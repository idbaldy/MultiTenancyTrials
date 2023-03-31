using System.Threading.Tasks;
using MultiTenancyTrials.Models.TokenAuth;
using MultiTenancyTrials.Web.Controllers;
using Shouldly;
using Xunit;

namespace MultiTenancyTrials.Web.Tests.Controllers
{
    public class HomeController_Tests: MultiTenancyTrialsWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}