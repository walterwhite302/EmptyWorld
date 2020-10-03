using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonControl : MonoBehaviour
{
    PCGameplay inputActions;
    Vector2 move;
    //Vector2 look;

    bool drawGizmos;
    public LayerMask layerMask;
    Vector3 halfExtents = new Vector3(3.0f, 2.0f, 3.0f);

    public CharacterController controller;
    public Transform cameraTransform;
    public float speed = 7f;
    public float smoothTime = 0.1f;
    bool inAttack = false;
    //used for storing:
    float smoothVelocity;  
    Collider[] overlapResult = new Collider[10];

    private void Awake()
    {
        inputActions = new PCGameplay();
        inputActions.MT.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.MT.Move.canceled += ctx => move = Vector2.zero;
        inputActions.MT.Interact.performed += Interact;
        //inputActions.MT.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        //inputActions.MT.Look.canceled += ctx => look = Vector2.zero;
    }

    private void OnEnable()
    {
        inputActions.MT.Enable();
    }

    private void OnDisable()
    {
        inputActions.MT.Disable();
    }

    void Start()
    {
        drawGizmos = true;
    }

    void FixedUpdate()
    {
        /*float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        */
        Vector3 direction = new Vector3(move.x, 0, move.y).normalized * Time.deltaTime * speed;
        transform.Translate(direction);
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = 0f; //Richtung, in die das Player Model sich drehen soll
            if (!inAttack)
            {
                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            }
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
  
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }


    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!inAttack)
        {
            // Find all the interactables in the local area.
            int count = Physics.OverlapBoxNonAlloc(transform.position, halfExtents, overlapResult, transform.rotation, layerMask);
            float closestDot = 0.0f;
            int closest = -1;
            IInteractable interactable = new EmptyInteractable();
            for (int i = 0; i < count; ++i)
            {
                // Find the dot product between the player and the interactable. This will be larger the closer to the player the interactable is.
                float d = Vector3.Dot(overlapResult[i].transform.position, transform.position);
                // Store the closest interactable.
                if (d > closestDot && overlapResult[i].tag == "Interactable")
                {
                    closestDot = d;
                    closest = i;
                    interactable = overlapResult[closest].GetComponent<IInteractable>();
                }
            }
            if (interactable != null)
            {
                Debug.Log(interactable.ToString());
                interactable.Interact();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (drawGizmos)
            Gizmos.DrawWireCube(transform.position, halfExtents);
    }
}
