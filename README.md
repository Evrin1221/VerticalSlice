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


1. 

The gameplay loop: you traverse the autoscroller 2d plaformer challenge. at points of the game (narratively, the ritual) you have to mark the arm you decided in the beginning of the game is the "correct" arm. by the end of the challenge your score is the number of times you marked the correct arm out of the total times you were prompted to mark the arm. Throughout the challenge, bad performance (taking damage, shown by the sanity levels) is punished by stacked nerfs, and good performance (killing enemies, shown by awakeness levels) is rewarded with stacked buffs. In my game pitch the checkpoints were slightly different areas w different enemies etc. In order to condense this, my vertical slice shows all of the collectables (health potions and grenades), the nerf/buff system, an enemy type that follows a spawning system that scales easily. Throughout the existing platforming challenge, the arm marking UI comes up accordingly, and by the end of this very condensed version you get a total score. This illustrates the broad concept of the player because the full game is essentially the same but with more variety in visual effects, enemies, etc. it keeps the essence of the platforming challenge and scrambling for the mouse to click the arm.




2. 

This is the shader I used. It is activated when the player goes below 80 sanity and makes the screen all wobbly. It takes the amount of time passed by the speed, and puts it through a sine graph so it wobbles back and forth. We then take the entire screen view and put it through the offset node to offset the entire thing by the value calculated earlier. This is also lerped so that the value change doesnt look snappy and flows like water. In code, I adjust the blend value of the shader to change its intensity depending on the player's sanity. I simply have the blend value at 0 in the beginning and increase it whenever I nerf the player more. 

![alt text](<Screenshot 2026-05-28 215225.png>)![alt text](<Screenshot 2026-05-28 215234.png>)![alt text](<Screenshot 2026-05-28 215242.png>)






3. 

I typically separate everything into "types". Basically I like to think about which tags I need to make, and base things off of that. I try to separate everything as much as possible, for example UI should only do text, and take info from a separate health and inventory script. Sound should be dealt in a different script etc. My general rule of thumb is too many scripts is better than no scripts because I've found that combining stuff is way easier than separating stuff. Then I start with the things I can't function without. usually player movement. then I play the game, and see what's missing that stops me from progressing the most, then I work on that. 

I don't think I'll use the bubble diagram because visually it looks messy and confusing to me especially when we're dealing with scripts with hundreds of lines of code (I had a few of those and bubble diagraming them would drive me insane) but i do like the idea of separating everything into systems. so I think maybe I'll do something similar, like a bullet point list with headers. 

While breaking stuff down you can realize that there's a lot more to a singular system than it sounds when you just say there's a "something" system. For example, originally I was hoping to add more enemy variations then I noticed my singular enemy system required a state machine with 4 different states, tons of member variables and took way longer than I expected. I could've realized this earlier if I broke it down in more detail. 

Although sometimes it's hard to think of how a system should be done until you actually start coding it, I think it might be helpful to even draw smaller diagrams for systems halfway through coding to understand that system in particular in more detail, which is something the bubble diagrams miss, because it focuses more on how different systems interact. 

I think I definitely need to be stricter about separating scripts. If a script is called one thing, the only thing it should be doing is that thing. However, I think my process on deciding what needs to be done next worked in my favor for this project, so I'll keep doing that. 

## Open-source assets

- [Player](https://www.gameart2d.com/cute-girl-free-sprites.html)
- [Background and platforms](https://www.gameart2d.com/free-graveyard-platformer-tileset.html)



