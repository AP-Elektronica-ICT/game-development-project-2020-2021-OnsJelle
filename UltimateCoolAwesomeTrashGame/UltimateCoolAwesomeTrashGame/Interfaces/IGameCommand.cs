using Microsoft.Xna.Framework;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.Interfaces
{
    interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction);
    }
}
