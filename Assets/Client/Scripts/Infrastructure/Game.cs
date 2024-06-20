using Client.Scripts.Services.Input;

namespace Client.Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game(bool isMouse)
        {
            //here we can check platform and add service for our platform (mobile or PC for example)
            if (isMouse)
                InputService = new DesktopMouseInputService();
            else
                InputService = new DesktopKeyboardInputService(); 
        }
    }
    
}
