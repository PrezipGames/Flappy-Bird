using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Librarys hinzufügen, um mit UI-Elementen und dem SceneManager arbeiten zu können
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variablen deklarieren
    public bool gameIsOver;
    public Image gameOverImage;
    public Button restartButton;

    // Beendet das Spiel und aktiviert gameOverImage und restartButton
    public void GameOver()
    {
        gameIsOver = true;
        gameOverImage.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Funktion, die das Spiel neu startet, wenn man auf den restartButton klickt
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
