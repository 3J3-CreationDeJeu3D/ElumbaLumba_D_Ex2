using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Balle : MonoBehaviour
{

    // [Header("État de jeu")]



    // [Header("Paramètres de tir")]
    [SerializeField] float angleTir;
    [SerializeField] float vitesseRotation;



    // [Header("Gauge de force")]


    [Header("Input Actions")]
    [SerializeField] InputAction tirAction;
    [SerializeField] InputAction tournerAction;



    // [Header("Composant")]


    void Start()
    {

    }

    void Update()
    {
        float inputRotation = tournerAction.ReadValue<float>();
        
        if (tirAction.WasPressedThisFrame())
        {
            Debug.Log("Enfoncé une fois");
        }

        if (tirAction.IsPressed())
        {
            Debug.Log("Enfoncé constamment");
        }

        if (tirAction.WasReleasedThisFrame())
        {
            Debug.Log("Relâché");
        }


    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerEnter(Collider collision)
    {

    }

    // ===================
    void FrapperBalle()
    {

    }

    void MettreAJourUI()
    {
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
