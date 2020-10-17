using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start() {
        Instantiate(cubePrefab, new Vector3( 0.0f, 0.0f, 0.1f), Quaternion.identity);
    }
}
