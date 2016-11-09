using UnityEngine;
using System.Collections;

public class infoText : MonoBehaviour
{
    int altitude; // Conversion m / ft
    int destination;
    float vitesse; // Conversion knots (kts) / km.h / mph
    float direction;

    private TextMesh textObject;
    // Use this for initialization
    void Start()
    {
            }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string txt = "Name : ";
                textObject = GameObject.Find("AvionText").GetComponent<TextMesh>();

                string txtPlaneName;
                if (string.IsNullOrEmpty(hit.transform.GetComponent<PlaneBehaviour>().planeName))
                    txtPlaneName = "test";
                else
                    txtPlaneName = hit.transform.GetComponent<PlaneBehaviour>().planeName;

        
                txt = string.Concat(txt, txtPlaneName);

        
                int altitude = hit.transform.GetComponent<PlaneBehaviour>().altitude; // Conversion m / ft
                int destination = hit.transform.GetComponent<PlaneBehaviour>().destination;
                float vitesse = hit.transform.GetComponent<PlaneBehaviour>().vitesse; // Conversion knots (kts) / km.h / mph
                float direction = hit.transform.GetComponent<PlaneBehaviour>().direction;

                txt = string.Concat(txt, "\n");
                txt = string.Concat(txt, "Destination : ");
                txt = string.Concat(txt, destination);
                txt = string.Concat(txt, "\n");
                txt = string.Concat(txt, "Vitesse : ");
                txt = string.Concat(txt, vitesse);
                txt = string.Concat(txt, "\n");
                txt = string.Concat(txt, "Altitude : ");
                txt = string.Concat(txt, altitude);
                txt = string.Concat(txt, "\n");
                txt = string.Concat(txt, "Direction : ");
                txt = string.Concat(txt, direction);
                
                textObject.text = txt;

            }
        }
    }
}