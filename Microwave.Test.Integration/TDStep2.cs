﻿using System;
using System.Threading;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class TDStep2
    {
        private Door door;
        private Button powerButton;
        private Button timeButton;
        private Button startCancelButton;
        private Button expandTimeButton;

        private UserInterface ui;

        private Light light;
        private Buzzer buzzer;
        private Display display;
        private CookController cooker;


        private IPowerTube powerTube;
        private ITimer timer;
        private IOutput output;
        private IPowerDial powerDial;

        [SetUp]
        public void Setup()
        {
            door = new Door();
            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            expandTimeButton = new Button();

            powerTube = Substitute.For<IPowerTube>();
            timer = Substitute.For<ITimer>();
            output = Substitute.For<IOutput>();
            powerDial = new PowerDial();
            powerTube = Substitute.For<IPowerTube>();

            light = new Light(output);
            buzzer = new Buzzer(output);
            display = new Display(output);

            cooker = new CookController(timer, display, powerTube);

<<<<<<< HEAD
            ui = new UserInterface(powerButton, timeButton, startCancelButton, expandTimeButton, door, display, light,
                powerDial, cooker,buzzer);
=======
            ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker);
>>>>>>> parent of f6e14c6 (Done, i think)
            cooker.UI = ui;
        }

        #region UI_Light

        [Test]
        public void UI_Light_TurnOn()
        {
            door.Open();

            output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("on")));
        }

        [Test]
        public void UI_Light_TurnOff()
        {
            door.Open();
            door.Close();

            output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        #endregion

        #region UI_Display

        [Test]
        public void UI_Display_ShowPower_50W()
        {
            powerButton.Press();
            powerDial.Dial(50);

            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("50 W")));
        }

        [Test]
        public void UI_Display_ShowPower_150W()
        {
            powerButton.Press();
            powerDial.Dial(150);

            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("150 W")));
        }

            [Test]
            public void UI_Display_Showtime_1min()
            {
                powerButton.Press();
                timeButton.Press();

<<<<<<< HEAD
                output.Received().OutputLine(Arg.Is<string>(str => str.Contains("01:00")));
            }
=======
        [Test]
        public void UI_Display_Showtime_1min()
        {
            powerButton.Press();
            timeButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

            [Test]
            public void UI_Display_Showtime_2min()
            {
                powerButton.Press();
                timeButton.Press();
                timeButton.Press();

<<<<<<< HEAD
                output.Received().OutputLine(Arg.Is<string>(str => str.Contains("02:00")));
            }
=======
        [Test]
        public void UI_Display_Showtime_2min()
        {
            powerButton.Press();
            timeButton.Press();
            timeButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

            [Test]
            public void UI_Display_Clear_()
            {
                powerButton.Press();
                timeButton.Press();
                startCancelButton.Press();

<<<<<<< HEAD
                // Simulate cooking is done
                // This would be fine, as we are investigating the UI - Display interface
                // not anything else
                // ui.CookingIsDone();
=======
        [Test]
        public void UI_Display_Clear_()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                // Alternative, use the timer as driver for cooker, which 
                // will make cooking stop
                // This would be more top down
                timer.Expired += Raise.EventWith(this, EventArgs.Empty);

                output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("cleared")));
            }

            #endregion

            #region UI_CookController

<<<<<<< HEAD
            [Test]
            public void UI_CookController_StartCooking_1min()
            {
                powerButton.Press();
                timeButton.Press();
                startCancelButton.Press();
=======
        [Test]
        public void UI_CookController_StartCooking_1min()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                // Cooking has started
                // Can be verified by timer
                timer.Received().Start(60);
            }

<<<<<<< HEAD
            [Test]
            public void UI_CookController_StartCooking_2min()
            {
                powerButton.Press();
                timeButton.Press();
                timeButton.Press();
                startCancelButton.Press();
=======
        [Test]
        public void UI_CookController_StartCooking_2min()
        {
            powerButton.Press();
            timeButton.Press();
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                // Cooking has started
                // Can be verified by timer
                timer.Received().Start(120);
            }

<<<<<<< HEAD
            [Test]
            public void UI_CookController_StartCooking_50W()
            {
                powerButton.Press();
                timeButton.Press();
                startCancelButton.Press();
=======
        [Test]
        public void UI_CookController_StartCooking_50W()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                // Cooking has started
                // Can be verified by powertube
                powerTube.Received().TurnOn(50);
            }

<<<<<<< HEAD
            [Test]
            public void UI_CookController_StartCooking_100W()
            {
                powerButton.Press();
                powerDial.Dial(100);
                timeButton.Press();
                startCancelButton.Press();
=======
        [Test]
        public void UI_CookController_StartCooking_100W()
        {
            powerButton.Press();
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                // Cooking has started
                // Can be verified by powertube
                powerTube.Received().TurnOn(100);
            }

            [Test]
            public void UI_CookController_StartCooking_700W()
            {
                powerButton.Press();
                    powerDial.Dial(700);

<<<<<<< HEAD
                    timeButton.Press();
                    startCancelButton.Press();
=======
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                    // Cooking has started
                    // Can be verified by powertube
                    powerTube.Received().TurnOn(700);
                }

<<<<<<< HEAD
                [Test]
                public void UI_CookController_Stop()
                {
                    powerButton.Press();
                    timeButton.Press();
                    startCancelButton.Press();
=======
        [Test]
        public void UI_CookController_Stop()
        {
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

                    // Now we force stopping
                    startCancelButton.Press();

                    // Cook controller should have stopped powertube
                    powerTube.Received(1).TurnOff();
                }

                #endregion
            }
        }
    