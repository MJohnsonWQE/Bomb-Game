using System;

public class Program
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        bool alive = true;
        bool wallChecker = true;
        int health = 100;
        string direction = null;

        //Define Base weapons for the Player
        string weapon = "Fists";
        string defence = null;

        //Define Player Position
        int x = 9;
        int y = 0;

        //Defines the Game Board
        string[,] gameBoard = new string[10, 10] { { "", "", "", "Heal", "", "", "", "Wall", "", "End" }, { "", "Landmine", "", "", "", "", "Monster", "Wall", "Landmine", "" }, { "", "", "", "", "Monster", "", "", "Wall", "", "" }, { "Landmine", "", "Monster", "", "", "", "", "Wall", "", "Monster" }, { "", "", "", "", "", "Landmine", "", "Wall", "Monster", "Landmine" }, { "", "Heal", "", "Monster", "", "", "", "Wall", "", "" }, { "Heal", "", "Sword", "", "Lake", "", "", "Wall", "", "" }, { "", "Monster", "", "Lake", "Lake", "", "", "", "", "" }, { "Monster", "", "", "", "", "", "Monster", "", "Landmine", "" }, { "Player", "", "Monster", "", "", "", "", "", "Shield", "Landmine" } };
        while (alive == true)
        {
            wallChecker = true;
            //Tells the player their stats and gives them instructions
            if (gameBoard[0, 9] == "Player")
            {
                Console.WriteLine("You found the exit and escaped!");
                Console.WriteLine("You Win!");
                Console.ReadLine(); // Stops the code from closing
                Environment.Exit(0);
            }
            if (health == 0)
            {
                Console.WriteLine("You died!");
                Console.ReadLine(); // Stops the code from closing
                Environment.Exit(0);
            }
            Console.WriteLine("You have {0} HP.", health);
            Console.WriteLine("Which way do you want to move? (Type W, A, S, or D)");
            direction = Console.ReadLine();
            Console.Clear();
            direction = direction.ToUpper();
            //Makes all actions and obstacles work for going in different directions
            if (direction == "W")
            {
                //Checks for walls up ahead and stops the player progressing further
                if (x == 0 || gameBoard[x - 1, y] == "Wall")
                {
                    Console.WriteLine("You hit a wall!");
                    wallChecker = false;

                }
                //Checks for heal items and heals player if found
                else if (gameBoard[x - 1, y] == "Heal" && wallChecker == true)
                {
                    //Fully heals player
                    health = 100;
                    Console.WriteLine("You found a heal! Your health was restored to {0}HP", health);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x - 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x - 1;
                }
                //Checks for Monsters and begins fight if one is found
                else if (gameBoard[x - 1, y] == "Monster" && wallChecker == true)
                {
                    //Runs Procedure starts Monster Encounter
                    health = Monster(health, weapon, defence);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x - 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x - 1;
                }
                //Checks for landmines and kills player if one is found
                else if (gameBoard[x - 1, y] == "Landmine" && wallChecker == true)
                {
                    Console.WriteLine("You were blown up by a landmine!");
                    Console.WriteLine("Game Over!");
                    Console.ReadLine(); // Stops the code from closing
                    Environment.Exit(0);
                }
                //Checks for swords and gives item to player if found
                else if (gameBoard[x - 1, y] == "Sword" && wallChecker == true)
                {
                    weapon = "Sword";
                    Console.WriteLine("You found a sword! You will now do double damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x - 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x - 1;
                }
                //Checks for a shield and gives item to player if found
                else if (gameBoard[x - 1, y] == "Shield" && wallChecker == true)
                {
                    defence = "Shield";
                    Console.WriteLine("You found a shield! You will now take half damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x - 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x - 1;
                }
                else if (gameBoard[x - 1, y] == "Lake" && wallChecker == true)
                {
                    Console.WriteLine("You fell in to a lake!");
                    Console.WriteLine("You pull yourself back out, gasping for breath.");
                    health = health - 1;
                }
                else if (wallChecker == true)
                {
                    gameBoard[x - 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x - 1;
                }
            }
            else if (direction == "A")
            {
                //Checks for walls up ahead and stops the player progressing further
                if (y == 0 || gameBoard[x, y - 1] == "Wall")
                {
                    Console.WriteLine("You hit a wall!");
                    wallChecker = false;

                }
                //Checks for heal items and heals player if found
                else if (gameBoard[x, y - 1] == "Heal" && wallChecker == true)
                {
                    //Fully heals player
                    health = 100;
                    Console.WriteLine("You found a heal! Your health was restored to {0}HP", health);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y - 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y - 1;
                }
                //Checks for Monsters and begins fight if one is found
                else if (gameBoard[x, y - 1] == "Monster" && wallChecker == true)
                {
                    //Runs Procedure starts Monster Encounter
                    health = Monster(health, weapon, defence);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y - 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y - 1;
                }
                //Checks for landmines and kills player if one is found
                else if (gameBoard[x, y - 1] == "Landmine" && wallChecker == true)
                {
                    Console.WriteLine("You were blown up by a landmine!");
                    Console.WriteLine("Game Over!");
                    Console.ReadLine(); // Stops the code from closing
                    Environment.Exit(0);
                }
                //Checks for swords and gives item to player if found
                else if (gameBoard[x, y - 1] == "Sword" && wallChecker == true)
                {
                    weapon = "Sword";
                    Console.WriteLine("You found a sword! You will now do double damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y - 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y - 1;
                }
                //Checks for a shield and gives item to player if found
                else if (gameBoard[x, y - 1] == "Shield" && wallChecker == true)
                {
                    defence = "Shield";
                    Console.WriteLine("You found a shield! You will now take half damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y - 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y - 1;
                }
                else if (gameBoard[x, y - 1] == "Lake" && wallChecker == true)
                {
                    Console.WriteLine("You fell in to a lake!");
                    Console.WriteLine("You pull yourself back out, gasping for breath.");
                    health = health - 1;
                }
                else if (wallChecker == true)
                {
                    gameBoard[x, y - 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y - 1;
                }
            }
            else if (direction == "S")
            {
                //Checks for walls up ahead and stops the player progressing further
                if (x == 9 || gameBoard[x + 1, y] == "Wall")
                {
                    Console.WriteLine("You hit a wall!");
                    wallChecker = false;

                }
                //Checks for heal items and heals player if found
                else if (gameBoard[x + 1, y] == "Heal" && wallChecker == true)
                {
                    //Fully heals player
                    health = 100;
                    Console.WriteLine("You found a heal! Your health was restored to {0}HP", health);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x + 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x + 1;
                }
                //Checks for Monsters and begins fight if one is found
                else if (gameBoard[x + 1, y] == "Monster" && wallChecker == true)
                {
                    //Runs Procedure starts Monster Encounter
                    health = Monster(health, weapon, defence);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x + 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x + 1;
                }
                //Checks for landmines and kills player if one is found
                else if (gameBoard[x + 1, y] == "Landmine" && wallChecker == true)
                {
                    Console.WriteLine("You were blown up by a landmine!");
                    Console.WriteLine("Game Over!");
                    Console.ReadLine(); // Stops the code from closing
                    Environment.Exit(0);
                }
                //Checks for swords and gives item to player if found
                else if (gameBoard[x + 1, y] == "Sword" && wallChecker == true)
                {
                    weapon = "Sword";
                    Console.WriteLine("You found a sword! You will now do double damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x + 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x + 1;
                }
                //Checks for a shield and gives item to player if found
                else if (gameBoard[x + 1, y] == "Shield" && wallChecker == true)
                {
                    defence = "Shield";
                    Console.WriteLine("You found a shield! You will now take half damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x + 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x + 1;
                }
                else if (gameBoard[x + 1, y] == "Lake" && wallChecker == true)
                {
                    Console.WriteLine("You fell in to a lake!");
                    Console.WriteLine("You pull yourself back out, gasping for breath.");
                    health = health - 1;
                }
                else if (wallChecker == true)
                {
                    gameBoard[x + 1, y] = "Player";
                    gameBoard[x, y] = "";
                    x = x + 1;
                }
            }
            else if (direction == "D")
            {
                //Checks for walls up ahead and stops the player progressing further
                if (y == 9 || gameBoard[x, y + 1] == "Wall")
                {
                    Console.WriteLine("You hit a wall!");
                    wallChecker = false;

                }
                //Checks for heal items and heals player if found
                else if (gameBoard[x, y + 1] == "Heal" && wallChecker == true)
                {
                    //Fully heals player
                    health = 100;
                    Console.WriteLine("You found a heal! Your health was restored to {0}HP", health);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y + 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y + 1;
                }
                //Checks for Monsters and begins fight if one is found
                else if (gameBoard[x, y + 1] == "Monster" && wallChecker == true)
                {
                    //Runs Procedure starts Monster Encounter
                    health = Monster(health, weapon, defence);
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y + 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y + 1;
                }
                //Checks for landmines and kills player if one is found
                else if (gameBoard[x, y + 1] == "Landmine" && wallChecker == true)
                {
                    Console.WriteLine("You were blown up by a landmine!");
                    Console.WriteLine("Game Over!");
                    Console.ReadLine(); // Stops the code from closing
                    Environment.Exit(0);
                }
                //Checks for swords and gives item to player if found
                else if (gameBoard[x, y + 1] == "Sword" && wallChecker == true)
                {
                    weapon = "Sword";
                    Console.WriteLine("You found a sword! You will now do double damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y + 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y + 1;
                }
                //Checks for a shield and gives item to player if found
                else if (gameBoard[x, y + 1] == "Shield" && wallChecker == true)
                {
                    defence = "Shield";
                    Console.WriteLine("You found a shield! You will now take half damage in battle.");
                    //Remove the item and old player position, place player in item position
                    gameBoard[x, y + 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y + 1;
                }
                else if (gameBoard[x, y + 1] == "Lake" && wallChecker == true)
                {
                    Console.WriteLine("You fell in to a lake!");
                    Console.WriteLine("You pull yourself back out, gasping for breath.");
                    health = health - 1;
                }
                else if (wallChecker == true)
                {
                    gameBoard[x, y + 1] = "Player";
                    gameBoard[x, y] = "";
                    y = y + 1;
                }
            }
        }
    }
    //Procedure containing the Monster Fight
    public static int Monster(int health, string weapon, string defence)
    {
        bool inBattle = true;
        string decision = null;
        int monsterHP = 100;
        int monsterDP = 10;
        int playerDEF = 1;
        int insultLength = 0;
        string monsterInsult = null;
        Console.WriteLine("You encountered a Monster!");
        if (defence == "Shield")
        {
            playerDEF = 2;
        }
        while (inBattle == true)
        {
            if (monsterHP == 0)
            {
                inBattle = false;
                break;
            }
            else if (health == 0)
            {
                Console.WriteLine("You died!");
                Environment.Exit(0);
            }
            Console.WriteLine("You have {0} HP remaining", health);
            Console.WriteLine("What will you do? (F to Fight or A to Act)");
            decision = Console.ReadLine();
            Console.Clear();
            //Makes sure that the Code activates whether or not the users input was capitalised or not
            decision = decision.ToUpper();
            if (decision == "F")
            {
                Console.WriteLine("You attacked the monster!");
                //Check what weapon the player is using, and deal damage accordingly
                if (weapon == "Fists")
                {
                    monsterHP = monsterHP - 20;
                    //Makes sure HP never goes past 0 HP
                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                    }
                    Console.WriteLine("You dealt 20 DMG to the Monster! It now has {0} HP", monsterHP);
                }
                else if (weapon == "Sword")
                {
                    monsterHP = monsterHP - 40;
                    //Makes sure HP never goes past 0 HP
                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                    }
                    Console.WriteLine("You dealt 40 DMG to the Monster! It now has {0} HP", monsterHP);
                }
            }

            //Gimmick which gives the Player a different way of killing the Monster
            else if (decision == "A")
            {
                Console.WriteLine("You plan to insult the monster... What do you say?");
                monsterInsult = Console.ReadLine();
                insultLength = monsterInsult.Length;
                if (insultLength < 3)
                {
                    Console.WriteLine("You trip over your words and miss your chance.");
                }
                else if (insultLength < 10)
                {
                    Console.WriteLine("Your insult slightly hurt the Monster's ego!");
                    monsterHP = monsterHP - 5;
                    monsterDP = monsterDP - 1;
                    //Makes sure HP never goes past 0 and DP never goes past 2
                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                    }
                    if (monsterDP < 2)
                    {
                        monsterDP = 2;
                    }
                    Console.WriteLine("The Monster now has {0} HP", monsterHP);
                }
                else if (insultLength <= 50)
                {
                    Console.WriteLine("Your insult wounded the Monster's ego!");
                    monsterHP = monsterHP - 10;
                    monsterDP = monsterDP - 2;
                    //Makes sure HP never goes past 0 and DP never goes past 2
                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                    }
                    if (monsterDP < 2)
                    {
                        monsterDP = 2;
                    }
                    Console.WriteLine("The Monster now has {0} HP", monsterHP);
                }
                else if(insultLength > 50)
                {
                    Console.WriteLine("Your insult was too long and the Monster lost interest!");
                    Console.WriteLine("This enraged the Monster!");
                    monsterDP = 20;
                }
            }

            Console.WriteLine("The Monster attacked you!");
            health = health - (monsterDP/playerDEF);
            Console.WriteLine("It dealt {0}DMG, leaving you with {1}HP", (monsterDP/playerDEF), health);
            if(health <= 0)
            {
                Console.WriteLine("You died!");
                Console.ReadLine(); // Stops the code from closing
                Environment.Exit(0);
            }
            //Check whether the Monster is dead
            if(monsterHP <= 0)
            {
                Console.WriteLine("The Monster died!");
            }
        }
        return health;
    }
}