using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float AnimTime = 6f;

    public float DissolveScale = 10f;

    public int RefreshFrequency = 10;

    private Renderer rend;

    private float halfAnimTime = 3f;

    private float curTime = 0f;

    private int curFrame = 0;

    private bool isDissolve = true;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Start()
    {
        halfAnimTime = AnimTime * 0.5f;
    }

    private void Update()
    {
        if (curTime >= AnimTime)
        {
            curTime = 0f;
            isDissolve = true;
        }
        if (curTime >= halfAnimTime)
        {
            isDissolve = false;
        }

        curTime += Time.deltaTime;

        float percentage;
        if (isDissolve)
            percentage = curTime / halfAnimTime;
        else
            percentage = (AnimTime - curTime) / halfAnimTime;

        curFrame++;
        if (curFrame < RefreshFrequency)
            return;
        else
            curFrame = 0;

        float scale = Mathf.Clamp(DissolveScale * percentage, 1, DissolveScale);

        rend.material.SetFloat("_Dissolve", scale);
    }
}