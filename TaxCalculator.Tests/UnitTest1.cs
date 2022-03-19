using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TaxServiceCalculateTax_ShouldCallTaxCalculator()
        {
            var calcMock = new Mock<ITaxCalculator>();
            
            calcMock.Setup(x => x.CalculateTaxAsync(It.IsAny<CalculateTaxRequest>()))
            .Returns(It.IsAny<Task<CalculateTaxResponse>>());

            var taxService = new TaxService(calcMock.Object);
            var request = new CalculateTaxRequest { ToCountry = "US" };
            taxService.CalculateTaxAsync(request);

            calcMock.Verify(x => x.CalculateTaxAsync(It.IsAny<CalculateTaxRequest>()),
                Times.AtLeastOnce);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TaxServiceCalculateTax_ShouldThrowException_WithoutProperValues()
        {
            var calcMock = new Mock<ITaxCalculator>();

            calcMock.Setup(x => x.CalculateTaxAsync(It.IsAny<CalculateTaxRequest>()))
            .Returns(It.IsAny<Task<CalculateTaxResponse>>());

            var taxService = new TaxService(calcMock.Object);

            taxService.CalculateTaxAsync(new CalculateTaxRequest());

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TaxServiceTaxRate_ShouldThrowException_WithNoZipCode()
        {
            var calcMock = new Mock<ITaxCalculator>();

            calcMock.Setup(x => x.GetTaxRate(It.IsAny<GetTaxRateRequest>()))
            .Returns(It.IsAny<Task<GetTaxRateResponse>>());

            var taxService = new TaxService(calcMock.Object);

            taxService.GetTaxRate(new GetTaxRateRequest());

        }




        [TestMethod]
        public void TaxJarCalculator_ShouldInvokeHttpClient()
        {
            var httpMock = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("test"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            httpMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            var tax = new TaxJarCalculator(httpMock.Object);
            tax.GetTaxRate(new GetTaxRateRequest { ZipCode = "45245" });

           

            httpMock.Verify(x => x.CreateClient(It.IsAny<string>()),Times.Once);
            
        }


    }
}
