using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class ResetPassword : UseCase<bool>
    {
		public string Email { get; set; }
		public string NewPassword { get; set; }
    }

	public class ResetPasswordHander : IUseCaseHandler<ResetPassword, bool>
	{


		public Task<UseCaseResult<bool>> Handle(ResetPassword request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}

}
