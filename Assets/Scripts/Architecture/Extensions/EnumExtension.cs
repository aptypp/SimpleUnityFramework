using System;

namespace Architecture.Architecture.Extensions
{
    public static class EnumExtension
    {
        public static int GetCount<T>() where T : Enum => Enum.GetNames(typeof(T)).Length;
    }
}