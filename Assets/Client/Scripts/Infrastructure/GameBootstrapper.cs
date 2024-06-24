using Client.Scripts.Infrastructure;
using Client.Scripts.Infrastructure.StateMachine;
using Client.Scripts.Logic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    public LoadingScreen LoadingScreen;
    
    private Game game;
    
    private void Awake()
    {
        game = new Game(this, LoadingScreen);
        game.StateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
} 