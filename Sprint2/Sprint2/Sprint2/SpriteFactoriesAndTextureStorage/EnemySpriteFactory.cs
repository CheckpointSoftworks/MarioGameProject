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
		
		public static Texture2D CreateGoombaSprite()
		{
			return goombaSpritesheet;
		}
        public static Texture2D CreateGoombaDamangedSprite()
        {
            return goombaDamagedSpritesheet;
        }
		
		public static Texture2D CreateKoopaSprite()
		{
			return koopaSpritesheet;
		}
        public static Texture2D CreateKoopaDamagedSprite()
        {
            return koopaShellSpritesheet;
        }

        
    }
}
