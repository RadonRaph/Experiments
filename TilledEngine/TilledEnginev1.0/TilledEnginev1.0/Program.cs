using System;

namespace TilledEnginev1._0
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static MainGame game;

        [STAThread]
        static void Main()
        {
            using (var g = new MainGame())
            {
                game = g;
                BasicShapes.gd = game.graphics.GraphicsDevice;
                
                g.Run();

            }
                
           
        }
    }
}
