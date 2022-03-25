using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject Inner;
    public Vector2 Pos => _position;

    private Vector2 _position;

    public void Init(Vector2 position)
    {
        this._position = position;
    }

    private void OnMouseDown()
    {
        if (Inner.GetComponent<SpriteRenderer>().color != Color.blue && Inner.GetComponent<SpriteRenderer>().color != Color.red)
        {
            if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
            Inner.GetComponent<SpriteRenderer>().color = Color.blue;
            else
            Inner.GetComponent<SpriteRenderer>().color = Color.red;

        BoardManager.Instance.SetLine(this);

        }
        
    }
}
