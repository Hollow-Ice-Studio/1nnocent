using Cinemachine;
using UnityEngine;

namespace innocent {
    public class AdamCameraController : MonoBehaviour
    {
        CinemachineBrain cinemachineBrain;
        public CinemachineVirtualCamera mirando, naoMirando;
        public Adam adam;
        public Transform adamChest;
        ICinemachineCamera activeVcam;
        public Transform player;
        #region MonoBehaviour
        void Start() => CacheReferences();
        void Update() => ChangeCamera();
        void LateUpdate() => RefreshCamera();
        #endregion

        void CacheReferences()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cinemachineBrain = GetComponent<CinemachineBrain>();
        }

        void ChangeCamera()
        {
            if (Input.GetMouseButton(1))
            {
                mirando.Priority = 1;
                naoMirando.Priority = 0;
            }
            if (Input.GetMouseButton(0))
            {
                naoMirando.Priority = 1;
                mirando.Priority = 0;
            }
        }

        void RefreshCamera()
        {
            activeVcam = cinemachineBrain.ActiveVirtualCamera;
            player.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            //adamChest.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, 0);
        }

    }
}