using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class inherits from TargetObject and represents a PickupObject.
/// </summary>
public class PickupObject : TargetObject
{
    [Header("PickupObject")]

    [Tooltip("New Gameobject (a VFX for example) to spawn when you trigger this PickupObject")]
    public GameObject spawnPrefabOnPickup;

    [Tooltip("Destroy the spawned spawnPrefabOnPickup gameobject after this delay time. Time is in seconds.")]
    public float destroySpawnPrefabDelay = 10;
    
    [Tooltip("Destroy this gameobject after collectDuration seconds")]
    public float collectDuration = 0f;
    private int winner = 1;
    void Start() {
        PlayerPrefs.SetInt("Winner", 1);
        PlayerPrefs.Save();
        Register();
    }
    public int Winner { get { return winner; } set {  winner = value; } }
    void OnCollect()
    {
        if (CollectSound)
        {
            AudioUtility.CreateSFX(CollectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        if (spawnPrefabOnPickup)
        {
            var vfx = Instantiate(spawnPrefabOnPickup, CollectVFXSpawnPoint.position, Quaternion.identity);
            Destroy(vfx, destroySpawnPrefabDelay);
        }
               
        Objective.OnUnregisterPickup(this);

        TimeManager.OnAdjustTime(TimeGained);

        Destroy(gameObject, collectDuration);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && ( other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2")))
        {
            OnCollect();
        }
        if (gameObject.CompareTag("LastTag"))
        {
            //float newXPosition = -232.4f;
            if (other.gameObject.CompareTag("Player2"))
            {
                //newXPosition = 237;
                winner = 2;
                PlayerPrefs.SetInt("Winner", 2);
                PlayerPrefs.Save();
                
            }
            /*// Trouver tous les objets avec le tag "winner"
            GameObject[] winners = GameObject.FindGameObjectsWithTag("winner");

            // Parcourir tous les objets gagnants et affecter la nouvelle position X
            foreach (GameObject winner in winners)
            {
                // Récupérer la position actuelle de l'objet
                Vector3 currentPosition = winner.transform.position;

                // Affecter la nouvelle position avec la même valeur Y et Z mais avec la nouvelle position X
                Vector3 newPosition = new Vector3(newXPosition, currentPosition.y, currentPosition.z);

                // Définir la nouvelle position à l'objet
                winner.transform.position = newPosition;*/
            /*if (!(SceneManager.GetSceneByName("WinScene").isLoaded))
            {
                Debug.Log("Win Scene pas loaded");
                SceneManager.LoadSceneAsync("WinScene", LoadSceneMode.Additive);
            }
            if (SceneManager.GetSceneByName("WinScene").isLoaded)
            {
                Debug.Log("Win Scene loaded");
                // Récupérez tous les objets ayant le tag "winner"
                GameObject[] winners = GameObject.FindGameObjectsWithTag("winner");

                // Parcourez chaque objet et affectez-lui la position X souhaitée
                foreach (GameObject winner in winners)
                {
                    // Assurez-vous que l'objet a un composant transform (qui contient la position)
                    if (winner.GetComponent<Transform>() != null)
                    {
                        // Affectez la nouvelle position X
                        Vector3 newPosition = winner.transform.position;
                        //newPosition.x = desiredXPosition;
                        winner.transform.position = newPosition;
                        // Récupérer la position actuelle de l'objet
                        Vector3 currentPosition = winner.transform.position;

                        // Affecter la nouvelle position avec la même valeur Y et Z mais avec la nouvelle position X
                        Vector3 newPosition = new Vector3(newXPosition, currentPosition.y, currentPosition.z);

                        // Définir la nouvelle position à l'objet
                        winner.transform.position = newPosition; 
                    }
                }
            }*/
        }
    }
}
