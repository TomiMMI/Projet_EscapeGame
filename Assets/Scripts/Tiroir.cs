using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiroir : Interactible
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }
    override public void Interact()
    {
        animator.SetTrigger("Interact");
    }
    override public void InteractWith(GameObject objet)
    {
        Debug.Log("IMPOSSIBLE");
    }
}
