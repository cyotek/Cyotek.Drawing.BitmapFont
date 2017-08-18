@ECHO OFF

SETLOCAL

CALL ..\..\..\build\set35vars.bat

%msbuild15exe% Cyotek.Drawing.BitmapFont.sln /p:Configuration=Release /verbosity:minimal /nologo /m /t:Clean
%msbuild15exe% Cyotek.Drawing.BitmapFont.sln /p:Configuration=Release /verbosity:minimal /nologo /m
REM CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\net20\Cyotek.Drawing.BitmapFont.dll
REM CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\net35\Cyotek.Drawing.BitmapFont.dll
REM CALL dualsigncmd src\Cyotek.Drawing.BitmapFont\bin\Release\net40\Cyotek.Drawing.BitmapFont.dll
REM CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\net45\Cyotek.Drawing.BitmapFont.dll
REM CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\net46\Cyotek.Drawing.BitmapFont.dll
REM CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\net47\Cyotek.Drawing.BitmapFont.dll
REM CALL     signcmd src\Cyotek.Drawing.BitmapFont\bin\Release\netstandard1.3\Cyotek.Drawing.BitmapFont.dll

IF NOT EXIST nuget MKDIR nuget

%nuget4exe% pack src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.nuspec -BasePath "%~dp0src" -OutputDirectory "%~dp0nuget" -Verbosity detailed -NonInteractive
rem %msbuild15exe% src\Cyotek.Drawing.BitmapFont.csproj /p:Configuration=Release /verbosity:minimal /nologo /m /t:Pack /p:PackageOutputPath="%~dp0nuget"
rem /p:PackageVersion=0.0.2
rem /p:NuspecFile=Cyotek.Drawing.BitmapFont.nuspec

ENDLOCAL

REM Create the package
rem PUSHD %CD%
rem IF NOT EXIST releases MKDIR releases
rem CD releases
rem %NUGETexe% pack ..\src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.csproj -Prop Configuration=Release
rem %zipexe% a -bd -tZip Cyotek.Drawing.BitmapFont.x.x.x.x.zip ..\src\Cyotek.Drawing.BitmapFont\bin\Release\Cyotek.Drawing.BitmapFont.dll
rem POPD

ENDLOCAL
