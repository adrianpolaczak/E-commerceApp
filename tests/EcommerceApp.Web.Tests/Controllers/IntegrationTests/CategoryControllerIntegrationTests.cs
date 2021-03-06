using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EcommerceApp.Web.Tests.Controllers.IntegrationTests
{
    public class CategoryControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _sut;
        private readonly HttpClient _client;

        public CategoryControllerIntegrationTests(WebApplicationFactory<Startup> sut)
        {
            // Arrange
            _sut = sut;
            _client = _sut.GetGuestHttpClient();
        }

        [Fact]
        public async Task Products_ReturnSuccessAndCorrectContentType()
        {
            // Act
            var response = await _client.GetAsync("/Category/Products?categoryId=1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Products_ReturnReturnNotFound()
        {
            // Act
            var response = await _client.GetAsync("/Category/Products");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
