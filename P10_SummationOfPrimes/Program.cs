ulong[] primes = new ulong[100];
primes[0] = 2;
ulong upperBoundary = 2_000_000UL;
ulong number = 3;

while (number < upperBoundary)
{
    for (int i = 0; i < primes.Length; i++)
    {
        if (i == primes.Length - 1)
        {
            primes = ExtendTheArray(primes);
        }
        if (primes[i] == 0)
        {
            primes[i] = number;
            break;
        }
        if (number % primes[i] == 0)
        {
            break;
        }
    }

    ++number;
}

ulong sum = 0;
int numPrimes = 0;
for (int i = 0; i < primes.Length; i++, ++numPrimes)
{
    if (primes[i] == 0)
    {
        break;
    }

    sum += primes[i];
}

Console.WriteLine($"The sum of all the primes below {upperBoundary}: {sum} ({numPrimes} primes)");

static ulong[] ExtendTheArray(ulong[] arr)
{
    int oldArraySize = arr.Length;
    ulong[] newArray = new ulong[oldArraySize * 2];
    arr.CopyTo(newArray, 0);

    return newArray;
}