using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class EnemySpriteFactory
    {
        private static Texture2D goombaSpritesheet;
        private static Texture2D koopaSpritesheet;
        private static Game1 game;

		public static void Load(ContentManager content, GraphicsDevice device)
		{
			goombaSpritesheet = content.Load<Texture2D>("enemySpriteSheet");
            koopaSpritesheet = content.Load<Texture2D>("enemySpriteSheet");
		}
		
		public static ISprite CreateGoombaSprite()
		{
			return new GoombaSprite(goombaSpritesheet);
		}
		
		public static ISprite CreateGreenKoopaSprite()
		{
			return new KoopaSprite(koopaSpritesheet);
		}
    }
}
