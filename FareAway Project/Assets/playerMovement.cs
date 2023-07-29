using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    private float rotZ;
    [SerializeField] private float rotationSpeed;
    public float moveSpeed = 5.0f;

    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private float dashSpeed = 6f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashCooldown = 5f;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("right") && canDash)
        {
            StartCoroutine(Dash());
            StaminaBar.instance.useStamina(1);
            
        }
        else if(isDashing)
        {
            moveSpeed = dashSpeed;
            tr.emitting = true;
        }
        else
        {
            moveSpeed = 5;
            tr.emitting = false;
            body.velocity = new Vector2(50 * moveSpeed * Time.deltaTime,0);
        }

        

        if(Input.GetKey("up"))
        {
            body.velocity = new Vector2(40 * moveSpeed * Time.deltaTime, 20 * moveSpeed * Time.deltaTime);
            rotZ += Time.deltaTime * rotationSpeed;
            if(rotZ >= 30)
            {
                rotZ = 30;
            }
        }
        else if(Input.GetKey("down"))
        {
            body.velocity = new Vector2(40 * moveSpeed * Time.deltaTime, -20 * moveSpeed * Time.deltaTime);
            rotZ += -Time.deltaTime * rotationSpeed;
            if(rotZ <= -30)
            {
                rotZ = -30;
            }
        }
        else
        {
            rotZ = 0;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(dashSpeed, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        body.gravityScale = originalGravity;
        isDashing = false;
        canDash = true;
    }
}
