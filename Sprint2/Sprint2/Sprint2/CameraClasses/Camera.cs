using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class Camera
    {
        private int width;
        private int height;
        private Vector2 position;
        public Camera(int height, int width, Vector2 position)
        {
            this.width = width;
            this.height = height;
            this.position = position;
        }

        public void MoveRight(int distance)
        {
            position.X = position.X + distance;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

    }
}
