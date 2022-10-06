int numSundays = CountDayOfTheWeek(7, 31, 12, 2000) - CountDayOfTheWeek(7, 31, 12, 1900);
Console.WriteLine($"{numSundays} Sundays fell on the first of the month during 20th century (1 Jan 1901 to 31 Dec 2000)");

static int CountDayOfTheWeek(int dayOfTheWeek, int day, int month, int year, int baseDayOfTheWeek = 1, int baseDay = 1, int baseMonth = 1, int baseYear = 1900)
{
    /* 
     * Days of the Week
     * 
     *  1: Monday
     *  2: Tuesday
     *  3: Wednesday
     *  4: Thursday
     *  5: Friday
     *  6: Saturday
     *  7: Sunday
     */
    
    if (year < baseYear) return -1;

    int currentDayOfTheWeek = baseDayOfTheWeek;
    int currentDay          = baseDay;
    int currentMonth        = baseMonth;
    int currentYear         = baseYear;
    int dayOfTheWeekCount   = 0;
    int daysInMonth         = DaysInMonth(currentMonth, currentYear);

    if (currentDayOfTheWeek == dayOfTheWeek && currentDay == 1) ++dayOfTheWeekCount;

    while (currentYear != year || currentMonth != month || currentDay != day)
    {
        ++currentDay;
        ++currentDayOfTheWeek;
        if (currentDayOfTheWeek > 7) currentDayOfTheWeek = 1;

        if (currentDay == daysInMonth + 1)
        {
            ++currentMonth;
            currentDay = 1;

            if (currentMonth > 12)
            {
                ++currentYear;
                currentMonth = 1;
            }

            daysInMonth = DaysInMonth(currentMonth, currentYear);
        }

        if (currentDayOfTheWeek == dayOfTheWeek && currentDay == 1) ++dayOfTheWeekCount;
    }

    return dayOfTheWeekCount;
}
static int DaysInMonth(int month, int year)
{
    return month switch
    {
        1  => 31,
        2  => IsLeapYear(year) ? 29 : 28,
        3  => 31,
        4  => 30,
        5  => 31,
        6  => 30,
        7  => 31,
        8  => 31,
        9  => 30,
        10 => 31,
        11 => 30,
        12 => 31,
        _  => -1
    };
}
static bool IsLeapYear(int year)
{
    if (year % 4 == 0)
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    else
    {
        return false;
    }
}