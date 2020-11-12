using System;

namespace Utils
{
    public static class RandomExtensions
    {
        public static void Shuffle<T> (this Random rng, T[] array, int arrLen = 0)
        {
            if (arrLen == 0)
            {
                arrLen = array.Length;
            }
            
            while (arrLen > 1) 
            {
                var k = rng.Next(arrLen--);
                var temp = array[arrLen];
                array[arrLen] = array[k];
                array[k] = temp;
            }
        }
    }
}