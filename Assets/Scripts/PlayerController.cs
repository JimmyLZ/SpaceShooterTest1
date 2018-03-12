using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary
{
    public float xMax, xMin, zMax, zMin;
}



public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float destroyTime = 0.3f;

    public float atackSpeed= 0.5f;
    private float nextFire = 0.0f;


     void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + atackSpeed;

            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();


            if (clone.gameObject.tag == "Bolt")
            {
                Destroy(clone, destroyTime);
            }
        }
        
    }
    void FixedUpdate()
    {

        float tilt = 3;
        var rigidBody = GetComponent<Rigidbody>();

        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        
        rigidBody.position = new Vector3
            (
            
              Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
              0.0f,
              Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
            );

        
            rigidBody.rotation = Quaternion.Euler(0.0f, rigidBody.velocity.y * 30, rigidBody.velocity.x * -tilt);

        
    }

    

}
