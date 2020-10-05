
| Josiah Hartley|
| :---          	|
| s208046     	|
| Computer Programming |
| Text Pvp Documentation |

## I. Requirements

1. Description of Problem

	- **Name**: Computer Programming Project

	- **Problem Statement**: 
	You are to create an application or game that meets one of the provided application briefs, or application requirements as negotiated with your teacher

	- **Problem Specifications**:  
    A text based game written in c# that has variables, operators, expressions, sequesters, selectection, iteration, functions, at least two arrays, reading
    and writing to a text file, at least two classes with at least 4 instance variables per, multiple options for object construction, user defined aggregation,
    use of polymorphism and code documentation.


2. Input Information
- Num Char '1' - Selects option 1
- Num Char '2' - Selects option 2
- Num Char '3' - Selects option 3
- Num Char '4' - Selects option 4
- AnyKey     - Continues from a pause in code


1.  Output Information
- Player information is displayed often along with enemy stats when in combat
- Store shows what it has in store and the price of said item
   

## II. Design

 _System Architecture_

Main Game Flow
Because this applications purpose is to demonstrate my understanding of c#, it has a main game loop, a battle loop, and a shop loop, and a lose condition. Onc the program is started, players are introduced to the game. The program only closes when the player dies or when the console is closed.


### Object Information

   **File**: Game.cs

     
  **Attributes**

        Name: _junk
             Description: Place holder Item for player
             Type:Class Item.cs

        Name: _Empty Slot
             Description: Place Holder for inventory array positions to display lack of item
             Type: Class Item.cs

        Name: _damageNecklace
             Description: Increases players output data
             Type: Class Item.cs

        Name: _healthNecklace
             Description: Increases players max health
             Type: Class Item.cs
        Name: _sword
             Description: Increases players output data
             Type: Class Item.cs
        Name: _Shop
             Description: Sells Items to the player
             Type: Class Shop.cs
        Name: _player
             Description: The player, holds vital variables needed for saving and loading
             Type: Class Player.cs   
        Name: _gameOver
             Description: Has potential to activate the End function and close program
             Type: bool
        Name: _useOldSave
             Description: Has potential to activate introduction or continue from last save
             Type: bool
        Name: Start()
             Description: Runs important code needed before the main game
             Type: void
        Name: Update()
             Description: Loops until game over
             Type: void   
        Name: End()
             Description: Prints one final message before closing
             Type: void 
        Name: InitStore()
             Description: Sets items to shops inventory to be sold to the player
             Type: void 
        Name: ChooseCharacter()
             Description: Takes in input to select 1 of 4 characters
             Type: void 
        Name: MainMenu()
             Description: Switches between either load save or start new game
             Type: void 
        Name: Introduction()
             Description: Introduces plot before going to a battle loop
             Type: void 
        Name: TestForSaves()
             Description: Takes in input to select either to use a save or create new save
             Type: void 
        Name: ControlIntro()
             Description: Explains how input works.
             Type: void
        Name: FarEndOfThePit
             Description: Segregated for code consistency, begins a battle loop
             Type: void 
        Name: BattleLoop(Player player)
             Description: Player fights zombie until one or the other is dead
             Type: void 
        Name: HuntAnimal(Player player)
             Description: Player fights a small animal until one or the other is dead
             Type: void 
        Name: GenerateNumber(int min, int max)
             Description: Takes in two ints and returns a float between those numbers
             Type: float
        Name: GenerateNumber(int min, int max, bool integer)
             Description: Takes in two ints and a bool and returns an int between those numbers
             Type: int 
         Name: Death()
             Description: Prints one final message before setting gameOver true, goes to the End tap
             Type: void
         Name: MeetTheCamp()
             Description: Only purpose is to hold dialogue
             Type: void 
        Name: CampLife()
             Description: Main game loop, switches between shop, heal, save, or fight
             Type: void 
        Name: CampShop()
             Description: Loops selling player items until they leave
             Type: void 
        Name: RestArea()
             Description: Calls for player to regen 25 health or to MaxHealth
             Type: void 
        Name: Save()
             Description: Makes player save all their important data
             Type: void 
        Name: Load()
             Description: Makes player read all their important data from a SaveData.txt file
             Type: void 
        Name: GetInput(string option1, string option2, string option3, string option4, string query)
             Description: Takes in 5 strings, returns a char if the option if abailable
             Type: char
        Name: InitInventory()
             Description: Sets all items in players inventory as Empty Slot
             Type: void 
        Name: GetInput(Items option1, Items option2, Items option3, string option4, string query)
             Description: Takes in 3 Items for shop inv, and 2 strings to print a line and to leave, returns the char
             Type: char 
        Name: GetInput(string option1, string option2, string query)
             Description: takes in 3 strings for simple yes or no questions, returns the char
             Type: char 


