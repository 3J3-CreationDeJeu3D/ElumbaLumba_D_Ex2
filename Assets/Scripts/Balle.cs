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
    [SerializeField] float forceTir;
    Rigidbody rigidbodyBalle;




    // [Header("Gauge de force")]


    [Header("Input Actions")]
    [SerializeField] InputAction tirAction;
    [SerializeField] InputAction tournerAction;



    // [Header("Composant")]


    void Start()
    {
        rigidbodyBalle = GetComponent<Rigidbody>();

    }

    void Update()
    {
        float inputRotation = tournerAction.ReadValue<float>();
        Debug.Log(inputRotation);
        angleTir += inputRotation;

        if (tirAction.WasPressedThisFrame())
        {
            Debug.Log("Enfoncé une fois");
            forceTir = 0;
        }

        if (tirAction.IsPressed())
        {
            Debug.Log("Enfoncé constamment");
             forceTir += 1;
             forceTir = Mathf.Clamp(forceTir,0, 100f);
        }

        if (tirAction.WasReleasedThisFrame())
        {
            Debug.Log("Relâché");
            rigidbodyBalle.AddForce(Vector3.forward * forceTir * Time.deltaTime, ForceMode.Impulse);
            forceTir = 0;
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
