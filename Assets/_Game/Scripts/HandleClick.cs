using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleClick : Singleton<HandleClick>
{
    int click = 0;
    Node startNode;
    Node endNode;
    public void Handle(Node node)
    {
        if (click == 0)
        {
            startNode = node;
            Debug.Log("Start");
            click++;
        }
        else
        {
            endNode = node;
            Debug.Log("End");
            click = 0;
            BFS.Ins.BFSSearchWithTurns(startNode, endNode, 3);
            startNode = null;
            endNode = null;
        }
    }
}
