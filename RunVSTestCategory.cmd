@@echo off
REM filename RunVSTestCategory.cmd
Color 07

REM Set Environment Variables Used in the Batch File
Set TargetDrive=C
Set TargetDir=\Test2\Selenium3.0.1Project

Set VisualStudioVersion=14.0
Set TestRoot="C:\Test2\Selenium3.0.1Project"
set vstestPath="C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow"
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

REM Run Test Using VSTest
%vstestPath%\vstest.console.exe %TestRoot%\AcceptanceTests\bin\Debug\AcceptanceTests.dll /TestCaseFilter:"TestCategory=GoogleSearchFeature" /Settings:%testSettingsFilename% /Logger:trx /InIsolation


:TestEnd
Set TIME=%TIME:~0,8%
If "%TIME:~0,1%"==" " Set TIM=0%TIME:~1,7%
Echo Test End Time: %TIME%
Echo.
:eof

REM ***************** Debug Msg *****************
REM pause
REM ***************** Debug Msg *****************
