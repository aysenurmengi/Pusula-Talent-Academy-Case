
namespace Algorithms;

public class Q1MaxIncreasingSubarray
{
    public static string MaxIncreasingSubarrayAsJson(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0) return "[]";

        int bestStart = 0, bestEnd = 0, bestSum = numbers[0];

        for (int i = 0; i < numbers.Count;)
        {
            int start = i, sum = numbers[i];
            i++;
            while (i < numbers.Count && numbers[i] > numbers[i - 1])
            {
                sum += numbers[i];
                i++;
            }

            if (sum > bestSum)
            {
                bestSum = sum;
                bestStart = start;
                bestEnd = i - 1;
            }

        }
        
        var conc = numbers.GetRange(bestStart, bestEnd - bestStart + 1);
        return System.Text.Json.JsonSerializer.Serialize(conc);
        
    }
}
