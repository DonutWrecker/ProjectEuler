long[] number = new long[1] { 1 };
long factorial = 100;

number = CalculateFactorial(number, 2, 30);
number = CalculateFactorial(number, 31, 50);
number = CalculateFactorial(number, 51, 70);
number = CalculateFactorial(number, 71, 80);
number = CalculateFactorial(number, 81, 90);
number = CalculateFactorial(number, 91, 100);

long sum = 0;
for (long i = 0; i < number.Length; i++)
{
    sum += number[i];
}

Console.WriteLine($"Sum of the digits in the number {factorial}!: {sum}");

static long[] CalculateFactorial(long[] number, long start, long end)
{
    long multiplication = 0;
    long remainder = 0;

    for (long multiplier = start; multiplier <= end; ++multiplier)
    {
        for (long i = number.Length - 1; i >= 0; --i)
        {
            multiplication += number[i] * multiplier;
            if (multiplication < 0)
            {
                Console.WriteLine($"{multiplication} ({start}, {end}): OVERFLOW");
            }
            if (multiplication > 9)
            {
                remainder = multiplication % 10;
                multiplication -= remainder;
                multiplication /= 10;
            }
            else
            {
                remainder = multiplication;
                multiplication = 0;
            }

            number[i] = remainder;
            if (i == 0 && multiplication != 0)
            {
                if (multiplier == end)
                {
                    long numDigits = multiplication.ToString().Length;
                    number = ExtendArray(number, numDigits);

                    for (long power = 1, rem, divisor = 10; power < numDigits; ++power)
                    {
                        rem = multiplication % divisor;
                        number[numDigits - power] = rem;
                        multiplication -= rem;
                        multiplication /= divisor;
                    }
                }
                else
                {
                    number = ExtendArray(number, 1);
                }

                number[0] = multiplication;
                multiplication = 0;
            }
        }
    }

    return number;
}
static long[] ExtendArray(long[] arr, long amount)
{
    if (amount < 1) return arr;

    long[] newArr = new long[arr.Length + (int)amount];
    arr.CopyTo(newArr, amount);

    return newArr;
}
