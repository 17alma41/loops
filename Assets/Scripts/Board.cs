using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int boardWidth;
    [SerializeField] int boardHeight;
    [SerializeField] float timeBetweenSpawns;
    List<GameObject> instantedObjects = new List<GameObject>();

    Vector3 position;
    TileScript tileAnimation;

    // Start is called before the first frame update
    void Start()
    {
        tileAnimation = GetComponent<TileScript>();
        StartCoroutine(CreateBoard());
        StartCoroutine(AnimateTiles());
    }

    IEnumerator CreateBoard()
    {
        for (int i = 0; i <= boardWidth; i++)
            for (int j = 0; j <= boardHeight; j++)
            {
                position = new Vector3(i, 0, j);
                InstantiateAt(position);

                yield return new WaitForSeconds(timeBetweenSpawns);
            }
    }

    
    IEnumerator AnimateTiles()
    {
        
        while (true)
        {
            for (int i = 0; i < instantedObjects.Count; i++)
            {
                GameObject obj = instantedObjects[i];

                
                StartCoroutine(tileAnimation.ScaleAnimation(obj));
                
                
                yield return null;
            }
            
        }
        
    }
    

    void InstantiateAt(Vector3 position)
    {
        GameObject instantiated = Instantiate(
           tilePrefab,
           transform
           );

        instantiated.transform.localPosition = position;

        instantedObjects.Add(instantiated);
    }
}
