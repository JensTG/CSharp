using Opgaver;
// https://www.w3resource.com/csharp-exercises/basic/index.php
while(true) {
    Console.Clear();
    Console.WriteLine("Opg. nr.");
    int opg = Int32.Parse(Console.ReadLine());

    switch(opg) {
        case 1:
            Basic.Opgave1();
        break;
        case 2:
            Basic.Opgave2();
        break;
        case 3:
            Basic.Opgave3();
        break;
        case 4:
            Basic.Opgave4();
        break;
        case 5:
            Basic.Opgave5();
        break;
        case 6:
            Basic.Opgave6();
        break;
        case 7:
            Basic.Opgave7();
        break;
        case 8:
            Basic.Opgave8();
        break;
        case 9:
            Basic.Opgave9();
        break;
        case 10:
            Basic.Opgave10();
        break;
        case 11:
            Basic.Opgave11();
        break;
        case 12:
            Basic.Opgave12();
        break;
        case 13:
            Basic.Opgave13();
        break;
        case 14:
            Basic.Opgave14();
        break;
        default:
        break;
    }
    Console.ReadKey();
}