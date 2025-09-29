using System;
using Console.GameState;

namespace Console
{
    class Program
    {
        static void Main()
        {
            GameManager gm = new GameManager();
            gm.Init();
            gm.ChangeState(new AdventureState());
            gm.Run();
        }
    }
}