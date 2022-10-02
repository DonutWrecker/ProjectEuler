// c > b > a && a + b + c = 1000
int total = 1000;
int a = 1;
int b = 2;
int c = total - (a + b);
bool foundTheTriplet = false;

while (true)
{
    for (; b < c; ++b, --c)
    {
        if (IsPythagoreanTriplet(a, b, c))
        {
            foundTheTriplet = true;
            break;
        }
    }

    if (!foundTheTriplet)
    {
        ++a;
        b = a + 1;
        c = total - (a + b);

        if (b > c)
        {
            break;
        }
    }
    else
    {
        break;
    }
}

if (foundTheTriplet)
{
    Console.WriteLine($"{a} + {b} + {c} = {total}, and {Math.Pow(a, 2)} + {Math.Pow(b, 2)} = {Math.Pow(c, 2)}" +
        $"\nabc = {a * b * c}");
}

static bool IsPythagoreanTriplet(int a, int b, int c) => (ulong)Math.Pow(c, 2) == (ulong)(Math.Pow(a, 2) + Math.Pow(b, 2));