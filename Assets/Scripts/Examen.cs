using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Examen : MonoBehaviour
{
    [SerializeField] float maxXRotationSpeed;
    [SerializeField] float maxYRotationSpeed;
    [SerializeField] float maxZRotationSpeed;

    [SerializeField] float xAnimationDuration;
    [SerializeField] float yAnimationDuration;
    [SerializeField] float zAnimationDuration;

    float elapsedTime;

    [SerializeField] AnimationCurve ease;

    void Start()
    {
        StartCoroutine(xRotationSpeed());
        StartCoroutine(yRotationSpeed());
        StartCoroutine(zRotationSpeed());
    }

    IEnumerator xRotationSpeed()
    {
        while (true)
        {
            elapsedTime = 0;

            while (elapsedTime < xAnimationDuration)
            {
                elapsedTime += Time.deltaTime;

                float xRotation = Mathf.Lerp(-maxXRotationSpeed, maxXRotationSpeed, ease.Evaluate(elapsedTime / xAnimationDuration));

                transform.Rotate(xRotation * Time.deltaTime, 0, 0);

                yield return null;
            }

            yield return null;
        }
    }

    IEnumerator yRotationSpeed()
    {
        while (true)
        {
            elapsedTime = 0;

            while (elapsedTime < yAnimationDuration)
            {
                elapsedTime += Time.deltaTime;

                float yRotation = Mathf.Lerp(-maxYRotationSpeed, maxYRotationSpeed, ease.Evaluate(elapsedTime / yAnimationDuration));

                transform.Rotate(0, yRotation * Time.deltaTime, 0);

                yield return null;
            }

            yield return null;
        }

    }

    IEnumerator zRotationSpeed()
    {

        while (true)
        {
            elapsedTime = 0;

            while (elapsedTime < zAnimationDuration)
            {
                elapsedTime += Time.deltaTime;

                float zRotation = Mathf.Lerp(-maxZRotationSpeed, maxZRotationSpeed, ease.Evaluate(elapsedTime / zAnimationDuration));

                transform.Rotate(0, 0, zRotation * Time.deltaTime);

                yield return null;
            }

            yield return null;
        }
    }

}
