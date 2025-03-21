using UnityEngine;

public class GameInput : MonoBehaviour 
{
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }
    // Be clear that output is normalised
    public Vector2  GetMovemnetVectorNormalised()
    {
        // Get move input
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
