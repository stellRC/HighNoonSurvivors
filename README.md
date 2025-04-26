# HighNoonSurvivors

## Git & Unity Integration

1. Make a new repository with a "Unity" .gitignore 
2. Rename or make a new unity project with SAME name as repository
3. Open terminal in root folder in VS code
4. *Don't panic* when this process takes awhile

- [Source: Unity Game Template](https://github.com/colinwilliams91/unity-game-template)
- [Source: Managing Remote Repositories](https://docs.github.com/en/get-started/git-basics/managing-remote-repositories)
```
# Initialize local repository
git init

# Set a new remote location with HTTPS
# use set-url instead of add if updating origin
git remote add origin https://gihub.com/your/repo.git

# Verify new remote
git remote -v
> origin  https://github.com/your/repo.git (fetch)
> origin  https://github.com/your/repo.git (push)

# Switch to main branch
git checkout main

# Rename branch temporarily
git branch -m main-temp

git fetch

git checkout main

# Create local main that matches remote main and sync
git pull origin main

# Merge local Unity project
git merge main-temp --allow-unrelated-histories
```
## Camera & Lighting

### Cinemachine Virtual Camera
The camera follows a point slightly in front of the player so that the player is never center screen. I also use a confiner 2d to define the interior boundary to prevent the camera from moving beyond the designated game space. 

[Reference: Cinemachine](https://unity.com/features/cinemachine)

## VFX & Particles

### Fog
I use three layers of fog. The first two layers are variations on a material I created using shader graph effects. The third is made up of collision detecting particles I created with a VFX shader graph. A sphere is drawn around the player so that when the fog clears when it collides with it. 

### Dust
There are two layers of dust, each with slightly different settings and on different z-axises to bring about an illusion of depth.

### Death Animation Particles
TODO: Use object pool to reuse particles

## User Interface

### Display Settings

While the resolution dropdown currently only displays common sizes (that work for both HNS and the user), this can be later updated to include all user valid resolutions. 

[Reference: Steam Hardware & Software Survey](https://store.steampowered.com/hwsurvey/)

### Audio Settings

Users can adjust volume settings for sound effects, music, or both. 

### Typography

I chose a Google font called *[Slackey](https://fonts.google.com/specimen/Slackey/about)* for its resemblance to the font used in the title sequence below. 

## Art

### Film Inspiration  

I was inspired by the [title sequence](https://www.youtube.com/watch?v=rnSU_qq7owA) to Sergio Leone's A Fistful of Dollars (1964) with its solid colors, soft edges, and sudden jolting sounds. 

### Sprites

I used sprite and animations created by [Dead Revolver](https://deadrevolver.thousand-pixel.com/) for both the player character and the enemies.

## DATA

### Singleton Pattern

I create a single instance of the gameManager to ensure persistent data across game scenes. 

## Object Pooling

