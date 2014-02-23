using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public interface IScalable
    {
        void LevelUp();

        int CurrentXp { get; }

        int NeededXP { get; }
    }
}
