using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour {
    /*
        Need a reference to the player object to listen to the event OnSelectedCounterChanged 
        [SerializeField] private Player player;
            would mean that every counter needs its own player reference which becomes very 
            tedious, the solution is Singleton pattern since there will always only be one 
            player for this game 
    */

    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        if (e.selectedCounter == baseCounter) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide() {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(false);
        }
    }
}
