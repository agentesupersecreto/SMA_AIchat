using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200004F RID: 79
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/simple_controller.html")]
	[AddComponentMenu("Dialogue System/Actor/Player/Simple Controller")]
	[RequireComponent(typeof(CharacterController))]
	public class SimpleController : MonoBehaviour
	{
		// Token: 0x06000253 RID: 595 RVA: 0x0000C700 File Offset: 0x0000A900
		private void Awake()
		{
			this.controller = base.GetComponent<CharacterController>();
			this.smoothCamera = base.GetComponentInChildren<SmoothCameraWithBumper>();
			this.audioSource = base.GetComponentInChildren<AudioSource>();
			this.anim = base.GetComponent<Animation>();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000C734 File Offset: 0x0000A934
		private void Start()
		{
			this.originalCameraRotation = Camera.main.transform.localRotation;
			this.anim.AddClip((this.aim != null) ? this.aim : this.idle, "aim");
			this.anim["aim"].layer = 1;
			this.anim["aim"].AddMixingTransform(this.upperBodyMixingTransform);
			this.anim[this.fire.name].layer = 1;
			this.anim[this.fire.name].AddMixingTransform(this.upperBodyMixingTransform);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
		private void Update()
		{
			if (Time.timeScale <= 0f)
			{
				return;
			}
			base.transform.Rotate(0f, Input.GetAxis("Mouse X") * this.mouseSensitivityX, 0f);
			this.cameraRotationY += Input.GetAxis("Mouse Y") * this.mouseSensitivityY;
			this.cameraRotationY = SimpleController.ClampAngle(this.cameraRotationY, this.mouseMinimumY, this.mouseMaximumY);
			Quaternion quaternion = Quaternion.AngleAxis(this.cameraRotationY, -Vector3.right);
			if (this.smoothCamera != null)
			{
				this.smoothCamera.adjustQuaternion = quaternion;
			}
			else
			{
				Camera.main.transform.localRotation = this.originalCameraRotation * quaternion;
			}
			if (this.fire != null && Input.GetButtonDown("Fire1") && !this.firing)
			{
				this.anim.CrossFade(this.fire.name);
				this.firing = true;
				this.fired = false;
				this.endFiringTime = Time.time + this.fire.length - 0.3f;
			}
			if (this.firing && Time.time > this.endFiringTime)
			{
				this.anim.CrossFade("aim");
				this.firing = false;
				if (!this.fired)
				{
					this.OnFired();
				}
			}
			float axis = Input.GetAxis("Vertical");
			float axis2 = Input.GetAxis("Horizontal");
			this.centralSpeed = Mathf.SmoothDamp(this.centralSpeed, axis, ref this.centralVelocity, 0.3f);
			this.lateralSpeed = Mathf.SmoothDamp(this.lateralSpeed, axis2, ref this.lateralVelocity, 0.3f);
			if (Mathf.Abs(axis) > 0.1f || Mathf.Abs(axis2) > 0.1f)
			{
				if (axis >= 0f)
				{
					this.anim[this.runForward.name].speed = 1f;
					this.anim.CrossFade(this.runForward.name);
				}
				else if (axis < -0.1f)
				{
					if (this.runBack != null)
					{
						this.anim.CrossFade(this.runBack.name);
					}
					else
					{
						this.anim[this.runForward.name].speed = -1f;
						this.anim.CrossFade(this.runForward.name);
					}
				}
			}
			else
			{
				this.anim.CrossFade(this.idle.name);
			}
			this.controller.Move(base.transform.rotation * (Vector3.forward * this.centralSpeed * this.runSpeed * Time.deltaTime + Vector3.right * this.lateralSpeed * this.runSpeed * Time.deltaTime) + Vector3.down * 20f * Time.deltaTime);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000CB08 File Offset: 0x0000AD08
		private void OnConversationStart()
		{
			this.anim.CrossFade(this.idle.name);
			this.centralSpeed = 0f;
			this.centralVelocity = 0f;
			this.lateralSpeed = 0f;
			this.lateralVelocity = 0f;
			this.firing = false;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000CB60 File Offset: 0x0000AD60
		private void OnFired()
		{
			this.fired = true;
			if (this.fireSound != null && this.audioSource != null)
			{
				this.audioSource.PlayOneShot(this.fireSound);
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2))), out raycastHit, float.PositiveInfinity, this.fireLayerMask))
			{
				raycastHit.collider.gameObject.BroadcastMessage("TakeDamage", this.weaponDamage, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000CBFB File Offset: 0x0000ADFB
		public static float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
			return Mathf.Clamp(angle, min, max);
		}

		// Token: 0x040001DD RID: 477
		public AnimationClip idle;

		// Token: 0x040001DE RID: 478
		public AnimationClip runForward;

		// Token: 0x040001DF RID: 479
		public AnimationClip runBack;

		// Token: 0x040001E0 RID: 480
		public AnimationClip aim;

		// Token: 0x040001E1 RID: 481
		public AnimationClip fire;

		// Token: 0x040001E2 RID: 482
		public Transform upperBodyMixingTransform;

		// Token: 0x040001E3 RID: 483
		public float runSpeed = 5f;

		// Token: 0x040001E4 RID: 484
		public float mouseSensitivityX = 15f;

		// Token: 0x040001E5 RID: 485
		public float mouseSensitivityY = 10f;

		// Token: 0x040001E6 RID: 486
		public float mouseMinimumY = -60f;

		// Token: 0x040001E7 RID: 487
		public float mouseMaximumY = 60f;

		// Token: 0x040001E8 RID: 488
		public LayerMask fireLayerMask = 1;

		// Token: 0x040001E9 RID: 489
		public AudioClip fireSound;

		// Token: 0x040001EA RID: 490
		public float weaponDamage = 100f;

		// Token: 0x040001EB RID: 491
		private CharacterController controller;

		// Token: 0x040001EC RID: 492
		private SmoothCameraWithBumper smoothCamera;

		// Token: 0x040001ED RID: 493
		private AudioSource audioSource;

		// Token: 0x040001EE RID: 494
		private Animation anim;

		// Token: 0x040001EF RID: 495
		private float centralSpeed;

		// Token: 0x040001F0 RID: 496
		private float centralVelocity;

		// Token: 0x040001F1 RID: 497
		private float lateralSpeed;

		// Token: 0x040001F2 RID: 498
		private float lateralVelocity;

		// Token: 0x040001F3 RID: 499
		private float cameraRotationY;

		// Token: 0x040001F4 RID: 500
		private Quaternion originalCameraRotation;

		// Token: 0x040001F5 RID: 501
		private bool firing;

		// Token: 0x040001F6 RID: 502
		private bool fired;

		// Token: 0x040001F7 RID: 503
		private float endFiringTime;
	}
}
