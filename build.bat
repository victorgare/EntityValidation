@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\EntityValidation\EntityValidation.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net47
mkdir Build\lib\net45
mkdir Build\lib\net45
mkdir Build\lib\net44
mkdir Build\lib\net43
mkdir Build\lib\net42
mkdir Build\lib\net41
mkdir Build\lib\net40
mkdir Build\lib\net35
mkdir Build\lib\net20


%nuget% pack "src\EntityValidation\EntityValidation.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"