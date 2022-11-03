namespace lr2{
   
    abstract public class GameAccount
    {
        
        public string UserName;
        public int CurrentRating;
        public int GamesCount;
        public List<Game> stats = new List<Game>();

        public GameAccount(string UserName){
            this.UserName = UserName;
            this.CurrentRating = 10;
            this.GamesCount = 0;
        }

        public abstract void WinGame(string opponentName, Game gameType);
        public abstract void LoseGame(string opponentName, Game gameType);
        
        public void GetStats(){
            string sign;
            for (int i = 0; i < this.stats.Count; i++){
                if(this.UserName == stats[i].winnerName)sign ="+";
                else sign ="-";

                Console.WriteLine("\nUSERNAME - " + this.UserName+"; Current rating: "+this.CurrentRating);
                Console.WriteLine("Game "+(stats[i].index)+"(rating "+sign+stats[i].rating+"):");
                Console.WriteLine("Win - "+stats[i].winnerName+"; Lose - "+stats[i].looserName);
            }
        }
    }

    class BasicGameAccount : GameAccount{

        public BasicGameAccount(string UserName): base(UserName){

        }

        public override void WinGame(string opponentName, Game gameType){
            this.CurrentRating+=gameType.rating;
            this.GamesCount++;
            
            gameType.winnerName = this.UserName;
            gameType.looserName = opponentName;

            stats.Add(gameType);
        }

        public override void LoseGame(string opponentName,Game gameType){
            if(this.CurrentRating>gameType.rating){
                this.CurrentRating-=gameType.rating;
            }
            else{
                this.CurrentRating = 1;
            }
            this.GamesCount++;
            
            gameType.winnerName = opponentName;
            gameType.looserName = this.UserName;

            stats.Add(gameType);
        }
        
    }

    class LessGameAccount : GameAccount{

        public LessGameAccount(string UserName): base(UserName){

        }

        public override void WinGame(string opponentName, Game gameType){
            this.CurrentRating+=gameType.rating;
            this.GamesCount++;
            
            gameType.winnerName = this.UserName;
            gameType.looserName = opponentName;

            stats.Add(gameType);
        }

        public override void LoseGame(string opponentName,Game gameType){
            if(this.CurrentRating>gameType.rating){
                this.CurrentRating-=(gameType.rating/2);
            }
            else{
                this.CurrentRating = 1;
            }
            this.GamesCount++;
            
            gameType.winnerName = opponentName;
            gameType.looserName = this.UserName;

            stats.Add(gameType);
        }
        
    }
    
    class SeriaGameAccount : GameAccount{

        private int seria;
        private int addPoints;


        public SeriaGameAccount(string UserName): base(UserName){
            this.seria=0;
            this.addPoints = 1;
        }

        public override void WinGame(string opponentName, Game gameType){
            this.seria++;

            if(this.seria >= 2){
                this.CurrentRating+=this.addPoints;
            }

            this.CurrentRating+=gameType.rating;
            this.GamesCount++;
            
            gameType.winnerName = this.UserName;
            gameType.looserName = opponentName;

            stats.Add(gameType);
            
        }

        public override void LoseGame(string opponentName,Game gameType){
            if(this.CurrentRating>gameType.rating){
                this.CurrentRating-=(gameType.rating);
            }
            else{
                this.CurrentRating = 1;
            }
            this.GamesCount++;

            this.seria=0;
            
            gameType.winnerName = opponentName;
            gameType.looserName = this.UserName;

            stats.Add(gameType);
        }
        
    }


}
