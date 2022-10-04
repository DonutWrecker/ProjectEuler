int num = 2;
int power = 1000;
int[] powerArr = Power(num, power);

int sum = 0;
for (int i = 0; i < powerArr.Length; i++)
{
    sum += powerArr[i];
}

Console.WriteLine($"Sum of the digits of the number {2}^{power}: {sum}");

static int[] Power(int num, int power)
{
    int[] powerArr = new int[1];
    powerArr[0] = 1;
    int multiplication = 0;
    int remainder = 0;

    while (power > 0)
    {
        for (int i = powerArr.Length - 1; i >= 0; --i)
        {
            multiplication += powerArr[i] * num;
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

            powerArr[i] = remainder;
            if (i == 0 && multiplication != 0)
            {
                powerArr = ExtendArray(powerArr);
                powerArr[0] = multiplication;
                multiplication = 0;
            }
        }

        --power;
    }

    return powerArr;
}
static int[] ExtendArray(int[] arr)
{
    int newLength = arr.GetLength(0) + 1;
    int[] newArr = new int[newLength];
    arr.CopyTo(newArr, 1);

    return newArr;
}