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
            Rectangle collisionRectangle=new Rectangle(0,0,0,0);

            //No collision needed for this class yet

            return collisionRectangle;
        }
    }
}
