using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class BoxHolder : MonoBehaviour
{

    public AudioSource footsteps;
    public AudioSource banging;

    public TextMeshProUGUI safe;

    void Start()
    {
        safe.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Crate"))
        {
            Invoke("Banging", 3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Crate"))
        {
            Invoke("footSteps", 3f);
            footsteps.Play(0);
        }
        
    }

    private void footSteps()
    {
        safe.gameObject.SetActive(true);
        Invoke("endEvent", 4f);
    }

    private void Banging()
    {
        banging.Play(0);
    }

    private void endEvent()
    {
        safe.gameObject.SetActive(false);
    }
}
