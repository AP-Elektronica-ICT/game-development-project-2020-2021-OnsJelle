using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.Animations
{
    public interface IEntityAnimation
    {
        Animation Animation { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void animHandler(bool hasJumped);
    }
}
