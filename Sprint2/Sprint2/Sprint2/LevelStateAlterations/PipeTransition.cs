using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class PipeTransition
    {
        private Boolean hasbeguntransition = false;
        private Boolean hasbeguntransitionout = false;
        private float transitiontime = 2;
        public PipeTransition()
        {

        }
        public void Update(Mario mario, float elapsedtime, Camera camera)
        {
            if (IsWithinSendUndergroundPipeBoundary(((Mario)mario).Location))
            {
                if (((Mario)mario).StateStatus().Equals(MarioState.Duck) || hasbeguntransition == true)
                {
                    if (hasbeguntransition == false) { SoundEffectFactory.Pipe(); }
                    hasbeguntransition = true;
                    if (transitiontime > UtilityClass.zero)
                    {
                        if (transitiontime < UtilityClass.two && transitiontime > UtilityClass.onePointFive) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeSixty); }
                        if (transitiontime < UtilityClass.onePointFive && transitiontime > UtilityClass.one) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeSeventy); }
                        if (transitiontime < UtilityClass.one && transitiontime > UtilityClass.pointFive) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeEighty); }
                        if (transitiontime < UtilityClass.pointFive && transitiontime > UtilityClass.zero) { ((Mario)mario).Location = new Vector2(UtilityClass.nineThrityEight, UtilityClass.threeNintey); }
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
            }
            if (IsWithinReturnFromUndergroundPipeBoundary(((Mario)mario).Location) || hasbeguntransitionout==true)
            {
                if (hasbeguntransitionout == false) { SoundEffectFactory.Pipe(); }
                hasbeguntransitionout = true;
                if (transitiontime > UtilityClass.zero)
                {
                    if (transitiontime < UtilityClass.two && transitiontime > UtilityClass.onePointFive) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundred, UtilityClass.fourTwentyFour); }
                    if (transitiontime < UtilityClass.onePointFive && transitiontime > UtilityClass.one) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundredAndTen, UtilityClass.fourTwentyFour); }
                    if (transitiontime < UtilityClass.one && transitiontime > UtilityClass.pointFive) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundredAndTwenty, UtilityClass.fourTwentyFour); }
                    if (transitiontime < UtilityClass.pointFive && transitiontime > UtilityClass.zero) { ((Mario)mario).Location = new Vector2(UtilityClass.fourtyTwoHundredAndThirty, UtilityClass.fourTwentyFour); }
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

        public Boolean IsWithinSendUndergroundPipeBoundary(Vector2 MarioLocation)
        {
            if (MarioLocation.X > UtilityClass.undergroundpipeleftX && MarioLocation.X < UtilityClass.undergroudpiperightX)
            {
                return true;
            }
            return false;
        }
        public Boolean IsWithinReturnFromUndergroundPipeBoundary(Vector2 MarioLocation)
        {
            if (MarioLocation.X > UtilityClass.leftfacingundergroundpipeX && MarioLocation.Y > UtilityClass.leftfacingundergroundpipeY)
            {
                return true;
            }
            return false;
        }
    }
}
