using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversations : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private AstronauteMove astronautMove; // Référence au script de mouvement de Player1
    private CatMove catMove;             // Référence au script de mouvement de Player2

    private void Start()
    {
        // Trouvez les objets des joueurs et récupérez leurs scripts
        astronautMove = GameObject.FindGameObjectWithTag("Player1").GetComponent<AstronauteMove>();
        catMove = GameObject.FindGameObjectWithTag("Player2").GetComponent<CatMove>();
    }

    private void OnTriggerStay(Collider other)
    {
        // Détecte si Player1 entre dans la zone
        if (other.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartDialogue();
            }
        }

        // Détecte si Player2 entre dans la zone
        if (other.CompareTag("Player2"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartDialogue();
            }
        }
    }

    private void Update()
    {
        // Si la conversation est terminée, réactivez les contrôles
        if (!ConversationManager.Instance.IsConversationActive)
        {
            EnablePlayerControls();
        }
    }

    private void StartDialogue()
    {
        // Démarre la conversation
        ConversationManager.Instance.StartConversation(myConversation);

        // Désactive les contrôles des joueurs
        DisablePlayerControls();
    }

    private void DisablePlayerControls()
    {
        // Désactive le script de mouvement de Player1
        if (astronautMove != null)
        {
            astronautMove.enabled = false;
        }

        // Désactive le script de mouvement de Player2
        if (catMove != null)
        {
            catMove.enabled = false;
        }
    }

    private void EnablePlayerControls()
    {
        // Réactive le script de mouvement de Player1
        if (astronautMove != null)
        {
            astronautMove.enabled = true;
        }

        // Réactive le script de mouvement de Player2
        if (catMove != null)
        {
            catMove.enabled = true;
        }
    }
}
