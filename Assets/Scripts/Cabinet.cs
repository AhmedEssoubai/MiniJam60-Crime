using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cabinet : MonoBehaviour
{
    public TextMeshProUGUI pickUpText;

    public TextMeshProUGUI noteText;

    private bool pickUpAllowed;

    private bool noteRead;

    public BoxCollider2D cabinetCollider;



    private void Start()
    {
        pickUpText.gameObject.SetActive(false);

        noteText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(noteRead && Input.GetKey(KeyCode.Q))
        {
            noteText.gameObject.SetActive(false);
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
            Invoke("endEvent", 4f);
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
        
    }
    
    private void endEvent()
    {
        pickUpText.gameObject.SetActive(false);

        noteText.gameObject.SetActive(false);

        Destroy(GetComponent<BoxCollider2D>());
    }
}
