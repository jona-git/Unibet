using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Score.Calculator.Validation
{
    public interface IGameValidator
    {        
        void ValidateScores(int[] scores);
    }
}
