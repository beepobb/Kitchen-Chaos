using UnityEngine;

public class KitchenObject : MonoBehaviour {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        if (this.clearCounter != null) {
            Debug.Log("replace" + this.clearCounter + "with"+clearCounter);
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject()) {
            Debug.LogError("Counter already has a kitchen object");
        } else {
            clearCounter.SetKitchenObject(this);
            // Teleport to other counter
            transform.parent = clearCounter.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
        }
            
    }

    public ClearCounter GetClearCounter() {
        return clearCounter;
    }
}
