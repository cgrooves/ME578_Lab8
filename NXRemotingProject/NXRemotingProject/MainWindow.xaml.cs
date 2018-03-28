using NXOpen;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace NXRemotingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Session theSession;
        UFSession theUFSession;

        string airFoilText; // complete text from the airfoil data
        List<double[]> airFoilData = new List<double[]>(); // List of ordered pairs for [x,y] data on airfoil
        public MainWindow()
        {
            InitializeComponent();

            //theSession = (Session)Activator.GetObject(typeof(Session), "http://localhost:4567/NXOpenSession");
            //theUFSession = (UFSession)Activator.GetObject(typeof(UFSession), "http://localhost:4567/UFSession");
        }

        private void selectAirfoil(object sender, RoutedEventArgs e)
        {
            OpenFileDialog airFoilDialog = new OpenFileDialog();
            //airFoilDialog.Filter = "Airfoil data (*.dat)|*.dat|All files (*.*)|*.*";
            if (airFoilDialog.ShowDialog() == true)
                airFoilText = File.ReadAllText(airFoilDialog.FileName);
        }

        // Parses the airfoil data from the UIUC Applied Aerodynamics site.
        private void parseAirfoilText()
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
                    // Debugging console message
                    System.Console.WriteLine("Line " + (i+1) + " contains the airfoil point: " + coord[0] + ", " + coord[1]);
                    // Write airfoil point to the airFoilData
                    airFoilData.Add(coord);
                }
                else
                {
                    // Write out message that nothing happened
                    System.Console.WriteLine("Line " + (i+1) + " does not contain an airfoil point.");
                }
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            parseAirfoilText();
        }
    }
}
