using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronauteMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    private Vector3 movement;

    void Update()
    {
        // Récupérer l'entrée utilisateur (clavier)
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        // Appliquer le mouvement au joueur
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
