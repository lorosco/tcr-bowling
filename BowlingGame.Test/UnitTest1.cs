using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // initialisation de la partie avec un score à 0
        public void initScoreIsZero(){
            var game = new Partie();
            Assert.AreEqual(0, game.score);
        }

        [TestMethod]
        [Ignore]
        public void initSquareWith10Keel(){
            var game = new Partie();
            Assert.AreEqual(10,game.currentKeel);

            game.dropKeel(5);

            game.nextSquare();
            Assert.AreEqual(10,game.currentKeel);
        }

        [TestMethod]
        [Ignore]
        public void dropKeelUpdateScore(){
            // lorsque le joueur effectue un lancer et fait tomber des quilles, le score est mis à jour
            var game = new Partie();
            game.dropKeel(3);

            Assert.AreEqual(game.score,3);
        }
    }
}