using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{

    public new Light light;

    public float MinIntensity = 0f;
    public float MaxIntensity;

    public int Smoothing = 10;

    Queue<float> SmoothQueue;
    float LastSum = 0;

    public void Reset()
    {
        SmoothQueue.Clear();
        LastSum = 0;
    }

    public void Start()
    {
        SmoothQueue = new Queue<float>(Smoothing);
        if(light == null)
        {
            light = GetComponent<Light>();
        }
    }

    private void Update()
    {
        if(light == null)
            return;

            while(SmoothQueue.Count >= Smoothing)
            {
                LastSum -= SmoothQueue.Dequeue();
            }

        float NewVal = Random.Range(MinIntensity, MaxIntensity);
        SmoothQueue.Enqueue(NewVal);

        LastSum += NewVal;

        light.intensity = LastSum / (float)SmoothQueue.Count;
    }



}
