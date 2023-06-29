using Application.DTOs;

namespace Application.Interfaces;

public interface IAccountCommunicator
{
	Task<bool> CreateAccount(AccountRequestDto accountRequest);
}