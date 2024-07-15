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
    [SerializeField]
    private LayerMask targetLayer;
    [SerializeField]
    private GameObject aimObject;

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
        if (isAim)
        {
            Transform camTransform = Camera.main.transform;
            Vector3 targetPosition = Vector3.zero;
            if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit, Mathf.Infinity))
            {// 카메라에서 전진방향으로 무한
                targetPosition = hit.point;
                aimObject.transform.position = hit.point; // 디버깅용 구체 이.
            }
            else
            {
                targetPosition = camTransform.position + camTransform.forward;
                aimObject.transform.position = camTransform.position + camTransform.forward;
            }
            Vector3 targetAim = targetPosition;
            targetAim.y = transform.position.y;
            Vector3 aimDir = (targetAim - transform.position).normalized; // 방향벡터 생성
            //transform.LookAt(hitPoint);
            transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 30);
        }
        aimCam.gameObject.SetActive(isAim);
        _crossHair.gameObject.SetActive(isAim);
        
    }
}
