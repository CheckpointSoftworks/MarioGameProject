using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class SkyWorldTransition
    {
        private Boolean hasbeguntransition;
        private Boolean vine_has_popped;
        private Boolean vine_box_hit;
        private Boolean drawtransition;
        private Boolean hit_vine;
        private float vinegrowthtime;
        private float transitiontime;
        public VineSequenceMario VineMario { get; set; }
        public SkyWorldTransition()
        {
            hasbeguntransition = false;
            drawtransition = false;
            vine_has_popped = false;
            vine_box_hit = false;
            hit_vine = false;
            vinegrowthtime = UtilityClass.two;
            transitiontime = UtilityClass.two;
            Vector2 location = new Vector2(368,320);
        }
        public void Update(Mario mario, float elapsedtime, Game1 game)
        {
            if (vine_box_hit)
            {
                if(vinegrowthtime > 1.5)
                {
                    SoundEffectFactory.OneUp();
                    IEnviromental GameObject = new SmallVine(355, 230);
                    game.levelStore.enviromentalObjectsList.Add(GameObject);
                    vinegrowthtime = vinegrowthtime - elapsedtime;
                }
                else if(vinegrowthtime > 1)
                {
                    IEnviromental GameObject = new MediumVine(355, 140);
                    game.levelStore.enviromentalObjectsList.Add(GameObject);
                    vinegrowthtime = vinegrowthtime - elapsedtime;
                }
                else if(vinegrowthtime > .5)
                {
                    IEnviromental GameObject = new LargeVine(355, 50);
                    game.levelStore.enviromentalObjectsList.Add(GameObject);
                    vinegrowthtime = vinegrowthtime - elapsedtime;
                }
                else if (vinegrowthtime > 0)
                {
                    IEnviromental GameObject = new FullVine(355, -40);
                    game.levelStore.enviromentalObjectsList.Add(GameObject);
                    vinegrowthtime = vinegrowthtime - elapsedtime;
                }
                else
                {
                    vine_box_hit = false;
                    vine_has_popped = true;
                }
            }
            if(vine_has_popped)
            {
                if (IsWithinSendSkyWorldBoundary(((Mario)mario).Location))
                {
                    if(((Mario)mario).StateStatus().Equals(MarioState.Jump) || hasbeguntransition == true)
                    {
                        if (hasbeguntransition == false) { SoundEffectFactory.Pipe(); }
                        hasbeguntransition = true;
                        SendToSkyWorld(mario, game);
                    }
                }
            }
            if(IsWithinExitSkyWorldBoundary(((Mario)mario).Location))
            {
                if(((Mario)mario).StateStatus().Equals(MarioState.Duck) || hasbeguntransition == true)
                {
                    if (hasbeguntransition == false) { SoundEffectFactory.Pipe(); }
                    hasbeguntransition = true;
                    SendFromSkyWorld(mario, elapsedtime, game);
                }
            }
        }
        private void SendToSkyWorld(IPlayer mario, Game1 game)
        {
            if (!hit_vine)
            {
                VineMario = new VineSequenceMario(((Mario)mario), ((Mario)mario).Small, ((Mario)mario).Fire, ((Mario)mario).Ice);
                hit_vine = true;
            }
            drawtransition = true;
            VineMario.Update();
            if (VineMario.SequenceFinished)
            {
                game.hitFlagpole = false;
                drawtransition = false;
                hasbeguntransition = false;
                ((Mario)mario).Location = new Vector2(UtilityClass.MarioSkyWorldAppearLocationX,UtilityClass.MarioSkyWorldAppearLocationY);
            }
        }
        private void SendFromSkyWorld(Mario mario, float elapsedtime, Game1 game)
        {
            if (transitiontime > UtilityClass.zero)
            {
                if (transitiontime < UtilityClass.two && transitiontime > UtilityClass.pipeTransistionAnimationSecondFramTime) { ((Mario)mario).Location = new Vector2(UtilityClass.MarioSkyWorldExitPipeLocationX, UtilityClass.pipeSendBelowGroundTransistionOneY+ 35); }
                if (transitiontime < UtilityClass.pipeTransistionAnimationSecondFramTime && transitiontime > UtilityClass.one) { ((Mario)mario).Location = new Vector2(UtilityClass.MarioSkyWorldExitPipeLocationX, UtilityClass.pipeSendBelowGroundTransistionTwoY + 35); }
                if (transitiontime < UtilityClass.one && transitiontime > UtilityClass.pipeTransistionAnimationFourthFrameTime) { ((Mario)mario).Location = new Vector2(UtilityClass.MarioSkyWorldExitPipeLocationX, UtilityClass.pipeSendBelowGroundTransistionThreeY + 35); }
                if (transitiontime < UtilityClass.pipeTransistionAnimationFourthFrameTime && transitiontime > UtilityClass.zero) { ((Mario)mario).Location = new Vector2(UtilityClass.MarioSkyWorldExitPipeLocationX, UtilityClass.pipeSendBelowGroundTransistionFourY + 35); }
                transitiontime = transitiontime - elapsedtime;
            }
            else
            {
                ((Mario)mario).Location = new Vector2(UtilityClass.pipeSendAboveGroundFinishedMarioLocationX, 0);
                game.camera.MoveLeft(UtilityClass.MarioSkyWorldCameraAdjustmentForExit);
                transitiontime = UtilityClass.two;
                MusicFactory.MainTheme();
            }
        }

        private static Boolean IsWithinSendSkyWorldBoundary(Vector2 MarioLocation)
        {
            bool isWithinSendingField = false;
            if (MarioLocation.X > UtilityClass.SkyWorldCoinBlockX1 && MarioLocation.X < UtilityClass.SkyWorldCoinBlockX2)
            {
                isWithinSendingField = true;
            }
            return isWithinSendingField;
        }

        private static Boolean IsWithinExitSkyWorldBoundary(Vector2 MarioLocation)
        {
            bool isWithinSendingField = false;
            if (MarioLocation.X > UtilityClass.MarioSkyWorldExitPipeLocationX-8 && MarioLocation.X < UtilityClass.MarioSkyWorldExitPipeLocationX+26)
            {
                isWithinSendingField = true;
            }
            return isWithinSendingField;
        }

        public void seVineBoxHit(Boolean toSet)
        {
            vine_box_hit = toSet;
        }

        public Boolean returnDrawTransition()
        {
            return drawtransition;
        }
    }
}
