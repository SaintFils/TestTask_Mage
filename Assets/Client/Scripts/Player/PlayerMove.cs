using Client.Scripts;
using Client.Scripts.Data;
using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Infrastructure.Services.Input;
using Client.Scripts.Infrastructure.Services.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour, ISavedProgress
{
    [SerializeField] private CharacterController CharacterController;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float RotationSpeed;
    
    private IInputService inputService;
    
    private void Awake()
    {
        inputService = ServiceLocator.Container.Single<IInputService>();
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (inputService.Axis.sqrMagnitude > Constants.Epsilon)
        {
            movementVector = Camera.main.transform.TransformDirection(inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();
        }
        
        transform.localRotation = Quaternion.AngleAxis(transform.localEulerAngles.y + inputService.RotationInput * RotationSpeed, Vector3.up);
        
        movementVector += Physics.gravity;
        
        CharacterController.Move(movementVector * (MovementSpeed * Time.deltaTime));
    }

    public void UpdateProgress(PlayerProgress progress)
    {
        progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevelName(), transform.position.AsVectorData());
    }

    public void LoadProgress(PlayerProgress progress)
    {
        if (CurrentLevelName() == progress.WorldData.PositionOnLevel.Level)
        {
            Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
            if (savedPosition != null)
            {
                CharacterController.enabled = false;
                transform.position = savedPosition.AsUnityVector();  
                CharacterController.enabled = true;
            }
        }
    }
    private static string CurrentLevelName() => SceneManager.GetActiveScene().name;
}