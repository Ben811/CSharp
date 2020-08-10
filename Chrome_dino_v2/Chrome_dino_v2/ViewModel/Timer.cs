using Chrome_dino_v2.Model;
using Chrome_dino_v2.View;
using System;
using System.Security.Permissions;
using System.Threading;
using System.Windows;

namespace Chrome_dino_v2.ViewModel
{
    public class Timer
    {
        private Action<object, TickEventArgs> _tick;
        public event Action<object, TickEventArgs> Tick
        {
            add { _tick += value; }
            remove { _tick -= value; }
        }

        private int _period;
        public int Period
        {
            get => _period;
            set
            {
                if (value > 0) _period = value;
                else _period = 100;
            }
        }

        private readonly Thread thread;
        private readonly GameView mainWindow;

        public bool TimerControl { get; set; }
        public int TotalMsElapsed { get; private set; }
        public Timer(int initPeriodInMS, GameView pMainWindow)
        {
            Period = initPeriodInMS;

            thread = new Thread(TiminigThread);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            mainWindow = pMainWindow;
        }

        public void Start()
        {
            TimerControl = true;
        }

        public void Stop()
        {
            TimerControl = false;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void Terminate()
        {
            try
            {
                Stop();
                thread.Abort();
            }
            catch (Exception)
            {
            }
            
        }

        public void ResetTimeElapsed()
        {
            TotalMsElapsed = 0;
        }
        private void TiminigThread()
        {
            while (true)
            {
                while (TimerControl)
                {
                    Thread.Sleep(_period);
                    TotalMsElapsed += _period;
                    Ontick(new TickEventArgs(_period, TotalMsElapsed));
                }
            }

        }

        private void Ontick(TickEventArgs tickEventArgs)
        {
            try
            {
                mainWindow.Dispatcher.Invoke(() => _tick?.Invoke(this, tickEventArgs));
            }
            catch (Exception)
            {
            }
           
        }


    }
}
