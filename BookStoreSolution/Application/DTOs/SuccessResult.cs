namespace Application.DTOs;

public class SuccessResult : ResultDto
{
	public SuccessResult()
	{

	}

	public SuccessResult(object data)
	{
		this.Data = data;
	}
	public string Message { get { return "Success!"; } }
}
