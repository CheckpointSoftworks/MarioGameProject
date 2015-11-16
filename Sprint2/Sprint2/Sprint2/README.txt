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

	The Analyzer said to avoid excessive complexity for the levelLoader file, but since levelLoading is doing the parsing of our xml,
	the team decided it was better to keep it all together.

	The Analyzer said that non-constant fields should not be visible in the utility class, however, because those valuse never, change, but cannot
	be declared as constants, the team decided to leave them as static fields instead, so that they can be accessed where they are needed.

Controls:
Mario:
arrow keys for left/right/crouch movement
z key for jumping
x key for fireballs
s key for sprinting
r key for resetting level
p key for pausing
q key for quiting

GamePad Mappings

left joystick for left/right/crouch/jump movement
a key for sprinting
x key for fireballs
start for pausing