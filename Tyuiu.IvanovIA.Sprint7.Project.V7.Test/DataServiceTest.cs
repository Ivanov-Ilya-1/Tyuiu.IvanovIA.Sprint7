using System;
using System.Collections.Generic;
using Xunit;
using Tyuiu.IvanovIA.Sprint7.Project.V7.Lib;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7.Test
{
    public class DataServiceTest_IvanovIA
    {
        [Fact]
        public void TestLoadFromCSV_IvanovIA()
        {
            DataService_IvanovIA ds = new DataService_IvanovIA();

            string testPath = "test_apartments_IvanovIA.csv";
            CreateTestCSVFile_IvanovIA(testPath);

            var result = ds.LoadFromCSV_IvanovIA(testPath);

            Assert.Equal(5, result.Count);
            Assert.Equal("Иванов", result[0].TenantLastName);
        }

        [Fact]
        public void TestSearchByLastName_IvanovIA()
        {
            DataService_IvanovIA ds = new DataService_IvanovIA();

            List<ApartmentModel_IvanovIA> testData = new List<ApartmentModel_IvanovIA>
            {
                new ApartmentModel_IvanovIA { TenantLastName = "Иванов" },
                new ApartmentModel_IvanovIA { TenantLastName = "Петров" },
                new ApartmentModel_IvanovIA { TenantLastName = "Сидоров" }
            };

            var result = ds.SearchByLastName_IvanovIA(testData, "Иванов");

            Assert.Single(result);
        }

        [Fact]
        public void TestCountApartments_IvanovIA()
        {
            DataService_IvanovIA ds = new DataService_IvanovIA();

            List<ApartmentModel_IvanovIA> testData = new List<ApartmentModel_IvanovIA>
            {
                new ApartmentModel_IvanovIA(),
                new ApartmentModel_IvanovIA(),
                new ApartmentModel_IvanovIA()
            };

            int result = ds.CountApartments_IvanovIA(testData);

            Assert.Equal(3, result);
        }

        [Fact]
        public void TestSumTotalArea_IvanovIA()
        {
            DataService_IvanovIA ds = new DataService_IvanovIA();

            List<ApartmentModel_IvanovIA> testData = new List<ApartmentModel_IvanovIA>
            {
                new ApartmentModel_IvanovIA { TotalArea = 50.5m },
                new ApartmentModel_IvanovIA { TotalArea = 65.0m },
                new ApartmentModel_IvanovIA { TotalArea = 42.0m }
            };

            decimal result = ds.SumTotalArea_IvanovIA(testData);

            Assert.Equal(157.5m, result);
        }

        [Fact]
        public void TestAverageTotalArea_IvanovIA()
        {
            DataService_IvanovIA ds = new DataService_IvanovIA();

            List<ApartmentModel_IvanovIA> testData = new List<ApartmentModel_IvanovIA>
            {
                new ApartmentModel_IvanovIA { TotalArea = 50.0m },
                new ApartmentModel_IvanovIA { TotalArea = 60.0m },
                new ApartmentModel_IvanovIA { TotalArea = 70.0m }
            };

            decimal result = ds.AverageTotalArea_IvanovIA(testData);

            Assert.Equal(60.0m, result);
        }

        private void CreateTestCSVFile_IvanovIA(string path)
        {
            System.IO.File.WriteAllText(path,
                "EntranceNumber,ApartmentNumber,TotalArea,LivingArea,RoomsCount,TenantLastName,RegistrationDate,FamilyMembers,ChildrenCount,HasDebt,Notes\n" +
                "1,1,50.5,35.0,2,Иванов,2020-01-15,3,1,False,Без замечаний\n" +
                "1,2,65.0,45.5,3,Петров,2019-05-20,4,2,True,Есть долг\n" +
                "2,3,42.0,30.0,1,Сидоров,2021-03-10,2,0,False,Пенсионер\n" +
                "2,4,75.0,55.0,3,Смирнов,2018-11-05,5,3,False,Многодетная\n" +
                "3,5,55.5,40.0,2,Кузнецов,2020-07-30,3,1,True,Долг есть\n");
        }
    }
}