using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestforIndianCensus
{
    [TestClass]
    public class UnitTest1Base
    {
        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndianCensusAnalyserProblem.CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
    }
}