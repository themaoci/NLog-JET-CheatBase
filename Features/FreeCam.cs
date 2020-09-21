using Cheat.Base.Tools;
using EFT;
using System.Reflection;
using UnityEngine;


namespace Cheat.Base.Features
{
    class FreeCam
    {
        LocalGameWorld gameWorld = new LocalGameWorld();
        bool enabled;
        Player _player;
        private float _cameraSpeed;

        public float CameraSpeed {
            get { return _cameraSpeed; }
            set { _cameraSpeed = value; }
        }
        private float _moveSpeed;
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }
        private bool _LockPlayer;
        public bool LockPlayer
        {
            get { return _LockPlayer; }
            set { _LockPlayer = value; }
        }
        public bool Enabled { 
            get { return enabled; }
        }
        public Vector3 playerCameraPos {
            get 
            {
                return _player.CameraContainer.transform.position;
            }
        }

        private Vector3 OnEnableSavedCameraPos;
        private Quaternion OnEnableSavedCameraRot;
        public void Enable() 
        {
            if (!enabled)
            {
                OnEnableSavedCameraPos = Camera.main.transform.position;
                OnEnableSavedCameraRot = Camera.main.transform.rotation;
                if (_player == null)
                    _player = GameObject.FindObjectOfType<GamePlayerOwner>().GetComponent<Player>();
                _player.PointOfView = EPointOfView.FreeCamera;
                _player.PlayerBones.Ribcage.Original.localScale = new Vector3(1f, 1f, 1f);
                _player.PointOfViewChanged.Invoke();
                _player.PlayerBody.PointOfView.Value = EPointOfView.ThirdPerson;
                _player.PlayerBody.UpdatePlayerRenders(_player.PlayerBody.PointOfView.Value, _player.Side);
                _player.MovementContext.PlayerAnimatorPointOfView(EPointOfView.ThirdPerson);
                _player.ProceduralWeaponAnimation.PointOfView = _player.PointOfView;
                enabled = true;
            }
        }
        public void Disable()
        {
            if (enabled)
            {
                if (_player == null)
                    _player = GameObject.FindObjectOfType<GamePlayerOwner>().GetComponent<Player>();
                _player.PointOfView = EPointOfView.FirstPerson;
                _player.PointOfViewChanged.Invoke();
                _player.PlayerBody.PointOfView.Value = EPointOfView.FirstPerson;
                _player.PlayerBody.UpdatePlayerRenders(_player.PlayerBody.PointOfView.Value, _player.Side);
                _player.MovementContext.PlayerAnimatorPointOfView(EPointOfView.FirstPerson);
                _player.ProceduralWeaponAnimation.PointOfView = _player.PointOfView;
                enabled = false;
                Camera.main.transform.position = OnEnableSavedCameraPos;
                Camera.main.transform.rotation = OnEnableSavedCameraRot;
            }
        }
        private Vector2 currentRotation;
        public void LockPlayerToCamera()
        {
            if (_LockPlayer)
            {
                _player.MovementContext.IsGrounded = true;
                _player.MovementContext.FreefallTime = 0f;
                //_player.MovementContext.FallSa = 0f;
                /*object FieldValue = _player.HealthController.GetType().BaseType
                    .GetField("dictionary_0", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(_player.HealthController);*/
                //Dictionary<EBodyPart, GClass1262.BodyPartState>
                //_player.HealthController.GetBodyPartHealth(EBodyPart.Common).Current
                //_player.MovementContext.VerticalSpeed.
                _player.Transform.position = Camera.main.transform.position - Camera.main.transform.forward * 0.2f;
            }
        }
        public void TeleportPlayerToCamera()
        {
            _player.Transform.position = Camera.main.transform.position;
        }
        public void MouseMove() 
        {
            currentRotation.x += Input.GetAxisRaw("Mouse X") * _cameraSpeed;
            currentRotation.y -= Input.GetAxisRaw("Mouse Y") * _cameraSpeed;
            currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
            Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        }
        public void Move() {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move_FWD();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Move_BWD();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move_Left();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Move_Right();
            }
            if (Input.GetKey(KeyCode.RightControl))
            {
                Move_DWN();
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                Move_UP();
            }
        }
        void Move_FWD()
        {
            if (_player == null || !enabled) return;
            Vector3 move = Camera.main.transform.forward * _moveSpeed;
            Camera.main.transform.position += move * Time.deltaTime;
        }
        void Move_BWD()
        {
            if (_player == null || !enabled) return;
            Vector3 move = Camera.main.transform.forward * _moveSpeed;
            Camera.main.transform.position -= move * Time.deltaTime;
        }
        void Move_UP()
        {
            if (_player == null || !enabled) return;
            Vector3 move = Camera.main.transform.up * _moveSpeed;
            Camera.main.transform.position += move * Time.deltaTime;
        }
        void Move_DWN()
        {
            if (_player == null || !enabled) return;
            Vector3 move = Camera.main.transform.up * _moveSpeed;
            Camera.main.transform.position -= move * Time.deltaTime;
        }
        void Move_Left()
        {
            if (_player == null || !enabled) return;
            Vector3 move = Camera.main.transform.right * _moveSpeed;
            Camera.main.transform.position -= move * Time.deltaTime;
        }
        void Move_Right()
        {
            if (_player == null || !enabled) return;
            Vector3 move = Camera.main.transform.right * _moveSpeed;
            Camera.main.transform.position += move * Time.deltaTime;
        }
    }
}
