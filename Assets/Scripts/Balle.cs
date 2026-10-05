using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Balle : MonoBehaviour
{

    [Header("État de jeu")]
    Vector3 positionBalle;

    int points = 0;


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


    void Start()
    {
        rigidbodyBalle = GetComponent<Rigidbody>();
        lineRendererBalle = GetComponent<LineRenderer>();
        audioSourceBalle = GetComponent<AudioSource>();

        points = 0;
        textePoints.text = $"Coups: {points}";

    }

    void Update()
    {

        if (rigidbodyBalle.linearVelocity.magnitude > 0.1f)
        {
            lineRendererBalle.enabled = false;
            
        }
        else
        {
            lineRendererBalle.enabled  = true;
        }
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
            rigidbodyBalle.AddForce(direction * forceTir * Time.deltaTime, ForceMode.Impulse);
            forceTir = 0;
            MettreAJourUI();
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
        
            //Replacer balle
            rigidbodyBalle.linearVelocity = Vector3.zero;
            transform.position = positionBalle;
            //Déclancher le son
            audioSourceBalle.PlayOneShot(sonErreur);
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "trou")
        {
            rigidbodyBalle.linearVelocity = Vector3.zero;
            transform.position = collision.transform.position;
            audioSourceBalle.PlayOneShot(sonFin);
        }

    }

    // ===================
    void FrapperBalle()
    {

    }

    void MettreAJourUI()
    {
        jaugeForce.value = forceTir;
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
        tirAction.Enable();
        tournerAction.Enable();

    }

    void OnDisable()
    {
        tirAction.Disable();
        tournerAction.Disable();

    }
}
