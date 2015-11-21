using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{
    public class GameOver
    {
        public Boolean deathscreen;
        private float deathtime;
        private SpriteFont font;
        private SpriteFont basicarialfont;
        private Texture2D deathbackground;
        private Boolean playmusic;
        public GameOver(Game1 game)
        {
             deathscreen = false;
             deathtime = UtilityClass.deathTimer;
             playmusic = true;
             font = game.Content.Load<SpriteFont>(UtilityClass.FontString);
             basicarialfont = game.Content.Load<SpriteFont>(UtilityClass.BasicArialFontString);
             deathbackground = game.Content.Load<Texture2D>(UtilityClass.deathbackground);
        }
        public void Update(Mario mario, float elapsedtime, Game1 game)
        {
             if (((Mario)mario).StateStatus().Equals(MarioState.Die))
             {
                if (playmusic)
                {
                    MusicFactory.Dead();
                    while (MediaPlayer.State != MediaState.Stopped) { }
                    playmusic = false;
                }  
                while (MediaPlayer.State != MediaState.Stopped) { }
                if (((Mario)mario).GetLives().ScoreValue < UtilityClass.zero) { MusicFactory.GameOver(); }
                if (deathtime > UtilityClass.zero) { deathscreen = true;  deathtime = deathtime - elapsedtime; }
                else
                {
                    deathscreen = false;
                    game.resetCommand.Execute();
                    playmusic = true;
                    deathtime = UtilityClass.deathTimer;
                }
             }
               
            else if (((int)(((Mario)mario).Location.Y)) > game.camera.GetHeight())
            {
                ((Mario)mario).DieImmediately();
                if (playmusic)
                {
                    MusicFactory.Dead();
                    while (MediaPlayer.State != MediaState.Stopped) { }
                    playmusic = false;
                }               
                if (((Mario)mario).GetLives().ScoreValue < UtilityClass.zero)
                {
                    MusicFactory.GameOver();
                }
                if (deathtime > UtilityClass.zero) { deathscreen = true; deathtime = deathtime - elapsedtime; }
                else
                {
                    deathscreen = false;
                    game.resetCommand.Execute();
                    playmusic = true;
                    deathtime = UtilityClass.deathTimer;
                }
            }
        }

        public void Draw(Game1 game)
        {
            Rectangle sourceRectangle = new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.gameOverScreenWidth, UtilityClass.generalSpriteHeightAndWidth);
            Rectangle mariodestinationRectangle = new Rectangle(UtilityClass.deathMarioLocationX, UtilityClass.deathMarioLocationY, UtilityClass.gameOverScreenWidth, UtilityClass.generalSpriteHeightAndWidth);
            Rectangle marioLives = new Rectangle(UtilityClass.deathMarioLocationX + UtilityClass.ten, UtilityClass.deathMarioLocationY, UtilityClass.gameOverScreenWidth, UtilityClass.generalSpriteHeightAndWidth);
            Rectangle backgrounddestinationRectangle = new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.deathBackgroundX, UtilityClass.deathBackgroundY);
            Texture2D deathmario = MarioSpriteFactory.CreateMarioSmallStillSprite();
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(deathbackground, backgrounddestinationRectangle, sourceRectangle, Color.Black);
            game.gui.DrawPlayGUI(game.spriteBatch, font);
            if (((Mario)game.mario).GetLives().ScoreValue >= UtilityClass.zero)
            {
                game.spriteBatch.DrawString(basicarialfont, UtilityClass.worldLevel, UtilityClass.deathtextloc, Color.White);
                game.spriteBatch.DrawString(font, UtilityClass.x, UtilityClass.deathmarioloc, Color.White);
                game.spriteBatch.DrawString(font, ((Mario)game.mario).GetLives().ScoreValue.ToString(), UtilityClass.remaininglivesloc, Color.White);
                game.spriteBatch.Draw(deathmario, mariodestinationRectangle, sourceRectangle, Color.White);
                ((Mario)game.mario).stats.DrawTotals(game.spriteBatch,font, new Vector2(UtilityClass.deathmarioloc.X-80,UtilityClass.deathmarioloc.Y+20));
            }
            else { game.spriteBatch.DrawString(font, UtilityClass.gameOver, UtilityClass.deathtextloc, Color.White); }
            game.spriteBatch.End();
        }
    }
}
