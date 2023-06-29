using Domain.Entities.OrderApi;

namespace Application.Interfaces;

public interface IGeneralOrderLog
{
	void InsertGeneralLog(GeneralLog log);
}