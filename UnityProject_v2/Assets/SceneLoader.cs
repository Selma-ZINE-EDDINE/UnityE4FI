using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Charge une sc�ne en fonction de son nom.
    /// </summary>
    /// <param name="sceneName">Nom de la sc�ne � charger.</param>
    public string sceneName;
    public void LoadSceneByName()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // V�rifie si la sc�ne demand�e existe
            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError($"La sc�ne '{sceneName}' n'existe pas ou n'est pas incluse dans les niveaux du build.");
            }
        }
        else
        {
            Debug.LogError("Le nom de la sc�ne est vide ou nul !");
        }
    }


}
