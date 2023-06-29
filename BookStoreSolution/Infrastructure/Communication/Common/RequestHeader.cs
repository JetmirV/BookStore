namespace Infrastructure.Communication.Common;

public class RequestHeader
{
	public RequestHeader(string name, string value)
	{
		this.Name = name;
		this.Value = value;
	}

	public string Name { get; set; }
	public string Value { get; set; }
}
