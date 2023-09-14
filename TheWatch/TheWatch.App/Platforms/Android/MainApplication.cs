
using Android.App;
using Android.Runtime;

namespace TheWatch.App
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A main application. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [Application]
    public class MainApplication : MauiApplication
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="handle">       The handle. </param>
        /// <param name="ownership">    The ownership. </param>
        ///-------------------------------------------------------------------------------------------------

        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

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