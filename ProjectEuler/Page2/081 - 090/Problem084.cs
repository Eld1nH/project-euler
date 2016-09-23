using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler.Page2._081___090
{
    // Monopoly odds
    public class Problem084
    {
        
        public static string Algorithm()
        {
            Random random = new Random();
            int limit = 1000000;
            int position = 0;
            int[] landed = new int[40];
            int[] chance = new int[] { 7, 22, 36 };
            int[] chanceMove = new int[] { 0, 10, 11, 24, 39, 5, -5, -5, -2, -3 };
            int[] chanceOrder = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            chanceOrder = chanceOrder.OrderBy(x => random.Next()).ToArray();
            int chancePos = 0;
            int[] chest = new int[] { 2, 17, 33 };
            int[] chestMove = new int[] { 0, 10 };
            int[] chestOrder = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            chestOrder = chestOrder.OrderBy(x => random.Next()).ToArray();
            int chestPos = 0;

            int dCount = 0;
            for (int i = 0; i < limit; i++)
            {
                int r1 = random.Next(1, 5);
                int r2 = random.Next(1, 5);

                if (r1 == r2)
                {
                    dCount++;
                    if (dCount == 3)
                    {
                        position = 10;
                        landed[position]++;
                        continue;
                    }
                }
                else
                    dCount = 0;

                int roll = r1 + r2;
                position += roll;
                position %= 40;

                if (chance.Contains(position))
                {
                    int card = chanceOrder[++chancePos % 16];
                    if (card < chanceMove.Length)
                    {
                        int move = chanceMove[card];
                        if (move == -5)
                        {
                            int t = position / 5;
                            if (t % 2 == 0)
                                t--;
                            t *= 5;
                            t += 10;
                            t %= 40;
                            position = t;
                            landed[position]++;
                            continue;
                        }
                        else if (move == -2)
                        {
                            if (position < 12 && position > 28)
                            {
                                position = 12;
                                landed[position]++;
                                continue;
                            }
                            else if (position > 12 && position < 28)
                            {
                                position = 28;
                                landed[position]++;
                                continue;
                            }
                        }
                        else if (move == -3)
                        {
                            position = position - 3 < 0 ? position - 3 + 40 : position - 3;
                            landed[position]++;
                            continue;
                        }
                        else
                        {
                            position = move;
                            landed[position]++;
                            continue;
                        }
                    }
                }
                else if (chest.Contains(position))
                {
                    int card = chestOrder[++chestPos % 16];;
                    if (card < chestMove.Length)
                    {
                        int move = chestMove[card];
                        position = move;
                        landed[position]++;
                        continue;
                    }
                }
                else if (position == 30)
                {
                    position = 10;
                    landed[position]++;
                    continue;
                }

                landed[position]++;
                continue;
            }

            double[] percent = new double[landed.Length];
            for (int i = 0; i < landed.Length; i++)
            {
                percent[i] = (double)landed[i] / (double)limit * 100.0;
            }

            int first = 0;
            double firstVal = 0.0;
            int second = 0;
            double secondVal = 0.0;
            int third = 0;
            double thirdVal = 0.0;
            for (int i = 0; i < percent.Length; i++)
            {
                if (percent[i] > firstVal)
                {
                    third = second;
                    thirdVal = secondVal;
                    second = first;
                    secondVal = firstVal;
                    first = i;
                    firstVal = percent[i];
                }
                else
                {
                    if (percent[i] > secondVal)
                    {
                        third = second;
                        thirdVal = secondVal;
                        second = i;
                        secondVal = percent[i];
                    }
                    else
                    {
                        if (percent[i] > thirdVal)
                        {
                            third = i;
                            thirdVal = percent[i];
                        }
                    }
                }
            }

            string result = first < 10 ? "0" + first.ToString() : first.ToString();
            result += second < 10 ? "0" + second.ToString() : second.ToString();
            result += third < 10 ? "0" + third.ToString() : third.ToString();

            return result;
        }
    }
}
