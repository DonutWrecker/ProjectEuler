string triangleString = "75 " +
                        "95 64 " +
                        "17 47 82 " +
                        "18 35 87 10 " +
                        "20 04 82 47 65 " +
                        "19 01 23 75 03 34 " +
                        "88 02 77 73 07 63 67 " +
                        "99 65 04 28 06 16 70 92 " +
                        "41 41 26 56 83 40 80 70 33 " +
                        "41 48 72 33 47 32 37 16 94 29 " +
                        "53 71 44 65 25 43 91 52 97 51 14 " +
                        "70 11 33 28 77 73 17 78 39 68 17 57 " +
                        "91 71 52 38 17 14 91 43 58 50 27 29 48 " +
                        "63 66 04 68 89 53 67 30 73 16 69 87 40 31 " +
                        "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23 ";


int numRows = 15;
int[][] triangleArr     = new int[numRows][];
int[][] triangleArrCopy = new int[numRows][];

// Write numbers into an array, and make a copy of the original array
for (int i = 0, numsInRow = 1; i < triangleString.Length; i += 3 * numsInRow, ++numsInRow)
{
    triangleArr[numsInRow - 1]     = new int[numsInRow];
    triangleArrCopy[numsInRow - 1] = new int[numsInRow];

    for (int j = numsInRow, k = 0; j > 0; --j, ++k)
    {
        triangleArr[numsInRow - 1][k] = Convert.ToInt32(triangleString[(i + k * 3)..(i + k * 3 + 2)]);
        triangleArrCopy[numsInRow - 1][k] = triangleArr[numsInRow - 1][k];
    }
}

for (int i = 0, numsInRow = 1, maxValue = 0; i < numRows; ++i, ++numsInRow, maxValue = 0)
{
    for (int j = numsInRow, k = 0; j > 0; --j, ++k)
    {
        if (triangleArr[numsInRow - 1][k] > maxValue)
        {
            maxValue = triangleArrCopy[numsInRow - 1][k];
        }
    }

    for (int j = numsInRow, k = 0; j > 0; --j, ++k)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        triangleArrCopy[numsInRow - 1][k] -= maxValue;
        
        if (triangleArrCopy[numsInRow - 1][k] == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write($"{triangleArrCopy[numsInRow - 1][k], 5}");
    }

    Console.Write('\n');
}

Console.ForegroundColor = ConsoleColor.White;

static void PutChar(char c, int times)
{
    for (; times > 0; --times)
    {
        Console.Write(c);
    }
}