using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variablen deklarieren
    private GameManager gm;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Sprite[] sprites;
    private int spriteIndex;
    public float jumpForce;
    public float rotationForce;
    private State state;

    // Enumeration erstellen und die verschiedenen Spielzust�nde definieren
    private enum State
    {
        Waiting, Playing
    }
    
    void Start()
    {
        // Komponenten den Variablen zuweisen
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        // PlayerAnimation Funktion wiederholt ausf�hren
        InvokeRepeating("PlayerAnimation", 0, 0.08f);

        // Rigidbody des Players auf Static setzen
        rb.bodyType = RigidbodyType2D.Static;

        // die Variable state auf den State.Waiting setzen
        state = State.Waiting;
    }

    void Update()
    {
        switch (state)
        {
            // der Fall, dass state = State.Waiting ist und das Spiel noch l�uft
            case State.Waiting:
                if (gm.gameIsOver == false)
                {
                    // Wenn der erste Input gegeben wird (Maus-Taste) 
                    if (Input.GetMouseButtonDown(0))
                    {
                        // wird der Rigidbody wieder auf Dynamic gesetzt
                        rb.bodyType = RigidbodyType2D.Dynamic;
                        // die Jump Funktion wird zum ersten Mal ausgef�hrt
                        Jump();
                        // Nach dem ersten Jump wird der Spielzustand state auf State.Playing gesetzt,
                        // wodurch wir in den n�chsten Case springen und die Pipes werden gespawnt
                        state = State.Playing;
                        FindObjectOfType<SpawnPipes>().SpawnThePipes();
                    }
                }
                break;
            // der Fall, dass state = State.Playing ist und das Spiel noch l�uft
            case State.Playing:
                if (gm.gameIsOver == false)
                {
                    // wir k�nnen ganz normal unseren Input geben mit der linken Maustaste
                    if (Input.GetMouseButtonDown(0))
                    {
                        Jump();
                    }
                }
                break;
        }
        
        // die Rotation um die z-Achse orientiert sich an der y-velocity unseres Players
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotationForce);        
    }   

    // Funktion, die dem Player einen Schub nach oben gibt
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    // Funktion, die den Fl�gelschlag des Players animiert
    private void PlayerAnimation()
    {      
        if(gm.gameIsOver == false)
        {
            // erh�ht den spriteIndex um 1
            spriteIndex++;

            // wenn der spriteIndex >=3 ist, wird er wieder auf 0 zur�ckgesetzt,
            // weil der Index unseres Arrays nur bis 2 geht (0,1,2)
            if (spriteIndex >= sprites.Length)
            {
                spriteIndex = 0;
            }

            // �ndert das Sprite des Players 
            sr.sprite = sprites[spriteIndex];
        }
        
    }

    // der Score wird um 1 erh�ht, wenn der Player den Trigger in der Mitte
    // der Pipes ausl�st (IncreaseTheScore Funktion wird aufgerufen)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreScript>().IncreaseTheScore();
    }

    // Wenn der Spieler mit irgendetwas kollidiert, wird das Spiel beendet (GameOver Funktion ausgef�hrt)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gm.GameOver();
    }
}
