using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class infoText : MonoBehaviour
{
    Button buttonSend;
    string txtVitesse, txtDirection, txtAltitude;
    RaycastHit planeHited;
    InputField InFiName, InFiDestination, InFiVitesse, InFiDirection, InFiAltitude;
    

    // Use this for initialization
    void Start()
    {
        
        buttonSend = GameObject.Find("Send").GetComponent<Button>();
        buttonSend.onClick.AddListener(() => PlaneSendData());

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
                InFiName = GameObject.Find("Name").GetComponent<InputField>();
                InFiDestination = GameObject.Find("Destination").GetComponent<InputField>();
                InFiVitesse = GameObject.Find("Speed").GetComponent<InputField>();           // Conversion knots (kts) / km.h / mph
                InFiDirection = GameObject.Find("Direction").GetComponent<InputField>();
                InFiAltitude =  GameObject.Find("Altitude").GetComponent<InputField>();       // Conversion m / ft

                // Erase data on orders
                GameObject.Find("SpeedOrder").GetComponent<InputField>().text = "--";
                GameObject.Find("AltitudeOrder").GetComponent<InputField>().text = "--";
                GameObject.Find("DirectionOrder").GetComponent<InputField>().text = "--";

                if (string.IsNullOrEmpty(hit.transform.GetComponent<PlaneBehaviour>().planeName))
                {
                    InFiName.text = "N/A";
                    InFiDestination.text = "N/A";
                    InFiVitesse.text = "N/A";
                    InFiAltitude.text = "N/A";
                    InFiDirection.text = "N/A";
                }
                else
                {

                    InFiName.text = hit.transform.GetComponent<PlaneBehaviour>().planeName.ToString();
                    switch(hit.transform.GetComponent<PlaneBehaviour>().destination)
                    {
                        case 0:
                            InFiDestination.text = "Montpellier";
                            break;

                       case 1:
                            InFiDestination.text = "Lyon";
                            break;
                        case 2:
                            InFiDestination.text = "Paris";
                            break;
                        case 3:
                            InFiDestination.text = "Toulouse";
                            break;
                            
                    }
                    //InFiDestination.text = hit.transform.GetComponent<PlaneBehaviour>().destination.ToString();
                    InFiVitesse.text = hit.transform.GetComponent<PlaneBehaviour>().vitesse.ToString() + " knots";
                    InFiAltitude.text = "FL"+hit.transform.GetComponent<PlaneBehaviour>().altitude.ToString();
                    InFiDirection.text = "cap"+hit.transform.GetComponent<PlaneBehaviour>().direction.ToString();

                    txtVitesse = InFiVitesse.text;
                    txtDirection = InFiDirection.text;
                    txtAltitude = InFiAltitude.text;
                }
                planeHited = hit;
            }
        }
    }
    

    void PlaneSendData()
    {
        
        InputField txtVitesseOrder, txtDirectionOrder, txtAltitudeOrder;
        //Debug.Log("Send Data");
 

        if (GameObject.Find("Speed").GetComponent<InputField>().text != txtVitesse)         {

            txtVitesseOrder = GameObject.Find("Speed").GetComponent<InputField>();
            txtVitesse = txtVitesseOrder.text;
            GameObject.Find("SpeedOrder").GetComponent<InputField>().text = txtVitesse;
            //Debug.Log("Vitesse: " + txtVitesse);
            //Debug.Log("VitesseOrder: " + txtVitesseOrder.text);

            planeHited.transform.GetComponent<PlaneBehaviour>().vitesseOrder = float.Parse(txtVitesseOrder.text);           // Conversion knots (kts) / km.h / mph

        }


       else if (GameObject.Find("Altitude").GetComponent<InputField>().text != txtAltitude)      {

            txtAltitudeOrder = GameObject.Find("Altitude").GetComponent<InputField>();     // Conversion m / ft
            txtAltitude = "FL" + txtAltitudeOrder.text;
            GameObject.Find("AltitudeOrder").GetComponent<InputField>().text = txtAltitude;
            //Debug.Log("Altitude: " + txtAltitude);
            //Debug.Log("AltitudeOrder: " + txtAltitudeOrder.text);

            planeHited.transform.GetComponent<PlaneBehaviour>().altitudeOrder = int.Parse(txtAltitudeOrder.text);

        }


       else if (GameObject.Find("Direction").GetComponent<InputField>().text != txtDirection)     {

            txtDirectionOrder = GameObject.Find("Direction").GetComponent<InputField>();
            txtDirection = "CAP" + txtDirectionOrder.text;
            GameObject.Find("DirectionOrder").GetComponent<InputField>().text = txtDirection;
            //Debug.Log("Direction: " + txtDirection);
            //Debug.Log("DirectionOrder: " + txtDirectionOrder.text);

            planeHited.transform.GetComponent<PlaneBehaviour>().directionOrder = int.Parse(txtDirectionOrder.text);

        }
    }
    

}