using System;

public class ItemContainer : PickUp
{
    #region Public properties

    /// <summary>
    /// Item data
    /// </summary>
    public Item Data;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        OnPickUp += OnPickUpItem;
    }

    #endregion

    #region Private methods

    private void OnPickUpItem(object sender, EventArgs e)
    {
        Inventory.Instance.AddItem(Data);
    }

    protected override bool CanPickUp()
    {
        return !Inventory.Instance.IsInventoryFull();
    }

    #endregion
}
