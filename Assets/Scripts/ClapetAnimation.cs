using UnityEngine;

public class BoxClapet : MonoBehaviour
{
    public Transform clapet;  // Le couvercle à animer
    public float openAngle = -90f;  // Angle d'ouverture sur Y
    public float speed = 5f;  // Vitesse d'ouverture/fermeture

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = clapet.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOpen = !isOpen;
        }

        clapet.rotation = Quaternion.Slerp(clapet.rotation, isOpen ? openRotation : closedRotation, Time.deltaTime * speed);
    }
}
