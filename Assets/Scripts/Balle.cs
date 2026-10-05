using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using Unity.VisualScripting;
using System.Globalization;
=======
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da

public class Balle : MonoBehaviour
{

<<<<<<< HEAD
    [Header("État de jeu")]
    Vector3 positionBalle;

    int points = 0;
    [SerializeField] bool peutJouer;


    [Header("Paramètres de tir")]
    [SerializeField] float angleTir;
    [SerializeField] float vitesseRotation;
    [SerializeField] float forceTir;
    Rigidbody rigidbodyBalle;
    LineRenderer lineRendererBalle;

 



    [Header("Gauge de force")]
    [SerializeField] Slider jaugeForce;


    [Header("Input Actions")]
    [SerializeField] InputAction tirAction;
    [SerializeField] InputAction tournerAction;



    [Header("Sons")]
    AudioSource audioSourceBalle;
    [SerializeField] AudioClip sonFin;
    [SerializeField] AudioClip sonErreur;

    [Header("UI")]
    [SerializeField] TMP_Text textePoints;
=======
    // [Header("État de jeu")]



    // [Header("Paramètres de tir")]



    // [Header("Gauge de force")]


    // [Header("Input Actions")]



    // [Header("Composant")]
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da


    void Start()
    {
<<<<<<< HEAD
        rigidbodyBalle = GetComponent<Rigidbody>();
        lineRendererBalle = GetComponent<LineRenderer>();
        audioSourceBalle = GetComponent<AudioSource>();

        points = 0;
        textePoints.text = $"Coups: {points}";
        peutJouer = true;

        if (PlayerPrefs.HasKey("positionBalle"))
        {
             string positionJSON = PlayerPrefs.GetString("positionBalle");
             transform.position = JsonUtility.FromJson<Vector3>(positionJSON);
        }
=======
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da

    }

    void Update()
    {

<<<<<<< HEAD
       if (peutJouer == true && GestJeu.instance.etat == EtatJeu.Jeu)
        {
        float inputRotation = tournerAction.ReadValue<float>();
        angleTir += inputRotation;

        Vector3 direction = Quaternion.Euler(0, angleTir,0) * Vector3.forward;
        lineRendererBalle.SetPosition(0, transform.position);
        lineRendererBalle.SetPosition(1, transform.position + direction);

        if (tirAction.WasPressedThisFrame())
        {
            
            forceTir = 0;
            MettreAJourUI();
        }

        if (tirAction.IsPressed())
        {
            
             forceTir += 1;
             forceTir = Mathf.Clamp(forceTir, jaugeForce.minValue, jaugeForce.maxValue);
             MettreAJourUI();
        }

        if (tirAction.WasReleasedThisFrame())
        {
            points++;
            textePoints.text = $"Coups: {points}";

            positionBalle = transform.position;

            string positionJSON = JsonUtility.ToJson(positionBalle);
            PlayerPrefs.SetString("positionBalle", positionJSON);

            rigidbodyBalle.AddForce(direction * forceTir * Time.deltaTime, ForceMode.Impulse);
            StartCoroutine(VerifierApresTir());
            forceTir = 0;
            MettreAJourUI();
        }
      }
    }

    IEnumerator VerifierApresTir()
    {
        peutJouer = false;
        lineRendererBalle.enabled = false;
        yield return new WaitForFixedUpdate();

        while(rigidbodyBalle.linearVelocity.magnitude>0.1f)
        {
            yield return null;
        }

        peutJouer = true;
        Vector3 direction = Quaternion.Euler(0, angleTir,0) * Vector3.forward;
        lineRendererBalle.SetPosition(0, transform.position);
        lineRendererBalle.SetPosition(1, transform.position + direction);
        lineRendererBalle.enabled = true;  
=======

>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da
    }

    void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.tag == "terrain")
        {
        
            //Replacer balle
            rigidbodyBalle.linearVelocity = Vector3.zero;
            transform.position = positionBalle;
            //Déclancher le son
            audioSourceBalle.PlayOneShot(sonErreur);
            GestJeu.instance.FinJeu();
        }
=======
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da

    }

    void OnTriggerEnter(Collider collision)
    {
<<<<<<< HEAD
        if(collision.gameObject.tag == "trou")
        {
            rigidbodyBalle.linearVelocity = Vector3.zero;
            rigidbodyBalle.useGravity = false;
            transform.position = collision.transform.position;
            // Déclencher un son
            audioSourceBalle.PlayOneShot(sonFin);

            PlayerPrefs.SetInt("NbCoups", points);
            PlayerPrefs.DeleteKey("positionBalle");
            StartCoroutine(GestJeu.instance.FinJeu());
        }
=======
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da

    }

    // ===================
    void FrapperBalle()
    {

    }

    void MettreAJourUI()
    {
<<<<<<< HEAD
        jaugeForce.value = forceTir;
=======
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da
    }

    // IEnumerator FinJeu()
    // {

    // }

    void SauvegarderScore()
    {

    }

    //=================================
    // Gestion des inputs actions
    void OnEnable()
    {
<<<<<<< HEAD
        tirAction.Enable();
        tournerAction.Enable();
=======
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da

    }

    void OnDisable()
    {
<<<<<<< HEAD
        tirAction.Disable();
        tournerAction.Disable();

    }
}

=======

    }
}
>>>>>>> e1dac66918cd6cd9fe0974aa123455c8823df7da
