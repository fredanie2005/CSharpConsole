namespace Console.GameScene;

public class MenuState : IGameState
{
    public void Init()
    {
        System.Console.WriteLine("MenuState: Init");
        Audio.Instance.Play("Resources/Audio/meow.mp3");
    }

    public void Update()
    {
        System.Console.WriteLine("MenuState: Update");
    }

    public void Draw()
    {
        System.Console.WriteLine("MenuState: Draw");
    }
    
    public void Exit()
    {
        System.Console.WriteLine("MenuState: Exit");
    }
}
