using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : Singleton<BFS>
{
    private enum Direction { Right, Down, Left, Up }

    private Dictionary<Direction, Vector2Int> directionOffsets = new Dictionary<Direction, Vector2Int>
    {
        { Direction.Right, new Vector2Int(1, 0) },
        { Direction.Down, new Vector2Int(0, -1) },
        { Direction.Left, new Vector2Int(-1, 0) },
        { Direction.Up, new Vector2Int(0, 1) }
    };

    public List<Node> BFSSearchWithTurns(Node startNode, Node endNode, int maxTurns)
    {
        Debug.Log("find...");
        int rows = GridManager.Ins.Width();
        int cols = GridManager.Ins.Height();
        bool[,] visited = new bool[rows, cols];
        Queue<PathNode> queue = new Queue<PathNode>();

        queue.Enqueue(new PathNode(startNode, -1, 0));
        visited[startNode.x, startNode.y] = true;

        while (queue.Count > 0)
        {
            PathNode currentNode = queue.Dequeue();

            if (currentNode.node == endNode)
            {
                List<Node> path = new List<Node>();
                while (currentNode != null)
                {
                    path.Add(currentNode.node);
                    currentNode = currentNode.previousNode;
                }
                path.Reverse();
                DrawPath(path);
                return path;
            }

            foreach (Direction direction in System.Enum.GetValues(typeof(Direction)))
            {
                Vector2Int offset = directionOffsets[direction];
                int newRow = currentNode.node.x + offset.x;
                int newCol = currentNode.node.y + offset.y;

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited[newRow, newCol])
                {
                    Node neighborNode = GridManager.Ins.GetNodeAtPos(newRow, newCol);

                    if (neighborNode != null && neighborNode.isWalkable)
                    {
                        int newTurns = currentNode.turns + (currentNode.direction == (int)direction ? 0 : 1);

                        if (newTurns > maxTurns)
                            continue;

                        queue.Enqueue(new PathNode(neighborNode, (int)direction, newTurns, currentNode));
                        visited[newRow, newCol] = true;
                    }
                }
            }
        }

        return null;
    }

    private void DrawPath(List<Node> path)
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            Debug.DrawLine(path[i].transform.position, path[i + 1].transform.position, Color.red, 5f);
        }
    }


    private class PathNode
    {
        public Node node;
        public int direction;
        public int turns;
        public PathNode previousNode;

        public PathNode(Node node, int direction, int turns, PathNode previousNode = null)
        {
            this.node = node;
            this.direction = direction;
            this.turns = turns;
            this.previousNode = previousNode;
        }
    }
}
