
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWatch.App.Platforms.Android.Interfaces
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for get permissions. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public interface IGetPermissions
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the permissions. </summary>
        ///
        /// <returns>   The permissions. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task<bool> GetPermissions();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the permissions. </summary>
        ///
        /// <param name="permission">   The permission. </param>
        ///
        /// <returns>   The permissions. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task<bool> GetPermissions(string permission);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the permissions. </summary>
        ///
        /// <param name="permissions">  The permissions. </param>
        ///
        /// <returns>   The permissions. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task<bool> GetPermissions(string[] permissions);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the permissions. </summary>
        ///
        /// <param name="permissions">  The permissions. </param>
        ///
        /// <returns>   The permissions. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task<bool> GetPermissions(List<string> permissions);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the permissions. </summary>
        ///
        /// <param name="permissions">  The permissions. </param>
        /// <param name="message">      The message. </param>
        ///
        /// <returns>   The permissions. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task<bool> GetPermissions(List<string> permissions, string message);
    }
}
