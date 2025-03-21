using NUnit.Framework.Interfaces;
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

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDir
            // Attempt only x movemnt
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            
            if (canMove)
            {
                // Can move only on the X axis
                moveDir = moveDirX;
            } else
            {
                // Cannot move only on the X axis

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                
                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                } else
                {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove)
        {
            // Time.deltaTime to make movement framerate dependent
            transform.position += moveDir * moveDistance;
        }

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
