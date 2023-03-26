using System.Numerics;

namespace EventsItAcademyGe.MVC.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static unsafe T* ToPointer<T>(this string pointer) where T : unmanaged
        {
            IntPtr ResultPointer = IntPtr.Zero;
            BigInteger bigInteger = BigInteger.Parse(pointer);
            BigInteger addAmount = bigInteger / int.MaxValue;
            for (int i = 0; i < addAmount; i++)
            {
                ResultPointer = IntPtr.Add(ResultPointer, int.MaxValue);
                bigInteger = bigInteger - int.MaxValue;
            }
            ResultPointer = IntPtr.Add(ResultPointer, (int)bigInteger);
            return (T*)ResultPointer;
        }
    }
}
