using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region Static properties

    /// <summary>
    /// Is the player freezing or not
    /// </summary>
    public static bool IsFreeze;

    /// <summary>
    /// When the player passed from the door
    /// </summary>
    public static System.EventHandler OnPlayerPassed;

    #endregion

    #region Public properties

    /// <summary>
    /// The position of the player when passed the door
    /// </summary>
    public Vector2 PlayerExitPosition;

    /// <summary>
    /// The new position of the camera
    /// </summary>
    public Vector3 CameraNewPosition;

    /// <summary>
    /// Is the door leading to a big space (Room, Hall way...)
    /// </summary>
    public bool ToBigSpace;

    /// <summary>
    /// Is the door locked
    /// </summary>
    public bool IsLocked;

    /// <summary>
    /// The name of the key to open the door
    /// </summary>
    public string KeyName;

    #endregion

    #region Serialize properties

    /// <summary>
    /// The camera
    /// </summary>
    [SerializeField]
    private CameraMan Camera;

    /// <summary>
    /// The player
    /// </summary>
    [SerializeField]
    private GameObject Player;

    #endregion

    #region Private methods

    /// <summary>
    /// Is the player near the door to open it
    /// </summary>
    private bool isNear = false;

    #endregion

    #region Unity methods

    void Update()
    {
        if (!IsFreeze && isNear && Input.GetKeyDown(KeyCode.E))
        {
            if (IsLocked)
            {
                if (Inventory.Instance.UseItem(KeyName))
                {
                    IsLocked = false;
                    UIManager.Manager.ShowInteractMessage("Door");
                }
            }
            else
            {
                UIManager.Manager.ShowTransition();
                StartCoroutine(TeleportPlayer());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsLocked)
                UIManager.Manager.ShowUnlockMessage("Door");
            else
                UIManager.Manager.ShowInteractMessage("Door");
            isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Manager.HideMessage();
            isNear = false;
        }
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Teleport the player
    /// </summary>
    /// <returns></returns>
    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0.4f);
        Player.transform.position = PlayerExitPosition;
        Camera.transform.position = CameraNewPosition;
        Camera.IsFollowing = ToBigSpace;
        if (OnPlayerPassed != null)
            OnPlayerPassed(this, System.EventArgs.Empty);
    }

    #endregion
}
