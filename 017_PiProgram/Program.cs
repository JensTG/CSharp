double pi = 0.0d;
bool sign = true;

Task stopTask = Task.Run(() =>
{
    Console.ReadKey();
    return true;
});

Console.CursorVisible = false;
Console.Clear();

for (int i = 1; !stopTask.IsCompleted; i += 2)
{
    if (sign) pi += 4d / i;
    else pi -= 4d / i;
    sign = !sign;

    Console.SetCursorPosition(0, 0);
    Console.Write(pi);
}

Console.CursorVisible = true;