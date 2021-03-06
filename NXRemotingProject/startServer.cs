// NX 10.0.0.24
// Journal created by cgrooves on Thu Mar 29 13:11:46 2018 Mountain Daylight Time
//
using System;
using NXOpen;

public class NXJournal
{
  public static void Main(string[] args)
  {
    NXOpen.Session theSession = NXOpen.Session.GetSession();
    // ----------------------------------------------
    //   Menu: File->Execute->NX Open...
    // ----------------------------------------------
    theSession.LogFile.WriteLine("In NXOpenRemotingService.Main - getting session\n"
    "");
    
    theSession.LogFile.WriteLine("Starting NX Service\n"
    "");
    
    theSession.LogFile.WriteLine("\n"
    "\n"
    "");
    
    theSession.LogFile.WriteLine("Exporting Session object");
    
    theSession.LogFile.WriteLine("Exporting UFSession Object");
    
    theSession.LogFile.WriteLine("NX Service started on port 4567\n"
    "");
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
