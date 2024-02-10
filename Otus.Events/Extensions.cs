using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Events
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class, new()
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (convertToNumber == null)
                throw new ArgumentNullException(nameof(convertToNumber));

            T maxItem = new();
            float maxNumber = float.MinValue;

            foreach (var item in collection)
            {
                float number = convertToNumber(item);
                if (number > maxNumber)
                {
                    maxNumber = number;
                    maxItem = item;
                }
            }

            return maxItem;
        }
    }
}
