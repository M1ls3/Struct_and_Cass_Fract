using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Laba3
{
    struct MyFrac
    {
        public long nom, denom, greatestCommonDivisor;
        public MyFrac(long nom_, long denom_)
        {
            nom = nom_;
            denom = denom_;
            greatestCommonDivisor = 0;
            if (nom == 0)
            {
                nom = 0;
                denom = 1;
            }
            else if (denom == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                nom = Math.Abs(nom);
                denom = Math.Abs(denom);
                while (nom != denom)
                {
                    if (nom > denom)
                    {
                        nom = nom - denom;
                    }
                    else
                    {
                        denom = denom - nom;
                    }
                }
                greatestCommonDivisor = nom;
                if (greatestCommonDivisor == 0)
                {
                    nom = nom_;
                    denom = denom_;
                }
                else
                {
                    nom = nom_ / greatestCommonDivisor;
                    denom = denom_ / greatestCommonDivisor;
                }
                if (denom < 0)
                {
                    denom = denom * -1;
                    nom = nom * -1;
                }
            }
        }
        public override string ToString()
        {
            return Convert.ToString('(' + nom + '/' + denom + ')');
        }

        //public static MyFrac operator +(MyFrac f1, MyFrac f2)
        //{
        //    MyFrac temp = new MyFrac();
        //    temp.nom = f1.nom * f2.denom + f2.nom * f1.denom;
        //    temp.denom = f1.denom * f2.denom;
        //    return temp;
        //}
        //public static MyFrac operator -(MyFrac f1, MyFrac f2)
        //{
        //    MyFrac temp = new MyFrac();
        //    temp.nom = f1.nom * f2.denom - f2.nom * f1.denom;
        //    temp.denom = f1.denom * f2.denom;
        //    return temp;
        //}
        //public static MyFrac operator *(MyFrac f1, MyFrac f2)
        //{
        //    MyFrac temp = new MyFrac();
        //    temp.nom = f1.nom * f2.nom;
        //    temp.denom = f1.denom * f2.denom;
        //    return temp;
        //}
        //public static MyFrac operator /(MyFrac f1, MyFrac f2)
        //{
        //    MyFrac temp = new MyFrac();
        //    temp.nom = f1.nom * f2.denom;
        //    temp.denom = f1.denom * f2.nom;
        //    return temp;
        //}
    }
    public class Block1
    {
        static string ToStringWithIntegerPart(MyFrac f)
        {
            long nom = f.nom;
            long denom = f.denom;
            long wholePart = nom / denom;
            nom = nom % denom;
            if (wholePart == 0)
                return Convert.ToString("(" + nom + "/" + denom + ")");
            else
                return Convert.ToString("(" + wholePart + "+" + "(" + nom + "/" + denom + "))");
        }
        static double DoubleValue(MyFrac f)
        {
            double temp = Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom);
            return temp;
        }
        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            MyFrac temp = new MyFrac();
            temp.nom = f1.nom * f2.denom + f2.nom * f1.denom;
            temp.denom = f1.denom * f2.denom;
            MyFrac returns = new MyFrac(temp.nom, temp.denom);
            return returns;
        }
        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            MyFrac temp = new MyFrac();
            temp.nom = f1.nom * f2.denom - f2.nom * f1.denom;
            temp.denom = f1.denom * f2.denom;
            MyFrac returns = new MyFrac(temp.nom, temp.denom);
            return returns;
        }
        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            MyFrac temp = new MyFrac();
            temp.nom = f1.nom * f2.nom;
            temp.denom = f1.denom * f2.denom;
            MyFrac returns = new MyFrac(temp.nom, temp.denom);
            return returns;
        }
        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            MyFrac temp = new MyFrac();
            temp.nom = f1.nom * f2.denom;
            temp.denom = f1.denom * f2.nom;
            MyFrac returns = new MyFrac(temp.nom, temp.denom);
            return returns;
        }
        static MyFrac CalcSum1(int n)
        {
            MyFrac f = new MyFrac(0, 1);
            MyFrac fVerification = new MyFrac(1, 1);
            for (int i = 1; i <= n; i++)
            {
                MyFrac temp = new MyFrac(1, i * (i + 1));
                f = Plus(f, temp);
            }
            fVerification = new MyFrac(n, n + 1);
            if (f.nom == fVerification.nom && f.denom == fVerification.denom)
                Console.WriteLine("Correct!\n");
            else
                Console.WriteLine("Incorrect!\n{0} != {1} or {2} != {3}", f.nom, fVerification.nom, f.denom, fVerification.denom);
            return f;
        }
        static MyFrac CalcSum2(int n)
        {
            MyFrac f = new MyFrac(1, 1);
            MyFrac minus = f;
            MyFrac fVerification = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                MyFrac temp = new MyFrac(1, i * i);
                temp = Minus(minus, temp);
                f = Multiply(f, temp);
            }
            fVerification = new MyFrac(n + 1, 2 * n);
            if (f.nom == fVerification.nom && f.denom == fVerification.denom)
                Console.WriteLine("Correct!\n");
            else
                Console.WriteLine("Incorrect!\n{0} != {1} or {2} != {3}", f.nom, fVerification.nom, f.denom, fVerification.denom);
            return f;
        }
        static string Show(MyFrac f)
        {
            return Convert.ToString("(" + f.nom + "/" + f.denom + ")");
        }

        static public void Main1()
        {
            Console.WriteLine("Input Numerator and Denumerator for 1 fraction: ");
            string[] value = Console.ReadLine().Trim().Split();
            long nom = Convert.ToInt32(value[0]);
            long denom = Convert.ToInt32(value[1]);
            MyFrac frac1 = new MyFrac(nom, denom);

            Console.WriteLine("Input Numerator and Denumerator for 2 fraction: ");
            value = Console.ReadLine().Trim().Split();
            nom = Convert.ToInt32(value[0]);
            denom = Convert.ToInt32(value[1]);
            MyFrac frac2 = new MyFrac(nom, denom);

            Console.WriteLine("\nFrac1.ToString(): {0}", frac1.ToString());
            Console.WriteLine("Frac2.ToString(): {0}", frac2.ToString());

            Console.WriteLine("\nSimplified 1 fraction: {0}", Show(frac1));
            Console.WriteLine("Simplified 2 fraction: {0}", Show(frac2));

            Console.WriteLine("\nSimplified 1 fraction with integer part: {0}", ToStringWithIntegerPart(frac1));
            Console.WriteLine("Simplified 2 fraction with integer part: {0}", ToStringWithIntegerPart(frac2));

            Console.WriteLine("\nDouble value 1 frattion: {0}", DoubleValue(frac1));
            Console.WriteLine("Double value 2 frattion: {0}", DoubleValue(frac2));

            Console.WriteLine("\nSum of fractions: {0} + {1} = {2}", Show(frac1), Show(frac2), Show(Plus(frac1, frac2)));
            Console.WriteLine("\nDifference of fractions: {0} - {1} = {2}", Show(frac1), Show(frac2), Show(Minus(frac1, frac2)));
            Console.WriteLine("\nProduct of fractions: {0} * {1} = {2}", Show(frac1), Show(frac2), Show(Multiply(frac1, frac2)));
            Console.WriteLine("\nFraction of fractions:  {0} / {1} = {2}", Show(frac1), Show(frac2), Show(Divide(frac1, frac2)));

            Console.WriteLine("\nInput number of additions for CalcSum1: ");
            int n1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nCalcSum1: {0}", Show(CalcSum1(n1)));

            Console.WriteLine("\nInput number of multiplications for CalcSum2: ");
            int n2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nCalcSum2: {0}", Show(CalcSum2(n2)));
        }
    }
}
