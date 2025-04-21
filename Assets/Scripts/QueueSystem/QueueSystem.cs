using UnityEngine;
using System.Collections.Generic;

public class QueueSystem : MonoBehaviour 
{
    public Queue<object> ClientsQueue = new Queue<object>();

    public void AddClients(object[] ClientsToAdd){
        if(ClientsToAdd != null){
            foreach(object ClientToAdd in ClientsToAdd){
                ClientsQueue.Enqueue(ClientToAdd);
            }
        }
    }

    public object GetNextClient(){
        if(ClientsQueue.Count > 0){
            return ClientsQueue.Dequeue();
        }else{
            return null;
        }
    }

    public object[] GetAllClients(){
        if(ClientsQueue.Count > 0){
            return ClientsQueue.ToArray();
        }else{
            return null;
        }
    }

    public object PeekClients(){
        if(ClientsQueue.Count > 0){
            return ClientsQueue.Peek();
        }else{
            return null;
        }
    }
    
    public void ResetClients(){
        ClientsQueue.Clear();
    }
}
