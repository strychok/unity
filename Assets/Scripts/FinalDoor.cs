using UnityEngine;

public class FinalDoor : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject key;
    [SerializeField] PLayerStateMAchine player;
    void Start()
    {
        
    }
    public void Interact() {
        if (player.currentStuff == key)
        {
            Debug.Log("END END END");
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
