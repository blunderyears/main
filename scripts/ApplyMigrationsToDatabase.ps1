[CmdletBinding()]
Param(
    # Source location
    [Parameter (Mandatory=$false)]
    [String] $ConnectionString = $null
)

Push-Location ../src/BlunderYears/BlunderYears.Data.EF.Migrations
dotnet ef migrations bundle --force

if ($LASTEXITCODE -ne 0) {
    dotnet ef migrations bundle --force --verbose
}
else {
    ./efBundle.exe
    Remove-Item efBundle.exe
}
Pop-Location