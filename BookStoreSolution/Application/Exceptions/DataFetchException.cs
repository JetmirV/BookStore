using System.Runtime.Serialization;

namespace Application.Exceptions;

public class DataFetchException : Exception
{
	public DataFetchException() { }

	public DataFetchException(string message) : base(message) { }

	public DataFetchException(string message, Exception? innerException) : base(message, innerException) { }

	protected DataFetchException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
