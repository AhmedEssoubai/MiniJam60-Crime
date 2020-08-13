using System;

public class Paper : PickUp
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
        OnPickUp += OnPickUpPaper;
    }

    #endregion

    #region Private methods

    private void OnPickUpPaper(object sender, EventArgs e)
    {
        Inventory.Instance.AddNote(Data);
    }

    protected override bool CanPickUp()
    {
        return true;
    }

    #endregion

    /*[SerializeField]

    public TextMeshProUGUI pickUpText;

    public TextMeshProUGUI noteText;

    private bool pickUpAllowed;

    private bool noteRead;

    AudioSource audioData;



    private void Start()
    {
        audioData = GetComponent<AudioSource>();

        pickUpText.gameObject.SetActive(false);

        noteText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(noteRead && Input.GetKey(KeyCode.Q))
        {
            noteText.gameObject.SetActive(false);
            audioData.Play(0);
            audioData.Play(1);
            //noteRead = false;
            Debug.Log("note read");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(gameObject);
        }

        if(pickUpAllowed && Input.GetKey(KeyCode.E))
        {
            noteText.gameObject.SetActive(true);
            noteRead = true;
            pickUpText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
        
    }*/

}