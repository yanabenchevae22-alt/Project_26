using System.Collections.Generic;
using System.Linq;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.Data.Models;

namespace Rivers_Dams_Bulgaria.Controllers
{
    public class ReservoirController
    {
        private readonly MyContext context;

        public ReservoirController(MyContext context)
        {
            this.context = context;
        }

        public List<Reservoir> GetAll()
        {
            return context.Reservoirs.ToList();
        }

        public Reservoir? GetById(int id)
        {
            return context.Reservoirs.Find(id);
        }

        public void Add(Reservoir reservoir)
        {
            context.Reservoirs.Add(reservoir);
            context.SaveChanges();
        }

        public void Update(Reservoir newReservoir)
        {
            var reservoir = context.Reservoirs.Find(newReservoir.ReservoirId);
            if (reservoir != null)
            {
                context.Entry(reservoir).CurrentValues.SetValues(newReservoir);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var reservoir = context.Reservoirs.Find(id);
            if (reservoir != null)
            {
                context.Reservoirs.Remove(reservoir);
                context.SaveChanges();
            }
        }
    }
}
