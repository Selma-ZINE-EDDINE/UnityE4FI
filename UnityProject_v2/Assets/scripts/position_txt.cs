using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_txt : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/
    //public PickupObject checkpoint;
    public int WinnerPlayer = 1;
    void Start()
    {
        WinnerPlayer = PlayerPrefs.GetInt("Winner");
        if (WinnerPlayer == 1)
        {
            //Vector3 p = new Vector3(-232.4f, 147.34f, 0);
            transform.position = new Vector3(580f, 750f, 0);
        }
        if (WinnerPlayer == 2)
        {
            Vector3 p = new Vector3(1300f, 750f, 0);
            this.transform.position = p;
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
