# Shadow

I made Shadow out of the desire for a solution for controlling my mule.  I like to keep my mule perfectly aligned with my main in terms of missions/quests/other content completed.  However, even with Ashita in the mix giving me the ability to easily switch between windows, I found it cumbersome to work my way through content.  Navigating menus, interacting with things, and generally walking around in the game was difficult with two characters.

Shadow is not meant to function as a buff or combat bot - while it will follow your main into combat and melee your target, that's all it'll do!  There's way too much to manage in the game for spells/abilities to be implemented in Shadow.  In the future I might implement a combat scripting system, but I make no promises.

## Currently implemented functionality

* Follow
  * The follow functionality is as intelligent as I could make it.  It maintains a queue of the master's location and follows the end of the queue.  Thus, it can accurately follow without latency being a factor, and it doesn't look suspicious to an outside observer.  (a master and a follower running around perfectly in sync is suspicious...)
  * Also implemented is a smart-zone routine - if the master changes zones and the slave runs out of points in the queue, it will move forward in an attempt to change zones.
* Attack
  * The slave will initiate melee combat if the master does, and will keep the target in range and in front of it.
* Mount
  * The slave will mount/dismount when the master does.  It will use the mount specified in Shadow.
* Stealth
  * The slave will use spectral jig or sneak/invisible to match the master's stealth buffs.  
  * If cancel is enabled, it will also drop sneak/invisible when the master does.  This requires that the corresponding addon - Cancel (Windower) or Debuff (Ashita) - be installed.
* NPC Interaction
  * If enabled, Shadow will interact with the same object as the master when the master begins a cutscene.  Best combined with cutscene management addons like Enternity and/or FastCS.
  * If enabled, Shadow will attempt to follow the master through menu options.  Notable limitations: Shadow does not know when you select a menu option on the master, so it simply keeps your menu index synced and hits "enter" when it notices the master changed to a different menu.  So, it is important to keep menus the same on both characters - for example you will need to try to make sure you have the same home points unlocked on both characters, or the menu will be different and you won't be selecting the same destination on the slave.  It is also usually best to use the exit options in menus (i.e. "On second thought, never mind.") instead of just hitting escape on your main.
* Abyssea Box opening
  * If the slave has keys in its inventory, it will automatically approach and open boxes it sees within 10 yalms based on color.  Only blue and red are implemented, as gold boxes have to be looted manually. 
 