using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ProjectileBlockCollisionHandler
    {
        public ProjectileBlockCollisionHandler()
        {

        }
        public void handleCollision(IProjectile projectile,IBlock block,ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleMovement(projectile, block, side);
            }
        }

        private void handleMovement(IProjectile projectile, IBlock block, ICollision side)
        {
            Rectangle projectileRectangle = projectile.returnCollisionRectangle();
            Rectangle blockRectangle = block.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(blockRectangle, projectileRectangle);
            Vector2 projectileLocation = projectile.returnLocation();
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newProjectileX = (int)projectileLocation.X - locationDiffToChange;
                projectile.updateLocation(new Vector2(newProjectileX, projectileLocation.Y));
                projectile.RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newProjectileX = (int)projectileLocation.X + locationDiffToChange;
                projectile.updateLocation(new Vector2(newProjectileX, projectileLocation.Y));
                projectile.LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newProjectileY = (int)projectileLocation.Y - locationDiffToChange;
                projectile.BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newProjectileY = (int)projectileLocation.Y + locationDiffToChange;
                projectile.TopCollision();
            }
        }
    }
}
