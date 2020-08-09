using System;

namespace StarWarrior
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (StarWarrior game = new StarWarrior())
            {
                game.Run();
            }
        }
    }
#endif
}

