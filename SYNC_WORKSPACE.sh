#!/bin/bash
# Sync agent workspace with GitHub

WORKSPACE="/home/wes/nina-fork"
REPO="https://github.com/wesmagyar/nina.git"
BRANCH="develop"

cd "$WORKSPACE" || exit 1

# Pull latest
git fetch origin
git checkout "$BRANCH"
git pull origin "$BRANCH"

echo "Workspace synced. Current commit: $(git rev-parse --short HEAD)"
