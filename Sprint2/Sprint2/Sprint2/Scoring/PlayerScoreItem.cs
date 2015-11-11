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
            ScoreValue = 0;
            ScoreName = "Score:";
            chainModifier = 1;
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
            ScoreName = "";
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
            chainModifier = 1;
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
                    adjustedLocation.X += 16;
                    sprite.Draw(spriteBatch,cameraLoc);
                    spriteBatch.DrawString(font, "x" + ToString(), adjustedLocation, Color.White);
                    break;
                }
                default :
                {
                    Vector2 adjustedLocation = location;
                    adjustedLocation.X += 16;
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
            ScoreValue += val * Chain();
        }
        public void UpdateScoreNoChain(int val)
        {
            ScoreValue += val;
        }

        private int Chain()
        {
            switch(chainModifier)
            {
                case (1):
                    {
                        return 1;
                    }
                case (2):
                    {
                        return 2;
                    }
                case (3):
                    {
                        return 4;
                    }
                case (4):
                    {
                        return 5;
                    }
                case (5):
                    {
                        return 8;
                    }
                case (6):
                    {
                        return 10;
                    }
                case (7):
                    {
                        return 20;
                    }
                case (8):
                    {
                        return 40;
                    }
                case (9):
                    {
                        return 50;
                    }
                case (10):
                    {
                        return 80;
                    }
                default:
                    {
                        return 1;
                    }
            }
        }
    }
}
