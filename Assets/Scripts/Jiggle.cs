using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiggle : MonoBehaviour
{
    [SerializeField] private Vector2 homePosition;
    [SerializeField] private bool useDefaultHomePosition = true;
    [SerializeField][Min(1)] private int jumpsPerSecond;
    private float desyncVal;
    [SerializeField] private bool jiggleActive = true;
    [SerializeField] private int effectRadius = 1;
    private float pixelUnit = 1 / 16f;
    private bool routineLock = false;

    private void Start()
    {
        desyncVal = Random.Range(-1f/30f, 1f/30f);
        if (useDefaultHomePosition)
            homePosition = transform.position;
    }

    private void Update()
    {
        if (!routineLock && jiggleActive)
            StartCoroutine(Step());
    }

    private IEnumerator Step()
    {
        routineLock = true;

        while (jiggleActive)
        {
            // Pick a direction away from the center.
            float radThisFrame = Random.Range(0f, 360f);
            
            // Pick a random distance away from the center, in the chosen direction.
            Vector2 offThisFrame = new Vector2(Mathf.Cos(radThisFrame), Mathf.Sin(radThisFrame));
            offThisFrame *= Random.Range(0f, effectRadius);

            // Round to the nearest integer values, for the pixel offset.
            offThisFrame.x = Mathf.RoundToInt(offThisFrame.x);
            offThisFrame.y = Mathf.RoundToInt(offThisFrame.y);

            // Actually move the object.
            transform.position = offThisFrame * pixelUnit + homePosition;

            yield return new WaitForSeconds(1f / jumpsPerSecond + desyncVal);
        }

        routineLock = false;
    }
}
