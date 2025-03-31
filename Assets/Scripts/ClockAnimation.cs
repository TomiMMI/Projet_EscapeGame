using UnityEngine;

public class ClockAnimation : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform gearHand; 
    
    public float hourSpeed = 100f;  
    public float minuteSpeed = 300f;
    public float gearSpeed = 30f;
    
    private bool isAnimating = false;
    private Quaternion initialHourRotation;
    private Quaternion initialMinuteRotation;
    private Quaternion initialGearRotation;

    void Start()
    {
        // Stocke les rotations initiales
        initialHourRotation = hourHand.rotation;
        initialMinuteRotation = minuteHand.rotation;
        if (gearHand != null)
        {
            initialGearRotation = gearHand.rotation;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAnimating = !isAnimating; // Active/désactive l'animation
            
            if (!isAnimating)
            {
                ResetHands(); // Réinitialise les aiguilles
            }
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
        if (gearHand != null)
        {
            gearHand.Rotate(0, gearSpeed * rotationAmount, 0);
        }
    }

    void ResetHands()
    {
        hourHand.rotation = initialHourRotation;
        minuteHand.rotation = initialMinuteRotation;
        if (gearHand != null)
        {
            gearHand.rotation = initialGearRotation;
        }
    }
}
