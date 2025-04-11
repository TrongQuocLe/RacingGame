// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     [Header("Car setting")]
//     public float accelerationFactor = 30.0f;
//     public float turnFactor = 3.5f;

//     // Local variables
//     float accelerationInput = 0;
//     float steeringInput = 0;

//     float rotationAngle = 0;

//     // Compoents
//     Rigidbody 2D carRigidbody2D;

//     // Awake is called when the script instance is being loaded
//     void Awake() 
//     {
//         carRigidbody2D = GetCompoent<Rigidbody2D>();
//     }

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     void FixedUpdate()
//     {
//         ApplyEngineForce();

//         ApplySteering();
//     }
    
//     void ApplyEngineForce() 
//     {
//         // Create a force the engine
//         Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
        
//         // Apply force and pushes the car forward
//         carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
//     }

//     void ApplySteering()
//     {
//         //Update the rotation angle based on input
//         rotationAngle -= steeringInput * turnFactor;

//         //Apply steering by rotating the car object
//         carRigidbody2D.MoveRotation(rotationAngle);
//     }

//     public void SetInputVector(Vector2 inputVector)
//     {
//         steeringInput = inputVector.x;
//         accelerationInput = inputVector.y;
        
//     }
// }
