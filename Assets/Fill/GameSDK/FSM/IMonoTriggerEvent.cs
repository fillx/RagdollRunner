using UnityEngine;

public interface IMonoTriggerEvent
{
    void OnTriggerEnter(Collider other);
    void OnTriggerStay(Collider other);
    void OnTriggerExit(Collider other);
}