using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;

namespace DDDSkeletonNET.Portal.ApplicationServices.Implementations
{
	public abstract class ApplicationServiceBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ApplicationServiceBase(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null) throw new ArgumentNullException("UnitOfWork");
			_unitOfWork = unitOfWork;
		}

		public IUnitOfWork UnitOfWork
		{
			get
			{
				return _unitOfWork;
			}
		}
	}
}
