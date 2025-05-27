using System.Collections.Generic;
using UnityEngine;

public class SpawnSistem : QueueSystem
{
    public List<GameObject> clientsPrefabs;
    GameObject clienteActual;
    public bool isGoingOut=false;
    GameObject clientGoingOut;
    public bool clientExist;
    public bool orderFinished;
    public bool canMove;
    int waitTime=240;
    private Vector3 velocity;

    public void Update()
    {
        if (canMove)
        {
            MoveCliente(clienteActual);
        }
        if (!clientExist)
        {
            //SpawnCliente();
        }
        if (orderFinished)
        {
            clienteAtendido();
        }
    }
    [ContextMenu("a")]
    public void SpawnCliente()
    {
        clientExist = true;
        int randomNumber = Random.Range(0, clientsPrefabs.Count);
        clienteActual = Instantiate(clientsPrefabs[randomNumber], transform);
        AddClients(clienteActual);
        canMove = true;
    }

    public void MoveCliente(GameObject wich)
    {
        clienteActual.transform.position = Vector3.SmoothDamp(clienteActual.transform.position, Vector3.zero, ref velocity, 0.5f);
    }
    [ContextMenu("clienteAtendido")]
    public void clienteAtendido()
    {
        //Debug.Log("Cliente atendido");
        canMove = false;
        if (!isGoingOut)
        {
            clientGoingOut = GetNextClient();
        }
        clientGoingOut.transform.position = Vector3.SmoothDamp(clientGoingOut.transform.position, new Vector3(20, 0, 0), ref velocity, 0.5f);

        isGoingOut = true;
        if (waitTime <= 0)
        {
            cleinteExplotar();
            waitTime = 240;
        }
        waitTime--;
    }
    public void cleinteExplotar()
    {
        clientExist=false;
        isGoingOut = false;
        orderFinished =false;
        Destroy(clienteActual);
    }

}
