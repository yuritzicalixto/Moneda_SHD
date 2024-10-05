using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorBolita : MonoBehaviour
{
    //Velocidad del movimiento
    public float velocidadMovimiento=5f;
    //Audio de la moneda
    public AudioSource fuente;
    public AudioClip sonidoMoneda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoBolita();
    }

    //Metodo de movimiento de la bolita
    void MovimientoBolita()
    {
        //detectar las teclas del teclado
        //Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        //Crear vector de movimiento en función de la entrada
        Vector3 movimiento = new Vector3(movimientoHorizontal,0, movimientoVertical);

        //Mover el objeto en función de la velocidad y del tiempo transcurrido
        //Le digo que se moverá por todo el espacio.
        transform.Translate(movimiento*velocidadMovimiento*Time.deltaTime, Space.World);
    }

//Detecta el suelo, 
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("suelo"))
        {
            transform.position = Vector3.zero; 
        }

        if(other.gameObject.tag.Contains("Moneda"))
        {
            fuente.clip = sonidoMoneda;
            fuente.Play();    
        }
    }
}
