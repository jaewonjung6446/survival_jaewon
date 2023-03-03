using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    enum PoolType
    {
        circle1 = 0,
        circle2 = 1,
        circle3 = 2
    }
    public GameObject[] prefabs;
    public Queue<GameObject>[] pools;
    private void Awake()
    {
        pools = new Queue<GameObject>[prefabs.Length];
        for(int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new Queue<GameObject>();
        }
        SetPool();
    }

    void SetPool()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {
            for(int m = 0; m<100; m++)
            {
                GameObject prefab = Instantiate(prefabs[i]);
                prefab.SetActive(false);
                pools[i].Enqueue(prefab);
            }
        }
    }
    public void GetPool(int enum_index,Vector3 genvec)
    {
        GameObject get_pool = null;
        if (!pools[enum_index].Contains(prefabs[enum_index]))
        {
            get_pool = GameObject.Instantiate(prefabs[enum_index]);
        }
        if (pools[enum_index].Contains(prefabs[enum_index]))
        {
            get_pool = pools[enum_index].Dequeue();
        }
        get_pool.SetActive(true);
        get_pool.transform.position = genvec;
    }
    void DesPool(GameObject obj)
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            if(prefabs[i].name == obj.name)
            {
                obj.SetActive(false);
                pools[i].Enqueue(obj);
            }
        }
    }
}
