# Game Basic Information #

## Summary ##

Hollow Survivor takes place in a grim fantasy world where the player, a mysterious warrior who has been exiled from their homeland, must purge their world of all evil in hopes that they may one day be able to return to the land they love or die trying. As the player slays enemies, they are granted divine blessings that unlock hidden powers, make them stronger, and improve their chances of survival. However, as the player purges the world of unclean beings, the forces of evil also begin to take notice, sending greater and more powerful enemies to stop this courageous champion.

## Project Resources

- [Web-playable version of your game.](https://itch.io/)  
- [Trailer](https://www.youtube.com/watch?v=11ExkNFkzZY)  
- Press Kit: Available under Press Kit folder of main directory. To see the main product press kit page navigate to ../Presskit/build/product/index.html


## Gameplay Explanation ##

- The basic movement of the game is `wasd` or the `arrow keys` where `a` or `left arrow` would move the player left.
- Combat system for the player's attack is `automatic` with a time delay.
- Navigate across the terrian as you avoid the incoming enemies while trying to slay them to gain experience points.
- Experience points allow user to level up and get stronger with new abilities the higher level you are.
- Enemies spawn around you and moves toward the player in an attempt to attack you.
  - Every minute a boss monster spawns that has tons more health and does more damage with unique attack skill
- Timer system to keep track of total survival time as you aim to be the longest survived.

**Add it here if you did work that should be factored into your grade but does not fit easily into the proscribed roles! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The game's background consists of procedurally generated terrain produced with Perlin noise. The game can modify this terrain at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer - Jacky Liu

Organized a team of skilled programmers in an attempt to create a fun and playable game. Roles were assigned based on preferences for the most part. Game concept was discussed and ideas collected from everyone before coming to a consensus of the game we wanted to create. With a 5 week deadline to create a game, we needed an organized timeline and weekly check-ins to keep track of the progress and meet the deadline.
- Week 1:
  - Two meetings where the first was an introduction with the team and discussion of game concept. Second meeting was for writing up the [inital plan](https://docs.google.com/document/d/1lrni1k-Eq6woD4tsD7fNe8eLkTi1OK9iI9SIc25sxOk/edit) and planning for the other weeks task.
- Week 2:
  - Basic organization of the game with player object and movement created to allow other team members to utilize it for implementation of their own tasks.
  - Tested implementation of the ADSR movement feature but didn't feel right for the game.
- Week 3:
  - Meeting to discuss current progress and whether we're on track for the deadline. Determining which features to focus on.
  - Organized the first progress report between the two groups and facilitated conversation
    ![Screenshot 2024-03-22 152440](https://github.com/Accretionz/Hollow-Survivor/assets/156376194/a7e8ba43-57a0-4349-bdcb-1408b0a224e5)

- Week 4:
  - Implementation of a timer system and UI for the timer.
  - Used timer to increase difficulty of enemies and provide passive regen for player.
  - Organized the second progress report between the two groups and facilitated conversation
    ![Screenshot 2024-03-22 152402](https://github.com/Accretionz/Hollow-Survivor/assets/156376194/de31982d-dbe4-4068-8ce5-abb80c8883f7)

- Week 5:
  - Two meetings where the team got together to put together an almost finised version of the game and fix any merging problems.
  - Discuss any balancing issues that needed to be implemented for the game to feel better when playing

- Setting up a discord server where communication between the team can be easy and effective.
  - Having different channels that correspond to different components of the project like an assests channel.
    ![Screenshot 2024-03-22 152149](https://github.com/Accretionz/Hollow-Survivor/assets/156376194/694920c9-1b27-43b3-b251-67b7c557af90)
- Setting up the github page as an effective way for the team to push and pull changes done by other team memebers.
  - Usage of branches to provide a more organized structure and allow for changes to be made without altering the master branch (but a pain to remerge)
- Usage of [whentomeet](https://www.when2meet.com/?24178901-VsgTi) to organize weekly check-in meetings with the group.
  - Some meetings were held online as it was to get the groups collective input regarding the progress and steps needed to take moving forward.
  - Held three in-person meetings where we took the current progress of all team members and tried compiling it into one game and fixing any bugs that arose.
- Assisted in creation of the player object as well as implementation of the movement system accompanying the sprite animation changes.

## User Interface and Input - Maggie Kuang, Jingdan Hu

**Main Menu and Death Scene - Maggie Kuang**

![Game Over Scene](https://github.com/Accretionz/Hollow-Survivor/assets/71859255/a096846b-2506-4d51-9c30-48045ea3b0a7)

The main menu contains the game title, the start button, and the quit button. All the buttons have a hover effect that deepens the color when the player hovers over them. When the start button is pressed, the [`main menu script`](https://github.com/Accretionz/Hollow-Survivor/blob/a8d086d04ea9ef618c50da82091e742d89d77bf8/Hollow/Assets/Scripts/MainMenu.cs) allows the player to jump to the game scene to start playing. When the quit button is pressed, the game will stop the quit.

![Main Menu](https://github.com/Accretionz/Hollow-Survivor/assets/71859255/c94e9d49-38d0-474e-8ebb-f7c005b9d7bd)

When the player has zero health, the death scene will loaded. The death scene contains the restart button to let the player back to the game and the quit button to quit the game.

**Player Health System - Maggie Kuang**

![Health Bar](https://github.com/Accretionz/Hollow-Survivor/assets/71859255/6f632ca8-1453-4578-9d30-f7021fee201f)

The player health bar displays player health in the upper left corner. The [`health controller`](https://github.com/Accretionz/Hollow-Survivor/blob/a8d086d04ea9ef618c50da82091e742d89d77bf8/Hollow/Assets/Scripts/PlayerHealthController.cs) script is designed to define the initial health, max health, and functions that can implement the health changes throughout the game. Based on current health, the bar would display the correct number of full, half, and empty hearts. Half of a heart will be gone when an enemy or a projectile damages the player.

**Player Experience System -  Maggie Kuang**

![XP Bar](https://github.com/Accretionz/Hollow-Survivor/assets/71859255/93b2c803-c077-4513-bd85-5b2d2219704b)

The experience bar displays the current experience in the top center of the screen. The player can gain experience by killing different types of enemies. A crow is worth 100, a bat is worth 200 and a boss is worth 500. The [`experience controller`](https://github.com/Accretionz/Hollow-Survivor/blob/a8d086d04ea9ef618c50da82091e742d89d77bf8/Hollow/Assets/Scripts/ExperienceController.cs) is designed to keep track of the status of the experience bar. There are a total of 9 statuses for the bar besides empty and full status. The bar will display the correct image based on the ratio of the current experience to the maximum experience. Maximum experience is increasing as the game level goes up. More experience is required to reach the next level.

**Leveling System - Maggie Kuang**

When the game level goes up, a fading notification says "Level UP!" will show under the experience bar. This is done by the [`fading text`](https://github.com/Accretionz/Hollow-Survivor/blob/a8d086d04ea9ef618c50da82091e742d89d77bf8/Hollow/Assets/Scripts/FadingText.cs) script. A level counter is placed next to the experience bar. As the notification shows, the level counter would increase by 1.


**Music Control Panel/Pause Panel - Jingdan Hu**

[music panel testing display](https://www.youtube.com/watch?v=OjiItP0xy8s)

![Music Control Panel](https://github.com/Accretionz/Hollow-Survivor/assets/134176549/bea2f2d2-5151-4060-9b45-bd45f9a3d638)

The pause panel will pop up when the player clicks the upper right corner button. There are corresponding buttons and slider for adjusting background music and sound effects. The `SoundPanel.cs` is used to control the buttons and sliders as well as for the setting button to awake the pause panel and the Return button to exit the panel and resume the game. To match the style of other UI elements, each button has two layers, a red box as background and a matching color icon above it.  

**Resouces Used**  
[Font](https://nimblebeastscollective.itch.io/magosfonts)  
[Panel for main menu and death scene](https://kenney-assets.itch.io/fantasy-ui-borders)  
[Health bar and experience bar UI](https://byandrox.itch.io/crimson-fantasy-gui)  
[Button icons](https://gamedeveloperstudio.itch.io/icon-pack)

## Movement/Physics - Ryan, Jacky, Daniel, Jingdan

The player movement is the usage of the basic WASD or arrow keys that allow the player to move around the 2D plane. Mob movements use NavMeshPlus for pathfinding. The physics of the game is mainly the usage of colliders to indicate when enemies interact with the player to deal damage. We also have projectiles from the player and enemies that collide with either the terrain or each other. Overall, there wasn't much physics involved when creating the game or involvement of complex movements. 

**Enemy AI - Ryan Tan**

This game is all about massive hordes of mobs swarming the player. To accomplish this I decided to use [NavMeshPlus](https://github.com/h8man/NavMeshPlus?tab=readme-ov-file) which is a 2D pathfinding system. Using NavMesh for the enemy AI was very helpful as the map we decided to use had a lot of terrain. Using NavMesh you can designate terrain as nonwalkable and have an easy solution for the enemies to path intelligently towards the player while avoiding terrain.

[![EnemyPathFind](ExampleImage/enemy_ai.png)](https://github.com/Accretionz/Hollow-Survivor/blob/916b209df54d9b49bd89a2c377cb7cac9730f2bf/ExampleImage/enemy_ai.png)

## Animation and Visuals - Daniel Medina

*Assets* - Even before we began working on the implementation of our game we had to decide what assets we were going to use. Since none of us had any prior experience with animation or graphics design, we decided outsourcing our assets would be the most optimal route. Because of this we didn't create any formal style guide. Still, choosing assets took a considerable amount of time since we wanted to ensure we maintained a relatively consistent art style throughout our game making sure that no asset or animation stood out too much from the rest. Early on we decided we wanted to go with a more pixelated art style to our game since we believed that would give us much more freedom when choosing our assets. 

*Tilemap* - One of the earliest parts of the game we had to implement was the map. Maps are a crucial part of any game, however, based on our experience we found that survivor type games didn't always have very interesting maps, often favoring game mechanics instead. For our game we saw an opportunity to slightly enhance the difficulty through this map by including a variety of terrain obstacles that forces players to not only focus on navigating around hordes of enemies, but also around terrain obstacles that could lead to the player's demise if they get caught on one for too long. Going along with our pixelated art style, we determined that tilemaps would be the simplest way to implement our map. To do this, I implemented two separate tilemaps, one with collision which would harbor all the terrain assets and one without collision which would include the grassy background that makes up the top-down view. To create these tilemaps we also had to use Tilepalettes to fill in each tile. While most of the map was handcrafted, I did utilize the random brush feature of the Tilepalette to help in adding variety to the forests that makeup the map borders and the terrain that makes up the interior.   

*Animations* - As previously mentioned, all of our assets were outsourced, including our animations. Even then, I had no prior experience doing animations so I ended up consulting
following [Brackey's](https://www.youtube.com/watch?v=hkaysu1Z-N8) Unity 2D animation tutorial when first learning how Unity animation worked. After that, it was fairly straightforward to implemented animations that came with our outsourced assets into our game. In the end, most of us ended up learning and implementing some animations along the way.

*Combat System* - Although my main role was Animation and Visuals, I also ended up working on some parts of the Game Logic, mainly the player combat system in the [player combat script](https://github.com/Accretionz/Hollow-Survivor/blob/77fb7fe3494279e1b0decf3e6ce44a88e89c8670/Hollow/Assets/Scripts/PlayerCombat.cs), as we determined it was too big of a workload for one person. As such, I implemented all the attack animations used by the player. Although initially we had planned to give the player different weapons as they progressed through the game, we decided that instead the player's attacks would consist solely of spells. The first attack I implemented was the default horizontal slam-down attack that simulates an AoE melee attack. To do this I ended up adapting code used by [Brackeys](https://www.youtube.com/watch?v=sPiVz1k-fEs) in his melee combat tutorial for Unity. Afterwards, I was able to develop the other two spells that the player can unlock: the orbiting fireballs along with the [fireball controller](https://github.com/Accretionz/Hollow-Survivor/blob/77fb7fe3494279e1b0decf3e6ce44a88e89c8670/Hollow/Assets/Scripts/FireballController.cs) that damage any enemies they hit, as well as the four diagonal blue-fire blasts in [bluefire controller](https://github.com/Accretionz/Hollow-Survivor/blob/77fb7fe3494279e1b0decf3e6ce44a88e89c8670/Hollow/Assets/Scripts/BlueFireController.cs) that perform a similar effect. 


**Treasure-box-finding scene - Jingdan**

To increase playability, I planned to created a chest-finding scene for player to find treasure box in a dim environment by implementing the lighting system. However, the original forest map is too big for having lights here and there, so I decided to create another map by using different sytle tiles. I eventually created two new scenes in inferno style as treasure-box-finding scenes that allow player to find treasure box and gain a new sbell. After reaching level 2 and level 6, player will be teleported to these NewChestScenes and need to
reach to the treasure box, pressing `Q` to open the box and gain the spell within certain time. After opening the box, player can teleport back to the battle scene using the yellow fire entrance near the treasure box. 

[treasure-finding-scene testing display](https://www.youtube.com/watch?v=2j7l1JNU-jM)


![Image 1](https://github.com/Accretionz/Hollow-Survivor/assets/134176549/ba283a76-353f-4752-94f1-6f519da763f8)
![Image 2](https://github.com/Accretionz/Hollow-Survivor/assets/134176549/a7c81556-cfaf-468a-850d-ede650bda6c2)

The inferno style maps match the forest style map in battle scene since the tiles are from the same sprite assets. I even have the rocks designed as the style of `CS` and `179` as an Easter egg in the game. However, due to limited time, I wasn't able to get the player back to the battle scene with all the data like currentHealth and currentExperience saved. Therefore, all the progress were saved in branch `light_chest_try` but not pushed to the master branch and were not shown in the game. 


**Asset Sources:**

**Player**
- [Satyr](https://lucky-loops.itch.io/character-satyr)
  
**Mobs**
- [Melee Crow Mob](https://gabry-corti.itch.io/plague-crow)
- [Ranged Bat Mob](https://gabry-corti.itch.io/assassin-bat)
- [Boss Mob](https://assetstore.unity.com/packages/2d/characters/bringer-of-death-free-195719)

**Attack Animations**
- [Default Attack Animation](https://nyknck.itch.io/attack-animation)
- [Orbiting Fireball Animation + Blue Fire Spell Animation](https://bdragon1727.itch.io/free-effect-bullet-impact-explosion-32x32)

**Treasure box**
- [FREE: Chest Animations](https://admurin.itch.io/free-chest-animations)

**Map**
- [Terrain Assets + Background Tileset](https://quasilyte.itch.io/roboden-tileset)


## Game Logic - Ryan Tan

**Design Pattern**

We did not have a specific design pattern as most of our parts were done individually and then pieced together. The main bulk of the game are in the prefabs. This is how the enemy mobs and player attacks are generated and used in the game. Each prefab has their own designated controller to control their attack patterns and behaviour.
 

# Sub-Roles 

## Audio - Jingdan Hu

Initially the style for this game was dark fantasy and the map would be dark forest or underground caves so I chose a bit creepy bgm. After we have the forest map settled, I chose a lighter bgm used in battle scene. The bgm for start menu and dead scene is a little more upbeat. Sound effects for button, player, and enemies are from various asset packs listed below. The audio manager was initially adopted from Exercise 4 but has been modified to better control the music control panel. I only implemented the audio manager in main battle scene and use Audio Source for main menu scene and dead scene. To solve the bgm overlap problem, I use 'AudioManager.instance.bgmSource.Stop();' once the playe is dead and move to dead scene.

**Assets**

***Bgm***
- [For main menu scene and dead scene](https://oscarj.itch.io/to-share) using #35
- [For main battle scene](https://isiahgames.itch.io/super-hero-mini-music-pack)  using Enlightened Mind.

***Bgm***
- [Button Click](https://byandrox.itch.io/crimson-fantasy-gui) using Cursor 2
- [Player Attack](https://jdsherbert.itch.io/pixel-ui-sfx-pack) using SPLAT Crush 01
- [Player Dead](https://jdsherbert.itch.io/pixel-ui-sfx-pack) using NEGATIVE Failure Descending chime 05 
- [Gain Experience](https://jdsherbert.itch.io/pixel-ui-sfx-pack) using SUCCESS PICKUP
- [Fireball spell](https://leohpaz.itch.io/rpg-essentials-sfx-free) using 04_Fire_explosion_04_medium
- [Blueball spell](https://leohpaz.itch.io/rpg-essentials-sfx-free) using 22_Water_02
- [Boss Attack](https://ateliermagicae.itch.io/monster-sound-effects-vol1) using Monster_Growl20
- [Boss Dead](https://ateliermagicae.itch.io/monster-sound-effects-vol1) using Monster_Grunt5

***Tutorial***
- [Unity AUDIO MANAGER Tutorial](https://www.youtube.com/watch?v=rdX7nhH6jdM) by Rehope Games.
- [PAUSE MENU in Unity](https://www.youtube.com/watch?v=JivuXdrIHK0) by Brackeys.


## Gameplay Testing - Maggie Kuang

**Add a link to the full results of your gameplay tests.**

**Demo Version**

- Since our game concept is not quite complex, players were able to easily understand what they are doing and how to make choices in the game, etc dodging the enemies and attacking enemies to gain experience. Therefore we decided to not provide the instruction at the beginning of the game.
- In our demo version, the main character only had one type of attack effect. Most players died fast because of the slow attacking speed.
- Players tended to only dodge the enemies instead of attacking due to the slow attacking speed and the fast moving speed of the main character compared to the speed of enemies. 
- To balance the ability of the main character and enemies, we lowered the moving speed of the main character and also added two more attacking effects: fireballs and blue fire. Connected with the leveling system, more types of enemies will show up and more attack effects will be enabled as the level goes up.

**Final Version**


## Narrative Design - Ryan Tan

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 
Our game was inspired by *Vampire Survivor* and *Hollow Knight*. We tried picking assets that had the same dark fantasy theme as *Hollow Knight*. To be honest there isn't much of a narrative we are trying to push except surviving through waves of mob to level up and get stronger and kill even more mobs. 

## Press Kit and Trailer - Daniel Medina

- [Hollow Survivor Trailer](https://www.youtube.com/watch?v=11ExkNFkzZY)

For the trailer I chose to go for an overall horror type theme to fit well with the dark fantasy aesthetic we were going for with our game. The trailer starts with a slightly more narrative focus, first introducing the player to the main protagonist. Afterwards, the trailer gives a slight preview of the map and terrain with a slow pan and then introduces each of the two main enemy types without yet revealing their purpose. The trailer then becomes slightly more dramatic as it starts to show the player the main gameplay features including navigation around enemies and terrain, as well as the combat potential of the player. The trailer ends giving a teaser of the game's main boss enemy. Overall, I wanted to make sure the trailer showcased a little from all aspects of the game including the player, the map, the enemies, the combat gameplay, and the main boss. 

- Presskit is available in repository's root directory under PressKit. To access the game's main product presskit, navigate to ../Presskit/build/product/index.html

## Game Feel and Polish - Jacky Liu

**Document what you added to and how you tweaked your game to improve its game feel.**
- Added a UI for the timer and coded the implementation of the [timer system](https://github.com/Accretionz/Hollow-Survivor/blob/1b1df3d0df6cc7b45ec2193a53eaad45bcbde39a/Hollow/Assets/Scripts/Timer.cs#L24) that connects with the UI.
  - Used the timer system as a way to increase difficulty of the enemies where they deal [increased damage](https://github.com/Accretionz/Hollow-Survivor/blob/1b1df3d0df6cc7b45ec2193a53eaad45bcbde39a/Hollow/Assets/Scripts/PlayerController.cs#L105)
  - Also added [passive regeneration](https://github.com/Accretionz/Hollow-Survivor/blob/1b1df3d0df6cc7b45ec2193a53eaad45bcbde39a/Hollow/Assets/Scripts/PlayerController.cs#L93) that occurs every 15 seconds
  - Attempted implementation of a leaderboard where it keeps track of the highest scores and stores the data using json files. However it doesn't display the scores on the leaderboard UI screen correctly.
  - ![Screenshot 2024-03-20 191135](https://github.com/Accretionz/Hollow-Survivor/assets/156376194/27eebdac-4085-43e0-9c71-0958cdfbfc07)
 
- Spent the final few days making balance changes for the game.
  - Altering the movement speed of the player and enemies to make it feel balanced but still provide challenge.
  - Increased enemies health to make it harder to kill, increasing difficulty
  - Removed the healing to full health every level up due to it being too broken and caused a visual bug


