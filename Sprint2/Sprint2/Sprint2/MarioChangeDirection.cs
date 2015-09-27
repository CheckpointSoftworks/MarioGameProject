using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
     class MarioChangeDirection: IPlayerState
    {
        private Mario mario;
        private AnimatedSprite small;
        private AnimatedSprite big;
        private AnimatedSprite fire;
        public MarioChangeDirection(Mario mario)
        {
            this.mario = mario;
            mario.FacingRight = !mario.FacingRight;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigChangeDirectionSprite(), 1, 1);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallChangeDirectionSprite(), 1, 1);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireChangeDirectionSprite(), 1, 1);
            //Set Sprite here
        }
        public void Update()
        {
            if (mario.Fire)
            {
                fire.Update();
            }
            else if (mario.Small)
            {
                small.Update();
            }
            else
            {
                big.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mario.Fire)
            {
                fire.Draw(spriteBatch,mario.Location,mario.FacingRight);
            }
            else if (mario.Small)
            {
                small.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
            else
            {
                big.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
        }
        public void Still()
        {
            mario.State = new MarioStill(mario);
        }
        public void Running()
        {
            mario.State = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            //Nothing
        }
        public void Jump()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void ShootFireball()
        {
            if (mario.Fire)
            mario.State = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            mario.State = new MarioDuck(mario);
        }
        public void Dying()
        {
            mario.State = new MarioDying(mario);
        }
    }
 }

