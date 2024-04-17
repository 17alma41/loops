using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] float targetScale;
    [SerializeField] float animationDuration;
    [SerializeField] AnimationCurve ease;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ScaleAnimation(GameObject prefab)
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
}
