using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int Width = 4;
    public int Height = 4;
    public Point PointPrefab;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                var p = new Vector2(i, j);
                Instantiate(PointPrefab, p, Quaternion.identity);
            }
        }

        var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -20);
    }

    public void SetPoint(Point p)
    {
        GameManager.Instance.SwitchPlayer();
    }

}
