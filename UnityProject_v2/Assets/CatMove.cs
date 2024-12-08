using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    private Vector3 movement;
    public GameObject sphere;

    void Update()
    {
        // Récupérer l'entrée utilisateur (clavier)
        movement.x = Input.GetAxis("Horizontal2");
        movement.z = Input.GetAxis("Vertical2");


        //Calcul de la position du joueur si il fait son déplacement
        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

        //Calcul limite de la sphere (serre)
        Vector3 sphereCenter = sphere.transform.position;
        float sphereRadius = sphere.transform.localScale.x * 0.5f;

        // Appliquer le mouvement au joueur si il ne fait pas sortir de la serre
        if (Vector3.Distance(newPosition, sphereCenter) <= sphereRadius)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }
}
