using UnityEngine;

public class ClockAnimation : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform gearHand;
    

    public float hourSpeed = 30f;  // Vitesse de rotation (ex: 30° par seconde)
    public float minuteSpeed = 180f;
    public float gearSpeed = 30f;
   

    private bool isAnimating = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAnimating = !isAnimating; // Active/désactive l'animation
        }

        if (isAnimating)
        {
            RotateHands();
        }
    }

    void RotateHands()
    {
        float rotationAmount = Time.deltaTime;

        hourHand.Rotate(0, 0, -hourSpeed * rotationAmount);
        minuteHand.Rotate(0, 0, -minuteSpeed * rotationAmount);
        gearHand.Rotate(0, gearSpeed * rotationAmount, 0);
        
    }
}
