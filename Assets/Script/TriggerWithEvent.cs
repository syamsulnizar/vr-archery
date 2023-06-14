using UnityEngine;
using UnityEngine.Events;

public class TriggerWithEvent : MonoBehaviour
{
    private bool playerEntered = false;
    public string tag = "Player";
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            playerEntered = true;
            Debug.Log("Player entered the trigger zone");
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            playerEntered = false;
            Debug.Log("Player exited the trigger zone");
            onExit.Invoke();

        }
    }
}






