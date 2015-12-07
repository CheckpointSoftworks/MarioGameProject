using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class DrunkCameraController : ICameraController
    {
        private Camera camera;
        private IPlayer mario;
        private Vector2 marioPosition;
        private int marioCameraPosition;
        private int shakeIntensity;
        private int wobbleDistance;
        private int screenCenter;
        private int shakePosition;
        private Boolean shakeForward;

        public DrunkCameraController(Camera camera, IPlayer mario, int wobbleDistance, int shakeIntensity){
            this.camera = camera;
            this.mario = mario;
            this.shakeIntensity = shakeIntensity;
            this.wobbleDistance = wobbleDistance;
            marioPosition = ((Mario)mario).Location;
            screenCenter = camera.GetWidth() / UtilityClass.two;
            shakePosition = 0;
            shakeForward = true;
        }

        public void Update()
        {
            marioCameraPosition = (int)(marioPosition.X - camera.GetPosition().X);
            int shakeScreenCenter = screenCenter - shakePosition;

            if (marioCameraPosition > shakeScreenCenter && (camera.GetPosition().X + UtilityClass.currentScreenMax) < UtilityClass.maxScroll)
            {
                    camera.MoveRight(marioCameraPosition - shakeScreenCenter);
            }

            if (marioCameraPosition < 0)
            {
                int newMarioX = (int)marioPosition.X - marioCameraPosition;
                ((Mario)mario).Location = new Vector2(newMarioX, mario.GetLocation().Y);
            }

            UpdateShakePosition();
            marioPosition = mario.GetLocation();
        }

        private void UpdateShakePosition()
        {
            if (shakePosition > wobbleDistance || shakePosition < -wobbleDistance)
            {
                shakeForward = !shakeForward;
            }


            if (shakeForward)
            {
                camera.MoveRight(shakeIntensity);
                shakePosition += shakeIntensity;
            }
            else
            {
                camera.MoveLeft(shakeIntensity);
                shakePosition -= shakeIntensity;
            }
        }

    }
}
