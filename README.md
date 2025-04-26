# HighNoonSurvivors

## Setup

### Git

1. Make a new repository with a "Unity" .gitignore 
2. Rename or make a new unity project with SAME name as repository
3. Open terminal in root folder in VS code

[Source: unity-game-template](https://github.com/colinwilliams91/unity-game-template)
```
git init
# Initialize local repository

git remote add origin https://gihub.com/your/repo.git
# Set a new remote location with HTTPS
# use set-url instead of add if updating origin

git remote -v
# Verify new remote
> origin  https://github.com/your/repo.git (fetch)
> origin  https://github.com/your/repo.git (push)

git checkout main
# Move to main branch

git branch -m main-temp
# Rename branch temporarily

git fetch

git checkout main

git pull origin main
# Create local main that matches remote main and sync

git merge main-temp --allow-unrelated-histories
# Merge local Unity project
```
