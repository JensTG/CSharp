using static System.Console;
public class ArrayOpgaver
{
    static void Main()
    {
        Clear();
        WriteLine("Please input the length of the two arrays:");
        int l1 = ReadInt(), l2 = ReadInt(), l3 = l1 + l2;
        int[] ar1 = new int[l1];
        int[] ar2 = new int[l2];
        int[] ar3 = new int[l3];

        Clear();
        WriteLine("Please input the values of the first array:");
        for (int i = 0; i < ar1.Length; i++)
        {
            ar1[i] = ReadInt();
        }
        Clear();
        WriteLine("Please input the values of the second array:");
        for (int i = 0; i < ar2.Length; i++)
        {
            ar2[i] = ReadInt();
        }

        for (int i = 0; i < ar1.Length; i++)
        {
            InsertAscending(ar1[i], ref ar3);
        }
        for (int i = 0; i < ar2.Length; i++)
        {
            InsertAscending(ar2[i], ref ar3);
        }

        Clear();
        foreach (int v in ar3)
        {
            Write(v + " ");
        }
    }

    static int ReadInt()
    {
    Start:
        string input = ReadLine();
        int number = 0;
        try { number = int.Parse(input); }
        catch { WriteLine("Try again"); goto Start; }
        return number;
    }

    static int[] InsertAscending(int insert, ref int[] output)
    {
        int index = output.Length - 1;
        while (insert < output[index])
        {
            index--;
        }
        for (int move = 0; move < index; move++)
        {
            output[move] = output[move + 1];
        }
        output[index] = insert;
        return output;
    }
}