using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fors : MonoBehaviour
{
    [SerializeField] int start = 0;
    [SerializeField] int lenght = 5;
    [SerializeField] float timeBetweenPrints = 0.5f;
    [SerializeField] GameObject prefab;

    int numberInstantiated;
    Vector3 position;
    Coroutine coroutine = null;

    [SerializeField] bool rotate = false;
    [SerializeField] Vector3 rotationSpeed;
    List<GameObject> instantedObjects = new List<GameObject>();

    void Start()
    {
        StartCoroutine(MainLoop());
        StartCoroutine(SphereRotation());
    }

    IEnumerator MainLoop()
    {
        while (true) { 

            coroutine = StartCoroutine(Loops());
            while (coroutine != null)
                yield return null;

            coroutine = StartCoroutine(DestroyObjects());
            while (coroutine != null)
                yield return null;
        }
    }

    IEnumerator Loops()
    {
        for (int i = start; i <= start + lenght - 1; i++)
            for (int j = start; j <= start + lenght - 1; j++)
                for (int k = start; k <= start + lenght - 1; k++)
                {
                    if (j == start && i == start ||
                        i == start && k == start ||
                        k == start && j == start ||
                        j == start && i == start + lenght - 1 ||
                        i == start && k == start + lenght - 1 ||
                        k == start && j == start + lenght - 1 ||
                        j == start + lenght - 1 && i == start ||
                        i == start + lenght - 1 && k == start ||
                        k == start + lenght - 1 && j == start ||
                        j == start + lenght - 1 && i == start + lenght - 1 ||
                        i == start + lenght - 1 && k == start + lenght - 1 ||
                        k == start + lenght - 1 && j == start + lenght - 1)
                    {
                        position = new Vector3(j, i, k);
                        InstantiateAt(position);
                        yield return new WaitForSeconds(timeBetweenPrints);
                    }
                }

        coroutine = null;
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

    }

    IEnumerator SphereRotation()
    {
        while (true)
        {
            if (rotate == true)
            {
                transform.Rotate(rotationSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    IEnumerator DestroyObjects()
    {
        while (instantedObjects.Count > 0)
        {
            Destroy(instantedObjects[0]);
            instantedObjects.RemoveAt(0);
            yield return new WaitForSeconds(timeBetweenPrints);
        }

        coroutine = null;
    }
}
