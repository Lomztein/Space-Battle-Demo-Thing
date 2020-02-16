using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Transform Transform;
    public float ShrinkIterations;

    private IEnumerator _current;

    public void Animate ()
    {
        if (_current != null)
        {
            StopCoroutine(_current);
        }

        _current = DoFlash();
        StartCoroutine(_current);
    }

    private IEnumerator DoFlash ()
    {
        Transform.localScale = Vector3.one * Random.Range (0.9f, 1.1f);
        Transform.Rotate(0f, Random.Range(0, 360), 0f, Space.Self);
        for (int i = 0; i < ShrinkIterations; i++)
        {
            Transform.localScale = Vector3.one * (1 - i / ShrinkIterations);
            yield return new WaitForFixedUpdate();
        }
        Transform.localScale = Vector3.zero;
        _current = null;
    }
}
