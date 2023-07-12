using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportVR : MonoBehaviour
{
    [Header("Teleport Player")]
    [SerializeField] GameObject playerVR;
    [SerializeField] GameObject XROrigin;
    [SerializeField] Transform destination;
    [SerializeField] Transform destinationParent;
    [SerializeField] UnityEvent eventAfterTeleport;


    private void Start()
    {
        XROrigin = GameObject.FindGameObjectWithTag("XR Origin");
        //PlayerSpawner.Instance.onLocalPlayerUpdated += () => {
        //    playerVR = PlayerSpawner.Instance.LocalPlayer;
        //};

    }
    public void TeleportPlayer()
    {
        XROrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
        XROrigin.GetComponent<TeleportationProvider>().enabled = false;

        //XROrigin.GetComponent<LocomotionSystem>().enabled = false;
        //XROrigin.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        //XROrigin.GetComponent<CharacterController>().enabled = false;

        playerVR.transform.position = destination.position;
        XROrigin.transform.position = destination.position;
        if (destinationParent != null)
        {
            playerVR.transform.SetParent(destinationParent);
            XROrigin.transform.SetParent(destinationParent);
        }
        else
        {
            playerVR.transform.SetParent(null);
            XROrigin.transform.SetParent(null);
        }

       eventAfterTeleport.Invoke();
    }

    public void BackToGround()
    {
        XROrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
        XROrigin.GetComponent<TeleportationProvider>().enabled = true;

        //XROrigin.GetComponent<LocomotionSystem>().enabled = true;
        //XROrigin.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
        //XROrigin.GetComponent<CharacterController>().enabled = true;

        playerVR.transform.position = destination.position;
        XROrigin.transform.position = destination.position;
        if (destinationParent != null)
        {
            playerVR.transform.SetParent(destinationParent);
            XROrigin.transform.SetParent(destinationParent);
        }
        else
        {
            playerVR.transform.SetParent(null);
            XROrigin.transform.SetParent(null);
        }

        eventAfterTeleport.Invoke();
    }
}