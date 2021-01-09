using Microsoft.EntityFrameworkCore;
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


        //Правильное использование асинхроного кода для интерфейса IQueryable
        public async Task<IQueryable<Sketch>> AllSketches()
        {
            return await context.Sketches.AsQueryable().ToListAsync();

        }

        


        public Task DeleteSketch(Sketch sketch)
        {
            throw new NotImplementedException();
        }

        public Task SaveSketch(Sketch sketch)
        {
            throw new NotImplementedException();
        }
    }
}
