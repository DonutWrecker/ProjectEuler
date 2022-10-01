uint fib1 = 1;
uint fib2 = 2;
uint sumEven = fib2;

while (fib1 <= 4_000_000 && fib2 <= 4_000_000)
{
    fib1 += fib2;
    fib2 += fib1;

    if (fib1 % 2 == 0) sumEven += fib1;
    if (fib2 % 2 == 0) sumEven += fib2;
}

Console.WriteLine($"The sum of even-valued Fibonacci sequence terms whose values do not exceed 4.000.000: {sumEven}");