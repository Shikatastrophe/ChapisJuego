using UnityEngine;


public class LogicToUseQueueSystem : QueueSystem
{
    /*
    Dejo este codigo para que lo quitemos despues, es solo para que recordemos como es 
    la base del funcionamiento del queue system por si necesitamos hacer ajustes mas adelante
    o cuando lo implementemos con el juego

    Una cosa importante de saber, es que el codigo donde manejaremos a los bichos tendra
    que eredar de QueueSystem y no de monobehaviour, lo hice de esta manera pq no le 
    entendi  a namespace y no creo que era necesaria una interfaz

    De igual forma comento mejor este codigo que se elminara
    que luego tengamos que borrar los comentarios en el otro
    */
    public GameObject[] clients;

    [ContextMenu("EjectuarAgregarACola")]
    public void AgregarCola(){
        //para agregar a la cola solo tenemos que mandarle cuantos datos cualquiera ya que recibe un array
        //por el momento puse el object, pero es facil cambiarla si lo necesitamos
        AddClients(clients);
        Debug.Log("agregado a cola");
    }

    [ContextMenu("ConseguirDatos")]
    public void ConseguirClientes(){
        //Esta funcion sirve para que podamos leer la gente dentro del queue
        //Esta NO SIRVE PARA EL DEQUEUE, esa esta mas abajito
        object[] clients = GetAllClients();
        //Uso object pero como dije antes lo podemos cambiar
        if(clients != null){
            //Siempre comprobar primero que no sea null, lo mando a null por no tener otra cosa pa mandar
            foreach(object client in clients){
                //de preferencia usar un foreach pq no sabemos cuantos objetos tendra la queue
                Debug.Log("Clientes dentro de la queue:");
                Debug.Log(client);
            }
        }
    }
    [ContextMenu("PeekTry")]
    public void Miradita(){
        //Funcion para checar cual es el siguiente client
        //Realmente la agrege por si en un momento necesitamos hacer eso
        Debug.Log("Peek al siguiente Cliente: ");
        Debug.Log(PeekClients());
    }
    [ContextMenu("ConseguirElSiguienteCliente")]
    public void ConsiguiendoElSiguiente(){
        //ESTA FUNCION SI ES EL DEQUEUE
        //Esta es la funcion que nos permite sacar del queue a los bichos
        //de igual forma regresa solo el dato de quien es el que sigue
        Debug.Log("Siguiente en la fila y dequeue: ");
        Debug.Log(GetNextClient());
    }
    [ContextMenu("ResetearQueue")]
    public void Resetear(){
        //Hay una funcion para resetar, la implemente para pruebas
        //pero creo que la podriamos llegar a usar por si acaso
        ResetClients();
    }
}
