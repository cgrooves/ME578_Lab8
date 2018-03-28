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
                string[] words = airFoilTextLines[i].Split(' ');
                try
                {
                    double x = 0;
                    double y = 0;

                    bool parseX = double.TryParse(words[0], out x);
                    bool parseY = double.TryParse(words[1], out y);
                    
                    if (parseX && parseY)
                    {
                        airFoilData.Add(new double[] { x, y });
                    }
                    else
                    {
                        System.Console.WriteLine("Line " + i + " is not a valid airfoil data point: " + airFoilTextLines[i]);
                    }                                        
                }
                catch
                {
                    System.Console.WriteLine("Line " + i + " is not a valid airfoil data point: " + airFoilTextLines[i]);
                }
                // If it fails, it's not airfoil data, discard it and move on
                // If it succeeds, add the doubles to the airFoilData
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            parseAirfoilText();
        }
    }
}
