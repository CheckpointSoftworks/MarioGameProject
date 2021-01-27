using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public static class ProjectileBlockCollisionHandler
    {
        public static void handleCollision(IProjectile projectile,IBlock block,ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleMovement(projectile, block, side);
            }
        }

        private static void handleMovement(IProjectile projectile, IBlock block, ICollision side)
        {
            Rectangle projectileRectangle = projectile.returnCollisionRectangle();
            Rectangle blockRectangle = block.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(blockRectangle, projectileRectangle);
            Vector2 projectileLocation = projectile.returnLocation();
            int locationDiffToChange = UtilityClass.zero;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newProjectileX = (int)projectileLocation.X - locationDiffToChange;
                projectile.updateLocation(new Vector2(newProjectileX, projectileLocation.Y));
                projectile.RigidBody().RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newProjectileX = (int)projectileLocation.X + locationDiffToChange;
                projectile.updateLocation(new Vector2(newProjectileX, projectileLocation.Y));
                projectile.RigidBody().LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                projectile.RigidBody().BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                projectile.RigidBody().TopCollision();
            }
        }
    }
}
