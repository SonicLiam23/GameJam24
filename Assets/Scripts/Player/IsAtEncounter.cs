using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAtEncounter : MonoBehaviour
{
    bool AtEncounter;
    Movement movement;
    [SerializeField]
    GameObject EncounterScreen;

    void Start()
    {
        movement = GetComponent<Movement>();
        AtEncounter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Encounter")
        {
            AtEncounter = true;
            Debug.Log("ENCOUNTER");
        }
    }


    private void Update()
    {
        if (AtEncounter) 
        {
            movement.movementSpeed = 0;
            EncounterScreen.SetActive(true);
            //ENOUNTER SCRIPT
        }
    }
}
