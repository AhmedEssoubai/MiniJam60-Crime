using System.Collections.Generic;
using System;

[Serializable]
public class PlayerData
{
    #region Public properties

    /// <summary>
    /// The player items
    /// </summary>
    public Item[] Items;

    /// <summary>
    /// The player notes
    /// </summary>
    public List<Note> Notes;

    /// <summary>
    /// The current index of empty item
    /// </summary>
    public int ItemIndex;

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    public PlayerData()
    {
        Items = new Item[5];
        Notes = new List<Note>();
        ItemIndex = 0;
    }

    #endregion
}
