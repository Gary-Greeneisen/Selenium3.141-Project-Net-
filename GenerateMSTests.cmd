@@echo off
REM filename GenerateMSTests.cmd
REM Generate MsTest's from your .feature-file
Color 07

REM Set Environment Variables Used in the Batch File
Set TargetDrive=C
Set TargetDir=\Test2\Selenium3.0.1Project

Set TestRoot="C:\Test2\Selenium3.0.1Project"
set SpecflowPath=%TestRoot%\packages\SpecFlow.2.1.0\tools

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

REM Generate MsTest's from your .feature-file
REM Generate tests from all feature files in a project
REM usage: specflow generateall projectFile [/force] [/verbose]
REM projectFile  Visual Studio Project File containing features
%SpecflowPath%\SpecFlow.exe generateAll %TestRoot%\AcceptanceTests\AcceptanceTests.csproj /force /verbose

:TestEnd
Set TIME=%TIME:~0,8%
If "%TIME:~0,1%"==" " Set TIM=0%TIME:~1,7%
Echo Test End Time: %TIME%
Echo.
:eof

REM ***************** Debug Msg *****************
REM pause
REM ***************** Debug Msg *****************
