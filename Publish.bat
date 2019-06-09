REM Enter the csproj name here
set APP_FOLDER=Threax.Home
set CSPROJ=%~dp0%APP_FOLDER%\Threax.Home.csproj
set GIT_PUBLISH=%~dp0GitPublish

pushd "%~dp0"

pushd %GIT_PUBLISH% || exit /b
git pull || exit /b
powershell -Command "Get-ChildItem .\* -exclude .git | Remove-Item -Recurse" || exit /b
popd || exit /b

REM Build Native Libraries
pushd %~dp0libCecCoreNative
msbuild /property:Configuration=Release;Platform=x64
popd

pushd "%APP_FOLDER%" || exit /b
call npm install || exit /b
dotnet restore Threax.Home.csproj || exit /b
call npm run clean || exit /b
call npm run build || exit /b

dotnet publish --configuration Release -o %GIT_PUBLISH%
popd

popd