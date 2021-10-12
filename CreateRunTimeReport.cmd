@@echo off
REM filename CreateRunTimeReport.cmd
Color 07

REM Set Environment Variables Used in the Batch File
Set TargetDrive=C
Set TargetDir=\Test2\Selenium3.0.1Project

Set VisualStudioVersion=14.0
Set TestRoot="C:\Test2\Selenium3.0.1Project"
set SpecflowPath=%TestRoot%\packages\SpecFlow.2.1.0\tools
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

REM usage: specflow mstestexecutionreport projectFile 
REM [/testResult:value] 
REM [/xsltFile:value] 
REM [/out:value]
REM Create the RunTime Report based on previous test results
%SpecflowPath%\SpecFlow.exe mstestexecutionreport %TestRoot%\AcceptanceTests\AcceptanceTests.csproj /testResult:%TestRoot%\TestResults\TestResults.trx

Echo Created TestResult.html
Echo.

:TestEnd
Set TIME=%TIME:~0,8%
If "%TIME:~0,1%"==" " Set TIM=0%TIME:~1,7%
Echo Test End Time: %TIME%
Echo.
:eof

REM ***************** Debug Msg *****************
REM pause
REM ***************** Debug Msg *****************
