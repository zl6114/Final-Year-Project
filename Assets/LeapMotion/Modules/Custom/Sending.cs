using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class Sending : MonoBehaviour
{

    //public static SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    public SerialPort sp = new SerialPort("COM6", 9600);
    public string message2;
    public string message2send;
    float timePassed = 0.0f;
    // Use this for initialization
    void Start()
    {
        OpenConnection();
    }

    // Update is called once per frame
    void Update()
    {
        //timePassed += Time.deltaTime;
        //if (timePassed >= 0.2f)
        //{
            //print("BytesToRead" + sp.BytesToRead);
        message2 = sp.ReadLine();
        sp.Write(message2send);
        message2send = string.Empty;
           //print(message2);
           // timePassed = 0.0f;
       // }
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

    public void send_thumb()
    {
        message2send = string.Concat(message2send,"t"); 
        print("thumb");
        //sp.Write("\n");
    }
    public void send_index()
    {
        message2send = string.Concat(message2send, "i");
        print("index");
        //sp.Write("\n");
    }
    public void send_middle()
    {
        message2send = string.Concat(message2send, "m");
        print("middle");
        //sp.Write("\n");
    }
    public void send_ring()
    {
        message2send = string.Concat(message2send, "r");
        print("ring");
        //sp.Write("\n");
    }
    public void send_little()
    {
        message2send = string.Concat(message2send, "l");
        print("little");
        //sp.Write("\n");
    }

    public void send_info()
    {
        sp.Write(message2send);
        message2send = string.Empty;
    }
}