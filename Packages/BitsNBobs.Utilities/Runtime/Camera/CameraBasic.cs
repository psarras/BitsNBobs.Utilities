    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
    using Color = System.Drawing.Color;

    namespace BitsNBobs.Cameras
{
    public class CameraBasic : MonoBehaviour
    {
        public int Shift_Speed_Mod = 5;
        public float ZoomMod = 0.25f;
        public float PanMod = .001f;
        private float NavModDefault = .005f;
        public float NavMod = 0.005f;
        public float speedModifier = 500;

        public float distance = 100;
        public float Dampening = 5;

        private Vector3 mousePositionPrevious = Vector3.zero;
        private Vector3 targetPan;
        private Vector3 tRot;
        public Vector3 target;

        private float OrthoTarget;
        private float maxPan = 100f;
        public Quaternion desiredRotation { get; private set; }
        private bool needUpdate = false;

        public float speedOrbit = .25f;

        private new Camera cameraRef;
        public Camera cam;

        private void Awake()
        {
            cam = GetComponent<Camera>();
        }

        public void Start()
        {
            StopMovement();
            cameraRef = GetComponent<Camera>();
            target = transform.position + transform.forward * distance;

        }

        public void OnDrawGizmos()
        {
            Gizmos.color = UnityEngine.Color.red;
            Gizmos.DrawCube(target, Vector3.one * 2);
        }

        public void Update()
        {
            //Not on UI
            if (EventSystem.current.IsPointerOverGameObject(-1) == false)
            {
                if (IsWithinRect())
                {
                    speedModifier = 500f;

                    var ray = cam.ScreenPointToRay(Input.mousePosition);
                    var hit = Physics.Raycast(ray, out var hitInfo);
                    if (hit)
                    {
                        var dist = Vector3.Distance(transform.position, hitInfo.point);
                        speedModifier = dist;
                    }

                    //Define Pan
                    if (Input.GetMouseButton(2) || Input.touchCount >= 3) //Middle button | Right + Control | Three Figers
                    {
                        var mouseDelta = mousePositionPrevious - Input.mousePosition;

                        if (mouseDelta.magnitude > maxPan)
                            mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxPan);

                        target += transform.right * mouseDelta.x * speedModifier * PanMod + transform.up * mouseDelta.y * speedModifier * PanMod;
                        UpdateTarget();
                    }

                    //Define Zoom 
                    if (Input.mouseScrollDelta.y != 0 && !Input.anyKey)
                    {
                        var scrollDelta = Input.mouseScrollDelta; //Scroll | Pinch To Zoom
                        cameraRef = GetComponent<Camera>();
                        OrthoTarget = cameraRef.orthographicSize - scrollDelta.y * speedModifier * ZoomMod / 2f;

                        if (hit)
                        {
                            Vector3 toMouse = scrollDelta.y * ray.direction * speedModifier * ZoomMod;

                            target += toMouse;
                            transform.position += toMouse;
                            UpdateTarget();
                        }
                        else
                        {
                            Vector3 toTarget = scrollDelta.y * ray.direction * distance * ZoomMod;
                            target += toTarget;
                            transform.position += toTarget;
                        }
                    }

                    //Define Orbit
                    if (Input.GetMouseButton(1)) //Right Click | 2 Figers
                    {
                        var mouseDelta = mousePositionPrevious - Input.mousePosition;
                        if (mouseDelta.magnitude > maxPan)
                            mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxPan);

                        tRot += new Vector3(-mouseDelta.x, mouseDelta.y) * speedOrbit;
                        desiredRotation = Quaternion.Euler(new Vector3(tRot.y, tRot.x, 0));
                        if (Input.GetKey(KeyCode.LeftAlt))
                        {
                            UpdateTowards();
                        }
                    }

                    //Define Move
                    {
                        NavMod = NavModDefault;
                        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            NavMod *= Shift_Speed_Mod;
                        }
                        //Forward / Packwards
                        {
                            var towards = transform.forward * distance * NavMod;//speedModifier
                            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightControl)))
                            {
                                transform.position += towards;
                                target += towards;
                                UpdateTarget();
                            }
                            else if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightControl)))
                            {
                                transform.position -= towards;
                                target -= towards;
                                UpdateTarget();
                            }
                        }
                        //Left Right
                        {
                            var side = transform.right * distance * NavMod;//speedModifier
                            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                            {
                                transform.position += side;
                                target += side;
                                UpdateTarget();
                            }
                            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                            {
                                transform.position -= side;
                                target -= side;
                                UpdateTarget();
                            }
                        }

                        //UP / Down
                        {
                            var up = transform.up * distance * NavMod;//speedModifier
                            if (Input.GetKey(KeyCode.E) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightControl)))
                            {
                                transform.position += up;
                                target += up;
                                UpdateTarget();
                            }
                            else if (Input.GetKey(KeyCode.Q) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightControl)))
                            {
                                transform.position -= up;
                                target -= up;
                                UpdateTarget();
                            }
                        }
                    }
                    //////////////////////////////
                    mousePositionPrevious = Input.mousePosition;
                }
            }

            cameraRef.orthographicSize = Mathf.Lerp(cameraRef.orthographicSize, distance, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * Dampening);
            Vector3 targetPosition = target - (transform.rotation * Vector3.forward * distance);

            if (!Input.GetKey(KeyCode.LeftAlt))
                transform.position = Vector3.Lerp(transform.position, targetPosition, 1);
        }

        private void UpdateTarget()
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(new Ray(transform.position, target - transform.position), out raycastHit))
            {
                target = raycastHit.point;
                distance = Vector3.Distance(target, transform.position);
            }
        }

        private void UpdateTowards()
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out raycastHit))
            {
                target = raycastHit.point;
                distance = Vector3.Distance(target, transform.position);
            }
            else
            {
                target = transform.position + transform.forward * distance;
            }
        }

        public void StopMovement()
        {
            StopPan();
            StopZoom();
            StopOrbit();
        }

        private void StopOrbit()
        {
            desiredRotation = transform.rotation;
            Vector3 rot = transform.rotation.eulerAngles;
            tRot = new Vector3(rot.y, rot.x, 0);
        }

        private void StopPan()
        {
            targetPan = transform.position;
        }

        private void StopZoom()
        {
            cameraRef = GetComponent<Camera>();
            OrthoTarget = cameraRef.orthographicSize;
        }

        private bool IsWithinRect()
        {
            var m = Input.mousePosition;
            Rect rect = GetComponent<Camera>().rect;
            Rect copy = new Rect(rect);
            Vector2 screen = new Vector2(Screen.width, Screen.height);

            Vector2 position = copy.position;
            position.Scale(screen);
            copy.position = position;

            Vector2 size = copy.size;
            size.Scale(screen);
            copy.size = size;

            return copy.Contains(new Vector2(m.x, m.y));
        }

        public void MatchCamera(CameraBasic cameraBasic)
        {
            this.target = cameraBasic.target;
            transform.position = cameraBasic.transform.position;
            transform.rotation = cameraBasic.transform.rotation;
            distance = cameraBasic.distance;
            desiredRotation = cameraBasic.desiredRotation;
        }
    }
}
