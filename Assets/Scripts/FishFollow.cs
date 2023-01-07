using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFollow : MonoBehaviour
{
    [SerializeField] private Transform[] _holders;
    [SerializeField] private Transform _fishs;
    [SerializeField] float distance;
    [SerializeField] float lerpSpeed;
    [SerializeField] float rotationSpeed;
    int index;
    void Start()
    {
        _fishs.position = _holders[index].transform.position;
        index++;
    }

    // Update is called once per frame
    void Update()
    {

        var dis = Vector3.Distance(_holders[index].transform.position, transform.position);
        if (distance > dis)
        {
            index++;
            if (index == _holders.Length)
            {
                index = 0;
            }
        }
        var target = _holders[index];
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);
       

        transform.transform.LookAt(target);
        _fishs.transform.position = Vector3.Lerp(_fishs.transform.position, target.position, lerpSpeed);
        _fishs.transform.rotation = Quaternion.Lerp(_fishs.rotation, transform.rotation, rotationSpeed);

    }
}
