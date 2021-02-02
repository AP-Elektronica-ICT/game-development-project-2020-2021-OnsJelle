using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using UltimateCoolAwesomeTrashGame.Interfaces;
using UltimateCoolAwesomeTrashGame.World;

namespace UltimateCoolAwesomeTrashGame.Collision
{

    /// <summary>
    /// Deze code heb ik gevraagd aan Sayan omdat ik zelf er niet kon opkomen.
    /// </summary>
    public class CollisionManager
    {
        private ICollisionHelper collisionhelper;
        public CollisionManager(ICollisionHelper helper)
        {
            this.collisionhelper = helper;
        }

        public void ExecuteCollision(Rectangle playerRec, Rectangle newRectangle, int xOffset, int yOffset, IMove entity)
        {

            // Trap hero inside window borders 
            if (entity.Position.X < -20)
                entity.Position = new Vector2(-20, entity.Position.Y);

            if (entity.Position.X+20 > xOffset - playerRec.Width)
                entity.Position = new Vector2(xOffset - playerRec.Width-20, entity.Position.Y);

            if (entity.Position.Y < 0)
                entity.Velocity = new Vector2(entity.Velocity.X, 7.5f);

            if (entity.Position.Y > yOffset - playerRec.Height)
                entity.Position = new Vector2(entity.Position.X, yOffset - playerRec.Height);


            

            if (collisionhelper.CollisionLeftOf(playerRec, newRectangle))
                entity.Position = new Vector2(newRectangle.Left - playerRec.Width-2, entity.Position.Y);

            if (collisionhelper.CollisionRightOf(playerRec, newRectangle))
                entity.Position = new Vector2(newRectangle.Right+2, entity.Position.Y);

            if (collisionhelper.CollisionBottomOf(playerRec, newRectangle))
                entity.Velocity = new Vector2(entity.Velocity.X, 7f);

            entity.OnGround = false;
            if (collisionhelper.CollisionTopOf(playerRec, newRectangle))
            {
                playerRec.Y = newRectangle.Y - (playerRec.Height + 30);
                entity.Velocity = new Vector2(entity.Velocity.X, 0f);
                entity.HasJumped = false;
                entity.OnGround = true;
            }


        }

        public bool CheckEndCollision(Rectangle playerRec, Rectangle endplatformRec) {
            return collisionhelper.CollisionTopOf(playerRec, endplatformRec);
                
        }


        /* public bool CheckCollision(Rectangle rect1, Rectangle rect2, Vector2 direction)
         {
             rect1.X += (int)direction.X * 5;
             rect1.Y += (int)direction.Y * 5;
             if (rect1.Intersects(rect2))
                 return true;

             return false;
         }

         public Vector2 CheckCollisionWorld(ITransform blob, Vector2 direction)
         {
             Vector2 nullvector = new Vector2(0, 0);
             if (currlevel.BlokArray != null)
             {
                 foreach (var item in currlevel.BlokArray)
                 {
                     if (item != null)
                     {
                         if (CheckCollision(blob.CollisionRectangle, item.CollisionRectangle, direction))
                         {                            
                             return nullvector;
                         }
                     }
                 }
             }            
             return direction;
         }*/
    }
}
