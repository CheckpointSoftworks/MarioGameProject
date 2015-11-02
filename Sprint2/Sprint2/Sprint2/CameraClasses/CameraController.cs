using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class CameraController
    {
        private int cameraWidth;
        private Camera camera;
        private IPlayer mario;
        private Vector2 marioPosition;
        private Vector2 cameraPosition;
        private int screenCenter;
        private int marioCameraPosition;


        public CameraController(Camera camera, IPlayer mario)
        {
            this.camera = camera;
            cameraWidth = camera.GetWidth();
            cameraPosition = camera.GetPosition();
            this.mario = mario;
            marioPosition = mario.returnLocation();
            screenCenter = cameraWidth/2;
        }

        public void Update()
        {
            marioCameraPosition = (int)(marioPosition.X - cameraPosition.X);
            if (marioCameraPosition > screenCenter && (camera.GetPosition().X + 800) < 3500)
            {
                camera.MoveRight(marioCameraPosition - screenCenter);
            }

            if (marioCameraPosition < 0)
            {
                int newMarioX = (int)marioPosition.X - marioCameraPosition;
                ((Mario)mario).Location = new Vector2(newMarioX, mario.returnLocation().Y);
            }
            cameraPosition = camera.GetPosition();
            marioPosition = mario.returnLocation();
        }
    }
}
