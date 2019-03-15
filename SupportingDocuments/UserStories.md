# User Stories 

- Player sees game menu and can select options
- Player start new game or continues saved game
- In a new game the player selects a ship (default ship)
- Game generates planets and economy 
  - I will create 9 ores 
  - I will create 10 planets 
  - Each planet will offer 3 Ores for sale and 3 in demand, pricing fixed 
- Player sees narrative and then is presented with a map showing planets within range 
- Ship is given initial inventory and budget (maybe let user select inventory later on...)
(START GAME LOOP)
- Ship receives reports from WeyLand with Market info (planet with details and top in demand ores, also hostility of route)
- Player select planet to got to 
- Ship calculates trip details, players confirms and leaves current location (animation)
- (Game generates raid if applicable, and updates economy at planet)
   - If raided, ship can fight (wins depending on weapon system and strength of raider) 
     or flee (looses % of fuel, or get raided anyway)) 
- Ship arrives to planet, lands and receive welcome brief, planet display market details:
  - Ores in demand and ores offered
  - Fuel (fixed price)
  - Upgrade (Engine, Weapons and or Capacity)
- Ship selects whether to buy or sell, then selects ore, transaction happens 
- Player opens map, displays planets within range, and receives new market report 
(END GAME LOOP)

- Ship trade offs: 
  - Having the most powerful weapons negatively affects speed and capacity
  - Having Top Engine negatively affects fuel consumption
  
- Planet trade rules:
  - a planet will not buy ores it sells
  - not all planets will have fuel or upgrades  