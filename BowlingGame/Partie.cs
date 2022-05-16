namespace BowlingGame
{
    public class Partie{
        public int score {get; private set;}

        public int currentKeel {get; private set;} = 10;
        private int currentLaunch;
        public Boolean isNextLaunchSpare;

        //lancé n-1
        public Boolean isN1LaunchStrike;
        //lancé n-2
        public Boolean isN2LaunchStrike;

        public void dropKeel(int number){
            if(isNextLaunchSpare){
                this.score += 2*number;
            }else{
                this.score += number;
            }
            
            this.currentKeel -= number;
            currentLaunch++;
            
            if(currentLaunch == 2 && areAllKeelsDown()){
                this.isNextLaunchSpare = true;
            }
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