using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookStoreAccountService
    {
        Task<ResultDto> CreateAccount(AccountRequestDto request);
    }
}