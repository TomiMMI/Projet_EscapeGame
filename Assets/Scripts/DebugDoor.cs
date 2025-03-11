using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDoor : Interactible
{
    [SerializeField] public Material mat;
    public override void Interact()
    {
        Debug.Log("Trouve la clé !");
    }
    public override void InteractWith(GameObject holdItem)
    {
        if (holdItem.CompareTag("Clé"))
        {
            Debug.Log("Ouvert !");
            gameObject.GetComponent<MeshRenderer>().material = mat;
        }
        else
        {
            Debug.Log("c'est pas la clé !");
        }
    }
}
