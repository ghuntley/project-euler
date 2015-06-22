<Query Kind="Statements" />

// The prime factors of 13195 are 5, 7, 13 and 29.
//
// What is the largest prime factor of the number 600851475143?

long number =  600851475143;
long largestFactor = 0;

// https://en.wikipedia.org/wiki/Fundamental_theorem_of_arithmetic
// Any integer greater than 1 is either a prime number, or can be written as a unique product of prime numbers (ignoring the order). 
long i = 2;
while (i * i <= number) {
    if (number % i == 0) {
        number = number / i;
        largestFactor = number;
    } else {
        i++;
    }
}

largestFactor.Dump();