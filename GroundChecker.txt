using UnityEngine;
/*** A script on a child of player character
* It should have a small BoxCollider2D set to trigger to just touch the ground
***/
public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    public BoxCollider2D collider;
    private int groundContacts = 0;

    public void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        //Empty
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        groundContacts++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        groundContacts--;
        if (groundContacts <= 0)
        {
            isGrounded = false;
            groundContacts = 0;
        }
    }


}