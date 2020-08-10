using System;

namespace Chrome_dino_v2.Model
{
    public class TickEventArgs : EventArgs
    {
        public int Period { get; }

        public int TotalMsElapsed { get; }

        public TickEventArgs(int period, int totalMsElapsed)
        {
            Period = period;
            TotalMsElapsed = totalMsElapsed;
        }
    }
}
