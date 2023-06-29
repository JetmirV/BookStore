using Domain.Entities.AccountApi;

namespace Application.Interfaces;

public interface IAccountRepo
{
	Task<int> InsertAccount(Account account);
}