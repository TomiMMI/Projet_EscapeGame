using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDisplay : MonoBehaviour
{
    public List <GameObject> cameras;

    void Start()
    {
      
    }

    void Update()
    {
        // Change de display en appuyant sur la touche "D"
        if (Input.GetKeyDown(KeyCode.D))
        {
           cameras[1].SetActive(!cameras[1].activeSelf);
           cameras[0].SetActive(!cameras[0].activeSelf);
        }
    }
}
