ConsoleKeyInfo input;
string key = "0";
string line;

int dungeon;

Console.WriteLine("\nWelcome to the dungeon! At this time, this is nothing more than a empty room. But you can change that!" +
    "\nPlease pick your favourite kind of dungeon:" + 
    "\n 1: A dungeon full of mazes and riddles!" +
    "\n 2: A lively dungeon with loads of enemies!" +
    "\n 3: A ### Dungeon\n");
while(key == "0"){
key = Console.ReadLine();

switch(key){
    // The Maze:
    case "1":
    Console.WriteLine("\nWell, I seem to have lost that story inside the dungeon and the Sphinx won't let me in..." +
        "\nPlease pick another:\n");
    key = "0";
    break;

    // The Arena:
    case "2":
    Console.WriteLine("\nI'm sorry, but the last one barely made it out alive and I wouldn't want you to get too hurt..." +
        "\nPlease pick another:\n");
    key = "0";
    break;

    // The you-know-what:
    case "3":
    Console.WriteLine("\nI'm terribly sorry, but the drawings for that story hasn't been completed yet..." +
        "\nPlease pick another:\n");
    key = "0";
    break;
}
}