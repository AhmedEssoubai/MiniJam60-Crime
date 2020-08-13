using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Delegates

    public delegate void NoteAdd(Note note);
    public delegate void ItemAdd(Item note, int index);
    public delegate void ItemRemoved(int index);

    #endregion

    #region Events

    /// <summary>
    /// When a note added to the inventory
    /// </summary>
    public event NoteAdd OnNoteAdd;

    /// <summary>
    /// When an item added to the inventory
    /// </summary>
    public event ItemAdd OnItemAdd;

    /// <summary>
    /// When an item removed from the inventory
    /// </summary>
    public event ItemRemoved OnItemRemoved;

    #endregion

    #region Single instance

    private static Inventory _instance;

    public static Inventory Instance { get { return _instance; } }

    #endregion

    #region Private members

    /// <summary>
    /// The player data
    /// </summary>
    private PlayerData playerData;

    #endregion

    #region Public properties

    public List<Note> Notes { get { return playerData.Notes; } }

    public Item[] Items { get { return playerData.Items; } }

    #endregion

    #region Unity methods

    // Start is called before the first frame update
    void Start()
    {
        playerData = new PlayerData();
        _instance = this;
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Add a note to the inventory
    /// </summary>
    public void AddNote(Note note)
    {
        playerData.Notes.Add(note);
        if (OnNoteAdd != null)
            OnNoteAdd(note);
    }

    /// <summary>
    /// Add a item to the inventory
    /// </summary>
    public void AddItem(Item item)
    {
        bool added = false;
        do
        {
            if (playerData.Items[playerData.ItemIndex] == null)
            {
                playerData.Items[playerData.ItemIndex] = item;
                added = true;
                playerData.ItemIndex++;
            }
        } while (!added || IsInventoryFull());
        if (OnItemAdd != null)
            OnItemAdd(item, playerData.ItemIndex - 1);
    }


    /// <summary>
    /// Is the items inventory full
    /// </summary>
    public bool IsInventoryFull()
    {
        return playerData.ItemIndex >= playerData.Items.Length;
    }

    /// <summary>
    /// Consume an item from the inventory 
    /// </summary>
    /// <param name="name">The name of the item</param>
    /// <returns>Is the item used</returns>
    public bool UseItem(string name)
    {
        for(int i = 0; i < playerData.Items.Length; i++)
            if (playerData.Items[i] != null && playerData.Items[i].Name == name)
            {
                playerData.Items[i] = null;
                if (OnItemRemoved != null)
                    OnItemRemoved(i);
                return true;
            }
        return false;
    }

    #endregion
}
