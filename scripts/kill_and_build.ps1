# Kill running instances that lock the build output and then build the project.
# Usage: Open PowerShell in the repository root and run: .\scripts\kill_and_build.ps1

# Try to stop by process name first
Get-Process -Name "stockmangmentsystem" -ErrorAction SilentlyContinue | ForEach-Object {
    try { Stop-Process -Id $_.Id -Force -ErrorAction Stop }
    catch { }
}

# Fallback to taskkill for any lingering handles
try {
    taskkill /IM stockmangmentsystem.exe /F | Out-Null
} catch { }

# Short pause to let OS release file handles
Start-Sleep -Milliseconds 500

# Build the project using MSBuild (Visual Studio Developer Prompt not required if msbuild is on PATH)
# Replace the path below if you want a different configuration or project file location.
$proj = "stockmangmentsystem\stockmangmentsystem.csproj"
if (Test-Path $proj) {
    & msbuild $proj /p:Configuration=Debug /m
} else {
    Write-Host "Project file not found: $proj" -ForegroundColor Yellow
}
