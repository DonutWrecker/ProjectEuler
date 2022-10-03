ulong numDivisors = 500;
ulong number = 0;

for (ulong index = 1, divisorCount = 0; divisorCount < numDivisors; ++index)
{
    number = GetTriangularNumber(index);
    divisorCount = CountDivisors(number);
}

Console.WriteLine($"The value of the first triangle number to have over {numDivisors} divisors: {number}");

static ulong GetTriangularNumber(ulong index) => index * (index + 1) / 2;

static ulong CountDivisors(ulong number)
{
    ulong count = 0;
    for (ulong divisor = 1; divisor <= number; ++divisor)
    {
        if (number % divisor == 0)
        {
            ++count;
        }
    }

    return count;
}