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
        int timer = 1600;
        public StarMario(Mario decoratedMario)
        {
            this.decoratedMario = decoratedMario;
        }
        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar();
            }

           state.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.setDrawColor(Color.Black);
            decoratedMario.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }

        void RemoveStar()
        {
            decoratedMario.Star = false;
            decoratedMario.State.setDrawColor(Color.White);
        }

    }
}
