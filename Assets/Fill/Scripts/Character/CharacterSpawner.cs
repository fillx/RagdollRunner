using GameSDK;
using GameSDK.Scripts.Race;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    private SignalBus _signalBus;

    private void Awake()
    {
       _signalBus = ServiceContainer.Resolve<SignalBus>();
    }

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var characters = GameConfig.Instance.Characters;
        characters.Randomize();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            var point = spawnPoints[i];
            if(point.gameObject.activeSelf == false)
                continue;
            
            var config = characters[i];
            var instance = Instantiate(config.Prefab,point.position, point.rotation);
            instance.Construct(config);
            _signalBus.FireSignal(new CharacterSpawnedSignal(instance));
        }
    }
}
