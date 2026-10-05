using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public enum EtatJeu
{
    Debut, 
    Initialistion, 
    Attaque,

    Jeu,
    Mort,

    Fin,
}

public class GestJeu : MonoBehaviour
{
    public static GestJeu instance;

    public EtatJeu etat;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }

        etat = EtatJeu.Jeu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FinJeu()
    {
        // Changer l'état
        etat = EtatJeu.Fin;

        // Attendre 2 seconde
        yield return new WaitForSeconds(2);
        // Enregistrer les points
        //Chnger de scène
        SceneManager.LoadScene("Intro");
        
    }
}
