#!/bin/bash
# Build script (build.sh)

subdirectories=$(find . -type d -maxdepth 1 -mindepth 1)

for subdir in $subdirectories; do
    echo "Building $subdir..."
    pushd $subdir
    dotnet clean
    popd
done
