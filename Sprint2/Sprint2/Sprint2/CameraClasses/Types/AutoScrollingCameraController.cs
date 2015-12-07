using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class AutoScrollingCameraController : ICameraController
    {
        private Camera camera;
        private IPlayer mario;
        private Vector2 marioPosition;
        private int marioCameraPosition;
        private int scrollSpeed;

        public AutoScrollingCameraController(Camera camera, IPlayer mario, int scrollSpeed)
        {
            this.camera = camera;
            this.mario = mario;
            this.scrollSpeed = scrollSpeed;
            marioPosition = ((Mario)mario).Location;
        }

        public void Update()
        {
            marioCameraPosition = (int)(marioPosition.X - camera.GetPosition().X);

            if ((camera.GetPosition().X + UtilityClass.currentScreenMax) < UtilityClass.maxScroll)
            {
                camera.MoveRight(scrollSpeed);
            }

            if (marioCameraPosition < 0)
            {
                int newMarioX = (int)marioPosition.X - (marioCameraPosition - scrollSpeed);
                ((Mario)mario).Location = new Vector2(newMarioX, mario.GetLocation().Y);
            }
            if (marioCameraPosition > (UtilityClass.currentScreenMax-16))
            {
                int newMarioX = (int)marioPosition.X - (marioCameraPosition - (UtilityClass.currentScreenMax-16));
               ((Mario)mario).Location = new Vector2(newMarioX, mario.GetLocation().Y);
            }
            marioPosition = mario.GetLocation();
        }
    }
}
