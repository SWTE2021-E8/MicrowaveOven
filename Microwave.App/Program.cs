using System;
using System.Threading;
using System.Threading.Tasks;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();
<<<<<<< HEAD
            Button expandTimeButton = new Button();
=======
>>>>>>> parent of f6e14c6 (Done, i think)

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            PowerDial powerDial = new PowerDial();

            PowerTube powerTube = new PowerTube(output, powerDial);

            Light light = new Light(output);
            Buzzer buzzer = new Buzzer(output);


            Microwave.Classes.Boundary.Timer timer = new Classes.Boundary.Timer();

            CookController cooker = new CookController(timer, display, powerTube);

<<<<<<< HEAD
        

            UserInterface ui = new UserInterface(powerButton, 
            timeButton, 
            startCancelButton, 
            expandTimeButton, 
            door, 
            display, 
            light,
            powerDial, 
            cooker,
            buzzer);
=======
            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker);
>>>>>>> parent of f6e14c6 (Done, i think)

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence

            powerButton.Press();

<<<<<<< HEAD
            powerDial.Dial(500);

            timeButton.Press();

            /// expand time with 5 secs each time
            for (int i = 0; i < 10; i++)
            {
                expandTimeButton.Press();
            }
=======
            timeButton.Press();
>>>>>>> parent of f6e14c6 (Done, i think)

            startCancelButton.Press();


                // The simple sequence should now run

                System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input

            System.Console.ReadLine();
        }
    }
}
