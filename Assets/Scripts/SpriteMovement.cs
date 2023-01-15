using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class SpriteMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;
    public float predTime;

    private Rigidbody2D rb;
    private GameObject predPoint;
    private Vector3 vel;
    private bool isMoving = false;

    public TextMeshProUGUI outputDirection;
    public TextMeshProUGUI outputSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        predPoint = GameObject.FindGameObjectWithTag("PredPoint");
        outputDirection.text = "";
        outputSpeed.text = "";
    }

    /// <summary>
    /// starts the program
    /// </summary>
    public void ProgramStart()
    {
        isMoving = true;
        vel = moveDirection * moveSpeed;
        StartCoroutine(LinearMovementPrediction());
    }

    /// <summary>
    /// stops the program
    /// </summary>
    public void ProgramStop()
    {
        isMoving = false;
        StopAllCoroutines();
    }

    /// <summary>
    /// resets the program and brings the sprite back to the center of the screen
    /// </summary>
    public void ResetProgram()
    {
        isMoving = false;
        rb.position = Vector3.zero;
    }

    //Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            StartCoroutine(Moving());
        }
    }

    /// <summary>
    /// Interacts with box collider to output current direction of selected sprite
    /// </summary>
    private void OnMouseDown()
    {
        if(moveDirection.x > 0 && moveDirection.y > 0)
        {
            outputDirection.text = "NorthEast";
        }
        else if(moveDirection.x < 0 && moveDirection.y > 0)
        {
            outputDirection.text = "NorthWest";
        }
        else if (moveDirection.x > 0 && moveDirection.y < 0)
        {
            outputDirection.text = "SouthEast";
        }
        else if (moveDirection.x < 0 && moveDirection.y < 0)
        {
            outputDirection.text = "SouthWest";
        }
        else if(moveDirection.x < 0)
        {
            outputDirection.text = "West";
        }
        else if(moveDirection.x > 0)
        {
            outputDirection.text = "East";
        }
        else if(moveDirection.y > 0)
        {
            outputDirection.text = "North";
        }
        else if(moveDirection.y < 0)
        {
            outputDirection.text = "South";
        }

        outputSpeed.text = moveSpeed.ToString();
    }

    /// <summary>
    /// Coroutine that will give the predicted location after a given prediction time property
    /// </summary>
    /// <returns></returns>
    private IEnumerator LinearMovementPrediction()
    {
        Vector3 PredictedPosition = (Vector3)rb.position + vel * predTime; //takes current position and adds it the sprites current velocity * prediction time you set
        yield return null;
        predPoint.transform.position = PredictedPosition;
        
    }
    
    /// <summary>
    /// Coroutine that will be cause the main sprite to move
    /// </summary>
    /// <returns></returns>
    private IEnumerator Moving()
    {
            rb.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            vel = moveDirection * moveSpeed;
            yield return null;
    }
}
