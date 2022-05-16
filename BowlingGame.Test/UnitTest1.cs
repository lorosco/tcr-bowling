using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // initialisation de la partie avec un score à 0
            var game = new Partie();
            Assert.AreEqual(0, game.score);
        }
    }
}