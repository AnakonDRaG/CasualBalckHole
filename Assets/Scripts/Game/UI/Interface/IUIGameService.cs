using Services;

namespace Game.UI.Interface
{
    public interface IUIGameService: IService
    {
        IWindow WinWindow { get; }
        IWindow LoseWindow { get; }
        IWindow GameMenuWindow { get; }
    }
}