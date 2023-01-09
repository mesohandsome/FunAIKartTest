using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public new Camera camera;
    int index = 0;

    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        string s = "test" + index.ToString() + ".jpg";
        this.RenderCameraToFile(s);
        index += 1;
    }

    void RenderCameraToFile(string filename)
    {
        // The resolution (640, 480) will get the performance of 10 frames per second
        // The frame number will be much less if the resolution is set bigger. e.g. (1024, 768) or (1920, 1080)
        RenderTexture rt = new RenderTexture(640, 480, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
        RenderTexture oldRT = camera.targetTexture;
        camera.targetTexture = rt;
        camera.Render();
        camera.targetTexture = oldRT;

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        RenderTexture.active = null;

        byte[] bytes = tex.EncodeToJPG();
        string path = "C:\\Users\\scream\\Desktop\\picture\\";

        System.IO.File.WriteAllBytes(path + filename, bytes);
    }
}
