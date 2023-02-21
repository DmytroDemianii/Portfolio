using UnityEngine;
using UnityEngine.EventSystems;

public class TurningWhileShooting : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Transform cam;

    private float _turnSmoothVelocity;
    private float _MinDeadZoneV = -0.01f;
    private float _MinDeadZoneH = -0.01f;
    private float _MaxDeadZoneV = 0.01f;
    private float _MaxDeadZoneH = 0.01f;
    private float _turnSmoothTime = 0.1f;
    
    
    private void FixedUpdate() 
    {
        if(SettingMenu.isPaused == false)
        {
            float h = joystick.Horizontal;
            float v = joystick.Vertical;
            DetermineInputValue(h, v);
            RotatePlayer(h, v);
        }
        else
        {
            joystick.OnPointerUp(new PointerEventData(EventSystem.current));
        }
    }

    private void DetermineInputValue(float v, float h)
    {
        if(h >= _MaxDeadZoneH || v >= _MaxDeadZoneV || h <= _MinDeadZoneH || v <= _MinDeadZoneV)
        {
            PlayerMovement.CanBeRotated = false;
                
        }
        else
        {
            PlayerMovement.CanBeRotated = true;
        }
        if( h == 0 && v == 0)
        {
            LaserSpawner.Pressed = false;
        }
    }

    void RotatePlayer(float h, float v)
    {
        if (Mathf.Abs(h) >= 0.2f || Mathf.Abs(v) >= 0.2f)
        {
            LaserSpawner.Pressed = true;
            Vector3 direction = new Vector3(h, 0f, v).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
