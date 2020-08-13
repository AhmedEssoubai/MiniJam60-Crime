using System;
using TMPro;
using UnityEngine;

public class NoteUI : MonoBehaviour
{

    #region Serialize properties

    [SerializeField]
    private Note noteData;

    [SerializeField]
    private TextMeshProUGUI labelUI;

    #endregion

    #region Public properties

    /// <summary>
    /// The note data
    /// </summary>
    public Note NoteData
    {
        set
        {
            if (noteData == null)
                return;
            noteData = value;
            labelUI.text = noteData.Label;
        }
        get
        {
            return noteData;
        }
    }

    /// <summary>
    /// On note open
    /// </summary>
    public Action<string> OnOpen;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        NoteData = noteData;
    }

    #region Public methods

    public void OpenNote()
    {
        if (OnOpen != null)
            OnOpen(noteData.Content);
    }

    #endregion
}
