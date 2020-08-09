using System;

namespace ComponentPacManTest
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PacManTest game = new PacManTest())
            {
                game.Run();
            }
        }
    }
#endif
}

