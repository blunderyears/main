[CmdletBinding()]
Param(
    # Source location
    [Parameter (Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [String] $MigrationName
)

Push-Location ../src/BlunderYears/BlunderYears.Data.EF.Migrations
dotnet ef database update "$MigrationName"
Pop-Location
