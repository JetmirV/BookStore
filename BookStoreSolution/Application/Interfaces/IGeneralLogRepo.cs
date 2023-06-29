using Application.Enums;

namespace Application.Interfaces;

public interface IGeneralLogRepo
{
	void InsertGeneralLog(LogTypes logType, string logData);
}