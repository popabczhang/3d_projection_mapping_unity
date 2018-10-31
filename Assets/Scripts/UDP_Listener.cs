// Done by Ariel Noyman
// ref github commit: 
// https://github.com/CityScope/CS_Cooper-Hewitt/commit/8da9b2f6b1bdf2f4f297d61b293264d86159127e


using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System;
using System.Text;
using System.Text.RegularExpressions;


public class UDP_Listener : MonoBehaviour

{
    // UdpClient listen port 
    public int port = 5005;
    //wait time in MS
    public int sleepTime = 5;
    private UdpClient _UdpClient;
    private IPEndPoint _IpEndPoint;
    private Thread _UdpThread;
    public string _encodedUDP;

    void Start()
    {
        _UdpClient = new UdpClient(port);
        _IpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        _UdpThread = new Thread(UDPRead);
        _UdpThread.Name = "UDP thread";
        _UdpThread.Start();
    }

    public void UDPRead()
    {
        while (true)
        {
            try
            {
                byte[] _udpBytes = _UdpClient.Receive(ref _IpEndPoint);
                _encodedUDP = Encoding.ASCII.GetString(_udpBytes);
                //Debug.Log(" UDP packet: " + _encodedUDP + '\n');
            }
            catch (Exception e)
            {
                Debug.Log("Issue: " + e.ToString());
            }
            Thread.Sleep(sleepTime);
        }
    }
    void OnDisable()
    {
        if (_UdpThread != null) _UdpThread.Abort();
        _UdpClient.Close();
    }
}
