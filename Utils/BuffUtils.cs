namespace SpriteAnonSuggestions.Utils
{
    public static class BuffUtils
    {
        public static int Seconds(int amt)
            => amt * 60;

        public static int Minutes(int amt)
            => Seconds(amt) * 60;

        public static int Hours(int amt)
            => Minutes(amt) * 60;
    }
}
