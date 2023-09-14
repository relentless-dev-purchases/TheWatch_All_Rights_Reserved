
using Bunit;
using TheWatch.Shared.Components;

namespace TheWatch.Shared.Tests.Components
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A survey prompt tests. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class SurveyPromptTests : TestContext
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (Unit Test Method) creates survey prompt success. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        [Fact]
        public void Create_SurveyPrompt_Success()
        {
            // Arrange
            string title = "How is Blazor working for you?";

            // Act
            var cut = RenderComponent<SurveyPrompt>(
                parameters => parameters.Add(p => p.Title, title));

            // Assert
            cut.Find("strong").TextContent.MarkupMatches(title);
        }
    }
}