using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Sprint2
{
    public static class SoundEffectFactory
    {
        private static SoundEffect coin;
        private static SoundEffect item;
        private static SoundEffect oneUp;
        private static SoundEffect jumpSmall;
        private static SoundEffect jumpBig;
        private static SoundEffect stomp;
        private static SoundEffect powerUp;
        private static SoundEffect transitionSmall;
        private static SoundEffect fireball;
        private static SoundEffect kick;
        private static SoundEffect brickbreak;
        private static SoundEffect bump;
        private static SoundEffect pipe;
        private static SoundEffect pause;
           
        public static void Load(ContentManager content){
            coin = content.Load<SoundEffect>("Sound Effects/coin");
            item = content.Load<SoundEffect>("Sound Effects/item");
            oneUp = content.Load<SoundEffect>("Sound Effects/1up");
            jumpSmall = content.Load<SoundEffect>("Sound Effects/jumpsmall");
            jumpBig = content.Load<SoundEffect>("Sound Effects/jumpbig");
            stomp = content.Load<SoundEffect>("Sound Effects/stomp");
            powerUp = content.Load<SoundEffect>("Sound Effects/powerup");
            transitionSmall = content.Load<SoundEffect>("Sound Effects/pipe");
            fireball = content.Load<SoundEffect>("Sound Effects/fireball");
            kick = content.Load<SoundEffect>("Sound Effects/kick");
            brickbreak = content.Load<SoundEffect>("Sound Effects/breakblock");
            bump = content.Load<SoundEffect>("Sound Effects/bump");
            pipe = content.Load<SoundEffect>("Sound Effects/pipe");
            pause = content.Load<SoundEffect>("Sound Effects/pause");


            
        }

        public static void Coin()
        {
            coin.Play();
        }
        public static void Item()
        {
            item.Play();
        }
        public static void OneUp()
        {
            oneUp.Play();
        }
        public static void JumpSmall()
        {
            jumpSmall.Play();
        }
        public static void Stomp()
        {
            stomp.Play();
        }
        public static void JumpBig()
        {
            jumpBig.Play();
        }
        public static void PowerUp()
        {
            powerUp.Play();
        }
        public static void TransitionSmall()
        {
            transitionSmall.Play();
        }
        public static void Fireball()
        {
            fireball.Play();
        }
        public static void Kick()
        {
            kick.Play();
        }
        public static void BrickBreak()
        {
            brickbreak.Play();
        }
        public static void Bump()
        {
            bump.Play();
        }
        public static void Pipe()
        {
            pipe.Play();
        }
        public static void Pause()
        {
            pause.Play();
        }
        
    }
}
