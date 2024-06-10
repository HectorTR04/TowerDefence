namespace TowerDefence.Managers
{
    internal sealed class GameManager
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public enum Scene { MainMenu, Gameplay, Lose }
        public Scene CurrentScene { get; set; }
        public enum RuntimeState { Playing, Paused }
        public RuntimeState CurrentRuntimeState { get; set; }
        public bool Exit { get; set; } = false;
        public int PlayerLives = 3;
        public int PlayerMoney = 1000;
        public bool StartWave { get; set; } = false;
        

    }
}
