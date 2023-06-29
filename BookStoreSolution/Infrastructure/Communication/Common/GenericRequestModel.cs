namespace Infrastructure.Communication.Common;

public class GenericRequestModel
{
	public string Url { get; set; }
	public string Method { get; set; } = "POST";
	public object Body { get; set; }
	public List<RequestHeader> Headers { get; set; } = new List<RequestHeader>();
	public string ContentType { get; set; } = "application/json";
}
