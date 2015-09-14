using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class DeadFloatingMario : ISprite
    {
        public Texture2D Texture { get; set; }
        public ContentManager Content { get; set; }
        public Vector2 Location { get; set; }
        private bool floatingUp=false;

        public DeadFloatingMario(ContentManager contentManager)
        {
            Content = contentManager;
            Texture = Content.Load<Texture2D>("DeadMario");
            Location = new Vector2(400, 200);
        }

        public void Update()
        {
            int yCorrdinate = (int)Location.Y;
            if (floatingUp){
                yCorrdinate--;

                if (yCorrdinate == 190)
                {
                    floatingUp = false;
                }

            }
            else
            {
                yCorrdinate++;
                if (yCorrdinate == 210)
                {
                    floatingUp = true;
                }
            }
            Location = new Vector2(Location.X, yCorrdinate);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 14, 14);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
