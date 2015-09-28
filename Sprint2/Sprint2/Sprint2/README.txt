Sprint 2
Team 6
JONATHAN MILLER
MATTHEW	MOHR
IAN	WEBER
SCOTT WEDDENDORF
KRISTOPHER WENGER

Notes
MarioSpriteFactory.cs contains several comments, but these have been left in the code. This solution will be reused later, and the commented lines refer to statuses that will be implemented later on(fireball, flagpole, etc).

The Analyzer says to review the unused parameters of the the program.cs, file
	in that args was never used the the team opted, not to change this
	because it is part of the program file, and standard setup.

The Anaylzer said for game1.cs to avoid unused private fields refering, to the
	graphics machine, however the team opted to leave this because
	it part of the game's template and removing it the team fears, it
	would break the game.

In game1.cs the analyzer said for all the public fields not declare them as public,
	however becuase of the need to change these fields in other parts
	of the game, i.e. changing mario's or the blocks' states, the team
	opted to leave them as public fields.