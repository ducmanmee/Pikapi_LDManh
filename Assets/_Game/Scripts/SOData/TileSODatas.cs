using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new TileSOData", menuName = "Scriptable Objects/TileSODatas")]

public class TileSODatas : ScriptableObject
{
    [SerializeField] TileSO[] tileDatas;

    public Sprite GetSprite(TileType type)
    {
        for (int i = 0; i < tileDatas.Length; i++)
        {
            if (tileDatas[i].tileType == type)
            {
                return tileDatas[i].sprite;
            }
        }
        return null;
    }

    public TileSO GetRandom()
    {
        if (tileDatas == null || tileDatas.Length == 0)
        {
            Debug.LogWarning("Null or 0");
            return null;
        }

        int randomIndex = Random.Range(0, tileDatas.Length); 
        return tileDatas[randomIndex];
    }

}

[System.Serializable]
public class TileSO
{
    public Sprite sprite;
    public TileType tileType;
}

public enum TileType
{
    None = 0,
    Tile_1 = 1,
    Tile_2 = 2,
    Tile_3 = 3,
    Tile_4 = 4,
    Tile_5 = 5,
    Tile_6 = 6,
    Tile_7 = 7,
    Tile_8 = 8,
    Tile_9 = 9,
    Tile_10 = 10,
    Tile_11 = 11,
    Tile_12 = 12
}
