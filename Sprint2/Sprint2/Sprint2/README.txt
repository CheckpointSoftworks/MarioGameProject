Sprint 6
Team 6
JONATHAN MILLER
MATTHEW	MOHR
IAN	WEBER
SCOTT WEDDENDORF
KRISTOPHER WENGER

REQUIRED FONTS:
BasicArial
	should be preinstalled on the computer

SuperMarioWorld font
	found here:http://www.dafont.com/super-mario-world.font
	Install into computer's reqular font folder in order to run game.

Segoe UI Mono
	should be preinstalled on the computer

Required Sounds:
	Should all be packaged with the game, and not need outside sources

Automated Testing:
Automated testing is done in the testing class and prints to the console if it passed or failed and which test it was.

Notes:
	The Analyzer says to review the unused parameters of the program.cs, file in 
	that args was never used the team opted, not to change this because it is part
	of the program file, and standard setup.
	
	The analyzer said not to make instance fields visible in the levelStorage class the team 
	decided to keep them as public and not as property to allow them to be accessed elsewhere as 
	they are needed to be.  The team also choose not to make them properties because the lists 
	needed to change when loaded so it wouldn’t make sense to have them as read only properties
	which the analyzer wants collections to be. 

	The analyzer said to mark assemblies with CLSCompliantAttributes.  The team was unsure what this
	meant or how to comply with the analyzer on this so the change was not made.

	The analyzer said not to dispose of objects multiple times when refering to the levelfile in levelLoader.
	The team did not make this change becuase the team did not believe that the change needed to be made.
	This is becuase of the functionality of the levelLoader class.

	The analyzer said to use properties for the enemies's rigid bodies, however, to keep coupling low the team decided to stick
	with using methods to return the rigidbody instead.

	The analyzer said to make all of camera's private fields and methods into properties, but in order to keep low coupling the
	team decided to keep the fields private and have them accessed through methods instead.

	Tha analyzer said to make some of mario's methods into properties instead but we believe that methods have lower coupling, so we
	keep them as methods.

	Tha anaylzer said to remove a boolean in the pipe class but it is used, it is set.

	The Analyzer said to avoid excessive complexity for the levelLoader file, but since levelLoading is doing the parsing of our xml,
	the team decided it was better to keep it all together.

	The Analyzer said that non-constant fields should not be visible in the utility class, however, because those valuse never, change, but cannot
	be declared as constants becuase of their types, the team decided to leave them as static fields instead, so that they 
	can be accessed where they are needed.

Controls:
Mario:
arrow keys for left/right/crouch movement
z key for jumping
x key for fireballs
c key for iceballs
s key for sprinting
r key for resetting level
p key for pausing
q key for quiting

GamePad Mappings:

Left Joystick for left/right/crouch/jump movement
A key for sprinting
X key for fireballs
B key for iceballs
Start for pausing

FEATURES ADDED FOR SPRINT 6:

Statistics and end game scoring - MATT MOHR
	Added all files found in the Stats subfolder of the Scoring and Stats folder.
	Stats are dividied into four types: Collectable, Count-Int, Count-Double, and Time
		Collectable stats are given a total possible values and keeps track of the total of that stat in a static value (TotalAvailable). Eg: CoinStats keeps track of all coins in the level and PlayerStatManager.CoinStats tracks how many coins the player has gotten
		Count-Int and Count-Double keep track of events and timespans, respectively. They only tick up and may contain rations. Eg: PlayerActionStatManager.JumpCount keeps track of the number of times the player jumped and PlayerActionStatManager.AirTime keeps track of how much time the player was in the air
		Time is a special kind of Count-Double that tracks death times and win times, displaying them at the end
	Mario has a reference to PlayerStatManager and PlayerActionStatManager, arrays of listeners to the Stats listener-observer pattern. 
		Eg: When Mario shoots a fireball, the PlayerActionStatManager is notified. When the fireball connects with an enemy, it is notified again. At the end, a shot accuracy is calculated.
	When mario dies, a list of collectables is displayed so the player knows how many enemies and items are available and how many they got in the last session.
	At the end of a level, stats are automatically generated on the string in the DrawTotals() method. 
		PlayerStatManager and PlayerStatActionManager has a fixed number of stats because the enemies and collectables use static class properties.
		TimeStat's information is automatically generated based on a list of death times and succesful level completion times.
	The only coupling involved in the new stats are in the DrawTotals method, which require spritebatches and fonts to properly rend the strings they generate.
	Cohesion is very high. Most methods in the new classes are single-line methods. The only exception, again, is DrawTotals, but for good reason.
	At the end of gameplay, relevant information is written to a file in bin/x86/Debug/GameRecords.txt

