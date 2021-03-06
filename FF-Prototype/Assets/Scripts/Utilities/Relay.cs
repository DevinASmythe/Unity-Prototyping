﻿using UnityEngine;
using System.Collections;
using System;

public class Relay : MonoBehaviour, ISubscriber
{
 
    public MessageLayer _messageType;
    public string message;
    public void Start()
    {
        Subscribe(_messageType, message, DoSomething);
    }
    public void Receive(string e)
    {
        if (e == _messageType.ToString() + ":" + message) 
            Debug.Log("got it");
    }

 
    public void Subscribe(MessageLayer t, string e, Callback c)
    {
        EventSystem.Subscribe(t, e, c, this);
    }
    
    public void Subscribe<T>(MessageLayer t, string e, Callback<T> c)
    {
        EventSystem.Subscribe<T>(t, e, c, this);
    }
    public void DoSomething()
    {

    }
}
