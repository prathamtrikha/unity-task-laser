using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
   [SerializeField]
   private Rigidbody rb;
   [SerializeField]
   private Animator anim;
   [SerializeField]
   private FixedJoystick fixedJoystick;
   [SerializeField]
   private Transform playerChildTransform;
   [SerializeField]
   private float moveSpeed;
   [SerializeField]
   private bool isGround;
   [SerializeField]
   private float jumpForce;
   private PlayerMovementController playerMovementScript;



   private float horizontalInput;
   private float verticalInput;

   private void Start() {
    isGround = true;
    playerMovementScript = GetComponent<PlayerMovementController>();
   }

   private void Update() {
    GetMovementInputs();
    SetRotation();
   }

   private void SetRotation() {
    if(horizontalInput != 0 || verticalInput != 0) {
        playerChildTransform.rotation = Quaternion.LookRotation(GetMoveVelocity());
    }   
   }

   private void FixedUpdate() {
    SetMovement();
   }

   private void SetMovement() {
    rb.velocity = GetMoveVelocity();
   }

    private Vector3 GetMoveVelocity(){
        return new Vector3(horizontalInput, rb.velocity.y, verticalInput) * moveSpeed * Time.fixedDeltaTime;
   }


   private void GetMovementInputs() {
    horizontalInput = fixedJoystick.Horizontal;
    verticalInput = fixedJoystick.Vertical;

    if(horizontalInput != 0 || verticalInput != 0){
        anim.SetBool("ru",true);
    }else{
        anim.SetBool("ru",false);
    }
   }
   
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            isGround = true;
        }
        if(other.gameObject.CompareTag("Lava")){
            this.gameObject.SetActive(false);
            GameBehaviour.Instance.ShowLoseScreen();
        }
    }

   public void PlayerJump() {
    if(isGround){
        rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z), ForceMode.Impulse);
        playerMovementScript.enabled = false;
        anim.SetBool("jump1", true);
        isGround = false;
        Invoke("Del",1.2f);
        }
   }

   private void Del() {
    anim.SetBool("jump1", false);
    playerMovementScript.enabled = true;
   }
}
