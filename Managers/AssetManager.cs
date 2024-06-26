﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Managers
{
    static class AssetManager
    {
        public static SpriteFont DefaultFont, ScoreBoardFont;

        public static Texture2D MenuBackground;
        public static Texture2D StartButton, QuitButton, ConfirmButton, ArcherButton, MageButton;

        public static Texture2D GameMap, Path, ArcherTower, MageTower, Goblin, Orc;
        public static Texture2D TutorialMessage, UIBackground, ShopMenu, Scoreboard;
        public static Texture2D Arrow, IceBall;
        public static Texture2D Particle;

        public static void LoadSprites(ContentManager content)
        {
            DefaultFont = content.Load<SpriteFont>("default");
            ScoreBoardFont = content.Load<SpriteFont>("scoreboard");

            MenuBackground = content.Load<Texture2D>("MainMenu\\TDbackground");
            StartButton = content.Load<Texture2D>("MainMenu\\startbutton");
            QuitButton = content.Load<Texture2D>("MainMenu\\quitbutton");

            ConfirmButton = content.Load<Texture2D>("UI\\confirmbutton");
            TutorialMessage = content.Load<Texture2D>("UI\\tutorialmessagebox");
            GameMap = content.Load<Texture2D>("Game\\TDgamemap");
            Path = content.Load<Texture2D>("Game\\path");
            UIBackground = content.Load<Texture2D>("UI\\TDUI");
            ArcherTower = content.Load<Texture2D>("Game\\bowtower");
            MageTower = content.Load<Texture2D>("Game\\magetower");
            Goblin = content.Load<Texture2D>("Game\\goblin");
            Orc = content.Load<Texture2D>("Game\\orc");
            ShopMenu = content.Load<Texture2D>("UI\\shopmenu");
            ArcherButton = content.Load<Texture2D>("UI\\archerbutton");
            MageButton = content.Load<Texture2D>("UI\\magebutton");
            Arrow = content.Load<Texture2D>("Game\\arrow");
            IceBall = content.Load<Texture2D>("Game\\iceball");
            Particle = content.Load<Texture2D>("Game\\particle");
            Scoreboard = content.Load<Texture2D>("UI\\scoreboard");
        }
    }
}


