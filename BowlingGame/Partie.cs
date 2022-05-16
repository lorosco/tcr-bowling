namespace BowlingGame
{
    public class Partie{
        public int score {get; private set;}

        public int currentKeel {get; private set;} = 10;
        private int currentLaunch;

        public void dropKeel(int number){
            this.score += number;
            this.currentKeel -= number;
            currentLaunch++;
            if(isAllLaunchDone() || areAllKeelsDown()){
                nextSquare();
            }
        }

        public void nextSquare(){
            this.currentKeel = 10;
        }

        private Boolean areAllKeelsDown(){
            return currentKeel == 0;
        }

        private Boolean isAllLaunchDone(){
            return currentLaunch == 2;
        }

    }
}