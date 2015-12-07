using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class ClassicCameraController : ICameraController
    {
         private int cameraWidth;
        private Camera camera;
        private IPlayer mario;
        private Vector2 marioPosition;
        private Vector2 cameraPosition;
        private int screenCenter;
        private int marioCameraPosition;
        private int oldMarioCameraPosition;


        public ClassicCameraController(Camera camera, IPlayer mario)
        {
            this.camera = camera;
            cameraWidth = camera.GetWidth();
            cameraPosition = camera.GetPosition();
            this.mario = mario;
            marioPosition = mario.GetLocation();
            screenCenter = cameraWidth/UtilityClass.two;
        }

        public void Update()
        {
            marioCameraPosition = (int)(marioPosition.X - cameraPosition.X);

            if (marioCameraPosition < screenCenter && marioCameraPosition > (screenCenter/2) && (camera.GetPosition().X + UtilityClass.currentScreenMax) < UtilityClass.maxScroll)
            {
                if (marioCameraPosition > oldMarioCameraPosition) {
                    camera.MoveRight(1);
                }
            }

            if (marioCameraPosition > screenCenter && (camera.GetPosition().X + UtilityClass.currentScreenMax) < UtilityClass.maxScroll)
            {
                camera.MoveRight(marioCameraPosition - screenCenter);
            }

            if (marioCameraPosition < 0)
            {
                int newMarioX = (int)marioPosition.X - marioCameraPosition;
                ((Mario)mario).Location = new Vector2(newMarioX, mario.GetLocation().Y);
            }
            oldMarioCameraPosition = marioCameraPosition;
            cameraPosition = camera.GetPosition();
            marioPosition = mario.GetLocation();
        }
    }
}
