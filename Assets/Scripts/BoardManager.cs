using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int Width = 4;
    public int Height = 4;
    public Point PointPrefab;
    public Line LinePrefab;

    private Line[][] LineArray;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateBoard();
    }

    void Update()
    {
        
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                var p = new Vector2(i*2, j*2);             //Posicion para ubicar puntos
                var ldown = new Vector2(i * 2, j * 2 - 1); //Posicion para ubicar lineas verticales
                var lleft = new Vector2(i * 2 - 1, j * 2); //Posicion para ubicar lineas horizontales
                
                Instantiate(PointPrefab, p, Quaternion.identity); //Ubicamos los puntos del tablero

                if (i < Height - (Height - 1)) //Condicional para ubicar las lineas horizontales
                {

                }
                else
                {

                    Instantiate(LinePrefab, lleft, Quaternion.Euler(0f, 0f, 90f)); //Quaternion.Euler se encarga de rotar el LinePrefab
                }

                if (j < Width -(Width -1 )) //Condicional para ubicar las lineas verticales
                {
                    
                }
                else
                {
                    Instantiate(LinePrefab, ldown, Quaternion.identity);
                }
            }
        }

        var center = new Vector2((float)Height*2 / 2 - 0.5f, (float)Width*2 / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -20);
    }

    public void SetLine(Line l)
    {
        GameManager.Instance.SwitchPlayer();
    }

}
