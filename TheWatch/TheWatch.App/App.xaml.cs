
using TheWatch.Shared;

namespace TheWatch.App
{
    public partial class App : Application
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        ///
        /// <value> The settings. </value>
        ///-------------------------------------------------------------------------------------------------

        public static Settings Settings { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}