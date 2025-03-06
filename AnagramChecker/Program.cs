/*Build a C# console application that checks 
if two input strings are anagrams using multiple approaches.
https://www.hackerrank.com/challenges/java-anagrams/problem?isFullScreen=true */

class AnagramChecker 
{
    /*Sorting Approach (O (n log n))*/
    private static bool IsAnagramSort(string a, string b)
    {
        if(string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            return false;
        if (a.Length != b.Length) return false; 
        Console.WriteLine($"Character  |  Frequency in '{a}'   | Frequency in '{b}'");
        Console.WriteLine("--------------------------------------------------------");
        var sortedA = string.Concat(a.ToLower().OrderBy(c => c));
        var sortedB = string.Concat(b.ToLower().OrderBy(c=>c));
        foreach (var key in sortedA.Concat(sortedB).Distinct().OrderBy(c=> c))
        {
            var countA = sortedA.Count(c => c == key);
            var countB = sortedB.Count(c => c == key);
            Console.WriteLine($"    {key}     |           {countA}           |           {countB}");
        }
        
        return sortedA == sortedB;
    }

    //Frequency Approach (O(n)) - Dictionary-based Approach
    private static bool IsAnagramFrequency(string a, string b)
    {
        if(string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            return false;
        if (a.Length != b.Length) return false; 
        
        var freqA = new Dictionary<char, int>();
        var freqB = new Dictionary<char, int>();
        
        foreach (var c in a.ToLower().Where(c => !freqA.TryAdd(c, 1))) freqA[c]++;
        foreach (var c in b.ToLower().Where(c => !freqB.TryAdd(c, 1))) freqB[c]++;
        
        Console.WriteLine($"Character  |  Frequency in '{a}'   | Frequency in '{b}'");
        Console.WriteLine("--------------------------------------------------------");
        foreach (var key in freqA.Keys.Concat(freqB.Keys).Distinct())
        {
            var countA = freqA.GetValueOrDefault(key, 0);
            var countB = freqB.GetValueOrDefault(key, 0);
            Console.WriteLine($"    {key}     |           {countA}           |           {countB}");
        }
        if(freqA.Count != freqB.Count) return false;
        foreach (var kv in freqA)
        {
            if(!freqB.TryGetValue(kv.Key, out var count) || count != kv.Value)
                return false;
        }
        return true;
    }

    private static void Main()
    {
        Console.WriteLine("Enter the first string: ");
        var a = Console.ReadLine();
        Console.WriteLine("Enter the second string: ");
        var b = Console.ReadLine();
        if(a == null || b == null)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        // Console.WriteLine(IsAnagramSort(a, b)? "Anagrams(Sorting)" : "Not Anagrams(Sorting)");
        Console.WriteLine(IsAnagramFrequency(a, b)? "Anagrams(Frequency)" : "Not Anagrams(Frequency)");
    }
}