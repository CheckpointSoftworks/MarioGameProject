using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class ShakyCameraController
    {
        private Camera camera;
        private IPlayer mario;
        private Vector2 marioPosition;
        private int marioCameraPosition;
        private int screenCenter;
        private int shakePosition;
        private Boolean shakeForward;
        private Boolean shake;
        private int shakeIntensity;
        private int wobbleDistance;
        private int shakeCounter;
        private int damageCounter;

        public ShakyCameraController(Camera camera, IPlayer mario)
        {
            this.camera = camera;
            this.mario = mario;
            marioPosition = ((Mario)mario).Location;
            screenCenter = camera.GetWidth() / UtilityClass.two;
            shakePosition = 0;
            shakeForward = true;
            shake = false;
            shakeCounter = 0;
            wobbleDistance = 20;
            shakeIntensity = 4;
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

            if (damageCounter != ((Mario)mario).takingDamage)
            {
                Shake();
            }

            if (shake)
            {
                UpdateShakePosition();
            }

            marioPosition = mario.GetLocation();
            damageCounter = ((Mario)mario).takingDamage;
        }

        private void UpdateShakePosition()
        {
            if (shakePosition > wobbleDistance || shakePosition < -wobbleDistance)
            {
                shakeForward = !shakeForward;
                shakeCounter++;
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

            if (shakeCounter == 4 && shakePosition == 0)
            {
                shake = false;
                shakeCounter = 0;
            }
        }

        public void Shake()
        {
            shake = true;
        }
    }
}
