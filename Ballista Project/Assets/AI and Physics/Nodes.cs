using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public GameObject[] nodes;
    public float threshold = 10.0f;

    List<Vector3> links;
    List<Vector3> fromposition;

    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Nodes");

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
                    if (!Physics.Raycast(node1.transform.position, edge, threshold) && !cliff)
                    {
                        links.Add(edge);
                        fromposition.Add(node1.transform.position);
                    }
                }
            }
        }
    }

    void Update()
    {
        int j = 0;
        foreach (Vector3 link in links)
        {
            //Debug.DrawLine(fromposition[j], fromposition[j] + link, Color.red);
            //j++;
        }
    }
}
