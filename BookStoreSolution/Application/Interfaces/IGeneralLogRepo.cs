using Domain.Entities.BookStore;

namespace Application.Interfaces;

public interface IGeneralLogRepo
{
	void InsertGeneralLog(GeneralLog log);
}