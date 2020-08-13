using UnityEngine;

public abstract class Container : MonoBehaviour
{
    #region Public properties

    /// <summary>
    /// The name of the container
    /// </summary>
    public string Name;

    /// <summary>
    /// Is the container locked
    /// </summary>
    public bool IsLocked;

    /// <summary>
    /// The name of the key to open the container
    /// </summary>
    public string KeyName;

    #endregion

    #region Protected members

    /// <summary>
    /// Is the container can be open
    /// </summary>
    protected bool openAllowed;

    #endregion

    #region Private members

    /// <summary>
    /// Is the container is looted
    /// </summary>
    //private bool looted;

    #endregion

    #region Events

    /// <summary>
    /// When the player open the container
    /// </summary>
    public System.EventHandler OnOpen;

    #endregion

    #region Unity methods

    // Update is called once per frame
    void Update()
    {
        if (openAllowed && Input.GetKeyDown(KeyCode.E))
        {
            if (IsLocked)
            {
                if (Inventory.Instance.UseItem(KeyName))
                {
                    IsLocked = false;
                    UIManager.Manager.ShowOpenMessage(Name);
                }
            }
            else if (CanPickUp())
            {
                if (OnOpen != null)
                    OnOpen(this, System.EventArgs.Empty);
                //looted = true;
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsLocked)
                UIManager.Manager.ShowUnlockMessage(Name);
            else
                UIManager.Manager.ShowOpenMessage(Name);
            openAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Manager.HideMessage();
            openAllowed = false;
        }
    }

    #endregion

    #region Protected methods

    /// <summary>
    /// Can the player pickup this
    /// </summary>
    /// <returns></returns>
    protected abstract bool CanPickUp();

    #endregion
}
