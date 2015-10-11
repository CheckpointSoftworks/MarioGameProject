using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class StarMario: IPlayerState
    {
        private Mario decoratedMario;
        int timer = 600;
        Game1 game;
        public StarMario(Mario decoratedMario, Game1 game)
        {
            this.decoratedMario = decoratedMario;
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
            if (timer % 5==0)
            {
                decoratedMario.Draw(spriteBatch);
            }
            else if (timer % 2 == 0)
            {

            }
            else
            {

            }
        }
        public void Still()
        {
            decoratedMario.State = new MarioStill(decoratedMario);
        }
        public void Running()
        {
            decoratedMario.State = new MarioRunning(decoratedMario);
        }
        public void ChangeDirection()
        {
            decoratedMario.State = new MarioChangeDirection(decoratedMario);
        }
        public void Jump()
        {
            decoratedMario.State = new MarioChangeDirection(decoratedMario);
        }
        public void ShootFireball()
        {
            //Nothing
        }
        public void Duck()
        {
            decoratedMario.State = new MarioDuck(decoratedMario);
        }
        public void Dying()
        {
            //Star mario cannot die.
        }

        void RemoveStar()
        {
            game.mario = decoratedMario;
        }

        public Rectangle returnStateCollisionRectangle()
        {
            return decoratedMario.returnCollisionRectangle();
        }
    }
}
