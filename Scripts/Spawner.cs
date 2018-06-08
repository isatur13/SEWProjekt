using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public  GameObject[] platforms;
    public GameObject top;
    public GameObject mid;
    public GameObject bot;
    float maxV = 3f;
    float minV = 0f;
    float r;
    public float groundRadius1 = 2f;
    public LayerMask ground;

    void Start () {
        
	}

    private void Update()
    {
        if (!Physics2D.OverlapCircle(top.transform.position, groundRadius1, ground) && !Physics2D.OverlapCircle(mid.transform.position, groundRadius1, ground) && !Physics2D.OverlapCircle(bot.transform.position, groundRadius1, ground))
        {
            Spawn();
        }
    }

    void Spawn() 
    {
        r = Random.Range(minV, maxV);
        if(r <= 1)
        {
            Instantiate(platforms[Random.Range(0,platforms.GetLength(0))],top.transform.position, Quaternion.identity);
        }
        if (r <= 2 && r>1)
        {
            Instantiate(platforms[Random.Range(0, platforms.GetLength(0))], mid.transform.position, Quaternion.identity);
        }
        if (r <= 3 && r>2)
        {
            Instantiate(platforms[Random.Range(0, platforms.GetLength(0))], bot.transform.position, Quaternion.identity);
        }
    }
}
