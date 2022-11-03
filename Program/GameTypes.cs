namespace lr2{

    public class GameTypes
    {
        public Game GetStandartGame(string winnerName, string looserName,int index){
            return new StandartGame(winnerName, looserName,index);
        }
        public Game GetTrainingGame(string winnerName, string looserName,int index){
            return new TrainingGame(winnerName, looserName,index);
        }
        public Game GetSingleGame(string winnerName, string looserName,int index){
            return new SingleGame(winnerName, looserName,index);
        }


    }

}


