using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    public List<GameObject> pipesContainer = new List<GameObject>();

    

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        pipesContainer.Add(pipes);

    }
    public void DestroyPipes()
    {
        for(int i = pipesContainer.Count -1; i >=0; i--)
        {
            var obj = pipesContainer[i];
            pipesContainer.Remove(obj);
            Destroy(obj);
        }
    }



}
