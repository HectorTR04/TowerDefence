﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using TowerDefence.GameObjects.UI;

namespace TowerDefence.Managers
{
    internal class UIManager
    {
        Button pauseButton, shopButton, startWaveButton, exitButton;
        Button archerButton, mageButton;
        Rectangle archerBTNRect, mageBTNRect;
        Rectangle pauseRect, shopRect, startWaveRect, exitRect;
        const int buttonWidth = 32;
        const int buttonDistance = 16;
        const int firstButtonX = 32;
        const int firstButtonY = 48;
        PauseMenu pauseMenu;
        EnemyManager enemyManager;
        TowerManager towerManager;
        bool displayShop = false;
        Vector2 shopPosition = new Vector2(352, 0);
        int shopButtonPadding = 100;
        
        

        public UIManager(EnemyManager enemyManager, TowerManager towerManager)
        {
            pauseMenu = new PauseMenu();
            this.towerManager = towerManager;
            this.enemyManager = enemyManager;
            exitRect = new Rectangle(firstButtonX, firstButtonY, buttonWidth, buttonWidth);
            pauseRect = new Rectangle(firstButtonX + buttonWidth + buttonDistance, firstButtonY, buttonWidth, buttonWidth);
            shopRect = new Rectangle(firstButtonX + 2 * (buttonWidth + buttonDistance), firstButtonY, buttonWidth, buttonWidth);
            startWaveRect = new Rectangle(firstButtonX + 3 * (buttonWidth + buttonDistance), firstButtonY, buttonWidth, buttonWidth);
            pauseButton = new Button(pauseRect, Pause);
            shopButton = new Button(shopRect, OpenShop);
            startWaveButton = new Button(startWaveRect, StartWave);
            exitButton = new Button(exitRect, Exit);
            archerBTNRect = new Rectangle((int)shopPosition.X + shopButtonPadding, (int)shopPosition.Y + shopButtonPadding, AssetManager.ArcherButton.Width, AssetManager.ArcherButton.Height);
            archerButton = new Button(archerBTNRect, ArcherSelected);
            mageBTNRect = new Rectangle(archerBTNRect.X + shopButtonPadding, (int)shopPosition.Y + shopButtonPadding, AssetManager.MageButton.Width, AssetManager.MageButton.Height);
            archerButton = new Button(archerBTNRect, ArcherSelected);
            mageButton = new Button(mageBTNRect, MageSelected);
        }
        public void Update()
        {
            pauseButton.Update();
            shopButton.Update();
            startWaveButton.Update();
            exitButton.Update();
            if(displayShop)
            {
                archerButton.Update();
                mageButton.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(displayShop)
            {
                spriteBatch.Draw(AssetManager.ShopMenu, shopPosition, Color.White);
                spriteBatch.Draw(AssetManager.ArcherButton, new Vector2(archerBTNRect.X, archerBTNRect.Y), Color.White);
                spriteBatch.Draw(AssetManager.MageButton, new Vector2(mageBTNRect.X, mageBTNRect.Y), Color.White);
            }
            spriteBatch.Draw(AssetManager.UIBackground, Vector2.Zero, Color.White);
        }
        void Pause()
        {
            GameManager.Instance.CurrentRuntimeState = GameManager.RuntimeState.Paused;
            pauseMenu.ShowDialog();
        }
        void StartWave()
        {
            if(enemyManager.EnemiesInCurrentWave.Count == 0)
            {
                GameManager.Instance.StartWave = true;
            }
        }
        void ArcherSelected()
        {
            towerManager.CurrentTowerSelected = TowerManager.TowerType.Archer;
        }
        void MageSelected()
        {
            towerManager.CurrentTowerSelected = TowerManager.TowerType.Mage;
        }
        void OpenShop()
        {
            displayShop = !displayShop;   
        }
        void Exit()
        {
            GameManager.Instance.Exit = true;
        }
    }
}
