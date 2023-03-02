using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RePosition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject grid;
    [SerializeField] GameObject[] terrain = new GameObject[3];
    Vector3 reposition = Vector3.zero;
    Vector3[] currentpos_x = { new Vector3(-20, 0, 0), new Vector3(0, 0, 0), new Vector3(20, 0, 0) };
    Vector3[] currentpos_y = { new Vector3(0, -20, 0), new Vector3(0, 0, 0), new Vector3(0, 20, 0) };
    Vector3[] currentposes = new Vector3[9];
    GameObject[] ground = new GameObject[9];
    Vector3[] groundVec = new Vector3[20];
    Queue<Vector3> groundqueue = new Queue<Vector3>();
    List<Vector3> getPos = new List<Vector3>();
    Vector3 difVec;
    Vector3 gap = new Vector3(10, 10, 0);
    List<Vector3> intersect = new List<Vector3>();
    Queue<GameObject> movGameObject = new Queue<GameObject>();
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!this.gameObject.CompareTag("Area"))
            return;
        if (collision.CompareTag("Ground"))
        {
            CurPosGet();
            GroundPosGet();
            GetMinus(currentposes, groundqueue.ToArray());
            Reposition(getPos);
            getPos.Clear();
            groundqueue.Clear();
            currentposes = new Vector3[9];
        }
    }
    void CurPosGet()
    {
        Vector3 currentPos = new Vector3 (Mathf.Round(player.transform.position.x/20)*20, Mathf.Round(player.transform.position.y/20)*20,0);
        int current = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 genpos = currentPos + currentpos_x[i] + currentpos_y[j];
                currentposes[current] = genpos;
                current++;
            }
        }
    }
    void GroundPosGet()
    {
        ground = GameObject.FindGameObjectsWithTag("Ground");
        for(int i =0; i < ground.Length; i++)
        {
            groundqueue.Enqueue(ground[i].transform.position);
        }
    }
    void GetMinus(Vector3[] from, Vector3[] a)
    {
        IEnumerable<Vector3> b = from.Except(a);
        getPos = b.ToList();
    }
    void Reposition(List<Vector3> a)
    {
        for(int i=0; i < a.Count; i++)
        {
            GameObject gen = null;
            gen = GameObject.Instantiate(terrain[Random.Range(0,2)], grid.transform);
            gen.transform.position = a[i];
        }
    }
}
