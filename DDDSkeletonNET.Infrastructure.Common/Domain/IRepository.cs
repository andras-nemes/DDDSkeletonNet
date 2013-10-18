using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Infrastructure.Common.Domain
{
	public interface IRepository<AggregateType, IdType> 
		: IReadOnlyRepository<AggregateType, IdType> where AggregateType 
		: IAggregateRoot
	{
		void Update(AggregateType aggregate);
		void Insert(AggregateType aggregate);
		void Delete(AggregateType aggregate);
	}
}
