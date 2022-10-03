ulong greatestStartingNumber = 1UL;
ulong collatzSequenceTermsCount = 1UL;

for (ulong startingNumber = 1UL, termsCount; startingNumber < 1_000_000UL; ++startingNumber)
{
    termsCount = CountOfCollatzSequenceTerms(startingNumber);
    if (termsCount > collatzSequenceTermsCount)
    {
        collatzSequenceTermsCount = termsCount;
        greatestStartingNumber = startingNumber;
    }
}

Console.WriteLine($"{greatestStartingNumber} produces the longest chain with {collatzSequenceTermsCount} terms.");

static ulong CountOfCollatzSequenceTerms(ulong number)
{
    ulong count = 1;
    while (number != 1)
    {
        number = NextCollatzSequenceTerm(number);
        ++count;
    }

    return count;
}
static bool isEven(ulong number) => number % 2 == 0;
static ulong NextCollatzSequenceTerm(ulong number)
{
    if (isEven(number))
    {
        return number / 2;
    }
    else
    {
        return 3 * number + 1;
    }
}