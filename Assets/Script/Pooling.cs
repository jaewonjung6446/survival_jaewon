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
    public GameObject[] prefabsClone;
    public Queue<GameObject>[] pools;
    private void Awake()
    {
        pools = new Queue<GameObject>[prefabs.Length];
        prefabsClone = new GameObject[prefabs.Length];
        for(int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new Queue<GameObject>();
            GameObject G_prefabsClone = GameObject.Instantiate(prefabs[i]);
            G_prefabsClone.SetActive(false);
            G_prefabsClone.transform.position = new Vector3(0,1,0);
            prefabsClone[i] = G_prefabsClone;
        }
        SetPool();
    }

    private void SetPool()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {
            for(int m = 0; m<100; m++)
            {
                GameObject prefab = GameObject.Instantiate(prefabs[i]);
                prefab.SetActive(false);
                pools[i].Enqueue(prefab);
            }
        }
    }
    public void GetPool(int enum_index,Vector3 genvec)
    {
        GameObject get_pool = null;
        if (pools[enum_index] == null)
        {
            get_pool = GameObject.Instantiate(prefabs[enum_index]);
        }
        if (pools[enum_index] != null)
        {
            get_pool = pools[enum_index].Dequeue();
        }
        get_pool.SetActive(true);
        get_pool.transform.position = genvec;
    }
    public void DesPool(GameObject obj)
    {
        for (int i = 0; i < prefabsClone.Length; i++)
        {
            if (prefabsClone[i].name == obj.name)
            {
                obj.SetActive(false);
                pools[i].Enqueue(obj);
            }
        }
    }
}