Achievements and Enemy Spawner - Kris Wenger

**IMPORTANT NOTE A GAME DESIGN DECISION MEANS THE GAME PAUSES AFTER AND ACHIEVEMENT IS OBTAINED**
**EXCEPT FOR DYING AND FINISHING THE LEVEL**

	Added all files under the achievement folder, added the enemy spawner class under the Environmental Object Classes subfolder of the Environment,
	the GoombaEnemySpawnerSprite and KoopaEnemySpawnerSprite classes under the Environmental Sprite Classes subfolder of the Environmental Classes, 
	and added the AchievementPuase class to the Level State Alterations folder.  I also added custom sprites based off the default pipe sprites for
	both types of enemy spawners, these can be found in the content part of the solution.

	There are twelve different achievements.  There are those revolving around level transitions, such as going to the underground area or finishing the level.
	Those which are based on Mario colliding with certain objects, such as the different power up items or killing an enemy.

	The achievement system has two components the manager, which deals with the displaying the pop-up message box for each achievement, and pausing the game when a
	player gets an achievement so they can take their time to get back into to their game whenever they are ready.  The manager also deals with loading and saving 
	the achievements to an external file found in the bin/x86/Debug folder of the solution.  The second component was created to help keep coupling between classes low,
	this class the Achievement event tracker, has a reference to the achievement manager, and is static so it can be called in any class without being first instantiated.
	This class is triggered when an event corresponding to an achievement is triggered to then call the achievement manager to have the proper logic for that achievement.
	It is also implemented to allow for testing to occur without having the achievements occur.

	The achievement system works by having the player complete certain events, if these events are completed the achievement manager pauses the game for the player, 
	displays a pop-up message box displaying which achievement was earned.  The game is left paused till the player decides to un-pause the game themselves, 
	the exception to this being the dying achievement which does not pause the game and the level finishing achievement which does not pause the ending sequence.  
	This design choice was made for a few reasons, the first was to allow the player ample time after getting their achievement to process where they were in the game
	and get ready to continue from that spot.  The second main reason was to pervent any glitches from where the pop-up message pauses the game.
	Also at the end of the level or whenever a player dies, or the game is quit by command, the achievements are saved to an external file, as stated above.  
	Then whenever the game is started again it remembers which achievements the player had.

	The enemy spawners work like environmental objects, except they have added methods which tell if they are to spawn enemies, the timer is set to spawn enemies in a
	manageable time set, and it can be changed easily through the utility class.  The logic for spawning enemies happens in the levelStorage class, since it handles the
	updating of all the different objects on the level.  The game checks to see if the spawners are on screen, if they are, it checks to see if it is time to spawn an enemy,
	if it is it adds the new enemy to the enemies array list.  The all of this is done through method calls to the enemy spawner, except for the actual placing the enemy in
	the array list that is done in the level store class.

	I believe for both of my new additions the coupling is low, achievement manager only knows about its own things, having no outside class calls, the only thing it relies
	on are in its write method it relies on a sent stream writer.  The enemy spawner classes have a reasonable amount of coupling also since enemy spawner knows about its sprite,
	and the sprites both use the animated sprite helper class.  Both of the sprite also use the texture storage to obtain their texture 2d.  In terms of cohesion I believe the 
	cohesion for the created classes is high, because all the achievement manager class handles is reading/writing and displaying achievements.  The spawner handles the logic 
	for spawning an enemy depending on if it is a goomba or koopa spawner.  Most methods in both classes are under ten lines, the only execption being the reading and writing
	methods for achievements.

