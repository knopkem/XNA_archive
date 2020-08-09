using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ClassicPacMan
{
    internal static class GamePadHelper
    {
        public static Keys currentKey(PlayerIndex index)
        {
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A))
                return Keys.Enter;

            float X = GamePad.GetState(index).ThumbSticks.Left.X;
            float Y = GamePad.GetState(index).ThumbSticks.Left.Y;

            if (X == 0 && Y == 0)
                return Keys.Z;

            if (Math.Abs(X) > Math.Abs(Y))
            {
                if (X < 0)
                    return Keys.Left;
                else
                    return Keys.Right;
            }
            else
            {
                if (Y < 0)
                    return Keys.Down;
                else
                    return Keys.Up;
            }
        }
    }
}