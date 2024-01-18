using static Skærm;
using static System.Console;

CursorVisible = false;

DateTime elapsed = DateTime.Now;
int x = 4;
Skærm skærm = new Skærm(x);
Task<ConsoleKey> inputTask = Task.Run(GetInput);

while (true)
{
    if (inputTask.IsCompleted)
    {
        switch (await inputTask)
        {
            case ConsoleKey.LeftArrow:
                skærm.Move(-1);
                break;
            case ConsoleKey.RightArrow:
                skærm.Move(1);
                break;
            case ConsoleKey.Spacebar:
                skærm.Fire();
                break;
        }
        inputTask = Task.Run(GetInput);
    }

    skærm.Print();
    while (elapsed.Ticks + 200000 > DateTime.Now.Ticks) ;
    elapsed = DateTime.Now;
}