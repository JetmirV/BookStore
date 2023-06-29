using Application.Enums;

namespace Application.Interfaces;

public interface IGeneralCartLogRepo
{
	void InsertGeneralLog(LogTypes logType, string logData);
}