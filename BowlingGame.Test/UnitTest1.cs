using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // initialisation de la partie avec un score à 0
        public void initScoreIsZero()
        {
            var game = new Partie();
            Assert.AreEqual(0, game.score);
        }

        [TestMethod]
        public void initSquareWith10Keel()
        {
            var game = new Partie();
            Assert.AreEqual(10, game.currentKeel);

            game.dropKeel(5);

            game.nextSquare();
            Assert.AreEqual(10, game.currentKeel);
        }

        [TestMethod]
        public void dropKeelUpdateScore()
        {
            // lorsque le joueur effectue un lancer et fait tomber des quilles, le score est mis à jour
            var game = new Partie();
            game.dropKeel(3);

            Assert.AreEqual(game.score, 3);
        }

        [TestMethod]
        public void isSquareResetWhenAllKeelsDown()
        {
            Partie game = new Partie();
            game.dropKeel(10);

            Assert.AreEqual(game.currentKeel, 10);
        }

        [TestMethod]
        public void isSquareResetWhenAllLaunchDone()
        {
            Partie game = new Partie();
            game.dropKeel(2);

            game.dropKeel(3);

            Assert.AreEqual(game.currentKeel, 10);
        }

        [TestMethod]
        public void isSpareCounted()
        {
            Partie partie = new Partie();

            partie.dropKeel(7);
            partie.dropKeel(3);

            Assert.AreEqual(partie.isNextLaunchSpare, true);

            partie.dropKeel(5);

            Assert.AreEqual(partie.score, 20);
        }

        [TestMethod]
        public void isStrikeCounted()
        {
            Partie partie = new Partie();

            partie.dropKeel(10);

            Assert.AreEqual(partie.isN1LaunchStrike, true);

            partie.dropKeel(10);

            Assert.AreEqual(partie.score, 30);

            Assert.AreEqual(partie.isN2LaunchStrike && partie.isN1LaunchStrike, true);

            partie.dropKeel(3);

            Assert.AreEqual(partie.score, 39);

            partie.dropKeel(3);

            Assert.AreEqual(partie.score, 45);

            Assert.AreEqual(partie.isN1LaunchStrike && partie.isN2LaunchStrike, false);
        }

        [TestMethod]
        public void isLastSquareCanBe3ShootOr2()
        {
            Partie partieStrike = new Partie();
            for (int i = 0; i < 9; i++)
            {
                partieStrike.dropKeel(5);
                partieStrike.dropKeel(3);
                Assert.AreEqual(partieStrike.score, 8 * (i + 1));
            }
            partieStrike.dropKeel(10);
            Assert.AreEqual(partieStrike.score, 82);
            Assert.AreEqual(partieStrike.currentSquare, 10);
            partieStrike.dropKeel(10);
            Assert.AreEqual(partieStrike.score, 92);
            partieStrike.dropKeel(10);
            //le score final est affiché dans la console, une fois celui-ci affiché, la partie se réinitialise
            //Assert.AreEqual(partieStrike.score,102);
        }

        [TestMethod]
        public void isLastSquareCanBe3ShootWithSpare()
        {
            Partie partieSpare = new Partie();
            for (int i = 0; i < 9; i++)
            {
                partieSpare.dropKeel(5);
                partieSpare.dropKeel(3);
                Assert.AreEqual(partieSpare.score, 8 * (i + 1));
            }
            partieSpare.dropKeel(5);
            partieSpare.dropKeel(5);
            Assert.AreEqual(partieSpare.score, 82);
            Assert.AreEqual(partieSpare.currentSquare, 10);
            partieSpare.dropKeel(5);
            //le score final est affiché dans la console, une fois celui-ci affiché, la partie se réinitialise
            //Assert.AreEqual(partieSpare.score, 87);
        }

        [TestMethod]
        public void isLastSquareCanBe2Shoot()
        {
            Partie partieSpare = new Partie();
            for (int i = 0; i < 9; i++)
            {
                partieSpare.dropKeel(5);
                partieSpare.dropKeel(3);
                Assert.AreEqual(partieSpare.score, 8 * (i + 1));
            }
            partieSpare.dropKeel(5);
            Assert.AreEqual(partieSpare.score, 77);
            partieSpare.dropKeel(2);
            //le score final est affiché dans la console, une fois celui-ci affiché, la partie se réinitialise
            //Assert.AreEqual(partieSpare.score,79);
            Assert.AreEqual(partieSpare.currentSquare, 1);
            partieSpare.dropKeel(5);
            Assert.AreEqual(partieSpare.score, 5);
        }
    }
}