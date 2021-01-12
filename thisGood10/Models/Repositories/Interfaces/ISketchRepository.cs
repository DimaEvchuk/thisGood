using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models.Repositories.Interfaces
{
    public interface ISketchRepository
    {
       
        Task<IEnumerable<Sketch>> AllSketches();
        Task SaveSketch(Sketch sketch);
        Task DeleteSketch(Sketch sketch);

    }
}
