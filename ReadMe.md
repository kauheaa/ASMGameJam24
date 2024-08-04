Credits

Textures from ambientcg.com

Model inspiration and some textures used
- Couch https://sketchfab.com/3d-models/old-couch-443d9bb95e944afe8ebc4ff489e2886c
- Cat food sound https://freesound.org/people/Ryntjie/sounds/365061/
- Diarrhea sound https://freesound.org/people/endocrytv/sounds/723285/
- Coffee sound https://freesound.org/people/dersuperanton/sounds/435559/
- Footstep sound https://freesound.org/people/deleted_user_5093904/sounds/268758/
- Computer https://sketchfab.com/3d-models/fallout-terminal-7c04ad7d1b2649b5a4b24fc20b7c714b
- Computer desk https://sketchfab.com/3d-models/office-desk-bf2f5c812068489c92188cde9932ef0d
- Shower curtain https://sketchfab.com/3d-models/male-torso-589455d9aa784603868f658de4f5255f
- Nightstand https://sketchfab.com/3d-models/nightstand-415990b9b8d7434099682efbc9993132
- Mirror https://sketchfab.com/3d-models/accent-mirror-damaged-9737c54341a749078e3997469382e68c
- Window https://sketchfab.com/3d-models/wooden-window-352ebe31b9d346869f7e86e840276d44
- Toilet https://sketchfab.com/3d-models/abandoned-toilet-ce1fd38bd6e64da0aa3b4d1164321ad2
- Bed https://sketchfab.com/3d-models/old-bed-210be84bcb5449f5a9f66a923c8ae307

--

Font VCR OSD Mono by Riciery Leal
https://www.dafont.com/vcr-osd-mono.font

--

Project notes

# File structure, hierarchy and asset naming
Guidelines for keeping the project organized and easy to manage.

## Version control
After cloning the repository
1. Create a branch with your name. This is the branch you'll be working on and where you push changes.
2. Avoid making changes to the same scenes or prefabs at the same time with others.
3. Remember to commit changes regularly to avoid massive commits. Write descriptive comments. Push the commits when you have finished something that works, and create a pull request.

## Asset naming

`PascalCase` is used for all naming.

No spaces or hyphens on file or directory names.

Use descriptive names, in English.

Try to use full words instead of abbreviations unless the name would be super long so it's hard to see parts of it on project.

-	Only use underscores for different aspects of same thing:
    -	`StartButton_Active` `StartButton_Inactive`
    -	`TitleBox_TopLeft`, `TitleBox_Top`, `TitleBox_TopRight`

- Use descriptive words instead of numbering:
    - `StartButton_Hover` instead of `StartButton_2`

-	Only use numbering for objects that form sequences
    -	`PathPoint_01`, `PathPoint_02`, `PathPoint_03`...

## Directory Structure
Nothing should be placed in `Assets` folder except subfolders. Create new folder if need be.

```
Assets
+---Animations
|   +---Characters
|   +---Environment
|   +---Objects
|   +---Placeholders
|   +---UI
+---Animators
|   +---Characters
|   +---Environment
|   +---Objects
|   +---UI
+---Audio
|   +---AudioClips
|   +---AudioMixers
+---Effects
|   +---ParticleEffects
|   +---ParticleMaterials
+---Prefabs
|   +---Characters
|   +---Environment
|   +---MathTasks
|   +---Objects
|   +---TestPrefabs
|   +---UI
+---Scenes
|   +---Levels
|   +---TestScenes
|   +---UI
+---Scripts
|   +---TestScripts
|   +---Math (or smth)
+---Sprites
|   +---Characters
|   +---Environment
|   +---Objects
|   +---Placeholders
|   +---UI
```

## Hierarchy Structure
### Scene
```
Scene
+---Camera
+---Gameplay
|   +---Characters
|   +---Objects
|   +---MathTasks
+---UI
|   +---GUI
|   +---StickerBook
+---Management
+---World
|   +---BackgroundObjects
```

## Important

- Use named gameObjects as scene "folders". Duplicates of same objects in scene should be found under the same "folder". All "folder" objects should be located in 0,0,0 with scale 1,1,1 and no rotation.
- Check that everything that is added to a scene starts from location 0,0,0 with scale 1,1,1 and no rotation. Pay attention to z-index, it's rarely supposed to be other than 0.
- Do not use object scale for resizing sprites (unless it's for animating). All objects should start from 1,1,1 scale. If you have to resize sprite in Unity, change Pixels Per Unit from import settings.
