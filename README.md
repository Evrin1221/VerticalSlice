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

### Q1

![alt text](<Screenshot 2026-05-28 215225.png>)![alt text](<Screenshot 2026-05-28 215234.png>)![alt text](<Screenshot 2026-05-28 215242.png>)

This is a full screen effect shader. It takes the amount of time passed multiplied by speed, then puts the whole thing through a sine graph so that we have the back and forth effect. Then we offset the rendering of everything in view by that value using the offset node. we also put it through the lerp node so it interpolates and everything looks smooth. This change is visible when you go below 80 sanity, and gets stronger if you go below 70.

### Q2

One bit of feedback was that there needs to be more visual indicator that shows when something is happening (referring to the reversed control animation that was buggy during last playtest). this has been fixed, and the new nerfs I've added are very obvious visually

### Q3

Since last milestone, I have added two more nerfs, an awakeness bar that increases every time you hit an enemy, one buff (speed up) when your awakeness hits a certain point, health potions that recover your sanity, a basic melee attack. All of the mechanics to play the basic loop is done, only thing left being more enemy variations, which just need to be assets as the system for spawning is all set up. Only thing left is the arm marking mechanic at the end of a checkpoint. 



## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Briefly describe your core gameplay loop and the content we can find in your game. Then, relate the gameplay and content you implemented back to your original plan for creating a Vertical Slice: how does this gameplay and content illustrate to the player what the full game would be like?

In about a paragraph, describe how your rendering effect is activated from gameplay logic. Either attach a screenshot of the relevant Graph OR cite the relevant C# file(s) so we can find them in your repo. Accurately describe your system with technical terms.

Describe your process for how you break down a large project into specific systems. If you don't have a process that works well for you right now, you must come up with an describe a viable plan.


Make sure to also answer ALL of these questions in your answer:
Do you plan on using either the bubble diagram break-downs and/or the task step break-downs we practiced this quarter in your planning process? Why or why not?
How does the process of breaking down a large project into small steps affect your understanding of the scope of the project?
How does the plan you're describing relate to your process of creating the Vertical Slice project? You can write about either how things went poorly and how you'd improve your process as a result, or about how things went well that you want to repeat.
## Open-source assets

- [Player](https://www.gameart2d.com/cute-girl-free-sprites.html)
- [Background and platforms](https://www.gameart2d.com/free-graveyard-platformer-tileset.html)



