using Application.DTOs;
using Infrastructure.Communication.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Communication.Adapters.Account;

public static class AccountAdapter
{
	public static AccountReques ToAccountRequest(this AccountRequestDto request)
	{
		return new AccountReques
		{
			FirstName = request.FirstName,
			LastName = request.LastName,
			Address1 = request.Address1,
			City = request.City,
			Country = request.Country,
			Email = request.Email
		};
	}
}
