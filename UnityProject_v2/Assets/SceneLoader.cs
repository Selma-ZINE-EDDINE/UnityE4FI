using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Charge une scène en fonction de son nom.
    /// </summary>
    /// <param name="sceneName">Nom de la scène à charger.</param>
    public string sceneName;
    public void LoadSceneByName()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Vérifie si la scène demandée existe
            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError($"La scène '{sceneName}' n'existe pas ou n'est pas incluse dans les niveaux du build.");
            }
        }
        else
        {
            Debug.LogError("Le nom de la scène est vide ou nul !");
        }
    }


}
