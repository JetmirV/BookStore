using Application.Enums;

namespace Application.Interfaces;

public interface IGeneralOrderLog
{
	void InsertGeneralLog(LogTypes logType, string logData);
}