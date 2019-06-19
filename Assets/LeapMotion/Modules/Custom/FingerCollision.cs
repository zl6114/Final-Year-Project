using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using Leap;

//Attach this script to a GameObject with a Collider component
//Create an empty GameObject (Create>Create Empty) and attach it in the New Transform field in the Inspector of the first GameObject
//This script tells if a point  you specify (the position of the empty GameObject) is within the first GameObject’s Collider

public class FingerCollision : MonoBehaviour
{
    Controller controller;
    //communication
    public SerialPort sp = new SerialPort("COM7", 19200);
    public string message2;
    public string message2send;
    float timePassed = 0.0f;

    //game object 1
    public GameObject SampleObject1;
    public GameObject SampleObjectOuterRing1;
    public GameObject SampleObjectInnerRing1;
    Collider m_Collider1;
    Collider m_OuterCollider1;
    Collider m_InnerCollider1;
    //game object 2
    public GameObject SampleObject2;
    public GameObject SampleObjectOuterRing2;
    public GameObject SampleObjectInnerRing2;
    Collider m_Collider2;
    Collider m_OuterCollider2;
    Collider m_InnerCollider2;
    //game object 3
    public GameObject SampleObject3;
    public GameObject SampleObjectOuterRing3;
    public GameObject SampleObjectInnerRing3;
    Collider m_Collider3;
    Collider m_OuterCollider3;
    Collider m_InnerCollider3;

    public Vector3 Thumb;
    public Vector3 Index;
    public Vector3 Middle;
    public Vector3 Ring;
    public Vector3 Little;
    public Vector3 m_Center;
    string thumb;
    string index;
    string middle;
    string ring;
    string little;
    //Sending info = new Sending();

