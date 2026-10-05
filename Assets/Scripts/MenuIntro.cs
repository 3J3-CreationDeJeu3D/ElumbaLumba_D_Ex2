using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
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
=======

public class MenuIntro : MonoBehaviour
{
    public void Demarrer()
    {
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da
    }
}
