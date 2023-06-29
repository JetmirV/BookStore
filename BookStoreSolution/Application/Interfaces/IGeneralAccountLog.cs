using Domain.Entities.AccountApi;

namespace Application.Interfaces;

public interface IGeneralAccountLog
{
	void InsertGeneralLog(GeneralLog log);
}