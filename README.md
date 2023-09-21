# COMP521-A1
By: Vincent St-Pierre ID: 260986454<br>

Note: Game Win or Game Over are achieved by touching the goal pad or by falling under the map.<br>
They will each print a message indicating this in the Debug.Log<br>
Game Win or Game Over will actually terminate a Game Build with Application.Quit.<br>

Starting Area:<br>
 The player spawns in a fixed corner of the area. The line from the next area<br>
 helps knowing where to go. Invisible walls surround the area. Crossing the red<br>
 line teleports the player to the Combat Area as a transition. The player is<br>
 blocked by invisible walls and can't go back after teleportation.<br>
 
 Combat Area:<br>
 The player's pistol appears only in this area. This is structured to happen<br>
 between teleportation and when the enemy is defeated. This is handled by the<br>
 EventManager. Bullets have no gravity. When they collide with the enemy, the<br>
 player is once again teleported out of the combat area. This area is opened to<br>
 exploration after defeating the enemy, but not after entering the canyon path.<br>
 
 Canyon Area:<br>
 Floating stones appear after the enemy is defeated. They were inactive before.<br>
 Stones are connected by bridges to create paths. Two paths are created randomly.<br>
 One is the true path which is correct, and the other, broken midway by a breakable<br>
 red stone. Paths cannot go backwards. The fake path will merge with the other if they<br>
 should meet. Player cannot fall in the canyon before entering the path due to an<br>
 invisible wall. After entering it, they can fall. The red stone will disappear if<br>
 it collides with the player. Players will get a game over if they fall.<br>
 
 Goal Area:<br>
 When the player touches the blue goal line, the canyon path disappears. The player<br>
 gets a Game Win if they touch the blue goal pad.<br>


Assets used:

Grass and flowers models + materials: "Flowers/Grass Plants" by NEON3D<br>
Gunshot/Bullet Hit noises: "Free Sound Effects Pack" by Olivier Girardot<br>
Gun Model + material: "Guns Pack: Low Poly Guns Collection" by Fun Assets<br>
Camera Modes/Movement: "MS Advanced Camera Controller" by Marcos Schultz<br>
Ground Material/Textures: "Yughues Free Ground Materials" by Nobiax / Yughes<br>
Victory Sound: "Free music and SFX collection" by Alchemy Studio Music<br>