using System;
using Microwave.Classes.Interfaces;


namespace Microwave.Classes.Boundary
{
    public class Buzzer : IBuzzer
    {
        private IOutput myOutput;

        public Buzzer(IOutput output)
        {
            myOutput = output;
        }
        public void shortSound()
        {
            Console.Beep();
            myOutput.OutputLine("Beep");
        }
    }
}