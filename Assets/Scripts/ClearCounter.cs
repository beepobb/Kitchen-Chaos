using UnityEngine;

public class ClearCounter : BaseCounter {
    // Can use GameObject too
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player) {
        // pick up and drop items
        // check if counter is empty before drop
        if (!HasKitchenObject()) {
            // There is no KitchenObject here
            if (player.HasKitchenObject()) { 
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // Player not carrying anything
            }
        } else {
            // There is a KitchenObject here
            if (player.HasKitchenObject()) {
                // Player is carrying something
            } else {
                // Player is not carrying anything
                // Give Player the KitchenObject
                GetKitchenObject().SetKitchenObjectParent(player);
            }
                
        }
    }
}
