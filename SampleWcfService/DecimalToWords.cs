using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWcfService
{
    public class DecimalToWords
    {
        static string[] Ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        static string[] Tens = {"ten", "eleven", "twelve", "thirteen", "fourteen","fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
        static string[] MultiplesOfTen = {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
        static string[] Thousands = { "", "thousand", "million" };

        static string convertThreeDigitNumberToWords(int number)
        {
            string words = "";

            int hundreds = number / 100;
            if (hundreds > 0)
            {
                words += Ones[hundreds] + " hundred";
                number -= hundreds * 100;
                if (number > 0)
                {
                    words += " ";
                }
            }

            int tensPlace = number / 10;
            if (tensPlace >= 2)
            {
                words += MultiplesOfTen[tensPlace - 2];
                number -= tensPlace * 10;
                if (number > 0)
                {
                    words += "-";
                }
            }
            else if (tensPlace == 1)
            {
                // Handle numbers from 10 to 19
                words += Tens[number - 10];
                return words;
            }

            // Extract the ones place digit
            int onesPlace = number % 10;
            if (onesPlace > 0)
            {
                words += Ones[onesPlace];
            }

            return words;
        }

        public static string convertCurrencyToWords(double amount)
        {
            long dollars = (long)Math.Floor(amount);
            string words = "";
            int thousandsIndex = 0;
            int amountCount = (int)Math.Floor(Math.Log10(amount) + 1);

            if (amountCount > 9)
            {
                return "Maximium Limit Reached.!!!";
            }

            if (amount < 1)
                words += " zero";

            if (amount == 0)
            {
                return "zero dollars";
            }

            while (dollars > 1)
            {
                int threeDigitNumber = (int)(dollars % 1000);
                dollars /= 1000;

                if (threeDigitNumber > 0)
                {
                    string str = convertThreeDigitNumberToWords(threeDigitNumber);
                    if (thousandsIndex > 0)
                    {
                        str += " " + Thousands[thousandsIndex];
                    }
                    if (!string.IsNullOrEmpty(words))
                    {
                        words = str + " " + words;
                    }
                    else
                    {
                        words = str;
                    }
                }

                thousandsIndex++;
            }

            if (dollars == 1)
                words += " one dollar";
            else
                words += " dollars";

            // Convert cents to words
            int cents = (int)Math.Round((amount - Math.Floor(amount)) * 100);
            if (cents > 0)
            {
                if (cents < 2)
                    words += " and " + convertThreeDigitNumberToWords(cents) + " cent";
                else
                    words += " and " + convertThreeDigitNumberToWords(cents) + " cents";
            }

            return words;
        }
    }
}