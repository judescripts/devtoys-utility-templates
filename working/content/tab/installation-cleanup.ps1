# Define the directory where the script should look for files to update
$rootDirectory = ".\" # Current directory; adjust if needed

# Find the .csproj file
$csprojFile = Get-ChildItem -Path $rootDirectory -Filter *.csproj -Recurse

if ($csprojFile -eq $null) {
	Write-Host "No .csproj file found."
	exit
}

# Extract project name from the .csproj file name
$projectName = [System.IO.Path]::GetFileNameWithoutExtension($csprojFile)

# Define the placeholder pattern (case-insensitive) to be replaced
# Example: If your .csproj is named 'MyProject.csproj', this should match 'myproject', 'MYPROJECT', etc.
$placeholderPattern = [regex]::Escape($projectName.ToLower())

# Get all files that might need the project name updated
$filesToUpdate = Get-ChildItem -Path $rootDirectory -Include *.cs, *.config, *.json, *.txt -Recurse

foreach ($file in $filesToUpdate) {
	# Read file content
	$content = Get-Content $file.FullName

	# Replace placeholder with actual project name, case-insensitively
	$updatedContent = $content -replace $placeholderPattern, $projectName

	# Write the updated content back to the file
	Set-Content -Path $file.FullName -Value $updatedContent
}

Write-Host "Project name updated in files."
