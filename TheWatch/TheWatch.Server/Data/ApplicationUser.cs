
using Microsoft.AspNetCore.Identity;

namespace TheWatch.Server.Data
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An application user. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ApplicationUser : IdentityUser
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ///-------------------------------------------------------------------------------------------------

        public string Name { get; set; }

        /*
        public string? Location { get; set; }

        public string? Bio { get; set; }

        public string? ProfilePicture { get; set; }

        public string? CoverPicture { get; set; }

        public string? Website { get; set; }

        public string? Facebook { get; set; } 

         */


    }
}
