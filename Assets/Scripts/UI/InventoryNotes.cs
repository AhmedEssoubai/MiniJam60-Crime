using TMPro;
using UnityEngine;

public class InventoryNotes : MonoBehaviour
{
    #region Serialize properties

    /// <summary>
    /// Note UI content
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI noteContentUI;

    /// <summary>
    /// Note UI content
    /// </summary>
    [SerializeField]
    private GameObject NoteListUI;

    /// <summary>
    /// Note prefab
    /// </summary>
    [SerializeField]
    private NoteUI notePrefab;

    #endregion

    #region Unity methods

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Inventory.Instance.Notes.Count; i++)
            CreateNoteUI(Inventory.Instance.Notes[i], i);
        Inventory.Instance.OnNoteAdd += OnNoteAdd;
        //gameObject.SetActive(false);
    }

    #endregion

    #region Public methods



    #endregion

    #region Private methods

    /// <summary>
    /// Create a note UI for the list
    /// </summary>
    private void CreateNoteUI(Note data, int index)
    {
        NoteUI note = Instantiate(notePrefab);
        note.transform.parent = NoteListUI.transform;
        RectTransform rt = note.GetComponent<RectTransform>();
        //rt.SetPositionAndRotation(new Vector3(2, 30 * index, rt.localPosition.z), rt.localRotation);
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -30 * index);
        //rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 30 * index, rt.rect.height);
        note.NoteData = data;
        note.OnOpen = OnOpenNote;
    }

    private void OnOpenNote(string content)
    {
        noteContentUI.text = content;
        noteContentUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// When a note added to the inventory
    /// </summary>
    /// <param name="note">Added note</param>
    private void OnNoteAdd(Note note)
    {
        UIManager.Manager.OpenNotesInventory();
        CreateNoteUI(note, Inventory.Instance.Notes.Count - 1);
        OnOpenNote(note.Content);
    }

    #endregion
}
