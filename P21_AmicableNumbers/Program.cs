long amicable1 = 1;
long amicable2;
long sum = 0;
long[][] amicables = new long[1][];
amicables[0] = new long[2];
int amicableIndex = 0;

while (amicable1 < 10000)
{
    amicable2 = AmicablePair(amicable1);
    if (amicable2 >= 10000)
    {
        ++amicable1;
        continue;
    }
    if (amicable2 != -1)
    {
        if (ExistsInArray(amicable1, amicables, 2))
        {
            ++amicable1;
            continue;
        }

        sum += amicable1 + amicable2;

        if (amicableIndex + 1 > amicables.GetLength(0))
        {
            amicables = ExtendArray(amicables);
        }

        amicables[amicableIndex][0] = amicable1;
        amicables[amicableIndex][1] = amicable2;
        ++amicableIndex;
    }

    ++amicable1;
}

Console.WriteLine(sum);

static bool ExistsInArray(long num, long[][] arr, int dim2)
{
    int dim1 = arr.GetLength(0);
    bool exists = false;

    for (int row = 0; row < dim1; ++row)
    {
        for (int col = 0; col < dim2; ++col)
        {
            if (arr[row][col] == num)
            {
                exists = true;
            }
        }
    }

    return exists;
}
static long[][] ExtendArray(long[][] arr)
{
    int length = arr.GetLength(0);
    long[][] newArr = new long[length + 1][];

    for (int i = 0; i < length; ++i)
    {
        newArr[i] = new long[2];
        arr[i].CopyTo(newArr[i], 0);
    }

    newArr[length] = new long[2];

    return newArr;
}
static long AmicablePair(long num)
{
    long amicableOther = AmicableOther(num);
    if (amicableOther == num || amicableOther <= 0) return -1;

    long amicableOtherPair = AmicableOther(amicableOther);
    bool isAmicable = amicableOtherPair == num;
    return isAmicable switch
    {
        true => amicableOther,
        false => -1
    };
}
static long AmicableOther(long num)
{
    long sumDivisors = 0;
    if (num < 2) return -1;

    for (long divisor = 1, division = -1; divisor < num; ++divisor)
    {
        if (num % divisor == 0)
        {
            division = num / divisor;
            sumDivisors += divisor;
        }
    }

    return sumDivisors;
}