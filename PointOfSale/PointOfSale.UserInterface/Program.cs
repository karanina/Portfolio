using System;
using System.Windows.Forms;

namespace PointOfSale.UserInterface
{
static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        // Have to fully qualify this so compiler doesn't get confused with PointOfSale.Application in project references.
        System.Windows.Forms.Application.Run(new MainForm());
    }    
}}