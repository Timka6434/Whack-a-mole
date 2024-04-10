using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour
{
  public float _Speed;
    public float _Rotate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Rotate = _Rotate - _Speed;
        transform.rotation = Quaternion.Euler(0,0, _Rotate);
    }
}
