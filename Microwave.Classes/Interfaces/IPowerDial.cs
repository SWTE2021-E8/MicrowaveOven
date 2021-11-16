using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    public interface IPowerDial
    {
        event EventHandler Dialed;

        void Dial(int powerLevel);
    }

    public class PowerChangedEventArgs : EventArgs
    {
        public int PowerLevel { get; set; }
    }
}
