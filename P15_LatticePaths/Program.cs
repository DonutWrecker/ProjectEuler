ulong gridLength = 20;
ulong gridHeight = 20;

Console.WriteLine($"{ComputePermutation(gridLength, gridHeight)} routes there are in a {gridLength}x{gridHeight} grid.");

static ulong ComputePermutation(ulong length, ulong height)
{
    if (length > 10 && height > 10)
    {
        ulong[] nominatorArr = new ulong[length + height - (length + 1) + 1];
        ulong[] denominatorArr = new ulong[length];

        for (ulong num = length + height, i = 0; num > length; --num, ++i)
        {
            nominatorArr[i] = num;
        }

        for (ulong num = 1, i = 0; num <= length; ++num, ++i)
        {
            denominatorArr[i] = num;
        }

        for (ulong i = 0; i < length; ++i)
        {
            for (ulong j = 0; j < length; ++j)
            {
                if (denominatorArr[j] != 1 && (nominatorArr[i] % denominatorArr[j] == 0))
                {
                    nominatorArr[i] /= denominatorArr[j];
                    denominatorArr[j] = 1;
                }
            }
        }

        return ComputeProductOfArr(nominatorArr) / ComputeProductOfArr(denominatorArr);
    }

    return ComputeProduct(length + 1, length + height) / ComputeFactorial(length);
}
static ulong ComputeFactorial(ulong number)
{
    ulong factorial = 1;
    while (number > 0)
    {
        factorial *= number;
        --number;
    }

    return factorial;
}
static ulong ComputeProduct(ulong start, ulong end)
{
    ulong product = 1;
    for (;end >= start; --end)
    {
        product *= end;
    }

    return product;
}
static ulong ComputeProductOfArr(ulong[] arr)
{
    ulong product = 1;
    foreach (ulong item in arr)
    {
        product *= item;
    }

    return product;
}
