using Bowling.Score.Calculator.Infrastructure.Exceptions;

namespace Bowling.Score.Calculator.Model
{
    public class Frame
    {
        public int? FirstBall { get; set; }

        private int? _secondBall;
        public int? SecondBall 
        {
            get { return _secondBall; } 
            set
            {
                if ( !FirstBall.HasValue || FirstBall.Value == 10)
                {
                    throw new ScorerException("Unable to set value. Frame is either a strike or FirstBall has not been set.");
                }
                _secondBall = value;
            } 
        }
        public int Score { 
            get 
            { 
                return FirstBall.HasValue && SecondBall.HasValue ?
                        FirstBall.Value + SecondBall.Value : 0;
            }  
        }
        public bool IsStrike { get { return FirstBall.HasValue && FirstBall.Value == 10; }  }
        public bool IsSpare { 
            get 
            {
                return FirstBall.HasValue && SecondBall.HasValue
                        && (FirstBall.Value + SecondBall.Value == 10);
            }
        }
    }
}
