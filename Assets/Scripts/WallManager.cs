using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallManager : MonoBehaviour
{
    [SerializeField] Sprite blankTile;
    [SerializeField] Sprite grassTile;
    [SerializeField] GameObject tileObject;
    [SerializeField] GameObject parentObject;
    List<GameObject> tiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start() 
    {
        //make a field full of blank tiles able to be converted
        //every sprite will be 50 x 50 to get a grid of 30 x 15 tiles perfectly

        for (int i = 0; i < 15; i++) //y position of the grid
        {
            for (int j = 0; j < 30; j++)
            {
                tiles.Add(Instantiate<GameObject>(tileObject, parentObject.transform.position + new Vector3(j * 50, i * 50, 0), new Quaternion(), parentObject.transform));
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TargetHit(Input.mousePosition);
            //Debug.Log(Input.mousePosition);
        }
    }

    public void TargetHit(Vector2 position)
    {

        position -= new Vector2(parentObject.transform.position.x, parentObject.transform.position.y);

        int x = (int)(position.x / 50);
        int y = (int)(position.y / 50);

        Debug.Log("x = " + x + "   y = " + y);
        if (position.x < 0 || x >= 30 || position.y < 0 || y >= 15)
        {
            Debug.Log("outside of the wall");
            return;
        }

        int hitTile = x + y * 30;
        List<int> hits = new List<int>();
        hits.Add(hitTile);
        bool notLeft = false;
        bool notRight = false;

        if (hitTile % 30 != 0) //not on left wall
        {
            hits.Add(hitTile - 1);
            notLeft = true;
        }
        if (hitTile% 30 != 29) //not on right wall
        {
            hits.Add(hitTile + 1);
            notRight = true;
        }
        if (hitTile + 30 < tiles.Count) //not on top wall
        {
            hits.Add(hitTile + 30);

            if (notLeft)
            {
                hits.Add(hitTile + 29);
            }
            if (notRight)
            {
                hits.Add(hitTile + 31);
            }
        }
        if (hitTile - 30 >= 0) //not on bottom wall
        {
            hits.Add(hitTile - 30);

            if (notLeft)
            {
                hits.Add(hitTile - 31);
            }
            if (notRight)
            {
                hits.Add(hitTile - 29);
            }
        }

        if (hitTile % 30 > 1)
        {
            hits.Add(hitTile - 2);
        }
        if (hitTile % 30 < 28)
        {
            hits.Add(hitTile + 2);
        }
        if (hitTile + 60 < tiles.Count)
        {
            hits.Add(hitTile + 60);
        }
        if (hitTile - 60 >= 0)
        {
            hits.Add(hitTile - 60);
        }


        foreach (int hit in hits)
        {
            tiles[hit].GetComponent<Image>().sprite = grassTile;
        }

        //Debug.Log((int)(pos / 50)); //works well
    }
}
