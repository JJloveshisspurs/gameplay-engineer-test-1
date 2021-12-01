# Gameplay Engineer Test

Name: Jonathan Jennings

When the game starts a random assigned picks whether O's or X's goes first  . 

The game infrastructure is broken up into 2 central parts 

Game Manager - Controls user interface , display / hiding of dialogs, manages game states

Game Data controls game specific aspetcs such as turn, evalutes winning patterns,  and manages the switching of turns


I didn't have time but the outstanding tasks I had was the actual data Serialization and restoration upon reload , 
I turned my entire game data class into a serializable sript and would have handled it by serializing the Game data into a
json class and all of it's members including the list of Markers and their values. Then wrote that serialized json class into player prefs .


Upon reload The game manager would have re-assigned my central Game data and the game board list   with the stored Json data and all the 
 the Marker buttons would have been set with the data  from my current game board which would have successfully restored the player turn, marker positions, 
and would have incremented the win tallies ( which i didn't get to set) . 

Ideally i would have also had a "Clear game data" button as well .


