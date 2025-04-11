using UnityEngine;

public class PlayerControllerLevel2 : MonoBehaviour
{
    // public float speed;
    // public float turnSpeed;

    // [Header("Dust Effects")]
    // public GameObject dust1;
    // public GameObject dust2;

    // // Update is called once per frame
    // void Update()
    // {
    //     Vector2 motionInput = new Vector2(0, Input.GetAxis("Vertical"));

    //     if (motionInput.y != 0)
    //     {
    //         float horizontalInput = Input.GetAxis("Horizontal");
    //         if(motionInput.y <0)
    //         {
    //             horizontalInput *= -1;
    //         }

    //         transform.Rotate(0, 0, -horizontalInput * turnSpeed * Time.deltaTime);
    //         dust1.SetActive(true);
    //         dust2.SetActive(true);        
    //     }
    //     else
    //     {
    //         dust1.SetActive(false);
    //         dust2.SetActive(false);
    //     }


    //     transform.Translate(motionInput * speed * Time.deltaTime);
    // }
    [SerializeField] float speed;
    [SerializeField] float speedBuildUp;
    [SerializeField] float turnSpeed;

    [Header("Dust Animations")]
    [SerializeField] GameObject leftDust;
    [SerializeField] GameObject rightDust;

    [Header("Audio Setting")]
    [SerializeField] AudioSource movingAudio;
    [SerializeField] AudioSource turningAudio;
    bool turnSoundOnce;

    [Header("Debug")]
    [SerializeField] float currentSpeed;


    private void FixedUpdate()
    {
        MovementSystem();
    }




    void MovementSystem()
    {
        Vector2 moveInput = new Vector2(0, Input.GetAxis("Vertical"));
        float turnInput = Input.GetAxis("Horizontal");

        if(moveInput.y != 0)
        {
            if (movingAudio &&  !movingAudio.isPlaying) movingAudio.Play();

            if (!turnSoundOnce && turnInput != 0 && turningAudio && !turningAudio.isPlaying)
            {
                turnSoundOnce = true;
                turningAudio.Play();
            }
            else if (turnInput == 0)
            {
                turnSoundOnce = false;
            }

            if(moveInput.y > 0) transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal")) * turnSpeed * Time.deltaTime);
            else transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal")) * turnSpeed * Time.deltaTime);

            leftDust.SetActive(true);
            rightDust.SetActive(true);
        }
        else
        {
            if (movingAudio && movingAudio.isPlaying) movingAudio.Stop();

            turnSoundOnce = false;
            leftDust.SetActive(false);
            rightDust.SetActive(false);
        }

        transform.Translate(moveInput * speed * Time.deltaTime);
    }



}
