using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class PipeTransition
    {
        private Boolean hasbeguntransition;
        private Boolean hasbeguntransitionout;
        private float transitiontime;
        public PipeTransition()
        {
            hasbeguntransition = false;
            hasbeguntransitionout = false;
            transitiontime = UtilityClass.two;

        }
        public void Update(Mario mario, float elapsedtime, Camera camera)
        {
            if (IsWithinSendUndergroundPipeBoundary(((Mario)mario).Location))
            {
                sendUnderground(mario,elapsedtime);
            }
            if (IsWithinReturnFromUndergroundPipeBoundary(((Mario)mario).Location) || hasbeguntransitionout==true)
            {
                sendAboveGround(mario, elapsedtime, camera);
            }
        }

        private static Boolean IsWithinSendUndergroundPipeBoundary(Vector2 MarioLocation)
        {
            bool isWithinSendingField = false;
            if (MarioLocation.X > UtilityClass.undergroundpipeleftX && MarioLocation.X < UtilityClass.undergroudpiperightX)
            {
                isWithinSendingField = true;
            }
            return isWithinSendingField;
        }
        private static Boolean IsWithinReturnFromUndergroundPipeBoundary(Vector2 MarioLocation)
        {
            bool isWithinReturnField = false;
            if (MarioLocation.X > UtilityClass.leftfacingundergroundpipeX && MarioLocation.Y > UtilityClass.leftfacingundergroundpipeY)
            {
                isWithinReturnField=true;
            }
            return isWithinReturnField;
        }

        private void sendUnderground(IPlayer mario,float elapsedtime)
        {
            if (((Mario)mario).StateStatus().Equals(MarioState.Duck) || hasbeguntransition == true)
            {
                if (hasbeguntransition == false) { SoundEffectFactory.Pipe(); }
                hasbeguntransition = true;
                sendUndergroundAnimation(mario, elapsedtime);
            }
        }
        private void sendUndergroundAnimation(IPlayer mario,float elapsedtime)
        {
            
                if (transitiontime > UtilityClass.zero)
                {
                    if (transitiontime < UtilityClass.two && transitiontime > UtilityClass.pipeTransistionAnimationSecondFramTime) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeSixty); }
                    if (transitiontime < UtilityClass.pipeTransistionAnimationSecondFramTime && transitiontime > UtilityClass.one) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeSeventy); }
                    if (transitiontime < UtilityClass.one && transitiontime > UtilityClass.pipeTransistionAnimationFourthFrameTime) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeEighty); }
                    if (transitiontime < UtilityClass.pipeTransistionAnimationFourthFrameTime && transitiontime > UtilityClass.zero) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeNintey); }
                    transitiontime = transitiontime - elapsedtime;
                }
                else
                {
                    ((Mario)mario).Location = new Vector2(UtilityClass.fourOThirtyTwo, UtilityClass.threeHundred);
                    transitiontime = UtilityClass.two;
                    hasbeguntransition = false;
                    MusicFactory.UnderworldTheme();
                }
        }
        private void sendAboveGround(IPlayer mario,float elapsedtime,Camera camera)
        {
            if (hasbeguntransitionout == false) { SoundEffectFactory.Pipe(); }
            hasbeguntransitionout = true;
            sendAboveGroundTransistion(mario, elapsedtime, camera);
        }
        private void sendAboveGroundTransistion(IPlayer mario,float elapsedtime,Camera camera)
        {
            if (transitiontime > UtilityClass.zero)
            {
                if (transitiontime < UtilityClass.two && transitiontime > UtilityClass.pipeTransistionAnimationSecondFramTime) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundred, UtilityClass.sendAbovegroundYLocation); }
                if (transitiontime < UtilityClass.pipeTransistionAnimationSecondFramTime && transitiontime > UtilityClass.one) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundredAndTen, UtilityClass.sendAbovegroundYLocation); }
                if (transitiontime < UtilityClass.one && transitiontime > UtilityClass.pipeTransistionAnimationFourthFrameTime) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundredAndTwenty, UtilityClass.sendAbovegroundYLocation); }
                if (transitiontime < UtilityClass.pipeTransistionAnimationFourthFrameTime && transitiontime > UtilityClass.zero) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundredAndThirty, UtilityClass.sendAbovegroundYLocation); }
                transitiontime = transitiontime - elapsedtime;
            }
            else
            {
                ((Mario)mario).Location = new Vector2(UtilityClass.twentySixHundrenAndSixtyFour, UtilityClass.fourHundred);
                camera.MoveLeft(UtilityClass.fiftenSixteen);
                transitiontime = UtilityClass.two;
                hasbeguntransitionout = false;
                MusicFactory.MainTheme();
            }
        }
    }
}
