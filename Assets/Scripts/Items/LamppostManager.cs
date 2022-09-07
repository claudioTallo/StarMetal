using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamppostManager : MonoBehaviour
{
    
    [SerializeField] private Transform LightButtonSwitch;

    [SerializeField]
    private float rayDistance = 10f;

    [SerializeField] private GameObject PostLigth;

    private bool illuminate = true;
    private bool flickering = true;

    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        LamppostRaycast();
    }

    private void LamppostRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(LightButtonSwitch.position, LightButtonSwitch.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player") && illuminate)
            {
                Debug.Log("COLLISION CON PLAYER");
                //yield return new WaitForSeconds(0.1f);
               
                //yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<Light>().intensity = 0;
                new WaitForSecondsRealtime(0.2f);
                gameObject.GetComponent<Light>().intensity += 10;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = LightButtonSwitch.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(LightButtonSwitch.position, direction);
        //Gizmos.DrawLine(shootPoint.position, direction); ESTE GIZMO NO AFECTA LA ROTACION
    }

}
