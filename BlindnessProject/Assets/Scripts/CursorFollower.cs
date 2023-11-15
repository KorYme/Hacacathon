using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    private IEnumerator Start()
    {
        Camera main = Camera.main;
        while (Application.isPlaying)
        {
            transform.position = ((Vector2)main.ScreenToWorldPoint(Input.mousePosition));
            yield return null;
        }
    }
}
