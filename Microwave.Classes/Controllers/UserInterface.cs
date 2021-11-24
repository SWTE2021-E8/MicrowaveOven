using System;
using System.Runtime.Serialization;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Controllers
{
    public class UserInterface : IUserInterface
    {
        private enum States
        {
            READY, SETPOWER, SETTIME, COOKING, DOOROPEN
        }

        private States myState = States.READY;

        private ICookController myCooker;
        private ILight myLight;
        private IDisplay myDisplay;
        private IBuzzer myBuzzer;

        private int powerLevel = 50;
<<<<<<< HEAD
        private int time = 60;
=======
        private int time = 1;
>>>>>>> parent of f6e14c6 (Done, i think)

        public UserInterface(
            IButton powerButton,
            IButton timeButton,
            IButton startCancelButton,
            IButton expandTimeButton,
            IDoor door,
            IDisplay display,
            ILight light,
            IPowerDial powerDial,
            ICookController cooker,
            IBuzzer buzzer)
        {
            powerButton.Pressed += new EventHandler(OnPowerPressed);
            timeButton.Pressed += new EventHandler(OnTimePressed);
            startCancelButton.Pressed += new EventHandler(OnStartCancelPressed);
<<<<<<< HEAD
            powerDial.Dialed += new EventHandler(OnPowerChanged);
            expandTimeButton.Pressed += new EventHandler(OnExpandTimeButtonPressed);
=======
>>>>>>> parent of f6e14c6 (Done, i think)

            door.Closed += new EventHandler(OnDoorClosed);
            door.Opened += new EventHandler(OnDoorOpened);
            

            myCooker = cooker;
            myLight = light;
            myDisplay = display;
            myBuzzer = buzzer;
        }

        private void OnExpandTimeButtonPressed(object sender, EventArgs e)
        {
            switch (myState)
            {
                case States.SETTIME:
                    time += 5;
                    Console.WriteLine("time is expanded with 5 seconds");
                    break;
            }
        }

        private void ResetValues()
        {
            powerLevel = 50;
<<<<<<< HEAD
            time = 60;
=======
            time = 1;
>>>>>>> parent of f6e14c6 (Done, i think)
        }

        public void OnPowerPressed(object sender, EventArgs e)
        {
            switch (myState)
            {
                case States.READY:
                    myDisplay.ShowPower(powerLevel);
                    myState = States.SETPOWER;
                    break;
            }
        }

        public void OnPowerChanged(object sender, EventArgs e)
        {
            PowerChangedEventArgs powerArgs = (PowerChangedEventArgs)e;
            switch (myState)
            {
                case States.SETPOWER:
<<<<<<< HEAD
                    powerLevel = powerArgs.PowerLevel;
                    myDisplay.ShowPower(powerLevel);
                    break;
            }

        }

        public void OnTimePressed(object sender, EventArgs e)
        {
            switch (myState)
            {
                case States.SETPOWER:
                    myDisplay.ShowTime(time/60, 0);
                    myState = States.SETTIME;
                    break;
                case States.SETTIME:
                    time += 60;
                    myDisplay.ShowTime(time/60, 0);
=======
                    myDisplay.ShowTime(time, 0);
                    myState = States.SETTIME;
                    break;
                case States.SETTIME:
                    time += 1;
                    myDisplay.ShowTime(time, 0);
>>>>>>> parent of f6e14c6 (Done, i think)
                    break;
            }
        }

        public void OnStartCancelPressed(object sender, EventArgs e)
        {
            switch (myState)
            {
                case States.SETPOWER:
                    ResetValues();
                    myDisplay.Clear();
                    myState = States.READY;
                    break;
                case States.SETTIME:
                    myLight.TurnOn();
<<<<<<< HEAD
                    myCooker.StartCooking(powerLevel, time);
=======
                    myCooker.StartCooking(powerLevel, time*60);
>>>>>>> parent of f6e14c6 (Done, i think)
                    myState = States.COOKING;
                    break;
                case States.COOKING:
                    ResetValues();
                    myCooker.Stop();
                    myLight.TurnOff();
                    myDisplay.Clear();
                    myState = States.READY;
                    break;
            }
        }

        public void OnDoorOpened(object sender, EventArgs e)
        {
            switch (myState)
            {
                case States.READY:
                    myLight.TurnOn();
                    myState = States.DOOROPEN;
                    break;
                case States.SETPOWER:
                    ResetValues();
                    myLight.TurnOn();
                    myDisplay.Clear();
                    myState = States.DOOROPEN;
                    break;
                case States.SETTIME:
                    ResetValues();
                    myLight.TurnOn();
                    myDisplay.Clear();
                    myState = States.DOOROPEN;
                    break;
                case States.COOKING:
                    myCooker.Stop();
                    myDisplay.Clear();
                    ResetValues();
                    myState = States.DOOROPEN;
                    break;
            }
        }

        public void OnDoorClosed(object sender, EventArgs e)
        {
            switch (myState)
            {
                case States.DOOROPEN:
                    myLight.TurnOff();
                    myState = States.READY;
                    break;
            }
        }

        public void CookingIsDone()
        {
            switch (myState)
            {
                case States.COOKING:
                    ResetValues();
                    myDisplay.Clear();
                    myLight.TurnOff();
                    // Beep 3 times
                    for (int i = 0; i < 3; i++)
                    {
                        myBuzzer.shortSound();
                    }
                    myState = States.READY;
                    break;
            }
        }
    }
}