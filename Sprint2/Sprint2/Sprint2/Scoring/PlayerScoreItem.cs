using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlayerScoreItem : IScoreItem
    {
        public enum GUIType { coin, mario, text };
        private GUIType type;
        private ISprite sprite;
        private Vector2 location;
        private int chainModifier;
        private bool drawEveryFrame;
        public int ScoreValue { get; set; }
        
        public String ScoreName { private get; set; }

        override public String ToString()
        {
            return ScoreName.ToString() + ScoreValue.ToString();
        }

        public PlayerScoreItem()
        {
            ScoreValue = UtilityClass.zero;
            ScoreName = UtilityClass.score;
            chainModifier = UtilityClass.one;
        }

        public PlayerScoreItem(String name, int value, Vector2 loc,bool frame)
        {
            type = GUIType.text;
            location = loc;
            ScoreName = name;
            ScoreValue = value;
            chainModifier = 1;
            drawEveryFrame = frame;
        }
        public PlayerScoreItem(GUIType type, int value, Vector2 loc,bool frame)
        {
            ScoreName = UtilityClass.emptyString;
            this.type = type;
            location = loc;
            ScoreValue = value;
            chainModifier = 1;
            sprite = GetSprite();
            drawEveryFrame = frame;
        }
        private ISprite GetSprite()
        {
            switch (type)
            {
                case (GUIType.coin) :
                    {
                        return new GUICoinSprite(location);                        
                    }
                case (GUIType.mario):
                    {
                        return new GUIMarioSprite(location);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public int ComboValue()
        {
            return chainModifier;
        }
        public void ChainHit()
        {
            chainModifier++;
        }

        public void ResetChain()
        {
            chainModifier = UtilityClass.one;
        }
        public void Update()
        {
            if (!type.Equals(GUIType.text))
            {
                sprite.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font, Vector2 cameraLoc)
        {
            switch(type)
            { 
                case(GUIType.text) :
                {
                    spriteBatch.DrawString(font, ToString(), location, Color.White);
                    break;
                }
                case(GUIType.coin) :
                {
                    Vector2 adjustedLocation = location;
                    adjustedLocation.X += UtilityClass.sixteen;
                    sprite.Draw(spriteBatch,cameraLoc);
                    spriteBatch.DrawString(font, UtilityClass.GUIMarioCoinName + ToString(), adjustedLocation, Color.White);
                    break;
                }
                default :
                {
                    Vector2 adjustedLocation = location;
                    adjustedLocation.X += UtilityClass.DefaultSpriteWidth;
                    sprite.Draw(spriteBatch, cameraLoc);
                    spriteBatch.DrawString(font, ToString(), adjustedLocation, Color.White);
                    break;
                }
            }
        }
        public bool DrawEveryFrame()
        {
            return drawEveryFrame;
        }
        public void UpdateScore(int val)
        {
            ScoreValue += val * UtilityClass.ChainBonusMultiplier[chainModifier];
        }
        public void UpdateScoreNoChain(int val)
        {
            ScoreValue += val;
        }
    }
}
