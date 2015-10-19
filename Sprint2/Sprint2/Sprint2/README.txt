Sprint 3
Team 6
JONATHAN MILLER
MATTHEW	MOHR
IAN	WEBER
SCOTT WEDDENDORF
KRISTOPHER WENGER

Notes:
	The Analyzer says to review the unused parameters of the program.cs, file in 
	that args was never used the team opted, not to change this because it is part
	of the program file, and standard setup.
	
	The analyzer said to make all of the handle collision methods static.
	The reason none of the collision handler's handle collision methods were marked
	as static is because they need to be accessed in other areas.  And marking them
	as static makes it so they cannot be accesed as easily as a normal public void method.
	
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

Controls:
Mario:
	up/w or left-thumbstick up= to move Mario up.
	down/s or left-thumbstick down= to move Mario down.
	left/a or left-thumbstick left= to move mario left.
	right/d or left-thumbstick right= to move mario right.

	Diagonal Movement Commands are a cominbation of normal movement commands or 
	diagonal on the left-thumbstick in desired direction.
