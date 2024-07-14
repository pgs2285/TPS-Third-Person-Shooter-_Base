using UnityEngine;
using Cinemachine;

public class playerManager : MonoBehaviour
{
    private PlayerInputSystem input;
    

    [Header("Aim")]
    [SerializeField]
    private CinemachineVirtualCamera aimCam;
    [SerializeField]
    private GameObject _crossHair;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInputSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        AimCheck(input.aim);

    }

    private void AimCheck(bool isAim)
    {
        aimCam.gameObject.SetActive(isAim);
        _crossHair.gameObject.SetActive(isAim);
        
    }
}
