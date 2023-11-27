using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Scenes
{
    public static class SceneFactory
    {
        private static Scene scene;

        public static Scene Scene { get { return scene; } }

        public static void CreateTitleScreen(int x, int y)
        {
            TitleScreen titleScreen = new TitleScreen(x, y);

            scene = titleScreen;
        }

        public static void CreateSettingsScreen(int x, int y)
        {
            SettingsScreen settingsScreen = new SettingsScreen(x, y);

            scene = settingsScreen;
        }
    }
}
