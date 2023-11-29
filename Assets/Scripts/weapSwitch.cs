using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class weapSwitch : MonoBehaviour
{
    int numWeapons = 1;
    public int curIndex;

    public GameObject[] guns;
    public GameObject wHolder;
    public GameObject curGun;
    // Start is called before the first frame update
    void Start()
    {
        
        numWeapons = wHolder.transform.childCount;
        guns = new GameObject[numWeapons];
        for (int i = 0; i < numWeapons; i++)
        {
            guns[i] = wHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        curGun = guns[0];
        curIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (curIndex < (numWeapons - 1))
            {
                guns[curIndex].SetActive(false);
                curIndex++;
                guns[curIndex].SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (curIndex > 0)
            {
                guns[curIndex].SetActive(false);
                curIndex--;
                guns[curIndex].SetActive(true);
            }
        }
    }
}
