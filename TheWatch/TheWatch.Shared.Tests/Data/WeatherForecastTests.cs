
using System.Diagnostics;
using TheWatch.Shared.OpenAPI;

namespace TheWatch.Shared.Tests
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A weather forecast tests. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [Collection("Configuration collection")]
    public class WeatherForecastTests
    {
        /// <summary>   (Immutable) options for controlling the operation. </summary>
        private readonly Settings settings;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="config">   The configuration. </param>
        ///-------------------------------------------------------------------------------------------------

        public WeatherForecastTests(ConfigurationFixture config)
        {
            this.settings = config.Settings;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) sets temperature c success. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [Fact]
        public void Set_TemperatureC_Success()
        {
            // Arrange
            var data = new WeatherForecast
            {
                // Act
                TemperatureC = 1
            };

            // Assert
            Assert.Equal(1, data.TemperatureC);

            Debug.WriteLine("Set_TemperatureC_Success");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) gets weather forecast data success asynchronous. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <returns>   A Task. </returns>
        ///-------------------------------------------------------------------------------------------------

        [Fact]
        public async Task Get_WeatherForecastData_SuccessAsync()
        {
            // Arrange
            ICollection<WeatherForecast>? forecasts;
            AppServices appServices = new(settings.Url, new HttpClient());

            // Act
            forecasts = await appServices.WeatherForecastAsync();

            // Assert
            Assert.Equal(6, forecasts.Count);
        }
    }
}