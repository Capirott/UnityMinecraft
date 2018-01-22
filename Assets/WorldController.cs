using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {
    public GameObject block;

    public int width = 10;
    public int height = 2;
    public int depth = 10;

    public IEnumerator BuildWorld()
    {
        for (int z = 0; z < depth; ++z)
        {
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    GameObject cube = GameObject.Instantiate(block, pos, Quaternion.identity);
                    cube.GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));
                    cube.name = x + "_" + y + "_" + z;
                }
                yield return null;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(BuildWorld());
    }
}
