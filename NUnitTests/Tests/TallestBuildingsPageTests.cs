using System;
using FluentAssertions;
using NUnit.Framework;
using NUnitTests.PageObject;

namespace NUnitTests.Tests
{
    public class TallestBuildingsPageTests : BaseTests
    {

        [Test]
        public void Verify_Buildings_Count()
        {
            string valueList = "tallest100-completed";
            int expectedBuildingCount = 100;

            var tallestBuildingsPage = new TallestBuildingsPage(driver);

            tallestBuildingsPage
                .SelectBuildingsFromTheList(valueList)
                .GetBuildingsNum()
                .Should()
                .Be(expectedBuildingCount);
        }

        [Test]
        public void Verify_LotteWorldTower_Floors_Count()
        {
            string headerColumnName = "FLOORS";
            string valueList = "tallest100-completed";
            string expLotteWorldTowerFloorsCount = "123";
            string buildingName = "Lotte World Tower";


            var tallestBuildingsPage = new TallestBuildingsPage(driver);

            tallestBuildingsPage
                .SelectBuildingsFromTheList(valueList)
                .GetInfoAboutBuilding(buildingName, headerColumnName)
                .Should()
                .Be(expLotteWorldTowerFloorsCount);
        }

        [Test]
        public void PrintOut_BuildingName_With_MaxFloors()
        {
            string valueList = "tallest100-completed";

            var tallestBuildingsPage = new TallestBuildingsPage(driver);

            var maxFloorBuildingName = tallestBuildingsPage
                .SelectBuildingsFromTheList(valueList)
                .GetMaxFloorBuildingName();

            Console.WriteLine($"Max Floors Building Name is: {maxFloorBuildingName}");
        }
    }
}
