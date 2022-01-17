using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    [SerializeField]
    private PipesMovement pipesPrefab;
    [SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private float minHeight = -1f;
    [SerializeField]
    private float maxHeight = 1f;

    [SerializeField] 
    private float offset;
   
    private List<PipesMovement> pipesContainer = new List<PipesMovement>();
    
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
        var pipes = Instantiate(pipesPrefab, transform.position + Vector3.left * offset, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        pipesContainer.Add(pipes);

    }
    public void DestroyPipes()
    {
        for(int i = pipesContainer.Count -1; i >=0; i--)
        {
            var obj = pipesContainer[i];
            pipesContainer.Remove(obj);
            if(obj != null)
                Destroy(obj.gameObject);
        }
    }
}
