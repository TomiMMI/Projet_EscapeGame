using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HandScript hand;
    public GameObject holdItem;
    static public PlayerController Instance { get; private set; }
    public Transform vueJoueur;
    private PlayerControlMaps inputActions;
    private Rigidbody playerRigidbody;

    [SerializeField] private float playerSpeed;

    private GameObject selectedObject = null;
    [SerializeField] private LayerMask selectionLayer;
    private void Awake()
    {
        Instance = this;
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
        inputActions = new PlayerControlMaps();
        inputActions.FPSPlayingMap.Enable();
    }

    void Start()
    {
        InputManager.Instance.OnSprintInputActivated += Instance_OnSprintInputActivated;
        InputManager.Instance.OnSprintInputDisactivated += Instance_OnSprintInputDisactivated;
        InputManager.Instance.OnInteractInputReceived += Instance_OnInteractInputReceived;
        InputManager.Instance.OnInteractAlternateInputReceived += Instance_OnInteractAlternateInputReceived;
        vueJoueur = Camera.main.transform;
    }



    private void Instance_OnInteractInputReceived(object sender, System.EventArgs e)
    {
        if(holdItem == null) {
            Interactible interactibleScript = selectedObject.GetComponent<Interactible>();
            if (interactibleScript != null)
            {
                interactibleScript.Interact();
            }
            else
            {
                holdItem = selectedObject;
                hand.Hold();
            }
        }
        else
        {
            Interactible interactibleScript = selectedObject.GetComponent<Interactible>();
            if (interactibleScript != null)
            {
                interactibleScript.InteractWith(holdItem);
            }
        }

    }
    private void Instance_OnInteractAlternateInputReceived(object sender, System.EventArgs e)
    {
        if(holdItem != null)
        {
            hand.Throw();
            holdItem = null;
        }
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
        GetLookSelection();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandlePlayerRotation();
    }
    private void LateUpdate()
    {


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
        bool touched = Physics.Raycast(new Vector3(transform.position.x,transform.position.y + 1.5f, transform.position.z), vueJoueur.forward, out RaycastHit hitInfo, 6f, selectionLayer);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), vueJoueur.forward * 6f, Color.green);
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
        transform.eulerAngles = new Vector3(0, vueJoueur.eulerAngles.y, 0);
    }
}   
