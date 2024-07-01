using Ardalis.Result;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingBackend.BusinessLayer.Dtos;
using TestingBackend.BusinessLayer.Interfaces;
using TestingBackend.DataLayer;
using TestingBackend.DataLayer.Entities;

namespace TestingBackend.BusinessLayer.Services
{
    public class TestService : ITestService
    {
        private readonly TestingBackendDbContext _context;
        private readonly IMapper _mapper;

        public TestService(TestingBackendDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<TestDto>>> RetrieveAllTestsAsync()
        {
            try
            {
                var tests = await _context.Test.ToListAsync();
                var testDtos = _mapper.Map<List<TestDto>>(tests);

                return Result<List<TestDto>>.Success(testDtos);
            }
            catch (Exception ex)
            {
                return Result<List<TestDto>>.Error(ex.Message);
            }
        }

        public async Task<Result<TestDto>> RetrieveTestAsync(Guid testId)
        {
            try
            {
                var test = await _context.Test.FindAsync(testId);
                if (test == null)
                    return Result<TestDto>.NotFound();

                var testDto = _mapper.Map<TestDto>(test);
                return Result<TestDto>.Success(testDto);
            }
            catch (Exception ex)
            {
                return Result<TestDto>.Error(ex.Message);
            }
        }

        public async Task<Result<TestDto>> CreateTestAsync(TestDto testDto)
        {
            try
            {
                var test = _mapper.Map<Test>(testDto);
                test.Id = Guid.NewGuid(); // Assign new ID
                _context.Test.Add(test);
                await _context.SaveChangesAsync();

                testDto.Id = test.Id; // Update DTO with the new ID
                return Result<TestDto>.Success(testDto);
            }
            catch (Exception ex)
            {
                return Result<TestDto>.Error(ex.Message);
            }
        }

        public async Task<Result> DeleteTestAsync(Guid testId)
        {
            try
            {
                var test = await _context.Test.FindAsync(testId);
                if (test == null)
                    return Result.NotFound();

                _context.Test.Remove(test);
                await _context.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
