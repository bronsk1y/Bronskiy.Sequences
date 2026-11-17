using System;

namespace Bronskiy.Sequences
{
    /// <summary>
    /// Generates sequences of values of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the sequence elements.</typeparam>
    public static class Sequence<T>
    {
        #region Main methods
        /// <summary>
        /// Generates a sequence of the specified length by invoking a function for each element.
        /// </summary>
        /// <param name="count">The number of elements in the sequence.</param>
        /// <param name="func">The function that creates each element's value.</param>
        /// <returns>A lazily evaluated sequence containing <paramref name="count"/> elements.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Generate(int count, Func<T> func)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(count);
            ArgumentNullException.ThrowIfNull(func);

            var result = Enumerate(count, func);
            return result;
        }

        /// <summary>
        /// Generates a sequence of the specified length, passing each element's index to the function.
        /// </summary>
        /// <param name="count">The number of elements in the sequence.</param>
        /// <param name="func">The function that creates a value from an element's index; indices start at zero.</param>
        /// <returns>A lazily evaluated sequence containing <paramref name="count"/> elements.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Generate(int count, Func<int, T> func)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(count);
            ArgumentNullException.ThrowIfNull(func);

            var result = Enumerate(count, func);
            return result;
        }

        /// <summary>
        /// Generates a sequence by computing values for indices in the specified range.
        /// </summary>
        /// <param name="range">The range of indices to generate values for. The start is inclusive and the end is exclusive. Endpoints are treated as absolute zero-based indices; from-end indices are not resolved relative to a collection length.</param>
        /// <param name="func">The function that creates a value from an index.</param>
        /// <returns>A lazily evaluated sequence; it is empty if the range's start value is greater than or equal to its end value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Generate(Range range, Func<int, T> func)
        {
            int start = range.Start.Value;
            int end = range.End.Value;

            ArgumentOutOfRangeException.ThrowIfNegative(start);
            ArgumentOutOfRangeException.ThrowIfNegative(end);
            ArgumentNullException.ThrowIfNull(func);

            var result = Enumerate(range, func);
            return result;
        }

        /// <summary>
        /// Generates a sequence by computing values for indices in the specified range using the given step.
        /// </summary>
        /// <param name="range">The range of indices to generate values for. The start is inclusive and the end is exclusive; endpoints are treated as absolute zero-based indices.</param>
        /// <param name="step">The increment between indices. A positive step generates increasing indices; a negative step generates decreasing indices.</param>
        /// <param name="func">The function that creates a value from an index.</param>
        /// <returns>A lazily evaluated sequence; it is empty if the step moves away from the range's end.</returns>
        /// <exception cref="ArgumentOutOfRangeException">An endpoint of <paramref name="range"/> is less than zero, or <paramref name="step"/> is zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Generate(Range range, int step, Func<int, T> func)
        {
            int start = range.Start.Value;
            int end = range.End.Value;

            ArgumentOutOfRangeException.ThrowIfNegative(start);
            ArgumentOutOfRangeException.ThrowIfNegative(end);
            ArgumentOutOfRangeException.ThrowIfZero(step);
            ArgumentNullException.ThrowIfNull(func);

            var result = Enumerate(range, step, func);
            return result;
        }


        /// <summary>
        /// Generates a sequence of <paramref name="count"/> elements by computing values for sequential indices starting from <paramref name="start"/>.
        /// </summary>
        /// <param name="start">The value of the first integer index in the sequence.</param>
        /// <param name="count">The number of sequential values to generate.</param>
        /// <param name="func">The function that creates a value from an index.</param>
        /// <returns>A lazily evaluated sequence; it is empty if <paramref name="count"/> is less than or equal to zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="start"/> is less than zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Generate(int start, int count, Func<int, T> func)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(start);
            ArgumentNullException.ThrowIfNull(func);

            var result = Enumerate(start, count, func);
            return result;
        }

        /// <summary>
        /// Generates a sequence of values for a specified number of indices, starting at <paramref name="start"/> and advancing by <paramref name="step"/>.
        /// </summary>
        /// <param name="start">The value of the first integer index in the sequence.</param>
        /// <param name="count">The number of values to generate.</param>
        /// <param name="step">The increment between indices; may be positive or negative, but not zero.</param>
        /// <param name="func">The function that creates a value from an index.</param>
        /// <returns>A lazily evaluated sequence; it is empty if <paramref name="count"/> is less than or equal to zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="start"/> is less than zero, or <paramref name="step"/> is zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Generate(int start, int count, int step, Func<int, T> func)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(start);
            ArgumentOutOfRangeException.ThrowIfZero(step);
            ArgumentNullException.ThrowIfNull(func);

            var result = Enumerate(start, count, step, func);
            return result;
        }

        /// <summary>
        /// Generates a sequence that contains one repeated value of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="count">The number of times to repeat the value in the generated sequence.</param>
        /// <param name="value">The value to be repeated.</param>
        /// <returns>A lazily evaluated sequence; empty if <paramref name="count"/> is zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is less than zero.</exception>
        public static IEnumerable<T> Repeat(int count, T value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(count);

            var result = Enumerate(count, value);
            return result;
        }
        #endregion

        #region Private methods
        private static IEnumerable<T> Enumerate(int count, T value)
        {
            for (int i = 0; i < count; i++)
            {
                yield return value;
            }
        }

        private static IEnumerable<T> Enumerate(int count, Func<T> func)
        {
            for (int i = 0; i < count; i++)
            {
                yield return func();
            }
        }
     
        private static IEnumerable<T> Enumerate(int count, Func<int, T> func)
        {
            for (int i = 0; i < count; i++)
            {
                yield return func(i);
            }
        }

        private static IEnumerable<T> Enumerate(Range range, Func<int, T> func)
        {
            int start = range.Start.Value;
            int end = range.End.Value;
            if (start < end)
            {
                for (int i = start; i < end; i++)
                    yield return func(i);
            }
            else
            {
                for (int i = start; i > end; i--)
                    yield return func(i);
            }
        }

        private static IEnumerable<T> Enumerate(Range range, int step, Func<int, T> func)
        {
            long start = range.Start.Value;
            long end = range.End.Value;

            if (step > 0)
            {
                for (long i = start; i < end; i += step)              
                    yield return func((int)i);
               
            }
            else
            {
                for (long i = start; i > end; i += step)                
                    yield return func((int)i);              
            }
        }

        private static IEnumerable<T> Enumerate(int start, int count, Func<int, T> func)
        {
            for (int i = 0; i < count; i++)
            {
                yield return func(i + start);
            }
        }

        private static IEnumerable<T> Enumerate(int start, int count, int step, Func<int, T> func)
        {
            for (int i = 0; i < count; i++)
            {
                long value = (long)i * step + start;
                yield return func((int)value);
            }
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Sequence<int>.Generate(0, 1, 0, x => x);
            foreach (var item in sequence)
            {
                Console.WriteLine(item);
            }
        }
    }
}