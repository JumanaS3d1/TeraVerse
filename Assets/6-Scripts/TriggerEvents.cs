using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{

    [SerializeField] private string tagToCompare;
    public UnityEvent triggerEvents; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToCompare) {
            triggerEvents.Invoke();
        }
    }
}
