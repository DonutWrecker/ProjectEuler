string[] digits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
string[] tenToTwenty = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
string[] tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
string[] others = new string[] { "hundred", "thousand", "and" };

/*
for (int number = 1; number <= 1000; ++number)
{
    Console.WriteLine(ReadNumber(number, digits, tenToTwenty, tens, others));
}
*/

int letterCount = 0;
for (int number = 1; number <= 1000; ++number)
{
    letterCount += ReadNumber(number, digits, tenToTwenty, tens, others).Length;
}

Console.WriteLine($"If all the numbers from 1 to 1000 (one thousand) inclusive " +
    $"were written out in words, {letterCount} letters would be used.");

// Over 1000 not implemented.
static string ReadNumber(int number, string[] digits, string[] tenToTwenty, string[] tens, string[] others)
{
    int numOnes = 0;
    int numTens = 0;
    int numHundreds = 0;
    int numThousands = 0;

    if (number > 9)
    {
        if (number > 99)
        {
            if (number > 999)
            {
                numThousands = number / 1000;
                number -= numThousands * 1000;
            }

            numHundreds = number / 100;
            number -= numHundreds * 100;
        }

        numTens = number / 10;
        number -= numTens * 10;
    }

    numOnes = number;

    string numberRead = "\0";

    if (numThousands > 0) numberRead += digits[numThousands] + others[1];
    if (numHundreds > 0)
    {
        numberRead += digits[numHundreds] + others[0];
        if (numTens > 0 || numOnes > 0)
        {
            numberRead += others[2];
        }
    }
    if (numTens > 0)
    {
        if (numTens == 1)
        {
            numberRead += tenToTwenty[numOnes];
        }
        else
        {
            numberRead += tens[numTens - 2];
        }
    }
    if (numOnes > 0 && numTens != 1)
    {
        numberRead += digits[numOnes];
    }


    return numberRead[1..numberRead.Length];
}