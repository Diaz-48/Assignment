using AppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Services
{
    public class MoneyService
    {
        public string calculateCoins()
        {

            List<Money> coinsList = new List<Money>();

            int total = 100;

            for(int i = 0; i <= total / 25; i++)
            {
                for(int j = 0; j <= total / 10; j++)
                {
                    for(int k = 0; k <= total / 5; k++)
                    {
                        for(int l = 0; l <= total; l++)
                        {
                            int calculate = i * 25 + j * 10 + k * 5 + l;
                            if(calculate == total)
                            {
                                Money money = new Money(l, k, j, i);
                                coinsList.Add(money);
                            }
                        }
                    }
                }
            }

            StringBuilder output = new StringBuilder();
            output.Append("{ count: " + coinsList.Count.ToString() + ", combinations: [");

            for (int i = 0; i < coinsList.Count; i++)
            {
                output.Append(coinsList[i].ToString());

                if (i != (coinsList.Count - 1))
                {
                    output.Append(", ");
                }
            }
            

            output.Append("]}");

            return output.ToString();
        }

        public string getCombinations(double[] denominations, List<string> keys)
        {

            List<string> allCoins = new List<string>();
            int[] currentCoins = new int[denominations.Length];
            
            int total = 100;
            

            getCombinationsRecursion(denominations, currentCoins, allCoins, 0, total, keys);

            StringBuilder output = new StringBuilder();
            output.Append(" { count: " + allCoins.Count.ToString() + ", combinations: [");


            for(int i = 0; i < allCoins.Count; i++)
            {
                output.Append(allCoins[i]);

                if(i != (allCoins.Count - 1))
                {
                    output.Append(", ");
                }
            }

            output.Append("]}");

            return output.ToString();
        }

        public void getCombinationsRecursion(double[] denominations, int[] currentCoins, List<string> allCoins, int index, int total, List<string> keys)
        {
            if(index >= currentCoins.Length)
            {
                StringBuilder str = new StringBuilder();
                str.Append("{");
                for(int i = 0; i < currentCoins.Length; i++)
                {
                    str.Append(keys[i] + ": " + currentCoins[i]);

                    if(i != (currentCoins.Length - 1)) {
                        str.Append(", ");
                    }
                }
                str.Append("}");
                allCoins.Add(str.ToString());
                return;
            }

            if(index == (currentCoins.Length - 1))
            {
                if(total % denominations[index] == 0)
                {
                    currentCoins[index] = Convert.ToInt32(Math.Floor(total / denominations[index]));
                    getCombinationsRecursion(denominations, currentCoins, allCoins, index + 1, 0, keys);
                }
            }
            else
            {
                for(int i = 0; i <= total / denominations[index]; i++)
                {
                    currentCoins[index] = i;
                    getCombinationsRecursion(denominations, currentCoins, allCoins, index + 1, Convert.ToInt32(Math.Floor(total - denominations[index] * i)), keys);
                }
            }
        }
    }
}
