using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public static GameObject crossair;
    private Canvas blackoutCanvas;
    // Start is called before the first frame update
    void Start()
    {
        blackoutCanvas = GameObject.FindGameObjectWithTag("Blackout").GetComponent<Canvas>();
        crossair = GameObject.FindGameObjectWithTag("Crossair");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = destination.GetChild(0).position;
        collision.transform.rotation = gameObject.transform.rotation;
        CameraManipulator.Instance.SetRotation(gameObject.transform.rotation.x);
        StartCoroutine("BlackOut");
    }
    IEnumerator BlackOut()
    {
        blackoutCanvas.enabled = true;
        crossair.SetActive(false);
        InputManager.Instance.DisableFPSPlayingMap();
        yield return new WaitForSeconds(1);
        blackoutCanvas.enabled = false;
        crossair.SetActive(true);
        InputManager.Instance.EnableFPSPlayingMap();
    }

    public void SetDestination(GameObject newDestination)
    {
        if(newDestination == null)
        {
            destination = null;
        }
        else
        {
        destination = newDestination.transform;
        }

    }
}
