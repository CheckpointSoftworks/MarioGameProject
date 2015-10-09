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
        public IPlayer player;
        public ArrayList staticObjectsList;
        public ArrayList enemiesList;
        public ArrayList blocksList;
        public ArrayList enviromentalObjectsList;

        public string LevelName { get; set; }
        public LevelLoader(string levelname)
        {
            this.LevelName = levelname;
            staticObjectsList = new ArrayList();
            enemiesList = new ArrayList();
            blocksList = new ArrayList();
            enviromentalObjectsList = new ArrayList();
        }
        public void LoadLevel()
        {
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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IBlock GameObject;
                            GameObject = new BrickBlock(XVal, YVal);
                            blocksList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IItemObjects GameObject;
                            GameObject = new BoxCoin(XVal, YVal);
                            staticObjectsList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IItemObjects GameObject;
                            GameObject = new FireFlower(XVal, YVal);
                            staticObjectsList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IEnemyObject GameObject;
                            GameObject = new Goomba(XVal, YVal);
                            enemiesList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IBlock GameObject;
                            GameObject = new GroundBlock(XVal, YVal);
                            blocksList.Add(GameObject);
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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IBlock GameObject;
                            GameObject = new HiddenBlock(XVal, YVal);
                            blocksList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IEnemyObject GameObject;
                            GameObject = new Koopa(XVal, YVal);
                            enemiesList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IItemObjects GameObject;
                            GameObject = new OneUpMushroom(XVal, YVal);
                            staticObjectsList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IEnviromental GameObject;
                            GameObject = new Pipe(XVal, YVal);
                            enviromentalObjectsList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IBlock GameObject;
                            GameObject = new PlatformingBlock(XVal, YVal);
                            blocksList.Add(GameObject);

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else if (ObjectType == "<QuestionBlock>")
                        {
                            var xstring = sr.ReadLine();
                            string[] xstringSeparators = new string[] { " ", "<x>", "</x>", "\n" };
                            string xtrimmed = xstring.Trim();
                            var xsplit = xtrimmed.Split(xstringSeparators, StringSplitOptions.None);
                            int XVal = Int32.Parse(xsplit[1]);
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IBlock GameObject;
                            GameObject = new QuestionBlock(XVal, YVal);
                            blocksList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IItemObjects GameObject;
                            GameObject = new SuperMushroom(XVal, YVal);
                            staticObjectsList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IItemObjects GameObject;
                            GameObject = new SuperStar(XVal, YVal);
                            staticObjectsList.Add(GameObject);

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
                            Console.WriteLine(XVal);

                            var ystring = sr.ReadLine();
                            string[] ystringSeparators = new string[] { " ", "<y>", "</y>", "\n" };
                            string ytrimmed = ystring.Trim();
                            var ysplit = ytrimmed.Split(ystringSeparators, StringSplitOptions.None);
                            int YVal = Int32.Parse(ysplit[1]);
                            Console.WriteLine(YVal);

                            IPlayer GameObject;
                            GameObject = new Mario(XVal, YVal);
                            player = GameObject;

                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                        else //Skip since comment or end of node.
                        {
                            ObjectType = sr.ReadLine();
                            ObjectType = ObjectType.Trim();
                        }
                    }
                }
            }
        }
    }
}
