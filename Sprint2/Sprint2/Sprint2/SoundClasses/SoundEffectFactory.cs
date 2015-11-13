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

        public static void Load(ContentManager content)
        {
            coin = content.Load<SoundEffect>(UtilityClass.coinEffect);
            item = content.Load<SoundEffect>(UtilityClass.itemEffect);
            oneUp = content.Load<SoundEffect>(UtilityClass.oneUpEffect);
            jumpSmall = content.Load<SoundEffect>(UtilityClass.jumpSmallEffect);
            jumpBig = content.Load<SoundEffect>(UtilityClass.jumpBigEffect);
            stomp = content.Load<SoundEffect>(UtilityClass.stompEffect);
            powerUp = content.Load<SoundEffect>(UtilityClass.powerUpEffect);
            transitionSmall = content.Load<SoundEffect>(UtilityClass.transitionSmallEffect);
            fireball = content.Load<SoundEffect>(UtilityClass.fireballEffect);
            kick = content.Load<SoundEffect>(UtilityClass.kickEffect);
            brickbreak = content.Load<SoundEffect>(UtilityClass.brickbreakEffect);
            bump = content.Load<SoundEffect>(UtilityClass.bumpEffect);
            pipe = content.Load<SoundEffect>(UtilityClass.pipeEffect);
            pause = content.Load<SoundEffect>(UtilityClass.pauseEffect);
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
