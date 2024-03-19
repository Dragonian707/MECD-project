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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {

    }
}
