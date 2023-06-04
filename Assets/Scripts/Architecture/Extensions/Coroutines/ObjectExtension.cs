namespace Architecture.Architecture.Extensions.Coroutines
{
    public static class ObjectExtension
    {
        public static bool IsNull(this object o) => ReferenceEquals(o, null);

        public static bool IsNotNull(this object o) => !ReferenceEquals(o, null);
    }
}