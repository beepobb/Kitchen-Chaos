using UnityEngine;

public class Player : MonoBehaviour
{
    // Expose private attribute to editor only for development purposes
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update() 
    {
        // Keep logic separated
        Vector2 inputVector = gameInput.GetMovemnetVectorNormalised();

        // Move the player
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        // Time.deltaTime to make movement framerate dependent
        transform.position += moveDir * Time.deltaTime * moveSpeed;

        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        
        Debug.Log(inputVector);
    }

    public bool IsWalking() 
    {
        return isWalking;
    }
}
