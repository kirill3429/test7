using UnityEngine;
using UnityEngine.InputSystem;
public class KeyboardInputHandler : InputHandler
{
    NewControls controls;
    private void Awake()
    {
        controls = new NewControls();

        //controls.Player.ActionButton.canceled += controls => action = controls.started;

        //action = controls.Player.ActionButton.phase == InputActionPhase.Started;

        controls.Player.WASD.started += controls => direction = controls.ReadValue<Vector2>();
        controls.Player.WASD.canceled += controls => direction = Vector3.zero;
    }

    private void Update()
    {
        action = controls.Player.ActionButton.phase == InputActionPhase.Started;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

}
