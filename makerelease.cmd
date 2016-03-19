@ECHO OFF

SETLOCAL

CALL ..\..\..\build\set35vars.bat

%msbuildexe% Cyotek.Drawing.BitmapFont.sln /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build
CALL signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\Cyotek.Drawing.BitmapFont.dll

PUSHD
CD releases
NUGET pack ..\src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.csproj -Prop Configuration=Release

%zipexe% a -bd -tZip Cyotek.Drawing.BitmapFont.x.x.x.x.zip ..\src\Cyotek.Drawing.BitmapFont\bin\Release\Cyotek.Drawing.BitmapFont.dll

POPD

ENDLOCAL
