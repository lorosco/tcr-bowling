namespace BowlingGame
{
    public class Partie{
        public int score {get; private set;}

        public int currentSquare {get; private set;} = 1;
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
            this.currentKeel -= number;
            currentLaunch++;
            //strike sur le dernier carreau
            if(!(currentSquare == 10 && currentLaunch>1)){
                this.score += number;
            }
            if(currentSquare == 10 && !isN1LaunchStrike && currentLaunch>1 && !isNextLaunchSpare && !isN2LaunchStrike){
                this.score += number;
            }
            //Check all bonus incomming
            this.isN2LaunchStrike = isN1LaunchStrike;
            this.isN1LaunchStrike = currentLaunch == 1 && areAllKeelsDown();
            this.isNextLaunchSpare = currentLaunch == 2 && areAllKeelsDown();
            if((isAllLaunchDone() || areAllKeelsDown()) && currentSquare!=10){
                nextSquare();
            }
            if(currentSquare == 10 && currentLaunch==2 && currentKeel>0 && !isN1LaunchStrike){
                int finalScore = endGame();
                Console.Write("Your final score is:" + finalScore);
            }
            if(currentSquare == 10 && currentLaunch == 3){
                int finalScore = endGame();
                Console.Write("Your final score is:" + finalScore);
            }
        }

        public void nextSquare(){
            this.currentKeel = 10;
            if(this.currentSquare != 10){
                this.currentLaunch = 0;
                this.currentSquare +=1;
            }
        }

        private int endGame(){
            int score = this.score;
            this.currentLaunch = 0;
            this.currentSquare = 1;
            this.isN1LaunchStrike = false;
            this.isN2LaunchStrike = false;
            this.isNextLaunchSpare = false;
            this.score = 0;
            return score;
        }
        private Boolean areAllKeelsDown(){
            return currentKeel == 0;
        }

        private Boolean isAllLaunchDone(){
            return currentLaunch == 2;
        }

    }
}