using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class RunningInPlaceMario : ISprite
    {
        public Texture2D Texture { get; set; }
        public ContentManager Content { get; set; }
        public Vector2 Location { get; set; }

        private int currentFrame;
        private int totalFrames;
        private int drawCounter;

        public RunningInPlaceMario(ContentManager contentManager)
        {
            currentFrame = 0;
            totalFrames = 4;
            drawCounter = 0;
            Content = contentManager;
            Location = new Vector2(400, 200);
            Texture = Content.Load<Texture2D>("MarioRunningRight");
        }
        public void Update()
        {
            if (drawCounter == 5)
            {
                drawCounter = 0;
                currentFrame++;

                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            else
            {
                drawCounter++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle= new Rectangle(0,0,0,0);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 0,0);

            if (currentFrame == 0)
            {
                sourceRectangle= new Rectangle(0,0,28,18);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 28, 18);

            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(28, 0, 28, 18);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 28, 18);

            }           
            else if (currentFrame == 2)
            {
                sourceRectangle = new Rectangle(56, 0, 31, 18);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 31, 18);

            }
            else if (currentFrame == 3)
            {
                sourceRectangle = new Rectangle(87, 0, 30, 18);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 30,18);
            }
            else if (currentFrame == 4)
            {
                sourceRectangle = new Rectangle(117, 0, 31, 18);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 31, 18);
            }
             
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
