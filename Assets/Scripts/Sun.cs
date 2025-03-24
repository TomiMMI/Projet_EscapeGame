using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float decompte = 4f;
    private bool isLookedAt = false;
    void Start()
    {
        PlayerController.Instance.PlayerLookingAtSun += Instance_PlayerLookingAtSun;
    }

    private void Instance_PlayerLookingAtSun(object sender, PlayerController.PlayerLookinAtSunEventArgs e)
    {
        isLookedAt = e.value;
        if (!isLookedAt) decompte = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(decompte <= 0)
        {
            //Animation()
        }
        else if (isLookedAt)
        {
            decompte -= Time.deltaTime;
        }
    }
}
