using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletObjectPool : MonoBehaviour
{
    Queue<GameObject> pooledObject;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    private void Awake()
    {
        pooledObject = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab,transform);
            pooledObject.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObject.Dequeue();
        obj.SetActive(true);
        pooledObject.Enqueue(obj);
        return obj;
    }
}
