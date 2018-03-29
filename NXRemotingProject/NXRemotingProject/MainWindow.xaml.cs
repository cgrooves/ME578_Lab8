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

        public double[][] airfoilData = null;

        public MainWindow()
        {
            InitializeComponent();

            theSession = (Session)Activator.GetObject(typeof(Session), "http://localhost:4567/NXOpenSession");
            theUFSession = (UFSession)Activator.GetObject(typeof(UFSession), "http://localhost:4567/UFSession");
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

        private void createNXPart(object sender, RoutedEventArgs e)
        {
            // Check that an airfoil has been selected
            if (airfoilData == null)
            {
                MessageBox.Show("Please select an airfoil data file first (Step 1, you moron)");
                return;
            }

            // Initialize remote NX session
            //theSession = (Session)Activator.GetObject(typeof(Session), "http://localhost:4567/NXOpenSession");
            //theUFSession = (UFSession)Activator.GetObject(typeof(UFSession), "http://localhost:4567/UFSession");

            // Create new NX part file
            NXOpen.FileNew fileNew1 = theSession.Parts.FileNew();
            fileNew1.TemplateFileName = "model-plain-1-mm-template.prt";
            fileNew1.UseBlankTemplate = false;
            fileNew1.ApplicationName = "ModelTemplate";
            fileNew1.Units = NXOpen.Part.Units.Millimeters;
            fileNew1.RelationType = "";
            fileNew1.UsesMasterModel = "No";
            fileNew1.TemplateType = NXOpen.FileNewTemplateType.Item;
            fileNew1.TemplatePresentationName = "Model";
            fileNew1.ItemType = "";
            fileNew1.Specialization = "";
            fileNew1.SetCanCreateAltrep(false);
            fileNew1.NewFileName = @"C:\Program Files\Siemens\NX 10.0\UGII\";
            fileNew1.MasterFileName = "";
            fileNew1.MakeDisplayedPart = true;
            NXOpen.NXObject nXObject1;
            nXObject1 = fileNew1.Commit();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            fileNew1.Destroy();
            theSession.ApplicationSwitchImmediate("UG_APP_MODELING");

            // Create new sketch on XY plane
            NXOpen.Sketch nullNXOpen_Sketch = null;
            NXOpen.SketchInPlaceBuilder sketchInPlaceBuilder1 = workPart.Sketches.CreateNewSketchInPlaceBuilder(nullNXOpen_Sketch);
            NXOpen.SketchAlongPathBuilder sketchAlongPathBuilder1;
            sketchAlongPathBuilder1 = workPart.Sketches.CreateSketchAlongPathBuilder(nullNXOpen_Sketch);

            theSession.Preferences.Sketch.CreateInferredConstraints = true;
            theSession.Preferences.Sketch.ContinuousAutoDimensioning = true;

            NXOpen.NXObject nXObject2;
            nXObject2 = sketchInPlaceBuilder1.Commit();
            NXOpen.Sketch sketch1 = (NXOpen.Sketch)nXObject2;
            NXOpen.Features.Feature feature1;
            feature1 = sketch1.Feature;

            sketch1.Activate(NXOpen.Sketch.ViewReorient.True);

            sketchInPlaceBuilder1.Destroy();
            sketchAlongPathBuilder1.Destroy();

            // Create points from airfoil data
            // Create lines from point to point
            // Create an extrude from those points
        }
    }
}
