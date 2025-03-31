using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent {

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    // protected access modifier: accessbile by this class and any class that extends it
    // virtual: for every function that we want the child class to implement in their own way
    // abstract: force child classes to implement -> need to define BaseCounter as abstract
    // public abstract void Interact(Player player);
    public virtual void Interact(Player player) {
        // should not be triggered
        Debug.LogError("BaseCounter.Interac();");
    }
    public virtual void InteractAlternate(Player player) {
        // should not be triggered
        Debug.LogError("BaseCounter.Interac();");
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