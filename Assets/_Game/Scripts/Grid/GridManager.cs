using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    int width;
    public int Width() => width;
    int height;
    public int Height() => height;

    [SerializeField] float cellSize;
    Node[,] gridArray;

    [SerializeField] Node curNode;
    List<Node> nodes = new List<Node>();

    [SerializeField] TileSODatas tileSODatas;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        CreateGrid(7, 12);
    }    

    public void CreateGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        gridArray = new Node[width, height];

        //Check so luong node 
        int totalNodes = width * height;
        if (totalNodes % 2 != 0)
        {
            Debug.LogError("So node la so le.");
            return;
        }

        for (int i = 0; i < totalNodes / 2; i++)
        {
            Node nodeA = Instantiate(curNode, this.transform);
            TileSO tileA = tileSODatas.GetRandom();
            nodeA.OnInit(tileA.sprite, tileA.tileType);

            Node nodeB = Instantiate(curNode, this.transform);
            TileSO tileB = tileSODatas.GetRandom();
            nodeB.OnInit(tileB.sprite, tileB.tileType);

            nodes.Add(nodeA);
            nodes.Add(nodeB);
        }

        // Xáo trộn danh sách node
        Shuffle(nodes);

        // Đặt các node lên lưới
        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                int index = i * gridArray.GetLength(1) + j;
                nodes[index].transform.position = new Vector2(i * cellSize, j * cellSize);
                nodes[index].SetPosition(i, j);
                gridArray[i, j] = nodes[index];
            }
        }

        float gridW = width * cellSize;
        float gridH = height * cellSize;
        transform.position = new Vector2(-gridW / 2 + cellSize / 2, -gridH / 2 + cellSize / 2);
    }

    void Shuffle(List<Node> nodeList)
    {
        for (int i = nodeList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Node temp = nodeList[i];
            nodeList[i] = nodeList[randomIndex];
            nodeList[randomIndex] = temp;
        }
    }

    public Node GetNodeAtPos(int x, int y)
    {
        return gridArray[x, y];
    }    


 }
