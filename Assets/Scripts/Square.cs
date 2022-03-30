using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public static Square Instance;
    public GameObject Inner;
    public Vector2 Pos => _position;

    private Vector2 _position;
    private int sides;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(Vector2 position)
    {
        this._position = position;
        this.sides = 0;
    }

    // Update is called once per frame
    void Update()
    {
    if (CheckActive())
        {
            SetActive();
        }
        
    }

    public void AddSides()
    {
        this.sides++;
    }

    public bool CheckActive()
    {
        if(this.sides == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetActive()
    {

            if (Inner.GetComponent<SpriteRenderer>().color != Color.blue && Inner.GetComponent<SpriteRenderer>().color != Color.red)
            {
                if (GameManager.Instance.GetGameState == GameManager.GameState.player2)
                {
                    Inner.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 150);
                }
                else
                {
                    Inner.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 150);
            }
            }

    }


}
