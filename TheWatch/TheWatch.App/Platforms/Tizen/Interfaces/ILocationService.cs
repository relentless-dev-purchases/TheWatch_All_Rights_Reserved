
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWatch.App.Platforms.Tizen.Interfaces
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for location service. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public interface ILocationService
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Queries if the location is enabled. </summary>
        ///
        /// <returns>   True if the location is enabled, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        bool IsLocationEnabled();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the permission. </summary>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------

        bool GetPermission();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the location. </summary>
        ///
        /// <returns>   The location. </returns>
        ///-------------------------------------------------------------------------------------------------

        string GetLocation();

        /// <summary>   Starts location updates. </summary>
        void StartLocationUpdates();

        /// <summary>   Stops location updates. </summary>
        void StopLocationUpdates();

        /// <summary>   Event queue for all listeners interested in LocationChanged events. </summary>
        event EventHandler<string> LocationChanged;

        /// <summary>   Event queue for all listeners interested in LocationError events. </summary>
        event EventHandler<string> LocationError;

        /// <summary>   Event queue for all listeners interested in LocationStatusChanged events. </summary>
        event EventHandler<string> LocationStatusChanged;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event queue for all listeners interested in LocationProviderEnabled events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event EventHandler<string> LocationProviderEnabled;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event queue for all listeners interested in LocationProviderDisabled events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event EventHandler<string> LocationProviderDisabled;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event queue for all listeners interested in LocationProviderStatusChanged events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event EventHandler<string> LocationProviderStatusChanged;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event queue for all listeners interested in LocationProviderStatusDisabled events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event EventHandler<string> LocationProviderStatusDisabled;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event queue for all listeners interested in LocationProviderStatusEnabled events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event EventHandler<string> LocationProviderStatusEnabled;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event queue for all listeners interested in LocationProviderStatusOutOfService events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event EventHandler<string> LocationProviderStatusOutOfService;
    }
}
