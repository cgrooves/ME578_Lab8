using System;
using System.Collections.Generic;
using System.IO;

namespace Dumbo
{

    public class Parser
    {

        private bool splitFlag;
        private int splitIndex;
        private string airFoilText; // complete text from the airfoil data
        private List<double[]> airFoilData = new List<double[]>(); // List of ordered pairs for [x,y] data on airfoil

        // Parser Constructor
        public Parser(string filename)
        {
            // Initialize properties
            splitFlag = false;
            splitIndex = -1;

            // Read in airfoil file text
            airFoilText = System.IO.File.ReadAllText(filename);

            parseAirfoilText();
        }

        public double[][] getAirfoilData()
        {
            // construct the 2darray from the List<double[]>
            double[][] array2d = new double[airFoilData.Count][];

            airFoilData.CopyTo(array2d); // copy over list to array

            return array2d;
        }

        // Parses the airfoil data from the UIUC Applied Aerodynamics site.
        public void parseAirfoilText()
        {
            // To add to airFoilData the form is: airFoilData.Add(new double[] {value1, value2})
            string[] airFoilTextLines = airFoilText.Split('\n');
            int noLines = airFoilTextLines.GetLength(0);

            // For each line of text in the airFoilText
            for (int i = 0; i < noLines; i++)
            {
                // Try parsing out two doubles
                double[] coord = { 0, 0 };
                bool parseX = false;
                bool parseY = false;

                string[] words = airFoilTextLines[i].Split(' ');

                // Look in the line for doubles
                for (int j = 0; j < words.GetLength(0); j++)
                {
                    if (!parseX)
                    {
                        parseX = double.TryParse(words[j], out coord[0]);
                    }
                    else if (!parseY)
                    {
                        parseY = double.TryParse(words[j], out coord[1]);
                    }

                }

                // If it fails, it's not airfoil data, discard it and move on
                // If it succeeds, add the doubles to the airFoilData
                if (parseX && parseY)
                {
                    // check for those weird 
                    if (i == 1 && (coord[0] > 2 || coord[1] > 2))
                    {
                        System.Console.WriteLine("Line " + Convert.ToString(i + 1) + " has those weird large numbers: " + coord[0] + ", " + coord[1]);
                    }
                    else
                    {
                        // Debugging console message
                        System.Console.WriteLine("Line " + Convert.ToString(i + 1) + " contains the airfoil point: " + coord[0] + ", " + coord[1]);
                        // Write airfoil point to the airFoilData
                        airFoilData.Add(coord);
                    }
                }
                else if (!parseX && !parseY && i > (airFoilTextLines.Length/4)
                         && i < airFoilTextLines.Length - 1)
                {
                    System.Console.WriteLine("%%%% Airfoil is split it two segments!!!! %%%%");
                    splitFlag = true;
                    splitIndex = airFoilData.Count - 1;
                }
                else
                {
                    // Write out message that nothing happened
                    System.Console.WriteLine("Line " + Convert.ToString(i + 1) +
                                             " does not contain an airfoil point: "
                                             + airFoilTextLines[i]);
                    System.Console.WriteLine("\t--Contains " + words.Length + " words");
                }
            }

            //Additional operations for a split segment
            if (splitFlag)
            {
                organizeSplitSegment();
            }

            // Check that final point matches initial point
            double[] finalPt = airFoilData[airFoilData.Count-1];
            double[] initPt = airFoilData[0];

            if (finalPt[0] != initPt[0] || finalPt[1] != initPt[1])
                airFoilData.Add(initPt);

        } // end of parseAirfoilText()

        // Organizes the 2nd split segment back into the main container for the
        // airfoil points.
        private void organizeSplitSegment()
        {
            // Copy 2nd segment into an array2d

            // get length of second segment
            int count = airFoilData.Count;
            int seg2Start = splitIndex;
            //int seg2Length = count - seg2Start;

            // allocate and copy the 2nd segment data as is
            double[][] segment2 = new double[count][];
            airFoilData.CopyTo(segment2);

            // go through the array backwards
            // reassign elements the 2nd half of airFoilData to their opposites'
            int j = 1;
            for (int i = seg2Start; i < count-1; i++)
            {
                airFoilData[i] = segment2[count - j];
                j++;
            }

            // Remove final point if necessary
            double[] finalPt = airFoilData[count - 1];
            double [] splitPt = segment2[splitIndex];
            if (finalPt[0] == splitPt[0] && finalPt[1] == splitPt[1])
            {
                airFoilData.RemoveAt(count - 1);
            }

            // display confirmation message to screen
            System.Console.WriteLine("Swapped around segment 2");
        }

        // Prints out all of the 
        public void printAirfoilData()
        {
            System.Console.WriteLine("\n*************2D Array of Airfoil Points************");
            for (int i = 0; i < airFoilData.Count; i++)
            {
                System.Console.WriteLine("Pt " + (i+1) + "--> X: " + airFoilData[i][0] +
                                         ", Y: " + airFoilData[i][1]);
            }

            if (splitFlag)
            {
                System.Console.WriteLine("Airfoil is split at pt " + splitIndex);
            }
        }


    }
}
