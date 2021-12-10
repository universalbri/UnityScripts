using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject m_player;
    private GameObject m_playerHead;
    private GameObject m_playerEyes;
    private const float MOVEMENTSPEED = 0.2f;
    private const float ROTATIONSPEED = 0.2f;
    private const float ROTYMULT = 1.0f;
    private const float ROTXMULT = 1.0f;
    
    private const float MAXYROTANGLE = 45.0f;
    private Vector3 m_curMousePosition;
    private Vector3 m_playerPos;
    private Vector3 m_startMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_playerHead = GameObject.Find("Player Head");
        m_playerEyes = GameObject.Find("Player Eyes");
        m_startMousePosition = m_curMousePosition = Input.mousePosition;
        m_playerPos = m_player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            m_playerPos += (m_player.transform.forward * MOVEMENTSPEED);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) )
            m_playerPos -= (m_player.transform.forward * MOVEMENTSPEED);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            m_playerPos += (m_player.transform.right * MOVEMENTSPEED);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            m_playerPos -= (m_player.transform.right * MOVEMENTSPEED);

        m_playerPos.y = 0f; // never transform up. 
        m_player.transform.position = m_playerPos;

        if (Input.GetAxis("Mouse Y") < 0)
        {
            m_playerHead.transform.Rotate(Vector3.right, ROTYMULT);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            m_playerHead.transform.Rotate(Vector3.right, -ROTYMULT);
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            m_player.transform.Rotate(Vector3.up, -ROTXMULT);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            m_player.transform.Rotate(Vector3.up, ROTXMULT);
        }
    }
}
