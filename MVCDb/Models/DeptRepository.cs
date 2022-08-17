using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDb.Models
{
	public class DeptRepository : IDept
	{
		DB1045Context db = new DB1045Context();
		public void AddDept(Dept dept)
		{
			db.Depts.Add(dept);
			db.SaveChanges();
		}

		public void DeleteDept(int id)
		{
			Dept dept = db.Depts.Find(id);
			db.Depts.Remove(dept);
			db.SaveChanges();
		}

		public void EditDept(Dept dept)
		{
			Dept odept = db.Depts.Find(dept.Id);
			odept.Name = dept.Name;
			odept.Location = dept.Location;
			db.SaveChanges();

		}

		public Dept FindDept(int id)
		{
			//var data = (from dept in db.Depts where dept.Id == id select dept).FirstOrDefault();
			var data = db.Depts.Find(id);
			
			return data;
		}

		public List<Dept> GetDepts()
		{
			var data = from dept in db.Depts select dept;
			return data.ToList();

		}
	}
}
