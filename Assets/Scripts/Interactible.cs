using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    abstract public void Interact();
    abstract public void InteractWith(GameObject holdItem);
}
