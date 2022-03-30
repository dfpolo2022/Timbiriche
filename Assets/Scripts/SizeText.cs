using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SizeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValue(float size)
    {
        this.GetComponent<TextMeshProUGUI>().text = "SIZE: "+size+"x"+size;
    }
}
