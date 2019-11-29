using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera MainCam;
    // Start is called before the first frame update
    void Start()
    {
        MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            StartCoroutine(ShortShake(0.2f));
        }
    }

    public IEnumerator ShortShake(float length)
    {
        length = length / 4f;
        MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 100;
        yield return new WaitForSeconds(length);
        MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 50;
        yield return new WaitForSeconds(length);
        MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 20;
        yield return new WaitForSeconds(length);
        MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 10;
        yield return new WaitForSeconds(length);
        MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
}
