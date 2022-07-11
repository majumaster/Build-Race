using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController cc;
    DataBoards dataBoards = new DataBoards();
    [SerializeField] Bot bot;
    WayData wayData = new WayData();
    [SerializeField]Animator m_animator=null;
    [SerializeField] private float m_moveSpeed = 1;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 15;

    private Vector3 m_currentDirection = Vector3.zero;
    Vector3 targetPosition_=new Vector3();
    public float speed = 2;
    public bool isBuild = false;
    int count = 0;
    public bool isEnd = false;
    int maxCube_ = 6;
    float v = 0;
    float h = 0;
    float m_HitStart = 0f;
    float m_minTimeHit = 2f;
    //bool m_isGrounded=false;
    private void FixedUpdate()
    {
        ///*
        
        if (!isEnd)
        {
            if (isBuild != true)
            {
                if (bot.GetCountBoard() < maxCube_)
                {
                    if (SearchTheClosestCube())
                    {
                        if (gameObject.transform.position.z != targetPosition_.z || gameObject.transform.position.x != targetPosition_.x)
                        {
                            //Goto(targetPosition_);
                            DirectUpdate();
                        }
                    }
                }
                else
                {
                    isBuild = true;
                }
            }
            else
            {
                if (Mathf.Abs(Mathf.Abs(gameObject.transform.position.x) - Mathf.Abs(wayData.bridgePositin[count].x)) > 0.2 || Mathf.Abs(Mathf.Abs(gameObject.transform.position.z) - Mathf.Abs(wayData.bridgePositin[count].z)) > 0.2)
                {
                    //Goto(wayData.bridgePositin[count]);
                    targetPosition_ = wayData.bridgePositin[count];
                    DirectUpdate();

                    Debug.Log("bot ma isc do " + wayData.bridgePositin[count]);
                }
                else
                {
                    count++;
                    if (count % 2 == 0) { isBuild = false; }
                    if (count == 6) { isEnd = true; }
                }

            }
        }
        //m_animator.SetFloat("MoveSpeed", speed);

    }

    public bool SearchTheClosestCube()
    {
        double way = 999999999;
        Vector3 wayToCube;
        for (int i=0;i< dataBoards.GetCountFromList(); i++)
        {
            wayToCube = dataBoards.GetPosition(i);
            if (way > (Mathf.Sqrt(Mathf.Pow(wayToCube.x - gameObject.transform.position.x, 2) + Mathf.Pow(wayToCube.z - gameObject.transform.position.z, 2))))
            {

                way = Mathf.Sqrt(Mathf.Pow(wayToCube.x - gameObject.transform.position.x, 2) + Mathf.Pow(wayToCube.z - gameObject.transform.position.z, 2));
                targetPosition_ = wayToCube;
            }
        }
        
        if (way == 999999999)
        {
            return false;
        }
        return true;
    }
    public void Goto(Vector3 theClosestCube_)
    {

        if (gameObject.transform.position.x < theClosestCube_.x)
        {
            gameObject.transform.position+=new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (gameObject.transform.position.x > theClosestCube_.x)
        {
            gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (gameObject.transform.position.z < theClosestCube_.z)
        {
            gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (gameObject.transform.position.z > theClosestCube_.z)
        {
            gameObject.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }

    }
    public void Goto2(Vector3 theClosestCube_)
    {

        if (gameObject.transform.position.x < theClosestCube_.x)
        {
            h = 1;
        }
        if (gameObject.transform.position.x > theClosestCube_.x)
        {
            h = -1;
        }
        if (gameObject.transform.position.z < theClosestCube_.z)
        {
            v = 1;
        }
        if (gameObject.transform.position.z > theClosestCube_.z)
        {
            v = -1;
        }

    }
    ///*
    private void DirectUpdate()
    {
        Goto2(targetPosition_);

        Transform camera = Camera.main.transform;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero && !m_animator.GetBool("Hit"))
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }
        m_animator.SetTrigger("Land");
        Hiting();
    }
    void Hiting()
    {
        bool HitOver = (Time.time - m_HitStart) >= m_minTimeHit;
        if (HitOver)
        {
            if (m_animator.GetBool("Hit"))
            {
                m_animator.SetBool("Hit", false);
            }
            m_HitStart = Time.time;

        }



    }
    //*/
    public void NewTargetPosition(Vector3 vector3)
    {
        targetPosition_ = vector3;
    }

}
