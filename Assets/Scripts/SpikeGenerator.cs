using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _spike;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedMultiplier;

    private float currentSpeed;

    public float CurrentSpeed => currentSpeed;

    private void Awake()
    {
        currentSpeed = _minSpeed;
        GenerateSpike();
    }

    public void GanarateNextSpikeWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("GenerateSpike", randomWait);

    }

    private void GenerateSpike()
    {
      GameObject SpikeInst =  Instantiate(_spike, transform.position, transform.rotation);

        SpikeInst.GetComponent<Spike>().spikeGenerator = this;
    }

    void Update()
    {
        if (currentSpeed < _maxSpeed)
        {
            currentSpeed += _speedMultiplier;
        }
    }
}
