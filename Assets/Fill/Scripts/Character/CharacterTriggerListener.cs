using GameSDK.Scripts.Character;
using UnityEngine;

public class CharacterTriggerListener : MonoBehaviour
{
    public bool isJump { get; set; }
    public bool isUnhook { get; set; }
    
    private SignalBus _signalBus;
    private CharacterMono _characterMono;

    public void Construct(CharacterMono characterMono)
    {
        _characterMono = characterMono;
        _signalBus = ServiceContainer.Resolve<SignalBus>();
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag: "Jumper"))
        {
            //Debug.Log("JUMPER CONTACT");
            isJump = true;
        }
        
        if (other.CompareTag(tag: "Finish"))
        {
            Debug.Log("Finished");
            _signalBus.FireSignal(new CharacterFinishedSignal(_characterMono));
        }
        
        if (other.CompareTag(tag: "Unhook"))
        {
            isUnhook = true;
            Debug.Log("UnCrabbing");
        }
    }
}
