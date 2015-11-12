using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{
    public static class MusicFactory
    {
        private static Song mainTheme;
        private static Song starMan;
        private static Song dead;
        private static Song gameOver;

           
        public static void Load(ContentManager content){
            mainTheme = content.Load<Song>("Music/maintheme");
            starMan = content.Load<Song>("Music/starman");
            dead = content.Load<Song>("Music/dead");
            gameOver = content.Load<Song>("Music/gameover");

            
        }

        public static void MainTheme()
        {
            MediaPlayer.Play(mainTheme);
            MediaPlayer.IsRepeating = true;
        }

        public static void StarMan()
        {
            MediaPlayer.Play(starMan);
            MediaPlayer.IsRepeating = false;
        }
        public static void Dead()
        {
            MediaPlayer.Play(dead);
            MediaPlayer.IsRepeating = false;
            while (!MediaPlayer.State.Equals(MediaState.Stopped))
            {

            }
           
        }
        public static void GameOver()
        {
            MediaPlayer.Play(gameOver);
            MediaPlayer.IsRepeating = false;
            while (!MediaPlayer.State.Equals(MediaState.Stopped))
            {

            }
        }
        
    }
}
