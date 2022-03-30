using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public int SliderN;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("nxn", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetGridSize(float size)
    {
        PlayerPrefs.SetInt("nxn", (int)size);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnMouseDown()
    {
        ChangeScene();
    }
}
