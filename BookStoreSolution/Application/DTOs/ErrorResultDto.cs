using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;
public class ErrorResultDto : ResultDto
{
	public ErrorResultDto()
	{

	}

	public ErrorResultDto(string errorMessage)
	{
		this.Message = errorMessage;
		this.Data = null!;
	}
}
