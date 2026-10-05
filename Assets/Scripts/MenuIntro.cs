using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuIntro : MonoBehaviour
{
    [SerializeField] TMP_Text texteCoups;
    void Start()
    {
        int NbCoups = PlayerPrefs.GetInt("NbCoups", 0);

        texteCoups.text = $"Dernier match; {NbCoups} coups";


    }
    public void DemarrerJeu()
    {
        SceneManager.LoadScene("Jeu");
    }
}
