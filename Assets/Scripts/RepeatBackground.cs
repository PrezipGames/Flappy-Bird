using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Variablen deklarieren
    private Vector2 startPosition;
    private float repeatPoint = -8.9f;
    
    void Start()
    {
        // speichert die Anfangsposition des Hintergrundes in startPosition
        startPosition = transform.position;
    }

    void Update()
    {
        // Wenn die x-Position des Hintergrundes <= dem repeatPoint ist, wird der Hintergrund wieder
        // auf die startPosaition zurückgesetzt
        if(transform.position.x <= repeatPoint)
        {
            transform.position = startPosition;
        }
    }
}
