using Application.Enums;

namespace Application.Interfaces;

public interface IGeneralAccountLog
{
	void InsertGeneralLog(LogTypes logType, string logData);
}