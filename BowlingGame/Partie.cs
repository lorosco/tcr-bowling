namespace BowlingGame
{
    public class Partie{
        public int score {get; private set;}

        public int currentKeel {get; private set;} = 10;
        private int currentLaunch;
        public Boolean isNextLaunchSpare;

        //lancé n-1
        public Boolean isN1LaunchStrike = false;
        //lancé n-2
        public Boolean isN2LaunchStrike = false;

        public void dropKeel(int number){
            if(isNextLaunchSpare){
                this.score += number;
            }
            if(isN1LaunchStrike){
                this.score += number;
            }
            if(isN2LaunchStrike){
                this.score += number;
            }
            this.score += number;
            this.currentKeel -= number;
            currentLaunch++;
            //Check all bonus incomming
            this.isN2LaunchStrike = isN1LaunchStrike;
            this.isN1LaunchStrike = currentLaunch == 1 && areAllKeelsDown();
            this.isNextLaunchSpare = currentLaunch == 2 && areAllKeelsDown();
            if(isAllLaunchDone() || areAllKeelsDown()){
                nextSquare();
            }
        }

        public void nextSquare(){
            this.currentKeel = 10;
            this.currentLaunch = 0;
        }

        private Boolean areAllKeelsDown(){
            return currentKeel == 0;
        }

        private Boolean isAllLaunchDone(){
            return currentLaunch == 2;
        }

    }
}