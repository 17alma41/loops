using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class While : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] List<Transform> Points;
    int startPoint = 0;
    int endPoint = 1;

    [SerializeField] AnimationCurve ease;
    [SerializeField] float animationDuration;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        //https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/

        elapsedTime = 0;
        StartCoroutine(AnimationLinearInterpolation());
    }


    IEnumerator AnimationLinearInterpolation()
    {

        while (true)
        {
            while (elapsedTime <= animationDuration)
            {
                elapsedTime += Time.deltaTime;
                objectToMove.position = Vector3.Lerp(Points[startPoint].position, Points[endPoint].position, elapsedTime / animationDuration);
                yield return null;
            }
            elapsedTime = 0;
            IndexCount();
        }

    }


    void IndexCount()
    {
        startPoint = endPoint;
        endPoint = (startPoint + 1) % Points.Count;
    }
}
