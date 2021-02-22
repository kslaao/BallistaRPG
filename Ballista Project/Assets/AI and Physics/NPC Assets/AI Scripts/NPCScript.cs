using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{

    //
    public NavMeshAgent NPCNavMesh;
    public Animator NPCAnimator;
    //
    public GameObject[] NPCs;
    public int i;

    private Nodes nodes;

    void Start()
    {
        NPCAnimator = GetComponent<Animator>();
        NPCNavMesh = GetComponent<NavMeshAgent>();
        nodes = FindObjectOfType<Nodes>();
        //i = Random.Range(0, nodes.nodes.Length);
    }

    public float timer;

    private void Moving()
    {
            float distancetopoints = Vector3.Distance(nodes.nodes[i].transform.position, transform.position);

            if (distancetopoints < 0.5f)
            {
                NPCAnimator.SetBool("IsNearPoint", true);
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    i++;
                    //i = UnityEngine.Random.Range(0, nodes.nodes.Length);
                    timer = 0;
                }
                if (i < nodes.nodes.Length)
                {
                    NPCNavMesh.destination = nodes.nodes[i].transform.position;
                    //transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
                }
            }
            else
            {
                NPCAnimator.SetBool("IsNearPoint", false);
                NPCNavMesh.destination = nodes.nodes[i].transform.position;
                //transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
            }
            if (i == nodes.nodes.Length)
            {
                i = 0;
                NPCNavMesh.destination = nodes.nodes[i].transform.position;
                //transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
            }

            Vector3 NPCPos = transform.position;
            float posX = NPCPos.x;
            float posY = NPCPos.y;
            NPCNavMesh.destination = nodes.nodes[i].transform.position;
            //transform.position = Vector3.MoveTowards(transform.position, nodes.nodes[i].transform.position, 2.0f * Time.deltaTime);
    }

        // Update is called once per frame
    void Update()
    {
        Moving();
    }
}
