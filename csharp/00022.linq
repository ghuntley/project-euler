<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Using names.txt (right click and 'Save Link/Target As...'), a 46K text file
// containing over five-thousand first names, begin by sorting it into
// alphabetical order. Then working out the alphabetical value for each name, 
// multiply this value by its alphabetical position in the list to obtain a name score.

// For example, when the list is sorted into alphabetical order, COLIN, which is worth
// 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a
// score of 938 × 53 = 49714.

// What is the total of all the name scores in the file?
void Main(string[] args)
{
   var names = GetNamesFromProjectEuler();

   var total = names.Select((x, index) => 
               x.ToCharArray()
               .Sum(c => (int)c - 64) * (index + 1))
               .Sum();
   
   total.Dump();
}

IEnumerable<string> GetNamesFromProjectEuler()
{
   const string url = @"https://projecteuler.net/project/resources/p022_names.txt";
   using (var client = new WebClient())
   {
       using (var stream = client.OpenRead(url))
       {
           using (var reader = new StreamReader(stream))
               return reader.ReadToEnd()
                   .Split(",".ToCharArray())
                   .ToList()
                   .Select(name => name.Replace("\"", ""))
                   .OrderBy(name => name);
       }
   }
}