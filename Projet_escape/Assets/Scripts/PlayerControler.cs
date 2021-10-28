using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //vitesse de course
    public float rotationRate = 360; // Faire un tour complet

    // Noms des inputs (project settings) � lire pour le d�placement 
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    //Hauteur de saut
    public float heightJump;


    // Seuil de l'input pour d�terminer s'il se d�place 
    public float minToMove = 0.1f;

    // R�f�rence pour l'animation 
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        // Assigner l'animator pour acc�der � la variable isMoving 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lire la valeur des inputs (entre -1 et 1) 
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        // Applique les inputs 
        ApplyInput(moveAxis, turnAxis);

        // Si l'input d�passe le seuil,  
        // modifier la valeur dans l'animator pour d�cider entre idle et marche 
        if (moveAxis > minToMove || moveAxis < -minToMove)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        // Si on appuie sur espace
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);
            
        }
    }

    // D�place et tourne le personnage 
    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    // D�place le personnage 
    private void Move(float input)
    {
        // Effectue une translation selon un vecteur3 :  
        //      .forward : vers l'avant du mod�le 
        //      input : entre -1 et 1 
        //      speed : facteur donn� en param�tre modifiable dans l'�diteur 
        //      deltaTime : pour un mouvement par seconde plut�t que par frame  
        transform.Translate(Vector3.forward * input * speed * Time.deltaTime);
    }

    

    // Tourne le personnage 
    private void Turn(float input)
    {
        // Effectue une rotation en angle Euler sur X, Y, Z, en Y dans ce cas (gauche-droite) 
        //      input : entre -1 et 1 
        //      rotationRate : nb degr�s par seconde 
        //      deltaTime : pour un mouvement par seconde plut�t que par frame 
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
