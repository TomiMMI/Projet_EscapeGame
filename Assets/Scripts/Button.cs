using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactible
{
    [SerializeField] private GameObject activatedButtonObject;
    [SerializeField] private GameObject disactivatedButtonObject;
    [SerializeField] private Material portalMaterial;
    [SerializeField] private Material disactivatedMaterial;

    [SerializeField] private GameObject destinationPortal;


    private static Button activeButton = null;


    private GameObject mainPortal;
    private bool activated;
    // Start is called before the first frame update
    void Start()
    {
        mainPortal = GameObject.FindGameObjectWithTag("Portail Principal");
    }
    override public void Interact()
    {
        if (activated)
        {
            Desactivate();
        }
        else
        {
            Activate();
        }
    }
    public override void InteractWith(GameObject holdItem)
    {
    }
    public void Activate()
    {
        activated = true;
        activatedButtonObject.SetActive(true);
        disactivatedButtonObject.SetActive(false);
        
        if(activeButton != null)
        {
            activeButton.Desactivate();
        }
        activeButton = this;
        mainPortal.GetComponent<PortalTeleport>().SetDestination(destinationPortal);
        mainPortal.GetComponent<MeshRenderer>().material = portalMaterial;
    }
    public void Desactivate()
    {
        activatedButtonObject.SetActive(false);
        disactivatedButtonObject.SetActive(true);

        activeButton = null;

        mainPortal.GetComponent<PortalTeleport>().SetDestination(null);
        mainPortal.GetComponent<MeshRenderer>().material = disactivatedMaterial;
        activated = false;
    }

}
