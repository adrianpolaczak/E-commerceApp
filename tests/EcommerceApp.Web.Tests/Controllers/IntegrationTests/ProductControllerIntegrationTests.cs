using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EcommerceApp.Web.Tests.Controllers.IntegrationTests
{
    public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _sut;
        private readonly HttpClient _client;

        public ProductControllerIntegrationTests(WebApplicationFactory<Startup> sut)
        {
            _sut = sut;
            _client = _sut.GetGuestHttpClient();
        }

        [Fact]
        public async Task Product_ReturnsSuccessAndCorrectContentTypeWhenIdHasValue()
        {
            // Act
            var response = await _client.GetAsync("/Product/Product/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Product_ReturnsNotFoundWhenIdHasNoValue()
        {
            // Act
            var response = await _client.GetAsync("/Product/Product");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
