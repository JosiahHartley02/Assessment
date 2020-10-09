To access this game, first download the file from https://github.com/Snositi/Assessment/releases/tag/v1.0
- click Assets under Text Based Fighting Game
- click October.2nd.Game.Programming.Assesment.rar
--should download zip
-drag zip somewhere rememberable
- right click this zip and press extract files
- double click HelloWorld.exe
- game should now be running
--------------------------------------------------ChangeLog-----------------------------------------------
I was given two notes on the flaws of my original program, 1, not enough polymorphism, and 2, failed to load
due to a missing save file, I have both added multiple uses of polymorphism for entities attacks and printing
stats, I also gave the Wizard the ability to polymorph enemies because I thought that was funny, even more 
polymorphism, I have also made it so if there is no save file found, the option will not display whatsoever,
and trying to select that option while its not visible does not work.

-Fixed Missing Save File Crash
-Changed Attack to virtual void / override void
-Changed BlindAttack to virtual void / override void
-Added ManaAttack for mage players
-Added Max Mana Values
-Added Wizard Abilities
-Added more Enemies
-Player can now sell items to the shop
-resting at the campfire will regen your mana.

