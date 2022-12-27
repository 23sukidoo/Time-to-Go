using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{

    public Text totalFruits;

    public Text fruitsCollected;

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }


    private void Update()
    {
        AllCoinsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
        
    }
    public void AllCoinsCollected()
    {
        if(transform.childCount==0)
        {
            Debug.Log("No quedan monedas, Victoria");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    }
}
