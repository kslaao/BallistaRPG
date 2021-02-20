using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public GameObject[] NPCs;
    public int i;

    private Nodes nodes;

    void Start()
    {
        nodes = FindObjectOfType<Nodes>();
        i = Random.Range(0, nodes.nodes.Length);
    }

    public float timer;

    private void Moving()
    {
            float distancetopoints = Vector3.Distance(nodes.nodes[i].transform.position, transform.position);

            if (distancetopoints < 0.5f)
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    i = UnityEngine.Random.Range(0, nodes.nodes.Length);
                    timer = 0;
                }
                if (i < nodes.nodes.Length)
                {
                    transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
            }
            if (i == nodes.nodes.Length)
            {
                i = 0;
                transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
            }

            Vector3 NPCPos = transform.position;
            float posX = NPCPos.x;
            float posY = NPCPos.y;
            transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
        }

        // Update is called once per frame
    void Update()
    {
        Moving();
    }
}
