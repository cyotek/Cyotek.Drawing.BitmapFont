@ECHO OFF

SETLOCAL

CALL ..\..\..\build\set35vars.bat

REM Build and sign the file
%msbuildexe% Cyotek.Drawing.BitmapFont.sln /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build
CALL signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\Cyotek.Drawing.BitmapFont.dll

REM Create the package
PUSHD %CD%
IF NOT EXIST releases MKDIR releases
CD releases
NUGET pack ..\src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.csproj -Prop Configuration=Release
POPD

ENDLOCAL
