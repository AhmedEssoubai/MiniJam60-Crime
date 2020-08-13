using System;

public class NoteContainer : PickUp
{
    #region Public properties

    /// <summary>
    /// Note data
    /// </summary>
    public Note Data;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        OnPickUp += OnPickUpNote;
    }

    #endregion

    #region Private methods

    private void OnPickUpNote(object sender, EventArgs e)
    {
        Inventory.Instance.AddNote(Data);
    }

    protected override bool CanPickUp()
    {
        return true;
    }

    #endregion
}
