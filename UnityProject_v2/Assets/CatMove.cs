using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    public float rotationSpeed = 100f; // vitesse de rotation
    private Vector3 movement;
    public GameObject sphere;

    void Update()
    {
        // Récupérer l'entrée utilisateur (clavier)
        movement.z = Input.GetAxis("Vertical2");
        float rotationInput = Input.GetAxis("Horizontal2"); // Rotation avec axe vertical


        //Calcul de la position du joueur si il fait son déplacement
        Vector3 forwardMovement = transform.forward * movement.z;
        Vector3 newPosition = transform.position + forwardMovement * speed * Time.deltaTime;

        //Calcul limite de la sphere (serre)
        Vector3 sphereCenter = sphere.transform.position;
        float sphereRadius = sphere.transform.localScale.x * 0.5f;

        // Appliquer le mouvement au joueur si il ne fait pas sortir de la serre
        if (Vector3.Distance(newPosition, sphereCenter) <= sphereRadius)
        {
            transform.position = newPosition;
        }

        if (rotationInput != 0)
        {
            transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
        }
    }
}
