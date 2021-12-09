using System;
using BenchmarkDotNet.Attributes;

namespace Homework3
{
    class Program
    {
        static void Main()
        {
            //var result = Task2(12);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine(result[i]);
            //}

            var result = Task5(5, 3);
            Console.WriteLine(result);
        }

        public static double Task1(double number, int degree)
        {
            double result = 1;

            for (int i = 1; i <= degree; i++)
            {
                result *= number;
            }

            return result;
        }

        public static int[] Task2(int number)
        {
            int countNumber = 0;
            int rangeMinValue = number;
            int rangeMaxValue = 1000;

            for (int i = rangeMinValue; i <= rangeMaxValue; i += number)
            {
                ++countNumber;
            }

            int[] resultList = new int[countNumber];

            rangeMinValue = number;

            for (int i = rangeMinValue; i <= rangeMaxValue; i += number)
            {
                resultList[--countNumber] = i;
            }

            return resultList;
        }

        [Benchmark]
        private static int Task3(double number)
        {
            for (int i = 0; i <= number; ++i)
            {
                if (i * i >= number)
                {
                    return (i - 1);
                }
            }

            return 0;
        }

        private static int Task4(int number)
        {
            int result = 1;
            int divider = number;

            do
            {
                if (number % (--divider) == 0)
                {
                    result = divider;
                    break;
                }
            }
            while (divider != 1);

            return result;
        }

        private static int Task5(int a, int b)
        {
            if (a > b)
            {
                Swap(ref a, ref b);
            }

            int result = 0;

            for (int i = a; i <= b; i++)
            {
                if (i % 7 == 0)
                {
                    result += i;
                }
            }

            return result;
        }

        private static int Task6(int position)
        {
            int n1 = 1;
            int n2 = 1;
            int n = 0;
            for (int i = 2; i < position; i++)
            {
                n = n1 + n2;
                n1 = n2;
                n2 = n;
            }

            return n;
        }

        private static int Task7(int a, int b)
        {
            if (a < b)
            {
                Swap(ref a, ref b);
            }

            int result = 1;

            while (true)
            {
                int remainder = a % b;

                a = b;
                b = remainder;

                if (remainder == 0)
                {
                    result = a;
                    break;
                }
            }

            return result;
        }

        private static double Task8(double number)
        {
            double rangeStart = 0;
            double rangeEnd = 1;

            do
            {
                if ((rangeEnd * rangeEnd * rangeEnd) < number)
                {
                    rangeStart = rangeEnd;
                    ++rangeEnd;
                }
                else
                {
                    break;
                }
            }
            while (true);
            var tt = 0;

            double precision;
            double result;

            do
            {
                result = (rangeStart + rangeEnd) / 2;
                precision = Math.Abs(result * result * result - number);

                if (((rangeStart * rangeStart * rangeStart - number) * (result * result * result - number)) > 0)
                {
                    rangeStart = result;
                }
                else
                {
                    rangeEnd = result;
                }
            }
            while (precision > 0.0001);

            return result;
        }

        public static int Task9(int number)
        {
            int countOddDigits = 0;

            do
            {
                int remainder = number % 10;

                if (remainder % 2 == 1)
                {
                    ++countOddDigits;
                }

                number /= 10;
            }
            while (number != 0);

            return countOddDigits;
        }

        public static int Task10(int number)
        {
            int reversedNumber = 0;

            while (number > 0)
            {
                int remainder = number % 10;
                reversedNumber = reversedNumber * 10 + remainder;
                number /= 10;
            };

            return reversedNumber;
        }

        public static int[] Task11(int enteredNumber)
        {
            var totalEvenNumber = 0;

            for (int i = 1; i <= enteredNumber; i++)
            {
                int countEven = 0;
                int countOdd = 0;

                int number = i;
                do
                {
                    int remainder = number % 10;
                    if (remainder % 2 == 0)
                    {
                        ++countEven;
                    }
                    else
                    {
                        ++countOdd;
                    }
                    number /= 10;
                }
                while (number != 0);

                if (countEven > countOdd)
                {
                    ++totalEvenNumber;
                }
            }

            int[] listEvenNumbers = new int[totalEvenNumber];
            int listPosition = 0;

            for (int i = 1; i <= enteredNumber; i++)
            {
                int countEven = 0;
                int countOdd = 0;

                int number = i;
                do
                {
                    int remainder = number % 10;
                    if (remainder % 2 == 0)
                    {
                        ++countEven;
                    }
                    else
                    {
                        ++countOdd;
                    }
                    number = number / 10;
                }
                while (number != 0);

                if (countEven > countOdd)
                {
                    listEvenNumbers[listPosition] = i;
                    ++listPosition;
                }
            }

            return listEvenNumbers;
        }

        public static bool Task12(int number1, int number2)
        {
            int number1Abs = Math.Abs(number1);
            int number2Abs = Math.Abs(number2);
            bool result = false;

            while (number1Abs > 0)
            {
                int tempNumber2 = number2Abs;
                int remainder1 = number1Abs % 10;

                while (tempNumber2 > 0)
                {
                    int remainder2 = tempNumber2 % 10;

                    if (remainder1 == remainder2)
                    {
                        result = false;
                        break;
                    }

                    tempNumber2 /= 10;
                };

                number1Abs /= 10;
            };

            return result;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}