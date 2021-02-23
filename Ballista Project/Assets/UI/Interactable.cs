using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform Player;
    public Transform interactionTransform;


    bool isFocus = false;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {

    }

    public void OnFocused()
    {

    }

    public void OnDefocused()
    {

    }

    private void Update()
    {
        if (Vector3.Distance(Player.position, interactionTransform.position) < 5)
        {
            isFocus = true;

        }
        else
        {
            isFocus = false;
        }

        if (isFocus == true)
        {
            Interact();
        }
    }
}
