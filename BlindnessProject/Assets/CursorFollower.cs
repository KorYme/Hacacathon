using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    [SerializeField] Transform _lightTransform;

    private IEnumerator Start()
    {

        while (Application.isPlaying)
        {
            Debug.Log(Input.mousePosition);
            _lightTransform.position = Input.mousePosition;
            yield return null;
        }
    }
}
