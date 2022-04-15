using Microsoft.Xna.Framework;

namespace SpriteAnonSuggestions.Utils
{
    public static class ColorUtils
    {
        public static Color MultiplyRGB(this Color c, float num)
            => new(c.R * num, c.G * num, c.B * num);

        public static Color MultiplyRGBA(this Color c, float num) =>
            new(c.R * num, c.G * num, c.B * num, c.A * num);
    }
}
