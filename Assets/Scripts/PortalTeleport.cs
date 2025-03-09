using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private Canvas blackoutCanvas;
    // Start is called before the first frame update
    void Start()
    {
        blackoutCanvas = GameObject.FindGameObjectWithTag("Blackout").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = destination.GetChild(0).position;
        StartCoroutine("BlackOut");
    }
    IEnumerator BlackOut()
    {
        blackoutCanvas.enabled = true;
        InputManager.Instance.DisableFPSPlayingMap();
        yield return new WaitForSeconds(1);
        blackoutCanvas.enabled = false;
        InputManager.Instance.EnableFPSPlayingMap();
    }
}