**File**: Entity.cs

**Attributes**

         Name: _name
             Description: Hold's entity's name
             Type: string
          Name: _health
             Description: Hold's entity's health value
             Type: float
       Name: _baseDamage_
             Description: Hold's entity's base damage value
              Type:float 
       Name: _level
             Description: Hold's entity's level value
              Type:int 
        Name: _experience
             Description: Hold's entity's experience value
              Type:int 
       Name: _mana
             Description: Hold's entity's mana value
              Type:int 
       Name: _hasmana
             Description: tests if entity has mana
              Type: bool  
      Name: _EmptySlot
             Description: Placeholder value for entity's inventory
              Type:Class Item.cs 
       Name: Entity()
             Description: base constructor for basic entity
              Type: constructor 
       Name: (string nameVal, float healthVal, float damageVal, int levelVal)
             Description: Takes inname, health, damage, and level, for secondary base constructor 
              Type:constructor
       Name: GenerateNumber(int min, int max)
             Description: Takes in two ints and returns a float between those two values
              Type:float
       Name: GetName()
             Description: returns entity's name value
              Type:string
          Name: GetLevel()
             Description: returns entity's level value
              Type:int
          Name: GetBaseDamage()
             Description: returns entity's base damage value
              Type:float
          Name: GetExperience()
             Description: returns entity's experience values
              Type:float
          Name: GetHealth()
             Description: Returns entity's health value
              Type:float
          Name: GetMana()
             Description: Retuns entity's mana value
              Type:int
          Name: Attack(Entity target)
             Description: Calls for the target to subtract their health by the aggressors damage
              Type:void
          Name: BlindAttack(Entity target)
             Description: Takes in a target, generates a random hitchance number and subtracts targets health by agressors output damage +50%
              Type:void
          Name: TakeDamage(float damage)
             Description: Decrements entity's health by a desired damage value
              Type:void
**File**: Enemy.cs

**Attributes**

         Name: _isUndead
             Description: Will be used to add ability to Necromancer
             Type: bool

        Name: Enemy(string nameVal, int levelVal)
             Description: Takes in string name val and int level val to create a base enemy
             Type: constructor
          Name: PrintStats()
             Description: Displays Enemys Current Stats used for battle loop
             Type: void

**File**: Item.cs

**Attributes**

         Name: _name
             Description: holds the items displayable name value
             Type: string
          Name:_healthboost
             Description: holds the items max health bonus
             Type: float
          Name: _damageboost_
             Description: Holds the items damage boost value
             Type: float
           Name: _value
             Description: Holds the items gold value
             Type: int
          Name:Items()
             Description: Base constructor for item
             Type: constructor 
        Name: Items(string nameval, float healthBoostVal, float damageBoostVal, int valueVal)
             Description: creates an item with said values
             Type: constructor
          Name: Items(bool EmptySlot)
             Description: creates an item to be an Empty Slot
             Type: constructor
          Name:GetName()
             Description: returns Name value
             Type: string
          Name:GetValue()
             Description: returns gold value
             Type: int
          Name:GetDamageBoost()
             Description: returns Damage Value boost
             Type: float
          Name:GetHealthBoost()
             Description: returns health boost value
             Type: float

