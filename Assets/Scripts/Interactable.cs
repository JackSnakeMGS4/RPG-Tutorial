using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3.0f;
    bool isFocus = false;
    bool hasInteracted = false;

    Transform player;
    public Transform interactionWillOnlyHappenHere;

    public virtual void Interact()
    {
        //Interactables will each have their own interaction
        Debug.Log("Interacting");   
    }

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionWillOnlyHappenHere.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionWillOnlyHappenHere.position, radius);
    }

}
