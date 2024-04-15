using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class While : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] List<Transform> Points;
    int startPoint = 0;
    int endPoint = 1;

    [SerializeField] AnimationCurve ease;
    [SerializeField] float animationDuration;
    [SerializeField] float rotationDuration;

    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        //https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/

        elapsedTime = 0;
        StartCoroutine(AnimationLinearInterpolation());
        StartCoroutine(LerpRotation());
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

    IEnumerator LerpRotation()
    {
        while (true)
        {
            elapsedTime = 0;

            while (elapsedTime < rotationDuration)
            {
                //transform.rotation = Quaternion.LerpUnclamped(fromRotation, toRotation, ease.Evaluate(1f - elapsedTime / rotationDuration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
