using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltimateCoolAwesomeTrashGame
{
    public interface ITransform
    {
        Vector2 Position { get; set; }
        void Draw(SpriteBatch spriteBatch);

        public Rectangle CollisionRectangle { get; set; }
    }
}