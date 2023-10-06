using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

[RequireComponent(typeof(CharacterController))]
public class KArtDrive : MonoBehaviour
{
    Driving driving;
    Vector2 move;
    public Rigidbody rb;
    float currentSpeed;
    [SerializeField] float speed, turnAmount,turnSpeed;

    [SerializeField] InputActionReference press;
    
    private int playerID;

    //[Header("Sub Behaviours")]
    //public PlayerMovementBehaviour playerMovementBehaviour;
    //public PlayerAnimationBehaviour playerAnimationBehaviour;
    //public PlayerVisualsBehaviour playerVisualsBehaviour;


    //[Header("Input Settings")]
    //public PlayerInput playerInput;
    //public float movementSmoothingSpeed = 1f;
    //private Vector3 rawInputMovement;
    //private Vector3 smoothInputMovement;

    // public bool isPlayer1, isPlayer2;

    public void SetupPlayer(int newPlayerID)
    {
        playerID = newPlayerID;

        //currentControlScheme = playerInput.currentControlScheme;

        //playerMovementBehaviour.SetupBehaviour();
        //playerAnimationBehaviour.SetupBehaviour();
        //playerVisualsBehaviour.SetupBehaviour(playerID, playerInput);
    }

 
    private void Awake()
    {
        //playerManager = GetComponent<PlayerManager>();
        driving = new Driving();


        driving.Drive.Turning.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        driving.Drive.Turning.canceled += cntxt => move = Vector2.zero;


    }

    private void Update()
    {
        //Vector3 m = new Vector3(move.x * 5, 0, move.y * 5);
        ////Vector3 r = new Vector3(0, move.y * 5, 0);

        ////GetComponent<Rigidbody>().velocity = m;

        

        GetComponent<Transform>().Rotate(Vector3.up * move.x * .2f);
    }
    private void FixedUpdate()
    {
        //body.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
        rb.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
        transform.position = rb.transform.position;
    }

    public void OnDrive(InputAction.CallbackContext cont)
    {
        driving.Drive.Forward.performed += cont =>
        {
            currentSpeed = speed;
        };

        driving.Drive.Forward.canceled += cont =>
        {
            currentSpeed = speed * 0;
        };

        //press.action.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        //press.action.canceled += cntxt => move = Vector2.zero;

        

    }
    public void OnReverse(InputAction.CallbackContext cont)
    {

        //currentSpeed = -speed * deeps;
        driving.Drive.Backward.performed += cont =>
        {
            currentSpeed = -speed;
        };

        driving.Drive.Backward.canceled += cont =>
        {
            currentSpeed = 0;
        };


    }
    //This is for tighter controls, might add it later.

    public void OnTurning(InputAction.CallbackContext cont)
    {
        //turnAmount = cont.ReadValue<float>();

        //Vector3 m = new Vector3(move.x * 5, 0, move.y * 5);
        driving.Drive.Turning.performed += cntxt =>
        {
            //    //GetComponent<Transform>().Rotate(Vector3.up * move.x * 20f);
            //    //print("boing");
            //    //    float newRotation = turnAmount * turnSpeed * Time.deltaTime;
            //    //    transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);
            cntxt.ReadValue<Vector2>();
        };
        //driving.Drive.Turning.canceled += cntxt =>
        //{
        //    //move = Vector2.zero;
        //};

        //driving.Drive.Turning.performed += cntxt => move = cntxt.ReadValue<Vector2>;


    }



    private void OnEnable()
    {
        driving.Drive.Enable();
    }
    private void OnDisable()
    {
        driving.Drive.Disable();
    }
}
