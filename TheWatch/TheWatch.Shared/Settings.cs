
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWatch.Shared
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A settings. This class cannot be inherited. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public sealed class Settings
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets URL of the document. </summary>
        ///
        /// <value> The URL. </value>
        ///-------------------------------------------------------------------------------------------------

        public string? Url { get; set; }
    }
}