using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMoveScript : MonoBehaviour
{
    public AnimationManager animator;
    public float shiftRotation = 90f;
    public float speed;
    public bool isMove = true;
    public bool isDead = false;

    private Rigidbody2D _rb;
    public float x;
    public float y;

    private Vector3 _direct;
    private Vector3 _mousePosition;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        InputManager();
    }

    private void InputManager()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        if (x is > 0.1f or < -0.1f || y is > 0.1f or < -0.1f)
            MoveManager();
        else
            IdleManager();
        RotationCharacter();
    }

    private void MoveManager()
    {
        if (y >= 0)
            animator.State = States.MoveUp;
        else
            animator.State = States.MoveDown;
        isMove = true;
        _rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void IdleManager()
    {
        x = 0;
        y = 0;
        animator.State = States.Idle;
        isMove = false;
    }
    
    private void RotationCharacter()
    {
        _mousePosition = Camera.main!.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        
        var dx = _mousePosition.x - transform.position.x;
        var dy = _mousePosition.y - transform.position.y;
        var angle = new Vector3(0, 0, Mathf.Atan2(dy, dx) * Mathf.Rad2Deg + shiftRotation);
        _rb.transform.eulerAngles = angle;
    }
    
}
