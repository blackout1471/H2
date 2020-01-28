using System;
using System.Collections.Generic;

namespace SortePerUpdated
{
    public static class Utils
    {
        /// <summary>
        /// Method to shuffle a lists content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static List<T> ShuffleList<T>(List<T> items)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            int curIndex = items.Count;
            while (curIndex > 1)
            {
                curIndex--;

                int rndIndex = rnd.Next(curIndex + 1);
                T val = items[rndIndex];
                items[rndIndex] = items[curIndex];
                items[curIndex] = val;
            }

            return items;
        }
    }
}
