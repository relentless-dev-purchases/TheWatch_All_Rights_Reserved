
using Microsoft.EntityFrameworkCore;

namespace TheWatch.Server.Data
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An application database context. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class ApplicationDbContext : DbContext
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="options">  Options for controlling the operation. </param>
        ///-------------------------------------------------------------------------------------------------

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


    }
}
