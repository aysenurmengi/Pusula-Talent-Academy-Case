
using System.Text.Json;

namespace Algorithms;

public class Q2LongestVowelSubsequence
{
    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        if (words == null || words.Count == 0) return "[]";

        char[] vowels = {'a', 'e', 'i', 'o', 'u'};
        var results = new List<object>(words.Count); //jsona dönüşmeden saklanacak yer


        foreach (var inputWord in words)
        {
            if (string.IsNullOrEmpty(inputWord))
            {
                return "[]";
            }

            string longestSubsequence = "";
            string currentSequence = "";

            foreach (var ch in inputWord)
            {
                bool isVowel = Array.Exists(vowels, v => v == ch);
                if (isVowel)
                {
                    currentSequence += ch;
                    if (currentSequence.Length > longestSubsequence.Length)
                    {
                        longestSubsequence = currentSequence;
                    }
                }
                else
                {
                    currentSequence = "";
                }
            }
            results.Add(new
            {
                word = inputWord,
                sequence = longestSubsequence,
                length = longestSubsequence.Length
            });
        }
        return JsonSerializer.Serialize(results);
    }
}
