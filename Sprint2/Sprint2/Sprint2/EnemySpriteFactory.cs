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

		public static void Load(ContentManager content)
		{
			goombaSpritesheet = content.Load<Texture2D>("GoombaSpriteSheet");
            koopaSpritesheet = content.Load<Texture2D>("KoopaSpriteSheet");
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
