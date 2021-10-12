filename - ReadMePackages.txt

Note:
Since the Selenium web drivers are linked to the target browser release#
and the Nuget package manager installs the Solution packages to the package directory

  The namespace AcceptanceTests.PageObjects Login class and the 
  namespace AcceptanceTests.Features.NUnit_Tests TestDrivers class using the flowing code to 
  locate the Selenium web Driver location
  var runDir = Libary.GetProjectDir();
  var driverDir = runDir + @"\packages\";

You must copy the current packages dir files from the source directory (packages)
to the Solution target directory (packages)

