using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.UseCases
{
	public class UseCaseResult<TEntity>
	{
		public string ResultCode { get; set; }
		public string ResultText { get; set; }

		//public CommandContext CommandContext;

		public TEntity Data { get; set; }

		public static UseCaseResult<TEntity> Create(TEntity data, string resultCode = "OK", string resultText = "" )
		{
			return new UseCaseResult<TEntity>
			{
				ResultCode = resultCode,
				ResultText = resultText,
				Data = data
			};
		}

		public static UseCaseResult<TEntity> CreateError(string resultCode = "Error", string resultText = "")
		{
			return new UseCaseResult<TEntity>
			{
				ResultCode = resultCode,
				ResultText = resultText,
				Data = default(TEntity)
			};
		}

	}
}
