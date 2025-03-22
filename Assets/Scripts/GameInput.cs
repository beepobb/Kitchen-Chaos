using System;
using UnityEngine;

public class GameInput : MonoBehaviour {
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        // OnInteractAction will be null if there are no subscribers

        // Same as the following code just more compact:
        // if (OnInteractAction != null) {
        //     OnInteractAction(this, EventArgs.Empty)
        // }

        // Use Invoke because parenthesis cannot come after ?
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    // Be clear that output is normalised
    public Vector2 GetMovementVectorNormalised() {
        // Get move input
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
