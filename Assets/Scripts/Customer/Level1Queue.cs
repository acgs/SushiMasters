using UnityEngine;
using System.Collections;

public class Level1Queue : TestQueue {

    // Use this for initialization
    void Start () {
        int numCustomers = 20;
        customers = new string[numCustomers];
        for(int i = 0; i < numCustomers; i++){
            customers[i] = "tourist";
            if(i % 6 == 0){
                customers[i] = "critic";
            }
			else if(i % 5 == 0){
				customers[i] = "regular";
			}
			else if(i % 7 == 0){
				customers[i] = "salaryman";
			}
			else if(i % 4 == 0){
				customers[i] = "student";
			}
        }
        customer_times = new float[numCustomers];
        float timeDelay = 3.5f;

        for(int i = 0; i < numCustomers; i++){
            customer_times[i] = 15.0f + timeDelay*i;
        }

        //try some random chairs
        customer_chair = new int[numCustomers];
        for(int i = 0; i < numCustomers; i++){
            customer_chair[i] = Random.Range(1, 11); //range is exclusive for max value, so we add 1
        }
    }

    // Update is called once per frame
    //void Update () {

    //}
}
