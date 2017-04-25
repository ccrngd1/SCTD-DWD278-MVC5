using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] single_digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            string[] two_digits =
            {
                "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                "eighteen", "nineteen"
            };
            string[] tens_multiple =
            {
                "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty",
                "ninety"
            };
            string[] hundreds_power = {"", "thousand", "million"};

            string inputNumber = System.Console.ReadLine();

            System.Console.WriteLine(inputNumber[0]);

            string negativePrefix = "";
            string finalNumberWords = "";

            //if the first character is a negative sign ('-'), then we rip it off and save that we need to call
            //this final result negative
            if (inputNumber[0] == '-')
            {
                negativePrefix = "negative";
                inputNumber = inputNumber.Substring(1, inputNumber.Length - 2);
            }

            while (inputNumber.Length%3 != 0)
            {
                inputNumber = "0" + inputNumber;
            }

            //it is better to store off the string as an array of numbers so we can walk through them
            //and use them as indexes into our arrays
            int[] convertedNumber = new int[inputNumber.Length];

            //have to iterate through our original string version of the number
            for (int i = 0; i < inputNumber.Length; i++)
            {
                //'0' has an int value of 48
                //so if we subtract '0' from all our characters
                //we get the real value left over without casting to int
                convertedNumber[i] = inputNumber[i] - '0';
            }

            //walk the number backward
            int hundredsPowerTracker = 0;
            for (int j = 0; j <= (convertedNumber.Length - 1)/3; j++)
            {
                string temp = "";
                int actualIndexLocation = j*3;
                bool isSpecialTensDigit = false;

                //0%3=0
                //1%3=1
                //2%3=2
                //3%3=0

                if (convertedNumber.Length >= actualIndexLocation && convertedNumber[actualIndexLocation]!=0) //hundreds 
                {
                    temp = single_digits[convertedNumber[actualIndexLocation]] + " hundred ";
                }

                if (convertedNumber.Length >= actualIndexLocation + 1) //tens
                {
                    if (convertedNumber[actualIndexLocation + 1] == 1)
                    {
                        temp += two_digits[convertedNumber[actualIndexLocation+2]] + " ";
                        isSpecialTensDigit = true;
                    }
                    else
                    {
                        temp += tens_multiple[convertedNumber[actualIndexLocation+1]] + " ";
                    }
                }

                if (convertedNumber.Length > actualIndexLocation+2 && !isSpecialTensDigit) //ones
                {
                    if (convertedNumber[actualIndexLocation + 2] == 0)
                    {
                        if (string.IsNullOrWhiteSpace(temp)) temp = "zero";
                    }
                    else
                    {
                        temp += single_digits[convertedNumber[actualIndexLocation + 2]];
                    }
                }

                temp += hundreds_power[hundredsPowerTracker] + " ";

                finalNumberWords +=temp;

                hundredsPowerTracker++;
            }

            Console.WriteLine(finalNumberWords);
        }

    }
}
