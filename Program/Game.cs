namespace lr2{
    
    /*  
        winnerName – імя переможця
        looserName – ім'я програвшого
        rating – рейтинг на який грали
        index  – індекс гри
    */ 
    public abstract class Game
    {
        public string winnerName;
        public string looserName;

        public int rating;
        public int index;

        public Game(string winnerName, string looserName, int index){
            this.winnerName = winnerName;
            this.looserName = looserName;
            this.index = index;
        }
    }
    class StandartGame: Game{
        public StandartGame(string winnerName, string looserName, int index)
        :base(winnerName,looserName,index){
            base.rating  = 2;
        }
    }
    class TrainingGame: Game{
        public TrainingGame(string winnerName, string looserName, int index)
        :base(winnerName,looserName,index){
            base.rating  = 0;
        }
    }
    class SingleGame: Game{
        public SingleGame(string winnerName, string looserName, int index)
        :base(winnerName, looserName,index){
            base.rating  = 2;
            base.looserName= "IA";
        }
    }
}

