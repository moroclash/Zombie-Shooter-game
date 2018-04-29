using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPropertice : MonoBehaviour {

    public float playerHelth = 1000f;
    public int playerScore = 0;
    public int playerCoins = 0;
    private Animator an;

    public Text score;
    public Text helth;
    public Text coin;
    private bool death = false;


    // Use this for initialization
    void Start()
    {
        an = GetComponent<Animator>();
        updateInfo();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        an.SetBool("hit", false);
        an.SetBool("death", false);
        
    }

    public void updatePlayerHelth(float impact)
    {
        if (playerHelth > impact)
        {
            an.SetBool("hit", true);
            playerHelth -= impact;
            updateInfo();
        }
        else
        {
            if (!death)
            {
                //player dead
                an.SetBool("death", true);
                playerHelth = 0;
                updateInfo();
                death = true;
            }
        }
    }


    public void updatePlayerScore(int score)
    {
        playerScore += score;
        updateInfo();
    }


    public void AddPlayerCoin(int coin)
    {
        playerCoins += coin;
        updateInfo();
    }


    public bool takecoin(int coin)
    {
        if (playerCoins < coin)
        {
            playerCoins -= coin;
            updateInfo();
            return true;
        }
        else
        {
            updateInfo();
            return false;
        }
    }

    public void updateInfo()
    {
        score.text = playerScore.ToString();
        coin.text = playerCoins.ToString();
        helth.text = playerHelth.ToString();
    }


}
