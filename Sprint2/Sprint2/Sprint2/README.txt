Sprint 5
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
	Added all files under the achievement folder, added the enemy spawner class under the Enviromental Object Classes subfolder of the Enviromental

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
