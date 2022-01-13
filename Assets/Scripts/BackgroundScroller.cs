using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed; 

    [SerializeField] private Vector2 offSet;

    [SerializeField] private Material material;


    // Update is called once per frame
    void Update()
    {
        offSet = moveSpeed * Time.deltaTime;

        material.mainTextureOffset += offSet;

    }
}
