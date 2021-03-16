using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        List<int> results = new List<int>();

        static void Main(string[] args)
        {
            var weights = new List<int> { 529, 382, 130, 462, 223, 167, 235, 529 };

            var p = new Program();

            p.NewMethod(weights);
            p.results.Sort();
            double sum = weights.Sum();
            double dividedWeight = sum / 2; 
            var result = p.results.Where(w => w <= dividedWeight).Max();
            double result2 = sum - result;
            Console.WriteLine("dividedweight: " + dividedWeight.ToString());
            Console.WriteLine("första: "+ result2.ToString() + " andra: " +  result.ToString());

            Console.WriteLine(string.Join(" ", p.results.Distinct()));
        }

        private void NewMethod(List<int> weights, int sum = 0)
        { // metodanrop 2: 9 12 3 , 5 
         // lägger till 5 + 9 = 14 
         // metodanrop 3: 12 3, 14 
         // metodanrop 4: 3, 26
         // metodanrop: 5: tom lista, 29 - foreachen körs inte eftersom listan är tom 
         
        //result: 5, 14, 26, 29,   9,    12, 
            foreach(var weight in weights)
            {
                results.Add(weight + sum);
                NewMethod(weights.Where(w => w != weight).ToList(), weight + sum);
            }
        }
    }
}
