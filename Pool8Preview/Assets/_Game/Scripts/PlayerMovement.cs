using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator animator;

    private Vector3 _velocity;
    private Camera _mainCamera;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private float _gravity = -9.81f;

    static public bool CanBeRotated = true;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    private void FixedUpdate() 
    {
        if(SettingMenu.isPaused == false)
        {
            ProcessImput();
            ApplyGravity();
            animator.SetBool("DontMove", false);
        }
        if(SettingMenu.isPaused == true)
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetBool("DontMove", true);
            _rb.velocity = Vector3.zero;
            joystick.AxisOptions = 0;
            joystick.OnPointerUp(new PointerEventData(EventSystem.current));
        }
        
    }
    
    void ProcessImput()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        PlayAnimation (h, v);
        RotatePlayer (h, v);
    }

    void RotatePlayer(float h, float v)
    {
        if(h == 0 || v == 0)
        {
            _rb.velocity = Vector3.zero;
        }
        if (Mathf.Abs(h) >= 0.15f || Mathf.Abs(v) >= 0.15f)
        {
            Vector3 direction = new Vector3(h, 0f, v).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            if(CanBeRotated == true)
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            Move (h, v, targetAngle);
        }
    }

    void Move(float h, float v, float targetAngle)
    {
        if (Mathf.Abs(h) >= 0.15f || Mathf.Abs(v) >= 0.15f)
        {
            float distance = new Vector2(h, v).magnitude;
            float speed = Mathf.Lerp(-.5f, 7.0f, distance);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            _rb.velocity = moveDir.normalized * speed * Time.deltaTime;
        }
    }
    
    void ApplyGravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
    }
    
    void PlayAnimation(float h, float v)
    {
        animator.SetFloat("Horizontal", h);
        animator.SetFloat("Vertical", v);
    }
}
