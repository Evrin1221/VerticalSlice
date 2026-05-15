# GDIM33 Vertical Slice
## Milestone 1 Devlog

### Q1

I use a visual scripting graph to handle the collision detection of the grenade and destroying it once its collected. I use an ontriggerenter node to detect the collision with the player object, and identify that it's the player by using the compare tag node. I have it set so that if comparetag returns true, I destroy the object. I also have it alert the inventory object using a custom event that an item has been collected, changing its state (which is in a graph in the inventory object) from "empty" to "has item"

### Q2

I use a state graph to control the animations in my game. My game is a sidescroller, but you can still press the forward key to go faster than the base speed. I made a state machine that connects to the animator. I had the game start in the walk state, which is when the player is moving at the base speed, and the player isn't using D or the right arrow. I made a transition that gets triggered when the player holds either the D key or the right arrow, to change into the run state, and the run animation will play. For the transition back to the walk state, I had it get triggered when the player lifts either key.

I also plan on using state machines to respond to the different UI health levels when I add it in the future. 

![alt text](<Screenshot 2026-04-28 231416.png>)

In my new breakdown I added another circle to represent my tilemap system. I have everything that is stationary on separate tilemaps on a singular grid (ground, platforms, collectables etc). This is so that I don't have to add my autoscroller script to every stationary category I have, but instead I can just apply it to the entire grid. I thought since this is almost a framework for how I will have to separate my code depending on which sorting categories everything is on, it would be useful to have it included in my breakdown. 

## Milestone 2 Devlog

### Q1

The UI and state machine that responds to how much sanity and awakeness the player has

- Make public values for current sanity and current awakeness
    - gonna need a set max value for each so I can get a health bar that changes depending on the percentage (private)
    - current levels (public)
- Make state machines for each
    - One each. divide it into 4-5 stages. each state gets triggered by the levels (o god visual scripting)
- Add the buffs/nerfs for each state
    - make an array of stuff to apply. make them inherit from the same class with a difficulty level property (scriptable objects maybe)
    - have a few of them spawn randomy depending on the sanity/awakeness bar value

### Q2

Yes it definitely did help because it helped me identify the parts I couldn't do by myself, which allowed me to schedule time to get help because I knew exactly what I needed help on. It also set up a system that would be heavily integrated later on when I add more visual effects.

The one from W5 was also a huge help because the script it describes is really long and complex, but by having that one script, when I add more enemy variations I literally just need to add them and there's no more code involved. If I'd gone into it with no planning the structure would've been impossible to scale.

### Q3

One instance I used visual scripting was to handle the nerfs depending on the players sanity. I use C# methods in visual scripting in order to get a public value in code that stores the players sanity (in playerstate script), and I have it enter a "nerf" stage (in this version, when the sanity goes down to 90, the controls get reversed). upon entering the state at sanity 90, the graph calls a c# method in the nerfmanager script that reverses the controls. 

![alt text](<Screenshot 2026-05-14 222044.png>)
![alt text](<Screenshot 2026-05-14 222058.png>)

### Q4

I use tilemaps and animator. The entire thing is grid based, and the player has a running and jumping animation, and the eye enemy has 3 distinct animations, moving, attack start, and attacking. 


## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets

- [Player](https://www.gameart2d.com/cute-girl-free-sprites.html)
- [Background and platforms](https://www.gameart2d.com/free-graveyard-platformer-tileset.html)
