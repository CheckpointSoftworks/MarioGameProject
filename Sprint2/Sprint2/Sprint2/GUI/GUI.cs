using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GUI
    {
        private List<IScoreItem> items;

        public GUI()
        {
            items = new List<IScoreItem>();
        }

        public void Subscribe(IScoreItem newItem)
        {
            items.Add(newItem);
        }

        public void Update()
        {
            foreach (IScoreItem i in items)
            {
                i.Update();
            }
        }

        public void DrawAll(SpriteBatch spriteBatch, SpriteFont font)
        {
            foreach(IScoreItem i in items)
            {
                i.Draw(spriteBatch, font, Vector2.Zero);
            }
        }
        public void DrawPlayGUI(SpriteBatch spriteBatch, SpriteFont font)
        {
            foreach (IScoreItem i in items)
            {
                if (i.DrawEveryFrame()) i.Draw(spriteBatch, font, Vector2.Zero);
            }
        }
    }
}
