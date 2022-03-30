using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int Width;
    public int Height;
    public Point PointPrefab;
    public Line LinePrefab;
    public Square SquarePrefab;
    public bool[,] score;
    public int scoreOne = 0;
    public int scoreTwo = 0;

    public List <Line> LineList;
    public List <Square> SquareList;
    private int max;

    private void Awake()
    {
        Height = PlayerPrefs.GetInt("nxn");
        Width = PlayerPrefs.GetInt("nxn");
        Instance = this;
        max = (Height - 1) * (Width - 1);
        score = new bool[max, 2];
    }

    void Start()
    {
        GenerateBoard();
    }

    void Update()
    {

    }

    //GENERACION DE EL TABLERO DE JUEGO
    private void GenerateBoard()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                var p = new Vector2(j*2, i*2);             //Posicion para ubicar puntos
                var s = new Vector2(j * 2 - 1, i * 2 - 1); //Posicion para ubicar cuadrados
                
                Instantiate(PointPrefab, p, Quaternion.identity); //Ubicamos los puntos del tablero

                if (i < Height - (Height - 1) || j < Width - (Width - 1))
                {

                } //Ubicamos cuadrados en el tablero
                else
                {
                    SquareList.Add(Instantiate(SquarePrefab, s, Quaternion.identity));
                }
            }
        }

        for (int i = 0; i < Height+1; i++)
        {
            for (int j = 0; j < Width-1; j++)
            {
                var lleft = new Vector2(j * 2+1, i * 2-2); //Posicion para ubicar lineas horizontales

                if (i < Height - (Height - 1)) //Condicional para ubicar las lineas horizontales
                {

                } //Ubicamos lineas horizontales en el tablero
                else
                {
                    LineList.Add(Instantiate(LinePrefab, lleft, Quaternion.Euler(0f, 0f, 90f))); //Quaternion.Euler se encarga de rotar el LinePrefab 
                    LineList[LineList.Count - 1].type = "Horizontal";
                }
            }
        }

        for (int i = 0; i < Width-1; i++)
        {
            for (int j = 0; j < Height+1; j++)
            {
                var ldown = new Vector2(j * 2-2, i * 2 +1); //Posicion para ubicar lineas verticales

                if (j < Width - (Width - 1)) //Condicional para ubicar las lineas verticales
                {

                } //Ubicamos lineas verticales en el tablero
                else
                {
                    LineList.Add(Instantiate(LinePrefab, ldown, Quaternion.identity));
                    LineList[LineList.Count - 1].type = "Vertical";
                }
            }
        }

        var center = new Vector2((float)Height*2 / 2 - 0.5f, (float)Width*2 / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, (int)(center.y*1.2), -20);
        Camera.main.orthographicSize = 4 + (Height - 3)*2;
    }

    public void AssignSide(int side)
    {

    }

    //VERIFICACION DE CUADRADOS
    public void CheckSquare()
    {
        int divisor = max / (Height - 1);
        for(int i=0; i < max; i++)
        {
            int fila = i / divisor;
            if (this.LineList[i].isActive() && this.LineList[i+Height-1].isActive() && this.LineList[Height*(Width-1)+fila+i].isActive() && this.LineList[Height * (Width - 1)+fila + i+1].isActive())
            {
                this.SquareList[i].AddSides();
                this.SquareList[i].AddSides();
                this.SquareList[i].AddSides();
                this.SquareList[i].AddSides();
                score[i,0] = true;
            }
        }
    }

    public void SetLine(Line l)
    {
        l.active = true;
        bool valor = false;
        CheckSquare();
        //GameManager.Instance.SwitchPlayer();
        for(int i = 0; i < max; i++)
        {
            if(score[i, 0] && !score[i, 1])
            {
                score[i, 1] = true;
                valor = true;
                if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
                {
                    scoreOne++;
                }
                else
                {
                    scoreTwo++;
                }
                if (scoreOne > this.SquareList.Count/2)
                {
                    SceneManager.LoadScene("OneWin");
                    Debug.Log("Gana Jugador 1");
                }
                if (scoreTwo > this.SquareList.Count / 2)
                {
                    SceneManager.LoadScene("TwoWin");
                    Debug.Log("Gana Jugador 2");
                }
                UIManager.Instance.UpdateScores(scoreOne, scoreTwo);
            }
        }
        if (!valor)
        {
            GameManager.Instance.SwitchPlayer();
        }
    }

}
