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
            fileNew1.NewFileName = @"C:\Program Files\Siemens\NX 10.0\UGII\airfoil.prt";
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
            // allocate the containers for all of the NXOpen.3dpoints and NXOpen.Lines
            int pointCount = airfoilData.Length-1; // remove redundant last point
            NXOpen.Point3d[] airfoilPoints = new NXOpen.Point3d[pointCount];
            NXOpen.Line[] airfoilLines = new NXOpen.Line[pointCount];

            // Get scale values
            double scale = Convert.ToDouble(scaleFactor.Text);
            double autoscale = 1;

            // create the first point
            airfoilPoints[0] = new NXOpen.Point3d(airfoilData[0][0]*scale*autoscale, airfoilData[0][1]*scale*autoscale, 0);

            // loop through each subsequent point in the airFoilData
            for (int i = 1; i < pointCount; i++)
            {
                // create the next point
                airfoilPoints[i] = new NXOpen.Point3d(airfoilData[i][0]*scale*autoscale, airfoilData[i][1]*scale*autoscale, 0);
                // create a line to connect it to the previous point
                airfoilLines[i - 1] = workPart.Curves.CreateLine(airfoilPoints[i - 1], airfoilPoints[i]);
                // add the line to the sketch
                sketch1.AddGeometry(airfoilLines[i - 1], Sketch.InferConstraintsOption.InferCoincidentConstraints);
            }

            // connect the last point to the first point
            airfoilLines[pointCount - 1] = workPart.Curves.CreateLine(airfoilPoints[pointCount - 1], airfoilPoints[0]);
            sketch1.AddGeometry(airfoilLines[pointCount - 1], Sketch.InferConstraintsOption.InferCoincidentConstraints);

            // Create an extrude from the sketch
            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;

            NXOpen.Features.ExtrudeBuilder extrudeBuilder1;
            extrudeBuilder1 = workPart.Features.CreateExtrudeBuilder(nullNXOpen_Features_Feature);

            NXOpen.Section section1;
            section1 = workPart.Sections.CreateSection(0.0095, 0.01, 0.5);
            extrudeBuilder1.Section = section1;
            extrudeBuilder1.AllowSelfIntersectingSection(true);
            extrudeBuilder1.DistanceTolerance = 1e-5;
            extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;

            NXOpen.Body[] targetBodies1 = new NXOpen.Body[1];
            NXOpen.Body nullNXOpen_Body = null;
            targetBodies1[0] = nullNXOpen_Body;
            extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies1);
            extrudeBuilder1.Limits.StartExtend.Value.RightHandSide = "0";
            extrudeBuilder1.Limits.EndExtend.Value.RightHandSide = extrudeLength.Text;
            extrudeBuilder1.Draft.FrontDraftAngle.RightHandSide = "2";
            extrudeBuilder1.Draft.BackDraftAngle.RightHandSide = "2";
            extrudeBuilder1.Offset.StartOffset.RightHandSide = "0";
            extrudeBuilder1.Offset.EndOffset.RightHandSide = "5";

            NXOpen.GeometricUtilities.SmartVolumeProfileBuilder smartVolumeProfileBuilder1;
            smartVolumeProfileBuilder1 = extrudeBuilder1.SmartVolumeProfile;

            smartVolumeProfileBuilder1.OpenProfileSmartVolumeOption = false;
            smartVolumeProfileBuilder1.CloseProfileRule = NXOpen.GeometricUtilities.SmartVolumeProfileBuilder.CloseProfileRuleType.Fci;
            section1.DistanceTolerance = 0.01;
            section1.ChainingTolerance = 0.0095;
            section1.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.OnlyCurves);

            NXOpen.Features.Feature[] features1 = new NXOpen.Features.Feature[1];
            NXOpen.Features.SketchFeature sketchFeature1 = (NXOpen.Features.SketchFeature)workPart.Features.FindObject("SKETCH(1)");
            features1[0] = sketchFeature1;
            NXOpen.CurveFeatureRule curveFeatureRule1;
            curveFeatureRule1 = workPart.ScRuleFactory.CreateRuleCurveFeature(features1);
            section1.AllowSelfIntersection(true);
            NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
            rules1[0] = curveFeatureRule1;
            NXOpen.NXObject nullNXOpen_NXObject = null;
            NXOpen.Point3d helpPoint1 = new NXOpen.Point3d(38.604206403219, 2.59588648435302, 0.0);
            section1.AddToSection(rules1, airfoilLines[0], nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);
            NXOpen.Direction direction1;
            direction1 = workPart.Directions.CreateDirection(sketch1, NXOpen.Sense.Forward, NXOpen.SmartObject.UpdateOption.WithinModeling);
            extrudeBuilder1.Direction = direction1;
            extrudeBuilder1.ParentFeatureInternal = false;
            feature1 = extrudeBuilder1.CommitFeature();
            NXOpen.Expression expression2;
            expression2 = extrudeBuilder1.Limits.StartExtend.Value;
            NXOpen.Expression expression3 = extrudeBuilder1.Limits.EndExtend.Value;
            extrudeBuilder1.Destroy();

        }
    }
}
