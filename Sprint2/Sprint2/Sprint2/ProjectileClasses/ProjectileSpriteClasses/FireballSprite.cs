using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
        class FireballSprite : ISprite
        {
            private AnimatedSprite AnimatedFireball;
            private bool FacingRight = true;
            private Vector2 location;
            private Fireball fireball;
            public Vector2 Location
            {
                get { return location; }
                set { location = value; }
            }

            public FireballSprite(Texture2D FireballSpritesheet, Vector2 location, Fireball fireball)
            {
                this.location = location;
                this.fireball = fireball;
                AnimatedFireball = new AnimatedSprite(FireballSpritesheet, 1, 4, location, 4);
            }
            public void Update()
            {
                AnimatedFireball.Update();
            }

            public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
            {
                AnimatedFireball.Draw(spriteBatch, fireball.returnLocation(), cameraLoc, FacingRight);
            }

            public Rectangle returnCollisionRectangle()
            {
                return AnimatedFireball.returnCollisionRectangle();
            }
        }
}
