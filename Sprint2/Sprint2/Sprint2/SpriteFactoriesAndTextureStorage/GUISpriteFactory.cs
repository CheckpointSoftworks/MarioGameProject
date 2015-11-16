using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace Sprint2
{
    public static class GUISpriteFactory
    {
        private static Texture2D guiMarioSprite;
        private static Texture2D guiCoinSprite;

        public static void Load(ContentManager content)
        {
            guiMarioSprite = content.Load<Texture2D>("MarioSmallStill");
            guiCoinSprite = content.Load<Texture2D>("BoxCoin");
        }

        public static Texture2D CreateGUIMarioSprite()
        {
            return guiMarioSprite;
        }

        public static Texture2D CreateGUICoinSprite()
        {
            return guiCoinSprite;
        }
    }
}
