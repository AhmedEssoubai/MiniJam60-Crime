using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    #region Serialize properties

    /// <summary>
    /// The buttons of the tabs
    /// </summary>
    [SerializeField]
    private Button[] tabsButtons;

    /// <summary>
    /// The panels of the tabs
    /// </summary>
    [SerializeField]
    private GameObject[] tabsPanels;

    /// <summary>
    /// Note UI content
    /// </summary>
    [SerializeField]
    private GameObject noteContentUI;

    #endregion

    #region Public properties

    /// <summary>
    /// The index of the tab
    /// </summary>
    public int TabIndex = 0;

    #endregion

    #region Unity methods

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    #endregion

    #region Public methods

    public void ChangeTab(int index)
    {
        noteContentUI.SetActive(false);
        tabsPanels[TabIndex].SetActive(false);
        tabsButtons[TabIndex].interactable = true;
        TabIndex = index;
        tabsPanels[TabIndex].SetActive(true);
        tabsButtons[TabIndex].interactable = false;
    }

    /// <summary>
    /// Open the inventory
    /// </summary>
    public bool Open(int index)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        else if (index == TabIndex)
        {
            gameObject.SetActive(false);
            return false;
        }
        ChangeTab(index);
        return true;
    }

    #endregion
}
