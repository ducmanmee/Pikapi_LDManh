using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int x;
    public int y;
    public bool isWalkable;
    public TileType tileType;

    [SerializeField] SpriteRenderer spriteRen;

    public void OnInit(Sprite sp, TileType type)
    {
        SetSprite(sp);
        tileType = type;
    }    

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetSprite(Sprite newSprite)
    {
        if (spriteRen != null && newSprite != null)
        {
            spriteRen.sprite = newSprite;
            Debug.Log(1);
        }
    }

    private void OnMouseDown()
    {
        HandleClick.Ins.Handle(this);
    }   
}
