using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;

[RequireComponent(typeof(CharacterController))]
public class KArtDrive : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private LayerMask ground;

    PlayerManager playerManager;

    private float forwardAmount;
    private float currentSpeed;
    [SerializeField] public float speed;
    [SerializeField] public float deeps;
    float turnAmount;
    [SerializeField] public float turnSpeed;

   // public bool isPlayer1, isPlayer2;


    private void Start()
    {
        body.transform.parent = null;
    }
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        transform.position = body.transform.position;

        //forwardAmount = Input.GetAxis("Vertical");
        turnAmount = Input.GetAxis("Horizontal");

        //if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space)) Drive();

        //if (isPlayer1 == true)//&& playerManager.controllerTypeConnected == PlayerManager.ControllerTypeConnected.Xbox)
        //{
        //    if (Gamepad.current.buttonSouth.isPressed) Drive();
        //    else currentSpeed = 0f;

        //    if (Gamepad.current.buttonEast.isPressed) DriveNowhere();

        //    Turning();
        //}

        //if (isPlayer2 == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space)) Drive();
        //    else currentSpeed = 0f;

        //    if (Input.GetKeyDown(KeyCode.LeftShift)) DriveNowhere();

        //    Turning();
        //}

        //GroundHandler();
    }
    private void FixedUpdate()
    {
        body.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
    }

    private void OnDrive(InputAction.CallbackContext cont)
    {
        //currentSpeed = forwardAmount *= speed;
        currentSpeed = speed;

    }
    void OnReverse(InputAction.CallbackContext cont)
    {
        currentSpeed = -speed * deeps;

    }
    //This is for tighter controls, might add it later.

    void OnTurning(InputAction.CallbackContext cont)
    {
        turnAmount = cont.ReadValue<float>();
        float newRotation = turnAmount * turnSpeed * Time.deltaTime;
        transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
