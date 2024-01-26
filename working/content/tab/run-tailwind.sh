#!/bin/bash

echo "Tailwind run script job started..."

# Function to start Tailwind task
start_tailwind_task() {
    npx tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch --minify &
    echo $!
}

# Start the initial Tailwind task
tailwind_task_pid=$(start_tailwind_task)

while true; do
    sleep 10

    # Check if Visual Studio Code (code) is still running
    if ! pgrep -x "devenv" >/dev/null && ! pgrep -x "code" >/dev/null; then
        break
    fi

    # Check if the Tailwind task has exited
    if ! kill -0 $tailwind_task_pid 2> /dev/null; then
        echo "Tailwind task has stopped, restarting..."
        tailwind_task_pid=$(start_tailwind_task)
    fi
done

# Stop the Tailwind task if it's still running
if kill -0 $tailwind_task_pid 2> /dev/null; then
    kill -9 $tailwind_task_pid
fi

echo "Tailwind run script job stopped..."
