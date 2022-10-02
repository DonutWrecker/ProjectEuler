ulong start = 1;
ulong end = 20;
ulong length = end - start + 1;
ulong[] numbers = new ulong[length];

for (ulong i = 0UL; i < length; ++i)
{
    numbers[i] = start + i;
}

ulong numPrimes = (ulong)DetermineMaxNumPrimeFactors(numbers);
ulong[] uniquePrimes = new ulong[numPrimes];
ulong[,] primes = new ulong[length, numPrimes];
ulong[] powers = new ulong[numPrimes];
DeterminePrimeFactors(numbers, uniquePrimes, primes);

Console.Write("   ");
for (ulong i = 0; i < numPrimes; ++i)
{
    Console.Write($"{uniquePrimes[i], 4}");
}
Console.WriteLine("\n     -------------------------------");

for (ulong i = 0; i < length; ++i)
{
    Console.Write($"{numbers[i], 2}: ");

    for (ulong j = 0; j < numPrimes; ++j)
    {
        Console.Write($"{primes[i, j], 3} ");
    }
    Console.Write("\n");
}

ulong currentMax = 0;
for (ulong i = 0; i < numPrimes; ++i)
{
    for (ulong j = 0; j < length; ++j)
    {
        if (primes[j, i] > currentMax)
        {
            currentMax = primes[j, i];
        }
    }

    powers[i] = currentMax;
    currentMax = 0;
}

ulong total = 1;
for (ulong i = 0; i < numPrimes; ++i)
{
    total *= (ulong)Math.Pow(uniquePrimes[i], powers[i]);
}

Console.WriteLine($"\nThe smallest positive number that is evenly divisible by all of the numbers from {start} to {end}: {total}");

/*
uint numDivisible = 0U;
ulong num = 1UL;
while (true)
{
    for (ulong i = 0UL; i < length; ++i)
    {
        if (num % numbers[i] != 0UL)
        {
            numDivisible = 0U;
            break;
        }

        ++numDivisible;
    }

    if (numDivisible == length)
    {
        break;
    }

    ++num;
}

Console.WriteLine($"The smallest positive number that is evenly divisible by all of the numbers from {start} to {end}: {num}");
*/


static void DeterminePrimeFactors(ulong[] numbers, ulong[] uniquePrimes, ulong[,] primes)
{
    ulong number;
    ulong divisor = 2;
    bool divisorChanged = true;
    int numbersLength = numbers.GetLength(0);
    int uniquePrimesLength = uniquePrimes.GetLength(0);
    int primeFactorCounter = 0;
    ulong primeCount = 0;
    int primeIndex = 0;
    bool primeExists;

    for (int i = 0; i < numbersLength; ++i)
    {
        number = numbers[i];

        while (number >= divisor)
        {
            if (number % divisor == 0)
            {
                if (divisorChanged)
                {
                    primeExists = false;

                    for (int j = 0; j < uniquePrimesLength; ++j)
                    {
                        if (uniquePrimes[j] == divisor)
                        {
                            primeIndex = j;
                            primeExists = true;
                            break;
                        }
                    }

                    if (!primeExists)
                    {
                        uniquePrimes[primeFactorCounter] = divisor;
                        primeIndex = primeFactorCounter;
                        ++primeFactorCounter;
                    }

                    divisorChanged = false;
                }

                number /= divisor;
                ++primeCount;
                continue;
            }

            if (primeCount != 0)
            {
                primes[i, primeIndex] = primeCount;
                primeCount = 0;
            }

            ++divisor;
            divisorChanged = true;
        }

        if (primeCount != 0)
        {
            primes[i, primeIndex] = primeCount;
            primeCount = 0;
        }

        divisor = 2;
        divisorChanged = true;
    }
}
static int DetermineMaxNumPrimeFactors(ulong[] numbers)
{
    ulong number;
    ulong divisor = 2;
    bool divisorChanged = true;
    
    int maxNumPrimeFactors = 50;
    ulong[] primeFactors = new ulong[maxNumPrimeFactors];
    int primeFactorCounter = 0;
    bool primeExists;
    for (int i = 0; i < maxNumPrimeFactors; ++i)
    {
        primeFactors[i] = 0;
    }

    int numbersLength = numbers.GetLength(0);
    for (int i = 0; i < numbersLength; ++i)
    {
        number = numbers[i];

        while (number >= divisor)
        {
            if (number % divisor == 0)
            {
                if (divisorChanged)
                {
                    primeExists = false;

                    for (int j = 0; j < maxNumPrimeFactors; ++j)
                    {
                        if (primeFactors[j] == divisor)
                        {
                            primeExists = true;
                            break;
                        }
                    }

                    if (!primeExists)
                    {
                        primeFactors[primeFactorCounter] = divisor;
                        ++primeFactorCounter;
                    }

                    divisorChanged = false;
                }

                number /= divisor;
                continue;
            }

            ++divisor;
            divisorChanged = true;
        }

        divisor = 2;
        divisorChanged = true;
    }

    int numPrimeFactors = 0;
    for (int i = 0; i < maxNumPrimeFactors; ++i)
    {
        if (primeFactors[i] == 0)
        {
            break;
        }

        ++numPrimeFactors;
    }

    return numPrimeFactors;
}
