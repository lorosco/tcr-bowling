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
            Assert.AreEqual(0, game.score());
        }

        public void test2(){
            
        }
    }
}