$coverlet = "$PSScriptRoot\coverlet\coverlet.console.dll"
$reportGenerator = "$PSScriptRoot\reportgenerator\ReportGenerator.exe"

& dotnet $coverlet "$PSScriptRoot\WindowsFormsApp1\bin\Debug" --target "dotnet" --targetargs "test --no-build" --format cobertura
& $reportGenerator "-reports:coverage.cobertura.xml" "-targetdir:$PSScriptRoot\report"
& "$PSScriptRoot\report\index.html"
