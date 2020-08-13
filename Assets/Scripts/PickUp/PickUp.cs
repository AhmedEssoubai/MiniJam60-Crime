using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    #region Public properties

    public string Name;

    #endregion

    #region Protected members

    /// <summary>
    /// Can the item be pickuped
    /// </summary>
    protected bool pickUpAllowed;

    #endregion

    #region Events

    /// <summary>
    /// When the player pickup this
    /// </summary>
    public System.EventHandler OnPickUp;

    #endregion

    #region Unity methods

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKey(KeyCode.E) && CanPickUp())
        {
            if (OnPickUp != null)
                OnPickUp(this, System.EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Manager.ShowPickUpMessage(Name);
            pickUpAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Manager.HideMessage();
            pickUpAllowed = false;
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
