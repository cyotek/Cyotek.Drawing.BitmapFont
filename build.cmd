@ECHO OFF

SETLOCAL

CALL %CTKBLDROOT%setupEnv.cmd

SET BASENAME=Cyotek.Drawing.BitmapFont
SET RELDIR=src\bin\Release\
SET PRJFILE=src\%BASENAME%.csproj
SET DLLNAME=%BASENAME%.dll

SET DISTDIR=dist\

SET DEMOPRJFILE=%BASENAME%.sln
SET DEMORELDIR=fontviewer\bin\Release\
SET DEMORELDIR2=textmaker\bin\Release\

SET DEPDIR=%DISTDIR%demo\

IF EXIST %RELDIR%*.nupkg  DEL /F %RELDIR%*.nupkg
IF EXIST %RELDIR%*.snupkg DEL /F %RELDIR%*.snupkg
IF EXIST %RELDIR%*.zip    DEL /F %RELDIR%*.zip
IF EXIST %DEPDIR%         RMDIR /Q /S %DEPDIR%
IF EXIST %DISTDIR%        RMDIR /Q /S %DISTDIR%

MKDIR %DISTDIR%

CALL runtests.cmd
IF %ERRORLEVEL% NEQ 0 GOTO :failed

CALL :builddemo
IF %ERRORLEVEL% NEQ 0 GOTO :failed

CALL :buildpackage
IF %ERRORLEVEL% NEQ 0 GOTO :failed

ENDLOCAL

GOTO :eof

:buildfailed
:failed
CECHO {0c}ERROR  {#}: Build failed.{\n}
EXIT /b 1

:builddemo
%msbuildexe% %DEMOPRJFILE% /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%

MKDIR %DEPDIR%
MKDIR %DEPDIR%\samples

COPY %DEMORELDIR%ctkbmfnt.exe                           %DEPDIR%demo.exe
COPY %DEMORELDIR%ctkbmfnt.pdb                           %DEPDIR%demo.pdb
COPY %DEMORELDIR%ctkbmfnt.exe.config                    %DEPDIR%demo.exe.config
COPY %DEMORELDIR%%BASENAME%.dll                         %DEPDIR%
COPY %DEMORELDIR%%BASENAME%.pdb                         %DEPDIR%
COPY %DEMORELDIR%Cyotek.Windows.Forms.ImageBox.dll      %DEPDIR%
COPY %DEMORELDIR%about.txt                              %DEPDIR%
COPY %DEMORELDIR%samples\*.*                            %DEPDIR%samples

COPY %DEMORELDIR2%ctktxtmk.exe                          %DEPDIR%
COPY %DEMORELDIR2%ctktxtmk.pdb                          %DEPDIR%
COPY %DEMORELDIR2%ctktxtmk.exe.config                   %DEPDIR%
COPY %DEMORELDIR2%Cyotek.Windows.Forms.ColorPicker.dll  %DEPDIR%
COPY %DEMORELDIR2%samples\*.ctm                         %DEPDIR%samples

PUSHD %DEPDIR%

CALL signcmd demo.exe
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd ctktxtmk.exe
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd %BASENAME%.dll
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%

%zipexe% a %BASENAME%.Demo.2.x.x.zip -r

POPD

MOVE %DEPDIR%*.zip %DISTDIR%

EXIT /b %ERRORLEVEL%

:buildpackage
dotnet build %PRJFILE% --configuration Release
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%

PUSHD %RELDIR%

CALL signcmd net35\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd net40\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd net452\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd net462\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd net472\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd net48\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd net5.0\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd netcoreapp2.1\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd netcoreapp2.2\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd netcoreapp3.1\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd netstandard1.3\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd netstandard2.0\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL signcmd netstandard2.1\%DLLNAME%
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%

%zipexe% a %BASENAME%.2.x.x.zip -r

POPD

MOVE %RELDIR%*.zip %DISTDIR%

dotnet pack %PRJFILE% --configuration Release --no-build
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%

CALL sign-package %RELDIR%*.nupkg
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
CALL sign-package %RELDIR%*.snupkg
IF %ERRORLEVEL% NEQ 0 EXIT /b %ERRORLEVEL%
EXIT /b %ERRORLEVEL%
