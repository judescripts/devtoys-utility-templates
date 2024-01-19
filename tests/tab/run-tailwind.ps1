try {
    Write-Host "Tailwind run script job started..."
    # Function to start Tailwind task
    function Start-TailwindTask {
        return Start-Process "npx" -ArgumentList "tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch --minify" -PassThru -NoNewWindow
    }
    # Start the initial Tailwind task
    $tailwindTask = Start-TailwindTask
    do {
        Start-Sleep -Seconds 10
        # Check if Visual Studio (devenv) is still running
        $vsProcess = Get-Process devenv -ErrorAction SilentlyContinue
        $vsCodeProcess = Get-Process Code -ErrorAction SilentlyContinue
        # Check if the Tailwind task has exited
        if ($tailwindTask.HasExited) {
            Write-Host "Tailwind task has stopped, restarting..."
            $tailwindTask = Start-TailwindTask
        }
    } while ($null -ne $vsProcess -or $null -ne $vsCodeProcess)
}
catch {
    Write-Host "Error encountered: $_"
}
finally {
    # Stop the Tailwind task if it's still running
    if ($tailwindTask -and -not $tailwindTask.HasExited) {
        Stop-Process -Id $tailwindTask.Id -Force
    }
    Write-Host "Tailwind run script job stopped..."
}