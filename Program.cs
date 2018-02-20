using FinchAPI;
using System;

namespace FinchesGotTalent
{
    class Program
    {
        /// <summary>
        /// Finches Got Talent Application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // **************************************************
            //
            // Title: Finches Got Talent
            // Description: Sensors
            // Application Type: Console
            // Author: Nate Schlusler
            // Dated Created: 2/7/2018
            // Last Modified:
            //
            // **************************************************

            // variables
            bool isConnected;
            double finchTemp;
            int rightLightSensor;
            int leftLightSensor;
            bool rightObstacle;
            



            // create (instantiate) a new finch object
            //
            Finch myFinch = new Finch();

            //
            // connect to the finch robot using the finch connnect method
            //
            isConnected = myFinch.connect();
            if (isConnected)
            {
                Console.WriteLine("Finch is connected.");
            }
            else
            {
                Console.WriteLine("Finch is broke.");
            }
            Console.WriteLine();

            // describe app
            Console.WriteLine("Demo of Finch Sensors");
            Console.WriteLine();

            // pause for user
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();



            // application loop
            rightObstacle = false;
            while (!rightObstacle)
            {
                // get temperature
                finchTemp = myFinch.getTemperature();
                Console.WriteLine($"Current Temperature: {finchTemp} celsius.");

               // get light sensor value
                leftLightSensor = myFinch.getLeftLightSensor();
                rightLightSensor = myFinch.getRightLightSensor();
                Console.WriteLine();
                Console.WriteLine($"Current Left Light Sensor: {leftLightSensor}");
                Console.WriteLine($"Current Right Light Sensor: {rightLightSensor}");
                Console.WriteLine($"Current Average Light Sensor: {((leftLightSensor) + (rightLightSensor)) / 2}");
                Console.WriteLine();

                // check right obstacle

                rightObstacle = myFinch.isObstacleRightSide();
                if (rightObstacle)
                {
                    Console.WriteLine("Right obstacle detected!");
                }

                myFinch.wait(1000);
                Console.Clear();
            }
            


            // pause for user
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


            //
            // end application code here
            //

            //
            // disconnect from the finch robot using the finch disconnect method
            //
            myFinch.disConnect();
        }
    }
}
