using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private WheelJoint2D wheels;
    
    public static bool IsRotationRight = false;
    public static bool IsRotationLeft = false;

    
    void Update()
    {
        TouchCheck();
    }

    void TouchCheck()
    {
        if(Input.touchCount == 0)
        {
            IsRotationLeft = false;
            IsRotationRight = false;
            IdleSpeed();
        }

        if (Input.touchCount > 0 || Input.anyKey)
            {
            if (Input.GetKey(KeyCode.LeftArrow) || (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 2))
            {
                RearGear();
                IsRotationRight = true;
                IsRotationLeft = false;
            }
            if (Input.GetKey(KeyCode.RightArrow) || (Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width / 2))
            {
                Gus();
                IsRotationLeft = true;
                IsRotationRight = false;
            }
        }
    }
    
    void Gus()
    {
        wheels.motor = new JointMotor2D { motorSpeed = -1400f, maxMotorTorque = 10000f };
    }
    void RearGear()
    {
        wheels.motor = new JointMotor2D { motorSpeed = 1600f, maxMotorTorque = 10000f };
    }
    void IdleSpeed()
    {
        wheels.motor = new JointMotor2D { motorSpeed = 0};
    }
}
