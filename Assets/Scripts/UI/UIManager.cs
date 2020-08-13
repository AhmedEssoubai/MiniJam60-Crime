using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Single instance

    private static UIManager _manager;

    public static UIManager Manager { get { return _manager; } }

    #endregion

    #region Public properties

    /// <summary>
    /// Is the UI freezing or not
    /// </summary>
    public bool IsFreeze;

    #endregion

    #region Serialize properties

    /// <summary>
    /// The inventory UI
    /// </summary>
    [SerializeField]
    private InventoryUI inventory;

    /// <summary>
    /// The player
    /// </summary>
    [SerializeField]
    private PlayerMovement player;

    /// <summary>
    /// Pickup message UI
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI pickupMessageUI;

    [SerializeField]
    private TextMeshProUGUI doorMessageUI;

    /// <summary>
    /// Transition panel
    /// </summary>
    [SerializeField]
    private GameObject TransitionPanel;

    /// <summary>
    /// Game over panel
    /// </summary>
    [SerializeField]
    private GameObject GameOverPanel;

    #endregion

    #region Private members


    private int pickUpItemsCount;

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    public UIManager()
    {
        _manager = this;
        pickUpItemsCount = 0;
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        pickupMessageUI.gameObject.SetActive(false);
        doorMessageUI.gameObject.SetActive(false);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (!IsFreeze && Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            player.IsFreeze = inventory.Open(0);
        //else if (Input.GetKeyDown(KeyCode.N))
        //    OpenNotesInventory();
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Door.IsFreeze = false;
            SceneManager.LoadScene("Main Scene");
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Show pickup message
    /// </summary>
    /// <param name="item">Item name</param>
    public void ShowPickUpMessage(string item)
    {
        pickUpItemsCount++;
        pickupMessageUI.text = "Press \"E\" to pickup " + item;
        if (pickUpItemsCount < 2)
            pickupMessageUI.gameObject.SetActive(true);
    }

    public void ShowInteractMessage(string door)
    {
        doorMessageUI.text = "Press \"E\" to interact with " + door;
        pickupMessageUI.gameObject.SetActive(true);
    }

    public void ShowOpenMessage(string door)
    {
        doorMessageUI.text = "Press \"E\" to open the " + door;
        pickupMessageUI.gameObject.SetActive(true);
    }

    public void ShowUnlockMessage(string door)
    {
        doorMessageUI.text = "Press \"E\" to unlock the " + door;
        pickupMessageUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hide pickup message
    /// </summary>
    public void HideMessage()
    {
        pickUpItemsCount--;
        if (pickUpItemsCount <= 0)
            pickupMessageUI.gameObject.SetActive(false);
    }

    /// <summary>
    /// Open the notes inventory
    /// </summary>
    public void OpenNotesInventory()
    {
        player.IsFreeze = inventory.Open(1);
    }

    /// <summary>
    /// Show a transition
    /// </summary>
    public void ShowTransition()
    {
        player.IsFreeze = true;
        TransitionPanel.SetActive(true);
        IsFreeze = true;
        StartCoroutine(HideTransition());
    }

    /// <summary>
    /// Show game over message
    /// </summary>
    public void ShowGameOver()
    {
        Door.IsFreeze = true;
        IsFreeze = true;
        GameOverPanel.SetActive(true);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Hide the transition after it finished
    /// </summary>
    /// <returns></returns>
    private IEnumerator HideTransition()
    {
        yield return new WaitForSeconds(1);
        player.IsFreeze = false;
        IsFreeze = false;
        TransitionPanel.SetActive(false);
    }

    #endregion
}
