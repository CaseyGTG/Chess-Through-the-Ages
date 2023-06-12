using System;

namespace Assets.Code.Extensions
{
    public static class EnumExtensions
    {
        public static T? Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] ValuesArray = (T[])Enum.GetValues(src.GetType());
            int nextIndex = Array.IndexOf(ValuesArray, src) + 1;
            return (ValuesArray.Length == nextIndex) ? null : ValuesArray[nextIndex];
        }

        public static T? Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] ValuesArray = (T[])Enum.GetValues(src.GetType());
            int previousIndex = Array.IndexOf(ValuesArray, src) - 1;
            return (previousIndex == -1) ? null : ValuesArray[previousIndex];
        }
    }
}