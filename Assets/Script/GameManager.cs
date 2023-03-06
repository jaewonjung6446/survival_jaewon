using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Pooling pool;
    public UIManager UI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if(Instance != null)
        {
            Destroy(this);
        }
    }
}
