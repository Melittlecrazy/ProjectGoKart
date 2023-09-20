using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;

[RequireComponent(typeof(CharacterController))]
public class KArtDrive : MonoBehaviour
{
    [SerializeField] float maxAngle,maxTorque,brake;
    [SerializeField] GameObject wheelShape;

    [SerializeField] float criticalSpeed;
    [SerializeField] int stepBellow;
    [SerializeField] int stepAbove;

    WheelCollider[] m_Wheels;
    float handBrake, torque;
    public float angle;

    public InputActionAsset inputActions;
    InputActionMap gameplayActionsMap;
    InputAction steeringInputAction, accelerationInputAction;

    private void Awake()
    {
        gameplayActionsMap = inputActions.FindActionMap("Move");

        accelerationInputAction = gameplayActionsMap.FindAction("drive");
        steeringInputAction = gameplayActionsMap.FindAction("steering");

        steeringInputAction.performed += GetAngleInput;
        steeringInputAction.canceled += GetAngleInput;

        accelerationInputAction.performed += GetTorque;
        accelerationInputAction.canceled += GetTorque;
    }
    void GetAngleInput(InputAction.CallbackContext cont)
    {
        angle = cont.ReadValue<float>() * maxAngle;
    }
    void GetTorque(InputAction.CallbackContext cont)
    {
        torque = cont.ReadValue<float>() * maxTorque; 
    }

    private void OnEnable()
    {
        steeringInputAction.Enable();
        accelerationInputAction.Enable();
    }
    private void OnDisable()
    {
        steeringInputAction.Disable();
        accelerationInputAction.Disable();
    }

    private void Start()
    {
        m_Wheels = GetComponentsInChildren<WheelCollider>();

        for(int i = 0; i < m_Wheels.Length; i++)
        {
            var wheel = m_Wheels[i];
            if(wheelShape != null)
            {
                var ws = Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }
    }
    private void Update()
    {
        m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepBellow, stepAbove);
        foreach(WheelCollider wheel in m_Wheels)
        {
            if(wheel.transform.localPosition.z >0)
            {
                wheel.steerAngle = angle;
            }
            if(wheel.transform.localPosition.z<0)
            {
                wheel.brakeTorque = handBrake;
            }
            if (wheel.transform.localPosition.z<0)
            {
                wheel.motorTorque = torque;
            }
            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                Transform shapeTransform = wheel.transform.GetChild(0);

                if (wheel.name == "wheel1" )
                {
                    shapeTransform.rotation = q * Quaternion.Euler(0, 180, 0);
                    shapeTransform.position = p;

                }
                else
                {
                    shapeTransform.position = p;
                    shapeTransform.rotation = q;
                }
            }
        }
    }
}
