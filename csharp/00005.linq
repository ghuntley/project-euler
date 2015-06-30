<Query Kind="Program" />

// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
void Main()
{
	Step(20)
		.First(number => Enumerable.Range(11, 9)
			.All(divisor => number % divisor == 0))
		.Dump();
}

public static IEnumerable<int> Step(int step = 1)
{
	int i = step;
	while (true)
	{
		yield return i;
		i += step;
	}
}
