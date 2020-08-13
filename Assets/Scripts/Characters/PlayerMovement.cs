using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    //public GameObject flashLight;

    #region Serialize properties

    /// <summary>
    /// The player flash light
    /// </summary>
    [SerializeField]
    private FlashLight flashLight;

    #endregion

    #region Private members

    /// <summary>
    /// The velocity of the player
    /// </summary>
    private Vector2 velocity;

    /// <summary>
    /// Player rigid body
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// The player animator
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Player sprite renderer
    /// </summary>
    private SpriteRenderer sr;

    #endregion

    #region Public properties

    /// <summary>
    /// Is the player freezing or not
    /// </summary>
    public bool IsFreeze;

    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!IsFreeze)
        {
            //INPUT
            velocity.x = Input.GetAxisRaw("Horizontal");
            velocity.y = Input.GetAxisRaw("Vertical");

            /*animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
            animator.SetFloat("Speed", velocity.sqrMagnitude);*/

            /*if (Input.GetKeyDown(KeyCode.F))
                flashLight.SetActive(!flashLight.activeSelf);*/
            if (velocity.x > 0)
            {
                flashLight.SetDirection(FlashLight.Direction.Right);
                sr.flipX = false;
            }
            else if (velocity.x < 0)
            {
                flashLight.SetDirection(FlashLight.Direction.Left);
                sr.flipX = true;
            }
            animator.SetBool("Walking", Math.Abs(velocity.x) + Math.Abs(velocity.y) != 0);
        }
    }

    void FixedUpdate()
    {
        if (!IsFreeze)
        {
            //MOVEMENT
            rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
        }
    }
    
}
