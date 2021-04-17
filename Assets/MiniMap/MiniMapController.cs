using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            //Follow Y axis
            Vector3 newPostion = player.position;
            newPostion.y = transform.position.y;
            transform.position = newPostion;

            //Rotate
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);

        }
    }
}
