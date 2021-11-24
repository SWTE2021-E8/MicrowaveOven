using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class TDStep1
    {
        private Door door;
        private Button powerButton;
        private Button timeButton;
        private Button startCancelButton;
        private Button expandTimeButton;

        private UserInterface ui;

        private ILight light;
        private IBuzzer buzzer;
        private IDisplay display;
        private ICookController cooker;
        private IPowerDial powerDial;

        [SetUp]
        public void Setup()
        {
            door = new Door();
            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            expandTimeButton = new Button();

            light = Substitute.For<ILight>();
            buzzer = Substitute.For<IBuzzer>();
            display = Substitute.For<IDisplay>();
            cooker = Substitute.For<ICookController>();
            powerDial = new PowerDial();

            ui = new UserInterface(powerButton, timeButton, startCancelButton, expandTimeButton, door, display, light, powerDial, cooker,buzzer);
        }

        [Test]
        public void Door_UI_DoorOpen()
        {
            door.Open();

            light.Received(1).TurnOn();
        }
        public void Door_UI_DoorClose()
        {
            door.Open();
            door.Close();

            light.Received(1).TurnOff();
        }

        [Test]
        public void PowerButton_UI_PowerPressed()
        {
            powerButton.Press();

            display.Received(1).ShowPower(50);
        }

        [Test]
        public void TimeButton_UI_TimePressed()
        {
            powerButton.Press();
            timeButton.Press();

            display.Received(1).ShowTime(1, 0);
        }


    }
}