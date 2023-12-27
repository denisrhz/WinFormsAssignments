@echo off
chcp 1252 > nul
setlocal enabledelayedexpansion

set "str=%~1"

set /a strlen=0
call :strLen str strlen

echo String length: %strlen%

set "converted="
set /a total

set /a idx=0
for %%c in ("ö=ouml" "ä=auml") do (
  set "convert[!idx!]=%%c"
  set /a idx+=1
)
set /a idx-=1

for /L %%i in (0,1,%strlen%) do (
  set "char=!str:~%%i,1!"
  set "found=0"
  for /L %%j in (0,1,%idx%) do (
    for /f "tokens=1,2 delims==" %%a in ("!convert[%%j]!") do (
      echo "!char!" == "%%a"
      if "!char!" == "%%a" (
        set "converted=!converted!&%%b;"
        set /a total+=1
        set "found=1"
        goto charProcessed
      )
    )
  )
  :charProcessed
  if !found! equ 0 set "converted=!converted!!char!"
)

echo Result: %converted%

if %total% gtr 0 (
 echo Replaced count: %total%
) else (
 echo Nothing was replaced
)

pause
exit /b

:strlen
setlocal
set "s=!%1!"
set len=0
:strLenLoop
if not "!s:~%len%!"=="" (
  set /a len+=1
  goto :strLenLoop
)
endlocal & set %2=%len%
goto :eof