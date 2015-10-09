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
			goombaSpritesheet = content.Load<Texture2D>("enemySpriteSheet");
            koopaSpritesheet = content.Load<Texture2D>("enemySpriteSheet");
		}
		
		public static ISprite CreateGoombaSprite(Vector2 location)
		{
			return new GoombaSprite(goombaSpritesheet,location);
		}
		
		public static ISprite CreateGreenKoopaSprite(Vector2 location)
		{
			return new KoopaSprite(koopaSpritesheet,location);
		}
    }
}
