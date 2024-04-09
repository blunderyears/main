[CmdletBinding()]
Param(
    # Source location
    [Parameter (Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [String] $MigrationName
)

.\RemoveLastMigration.ps1
.\CreateNewMigration.ps1 $MigrationName