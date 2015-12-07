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
        public Boolean vine_box_hit;
        private Boolean hit_vine;
        private Boolean hasbeguntransitionout;
        private float vinegrowthtime;
        private float transitiontime;
        private AnimatedSprite bigFlagpole;
        private AnimatedSprite smallFlagpole;
        private AnimatedSprite fireFlagpole;
        private AnimatedSprite iceFlagpole;

        public VineSequenceMario VineMario { get; set; }
        public SkyWorldTransition()
        {
            hasbeguntransition = false;
            vine_has_popped = false; //whether vine has finished coming out of the coinbox
            vine_box_hit = false; //whether the box was hit by mario
            hit_vine = false; //whether mario has hit the vine and begun his transition upward
            hasbeguntransitionout = false;
            vinegrowthtime = UtilityClass.two;
            transitiontime = UtilityClass.two;
            Vector2 location = new Vector2(368,320);
        }
        public void Update(Mario mario, float elapsedtime, Camera camera, Game1 game)
        {
            if (vine_box_hit)
            {
                //then display vine growing animation
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

            //vine has grown all the way; if mario jumps between the boundaries of the vine, then show his transition animation.
            if(vine_has_popped)
            {
                if (IsWithinSendSkyWorldBoundary(((Mario)mario).Location))
                {
                    if(((Mario)mario).StateStatus().Equals(MarioState.Jump) || hasbeguntransition == true)
                    {
                        //then show mario's transition animation (climbing up the vine!)
                        if (hasbeguntransition == false) { SoundEffectFactory.Pipe(); }
                        hasbeguntransition = true;
                        SendToSkyWorld(mario, elapsedtime, game);
                    }
                }
            }
        }
        private void SendToSkyWorld(IPlayer mario, float elapsedtime, Game1 game)
        {
            if (!hit_vine)
            {
                VineMario = new VineSequenceMario(((Mario)mario), ((Mario)mario).Small, ((Mario)mario).Fire, ((Mario)mario).Ice);
                hit_vine = true;
            }
            else
            {
                VineMario.Update();
                game.spriteBatch.Begin();
                VineMario.Draw(game.spriteBatch, game.camera.GetPosition());
                game.spriteBatch.End();
                if (VineMario.SequenceFinished)
                {
                    ((Mario)mario).Location = new Vector2(5050, 300);
                }
            }
        }

        private static void SendFromSkyWorld(Mario mario, float elapsedtime)
        {

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
    }
}
