using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleScript : MonoBehaviour {

    public int ImageCount = 6;

	// Use this for initialization
	void Start () {
        PickRandomImage();
        RotateRandom();
	}

    // Randomly pick one of the images in the spritesheet and apply it to the quad
    void PickRandomImage()
    {
        var mesh = GetComponentInChildren<MeshFilter>().mesh;
        int imageIndex = Random.Range(0, ImageCount - 1);
        Debug.Log(imageIndex);
        float x1 = ((float)imageIndex) / ((float)ImageCount);
        float x2 = ((float)(imageIndex + 1)) / ((float)ImageCount);

        Vector2[] uvs = {
            new Vector2(x1, 0f),
            new Vector2(x2, 1f),
            new Vector2(x2, 0f),
            new Vector2(x1, 1f)
        };
        mesh.uv = uvs;
    }                 

    // Pick a random rotation so they look different
    void RotateRandom()
    {
        transform.Rotate(0, 0, Random.Range(0, 359));
    }
}
