using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    int width = 16;
    int height = 16;

    public GameObject pixelPrefab;
    public Material green;
    public Material red;
    public Material defaultMat;

    GameObject[,] pixels;

    void Start()
    {
        pixels = new GameObject[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject p = (GameObject) Instantiate(pixelPrefab, new Vector3(x * 1.5f, 0, y * 1.5f), Quaternion.identity);
                pixels[x, y] = p;
            }
        }
        deactivateAll();
    }

    void Update()
    {

    }

    public void setColor(int x, int y, string color)
    {
        GameObject p = pixels[x, y];

        Material material = (color == "red") ? red : green;
        p.GetComponent<MeshRenderer>().material = material;
    }

    public void deactivate(int x, int y)
    {
        GameObject p = pixels[x, y];
        p.GetComponent<MeshRenderer>().material = defaultMat;
    }

    public void deactivateAll()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                deactivate(x, y);
            }
        }
    }
}
