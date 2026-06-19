using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200022A RID: 554
	public class DetectorDeCollisionesDeCamaraDeCharacter : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000E3F RID: 3647 RVA: 0x0003F696 File Offset: 0x0003D896
		public sealed override int updateEvent1Index
		{
			get
			{
				return 19;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00014284 File Offset: 0x00012484
		public sealed override int updateEvent2Index
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000E41 RID: 3649 RVA: 0x0003F69A File Offset: 0x0003D89A
		public IPuppetChar puppetChar
		{
			get
			{
				return this.m_char;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x0003F6A2 File Offset: 0x0003D8A2
		public SphereCollider cameraTrigger
		{
			get
			{
				return this.m_cameraTrigger;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000E43 RID: 3651 RVA: 0x0003F6AA File Offset: 0x0003D8AA
		public float defaultCameraTriggerRadius
		{
			get
			{
				return this.m_cameraTriggerRadius;
			}
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x0003F6B2 File Offset: 0x0003D8B2
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CCchar = this.GetComponentEnCharacter(false);
			this.m_char = this.GetComponentEnCharacter(false);
			if (this.m_char == null)
			{
				throw new ArgumentNullException("m_char", "m_char null reference.");
			}
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x0003F6EC File Offset: 0x0003D8EC
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_wasInsideHitSkin = false;
			if (!quitting)
			{
				this.ClearCamera();
			}
			this.m_lastFixedCollisionsColliders.Clear();
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0003F710 File Offset: 0x0003D910
		private void SetCamera(Transform cameraTrans)
		{
			this.m_cameraTransform = cameraTrans;
			this.m_lastCamera = cameraTrans.GetComponentInChildren<Camera>();
			if (this.m_lastCamera == null)
			{
				throw new ArgumentNullException("m_lastCamera", "m_lastCamera null reference.");
			}
			Rigidbody componentInChildren = this.m_lastCamera.GetComponentInChildren<Rigidbody>();
			this.m_cameraTrigger = componentInChildren.GetComponentInChildren<SphereCollider>();
			if (this.m_cameraTrigger == null)
			{
				throw new ArgumentNullException("m_cameraTrigger", "m_cameraTrigger null reference.");
			}
			this.m_cameraTriggerRadius = this.m_cameraTrigger.radius;
			this.m_BroadCaster = this.m_cameraTrigger.GetComponentNotNull<TriggerEventsBroadCaster>();
			this.m_BroadCaster.IgnoreColliders(this.m_char.puppetColliders, true);
			if (this.m_CCchar != null)
			{
				this.m_CCchar.UpdateActorControllerColliders();
				this.m_BroadCaster.IgnoreColliders(this.m_CCchar.characterControllerColliders, true);
			}
			this.m_BroadCaster.onTriggerEnter += this.M_BroadCaster_onTriggerAny;
			this.m_BroadCaster.onTriggerStay += this.M_BroadCaster_onTriggerAny;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x0003F818 File Offset: 0x0003DA18
		private void ClearCamera()
		{
			this.m_cameraTransform = null;
			this.m_lastCamera = null;
			this.m_cameraTrigger = null;
			if (this.m_BroadCaster)
			{
				this.m_BroadCaster.onTriggerEnter -= this.M_BroadCaster_onTriggerAny;
				this.m_BroadCaster.onTriggerStay -= this.M_BroadCaster_onTriggerAny;
				this.m_BroadCaster.IgnoreColliders(this.m_char.puppetColliders, false);
				if (this.m_CCchar != null)
				{
					this.m_CCchar.UpdateActorControllerColliders();
					this.m_BroadCaster.IgnoreColliders(this.m_CCchar.characterControllerColliders, false);
				}
			}
			this.m_BroadCaster = null;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x0003F8C0 File Offset: 0x0003DAC0
		private void UpdateCameraReference()
		{
			if (!(this.m_char.self.cameraAtadaTransform == null))
			{
				if (this.m_char.self.cameraAtadaTransform != this.m_cameraTransform)
				{
					this.ClearCamera();
					this.SetCamera(this.m_char.self.cameraAtadaTransform);
				}
				return;
			}
			if (this.m_lastCamera == null)
			{
				return;
			}
			this.ClearCamera();
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x0003F934 File Offset: 0x0003DB34
		public sealed override void OnUpdateEvent1()
		{
			this.m_lastFixedCollisionsColliders.Clear();
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x0003F944 File Offset: 0x0003DB44
		public sealed override void OnUpdateEvent2()
		{
			this.UpdateCameraReference();
			if (this.m_lastCamera == null)
			{
				this.direccionDeEscapeCalculada = Vector3.zero;
				return;
			}
			this.direccionDeEscapeCalculada = this.CalcularDireccionDeEscape(this.m_lastFixedCollisionsColliders, this.m_lastFixedCollisionsColliders.Count, DetectorDeCollisionesDeCamaraDeCharacter.m_hittedHitSkins);
			Transform transform = this.m_lastCamera.transform;
			Vector3 vector = transform.position + transform.forward * 0.0025f;
			bool flag = false;
			try
			{
				foreach (HitSkinBasica hitSkinBasica in DetectorDeCollisionesDeCamaraDeCharacter.m_hittedHitSkins)
				{
					flag = hitSkinBasica.PointIsInside(vector);
					if (flag)
					{
						break;
					}
				}
			}
			finally
			{
				DetectorDeCollisionesDeCamaraDeCharacter.m_hittedHitSkins.Clear();
			}
			if (flag != this.m_wasInsideHitSkin)
			{
				this.m_wasInsideHitSkin = flag;
				if (CameraFade.CanFade())
				{
					if (flag)
					{
						CameraFade.FadeOutMain(0.333f);
					}
					else
					{
						CameraFade.FadeInMain(1f);
					}
				}
			}
			bool flag2 = this.debugDraw;
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x0003FA54 File Offset: 0x0003DC54
		private Vector3 CalcularDireccionDeEscape(IList<Collider> others, int length, HashSet<HitSkinBasica> hittedHitSkins)
		{
			this.cameraScaleCalculada = this.cameraTrigger.transform.localScale.Escala();
			if (!this.activado)
			{
				return Vector3.zero;
			}
			int num = Mathf.Min(this.iteraciones, length);
			if (num <= 0)
			{
				return Vector3.zero;
			}
			length = Mathf.Min(others.Count, length);
			Vector3 vector = this.m_cameraTransform.position;
			Quaternion rotation = this.m_cameraTransform.rotation;
			for (int i = 0; i < num; i++)
			{
				if (i > 0)
				{
					others.Shuffle(length);
				}
				for (int j = 0; j < length; j++)
				{
					Collider collider = others[j];
					if (!(collider == null))
					{
						if (i == 0)
						{
							Rigidbody attachedRigidbody = collider.attachedRigidbody;
							HitSkinBasica hitSkinBasica = ((attachedRigidbody != null) ? attachedRigidbody.GetComponent<HitSkinBasica>() : null);
							if (hitSkinBasica != null)
							{
								hittedHitSkins.Add(hitSkinBasica);
							}
						}
						Vector3 vector2;
						float num2;
						if (Physics.ComputePenetration(this.m_cameraTrigger, vector, rotation, collider, collider.transform.position, collider.transform.rotation, out vector2, out num2))
						{
							vector += vector2 * num2;
						}
					}
				}
			}
			return vector - this.m_cameraTransform.position;
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x0003FB88 File Offset: 0x0003DD88
		private void M_BroadCaster_onTriggerAny(Collider obj)
		{
			if (this.m_char.puppetColliders.Contains(obj))
			{
				return;
			}
			if (this.m_char.ObjetoEsMiPene(obj))
			{
				return;
			}
			if (this.m_char.ObjetoEsMiDedo(obj))
			{
				return;
			}
			if (this.m_char.ObjetoEsMiMano(obj))
			{
				return;
			}
			this.m_lastFixedCollisionsColliders.Add(obj);
		}

		// Token: 0x040009D2 RID: 2514
		public bool activado = true;

		// Token: 0x040009D3 RID: 2515
		[ReadOnlyUI]
		[SerializeField]
		private Camera m_lastCamera;

		// Token: 0x040009D4 RID: 2516
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_cameraTransform;

		// Token: 0x040009D5 RID: 2517
		[ReadOnlyUI]
		[SerializeField]
		private SphereCollider m_cameraTrigger;

		// Token: 0x040009D6 RID: 2518
		[SerializeField]
		private float m_cameraTriggerRadius;

		// Token: 0x040009D7 RID: 2519
		private TriggerEventsBroadCaster m_BroadCaster;

		// Token: 0x040009D8 RID: 2520
		private IPuppetChar m_char;

		// Token: 0x040009D9 RID: 2521
		private ICharacterControllerChar m_CCchar;

		// Token: 0x040009DA RID: 2522
		[SerializeField]
		private SerializableHashSetList<Collider> m_lastFixedCollisionsColliders = new SerializableHashSetList<Collider>();

		// Token: 0x040009DB RID: 2523
		public Vector3 direccionDeEscapeCalculada;

		// Token: 0x040009DC RID: 2524
		public float cameraScaleCalculada;

		// Token: 0x040009DD RID: 2525
		public int iteraciones = 4;

		// Token: 0x040009DE RID: 2526
		public bool debugDraw;

		// Token: 0x040009DF RID: 2527
		private static HashSet<HitSkinBasica> m_hittedHitSkins = new HashSet<HitSkinBasica>();

		// Token: 0x040009E0 RID: 2528
		private bool m_wasInsideHitSkin;
	}
}
