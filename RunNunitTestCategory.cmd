@@echo off
REM filename RunNunitTestCategory.cmd
Color 07

REM Set Environment Variables Used in the Batch File
Set TargetDrive=C
Set TargetDir=\Test2\Selenium3.0.1Project

Set VisualStudioVersion=14.0
Set TestRoot="C:\Test2\Selenium3.0.1Project"
set nunitPath="C:\Program Files (x86)\NUnit 2.6.4\bin"
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

REM Run Test Using Nunit
%nunitPath%\nunit.exe %TestRoot%\AcceptanceTests\bin\Debug\AcceptanceTests.dll /include:GoogleSearchFeature


:TestEnd
Set TIME=%TIME:~0,8%
If "%TIME:~0,1%"==" " Set TIM=0%TIME:~1,7%
Echo Test End Time: %TIME%
Echo.
:eof

REM ***************** Debug Msg *****************
REM pause
REM ***************** Debug Msg *****************
