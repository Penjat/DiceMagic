Before starting any project, I always make a plan.
For this I knew I wanted a MainManager and a Gameplay manager, and then could have other subscripts to manage keeping track of the score and the menu system.
I often set up delegate patterns between managers to de-couple the code but for this project that didn't seem necessary.

I opted to use the physics to emulate the dice roll.
Animations seemed like they would become stale on repeat play throughs.
The dice have their direction and force somewhat randomized.
I increased the rate of gravity to better suit the type of physics a user would expect from dice.
Further tweaking could make them behave and roll more like real dice.

I was capable of adding textures to the dice and having them calculate based on which side is up.
I reasoned that this would be tricky to implement with the option to 'fix' the game on the 5th roll so I decided for a more stylized look to the dice.
I thought back to 'gunstar heroes' to the dice level, where the dice only reveals its value after it has come to a stop.

After the dice have come to a complete stop, the dice display their values with a world space canvas.
In the past I have had troubles with objects not coming to a complete stop with unity physics, [Vector2(0,0,0.0000000001)] but in all of my tests for this project it was not an issue.
There is a simple fix to this problem if it occurs.

With any turn based game, I have found it very important to leave time or animate between states.
I added wait time after the dice come to a rest to allow the user to take in the results.
I created the scoreboard with a world space canvas.

I decided to go with a black and white color scheme with splashes of bright colors.
I have learned first hand that a good font can really make a project pop.
I grabbed a couple of my favorite fonts and ended up giving it a bit of a minimalist/retro feel.

I added a particle system pointed at the camera to give a little movement and color.

A great addition would be for the player to roll more than 2 dice.  That way there would be a greater risk (more chances of doubles) but also a greater reward (higher score).
I have experience producing music and sound effects and I would have loved to dig in on this project.
