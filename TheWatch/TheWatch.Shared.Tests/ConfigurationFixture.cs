
using Microsoft.Extensions.Configuration;

namespace TheWatch.Shared.Tests
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A configuration fixture. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ConfigurationFixture : IDisposable
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        ///
        /// <value> The settings. </value>
        ///-------------------------------------------------------------------------------------------------

        public Settings Settings { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public ConfigurationFixture()
        {
            // Build a config object, using env vars and JSON providers.
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Settings = config.GetRequiredSection(typeof(ConfigurationFixture).Namespace).Get<Settings>();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public void Dispose() { }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Collection of configurations. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [CollectionDefinition("Configuration collection")]
    public class ConfigurationCollection : ICollectionFixture<ConfigurationFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}