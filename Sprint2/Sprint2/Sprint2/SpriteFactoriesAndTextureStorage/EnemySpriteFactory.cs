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
        private static Texture2D goombaDamagedSpritesheet;
        private static Texture2D koopaSpritesheet;
        private static Texture2D koopaShellSpritesheet;

		public static void Load(ContentManager content)
		{
			goombaSpritesheet = content.Load<Texture2D>("GoombaSpriteSheet");
            goombaDamagedSpritesheet = content.Load<Texture2D>("GoombaDamagedSprite");
            koopaSpritesheet = content.Load<Texture2D>("KoopaSpriteSheet"); 
            koopaShellSpritesheet = content.Load<Texture2D>("KoopaShellSprite");

		}
		
		public static ISprite CreateGoombaSprite(Vector2 location)
		{
			return new GoombaSprite(goombaSpritesheet,location);
		}
        public static ISprite CreateGoombaDamangedSprite(Vector2 location)
        {
            return new GoombaDamagedSprite(goombaDamagedSpritesheet, location);
        }
		
		public static ISprite CreateGreenKoopaSprite(Vector2 location)
		{
			return new KoopaSprite(koopaSpritesheet,location);
		}
        public static ISprite CreateGreenKoopaShellSprite(Vector2 location)
        {
            return new KoopaShellSprite(koopaShellSpritesheet, location);
        }

        
    }
}
