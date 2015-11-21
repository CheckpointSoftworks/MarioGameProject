using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Diagnostics;

namespace Sprint2
{
    public class LevelLoader
    {

        public string LevelName { get; set; }
        public Camera camera { get; set; }
        public LevelLoader(string levelname, Camera camera)
        {
            this.LevelName = levelname;
            this.camera = camera;
        }
        public LevelStorage LoadLevel()
        {
            LevelStorage storage = new LevelStorage(camera);
            using (var levelfile = TitleContainer.OpenStream(@"Content\" + LevelName))
            {
                using (var sr = new StreamReader(levelfile))
                {
                    var ObjectType = sr.ReadLine();
                    ObjectType.Trim();
                    while (ObjectType != "<!-- END -->")
                    {
                        if (ObjectType == "<BrickBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new BrickBlock(XVal, YVal,BlockType.Brick);
                            storage.blocksList.Add(GameObject);
                            BreakableBlockStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType.Trim();
                        }
                        else if (ObjectType == "<BoxCoin>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IItemObjects GameObject;
                            GameObject = new BoxCoin(XVal, YVal);
                            storage.itemList.Add(GameObject);
                            CoinStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<FireFlower>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IItemObjects GameObject;
                            GameObject = new FireFlower(XVal, YVal);
                            storage.itemList.Add(GameObject);
                            FireFlowerStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<Goomba>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IEnemyObject GameObject;
                            GameObject = new Goomba(XVal, YVal);
                            storage.enemiesList.Add(GameObject);
                            GoombaStats.TotalAvailable++;
                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }

                        else if (ObjectType == "<GroundBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new Blocks(XVal, YVal,BlockType.Ground);
                            storage.blocksList.Add(GameObject);
                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        } 
                        else if (ObjectType == "<HiddenBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new HiddenBlock(XVal, YVal,BlockType.Hidden);
                            storage.blocksList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<CoinDispenserBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new BrickBlockCoinDispenser(XVal, YVal, BlockType.BrickCoin);
                            storage.blocksList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<Koopa>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IEnemyObject GameObject;
                            GameObject = new Koopa(XVal, YVal);
                            storage.enemiesList.Add(GameObject);
                            KoopaStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<OneUpMushroom>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IItemObjects GameObject;
                            GameObject = new OneUpMushroom(XVal, YVal);
                            storage.itemList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<Pipe>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IEnviromental GameObject;
                            GameObject = new Pipe(XVal, YVal);
                            storage.enviromentalObjectsList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<PlatformingBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new Blocks(XVal, YVal,BlockType.Platforming);
                            storage.blocksList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<QuestionStarBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new QuestionStarBlock(XVal,YVal,BlockType.QuestionStar);
                            storage.blocksList.Add(GameObject);
                            SuperStarStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<QuestionCoinBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new QuestionCoinBlock(XVal, YVal, BlockType.QuestionCoin);
                            storage.blocksList.Add(GameObject);
                            CoinStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<QuestionSuperMushroomFireFlowerBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new QuestionSuperMushroomFireFlower(XVal, YVal, BlockType.QuestionSuperMushroomFireFlower);
                            storage.blocksList.Add(GameObject);
                            FireFlowerStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<SuperMushroom>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IItemObjects GameObject;
                            GameObject = new SuperMushroom(XVal, YVal);
                            storage.itemList.Add(GameObject);
                            SuperMushroomStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<SuperStar>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IItemObjects GameObject;
                            GameObject = new SuperStar(XVal, YVal);
                            storage.itemList.Add(GameObject);
                            SuperStarStats.TotalAvailable++;
                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<Mario>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IPlayer GameObject;
                            GameObject = new Mario(XVal, YVal);
                            storage.player = GameObject;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<BlueBrickBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new BlueBrickBlock(XVal, YVal, BlockType.BlueBrick);
                            storage.blocksList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<BlueGroundBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IBlock GameObject;
                            GameObject = new BlueGroundBlock(XVal, YVal, BlockType.BlueGround);
                            storage.blocksList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<UndergroundPipe>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            Pipe GameObject = new Pipe(XVal, YVal);
                            ((Pipe)GameObject).setUnderground();
                            storage.enviromentalObjectsList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<RightFacingPipeEdge>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            RightFacingPipeEdge GameObject = new RightFacingPipeEdge(XVal, YVal);
                            storage.enviromentalObjectsList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<RightFacingPipe>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            RightFacingPipe GameObject = new RightFacingPipe(XVal, YVal);
                            storage.enviromentalObjectsList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<StaticCoin>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);

                            IItemObjects GameObject = new StaticCoin(XVal, YVal);
                            storage.itemList.Add(GameObject);
                            CoinStats.TotalAvailable++;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else
                        {
                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                    }
                }
            }
            return storage;
        }
    }
}
