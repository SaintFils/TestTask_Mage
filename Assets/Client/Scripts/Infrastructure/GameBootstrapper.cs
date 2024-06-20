using System;
using Client.Scripts.Infrastructure;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField, Header("Just temp solution for using mouse")] private bool mouseToggle = true;
    private Game game;
    
    
    private void Awake()
    {
        game = new Game(mouseToggle);
        
        DontDestroyOnLoad(this);
    }
}