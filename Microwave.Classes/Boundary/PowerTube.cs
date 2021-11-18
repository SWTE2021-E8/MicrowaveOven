using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;
        private IPowerDial myPowerDial;

        private bool IsOn = false;

        public PowerTube(IOutput output, IPowerDial powerDial)
        {
            myOutput = output;
            myPowerDial = powerDial;
        }

        public void TurnOn(int power)
        {
            if (power < myPowerDial.lowerBound || power > myPowerDial.upperBound)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myPowerDial.Dial(power);
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}
