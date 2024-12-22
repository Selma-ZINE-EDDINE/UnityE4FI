using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversations : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private AstronauteMove astronautMove; // R�f�rence au script de mouvement de Player1
    private CatMove catMove;             // R�f�rence au script de mouvement de Player2

    private void Start()
    {
        // Trouvez les objets des joueurs et r�cup�rez leurs scripts
        astronautMove = GameObject.FindGameObjectWithTag("Player1").GetComponent<AstronauteMove>();
        catMove = GameObject.FindGameObjectWithTag("Player2").GetComponent<CatMove>();
    }

    private void OnTriggerStay(Collider other)
    {
        // D�tecte si Player1 entre dans la zone
        if (other.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartDialogue();
            }
        }

        // D�tecte si Player2 entre dans la zone
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
        // Si la conversation est termin�e, r�activez les contr�les
        if (!ConversationManager.Instance.IsConversationActive)
        {
            EnablePlayerControls();
        }
    }

    private void StartDialogue()
    {
        // D�marre la conversation
        ConversationManager.Instance.StartConversation(myConversation);

        // D�sactive les contr�les des joueurs
        DisablePlayerControls();
    }

    private void DisablePlayerControls()
    {
        // D�sactive le script de mouvement de Player1
        if (astronautMove != null)
        {
            astronautMove.enabled = false;
        }

        // D�sactive le script de mouvement de Player2
        if (catMove != null)
        {
            catMove.enabled = false;
        }
    }

    private void EnablePlayerControls()
    {
        // R�active le script de mouvement de Player1
        if (astronautMove != null)
        {
            astronautMove.enabled = true;
        }

        // R�active le script de mouvement de Player2
        if (catMove != null)
        {
            catMove.enabled = true;
        }
    }
}
