# GDIM33 Vertical Slice
## Milestone 1 Devlog

### Q1

I use a visual scripting graph to handle the collision detection of the grenade and destroying it once its collected. I use an ontriggerenter node to detect the collision with the player object, and identify that it's the player by using the compare tag node. I have it set so that if comparetag returns true, I destroy the object. I also have it alert the inventory object using a custom event that an item has been collected, changing its state (which is in a graph in the inventory object) from "empty" to "has item"

### Q2

I use a state graph to control the animations in my game. My game is a sidescroller, but you can still press the forward key to go faster than the base speed. I made a state machine that connects to the animator. I had the game start in the walk state, which is when the player is moving at the base speed, and the player isn't using D or the right arrow. I made a transition that gets triggered when the player holds either the D key or the right arrow, to change into the run state, and the run animation will play. For the transition back to the walk state, I had it get triggered when the player lifts either key.

![alt text](<Screenshot 2026-04-28 231416.png>)

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets

- [Player](https://www.gameart2d.com/cute-girl-free-sprites.html)
- [Background and platforms](https://www.gameart2d.com/free-graveyard-platformer-tileset.html)
