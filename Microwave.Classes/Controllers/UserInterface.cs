﻿using System;
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

        private int powerLevel = 50;
        private int time = 60;

        public UserInterface(
            IButton powerButton,
            IButton timeButton,
            IButton startCancelButton,
            IButton expandTimeButton,
            IDoor door,
            IDisplay display,
            ILight light,
            IPowerDial powerDial,
            ICookController cooker)
        {
            powerButton.Pressed += new EventHandler(OnPowerPressed);
            timeButton.Pressed += new EventHandler(OnTimePressed);
            startCancelButton.Pressed += new EventHandler(OnStartCancelPressed);
            powerDial.Dialed += new EventHandler(OnPowerChanged);
            expandTimeButton.Pressed += new EventHandler(OnExpandTimeButtonPressed);

            door.Closed += new EventHandler(OnDoorClosed);
            door.Opened += new EventHandler(OnDoorOpened);

            myCooker = cooker;
            myLight = light;
            myDisplay = display;
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
            time = 60;
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
                    myCooker.StartCooking(powerLevel, time);
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
                    myState = States.READY;
                    break;
            }
        }
    }
}