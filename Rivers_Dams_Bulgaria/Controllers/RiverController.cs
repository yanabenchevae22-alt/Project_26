using System.Collections.Generic;
using System.Linq;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.Data.Models;

namespace Rivers_Dams_Bulgaria.Controllers
{
    public class RiverController
    {
        private readonly MyContext context;

        public RiverController(MyContext context)
        {
            this.context = context;
        }

        public List<River> GetAll()
        {
            return context.Rivers.ToList();
        }

        public River? GetById(int id)
        {
            return context.Rivers.Find(id);
        }

        public void Add(River river)
        {
            context.Rivers.Add(river);
            context.SaveChanges();
        }

        public void Update(River newRiver)
        {
            var river = context.Rivers.Find(newRiver.RiverId);

            if (river != null)
            {
                context.Entry(river).CurrentValues.SetValues(newRiver);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var river = context.Rivers.Find(id);

            if (river != null)
            {
                context.Rivers.Remove(river);
                context.SaveChanges();
            }
        }
    }
}
