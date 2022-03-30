using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public static Line Instance;
    public GameObject Inner;
    public Vector2 Pos => _position;
    public bool active;
    public string type;

    private Vector2 _position;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(Vector2 position, bool active)
    {
        this._position = position;
        this.active = active;
    }

    private void OnMouseDown()
    {
        if (Inner.GetComponent<SpriteRenderer>().color != Color.blue && Inner.GetComponent<SpriteRenderer>().color != Color.red)
        {
            if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
            {
                this.active = true;
                Inner.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else
            {
                this.active = true;
                Inner.GetComponent<SpriteRenderer>().color = Color.red;
            }
        BoardManager.Instance.SetLine(this);

        }
        
    }

    public bool isActive()
    {
        return this.active;
    }
}
