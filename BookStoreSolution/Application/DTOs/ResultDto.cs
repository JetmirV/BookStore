namespace Application.DTOs;

public class ResultDto
{
	public string Message { get; set; } = string.Empty;
	public object Data { get; set; } = null!;
}
