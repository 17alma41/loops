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

    Material material;

    private void Awake()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    void Start()
    {
        if (rotationSpeed != Vector3.zero)
            StartCoroutine(RotationCoroutine());
        
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

}
