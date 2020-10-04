using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ThirdPersonControl : MonoBehaviour
{
    PCGameplay inputActions;
    Vector2 move;
    //Vector2 look;

    bool drawGizmos;
    public LayerMask layerMask;
    public LayerMask playerLayer;
    Vector3 halfExtents = new Vector3(3.0f, 2.0f, 3.0f);

    public CharacterController controller;
    public Transform cameraTransform;
    public float speed = 7f;
    public float smoothTime = 0.1f;
    bool inAttack = false;
    //used for storing:
    float smoothVelocity;  
    Collider[] overlapResult = new Collider[10];
    #region combat system
    public List<GameObject> allWeapons = new List<GameObject>();
    public List<GameObject> equippedTools = new List<GameObject>();
    public int activeWeaponIndex;
    public Transform HandA;
    public Transform HandB;
    public List<string> actor = new List<string>();
    public List<string> target = new List<string>();
    public List<string> enemyType = new List<string>();
    delegate void DamageMethod();
    private List<List<List<DamageMethod>>> SpecialDamage = new List<List<List<DamageMethod>>>();

    
    void CreateList() //Weil C# scheisse mit mehrdimensionalen Listen ist, muss für jeden Waffentyp wiefolgt die Liste der Methoden initialisiert werden und anschließend SpecialDamage hinzugefügt werden.
    {
        List<DamageMethod> melees = new List<DamageMethod> { Rip, Snap };
        SpecialDamage.Add(new List<List<DamageMethod>> { melees});
        /* Hier müsste noch um eine Listenstufe und einer weiteren Schleife erweitert werden.
        int a = 0;
        foreach(List<DamageMethod> i in SpecialDamage)
        {
            
            int b = 0;
            foreach (DamageMethod j in i)
            {
                
                Debug.Log(a + "_" + b);
                b++;
            }
            a++;
        }*/

    }


    void Rip()
    {
        Debug.Log("Kar en Tuk");
    }
    void Snap()
    {
        Debug.Log("Take that Zod");
    }
    #endregion
    void CheckWeapons()
    {
        int a = 0;
        for (int i = 0; i < equippedTools.Count; i++)
        {
            if (equippedTools[i] == null)
            {
                a++;
            }
        }
        if (a == equippedTools.Count)
        {
            equippedTools[0] = allWeapons[0];
        }
    }
    private void Awake()
    {
        inputActions = new PCGameplay();
        inputActions.MT.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.MT.Move.canceled += ctx => move = Vector2.zero;
        inputActions.MT.Interact.performed += Interact;
        inputActions.MT.specialCombatAction.performed += SpecialCombatMove;
        CreateList();
        CheckWeapons();
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
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100f, Color.green);
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
    void SpecialCombatMove(InputAction.CallbackContext context)
    {
        CheckWeapons();
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 10f, ~playerLayer))
        {
            if(hit.transform.tag == "damageObject")
            {
                string[] n = hit.transform.name.Split('_');
                Debug.Log(n[0] + "_" + n[1]);
                string a = n[0];
                string b = n[1];
                int c=0;
                for(int i = 0; i < target.Count; i++)
                {
                    if(a == target[i])
                    {
                        c = i;
                    }
                }
                int d=0;
                for (int i = 0; i < enemyType.Count; i++)
                {
                    if (b == target[i])
                    {
                        d = i;
                    }
                }
                Debug.Log("c:" + c + " d: " + d);
                SpecialDamage[activeWeaponIndex][d][c]();
            }
        }
        
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (!inAttack)
        {
            // Find all the interactables in the local area.
            int count = Physics.OverlapBoxNonAlloc(controller.transform.position + controller.center, halfExtents, overlapResult, transform.rotation, layerMask);
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
            Gizmos.DrawWireCube(controller.transform.position + controller.center, halfExtents);
    }
}
