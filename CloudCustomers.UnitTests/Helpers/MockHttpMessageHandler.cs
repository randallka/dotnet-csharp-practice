
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace CloudCustomers.UnitTests.Helpers
{
	internal static class MockHttpMessageHandler<T>
	{
		//method to return a mock http handler to return a response
		internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
		{
			var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
			{
				Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
			};

			mockResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			var handlerMock = new Mock<HttpMessageHandler>();

			handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(mockResponse);

			return handlerMock;
		}
	}
}

