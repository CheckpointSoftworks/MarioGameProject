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

In game1.cs the analyzer said for all the public fields not to declare them as public,
	however becuase of the need to change these fields in other parts
	of the game, i.e. changing mario's or the blocks' states, the team
	opted to leave them as public fields to keep the game working.

	Controls:
Mario:
up/w = change mario to an idle state if he was in a crouching state and a jumping state if he was not.
down/s = change mario to an idle state if he was jumping state and a crouching state if he was not.
left/a = change mario between left running, left idle
right/d = change mario between right idle, and right running.
y should change mario to a small state.
u should change mario to a big state.
i should change mario to a fire state.
o should change mario to a dead state.
For different types of blocks:
z = Question block turns into used block
x = Brick block disappears
c = Hidden block turns into used block
r=reset everything back to its initial state.