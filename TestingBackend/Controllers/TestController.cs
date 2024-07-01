using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using TestingBackend.BusinessLayer.Dtos;
using TestingBackend.BusinessLayer.Interfaces;

namespace TestingBackend.Api.Controllers
{
    /// <summary>
    /// Represents an API for tests.
    /// </summary>
    [ApiController, Route("api/test")]
    public class TestController : BaseServiceController<ITestService>
    {
        public TestController(ITestService service) : base(service)
        {
        }

        /// <summary>
        /// Retrieves the Tests.
        /// </summary>
        /// <returns> The Tests. </returns>
        [HttpGet(Name = nameof(RetrieveAllTestsAsync))]
        public async Task<Result<List<TestDto>>> RetrieveAllTestsAsync()
        {
            return await _service.RetrieveAllTestsAsync();
        }

        /// <summary>
        /// Retrieves the Test given by it's id.
        /// </summary>
        /// <param name="testId"> The id of the test to retrieve. </param>
        /// <returns> The Test with given id. </returns>
        [HttpGet("{testId}", Name = nameof(RetrieveTestAsync))]
        public async Task<Result<TestDto>> RetrieveTestAsync([FromRoute] Guid testId)
        {
            return await _service.RetrieveTestAsync(testId);
        }

        /// <summary>
        /// Creates a Test.
        /// </summary>
        /// <param name="testId"> The id of the test to retrieve. </param>
        [HttpPost("test", Name = nameof(CreateTestAsync))]
        public async Task<Result<TestDto>> CreateTestAsync([FromBody] TestDto newTest)
        {
            return await _service.CreateTestAsync(newTest);
        }

        /// <summary>
        /// Deletes the Test given by it's id.
        /// </summary>
        /// <param name="testId"> The id of the test to retrieve. </param>
        [HttpDelete("{testId}", Name = nameof(DeleteTestAsync))]
        public async Task<Result> DeleteTestAsync([FromRoute] Guid testId)
        {
            return await _service.DeleteTestAsync(testId);
        }
    }
}
