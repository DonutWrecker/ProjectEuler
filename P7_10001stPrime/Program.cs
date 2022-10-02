int xThPrime = 10_001;
ulong[] primes = new ulong[xThPrime];
primes[0] = 2;

for (ulong num = 3; primes[^1] == 0; ++num)
{
    for (int i = 0; i < xThPrime; ++i)
    {
        if (primes[i] == 0)
        {
            primes[i] = num;
            break;
        }

        if (num % primes[i] == 0) break;
    }
}

Console.WriteLine($"The {xThPrime}st prime number: {primes[^1]}");