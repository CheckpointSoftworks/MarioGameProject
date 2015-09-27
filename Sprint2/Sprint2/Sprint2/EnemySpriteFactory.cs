using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public static class EnemySpriteFactory
    {
        private static Texture2D goombaSpritesheet;
        private static Texture2D koopaSpritesheet;

		public static void Load(ContentManager content, GraphicsDevice device)
		{
			goombaSpritesheet = content.Load<Texture2D>("GoombaSpriteSheet");
            koopaSpritesheet = content.Load<Texture2D>("KoopaSpriteSheet");
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
