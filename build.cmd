@ECHO OFF

SETLOCAL

CALL ..\..\..\build\set35vars.bat

REM Build and sign the file
%msbuildexe% Cyotek.Drawing.BitmapFont.sln /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build
CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\Cyotek.Drawing.BitmapFont.dll

REM Create the package
PUSHD %CD%
IF NOT EXIST releases MKDIR releases
CD releases
%NUGETexe% pack ..\src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.csproj -Prop Configuration=Release
%zipexe% a -bd -tZip Cyotek.Drawing.BitmapFont.x.x.x.x.zip ..\src\Cyotek.Drawing.BitmapFont\bin\Release\Cyotek.Drawing.BitmapFont.dll
POPD

ENDLOCAL
