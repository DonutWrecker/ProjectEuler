ulong numberOriginal = 600_851_475_143;
ulong number = numberOriginal;
ulong largestPrimeFactor = 1;

for (ulong factor = 3UL; factor <= number; factor += 2)
{
    if (number % factor == 0)
    {
        number = DivideUntilNoMore(number, factor);
        largestPrimeFactor = factor;
    }
}

Console.WriteLine($"The largest prime factor of the number {numberOriginal}: {largestPrimeFactor}");

static ulong DivideUntilNoMore(ulong number, ulong factor)
{
    while (number % factor == 0)
    {
        number /= factor;
    }
    
    return number;
}