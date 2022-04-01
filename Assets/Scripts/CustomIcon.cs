using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomIcon : MonoBehaviour
{
    public bool playerOne = false;
    public bool playerTwo = false;
    public int iconId;

    // Start is called before the first frame update
    void Start()
    {
        if (playerOne)
        {
            PlayerPrefs.SetInt("iconOne", 0);
        }
        else
        {
            PlayerPrefs.SetInt("iconTwo", 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (playerOne)
        {
            PlayerPrefs.SetInt("iconOne", iconId);
        }
        else
        {
            if (playerTwo)
            {
                PlayerPrefs.SetInt("iconTwo", iconId);
            }
            
        }
    }
}
