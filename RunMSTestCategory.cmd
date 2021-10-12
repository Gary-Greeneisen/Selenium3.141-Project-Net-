@@echo off
REM filename RunMSTestCategory.cmd
Color 07

REM Set Environment Variables Used in the Batch File
Set TargetDrive=C
Set TargetDir=\Test2\Selenium3.0.1Project

Set VisualStudioVersion=14.0
Set TestRoot="C:\Test2\Selenium3.0.1Project"
set mstestPath="C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE"
set testSettingsFilename=%TestRoot%\TestSettings.testsettings
Set Env=""


REM Switch To The Target Drive Location
%TargetDrive%:

REM MD %TargetDir%
CD %TargetDir%
Echo.
echo Starting Test(s) in %TargetDrive%:%TargetDir% 

:StartTheTest
Set TIME=%TIME:~0,8%
Echo.
Echo Test Start Time: %TIME%
Echo.

REM Run Tests Using MSTest
REM Delete the previous Test Results file
if Exist %TestRoot%\TestResults\testResults.trx del %TestRoot%\TestResults\testResults.trx 
REM %mstestPath%\MSTest.exe /testcontainer:%TestRoot%\AcceptanceTests\bin\Debug\AcceptanceTests.dll /category:GoogleSearchFeature /testsettings:%testSettingsFilename% /noisolation
REM %mstestPath%\MSTest.exe /testcontainer:%TestRoot%\AcceptanceTests\bin\Debug\AcceptanceTests.dll /category:GoogleSearchFeature /testsettings:%testSettingsFilename% /resultsfile:testResults.trx
REM This did not work until I added the TestResults dir = /resultsfile:%TestRoot%\TestResults\testResults.trx
%mstestPath%\MSTest.exe /testcontainer:%TestRoot%\AcceptanceTests\bin\Debug\AcceptanceTests.dll /category:GoogleSearchFeature /testsettings:%testSettingsFilename% /resultsfile:%TestRoot%\TestResults\testResults.trx


:TestEnd
Set TIME=%TIME:~0,8%
If "%TIME:~0,1%"==" " Set TIM=0%TIME:~1,7%
Echo Test End Time: %TIME%
Echo.
:eof

REM ***************** Debug Msg *****************
REM pause
REM ***************** Debug Msg *****************