**File**: WildLife.cs


**Attributes**

         Name: WildLife(int AnimalNumber)
             Description: Creates an animal based on the animal value
             Type: constructor

   **File**: Shop.cs


    **Attributes**

        Name: _totalGold
             Description: Hold shops gold value
             Type: int
        Name: _ShopName
             Description: Holds shops name value
             Type: string
        Name: _shopClerkName_
             Description: Holds shop clerks name value
             Type: string
        Name: _inventory
             Description: holds the shops inventory
             Type: Class Item.cs array
        Name: Shop()
             Description: only constructor needed, takes in 3 items for the shops permanent inventory
             Type: constructor
        Name: CanAfford (Items itemchoice)
             Description: used to see if shop can afford a specific item and returns a true or false
             Type: bool
        Name: PrintInventory
             Description: Prints the shops inventory
             Type: void
        Name: GetItem(int arrayPosition)
             Description: returns value of shops inventory at desired array position
             Type: Items.Cs
        Name: GetValue(int arrayPosition)
             Description: displays ITEM value at desired array position
             Type: int
        Name: SellItem(Items itemchoice)
             Description: takes shops total gold and adds the items value
             Type: void
        Name: BuyItem(Items itemchoice)
             Description: takes shops total gold and subtracts item value
             Type: bool
        Name: SetItem(Items itemname, int arrayPostion)
             Description: sets item to an inventory array position
             Type: void
        Name: GetName()
             Description: returns _name value
             Type: string
        Name: GetGold()
             Description: returns _totalGold value_
             Type: int


**File**: Player.cs

**Attributes**

        Name: _maxHealth
             Description: holds players max health
             Type: float 
        Name: _gold
             Description: holds players gold
             Type: int
        Name: inventory
             Description: keeps track of items in a 3 position array
             Type: Clas Items Array
        Name: Player()
             Description: base constructor
             Type: constructor
        Name: Player(int choiceVal)
             Description: Constructor used to choose character
             Type: constructor
        Name: InitInventory
             Description: Sets every single position in the players inventory array to an emptySlot item,
             Type: void
        Name: PrintInventory()
             Description: Prints players inventory one line per array position
             Type: void
        Name: GainExperience(Entity enemy)
             Description: player earns experience depending on the level of the enemy
             Type: float
        Name: LevelUP()
             Description: tests for each lvl the player could level
             Type:  void
        Name: BuyItem(Shop shopname, int arrayPosition)
             Description: takes in a shop object and an int for the position in the array test to see if player can afford
             Type: void
        Name: SellItem(Shop shopname, int arrayPosition)
             Description: takes in shop object and position of the array the player wants to sell test to see if the shop cacn afford it, removes item from players inv
             Type: void
          Name:  EquipItem(Items itemname)
             Description: /Allows player to put an item in a specific slot, then updates max health in case an item was removed or added
             Type: void
        Name: Attack
             Description: Takes in players base damage and adds all items damage value to create an output damaeg
             Type: overriden void
        Name: BlindAttack
             Description: Takes in players base damage plus damagevalue of all items, multiplies that by half and adds the total damage of all the damages and items again
             Type: overriden void
          Name:  PrintStats()
             Description: Prints players stats
             Type: void
          Name:  GetInput((string option1, string option2, string option3, string option4, string query))
             Description: prints a message, takes in 3 choices, and returns the choice as a char
             Type: char
          Name:  GoldEarned(int goldearned)
             Description: Takes in an int then adds to player gold
             Type: void
          Name:  HealFromRest(int healthHealed)
             Description: heals the player for specific amount
             Type: void
          Name:  UpdateMaxHealth()
             Description: updates max health to the the base health plus all items damageboost
             Type: void
          Name:  Save(StreamWriter writer)
             Description: writes players stats to SavedData.txt
             Type: void
          Name:  Load(StreamReader reader)
             Description: reads player stast from SavedData.txt and applies information to current session
             Type: void
