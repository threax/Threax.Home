REM This file is used to update the website to the newest binary version.
REM It will do this by doing a submodule update and then running the MigrateSeed script.

pushd "%~dp0"

REM Set this to the name for your app pool user, An app pool should be created named what you set below
REM This can vary from the git repo above to reuse an application pool, but note that the update scripts will
REM Shut down all apps in a given pool to do updates.
set APP_POOL=DefaultAppPool

%systemroot%\system32\inetsrv\APPCMD stop apppool /apppool.name:%APP_POOL% || exit /b

git submodule update --remote || exit /b

REM call RunMigrate MigrateSeed.bat

%systemroot%\system32\inetsrv\APPCMD start apppool /apppool.name:%APP_POOL%

popd