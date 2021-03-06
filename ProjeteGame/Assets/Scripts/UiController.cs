using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject Image;
    [SerializeField] private GameObject Monolog;
    public bool trigger;
    private bool imageEnabled = false;
    public AudioSource audioSrc;
    public AudioClip firstAudio;
    public AudioClip secoundAudio;
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Image != null)
        {
            if (trigger == true && Input.GetKeyDown(KeyCode.E))
            {
                Image.SetActive(true);
                audioSrc.clip = firstAudio;
                audioSrc.Play();
                imageEnabled = true; 
            }

            if (!trigger)
            {
                Image.SetActive(false);

                if (imageEnabled)
                {
                    imageEnabled = false;
                    GetComponent<Collider2D>().enabled = false;

                    if (Monolog != null) { 
                        Monolog.SetActive(true);

                        if (secoundAudio != null)
                        {
                            audioSrc.clip = secoundAudio;
                            audioSrc.Play();
                        }
                        else return;
                    }

                    else return;
                }
            }
        }
        else return;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) trigger = true;      
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) trigger = false;
    }
}
