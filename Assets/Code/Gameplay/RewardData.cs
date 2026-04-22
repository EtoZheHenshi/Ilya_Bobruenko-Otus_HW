namespace Gameplay
{
    public static class RewardData
    {
        public static int FinalCoin => _finalCoin;
        public static int CurrentCoin => _currentCoin;
        public static int FinalTrophy => _finalTrophy;
        
        private static int _finalCoin = 0;
        private static int _currentCoin = 0;
        private static int _finalTrophy = 0;

        public static void AddCoin()
        {
            _currentCoin++;
        }

        public static void AddLevelReward()
        {
            AddCoinToReward();
            AddTrophyToReward();
        }

        public static void AddCoinToReward()
        {
            _finalCoin += _currentCoin;
            _currentCoin = 0;
        }
        
        public static void AddTrophyToReward()
        {
            _finalTrophy += LevelData.CurrentLevel;
        }
        
        public static void ResetReward()
        {
            _finalCoin = 0;
            _finalTrophy = 0;
            _currentCoin = 0;
        }
    }
}