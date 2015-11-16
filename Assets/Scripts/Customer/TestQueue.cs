using UnityEngine;
using System.Collections;

public class TestQueue : CustomerQueue {
    void Start() {
        customers = new string[2];
        customers[0] = "tourist";
        customers[1] = "tourist";
        customer_times = new float[2];
        customer_times[0] = 10.0f;
        customer_times[1] = 20.0f;
        customer_chair = new int[2];
        customer_chair[0] = 2;
        customer_chair[1] = 2;
    }

    // Update is called once per frame
    void Update () {
        if(customer_index < customers.Length && Time.time > customer_times[customer_index]){
            Debug.Log("Making new customer");
            Transform plateClone = (Transform) Instantiate(getCustomerPrefab(customers[customer_index]), path_starts[customer_chair[customer_index]-1], Quaternion.identity);
            plateClone.GetComponent<Customer>().startPath(path_names[customer_chair[customer_index]-1]);

            customer_index++;
            Debug.Log(customer_index);
        }
    }
}
