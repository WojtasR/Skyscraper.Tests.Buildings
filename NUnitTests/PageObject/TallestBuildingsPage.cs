using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTests.PageObject
{
    public class TallestBuildingsPage
    {
        private IWebDriver _driver;

        public TallestBuildingsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private string _url = "https://www.skyscrapercenter.com/buildings?list=tallest100-construction";
        private IWebElement SelectionList => _driver.FindElement(By.Name("list"));
        private IWebElement BuildingsWebTableBody => _driver.FindElement(By.CssSelector("table>tbody"));
        private IWebElement BuildingsWebTableHeader => _driver.FindElement(By.CssSelector("table>thead>tr"));

        public TallestBuildingsPage GoToTallestBuildingsPage()
        {
            _driver.Navigate().GoToUrl(_url);

            return this;
        }

        public TallestBuildingsPage SelectBuildingsFromTheList(string listValue)
        {
            SelectElement select = new SelectElement(SelectionList);
            select.SelectByValue(listValue);

            return this;
        }

        public int GetBuildingsNum()
        {
            var buildingsRecordsList = new List<IWebElement>(BuildingsWebTableBody.FindElements(By.TagName("tr")));

            return buildingsRecordsList.Count;
        }

        public string GetInfoAboutBuilding(string buildingName, string headerColumnName)
        {
            var rowIndex = GetRowIndexByBuildingName(buildingName) + 1;
            var columnIndex = GetColumnIndexByName(headerColumnName) + 1;

            var buildingInfo = BuildingsWebTableBody.FindElement(By.XPath($"//tr[{rowIndex}]/td[{columnIndex}]/p")).Text;

            return buildingInfo;
        }

        public string GetMaxFloorBuildingName()
        {
            string headerColumnName = "NAME";

            var maxFloor = GetMaxFloor();
            var bodyRowIndexMaxFloor = GetRowIndexByFloors(maxFloor) + 1;
            var columnIndex = GetColumnIndexByName(headerColumnName) + 1;

            var buildingaNem = BuildingsWebTableBody.FindElement(By.XPath($"//tr[{bodyRowIndexMaxFloor}]/td[{columnIndex}]/p")).Text;

            return buildingaNem;
        }

        private int GetColumnIndexByName(string headerColumnName)
        {
            var buildingsWebTblHeaderColumnsList = new List<IWebElement>(BuildingsWebTableHeader.FindElements(By.TagName("th")));

            var headerColumnIndex = buildingsWebTblHeaderColumnsList
                .FindIndex(c => c.FindElement(By.CssSelector("th>div>p")).Text == headerColumnName);

            return headerColumnIndex;
        }

        private int GetRowIndexByBuildingName(string buildingName)
        {
            var buildingsRecordsList = new List<IWebElement>(BuildingsWebTableBody.FindElements(By.TagName("tr")));

            var bodyRowIndex = buildingsRecordsList
                .FindIndex(r => r.FindElement(By.CssSelector("tr>td>p>a")).Text == buildingName);

            return bodyRowIndex;
        }

        private string GetMaxFloor()
        {
            string headerColumnName = "FLOORS";
            List<int> floorsList = new List<int>();

            var columnIndex = GetColumnIndexByName(headerColumnName) + 1;

            var floors = BuildingsWebTableBody.FindElements(By.XPath($"//tr/td[{columnIndex}]/p"));

            foreach (var floorStr in floors)
            {
                int floorInt = int.TryParse(floorStr.Text, out floorInt) ? floorInt : 0;
                floorsList.Add(floorInt);
            }

            return floorsList.OrderByDescending(x => x).First().ToString();
        }

        private int GetRowIndexByFloors(string floors)
        {
            string headerColumnName = "FLOORS";
            var columnIndex = GetColumnIndexByName(headerColumnName) + 1;

            var buildingsRecordsList = new List<IWebElement>(BuildingsWebTableBody.FindElements(By.TagName("tr")));

            var bodyRowIndex = buildingsRecordsList
                .FindIndex(r => r.FindElement(By.XPath($"//tr/td[{columnIndex}]/p")).Text == floors);

            return bodyRowIndex;
        }
    }
}
