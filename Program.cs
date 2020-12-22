using System;

namespace ChemisteryMystery
{
    class Program
    {
        public double X { get; set; }
        public double X2 => 2 / X;
        public double X5 => (2 / X) * 3.76;
        public double X6 => (4 / X) - 4;
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Welcome to my CombustionProject ");


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


                const double X1 = 1;
                const double X3 = 1;
                const double X4 = 2;
                const double tin = 298;
                const double R = 8.315;
                const double h_Ch4 = -74831;
                const double h_CO2 = -393546;
                const double h_H2o = -241845;
                const double h_N2 = 0;
                const double h_O2 = 0;
                const double c_Co2 = 56.21;
                const double c_H20 = 43.87;
                const double c_N2 = 33.71;
                const double c_O2 = 35.593;

                if (cType.ToLower() == "cp")
                {
                    var a = X1 * h_Ch4 + X2 * h_O2 + X2 * 3.76 * h_N2;
                    var b = X3 * h_CO2 + X4 * h_H2o + X5 * h_N2 + X6 * h_O2;
                    var c = X3 * c_O2 * tin + X4 * c_H20 * tin + X5 * c_N2 * tin + X6 * c_O2 * tin;
                    var d = X3 * c_Co2 + X4 * c_H20 + X5 * c_N2 + X6 * c_O2;
                    var tad = (a - b + c) / d;
                    Console.WriteLine($"The Tad based on CP is = {tad.ToString("0.###")}");
                }
                else
                {
                    var e = X1 * h_Ch4 + X2 * h_O2 + X2 * 3.76 * h_N2;
                    var f = X3 * h_CO2 + X4 * h_H2o + X5 * h_N2 + X6 * h_O2;
                    var g = X3 * c_O2 * tin + X4 * c_H20 * tin + X5 * c_N2 * tin + X6 * c_O2 * tin;
                    var h = R * tin * X1 + R * tin * X2;
                    var i = X3 * c_Co2 + X4 * c_H20 + X5 * c_N2 + X6 * c_O2;
                    var j = X3 * R + X4 * R + X5 * R + X6 * R;
                    var cvTad = (e - f + g - h) / (i - j);
                    Console.WriteLine($"The Tad based on CV is={cvTad.ToString("0.###")}");
                }

            }

        }


    }
}
