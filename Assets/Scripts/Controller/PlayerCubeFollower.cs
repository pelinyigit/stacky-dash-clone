using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeFollower : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall" )
        {
            EventManager.onCollisionWall.Invoke();
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropDash")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            EventManager.OnDashDropped.Invoke();
        }
    }
}
