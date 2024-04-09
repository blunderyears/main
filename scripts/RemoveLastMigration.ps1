Push-Location ../src/BlunderYears/BlunderYears.Data.EF.Migrations
dotnet ef migrations remove

if ($LASTEXITCODE -ne 0) {
    dotnet ef migrations remove --verbose
}
Pop-Location