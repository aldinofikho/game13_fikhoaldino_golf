using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public Vector3 Position => rb.position;

    public bool IsMoving => rb.velocity != Vector3.zero;
    bool isTeleporting;
    public bool IsTeleporting => isTeleporting;

    Vector3 lastPosition;



    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();

        }
    }

    internal void AddForce(Vector3 force)
    {

        // lastPosition = this.transform.position;
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero && rb.velocity.magnitude < 0.5f)
        {
            rb.velocity = Vector3.zero;
            //  rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Out")
        {
            //teleport;
        }
    }

    IEnumerator DelayedTeleport()
    {
        isTeleporting = true;
        yield return new WaitForSeconds(3);
        this.transform.position = lastPosition;
        isTeleporting = false;
    }
}
