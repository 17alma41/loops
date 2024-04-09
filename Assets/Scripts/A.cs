using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    [SerializeField] int start;
    [SerializeField] int lenght;
    [SerializeField] float timeBetweenPrints;
    [SerializeField] GameObject prefab;
    int numberInstantiated;
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        /*
        for (int i = 0; i < times; i++)
        {
            //print(i);
            //print(i+1);
            //print(-i);
        }
        */

        StartCoroutine(loops());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator loops()
    {
        for (int i = start; i <= start + lenght -1; i++)
            for (int j = start; j <= start + lenght -1; j++)
                for (int k = start; k <= start + lenght -1; k++)
                {

                    position = new Vector3(j, i, k);
                    InstantiateAt(position);
                    yield return new WaitForSeconds(timeBetweenPrints);

                    //if (i == j) //Diagonal
                    //{
                    //    position = new Vector3(j, i, 0);
                    //    InstantiateAt(position);
                    //    yield return new WaitForSeconds(timeBetweenPrints); 
                    //}

                    //if (i == start || i == start + lenght -1 || j == start || j == start + lenght -1) //Marco
                    //{
                    //    position = new Vector3(j, i, 0);
                    //    InstantiateAt(position);
                    //    yield return new WaitForSeconds(timeBetweenPrints);
                    //}
                }
    }

    void InstantiateAt(Vector3 position)
    {
        GameObject instantiated = Instantiate(
            prefab,
            position,
            Quaternion.identity
            );

        instantiated.name = "Sphere " + numberInstantiated++;
        print("Placing " + instantiated.name + " at " + position);

        float Normalize(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        instantiated.GetComponent<MeshRenderer>().material.color = new Color(
        Normalize(position.x, 0, 5),
        Normalize(position.y, 0, 5),
        Normalize(position.z, 0, 5));
                    
    }
}
