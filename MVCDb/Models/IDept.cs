using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDb.Models
{
	public interface IDept
	{
		List<Dept> GetDepts();
		Dept FindDept(int id);
		void AddDept(Dept dept);
		void EditDept(Dept dept);
		void DeleteDept(int id);

	}
}
