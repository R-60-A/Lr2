namespace lr2
{

    class Program
    {

        public static void playGame(GameAccount user1,GameAccount user2,Game gameType, int index){
            if(gameType.rating>=0){

                gameType.index = index;
                
                Random rnd = new Random();
                int value1 = rnd.Next(0, 10);

                if(gameType.looserName != "IA"){

                    if(value1<5){
                        user1.WinGame(user2.UserName,gameType);
                        user2.LoseGame(user1.UserName,gameType);
                    }
                    else{
                        user2.WinGame(user1.UserName,gameType);
                        user1.LoseGame(user2.UserName,gameType);
                    }
                }
                else{

                    if(value1<5){
                        user1.WinGame("IA",gameType);
                    }
                    else{
                        user1.LoseGame("IA",gameType);
                    }
                }
                
            }
            else{
                 Console.WriteLine("Error: negative rating!");
            }
        }

        public static void Main(string[] args)
        {
            /* creating a database of accounts */
            lr2.AccountTypes accountTypes = new lr2.AccountTypes();
            List<GameAccount> AT = new List<GameAccount>{
                accountTypes.GetBasicAcc("Ivan"),
                accountTypes.GetLessAcc("Misha"),
                accountTypes.GetSeriaAcc("Stepan"),
                //accountTypes.GetBasicAcc("Anton"),
            };
            
            /* everyone plays with everyone(only one time)*/
            int i=0;
            foreach(GameAccount gameAccount1 in AT){
                foreach(GameAccount gameAccount2 in AT){

                    GameTypes gameTypes = new GameTypes();
                    var GT = new List<Game>{
                        gameTypes.GetStandartGame(gameAccount1.UserName,gameAccount2.UserName, 0),
                        gameTypes.GetTrainingGame(gameAccount1.UserName,gameAccount2.UserName, 0),
                        gameTypes.GetSingleGame(gameAccount1.UserName,gameAccount2.UserName, 0),
                    };

                    foreach(Game game in GT){
                        if((AT.IndexOf(gameAccount2)<AT.IndexOf(gameAccount1)) && game.looserName =="IA"){
                            playGame(gameAccount1,gameAccount2, game,i);
                            i++;
                        }
                        else if(AT.IndexOf(gameAccount2)>AT.IndexOf(gameAccount1)){
                            playGame(gameAccount1,gameAccount2, game,i);
                            i++;
                        }
                    }
                }
            }
            
            /* output statisitcs */ 
            foreach(GameAccount gameAccount in AT){
                gameAccount.GetStats();
                Console.WriteLine("\n\n\n");
            }


            
        }
    }
}