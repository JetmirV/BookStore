namespace Application.DTOs;

#nullable disable
public class AccountRequestDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }

	public string Address1 { get; set; }

	public string City { get; set; }

	public string? Country { get; set; }
}
