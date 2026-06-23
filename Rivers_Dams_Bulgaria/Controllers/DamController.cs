using System.Collections.Generic;
using System.Linq;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.Data.Models;

namespace Rivers_Dams_Bulgaria.Controllers
{
	public class DamController
	{
		private readonly MyContext context;

		public DamController(MyContext context)
		{
			this.context = context;
		}

		public List<Dam> GetAll()
		{
			return context.Dams.ToList();
		}

		public Dam? GetById(int id)
		{
			return context.Dams.Find(id);
		}

		public void Add(Dam dam)
		{
			context.Dams.Add(dam);
			context.SaveChanges();
		}

		public void Update(Dam newDam)
		{
			var dam = context.Dams.Find(newDam.DamId);
			if (dam != null)
			{
				context.Entry(dam).CurrentValues.SetValues(newDam);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var dam = context.Dams.Find(id);
			if (dam != null)
			{
				context.Dams.Remove(dam);
				context.SaveChanges();
			}
		}
	}
}
