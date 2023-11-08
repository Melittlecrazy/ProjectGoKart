using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture : MonoBehaviour
{
    public Texture[] textures;
    public float changeInterval;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Rand());
    }

    void Update()
    {
        //if (textures.Length == 0)
        //    return;
        //int bob = 
        // Mathf.FloorToInt(Time.time / changeInterval);
        //index = index % bob;
        
        
    }

    IEnumerator Rand()
    {
        
        int index = Random.Range(0, textures.Length);
        rend.material.mainTexture = textures[index];
        yield return new WaitForSeconds(changeInterval);
        StartCoroutine(Rand());
    }
}
