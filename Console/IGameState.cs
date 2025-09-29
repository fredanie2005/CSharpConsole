namespace Console;

public interface IGameState
{
    void Init();
    void Update();
    void Draw();
    void Exit();
}
