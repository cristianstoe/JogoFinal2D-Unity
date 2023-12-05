using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore()
    {
        int currentScore = int.Parse(textMeshPro.text);
        textMeshPro.text = (currentScore+1).ToString();
    }
}
