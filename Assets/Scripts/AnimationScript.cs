using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator SunAnimator;


    public void SetAnimation()
    {
            SunAnimator.SetTrigger("Triggered");
    }
}
