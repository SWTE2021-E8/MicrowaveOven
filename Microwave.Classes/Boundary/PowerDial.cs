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

        public int lowerBound { get; private set; } = 1;
        public int upperBound { get; private set; } = 700;

        private IOutput myOutput;

        public PowerDial(IOutput output, int lowerBound = 1, int upperBound = 700)
        {
            myOutput = output;
            setBounds(lowerBound, upperBound);
        }

        public void Dial(int powerLevel)
        {
            checkPowerLevel(powerLevel);
            myOutput.OutputLine($"PowerTube works with {powerLevel}");
            PowerChangedEventArgs args = new PowerChangedEventArgs { PowerLevel = powerLevel };
            Dialed?.Invoke(this, args);
        }

        private void setBounds(int lowerBound, int upperBound)
        {
            if (lowerBound > 0 && upperBound > lowerBound)
            {
                this.lowerBound = lowerBound;
                this.upperBound = upperBound;
            }
        }

        private void checkPowerLevel(int powerLevel)
        {
            if (powerLevel < lowerBound || powerLevel > upperBound)
                throw new ArgumentOutOfRangeException();
        }
    }

}
