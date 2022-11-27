using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Library hinzufügen, um mit UI-Elementen arbeiten zu können
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Variablen deklarieren
    Text scoreText;
    int score = 0;
    
    void Start()
    {
        // Komponente Text der Variable scoreText zuweisen
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        // den Text von scoreText auf die Zahl score setzen und diese in einen String umwandeln
        scoreText.text = score.ToString();
    }

    // Funktion, die den int score um 1 erhöht
    public void IncreaseTheScore()
    {
        score++;
    }
}