Ice Mario State, Iceball Power, and Ice Flower - Jonathan Miller

	Ice Mario, Iceball, and Ice Flower sprites were custom made using GIMP. Ice Mario state logic was added along with 
	new ShootMarioIceball, Iceball, IceballSprite, IceFlower, IceFlowerSprite, QuestionIceFlower, 
	QuestionIceFlowerCommand, MarioIceFlowerCollisionCommand, IceballCommand, NoIceCommand, and ProjectileTypeEnum 
	classes were added to the project. Mario's state transition logic was updated to include the Ice Mario state.
	EndingSequenceMario and EndingSequenceMarioSprite was updated for the Ice Mario state. Collision handlers were
	updated for the added objects. Commands were added for collision between the new objects. Other general commands 
	were added/updated for the new objects. The enemy classes were updated to include new logic for when the Iceball 
	strikes them. They stop moving and they change color while they are in a frozen state, then return to normal when 
	the frozen timer runs out. Texture storages and sprite factories were updated for the new sprite sheets. 
	Interfaces were updated to include new methods or states. New numbers and strings were added to the Utility class 
	for the new classes to use. The LevelLoader and LevelStorage classes were updated for the new objects. The 
	Level.xml file was updated to add the new objects to the level. Controls were updated for shooting the Iceball.

Alternate Cameras - Scott Weddendorf
	Five new alternate camera modes are now available and are found in the CameraClasses>Types folder.  New Keyboard
	commands were created to allow camera type to change during gameplay.  The camera type can be changed at any time
	using numpad 0-5.
		Numpad 0, Original Camera - This changes the camera to the original camera mode that moves with Mario's
			movement when Mario moves past the center of the screen.
		Numpad 1, Classic Camera - This camera mode more closely resembles the camera of the original Mario game as
			it moves right slowly as Mario moves right until Mario moves past the middle of the screen in which the
			camera moves right with Mario's movement.
		Numpad 2, Shaky Camera - This new camera adds a shake feature that shakes the camera when mario takes damage.
			This new feature can also easily be implemented to shake for any condition by simply calling the shake 
			method found in the class.
		Numpad 3, Drunk Camera - A dissorienting camera that moves back and forth constantly during gameplay.  The 
			speed at which the camera moves and the distance it moves back and forth can be set during initialization.
		Numpad 4, Movable Camera - This camera mode is specific to the gamepad.  The camera will move left or right
			a certain distance based on the position of the right analog stick on the gamepad.
		Numpad 5, AutoScrolling Camera - A simple camera mode that scrolls right at a speed specified at initialization.
			The Mario can not affect the position of the camera at any point.

Skyworld Hidden Level Area - Ian Weber

	A new hidden area of the level was added including all new sprites and background image.  The area mimics the hidden skyworld
	common in the Mario series where Mario can climb up a hidden vine to reach it.  Transition logic was added both to and from the 
	skyworld, as well as logic for making the vine appear when the specific box is hit.  New sounds were added for the skyworld such
	as the vine appearing sound and new music.  Enemies and obstacles and the new area itself were added to the skyworld in the XML file,
	levelloader was updated to work with all the new object types.  New objects include IceCloud, IceSmileyCloud, IceBridge, Vine(s), IcePipe.

	TO ACCESS THE SKYWORLD: hit the coinblock on top of the pyramid like structure at the beginning of the level.  Then, a vine
	will appear and reach to the top of the screen.  Stand on top of the block and press the jump command.  Mario will begin climbing up
	the vine until he dissappears, then he will appear in the skyworld.  To exit the skyworld, walk through it to the end and go down
	the IcePipe by standing on top of it and pressing the crouch command.  Mario will go down the IcePipe and reappear falling back to
	the main level.