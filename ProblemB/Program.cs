using System;
using System.Linq;

namespace ProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Cast<int>();
            var dividedWeight = input.Sum() / 2;
            var weights = input.ToArray();
            var numberOfWeights = weights[0];
            // Ta bort första elementet som bara är antal vikter 
            weights.ToList().Remove(0);
           // var sortedList = weights.ToList();
           // sortedList.Sort();


            double backpack1 = 0;
            double backpack2;
            int closest = 0;

            for (int i = 0; i < weights.Length; i++)
            { 
                // Först testar vi kombinationen index[0] i weights tillsammans med varje enskild vikt i arrayen 
                // Om vikterna tillsammans inte är större än jämnvikten och den tidigare närmaste vikten så sparar vi vikten som closest tills vi
                //hittar en mer optimerad kombination 
                for (int k = 1; k <= dividedWeight; k++)
                {
                    k = findClosest(weights, weights[i], i + 1, dividedWeight);
                    if (k < dividedWeight)
                    {
                        closest = k;
                    }
                    closest+=  weights[i + 1];

                }
            }
            Console.WriteLine(closest);

                }


        public static int findClosest(int [] weightArray, int current, int index, int dividedWeight)
        {
            int max = current;
            for(int i = index; i < weightArray.Length; i++)
            {
                if(current + weightArray[i] < dividedWeight && current + weightArray[i] > current)
                {
                    max = current + weightArray[i];
                }
            }

            return max;
        }
    }
}
