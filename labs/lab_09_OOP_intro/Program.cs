using System;

namespace lab_09_OOP_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            // var keyword INFER TYPE FROM RIGHT ie CAR
            // car01 INSTANCE ie particular object created
            // Car = TEMPLATE USED
            // () run a METHOD when calling 'new' keyword  //  Constructor Method
            var car01 = new Car();
            car01.Make = "Mercedes";
            for (int i = 0; i< 1000; i++)
            {
                // CREATE 1000 CARS!
                var car = new Car();
            }
            var newCar = new Car();
            Console.WriteLine($"Initial Speed {newCar.Speed}");
            newCar.Speed++;
            newCar.Speed++;
            Console.WriteLine($"Final Speed{newCar.Speed}");

        }
    }

    class Car
    {
        public string Make;
        public string Model;
        public string Color;
        public int Length; // mm
        public int Speed;

        // Constructor is present even if not stated
        // Default constructor
        public Car() {
            this.Speed = -1;  // THIS KEYWORD refers to INSTANCE OBJECT IN USE AT THE TIME
        }
    }

}
