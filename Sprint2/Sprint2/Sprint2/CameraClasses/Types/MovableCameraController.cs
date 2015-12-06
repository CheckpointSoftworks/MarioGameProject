using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MovableCameraController
    {

        private int cameraWidth;
        private Camera camera;
        private IPlayer mario;
        private Vector2 marioPosition;
        private Vector2 cameraPosition;
        private int screenCenter;
        private int marioCameraPosition;
        private GamepadController gamepad;
        private float movementDistance;
        private int lookDistance;


        public MovableCameraController(Camera camera, IPlayer mario, GamepadController gamepad, int lookDistance)
        {
            this.camera = camera;
            cameraWidth = camera.GetWidth();
            cameraPosition = camera.GetPosition();
            this.mario = mario;
            marioPosition = mario.GetLocation();
            screenCenter = cameraWidth/UtilityClass.two;
            this.gamepad = gamepad;
            movementDistance = 0;
            this.lookDistance = lookDistance;
        }

        public void Update()
        {
            camera.MoveRight(-(int)movementDistance);
            marioCameraPosition = (int)(marioPosition.X - cameraPosition.X);


            float thumbstickInput = gamepad.padState1.ThumbSticks.Right.X;
            movementDistance = thumbstickInput * lookDistance;

            camera.MoveRight((int)movementDistance);


            int newCenter = (screenCenter - (int)movementDistance);
            if (marioCameraPosition > newCenter && (camera.GetPosition().X + UtilityClass.currentScreenMax) < UtilityClass.maxScroll)
            {
                camera.MoveRight(marioCameraPosition - newCenter);
            }
            
            if (marioCameraPosition < 0)
            {
                int newMarioX = (int)marioPosition.X - marioCameraPosition;
                ((Mario)mario).Location = new Vector2(newMarioX, mario.GetLocation().Y);
            }

            cameraPosition = camera.GetPosition();
            marioPosition = mario.GetLocation();
        }
    }
}
