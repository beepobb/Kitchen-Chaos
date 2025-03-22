using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour {
    /*
        Need a reference to the player object to listen to the event OnSelectedCounterChanged 
        [SerializeField] private Player player;
            would mean that every counter needs its own player reference which becomes very 
            tedious, the solution is Singleton pattern since there will always only be one 
            player for this game 
    */

    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;

    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
