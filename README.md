# Skyscraper.Tests.Buildings
Write an automated test in C# based on the NUnit framework using Selenium doing the following:

1. Open Chrome browser and maximise the window.

2. Go to URL : https://www.skyscrapercenter.com/buildings?list=tallest100-construction

3. Select in the dropdown list the value : “100 Tallest Completed Buildings in the World”
4. Consider the web table as a dynamic table meaning the number of rows and columns can change. In this web table assert the following:

- Verify there are exactly 100 buildings in the list

- Verify that the "Lotte World Tower" building in Seoul has exactly 123 floors

- Give us the building with the maximum number of floors in that list
