
namespace MyMountainApp.Tests
{
    public class Tests
    {
        [Test]
        public void TestMethodDifficultyLevelAndSumValuesFromStatistics()
        {
            //arrange
            MTrailsInMemory trails = new MTrailsInMemory();
            Statistics statistics = new Statistics();
            //act
            trails.DifficultyLevel(4.5);
            trails.DifficultyLevel(5);
            trails.DifficultyLevel(2.2);
            statistics = trails.GetStatistics();

            //assert
            Assert.AreEqual(11.7f, statistics.Sum);

        }

        [Test]
        public void TestMethodDifficultyLevelAndAverageValuesFromStatistics()
        {
            //arrange
            MTrailsInMemory trails = new MTrailsInMemory();
            Statistics statistics = new Statistics();
            //act
            trails.DifficultyLevel(4.5);
            trails.DifficultyLevel(5);
            trails.DifficultyLevel(2.2);
            statistics = Trails.GetStatistics();

            //assert
            Assert.AreEqual(3.9, Math.Round(statistics.Average, 1));

        }
        [Test]
        public void TestMethodDifficultyLevelAndAverageStringValuesFromStatistics()
        {
            //arrange
            MTrailsInMemory trails = new MTrailsInMemory();
            Statistics statistics = new Statistics();
            //act
            trails.DifficultyLevel(1);
            trails.DifficultyLevel(0.1);
            trails.DifficultyLevel(0.5);
            statistics = Trails.GetStatistics();

            //assert
            Assert.AreEqual("Very Light", statistics.AverageString) ;

        }
    }
}