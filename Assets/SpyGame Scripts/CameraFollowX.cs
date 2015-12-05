using UnityEngine;
using System.Collections;

public class CameraFollowX : MonoBehaviour
{

    public GameObject Spy;

    void Start()
    {
        Spy = GameObject.Find("Spy");
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = new Vector3(Spy.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

    }
}
