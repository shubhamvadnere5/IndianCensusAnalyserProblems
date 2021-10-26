using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestforIndianCensus;
using System.Collections.Generic;
using System;
using IndianCensusAnalyserProblem;
using IndianCensusAnalyserProblem.DATADTO;

namespace MSTestforIndianCensus
{
    [TestClass]
    public class UnitTest1
    {
        //Initializing the path 
        //string stateCodePath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\IndiaStateCode.csv";
        string stateCensusPath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\IndiaStateData.csv";
        string wrongStateCodePath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\IndiaCode.csv";
        string wrongTypeStateCodePath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCodePath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\WrongIndiaStateCode.csv";
        string wrongHeaderStateCensusPath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCodePath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCode.csv";
        string delimiterStateCensusPath = @"C:\Users\OmSaiRam\Downloads\Practicals\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCensusData.csv";
        IndianCensusAnalyserProblem.CSVAdapterFactory csv = null;
        Dictionary<string, CensusDataDAO> stateRecords;

        [TestInitialize]
        public void SetUp()
        {
            csv = new IndianCensusAnalyserProblem.CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }
        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndianCensusAnalyserProblem.CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }

        /// TC 1.2
        /// Giving incorrect path should return file not found custom exception
        [TestMethod]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                //total no of rows excluding header are 29 in indian state census data.
                //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }

        /// TC 1.3
        /// Giving wrong type of path should return invalid file type custom exception
        [TestMethod]
        public void GivenWrongTypeReturnsCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [TestMethod]
        public void GivenWrongDelimeterReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.5
        /// Giving wrong header type should return incorrect header type custom exception
        [TestMethod]
        public void GivenWrongHeaderReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}