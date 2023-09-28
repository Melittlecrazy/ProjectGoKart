using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;
using static UnityEditor.Timeline.TimelinePlaybackControls;

[RequireComponent(typeof(CharacterController))]
public class KArtDrive : MonoBehaviour
{
    Driving driving;
    Vector2 move;
    
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

        driving.Drive.Forward.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        driving.Drive.Forward.canceled += cntxt => move = Vector2.zero;

        driving.Drive.Backward.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        driving.Drive.Backward.canceled += cntxt => move = Vector2.zero;

        driving.Drive.Turning.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        driving.Drive.Turning.canceled += cntxt => move = Vector2.zero;
    }

    private void Update()
    {
        Vector3 m =  new Vector3(move.x * 5, 0, move.y * 5);
        //Vector3 r = new Vector3(0,move.y * 5, 0);

       //GetComponent<Rigidbody>().velocity = m;

        GetComponent<Transform>().Rotate(Vector3.up* move.x * .2f);
    }
    private void FixedUpdate()
    {
        //body.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
    }

    public void OnDrive(InputAction.CallbackContext cont)
    {
        //currentSpeed = forwardAmount *= speed;
        //currentSpeed = speed;

    }
    public void OnReverse(InputAction.CallbackContext cont)
    {
        //currentSpeed = -speed * deeps;

    }
    //This is for tighter controls, might add it later.

    public void OnTurning(InputAction.CallbackContext cont)
    {
        //turnAmount = cont.ReadValue<float>();
        //float newRotation = turnAmount * turnSpeed * Time.deltaTime;
        //transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);
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
