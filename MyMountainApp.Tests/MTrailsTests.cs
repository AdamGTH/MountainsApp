
namespace MyMountainApp.Tests
{
    public class Tests
    {
        [Test]
        public void TestMethodDifficultyLevelAndSumValuesFromStatistics()
        {
            //arrange
            MTrailsInMemory Trails = new MTrailsInMemory();
            Statistics statistics = new Statistics();
            //act
            Trails.DifficultyLevel(4.5);
            Trails.DifficultyLevel(5);
            Trails.DifficultyLevel(2.2);
            statistics = Trails.GetStatistics();

            //assert
            Assert.AreEqual(11.7f, statistics.Sum);

        }

        [Test]
        public void TestMethodDifficultyLevelAndAverageValuesFromStatistics()
        {
            //arrange
            MTrailsInMemory Trails = new MTrailsInMemory();
            Statistics statistics = new Statistics();
            //act
            Trails.DifficultyLevel(4.5);
            Trails.DifficultyLevel(5);
            Trails.DifficultyLevel(2.2);
            statistics = Trails.GetStatistics();

            //assert
            Assert.AreEqual(3.9, Math.Round(statistics.Average, 1));

        }
        [Test]
        public void TestMethodDifficultyLevelAndAverageStringValuesFromStatistics()
        {
            //arrange
            MTrailsInMemory Trails = new MTrailsInMemory();
            Statistics statistics = new Statistics();
            //act
            Trails.DifficultyLevel(1);
            Trails.DifficultyLevel(0.1);
            Trails.DifficultyLevel(0.5);
            statistics = Trails.GetStatistics();

            //assert
            Assert.AreEqual("Very Light", statistics.AverageString) ;

        }
    }
}