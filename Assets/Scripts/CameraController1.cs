using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private Camera camera;
    private float lookAhead;

    // Start is called before the first frame update
    void Start()
    {
       //camera = GetComponent<Camera>();
       //camera.backgroundColor=Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, 
            player.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x),
            Time.deltaTime * cameraSpeed);
    }
}
