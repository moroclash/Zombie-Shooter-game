using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;

    }
    #endregion

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Cancel") > 0)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }

}
