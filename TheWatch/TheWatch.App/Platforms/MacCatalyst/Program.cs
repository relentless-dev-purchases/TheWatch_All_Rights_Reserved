
using ObjCRuntime;
using UIKit;

namespace TheWatch.App
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A program. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Program
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   This is the main entry point of the application. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="args"> An array of command-line argument strings. </param>
        ///-------------------------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}