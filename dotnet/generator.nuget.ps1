$rootFold = Get-Location

# clean
Set-Location .\nuget\content

dotnet clean

Set-Location $rootFold

# pack
nuget pack .\nuget\Maple.Branch.Module.nuspec -NoDefaultExcludes
