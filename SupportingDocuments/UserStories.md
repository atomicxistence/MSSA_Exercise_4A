# User Stories 

- Player sees game menu and can select options
- Player start new game (or continues saved game?)
- In a new game the player selects a ship (default ship or select one?)
- Game generates planets and economy 
  - I will create 10 ores 
  - I will create 14 planets (2 refuel only)
  - Each planet will offer 5 Ores for sale and 5 in demand (fixed pricing?) 
- Player sees narrative and then is presented with a map showing planets within range 
- Ship is given initial inventory and budget (let user select inventory?)

### START GAME LOOP

  - Ship receives reports from WeyLand with Market info 
    - Planet with details: description, distance etc 
    - In demand and offered ores
    - (hostility?)
  - Player select planet to go to 
  - Ship calculates trip details, players confirms and leaves current location (animation?)
  - (Game generates raid and updates economy?)
     - If raided, ship can fight (wins depending on weapon system power) 
     - or flee (looses % of fuel, or get raided anyway)) 
  - Ship arrives to planet, lands and receive welcome brief, planet display market details:
    - Ores in demand and ores offered
    - Fuel (fixed price)
    - Upgrade (Engine, Weapons and or Capacity)
  - Ship selects whether to buy or sell, then selects ore, transaction happens 
  - Player opens map, displays planets within range, and receives new market report 

### END GAME LOOP

- Ship travel rules: 
  - Higher travel speed negatively affects fuel consumption 
  - (Having the most powerful weapons negatively affects speed and capacity?)
  
- Planet trade rules:
  - a planet will not buy ores it sells
  - not all planets will offer upgrades (or fuel?)
  
  ### Trend Reports  
  
  * Ore Name (x10)
  * Top 3 Planets - Lowest Price Selling
    * Planet Name
    * Planet Distance
    * Planet Price
  * Top 3 Planets - Highest Price Buying
    * Planet Name
    * Planet Distance
    * Planet Price
  
