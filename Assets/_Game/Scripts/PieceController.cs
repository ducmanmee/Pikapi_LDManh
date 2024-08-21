using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : Singleton<PieceController>
{
    [SerializeField] List<Node> pieces = new List<Node>();
    
    public Node RandomPiece(int maxPiece)
    {
        Node N = null;
        if (pieces.Count < maxPiece) 
        {
            N = null;
        } 
        else
        {
            int randomIndex = Random.Range(0, maxPiece);
            N = pieces[randomIndex];
        }    
        
        return N;

    }    
}


