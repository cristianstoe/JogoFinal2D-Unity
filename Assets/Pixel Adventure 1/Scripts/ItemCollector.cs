using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSound;
    Score scoreText;


    private void Start()
    {
        scoreText = FindObjectOfType<Score>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            scoreText.AddScore();
            collectionSound.Play();
            Destroy(collision.gameObject);
        }

    }

    
}





