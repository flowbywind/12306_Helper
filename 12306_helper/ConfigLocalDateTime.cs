using System;
using System.Runtime.InteropServices;

namespace _12306_Helper
{
    class ConfigLocalDateTime
    {
        public static DateTime tmpTime = DateTime.Now;
        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SYSTEMTIME time);
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME time);
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SYSTEMTIME time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SYSTEMTIME time);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;

            public void InitSystemTimeValue(DateTime dateTime)
            {
                wYear = (ushort)dateTime.Year;
                wMonth = (ushort)dateTime.Month;
                wDayOfWeek = (ushort)dateTime.DayOfWeek;
                wDay = (ushort)dateTime.Day;
                wHour = (ushort)dateTime.Hour;
                wMinute = (ushort)dateTime.Minute;
                wSecond = (ushort)dateTime.Second;
                wMilliseconds = (ushort)dateTime.Millisecond;
            }

            public DateTime ToDateTime()
            {
                return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond);
            }
        }
    }
}
