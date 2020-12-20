using System;

namespace ChemisteryMystery
{
    class Program
    {
        public double X { get; set; }
        public double X2 => 2 / X;
        public double X5 => (2 / X) * 3.76;
        public double X6 => (9 / X) - 4;
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Welcome to my Chemistery Mystery");


                Console.WriteLine("What is stable Cp/Cv");

                var cType = Console.ReadLine();
                if (cType.ToLower() == "cp" || cType.ToLower() == "cv")
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid type try again...");
                }

                isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("Please provide the X:");
                    var xInput = Console.ReadLine();

                    if (double.TryParse(xInput, out double x) && x <= 1 && x > 0)
                    {
                        X = x;
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("X is invalid please try again");

                    }
                }


                const double x1 = 1;
                const double x3 = 1;
                const double x4 = 2;
                const double tin = 298;
                const double R = 8.315;
                const double hMinCh4 = -74831;
                const double hMinCO2 = -393546;
                const double hMinH2o = -241845;
                const double hMinN2 = 0;
                const double hMinO2 = 0;
                const double cMinCo2 = 56.21;
                const double cMinH20 = 43.87;
                const double cMinN2 = 33.71;
                const double cMinO2 = 35.593;

                if (cType.ToLower() == "cp")
                {
                    var a = x1 * X * (hMinCh4) + X2 * X * hMinO2 + X2 * 3.76 * hMinN2;
                    var b = x3 * hMinCO2 + x4 * hMinH2o + X5 * hMinN2 + X6 * hMinO2;
                    var c = x3 * cMinO2 * tin + x4 * cMinH20 * tin + X5 * cMinN2 * tin + (X6 * hMinO2) * tin;
                    var d = x3 * cMinCo2 + x4 * cMinH20 + X5 * cMinN2 + X6 * hMinO2;
                    var tad = (a - b + c) / d;
                    Console.WriteLine($"The Tad based on CP is = {tad.ToString("0.###")}");
                }
                else
                {
                    var e = x1 * hMinCh4 + X2 * hMinO2 + X2 * 3.76 * hMinN2;
                    var f = x3 * hMinCO2 + x4 * hMinH2o + X5 * hMinN2 + X6 * hMinO2;
                    var g = R * tin * (x1 + X2);
                    var h = (x3 + x4 + X5 + X6);
                    var cvTad = (e + f + g) / h;
                    Console.WriteLine($"e = {e}");
                    Console.WriteLine($"f = {f}");
                    Console.WriteLine($"g = {g}");
                    Console.WriteLine($"h = {h}");
                    Console.WriteLine($"The Tad based on CV is {cvTad.ToString("0.###")}");
                }

            }

        }


    }
}
