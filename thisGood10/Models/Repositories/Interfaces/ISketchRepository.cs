using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models.Repositories.Interfaces
{
    public interface ISketchRepository
    {
        IQueryable<Sketch> AllSketches();
        void SaveSketch(Sketch sketch);
        void DeleteSketch(Sketch sketch);

    }
}
