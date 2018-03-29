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
using Dumbo;
using System.Text.RegularExpressions;

namespace NXRemotingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Session theSession;
        UFSession theUFSession;

        public double[][] airfoilData;

        public MainWindow()
        {
            InitializeComponent();

            //theSession = (Session)Activator.GetObject(typeof(Session), "http://localhost:4567/NXOpenSession");
            //theUFSession = (UFSession)Activator.GetObject(typeof(UFSession), "http://localhost:4567/UFSession");
        }

        private void selectAirfoil(object sender, RoutedEventArgs e)
        {
            OpenFileDialog airFoilDialog = new OpenFileDialog();

            if (airFoilDialog.ShowDialog() == true)
            {
                // Get airfoil data, parse it and store it
                Parser parser = new Parser(airFoilDialog.FileName);
                airfoilData = parser.getAirfoilData();
                parser.printAirfoilData();

                // Display the filename in the text box
                filePath.Text = airFoilDialog.FileName;
            }
        }

        private void limitTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }


    }
}
