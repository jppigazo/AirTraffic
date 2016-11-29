using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class infoText : MonoBehaviour
{
    Button buttonSend;

    // Use this for initialization
    void Start()
    {
        //var input = gameObject.GetComponent<InputField>();
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        
            Text txtName, txtVitesse, txtDestination, txtDirection, txtAltitude;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                txtName = GameObject.Find("Name").GetComponentInChildren<Text>();
                txtDestination = GameObject.Find("Destination").GetComponentInChildren<Text>();
                txtVitesse = GameObject.Find("Speed").GetComponentInChildren<Text>();           // Conversion knots (kts) / km.h / mph
                txtAltitude = GameObject.Find("Altitude").GetComponentInChildren<Text>();       // Conversion m / ft
                txtDirection = GameObject.Find("Direction").GetComponentInChildren<Text>();
                
                if (string.IsNullOrEmpty(hit.transform.GetComponent<PlaneBehaviour>().planeName))
                {
                    txtName.text = "N/A";
                    txtDestination.text = "N/A";
                    txtVitesse.text = "N/A";
                    txtAltitude.text = "N/A";
                    txtDirection.text = "N/A";
                }
                else
                {
                    txtName.text = hit.transform.GetComponent<PlaneBehaviour>().planeName.ToString();
                    txtDestination.text = hit.transform.GetComponent<PlaneBehaviour>().destination.ToString();
                    txtVitesse.text = hit.transform.GetComponent<PlaneBehaviour>().vitesse.ToString();
                    txtAltitude.text = hit.transform.GetComponent<PlaneBehaviour>().altitude.ToString();
                    txtDirection.text = hit.transform.GetComponent<PlaneBehaviour>().direction.ToString();
                }
                
            }
        }
    }
    
    //private void SubmitName(string arg0)
    //{
    //   // Debug.Log(arg0);
    //}
    

    void Awake()
    {
        buttonSend = GameObject.Find("Send").GetComponent<Button>();

        buttonSend.onClick.AddListener(() => PlaneSendData());

        Debug.Log("Send Data clicked");
    }


    void PlaneSendData()
    {
        string txtName, txtVitesse, txtDestination, txtDirection, txtAltitude;
        //txtName = GameObject.Find("Name").GetComponentInChildren<Text>();
        //txtDestination = GameObject.Find("Destination").GetComponentInChildren<Text>();
        //txtVitesse = GameObject.Find("Speed").GetComponentInChildren<Text>();           // Conversion knots (kts) / km.h / mph
        //txtAltitude = GameObject.Find("Altitude").GetComponentInChildren<Text>();       // Conversion m / ft
        //txtDirection = GameObject.Find("Direction").GetComponentInChildren<Text>();

        txtName = GameObject.Find("Name").GetComponent<InputField>().text;
        txtDestination = GameObject.Find("Destination").GetComponent<InputField>().text;
        txtVitesse = GameObject.Find("Speed").GetComponent<InputField>().text;           // Conversion knots (kts) / km.h / mph
        txtAltitude = GameObject.Find("Altitude").GetComponent<InputField>().text;     // Conversion m / ft
        txtDirection = GameObject.Find("Direction").GetComponent<InputField>().text;


        Debug.Log("Send Data");
        Debug.Log(txtName);
        Debug.Log(txtVitesse);
        Debug.Log(txtAltitude);
        Debug.Log(txtDirection);
        Debug.Log(txtDestination);

        //txtName.text = hit.transform.GetComponent<PlaneBehaviour>().planeName.ToString();
        //txtDestination.text = hit.transform.GetComponent<PlaneBehaviour>().destination.ToString();
        //txtVitesse.text = hit.transform.GetComponent<PlaneBehaviour>().vitesse.ToString();
        //txtAltitude.text = hit.transform.GetComponent<PlaneBehaviour>().altitude.ToString();
        //txtDirection.text = hit.transform.GetComponent<PlaneBehaviour>().direction.ToString();


    }
}