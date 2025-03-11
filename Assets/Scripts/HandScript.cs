using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    public void Hold()
    {
        GameObject holdItem = PlayerController.Instance.holdItem;
        holdItem.transform.position = hand.transform.position;
        holdItem.transform.SetParent(hand.transform);
        Rigidbody item = holdItem.GetComponent<Rigidbody>();
        item.detectCollisions = false;
        item.useGravity = false;
    }
    public void Unhold()
    {
        GameObject holdItem = PlayerController.Instance.holdItem;
        holdItem.transform.SetParent(null);
        Rigidbody item = holdItem.GetComponent<Rigidbody>();
        item.detectCollisions = true;
        item.useGravity = false;
    }
    public void Throw()
    {
        GameObject holdItem = PlayerController.Instance.holdItem;
        holdItem.transform.SetParent(null);
        Rigidbody item = holdItem.GetComponent<Rigidbody>();
        item.detectCollisions = true;
        item.useGravity = true;
        item.isKinematic = false;
        item.AddForce(PlayerController.Instance.vueJoueur.forward.normalized * 500);
    }
}
