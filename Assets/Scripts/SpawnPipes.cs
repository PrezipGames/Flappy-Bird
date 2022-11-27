using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    // Variablen deklarieren
    public GameObject pipePrefab;
    private float startDelay = 1;
    private float repeatRate = 1.5f;
    private float min = -0.8f;
    private float max = 3;

    // Führt die Funktion InstantiatePipes in bestimmten Abständen und mit einer Startverzögerung aus
    public void SpawnThePipes()
    {
        InvokeRepeating("InstantiatePipes", startDelay, repeatRate);
    }

    // Funktion, die solange das Spiel noch nicht game over ist, eine Pipe spawnt
    private void InstantiatePipes()
    {
        if (FindObjectOfType<GameManager>().gameIsOver == false)
        {
            Instantiate(pipePrefab, (Vector2)transform.position + RandomVector(), pipePrefab.transform.rotation);
        }
                             
    }

    // Funktion, die einen zufälligen Vektor für die y-Position der Pipes
    // berechnet (auf Basis der Variablen min & max)
    private Vector2 RandomVector()
    {
        Vector2 spawnPosition = Vector2.up * Random.Range(min,max);
        return spawnPosition;
    }
}
