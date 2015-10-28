using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioBlockCollisionHandler
    {
        public MarioBlockCollisionHandler()
        {

        }

        public void handleCollision(Mario mario, IBlock block, ICollision side,Game1 game)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None))&&!(block.returnBlockType().Equals(BlockType.Hidden)))
            {
                handleMarioMovement(mario, block, side);
            }
            else if (block.returnBlockType().Equals(BlockType.Hidden))
            {
                if (!(side.returnCollisionSide().Equals(CollisionSide.None))&&(block.checkForSpecalizedSideCollision()))
                {
                    handleMarioMovement(mario, block, side);
                }
            }

            if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                executeCollisionCommand(mario, block,game);
            }
        }

        private static void executeCollisionCommand(Mario mario, IBlock block,Game1 game)
        {
            BlockType type = block.returnBlockType();
            ICommand command;
            if (type.Equals(BlockType.QuestionCoin))
            {
                command = new MarioQuestionCoinBlockCollisionCommand(block,game);
                command.Execute();
            }
            else if(type.Equals(BlockType.QuestionSuperMushroomFireFlower)&&mario.Small&&!mario.Fire)
            {
                command = new QuestionSuperMushroomCommand(block, game);
                command.Execute();
            }
            else if (type.Equals(BlockType.QuestionSuperMushroomFireFlower) && !mario.Small)
            {
                command = new QuestionFireFlowerCommand(block, game);
                command.Execute();
            }
            else if (type.Equals(BlockType.QuestionStar))
            {
                command = new QuestionStarCommand(block, game);
                command.Execute();
            }
            else if (type.Equals(BlockType.Hidden))
            {
                command = new MarioHiddenBlockCollisionCommand(block,game);
                command.Execute();
            }
            else if (type.Equals(BlockType.BrickCoin))
            {
                command = new BrickBlockDispenserCommand(block, game);
                command.Execute();
            }
            else if (type.Equals(BlockType.Brick)&&((!mario.Small)||(mario.Star)))
            {
                command = new BigMarioBrickBlockCollisionCommand(block,game);
                command.Execute();
            }

        }

        private static void handleMarioMovement(Mario mario, IBlock block, ICollision side)
        {
            Rectangle blockRectangle = block.returnCollisionRectange();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, blockRectangle);
            int locationDiffToChange = 0;
            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X - locationDiffToChange;
                mario.Location = new Vector2(newMarioX, mario.Location.Y);
                mario.rigidbody.HorizontalCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X + locationDiffToChange;
                mario.Location = new Vector2(newMarioX, mario.Location.Y);
                mario.rigidbody.HorizontalCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y - locationDiffToChange;
                mario.Location = new Vector2(mario.Location.X, newMarioY);
                //mario.State.Still();
                mario.rigidbody.BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y + locationDiffToChange;
                mario.Location = new Vector2(mario.Location.X, newMarioY);
                mario.rigidbody.TopCollision();
            }
        }

    }
}
