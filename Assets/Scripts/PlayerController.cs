using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform vueJoueur;
    private PlayerControlMaps inputActions;
    private Rigidbody playerRigidbody;

    [SerializeField] private float playerSpeed;

    private GameObject selectedObject = null;
    [SerializeField] private LayerMask selectionLayer;
    private void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
        inputActions = new PlayerControlMaps();
        inputActions.FPSPlayingMap.Enable();
    }

    void Start()
    {
        InputManager.Instance.OnSprintInputActivated += Instance_OnSprintInputActivated;
        InputManager.Instance.OnSprintInputDisactivated += Instance_OnSprintInputDisactivated;
        vueJoueur = Camera.main.transform;
    }

    private void Instance_OnSprintInputDisactivated(object sender, System.EventArgs e)
    {
        playerSpeed = 10;
    }

    private void Instance_OnSprintInputActivated(object sender, System.EventArgs e)
    {
        playerSpeed = 5;
    }

    void Update()
    {
        HandlePlayerRotation();
        GetLookSelection();
        //Debug.Log("Selected : " + selectedObject);
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        Vector2 movement = InputManager.Instance.GetMoveInputValues();
        Vector3 movement3 = (vueJoueur.transform.right * movement.x + vueJoueur.transform.forward * movement.y).normalized * playerSpeed;
        movement3.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = movement3; 
    }

    void GetLookSelection()
    {
        bool touched = Physics.Raycast(transform.position, vueJoueur.forward, out RaycastHit hitInfo, 6f, selectionLayer);
        Debug.DrawRay(transform.position, vueJoueur.forward * 6f, Color.green);
        if (!touched)
        {
            if (selectedObject != null) selectedObject = null;
        }
        else if(selectedObject != hitInfo.collider.gameObject)
        {
            selectedObject = hitInfo.collider.gameObject;
        }

    }
    void HandlePlayerRotation()
    {
        Debug.Log(new Vector3(0, vueJoueur.eulerAngles.y, 0));
        transform.eulerAngles = new Vector3(0, vueJoueur.eulerAngles.y, 0);
    }
}   
