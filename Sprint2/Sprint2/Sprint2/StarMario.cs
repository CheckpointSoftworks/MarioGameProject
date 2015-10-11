using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class StarMario: IPlayer
    {
        private Mario decoratedMario;
        IPlayerState state;
        int timer = 600;
        Game1 game;
        public StarMario(Mario decoratedMario, Game1 game)
        {
            this.decoratedMario = decoratedMario;
            this.state = decoratedMario.State;
            this.game = game;
        }
        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar();
            }

            decoratedMario.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (timer > 180)
            {
                if (timer % 60 == 0)
                {

                }
                else if (timer % 48 == 0)
                {

                }
                else if (timer % 36 == 0)
                {

                }
                else if (timer % 24 == 0)
                {

                }
                else if (timer % 12 == 0)
                {

                }
            }
            else
            {
                if (timer % 60 == 0)
                {

                }
                else if (timer % 40 == 0)
                {

                }
                else if (timer % 20 == 0)
                {

                }
            }
        }

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }

        void RemoveStar()
        {
            game.mario = decoratedMario;
            decoratedMario.Star = false;
        }

    }
}
