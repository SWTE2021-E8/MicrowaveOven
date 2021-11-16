using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerDial : IPowerDial
    {
        public event EventHandler Dialed;

        private int lowerBound;
        private int upperBound;

        public PowerDial(int lowerBound = 1, int upperBound = 700)
        {
            if (lowerBound > 0 && upperBound > lowerBound)
            {
                this.lowerBound = lowerBound;
                this.upperBound = upperBound;
            }
            else
            {
                this.lowerBound = 1;
                this.lowerBound = 700;
            }

        }

        public void Dial(int powerLevel)
        {
            checkPowerLevel(powerLevel);
            PowerChangedEventArgs args = new PowerChangedEventArgs { PowerLevel = powerLevel };
            Dialed?.Invoke(this, args);
        }

        private void checkPowerLevel(int powerLevel)
        {
            if (powerLevel < lowerBound || powerLevel > upperBound)
                throw new ArgumentOutOfRangeException();
        }
    }

}
