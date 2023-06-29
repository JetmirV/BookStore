using Domain.Entities.CartApi;

namespace Application.Interfaces;

public interface IGeneralCartLogRepo
{
	void InsertGeneralLog(GeneralLog log);
}