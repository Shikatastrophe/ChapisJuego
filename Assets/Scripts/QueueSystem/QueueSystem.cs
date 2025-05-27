using UnityEngine;
using System.Collections.Generic;

public class QueueSystem : MonoBehaviour 
{
    public Queue<GameObject> ClientsQueue = new Queue<GameObject>();

    public void AddClients(GameObject ClientToAdd){
        if(ClientToAdd != null){
            ClientsQueue.Enqueue(ClientToAdd);
        }
    }

    public GameObject GetNextClient(){
        if(ClientsQueue.Count > 0){
            return ClientsQueue.Dequeue();
        }else{
            return null;
        }
    }

    public GameObject[] GetAllClients(){
        if(ClientsQueue.Count > 0){
            return ClientsQueue.ToArray();
        }else{
            return null;
        }
    }

    public GameObject PeekClients(){
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
