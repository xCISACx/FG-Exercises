using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeArt : MonoBehaviour
{
    public float repeatTime = 1f;
    public List<Material> Materials;

    private MeshRenderer currentRenderer;

    public CubeManager CubeManager;

    void Start()
    {
        currentRenderer = GetComponent<MeshRenderer>();

        switch (CubeManager.playMode)
        {
            case CubeManager.Mode.Start:
                ChangeTextureOnStart();
                break;
            case CubeManager.Mode.RandomStart:
                PickRandomTexture();
                break;
            case CubeManager.Mode.InvokeRepeating:
                InvokeRepeatingTextureChange();
                break;
            case CubeManager.Mode.Coroutine:
                StartCoroutine(ChangeTextureAfterSeconds());
                break;
        }
    }

    public void ChangeTextureOnStart()
    {
        currentRenderer.material = Materials[9];
    }

    public void PickRandomTexture()
    {
        currentRenderer.material = Materials[Random.Range(0, Materials.Count)];
    }

    public void InvokeRepeatingTextureChange()
    {
        InvokeRepeating("PickRandomTexture", 0, repeatTime);
    }

    IEnumerator ChangeTextureAfterSeconds()
    {
        while (true)
        {
            PickRandomTexture();
            yield return new WaitForSeconds(repeatTime);
        }
    }
}
