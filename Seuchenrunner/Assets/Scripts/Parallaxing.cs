using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;                         //Array für alle Vorder und Hintergründe
    private float[] parallaxScales;                         //Anteil der Bewegung der Kamera, um die Hintergründe zu verschieben
    public float smoothing = 1f;                            //Wie weich die parallaxe wird

    private Transform cam;                                  //referenz auf die Main Kamera
    private Vector3 previousCamPos;                         //die Position der Kamera im vorherigen Frame

    void Awake ()                                           //wird vor Start() aufgerufen
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;                      

        parallaxScales = new float[backgrounds.Length];     
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallaxX = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float parallaxY = (cam.position.y - previousCamPos.y) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX;
            float backgroundTargetPosY = backgrounds[i].position.y + parallaxY;

            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgroundTargetPosY, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        //Vorherige Kameraposition auf aktuelle Kameraposition setzen
        previousCamPos = cam.position;
    }
}
