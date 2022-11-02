using FluentAssertions;
using NUnit.Framework;
using NUnitTests.PageObject;
using System;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class TallestBuildingsPageTests : BaseTests
    {
        private string _valueList;
        private TallestBuildingsPage _tallestBuildingsPage;


        [SetUp]
        public void SetUp()
        {
            _valueList = "tallest100-completed";
            _tallestBuildingsPage = new TallestBuildingsPage(driver);
            _tallestBuildingsPage.GoToTallestBuildingsPage();
        }


        [Test]
        public void Verify_Buildings_Count()
        {
            int expectedBuildingCount = 100;

            _tallestBuildingsPage
                .SelectBuildingsFromTheList(_valueList)
                .GetBuildingsNum()
                .Should()
                .Be(expectedBuildingCount);
        }

        [Test]
        public void Verify_LotteWorldTower_Floors_Count()
        {
            string headerColumnName = "FLOORS";
            string expLotteWorldTowerFloorsCount = "123";
            string buildingName = "Lotte World Tower";

            _tallestBuildingsPage
                .SelectBuildingsFromTheList(_valueList)
                .GetInfoAboutBuilding(buildingName, headerColumnName)
                .Should()
                .Be(expLotteWorldTowerFloorsCount);
        }

        [Test]
        public void PrintOut_BuildingName_With_MaxFloors()
        {
            var maxFloorBuildingName = _tallestBuildingsPage
                .SelectBuildingsFromTheList(_valueList)
                .GetMaxFloorBuildingName();

            Console.WriteLine($"Max Floors Building Name is: {maxFloorBuildingName}");
        }
    }
}