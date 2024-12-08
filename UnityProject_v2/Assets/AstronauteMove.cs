using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronauteMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement
    private Vector3 movement;

    void Update()
    {
        // R�cup�rer l'entr�e utilisateur (clavier)
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        // Appliquer le mouvement au joueur
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
