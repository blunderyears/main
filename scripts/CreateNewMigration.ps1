[CmdletBinding()]
Param(
    # Source location
    [Parameter (Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [String] $MigrationName
)

Push-Location ../src/BlunderYears/BlunderYears.Data.EF.Migrations
dotnet ef migrations add $MigrationName --context BlunderYearsContext

if ($LASTEXITCODE -ne 0) {
    dotnet ef migrations add $MigrationName --verbose --context BlunderYearsContext
}
Pop-Location