    // Start is called before the first frame update
    void Start()
    {
        OpenConnection();
        controller = new Controller();
        //Fetch the Collider from the GameObject this script is attached to
        m_Collider1 = SampleObject1.GetComponent<Collider>();
        m_OuterCollider1 = SampleObjectOuterRing1.GetComponent<Collider>();
        m_InnerCollider1 = SampleObjectInnerRing1.GetComponent<Collider>();

        m_Collider2 = SampleObject2.GetComponent<Collider>();
        m_OuterCollider2 = SampleObjectOuterRing2.GetComponent<Collider>();
        m_InnerCollider2 = SampleObjectInnerRing2.GetComponent<Collider>();

        m_Collider3 = SampleObject3.GetComponent<Collider>();
        m_OuterCollider3 = SampleObjectOuterRing3.GetComponent<Collider>();
        m_InnerCollider3 = SampleObjectInnerRing3.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        //print(message2send);
        sp.Write(message2send);
        thumb = index = middle = ring = little = string.Empty;
        message2send = string.Empty;
        message2send = string.Concat(message2send, "S");

        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand firstHand = hands[0];
            if (firstHand.IsLeft == true) {
                List<Finger> fingers = firstHand.Fingers;
                Thumb.x = fingers[0].TipPosition.x / 1000;
                Thumb.y = fingers[0].TipPosition.y / 1000;
                Thumb.z = -1 * fingers[0].TipPosition.z / 1000;
                Index.x = fingers[1].TipPosition.x / 1000;
                Index.y = fingers[1].TipPosition.y / 1000;
                Index.z = -1 * fingers[1].TipPosition.z / 1000;
                Middle.x = fingers[2].TipPosition.x / 1000;
                Middle.y = fingers[2].TipPosition.y / 1000;
                Middle.z = -1 * fingers[2].TipPosition.z / 1000;
                Ring.x = fingers[3].TipPosition.x / 1000;
                Ring.y = fingers[3].TipPosition.y / 1000;
                Ring.z = -1 * fingers[3].TipPosition.z / 1000;
                Little.x = fingers[4].TipPosition.x / 1000;
                Little.y = fingers[4].TipPosition.y / 1000;
                Little.z = -1 * fingers[4].TipPosition.z / 1000;
                //m_Point = transform.TransformDirection(m_Point);
                //If the first GameObject's Bounds contains the Transform's position, output a message in the console
                if (m_OuterCollider1.bounds.Contains(Thumb) || m_OuterCollider2.bounds.Contains(Thumb))
                {
                    thumb = "t";
                    if (m_Collider1.bounds.Contains(Thumb) || m_Collider2.bounds.Contains(Thumb))
                    {
                        thumb = "T";
                        if (m_InnerCollider1.bounds.Contains(Thumb) || m_InnerCollider2.bounds.Contains(Thumb))
                        {
                            thumb = "a";
                        }
                    }
                    //print("Bounds contain the thumb");
                    message2send = string.Concat(message2send, thumb);
                }
                if (m_OuterCollider1.bounds.Contains(Index) || m_OuterCollider2.bounds.Contains(Index))
                {
                    index = "i";
                    if (m_Collider1.bounds.Contains(Index) || m_Collider2.bounds.Contains(Index))
                    {
                        index = "I";
                        if (m_InnerCollider1.bounds.Contains(Index) || m_InnerCollider2.bounds.Contains(Index))
                        {
                            index = "b";
                        }
                    }
                    //print("Bounds contain the thumb");
                    message2send = string.Concat(message2send, index);
                }
                if (m_OuterCollider1.bounds.Contains(Middle) || m_OuterCollider2.bounds.Contains(Middle))
                {
                    middle = "m";
                    if (m_Collider1.bounds.Contains(Middle) || m_Collider2.bounds.Contains(Middle))
                    {
                        middle = "M";
                        if (m_InnerCollider1.bounds.Contains(Middle) || m_InnerCollider2.bounds.Contains(Middle))
                        {
                            middle = "c";
                        }
                    }
                    //print("Bounds contain the thumb");
                    message2send = string.Concat(message2send, middle);
                }
                if (m_OuterCollider1.bounds.Contains(Ring) || m_OuterCollider2.bounds.Contains(Ring))
                {
                    ring = "r";
                    if (m_Collider1.bounds.Contains(Ring) || m_Collider2.bounds.Contains(Ring))
                    {
                        ring = "R";
                        if (m_InnerCollider1.bounds.Contains(Ring) || m_InnerCollider2.bounds.Contains(Ring))
                        {
                            ring = "d";
                        }
                    }
                    //print("Bounds contain the thumb");
                    message2send = string.Concat(message2send, ring);
                }
                if (m_OuterCollider1.bounds.Contains(Little) || m_OuterCollider2.bounds.Contains(Little))
                {
                    little = "l";
                    if (m_Collider1.bounds.Contains(Little) || m_Collider2.bounds.Contains(Little))
                    {
                        little = "L";
                        if (m_InnerCollider1.bounds.Contains(Little) || m_InnerCollider2.bounds.Contains(Little))
                        {
                            little = "e";
                        }
                    }
                    message2send = string.Concat(message2send, little);
                }
                //print("Bounds contain the thumb");
                if (m_OuterCollider3.bounds.Contains(Thumb))
                {
                    thumb = "b";
                    if (m_Collider3.bounds.Contains(Thumb))
                    {
                        thumb = "H";
                        if (m_InnerCollider3.bounds.Contains(Thumb))
                        {
                            thumb = "H";
                        }
                    }
                }
                if (m_OuterCollider3.bounds.Contains(Index))
                {
                    thumb = "h";
                    if (m_Collider3.bounds.Contains(Index))
                    {
                        thumb = "H";
                        if (m_InnerCollider3.bounds.Contains(Index))
                        {
                            thumb = "H";
                        }
                    }
                }
                
                
            }
        }
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 16;  // sets the timeout value before reporting error
                print("Port Opened!");
                //		message = "Port Opened!";
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }

}




