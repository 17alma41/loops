using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] float targetScale;
    [SerializeField] float animationDuration;
    [SerializeField] AnimationCurve ease;

    [HideInInspector] public Vector3 rotationSpeed = Vector3.zero;
    [HideInInspector] public int initialX;
    [HideInInspector] public int initialY;
    [HideInInspector] public int width;
    [HideInInspector] public int height;
    [HideInInspector] public float aSpeed;
    [HideInInspector] public float bSpeed;

    Material material;

    private void Awake()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    void Start()
    {
        if (rotationSpeed != Vector3.zero || aSpeed != 0 || bSpeed != 0)
        {

            StartCoroutine(RotationCoroutine());
            StartCoroutine(ColorCoroutine());
        }

    }

    public void Animation()
    {
        StartCoroutine(ScaleAnimation());
    }

    IEnumerator ScaleAnimation()
    {
        Vector3 scaleVector = new Vector3(targetScale, targetScale, targetScale);

        float elapsedTime = 0;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;

            transform.localScale = Vector3.LerpUnclamped(Vector3.one, scaleVector, ease.Evaluate(elapsedTime / animationDuration));
            yield return null;
        }
    }

    IEnumerator RotationCoroutine()
    {
        transform.Rotate(initialX * 5, initialY * 5, 0);

        while (true)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator ColorCoroutine()
    {
        float a = initialX;
        float b = initialY;
        float c = 0;
        float aDirection = 1;
        float bDirection = 1;
        float cDirection = 1;

        while (true)
        {
            a += Time.deltaTime * aSpeed * aDirection;
            if (a > width && aDirection > 0)
                aDirection = -1;
            else if (a < 0 && aDirection < 0)
                aDirection = 1;

            b += Time.deltaTime * bSpeed * bDirection;
            if (b > height && bDirection > 0)
                bDirection = -1;
            else if (b < 0 && bDirection < 0)
                bDirection = 1;

            c += Time.deltaTime * cDirection;
            if (c > height)
                cDirection = -1;
            else if (c < 0)
                cDirection = 1;

            material.color = new Color(
                a / width,
                b / height,
                c / height
            );

            yield return null;
        }
    }
}
