
using Foundation;

namespace TheWatch.App
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An application delegate. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates maui application. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <returns>   The new maui application. </returns>
        ///-------------------------------------------------------------------------------------------------

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}