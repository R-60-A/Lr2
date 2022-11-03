namespace lr2
{

    class AccountTypes
    {
        public GameAccount GetBasicAcc(string UserName){
            return new BasicGameAccount(UserName) ;
        }

        public GameAccount GetLessAcc(string UserName){
            return new LessGameAccount(UserName) ;
        }

        public GameAccount GetSeriaAcc(string UserName){
            return new SeriaGameAccount(UserName) ;
        }
    }

}


