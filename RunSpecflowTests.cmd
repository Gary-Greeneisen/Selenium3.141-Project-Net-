@echo off
REM filename RunSpecflowTests.cmd
REM Create a driver batch file to call the 
REM 3-batch files needed to Generate MSTests, Run MSTests, Create the RunTime Report
Color 07

:StartTheTest
Set TIME=%TIME:~0,8%
Echo.
Echo Test Start Time: %TIME%
Echo.

Call GenerateMSTests.cmd
Call RunMSTestCategory.cmd
Call CreateRunTimeReport.cmd


:TestEnd
Set TIME=%TIME:~0,8%
If "%TIME:~0,1%"==" " Set TIM=0%TIME:~1,7%
Echo Test End Time: %TIME%
Echo.
:eof

REM ***************** Debug Msg *****************
REM pause
REM ***************** Debug Msg *****************

