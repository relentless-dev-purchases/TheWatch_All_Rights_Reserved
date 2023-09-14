
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace TheWatch.App
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A program. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    internal class Program : MauiApplication
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates maui application. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <returns>   The new maui application. </returns>
        ///-------------------------------------------------------------------------------------------------

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Main entry-point for this application. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="args"> An array of command-line argument strings. </param>
        ///-------------------------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}