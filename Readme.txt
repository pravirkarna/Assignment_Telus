Prerequisites :

1) Install Visual studio 2019 or Later
2) Open VS Go to Extension -> Click on Manage Extension --> Install Specflow 


Step 1 - Clone the project using git clone main https://github.com/pravirkarna/DotNetCore.git

step 2 - Open project go to DotNetCore and launch DotNetCore.sln

step 3 - Go to Solution Explorer --> Expand Automation.UI.Tests --> Expand Dependencies --> Go to Project
         Right click and add project reference
         Add Automation.UI.Accelerators and Automation.Reporting project referrence

Step 4 - Clean the project

step 5 - Build the project

Step 6 - Go to Test --> Test Explorer 
         You would see all 3 tests are listed there , Right click on it and click on Run

Note : I am using NunitTest3Adapter for running the tests , Once the build is successfull it would automatically get downloaded no need to install it explicitly.

***********************************************************
