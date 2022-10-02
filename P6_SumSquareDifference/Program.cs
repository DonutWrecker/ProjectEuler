ulong firstXnumbers = 100;
ulong difference = ComputeSquareOfTheSum(firstXnumbers) - ComputeSumOfTheSquares(firstXnumbers);
Console.WriteLine("The difference between the sum of the squares of the " +
    $"first {firstXnumbers} natural numbers and the square of the sum: {difference}");

static ulong ComputeSumOfTheSquares(ulong firstXnumbers) => firstXnumbers * (firstXnumbers + 1) * (2 * firstXnumbers + 1) / 6;
static ulong ComputeSquareOfTheSum(ulong firstXnumbers) => (ulong)Math.Pow((double)(firstXnumbers * (firstXnumbers + 1) / 2), 2.0);
