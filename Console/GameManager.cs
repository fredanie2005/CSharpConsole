using Console.GameScene;

namespace Console;

public class GameManager
{
    private IGameState _currentState = new MenuState();
    private bool _isRunning = true;

    public bool IsRunning
    {
        get => _isRunning;
        set => _isRunning = value;
    }
    
    public void Init()
    {
        _currentState.Init();
    }

    public void ChangeState(IGameState newState)
    {
        _currentState.Exit();       
        _currentState = newState;
        _currentState.Init(); 
    }

    public void Run()
    {
        while (_isRunning)
        {
            _currentState.Update();
            _currentState.Draw();
        }
    }
}
