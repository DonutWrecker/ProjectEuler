int num1 = 100;
int num2 = 100;
int numMax = 999;
int product;
int largestPalindrome = 0;
int palindromeProductNum1 = 1;
int palindromeProductNum2 = 1;

for (; num1 < numMax; ++num1)
{
    for (; num2 < numMax; ++num2)
    {
        product = num1 * num2;
        if (IsPalindrome(product) && product > largestPalindrome)
        {
            largestPalindrome = product;
            palindromeProductNum1 = num1;
            palindromeProductNum2 = num2;
        }
    }

    num2 = 100;
}

Console.WriteLine("The largest palindrome made from the product of two 3-digit numbers: " +
    $"{largestPalindrome} ({palindromeProductNum1} x {palindromeProductNum2})");

static bool IsPalindrome(int number)
{
    char[] numCharArr = number.ToString().ToCharArray();
    int numCharArrLength = numCharArr.GetLength(0);
    char[] numCharArrReverse = new char[numCharArrLength];

    uint numMatchingChars = 0;
    bool isPalindrome = false;

    for (int i = 1; i <= numCharArrLength; ++i)
    {
        numCharArrReverse[i - 1] = numCharArr[^i];
    }

    for (int i = 0; i < numCharArrLength; ++i)
    {
        if (numCharArr[i] == numCharArrReverse[i])
        {
            ++numMatchingChars;
        }
    }

    if (numMatchingChars == numCharArrLength)
    {
        isPalindrome = true;
    }

    return isPalindrome;
}