using System;
using Client.Scripts;
using Client.Scripts.Infrastructure;
using Client.Scripts.Services.Input;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController CharacterController;
    public float MovementSpeed;
    public float RotationSpeed;
    
    private IInputService inputService;
    private Camera camera;
    
    private void Awake()
    {
        inputService = Game.InputService;
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (inputService.Axis.sqrMagnitude > Constants.Epsilon)
        {
            movementVector = camera.transform.TransformDirection(inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();
        }
        
        transform.localRotation = Quaternion.AngleAxis(transform.localEulerAngles.y + inputService.RotationInput * RotationSpeed, Vector3.up);
        
        movementVector += Physics.gravity;
        
        CharacterController.Move(movementVector * (MovementSpeed * Time.deltaTime));
    }
}
