using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    #region Serialize properties

    /// <summary>
    /// Items image UI
    /// </summary>
    [SerializeField]
    private UnityEngine.UI.Image[] ItemsUI;

    #endregion

    #region Unity methods

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Inventory.Instance.Items.Length; i++)
            if (Inventory.Instance.Items[i] != null)
                SetItemUI(Inventory.Instance.Items[i], i);
        Inventory.Instance.OnItemAdd += OnItemAdd;
        Inventory.Instance.OnItemRemoved += OnDropItem;
        //gameObject.SetActive(false);
    }

    #endregion

    #region Public methods



    #endregion

    #region Private methods

    /// <summary>
    /// Set the item image in it's cell
    /// </summary>
    private void SetItemUI(Item data, int index)
    {
        ItemsUI[index].sprite = data.Icon;
        ItemsUI[index].gameObject.SetActive(true);
    }

    /// <summary>
    /// When the player drop an item
    /// </summary>
    /// <param name="index">The index of the item</param>
    private void OnDropItem(int index)
    {
        ItemsUI[index].sprite = null;
        ItemsUI[index].gameObject.SetActive(false);
    }

    /// <summary>
    /// When a note added to the inventory
    /// </summary>
    /// <param name="item">Added item</param>
    /// <param name="index">Cell index</param>
    private void OnItemAdd(Item item, int index)
    {
        SetItemUI(item, index);
    }

    #endregion
}
