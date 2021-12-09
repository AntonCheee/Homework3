using System;

namespace Homework3
{
    class Program
    {
        static void Main()
        {
            //var result = Task2(81);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine(result[i]);
            //    }

            //var result = Task12(97, 546);
            //Console.WriteLine(result);
        }

        public static double Task1(double number, double degree)
        {
            double result = 1;

            if (degree >= 1 && degree % 1 == 0)
            {
                for (int i = 1; i <= degree; i++)
                {
                    result = result * number;
                }
            }
            else if (degree < -1 && degree % 1 == 0)
            {
                for (int i = 1; i <= Math.Abs(degree); i++)
                {
                    result = result * number;
                    if (i == Math.Abs(degree))
                    {
                        result = 1 / result;
                    }
                }
            }
            else if(degree == 0)
            {
                result = 1;
            }
            else
            {
                result = Math.Pow(number, degree);
            }

            return result;
        }

        public static int[] Task2(int number)
        {
            int countNumber = 0;
            int rangeMinValue = 1;
            int rangeMaxValue = 1000;

            for (int i = rangeMinValue; i <= rangeMaxValue; i++)
            {
                if (i % number == 0)
                {
                    ++countNumber;
                }
            }

            int[] resultList = new int[countNumber];

            for (int i = rangeMinValue; i <= rangeMaxValue; i++)
            {
                if (i % number == 0)
                {
                    --countNumber;
                    resultList[countNumber] = i;
                }
            }

            return resultList;
        }

        private static int Task3(double number)
        {
            int minNumber = (int)Math.Sqrt(number/2); //здесь вместо 2 может быть любое число >1, чем ближе оно 1 тем меньшее кол-во итераций цикла понадобится, при =1 вырождается во второй вариант решения

            while (true)
            {
                if (minNumber * minNumber < number)
                {
                    ++minNumber;
                }
                else
                {
                    --minNumber;
                    break;
                }
            }

            return minNumber;
        }

        private static int Task3WithoutLoop(double number)
        {
            var sqrt = Math.Sqrt(number);
            var additional = (sqrt % 1) == 0 ? 1 : 0;
            var count = (int)Math.Floor(sqrt) - additional;

            return count;
        }


        private static int Task4(int a)
        {
            int number = 1;
            int result = 1;

            do
            {
                ++number;
                if (a % number == 0 && number < a)
                {
                    result = number;
                }
            }
            while (number < a);

            return result;
        }

        private static int Task5(int a, int b)
        {
            if (a > b) {
                Swap(ref a, ref b);
            }

            int result = 0;

            for (int i = a; i <= b; i++)
            {
                if (i % 7 == 0) {
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
            if (a < b) {
                Swap(ref a, ref b);
            }

            int remainder;
            do
            {
                remainder = a % b;
                if (b > remainder && remainder != 0)
                {
                    a = b;
                    b = remainder;
                }
                else
                {
                    a = remainder;
                }
            }
            while (remainder != 0);

            return b; 
        }

        private static double Task8(double number)
        {
            double rangeStart = 0;
            double rangeEnd;
            if (number >= 0)
            {
                rangeEnd = 1;
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
            }
            else
            {
                rangeEnd = -1;
                do
                {
                    if ((rangeEnd * rangeEnd * rangeEnd) > number)
                    {
                        rangeStart = rangeEnd;
                        --rangeEnd;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true);
            }

            double a = rangeStart;
            double b = rangeEnd;
            double precision;
            double x;

            do
            {
                x = (a + b) / 2;
                precision = Math.Abs(x * x * x - number);

                if (((a * a * a - number) * (x * x * x - number)) > 0)
                {
                    a = x;
                }
                else
                {
                    b = x;
                }
            }
            while (precision > 0.0001);

            return x;
        }

        public static int Task9(int number)
        {
            int countOddDigits = 0;

            do
            {
                int remainder = number % 10;
                if (remainder % 2 != 0)
                {
                    ++countOddDigits;
                }
                number = number / 10;
            }
            while (number!= 0);

            return countOddDigits;
        }

        public static int Task10(int number)
        {
            int reversedNumber = 0;

            while (number>0)
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
                    number = number / 10;
                }
                while (number != 0);

                if (countEven > countOdd) {
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

        public static string Task12(int number1, int number2)
        {
            int number1Abs = Math.Abs(number1);
            int number2Abs = Math.Abs(number2); 

            while (number1Abs > 0)
            {
                int tempNumber2 = number2Abs;
                int remainder1 = number1Abs % 10;

                while (tempNumber2 > 0)
                {
                    int remainder2 = tempNumber2 % 10;

                    if (remainder1 == remainder2) 
                    {
                        return "ДА";
                    }

                    tempNumber2 /= 10;
                };

                number1Abs /= 10;
            };

            return "НЕТ";
        }

        private static void Swap(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}