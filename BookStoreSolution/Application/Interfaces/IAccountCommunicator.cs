using Application.DTOs;

namespace Application.Interfaces;

public interface IAccountCommunicator
{
	Task<AccountResponseDto> CreateAccount(AccountRequestDto accountRequest);
}