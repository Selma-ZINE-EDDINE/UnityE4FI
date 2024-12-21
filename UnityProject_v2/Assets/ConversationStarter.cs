using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{

    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider other)
    {
        //astronaute
        if (other.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }

        //Cat
        if (other.CompareTag("Player2"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }

}
