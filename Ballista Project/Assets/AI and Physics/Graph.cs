using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    public GameObject[] nodes;
    public float threshold = 10.0f;

    List<Vector3> links;
    List<Vector3> fromposition;

    public GameObject AIplayer;
    public int i;
    public bool linedrawn;

    void Start()
    {
        int elements = this.transform.childCount;
        nodes = new GameObject[elements];

        links = new List<Vector3>();
        fromposition = new List<Vector3>();

        for (int i = 0; i < elements; i++)
        {
            nodes[i] = this.transform.GetChild(i).gameObject;
        }
        foreach (GameObject node1 in nodes)
        {
            foreach (GameObject node2 in nodes)
            {
                if (node1 == node2) continue;
                float dist = Vector3.Distance(node1.transform.position, node2.transform.position);
                if (dist < threshold)
                {
                    Vector3 edge = node2.transform.position - node1.transform.position;

                    bool cliff = false;
                    int steps = Mathf.FloorToInt(edge.magnitude);

                    for (int i = 0; i < steps; i++)
                    {
                        Vector3 pos = node1.transform.position + edge.normalized * i;
                        RaycastHit hit;
                        if (Physics.Raycast(pos, Vector3.down, out hit, threshold))
                        {
                            if (hit.distance > 1.5f) cliff = true;
                        }
                    }
                    //links.Add(edge);
                    //fromposition.Add(node1.transform.position);
                    if (!Physics.Raycast(node1.transform.position, edge, threshold) && !cliff)
                    {
                        links.Add(edge);
                        fromposition.Add(node1.transform.position);
                    }
                }
            }
        }

        i = Random.Range(0, nodes.Length);
    }

    public float timer;

    private void Moving()
    {
        float distancetopoints = Vector3.Distance(nodes[i].transform.position, AIplayer.transform.position);

        AIplayer.transform.position = Vector3.MoveTowards(AIplayer.transform.position, nodes[i].transform.position, 3.0f * Time.deltaTime);

        if (distancetopoints < 0.5f)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                timer = 0;
                i++;
                //i = UnityEngine.Random.Range(0, nodes.Length);
            }
            if (i < nodes.Length)
            {
                AIplayer.transform.position = Vector3.MoveTowards(AIplayer.transform.position, nodes[i].transform.position, 3.0f * Time.deltaTime);
            }
        }
        else
        {
            AIplayer.transform.position = Vector3.MoveTowards(AIplayer.transform.position, nodes[i].transform.position, 3.0f * Time.deltaTime);
        }
        if (i == nodes.Length)
        {
            i = 0;
            AIplayer.transform.position = Vector3.MoveTowards(AIplayer.transform.position, nodes[i].transform.position, 3.0f * Time.deltaTime);
        }
    }

    void Update()
    {
        int j = 0;
        foreach (Vector3 link in links)
        {
            Debug.DrawLine(fromposition[j], fromposition[j] + link, Color.red);
            j++;
        }

        Moving();
    }
}
