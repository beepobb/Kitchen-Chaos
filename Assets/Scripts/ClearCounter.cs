using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent {
    // Can use GameObject too
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update() {
        if (testing && Input.GetKeyDown(KeyCode.T)) {
            if (kitchenObject != null) {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }
        }
    }
    public void Interact(Player player) {
        if(kitchenObject == null) {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint); // Spawn the tomato
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        } else {
            // Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
            Debug.Log(kitchenObject.GetKitchenObjectParent());
        }
    }

    public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null; 
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
