using System;

namespace KrisWengersSprint0
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Sprint0.Game1 game = new Sprint0.Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

