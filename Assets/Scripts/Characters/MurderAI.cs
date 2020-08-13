using System;
using UnityEngine;

public class MurderAI : MonoBehaviour
{
    #region Serialize properties

    /// <summary>
    /// Map nodes
    /// </summary>
    [SerializeField]
    private PathNode[] nodes;

    /// <summary>
    /// The player
    /// </summary>
    [SerializeField]
    private Player player;

    #endregion

    #region Public properties

    /// <summary>
    /// Is the murder freezing or not
    /// </summary>
    public bool IsFreeze;

    /// <summary>
    /// The murder mass
    /// </summary>
    public float Mass;

    /// <summary>
    /// The murder max speed
    /// </summary>
    public float MaxSpeed;

    /// <summary>
    /// The index of the current room
    /// </summary>
    public int CurrentRoom;

    /// <summary>
    /// The index of the room the player currently in
    /// </summary>
    public int PlayerCurrentRoom;

    #endregion

    #region Private members

    /// <summary>
    /// Target object
    /// </summary>
    private GameObject target;

    /// <summary>
    /// Murder rigid body
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Murder sprite renderer
    /// </summary>
    private SpriteRenderer sr;

    /// <summary>
    /// The player animator
    /// </summary>
    private Animator animator;

    /// <summary>
    /// The velocity of the murder
    /// </summary>
    private Vector2 velocity;

    /// <summary>
    /// Target node index
    /// </summary>
    public int targetNode;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Door.OnPlayerPassed += OnPlayerPassedDoor;
        UpdateTarget();
    }

    private void OnPlayerPassedDoor(object sender, EventArgs e)
    {
        Door door = sender as Door;
        for (int i = 0; i < nodes.Length; i++)
            if (nodes[i].Door == door)
            {
                PlayerCurrentRoom = nodes[nodes[i].ExitDoor].Room;
                UpdateTarget();
            }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walking", !IsFreeze);
        if (velocity.x > 0)
            sr.flipX = true;
        else if (velocity.x < 0)
            sr.flipX = false;
    }

    void FixedUpdate()
    {
        if (!IsFreeze)
        {
            Vector2 dv = (target.transform.position - transform.position).normalized * MaxSpeed;
            Vector2 s = (dv - velocity) / Mass;
            velocity += s;
            //MOVEMENT
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && collision.gameObject.Equals(target))
        {
            Vector2 newPosition = target.GetComponent<Door>().PlayerExitPosition;
            transform.position = newPosition;
            CurrentRoom = nodes[nodes[targetNode].ExitDoor].Room;
            UpdateTarget();
        }
    }

    private void UpdateTarget()
    {
        if (CurrentRoom == PlayerCurrentRoom)
            target = player.gameObject;
        else
        {
            targetNode = FindRoom(CurrentRoom, PlayerCurrentRoom, new int[] { -1 });
            target = nodes[targetNode].Door.gameObject;
        }
    }

    // VERY BAD CODE
    private int FindRoom(int currentRoom, int targetRoom, int[] enterDoor)
    {
        if (currentRoom == targetRoom)
            return enterDoor[enterDoor.Length - 1];
        for (int i = 0; i < nodes.Length; i++)
        {
            bool passed = false;
            for (int j = 0; j < enterDoor.Length; j++)
                if (enterDoor[j] == i)
                {
                    passed = true;
                    break;
                }
            if (!passed && nodes[i].Room == currentRoom)
            {
                int[] ed = new int[enterDoor.Length + 2];
                for (int j = 0; j < enterDoor.Length; j++)
                    ed[j] = enterDoor[j];
                ed[enterDoor.Length] = i;
                ed[enterDoor.Length + 1] = nodes[i].ExitDoor;
                if (FindRoom(nodes[nodes[i].ExitDoor].Room, targetRoom, ed) != -1)
                    return i;
            }
        }
        return -1;
    }
}
