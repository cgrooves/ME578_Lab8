// NX 10.0.0.24
// Journal created by cgrooves on Thu Mar 29 12:27:46 2018 Mountain Daylight Time
//
using System;
using NXOpen;

public class NXJournal
{
  public static void Main(string[] args)
  {
    NXOpen.Session theSession = NXOpen.Session.GetSession();
    // ----------------------------------------------
    //   Menu: File->New...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId1;
    markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    NXOpen.FileNew fileNew1;
    fileNew1 = theSession.Parts.FileNew();
    
    theSession.SetUndoMarkName(markId1, "New Dialog");
    
    NXOpen.Session.UndoMarkId markId2;
    markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "New");
    
    theSession.DeleteUndoMark(markId2, null);
    
    NXOpen.Session.UndoMarkId markId3;
    markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "New");
    
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
    
    fileNew1.NewFileName = "J:\\SystemsEng\\ME578_Lab8\\NXRemotingProject\\model1.prt";
    
    fileNew1.MasterFileName = "";
    
    fileNew1.MakeDisplayedPart = true;
    
    NXOpen.NXObject nXObject1;
    nXObject1 = fileNew1.Commit();
    
    NXOpen.Part workPart = theSession.Parts.Work;
    NXOpen.Part displayPart = theSession.Parts.Display;
    theSession.DeleteUndoMark(markId3, null);
    
    fileNew1.Destroy();
    
    theSession.ApplicationSwitchImmediate("UG_APP_MODELING");
    
    NXOpen.Session.UndoMarkId markId4;
    markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Enter Gateway");
    
    NXOpen.Session.UndoMarkId markId5;
    markId5 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Enter Modeling");
    
    // ----------------------------------------------
    //   Menu: Insert->Sketch...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId6;
    markId6 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    NXOpen.Sketch nullNXOpen_Sketch = null;
    NXOpen.SketchInPlaceBuilder sketchInPlaceBuilder1;
    sketchInPlaceBuilder1 = workPart.Sketches.CreateNewSketchInPlaceBuilder(nullNXOpen_Sketch);
    
    NXOpen.Unit unit1 = (NXOpen.Unit)workPart.UnitCollection.FindObject("MilliMeter");
    NXOpen.Expression expression1;
    expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Expression expression2;
    expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.SketchAlongPathBuilder sketchAlongPathBuilder1;
    sketchAlongPathBuilder1 = workPart.Sketches.CreateSketchAlongPathBuilder(nullNXOpen_Sketch);
    
    theSession.SetUndoMarkName(markId6, "Create Sketch Dialog");
    
    NXOpen.Session.UndoMarkId markId7;
    markId7 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Create Sketch");
    
    theSession.DeleteUndoMark(markId7, null);
    
    NXOpen.Session.UndoMarkId markId8;
    markId8 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Create Sketch");
    
    theSession.Preferences.Sketch.CreateInferredConstraints = true;
    
    theSession.Preferences.Sketch.ContinuousAutoDimensioning = true;
    
    theSession.Preferences.Sketch.DimensionLabel = NXOpen.Preferences.SketchPreferences.DimensionLabelType.Expression;
    
    theSession.Preferences.Sketch.TextSizeFixed = true;
    
    theSession.Preferences.Sketch.FixedTextSize = 3.0;
    
    theSession.Preferences.Sketch.ConstraintSymbolSize = 3.0;
    
    theSession.Preferences.Sketch.DisplayObjectColor = false;
    
    theSession.Preferences.Sketch.DisplayObjectName = true;
    
    NXOpen.NXObject nXObject2;
    nXObject2 = sketchInPlaceBuilder1.Commit();
    
    NXOpen.Sketch sketch1 = (NXOpen.Sketch)nXObject2;
    NXOpen.Features.Feature feature1;
    feature1 = sketch1.Feature;
    
    NXOpen.Session.UndoMarkId markId9;
    markId9 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "update");
    
    int nErrs1;
    nErrs1 = theSession.UpdateManager.DoUpdate(markId9);
    
    sketch1.Activate(NXOpen.Sketch.ViewReorient.True);
    
    theSession.DeleteUndoMark(markId8, null);
    
    theSession.SetUndoMarkName(markId6, "Create Sketch");
    
    sketchInPlaceBuilder1.Destroy();
    
    sketchAlongPathBuilder1.Destroy();
    
    try
    {
      // Expression is still in use.
      workPart.Expressions.Delete(expression2);
    }
    catch (NXException ex)
    {
      ex.AssertErrorCode(1050029);
    }
    
    try
    {
      // Expression is still in use.
      workPart.Expressions.Delete(expression1);
    }
    catch (NXException ex)
    {
      ex.AssertErrorCode(1050029);
    }
    
    // ----------------------------------------------
    //   Menu: Insert->Sketch Curve->Profile...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId10;
    markId10 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Profile short list");
    
    NXOpen.Session.UndoMarkId markId11;
    markId11 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Curve");
    
    theSession.SetUndoMarkVisibility(markId11, "Curve", NXOpen.Session.MarkVisibility.Visible);
    
    NXOpen.Point3d startPoint1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point3d endPoint1 = new NXOpen.Point3d(46.1268812369983, 29.9551469258265, 0.0);
    NXOpen.Line line1;
    line1 = workPart.Curves.CreateLine(startPoint1, endPoint1);
    
    theSession.ActiveSketch.AddGeometry(line1, NXOpen.Sketch.InferConstraintsOption.InferNoConstraints);
    
    NXOpen.Sketch.ConstraintGeometry geom1_1 = new NXOpen.Sketch.ConstraintGeometry();
    geom1_1.Geometry = line1;
    geom1_1.PointType = NXOpen.Sketch.ConstraintPointType.StartVertex;
    geom1_1.SplineDefiningPointIndex = 0;
    NXOpen.Sketch.ConstraintGeometry geom2_1 = new NXOpen.Sketch.ConstraintGeometry();
    NXOpen.Features.DatumCsys datumCsys1 = (NXOpen.Features.DatumCsys)workPart.Features.FindObject("SKETCH(1:1B)");
    NXOpen.Point point1 = (NXOpen.Point)datumCsys1.FindObject("POINT 1");
    geom2_1.Geometry = point1;
    geom2_1.PointType = NXOpen.Sketch.ConstraintPointType.None;
    geom2_1.SplineDefiningPointIndex = 0;
    NXOpen.SketchGeometricConstraint sketchGeometricConstraint1;
    sketchGeometricConstraint1 = theSession.ActiveSketch.CreateCoincidentConstraint(geom1_1, geom2_1);
    
    NXOpen.Sketch.DimensionGeometry dimObject1_1 = new NXOpen.Sketch.DimensionGeometry();
    dimObject1_1.Geometry = line1;
    dimObject1_1.AssocType = NXOpen.Sketch.AssocType.StartPoint;
    dimObject1_1.AssocValue = 0;
    dimObject1_1.HelpPoint.X = 0.0;
    dimObject1_1.HelpPoint.Y = 0.0;
    dimObject1_1.HelpPoint.Z = 0.0;
    NXOpen.NXObject nullNXOpen_NXObject = null;
    dimObject1_1.View = nullNXOpen_NXObject;
    NXOpen.Sketch.DimensionGeometry dimObject2_1 = new NXOpen.Sketch.DimensionGeometry();
    dimObject2_1.Geometry = line1;
    dimObject2_1.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject2_1.AssocValue = 0;
    dimObject2_1.HelpPoint.X = 0.0;
    dimObject2_1.HelpPoint.Y = 0.0;
    dimObject2_1.HelpPoint.Z = 0.0;
    dimObject2_1.View = nullNXOpen_NXObject;
    NXOpen.Point3d dimOrigin1 = new NXOpen.Point3d(26.6124216000449, 9.51262199218674, 0.0);
    NXOpen.Expression nullNXOpen_Expression = null;
    NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint1;
    sketchDimensionalConstraint1 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.ParallelDim, dimObject1_1, dimObject2_1, dimOrigin1, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);
    
    NXOpen.SketchHelpedDimensionalConstraint sketchHelpedDimensionalConstraint1 = (NXOpen.SketchHelpedDimensionalConstraint)sketchDimensionalConstraint1;
    NXOpen.Annotations.Dimension dimension1;
    dimension1 = sketchHelpedDimensionalConstraint1.AssociatedDimension;
    
    NXOpen.Expression expression3;
    expression3 = sketchHelpedDimensionalConstraint1.AssociatedExpression;
    
    NXOpen.Sketch.DimensionGeometry dimObject1_2 = new NXOpen.Sketch.DimensionGeometry();
    NXOpen.DatumAxis datumAxis1 = (NXOpen.DatumAxis)workPart.Datums.FindObject("SKETCH(1:1B) X axis");
    dimObject1_2.Geometry = datumAxis1;
    dimObject1_2.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject1_2.AssocValue = 0;
    dimObject1_2.HelpPoint.X = 28.575;
    dimObject1_2.HelpPoint.Y = 0.0;
    dimObject1_2.HelpPoint.Z = 0.0;
    dimObject1_2.View = nullNXOpen_NXObject;
    NXOpen.Sketch.DimensionGeometry dimObject2_2 = new NXOpen.Sketch.DimensionGeometry();
    dimObject2_2.Geometry = line1;
    dimObject2_2.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject2_2.AssocValue = 0;
    dimObject2_2.HelpPoint.X = 46.1268812369983;
    dimObject2_2.HelpPoint.Y = 29.9551469258265;
    dimObject2_2.HelpPoint.Z = 0.0;
    dimObject2_2.View = nullNXOpen_NXObject;
    NXOpen.Point3d dimOrigin2 = new NXOpen.Point3d(6.24786837705089, 1.8507029280293, 0.0);
    NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint2;
    sketchDimensionalConstraint2 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.AngularDim, dimObject1_2, dimObject2_2, dimOrigin2, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);
    
    NXOpen.Annotations.Dimension dimension2;
    dimension2 = sketchDimensionalConstraint2.AssociatedDimension;
    
    NXOpen.Expression expression4;
    expression4 = sketchDimensionalConstraint2.AssociatedExpression;
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = false;
    
    theSession.ActiveSketch.Update();
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = true;
    
    NXOpen.Session.UndoMarkId markId12;
    markId12 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Curve");
    
    theSession.SetUndoMarkVisibility(markId12, "Curve", NXOpen.Session.MarkVisibility.Visible);
    
    NXOpen.Point3d startPoint2 = new NXOpen.Point3d(46.1268812369983, 29.9551469258265, 0.0);
    NXOpen.Point3d endPoint2 = new NXOpen.Point3d(77.5760197358645, -4.97265987161118, 0.0);
    NXOpen.Line line2;
    line2 = workPart.Curves.CreateLine(startPoint2, endPoint2);
    
    theSession.ActiveSketch.AddGeometry(line2, NXOpen.Sketch.InferConstraintsOption.InferNoConstraints);
    
    NXOpen.Sketch.ConstraintGeometry geom1_2 = new NXOpen.Sketch.ConstraintGeometry();
    geom1_2.Geometry = line2;
    geom1_2.PointType = NXOpen.Sketch.ConstraintPointType.StartVertex;
    geom1_2.SplineDefiningPointIndex = 0;
    NXOpen.Sketch.ConstraintGeometry geom2_2 = new NXOpen.Sketch.ConstraintGeometry();
    geom2_2.Geometry = line1;
    geom2_2.PointType = NXOpen.Sketch.ConstraintPointType.EndVertex;
    geom2_2.SplineDefiningPointIndex = 0;
    NXOpen.SketchGeometricConstraint sketchGeometricConstraint2;
    sketchGeometricConstraint2 = theSession.ActiveSketch.CreateCoincidentConstraint(geom1_2, geom2_2);
    
    NXOpen.Sketch.DimensionGeometry dimObject1_3 = new NXOpen.Sketch.DimensionGeometry();
    dimObject1_3.Geometry = line2;
    dimObject1_3.AssocType = NXOpen.Sketch.AssocType.StartPoint;
    dimObject1_3.AssocValue = 0;
    dimObject1_3.HelpPoint.X = 0.0;
    dimObject1_3.HelpPoint.Y = 0.0;
    dimObject1_3.HelpPoint.Z = 0.0;
    dimObject1_3.View = nullNXOpen_NXObject;
    NXOpen.Sketch.DimensionGeometry dimObject2_3 = new NXOpen.Sketch.DimensionGeometry();
    dimObject2_3.Geometry = line2;
    dimObject2_3.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject2_3.AssocValue = 0;
    dimObject2_3.HelpPoint.X = 0.0;
    dimObject2_3.HelpPoint.Y = 0.0;
    dimObject2_3.HelpPoint.Z = 0.0;
    dimObject2_3.View = nullNXOpen_NXObject;
    NXOpen.Point3d dimOrigin3 = new NXOpen.Point3d(57.0089645781627, 8.13104963084718, 0.0);
    NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint3;
    sketchDimensionalConstraint3 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.ParallelDim, dimObject1_3, dimObject2_3, dimOrigin3, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);
    
    NXOpen.SketchHelpedDimensionalConstraint sketchHelpedDimensionalConstraint2 = (NXOpen.SketchHelpedDimensionalConstraint)sketchDimensionalConstraint3;
    NXOpen.Annotations.Dimension dimension3;
    dimension3 = sketchHelpedDimensionalConstraint2.AssociatedDimension;
    
    NXOpen.Expression expression5;
    expression5 = sketchHelpedDimensionalConstraint2.AssociatedExpression;
    
    NXOpen.Sketch.DimensionGeometry dimObject1_4 = new NXOpen.Sketch.DimensionGeometry();
    dimObject1_4.Geometry = line1;
    dimObject1_4.AssocType = NXOpen.Sketch.AssocType.StartPoint;
    dimObject1_4.AssocValue = 0;
    dimObject1_4.HelpPoint.X = 0.0;
    dimObject1_4.HelpPoint.Y = 0.0;
    dimObject1_4.HelpPoint.Z = 0.0;
    dimObject1_4.View = nullNXOpen_NXObject;
    NXOpen.Sketch.DimensionGeometry dimObject2_4 = new NXOpen.Sketch.DimensionGeometry();
    dimObject2_4.Geometry = line2;
    dimObject2_4.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject2_4.AssocValue = 0;
    dimObject2_4.HelpPoint.X = 77.5760197358645;
    dimObject2_4.HelpPoint.Y = -4.97265987161118;
    dimObject2_4.HelpPoint.Z = 0.0;
    dimObject2_4.View = nullNXOpen_NXObject;
    NXOpen.Point3d dimOrigin4 = new NXOpen.Point3d(45.2763454802842, 23.4946864537456, 0.0);
    NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint4;
    sketchDimensionalConstraint4 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.AngularDim, dimObject1_4, dimObject2_4, dimOrigin4, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);
    
    NXOpen.Annotations.Dimension dimension4;
    dimension4 = sketchDimensionalConstraint4.AssociatedDimension;
    
    NXOpen.Expression expression6;
    expression6 = sketchDimensionalConstraint4.AssociatedExpression;
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = false;
    
    theSession.ActiveSketch.Update();
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = true;
    
    NXOpen.Session.UndoMarkId markId13;
    markId13 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Curve");
    
    theSession.SetUndoMarkVisibility(markId13, "Curve", NXOpen.Session.MarkVisibility.Visible);
    
    NXOpen.Point3d startPoint3 = new NXOpen.Point3d(77.5760197358645, -4.97265987161118, 0.0);
    NXOpen.Point3d endPoint3 = new NXOpen.Point3d(32.4707739381409, -21.3896267512432, 0.0);
    NXOpen.Line line3;
    line3 = workPart.Curves.CreateLine(startPoint3, endPoint3);
    
    theSession.ActiveSketch.AddGeometry(line3, NXOpen.Sketch.InferConstraintsOption.InferNoConstraints);
    
    NXOpen.Sketch.ConstraintGeometry geom1_3 = new NXOpen.Sketch.ConstraintGeometry();
    geom1_3.Geometry = line3;
    geom1_3.PointType = NXOpen.Sketch.ConstraintPointType.StartVertex;
    geom1_3.SplineDefiningPointIndex = 0;
    NXOpen.Sketch.ConstraintGeometry geom2_3 = new NXOpen.Sketch.ConstraintGeometry();
    geom2_3.Geometry = line2;
    geom2_3.PointType = NXOpen.Sketch.ConstraintPointType.EndVertex;
    geom2_3.SplineDefiningPointIndex = 0;
    NXOpen.SketchGeometricConstraint sketchGeometricConstraint3;
    sketchGeometricConstraint3 = theSession.ActiveSketch.CreateCoincidentConstraint(geom1_3, geom2_3);
    
    NXOpen.Sketch.DimensionGeometry dimObject1_5 = new NXOpen.Sketch.DimensionGeometry();
    dimObject1_5.Geometry = line3;
    dimObject1_5.AssocType = NXOpen.Sketch.AssocType.StartPoint;
    dimObject1_5.AssocValue = 0;
    dimObject1_5.HelpPoint.X = 0.0;
    dimObject1_5.HelpPoint.Y = 0.0;
    dimObject1_5.HelpPoint.Z = 0.0;
    dimObject1_5.View = nullNXOpen_NXObject;
    NXOpen.Sketch.DimensionGeometry dimObject2_5 = new NXOpen.Sketch.DimensionGeometry();
    dimObject2_5.Geometry = line3;
    dimObject2_5.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject2_5.AssocValue = 0;
    dimObject2_5.HelpPoint.X = 0.0;
    dimObject2_5.HelpPoint.Y = 0.0;
    dimObject2_5.HelpPoint.Z = 0.0;
    dimObject2_5.View = nullNXOpen_NXObject;
    NXOpen.Point3d dimOrigin5 = new NXOpen.Point3d(52.7947226033705, -7.05791117920219, 0.0);
    NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint5;
    sketchDimensionalConstraint5 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.ParallelDim, dimObject1_5, dimObject2_5, dimOrigin5, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);
    
    NXOpen.SketchHelpedDimensionalConstraint sketchHelpedDimensionalConstraint3 = (NXOpen.SketchHelpedDimensionalConstraint)sketchDimensionalConstraint5;
    NXOpen.Annotations.Dimension dimension5;
    dimension5 = sketchHelpedDimensionalConstraint3.AssociatedDimension;
    
    NXOpen.Expression expression7;
    expression7 = sketchHelpedDimensionalConstraint3.AssociatedExpression;
    
    NXOpen.Sketch.DimensionGeometry dimObject1_6 = new NXOpen.Sketch.DimensionGeometry();
    dimObject1_6.Geometry = line2;
    dimObject1_6.AssocType = NXOpen.Sketch.AssocType.StartPoint;
    dimObject1_6.AssocValue = 0;
    dimObject1_6.HelpPoint.X = 46.1268812369983;
    dimObject1_6.HelpPoint.Y = 29.9551469258265;
    dimObject1_6.HelpPoint.Z = 0.0;
    dimObject1_6.View = nullNXOpen_NXObject;
    NXOpen.Sketch.DimensionGeometry dimObject2_6 = new NXOpen.Sketch.DimensionGeometry();
    dimObject2_6.Geometry = line3;
    dimObject2_6.AssocType = NXOpen.Sketch.AssocType.EndPoint;
    dimObject2_6.AssocValue = 0;
    dimObject2_6.HelpPoint.X = 32.4707739381409;
    dimObject2_6.HelpPoint.Y = -21.3896267512432;
    dimObject2_6.HelpPoint.Z = 0.0;
    dimObject2_6.View = nullNXOpen_NXObject;
    NXOpen.Point3d dimOrigin6 = new NXOpen.Point3d(71.2533714171785, -3.39624659363336, 0.0);
    NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint6;
    sketchDimensionalConstraint6 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.AngularDim, dimObject1_6, dimObject2_6, dimOrigin6, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);
    
    NXOpen.Annotations.Dimension dimension6;
    dimension6 = sketchDimensionalConstraint6.AssociatedDimension;
    
    NXOpen.Expression expression8;
    expression8 = sketchDimensionalConstraint6.AssociatedExpression;
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = false;
    
    theSession.ActiveSketch.Update();
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = true;
    
    NXOpen.Session.UndoMarkId markId14;
    markId14 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Curve");
    
    theSession.SetUndoMarkVisibility(markId14, "Curve", NXOpen.Session.MarkVisibility.Visible);
    
    NXOpen.Point3d startPoint4 = new NXOpen.Point3d(32.4707739381409, -21.3896267512432, 0.0);
    NXOpen.Point3d endPoint4 = new NXOpen.Point3d(1.4210854715202e-014, 3.19744231092045e-014, 0.0);
    NXOpen.Line line4;
    line4 = workPart.Curves.CreateLine(startPoint4, endPoint4);
    
    theSession.ActiveSketch.AddGeometry(line4, NXOpen.Sketch.InferConstraintsOption.InferNoConstraints);
    
    NXOpen.Sketch.ConstraintGeometry geom1_4 = new NXOpen.Sketch.ConstraintGeometry();
    geom1_4.Geometry = line4;
    geom1_4.PointType = NXOpen.Sketch.ConstraintPointType.StartVertex;
    geom1_4.SplineDefiningPointIndex = 0;
    NXOpen.Sketch.ConstraintGeometry geom2_4 = new NXOpen.Sketch.ConstraintGeometry();
    geom2_4.Geometry = line3;
    geom2_4.PointType = NXOpen.Sketch.ConstraintPointType.EndVertex;
    geom2_4.SplineDefiningPointIndex = 0;
    NXOpen.SketchGeometricConstraint sketchGeometricConstraint4;
    sketchGeometricConstraint4 = theSession.ActiveSketch.CreateCoincidentConstraint(geom1_4, geom2_4);
    
    NXOpen.Sketch.ConstraintGeometry geom1_5 = new NXOpen.Sketch.ConstraintGeometry();
    geom1_5.Geometry = line4;
    geom1_5.PointType = NXOpen.Sketch.ConstraintPointType.EndVertex;
    geom1_5.SplineDefiningPointIndex = 0;
    NXOpen.Sketch.ConstraintGeometry geom2_5 = new NXOpen.Sketch.ConstraintGeometry();
    geom2_5.Geometry = line1;
    geom2_5.PointType = NXOpen.Sketch.ConstraintPointType.StartVertex;
    geom2_5.SplineDefiningPointIndex = 0;
    NXOpen.SketchGeometricConstraint sketchGeometricConstraint5;
    sketchGeometricConstraint5 = theSession.ActiveSketch.CreateCoincidentConstraint(geom1_5, geom2_5);
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = false;
    
    theSession.ActiveSketch.Update();
    
    theSession.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = true;
    
    NXOpen.Session.UndoMarkId markId15;
    markId15 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Curve");
    
    theSession.ActiveSketch.Update();
    
    // ----------------------------------------------
    //   Menu: File->Finish Sketch
    // ----------------------------------------------
    theSession.DeleteUndoMark(markId15, "Curve");
    
    NXOpen.Session.UndoMarkId markId16;
    markId16 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Deactivate Sketch");
    
    theSession.ActiveSketch.Deactivate(NXOpen.Sketch.ViewReorient.False, NXOpen.Sketch.UpdateLevel.Model);
    
    // ----------------------------------------------
    //   Menu: Insert->Design Feature->Extrude...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId17;
    markId17 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
    
    if ( !workPart.Preferences.Modeling.GetHistoryMode() )
    {
        throw new Exception("Create or edit of a Feature was recorded in History Mode but playback is in History-Free Mode.");
    }
    
    NXOpen.Features.ExtrudeBuilder extrudeBuilder1;
    extrudeBuilder1 = workPart.Features.CreateExtrudeBuilder(nullNXOpen_Features_Feature);
    
    NXOpen.Section section1;
    section1 = workPart.Sections.CreateSection(0.0095, 0.01, 0.5);
    
    extrudeBuilder1.Section = section1;
    
    extrudeBuilder1.AllowSelfIntersectingSection(true);
    
    NXOpen.Unit unit2;
    unit2 = extrudeBuilder1.Draft.FrontDraftAngle.Units;
    
    NXOpen.Expression expression9;
    expression9 = workPart.Expressions.CreateSystemExpressionWithUnits("2.00", unit2);
    
    extrudeBuilder1.DistanceTolerance = 0.01;
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies1 = new NXOpen.Body[1];
    NXOpen.Body nullNXOpen_Body = null;
    targetBodies1[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies1);
    
    extrudeBuilder1.Limits.StartExtend.Value.RightHandSide = "0";
    
    extrudeBuilder1.Limits.EndExtend.Value.RightHandSide = "25";
    
    extrudeBuilder1.Offset.StartOffset.RightHandSide = "0";
    
    extrudeBuilder1.Offset.EndOffset.RightHandSide = "5";
    
    NXOpen.GeometricUtilities.SmartVolumeProfileBuilder smartVolumeProfileBuilder1;
    smartVolumeProfileBuilder1 = extrudeBuilder1.SmartVolumeProfile;
    
    smartVolumeProfileBuilder1.OpenProfileSmartVolumeOption = false;
    
    smartVolumeProfileBuilder1.CloseProfileRule = NXOpen.GeometricUtilities.SmartVolumeProfileBuilder.CloseProfileRuleType.Fci;
    
    theSession.SetUndoMarkName(markId17, "Extrude Dialog");
    
    extrudeBuilder1.Limits.StartExtend.Value.RightHandSide = "0";
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies2 = new NXOpen.Body[1];
    targetBodies2[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies2);
    
    extrudeBuilder1.Limits.EndExtend.Value.RightHandSide = "25";
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies3 = new NXOpen.Body[1];
    targetBodies3[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies3);
    
    extrudeBuilder1.Draft.FrontDraftAngle.RightHandSide = "2";
    
    NXOpen.Expression expression10;
    expression10 = extrudeBuilder1.Draft.FrontDraftAngle;
    
    expression10.RightHandSide = "2";
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies4 = new NXOpen.Body[1];
    targetBodies4[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies4);
    
    extrudeBuilder1.Draft.BackDraftAngle.RightHandSide = "2";
    
    NXOpen.Expression expression11;
    expression11 = extrudeBuilder1.Draft.BackDraftAngle;
    
    expression11.RightHandSide = "2";
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies5 = new NXOpen.Body[1];
    targetBodies5[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies5);
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies6 = new NXOpen.Body[1];
    targetBodies6[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies6);
    
    extrudeBuilder1.Offset.StartOffset.RightHandSide = "0";
    
    NXOpen.Expression expression12;
    expression12 = extrudeBuilder1.Offset.StartOffset;
    
    expression12.RightHandSide = "0";
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies7 = new NXOpen.Body[1];
    targetBodies7[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies7);
    
    extrudeBuilder1.Offset.EndOffset.RightHandSide = "5";
    
    NXOpen.Expression expression13;
    expression13 = extrudeBuilder1.Offset.EndOffset;
    
    expression13.RightHandSide = "5";
    
    extrudeBuilder1.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    
    NXOpen.Body[] targetBodies8 = new NXOpen.Body[1];
    targetBodies8[0] = nullNXOpen_Body;
    extrudeBuilder1.BooleanOperation.SetTargetBodies(targetBodies8);
    
    section1.DistanceTolerance = 0.01;
    
    section1.ChainingTolerance = 0.0095;
    
    section1.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.OnlyCurves);
    
    NXOpen.Session.UndoMarkId markId18;
    markId18 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "section mark");
    
    NXOpen.Session.UndoMarkId markId19;
    markId19 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, null);
    
    NXOpen.Features.Feature[] features1 = new NXOpen.Features.Feature[1];
    NXOpen.Features.SketchFeature sketchFeature1 = (NXOpen.Features.SketchFeature)feature1;
    features1[0] = sketchFeature1;
    NXOpen.CurveFeatureRule curveFeatureRule1;
    curveFeatureRule1 = workPart.ScRuleFactory.CreateRuleCurveFeature(features1);
    
    section1.AllowSelfIntersection(true);
    
    NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
    rules1[0] = curveFeatureRule1;
    NXOpen.Point3d helpPoint1 = new NXOpen.Point3d(18.9227423228816, 12.2885725485992, 0.0);
    section1.AddToSection(rules1, line1, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);
    
    theSession.DeleteUndoMark(markId19, null);
    
    NXOpen.Direction direction1;
    direction1 = workPart.Directions.CreateDirection(sketch1, NXOpen.Sense.Forward, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    extrudeBuilder1.Direction = direction1;
    
    theSession.DeleteUndoMark(markId18, null);
    
    NXOpen.Matrix3x3 rotMatrix1 = new NXOpen.Matrix3x3();
    rotMatrix1.Xx = 0.995785390639825;
    rotMatrix1.Xy = 0.00278652832385416;
    rotMatrix1.Xz = 0.0916716480063017;
    rotMatrix1.Yx = 0.0321348457167462;
    rotMatrix1.Yy = 0.925574139900194;
    rotMatrix1.Yz = -0.377200030804317;
    rotMatrix1.Zx = -0.0858999853262609;
    rotMatrix1.Zy = 0.378556134289113;
    rotMatrix1.Zz = 0.921583661808862;
    NXOpen.Point3d translation1 = new NXOpen.Point3d(-0.994353322914343, 3.78730177538613, 2.69082860314663);
    workPart.ModelingViews.WorkView.SetRotationTranslationScale(rotMatrix1, translation1, 1.38117148010198);
    
    NXOpen.Session.UndoMarkId markId20;
    markId20 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Extrude");
    
    theSession.DeleteUndoMark(markId20, null);
    
    NXOpen.Session.UndoMarkId markId21;
    markId21 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Extrude");
    
    extrudeBuilder1.ParentFeatureInternal = false;
    
    NXOpen.Features.Feature feature2;
    feature2 = extrudeBuilder1.CommitFeature();
    
    theSession.DeleteUndoMark(markId21, null);
    
    theSession.SetUndoMarkName(markId17, "Extrude");
    
    NXOpen.Expression expression14 = extrudeBuilder1.Limits.StartExtend.Value;
    NXOpen.Expression expression15 = extrudeBuilder1.Limits.EndExtend.Value;
    extrudeBuilder1.Destroy();
    
    workPart.Expressions.Delete(expression9);
    
    // ----------------------------------------------
    //   Menu: File->Save
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId22;
    markId22 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    theSession.SetUndoMarkName(markId22, "Name Parts Dialog");
    
    NXOpen.Session.UndoMarkId markId23;
    markId23 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Name Parts");
    
    theSession.DeleteUndoMark(markId23, null);
    
    NXOpen.Session.UndoMarkId markId24;
    markId24 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Name Parts");
    
    workPart.AssignPermanentName("J:\\SystemsEng\\ME578_Lab8\\NXRemotingProject\\model1.prt");
    
    theSession.DeleteUndoMark(markId24, null);
    
    theSession.SetUndoMarkName(markId22, "Name Parts");
    
    NXOpen.PartSaveStatus partSaveStatus1;
    partSaveStatus1 = workPart.Save(NXOpen.BasePart.SaveComponents.True, NXOpen.BasePart.CloseAfterSave.False);
    
    partSaveStatus1.Dispose();
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
