using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Variablen deklarieren
    public float speed;

    void Update()
    {
        // bewegt den Hintergrund und die Pipes nach links, solange das Spiel nicht game over ist
        if(FindObjectOfType<GameManager>().gameIsOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
           
        // löscht die Pipes aus dem Spiel, wenn sie aus der Szene herausgefahren sind
        if(transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
