using Domain.Entities.AccountApi;

namespace Application.Interfaces;

public interface IAddressRepo
{
	Task<int> InsertAddress(Address address);
}