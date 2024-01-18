using static System.Console;

public class Skærm
{
    int x;
    int y;
    char defIcon;
    char atkIcon;
    int atkLine = 2;
    int sideBuffer = 2;
    List<Shot> shots;

    public Skærm(int x, int y = 2, char icon = 'I')
    {

        this.x = x;
        this.y = y;
        defIcon = icon;
        shots = new List<Shot>();
    }

    public void Move(int x, int y = 0)
    {
        if (x < 0 && this.x > sideBuffer + 1) this.x += x;
        else if (x > 0 && this.x < WindowWidth - sideBuffer - 1) this.x += x;
    }

    public void Fire()
    {
        shots.Add(new Shot(x, y + 1));
    }

    public void Print()
    {
        Clear();
        
        List<Shot> removedShots = new List<Shot> ();
        foreach (Shot shot in shots)
        {
            if (WindowHeight - shot.y > atkLine)
            {
                SetCursorPosition(shot.x, WindowHeight - shot.y);
                Write(shot.icon);
                shot.y++;
            }
            else removedShots.Add(shot);
        }
        foreach(Shot shot in removedShots) shots.Remove(shot);

        SetCursorPosition(x, WindowHeight - y);
        Write(defIcon);
    }

    public static ConsoleKey GetInput()
    {

        ConsoleKey key = ReadKey(false).Key;
        return key;
    }
}

public class Shot
{
    public int x;
    public int y;
    public char icon;
    public Shot(int x, int y, char icon = '*')
    {
        this.x = x;
        this.y = y;
        this.icon = icon;
    }
}