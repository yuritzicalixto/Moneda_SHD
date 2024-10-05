using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorMoneda : MonoBehaviour
{
    //rango delimitar
    //Rango en el cual el obj puede moverse (definido por el tamaño del plano)
    public Vector2 rangoX;
    public Vector2 rangoZ;
    public float alturaY= 0.38f; //altura fija en Y

    //declaramos velocidad
    public float velocidadRotacion=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //La moneda tiene una rotación
        //Rotar el objeto indefinidamente en el eje X
        transform.Rotate(0,velocidadRotacion*Time.deltaTime,0);
    }

    //Detectar la colision 
    private void OnTriggerEnter(Collider other)
    {
        //Si colisiona en con el obj que tiene el tag "bolita"
        if(other.gameObject.tag == "Bolita")
        {
            CambiarPosicionAleatoria();
        }
    }

//Método para cambiar la posición del obj a una posicion aleatoria
    void CambiarPosicionAleatoria()
    {
        //Generar una nueva posición aleatoria dentro del rango definido
        float nuevoX = Random.Range(rangoX.x, rangoX.y);
        float nuevoZ = Random.Range(rangoZ.x, rangoZ.y);

        //Cambiar la posición del obj
        transform.position = new Vector3(nuevoX, alturaY, nuevoZ);
    }
}
