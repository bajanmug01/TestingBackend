using Ardalis.Result;
using TestingBackend.BusinessLayer.Dtos;

namespace TestingBackend.BusinessLayer.Interfaces
{
    public interface ITestService
    {
        /// <summary>
        /// bla
        /// </summary>
        /// <returns></returns>
        Task<Result<List<TestDto>>> RetrieveAllTestsAsync();

        /// <summary>
        /// bla
        /// </summary>
        /// <returns></returns>
        Task<Result<TestDto>> RetrieveTestAsync(Guid testId);

        /// <summary>
        /// bla
        /// </summary>
        /// <returns></returns>
        Task<Result<TestDto>> CreateTestAsync(TestDto test);

        /// <summary>
        /// bla
        /// </summary>
        /// <returns></returns>
        Task<Result> DeleteTestAsync(Guid testId);
    }
}
