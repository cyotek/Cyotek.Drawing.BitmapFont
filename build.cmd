@ECHO OFF

SETLOCAL

CALL ..\..\..\build\set35vars.bat

%msbuild15exe% Cyotek.Drawing.BitmapFont.sln /p:Configuration=Release /verbosity:minimal /nologo /m /t:Clean,Build
CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\net20\Cyotek.Drawing.BitmapFont.dll
CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\net35\Cyotek.Drawing.BitmapFont.dll
CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\net40\Cyotek.Drawing.BitmapFont.dll
CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\net45\Cyotek.Drawing.BitmapFont.dll
CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\net46\Cyotek.Drawing.BitmapFont.dll
CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\net47\Cyotek.Drawing.BitmapFont.dll
CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\netstandard1.3\Cyotek.Drawing.BitmapFont.dll

IF NOT EXIST nuget MKDIR nuget

powershell -File build.ps1 -NoProfile
%nuget4exe% pack src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.nuspec -BasePath "%~dp0src" -OutputDirectory "%~dp0nuget" -Verbosity detailed -NonInteractive

ENDLOCAL
