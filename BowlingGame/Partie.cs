namespace BowlingGame
{
    public class Partie{
        public int score {get; private set;}

        public int currentKeel {get; private set;} = 10;

        public void dropKeel(int number){
            this.score += number;
            this.currentKeel -= number;
        }

        public void nextSquare(){
            this.currentKeel = 10;
        }

    }
}