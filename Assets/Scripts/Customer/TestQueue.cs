using UnityEngine;
using System.Collections;

public class TestQueue : CustomerQueue {
    public string[] customers = {"tourist", "tourist"};
    public float[] customer_times = {10.0f, 60.0f};
    public int[] customer_chair = {2, 2};

    // Update is called once per frame
    void Update () {
        if(customer_index < customers.Length && Time.time > customer_times[customer_index]){
            Transform plateClone = (Transform) Instantiate(getCustomerPrefab(customers[customer_index]), path_starts[customer_chair[customer_index]-1], Quaternion.identity);
            plateClone.GetComponent<Customer>().startPath(path_names[customer_chair[customer_index]-1]);

            customer_index++;
        }
    }
}
