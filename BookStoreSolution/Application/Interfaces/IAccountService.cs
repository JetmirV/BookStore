using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccount(AccountRequestDto request);
    }
}