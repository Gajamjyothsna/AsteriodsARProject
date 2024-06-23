# AsteriodsARProject
This is an Asteroids AR Project. In this game, players will be in an outer space scene, protecting Earth from incoming asteroids and UFO saucers. Players can earn points and mystery prizes for destroying them.

## **Game Objective**
 The objective of the game is to destroy the asteroids and UFOs. Shooting a large asteroid breaks the asteroid into two medium sized asteroids. Shooting one of those pieces breaks it into two small asteroids. 
 Asteroids will travel towards the Earth behind the Player with a small direction offset. Asteroids can damage the player and Earth. If the player's or Earth’s life reaches zero, then the game is over.

## **Gameplay**
 ### **Scoring**
 Players will earn the following scores upon destroying the asteroids and UFO saucers:
 - SmallAsteroid = 100
 - MediumAsteroid=50
 - LargeAsteroid = 20
 - UFO=100

 ### Player mechanics
 - The camera’s view is the player, with the Earth appearing behind the player.
 - Asteroids will spawn in front of the player and traverse towards the Earth.
 - Players can move and rotate the phone to aim at asteroids.
 - Playervshoots by tapping the screen. An unlimited number of bullets are created at the center of the screen and will travel in a straight line from the direction of the shooter.
 - If asteroids reach the camera (player’s view) then they will damage the player.
 - Players will lose a small amount of health each time an asteroid damages the player, and a health bar will indicate the player’s remaining health
   
 ### Earth
 - Is a large sphere behind the player.
 - Asteroids will damage the Earth if they crash into it, with smaller asteroids causing less damage than larger asteroids.
 - The Earth’s health bar will appear on the screen.
 - If the Earth is destroyed (reaches 0), the “game over” screen displays.
 
 ### Asteroids
 - Asteroids spawn on the opposite side of the Earth. Vertical spawning is limited to prevent asteroids from appearing too high or too low.
 - Asteroids movetowards Earth after spawning.
 - Large and medium asteroids are split when they are hit.
 - Asteroids are destroyed when they reach the player’s view (the camera’s position), damaging the player.
 - Asteroids also are destroyed when they damage the Earth or are hit by a player’s bullet.

### UFO
 - The UFO will spawn in a randomposition infront of the originalplayer position.
 - Each UFO traverses the player’s eyesight.
 - The UFO shoots bullets towards the player.These bullets can’t be destroyed,they will always damage the player if they hit.
 - The UFO can be destroyed by bullets.
 - When a UFO is destroyed,a mysterybox will appear in the scene for 10 seconds. If the player destroys the mysterybox,this box will release a recovery 
   HealthItem that will start moving towards the player. When this item touches the player,a small amount of player health will be gained.

 ### Userinterface
 - Healthbar indicating remaining life of Player
 - Healthbar indicating remaining life of Earth
 - Score amount
