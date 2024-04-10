using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1 : MonoBehaviour
{
    [Header("Instanciar esferas")]
    [SerializeField] int start;
    [SerializeField] int lenght;
    [SerializeField] float timeBetweenPrints;
    [SerializeField] GameObject prefab;

    int numberInstantiated;
    Vector3 position;

    [Header("Rotación del cubo")]
    [SerializeField] bool rotate = false;
    [SerializeField] Vector3 rotationSpeed;

    [SerializeField] List<GameObject> instantedObjects = new List<GameObject>();

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
        StartCoroutine(SphereRotation());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator loops()
    {
        for (int i = start; i <= start + lenght - 1; i++)
            for (int j = start; j <= start + lenght - 1; j++)
                for (int k = start; k <= start + lenght - 1; k++)
                {

                    //position = new Vector3(j, i, k);
                    //InstantiateAt(position);
                    //yield return new WaitForSeconds(timeBetweenPrints);

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

                    if (j == start && i == start ||
                        i == start && k == start ||
                        k == start && j == start ||
                        j == start && i == start + lenght -1 ||
                        i == start && k == start + lenght -1 ||
                        k == start && j == start + lenght -1 ||
                        j == start + lenght -1 && i == start ||
                        i == start + lenght - 1 && k == start||
                        k == start + lenght - 1 && j == start ||
                        j == start + lenght -1 && i == start + lenght -1||
                        i == start + lenght -1 && k == start + lenght -1||
                        k == start + lenght -1 && j == start + lenght -1) //Cubo con solo las aristas
                    {
                       position = new Vector3(j, i, k);
                       InstantiateAt(position);
                       yield return new WaitForSeconds(timeBetweenPrints);
                    }
                }
   
    }

    void InstantiateAt(Vector3 position)
    {
        GameObject instantiated = Instantiate(
            prefab,
            transform
            );

        instantiated.transform.localPosition = position;

        instantiated.name = "Sphere " + numberInstantiated++;
        print("Placing " + instantiated.name + " at " + position);

        instantedObjects.Add(instantiated);

        float Normalize(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        instantiated.GetComponent<MeshRenderer>().material.color = new Color(
        Normalize(position.x, 0, 5),
        Normalize(position.y, 0, 5),
        Normalize(position.z, 0, 5));

        StartCoroutine(DestroySphere());
    }

    IEnumerator SphereRotation()
    {
        while (true)
        {
            if(rotate == true)
            {
                transform.Rotate(rotationSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    IEnumerator DestroySphere()
    {
        for (int i = 0; i < instantedObjects.Count; i++)
        {
            Destroy(instantedObjects[i]);
            instantedObjects.Clear();
        }
        yield return null;
    }
    
}
