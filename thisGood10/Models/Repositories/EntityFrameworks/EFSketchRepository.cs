using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models.Repositories.Interfaces;


namespace thisGood10.Models.Repositories.EntityFrameworks
{
    public class EFSketchRepository : ISketchRepository
    {
        private AppDbContext context;

        public EFSketchRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Sketch> AllSketches()
        {  
            return context.Sketches;
        }

        public void DeleteSketch(Sketch sketch)
        {
            throw new NotImplementedException();
        }

        public void SaveSketch(Sketch sketch)
        {
            throw new NotImplementedException();
        }
    }
}
