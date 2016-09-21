using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BricksGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int n = int.Parse(Console.ReadLine());
                String str = Console.ReadLine();
                char delimiter = ' ';
                String[] tokens = str.Split(delimiter);
                long[] arr = new long[n];
                int i = 0;
                BigInteger[] friend = new BigInteger[n];
                BigInteger[] me = new BigInteger[n];
                for (i = 0; i < n; i++)
                {
                    arr[i] = long.Parse(tokens[i]);
                    friend[i] = new BigInteger(-1);
                    me[i] = new BigInteger(-1);
                }
               
               
                Console.WriteLine(func(friend,me, n,arr, 0, 0));
                t--;
            }
             //Console.ReadKey();
        }
        public static BigInteger func(BigInteger[] friend,BigInteger[] me, int n,long[] arr,int index,int turn)
        {
           if(index >= n - 3)
            {
                if(turn == 1)
                {
                    if(friend[index] != -1)
                    {
                        return friend[index];
                    }
                    else
                    {
                        friend[index] = 0;
                        return friend[index];
                    }
                }
                else
                {
                    if(me[index] != -1)
                    {
                        return me[index];
                    }
                    else
                    {
                        BigInteger sum = new BigInteger(0);
                        for (int i = index; i < n; i++)
                        {
                            sum = sum + arr[i];
                        }
                        me[index] = sum;
                        return me[index];
                    }
                }
            }
           else
            {
                BigInteger buyOne , buyTwo , buyThree;
                if(turn == 0)
                {
                    if(friend[index + 1] != -1)
                    {
                        buyOne = friend[index + 1];
                    }
                    else
                    {
                        buyOne = func(friend, me, n, arr, index + 1, 1);
                    }
                    if(friend[index + 2] != -1)
                    {
                        buyTwo = friend[index + 2];
                    }
                    else
                    {
                        buyTwo = func(friend, me, n, arr, index + 2, 1);
                    }
                    if(friend[index + 3] != -1)
                    {
                        buyThree = friend[index + 3];
                    }
                    else
                    {
                        buyThree = func(friend, me, n, arr, index + 3, 1);
                    }
                    me[index] = max(buyOne + arr[index], buyTwo + arr[index] + arr[index + 1], arr[index] + arr[index + 1] + arr[index + 2] + buyThree);
                    return me[index];
                }
                else
                {
                    if(me[index + 1] != -1)
                    {
                        buyOne = me[index + 1];
                    }
                    else
                    {
                        buyOne = func(friend, me, n, arr, index + 1, 0);
                    }
                    if(me[index + 2] != -1)
                    {
                        buyTwo = me[index + 2];
                    }
                    else
                    {
                        buyTwo = func(friend, me, n, arr, index + 2, 0);
                    }
                    if(me[index + 3] != -1)
                    {
                        buyThree = me[index + 3];
                    }
                    else
                    {
                        buyThree = func(friend, me, n, arr, index + 3, 0);
                    }
                    friend[index] = min(buyOne, buyTwo, buyThree);
                    return friend[index];
                }
            }
        }
        public static BigInteger max(BigInteger first, BigInteger second, BigInteger third)
        {
            BigInteger max = first;
            if (second > max)
            {
                max = second;
            }
            if (third > max)
            {
                max = third;
            }
            return max;
        }
        public static BigInteger min(BigInteger first, BigInteger second, BigInteger third)
        {
            BigInteger min = first;
            if (second < min)
            {
                min = second;
            }
            if (third < min)
            {
                min = third;
            }
            return min;
        }
    }
}
