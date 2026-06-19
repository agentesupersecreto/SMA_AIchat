using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.Globales.Mapas;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000028 RID: 40
	[RequireComponent(typeof(LookAtIK))]
	[RequireComponent(typeof(SexIKUpdater))]
	public class SexIKInitializador : CustomMonobehaviour, IIKInitializador
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00008336 File Offset: 0x00006536
		// (set) Token: 0x0600015C RID: 348 RVA: 0x0000833E File Offset: 0x0000653E
		Vector3 IIKInitializador.axisEurleOffset
		{
			get
			{
				return this.axisEurleOffset;
			}
			set
			{
				this.axisEurleOffset = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00008347 File Offset: 0x00006547
		public LookAtIK lookAtIK
		{
			get
			{
				if (this.m_LookAtIK == null)
				{
					this.m_LookAtIK = base.GetComponent<LookAtIK>();
					return this.m_LookAtIK;
				}
				return this.m_LookAtIK;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00008370 File Offset: 0x00006570
		public Transform lokingBone
		{
			get
			{
				return this.m_EntradaProxy;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00008378 File Offset: 0x00006578
		public Transform spine01Bone
		{
			get
			{
				return this.m_spine01Bone;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00008380 File Offset: 0x00006580
		public Transform hipsBone
		{
			get
			{
				return this.m_hipsBone;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00008388 File Offset: 0x00006588
		public Transform thingsRBone
		{
			get
			{
				return this.m_thingsRBone;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00008390 File Offset: 0x00006590
		public Transform thingsLBone
		{
			get
			{
				return this.m_thingsLBone;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00008398 File Offset: 0x00006598
		public Transform vagEntradaBone
		{
			get
			{
				return this.m_vagEntradaBone;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000164 RID: 356 RVA: 0x000083A0 File Offset: 0x000065A0
		public Transform anoEntradaBone
		{
			get
			{
				return this.m_anoEntradaBone;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000165 RID: 357 RVA: 0x000083A8 File Offset: 0x000065A8
		public Transform spine01Proxy
		{
			get
			{
				return this.m_spine01Proxy;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000166 RID: 358 RVA: 0x000083B0 File Offset: 0x000065B0
		public Transform hipsProxy
		{
			get
			{
				return this.m_hipsProxy;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000167 RID: 359 RVA: 0x000083B8 File Offset: 0x000065B8
		public Transform thingsRProxy
		{
			get
			{
				return this.m_thingsRProxy;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000168 RID: 360 RVA: 0x000083C0 File Offset: 0x000065C0
		public Transform thingsLProxy
		{
			get
			{
				return this.m_thingsLProxy;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000083C8 File Offset: 0x000065C8
		public Transform vagEntradaProxy
		{
			get
			{
				return this.m_vagEntradaProxy;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600016A RID: 362 RVA: 0x000083D0 File Offset: 0x000065D0
		public Transform anoEntradaProxy
		{
			get
			{
				return this.m_anoEntradaProxy;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600016B RID: 363 RVA: 0x000083D8 File Offset: 0x000065D8
		public Transform EntradaProxy
		{
			get
			{
				return this.m_EntradaProxy;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000083E0 File Offset: 0x000065E0
		public Transform hipsReal
		{
			get
			{
				return this.m_hipsReal;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600016D RID: 365 RVA: 0x000083E8 File Offset: 0x000065E8
		public Transform spine01Real
		{
			get
			{
				return this.m_spine01Real;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600016E RID: 366 RVA: 0x000083F0 File Offset: 0x000065F0
		public Transform thingsRReal
		{
			get
			{
				return this.m_thingsRReal;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600016F RID: 367 RVA: 0x000083F8 File Offset: 0x000065F8
		public Transform thingsLReal
		{
			get
			{
				return this.m_thingsLReal;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00008400 File Offset: 0x00006600
		public Transform vagEntradaReal
		{
			get
			{
				return this.m_vagEntradaReal;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00008408 File Offset: 0x00006608
		public Transform anoEntradaReal
		{
			get
			{
				return this.m_anoEntradaReal;
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00008410 File Offset: 0x00006610
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.SetDefaultCurve();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00008420 File Offset: 0x00006620
		public void SetDefaultCurve()
		{
			LookAtIK lookAtIK;
			if (this.m_LookAtIK == null)
			{
				lookAtIK = base.GetComponent<LookAtIK>();
			}
			else
			{
				lookAtIK = this.m_LookAtIK;
			}
			Keyframe[] array = new Keyframe[]
			{
				new Keyframe(0f, 0.2f),
				new Keyframe(1f, 1f)
			};
			array[1].inTangent = 1f;
			lookAtIK.solver.spineWeightCurve = new AnimationCurve(array);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000084A0 File Offset: 0x000066A0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = base.GetComponent<SexIKUpdater>();
			if (!this.m_updater.isAwaken)
			{
				this.m_updater.ManualAwake();
			}
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			this.m_LookAtIK.solver.IKPositionWeight = 0f;
			this.m_Character = base.GetComponentInParent<ICharacter>();
			this.m_vag = this.m_Character.GetComponentInChildren<IVagHole>();
			this.m_ano = this.m_Character.GetComponentInChildren<IAnusHole>();
			this.m_LookAtIK.SetAnimator(this.m_Character.bodyAnimator);
			this.m_Character.stared += this.Cha_stared;
			this.m_vag.stared += this.M_hole_stared;
			this.m_ano.stared += this.M_hole_stared;
			this.m_updater.updating += this.M_updater_updating;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00008598 File Offset: 0x00006798
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_updater)
			{
				this.m_updater.updating -= this.M_updater_updating;
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000085C5 File Offset: 0x000067C5
		private void M_hole_stared(object sender)
		{
			if (this.m_vag.isStared && this.m_ano.isStared && this.m_Character.isStared)
			{
				this.SetChain();
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000085F4 File Offset: 0x000067F4
		protected void Cha_stared(object obj)
		{
			if (this.m_vag.isStared && this.m_ano.isStared && this.m_Character.isStared)
			{
				this.SetChain();
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00008624 File Offset: 0x00006824
		private void SetChain()
		{
			if (this.m_initiated)
			{
				return;
			}
			Animator componentInChildren = this.m_Character.GetComponentInChildren<Animator>();
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			Transform transform = base.transform.CreateChild("RealRoot");
			Transform transform2 = base.transform.CreateChild("ProxyRoot");
			this.m_spine01Bone = SexIKInitializador.TryGetBones(instance.Spine01, componentInChildren);
			this.m_hipsBone = SexIKInitializador.TryGetBones(instance.Hip, componentInChildren);
			this.m_thingsRBone = SexIKInitializador.TryGetBones(instance.Thigh_R, componentInChildren);
			this.m_thingsLBone = SexIKInitializador.TryGetBones(instance.Thigh_L, componentInChildren);
			this.m_vagEntradaBone = this.m_vag.entrada;
			this.m_anoEntradaBone = this.m_ano.entrada;
			this.m_spine01Real = this.m_spine01Bone.CloneTransform(null, false);
			this.m_hipsReal = this.m_hipsBone.CloneTransform(null, false);
			this.m_thingsRReal = this.m_thingsRBone.CloneTransform(null, false);
			this.m_thingsLReal = this.m_thingsLBone.CloneTransform(null, false);
			this.m_vagEntradaReal = this.m_vagEntradaBone.CloneTransform(null, false);
			this.m_anoEntradaReal = this.m_anoEntradaBone.CloneTransform(null, false);
			this.m_spine01Real.parent = transform;
			this.m_hipsReal.parent = this.m_spine01Real;
			this.m_thingsRReal.parent = this.m_hipsReal;
			this.m_thingsLReal.parent = this.m_hipsReal;
			this.m_vagEntradaReal.parent = this.m_hipsReal;
			this.m_anoEntradaReal.parent = this.m_hipsReal;
			this.m_spine01Proxy = this.m_spine01Real.CloneTransform(null, false);
			this.m_hipsProxy = this.m_hipsReal.CloneTransform(null, false);
			this.m_thingsRProxy = this.m_thingsRReal.CloneTransform(null, false);
			this.m_thingsLProxy = this.m_thingsLReal.CloneTransform(null, false);
			this.m_vagEntradaProxy = this.m_vagEntradaReal.CloneTransform(null, false);
			this.m_anoEntradaProxy = this.m_anoEntradaReal.CloneTransform(null, false);
			this.m_spine01Proxy.parent = transform2;
			this.m_hipsProxy.parent = this.m_spine01Proxy;
			this.m_thingsRProxy.parent = this.m_hipsProxy;
			this.m_thingsLProxy.parent = this.m_hipsProxy;
			this.m_vagEntradaProxy.parent = this.m_hipsProxy;
			this.m_anoEntradaProxy.parent = this.m_hipsProxy;
			this.FollowReales();
			this.m_EntradaProxy = this.m_vagEntradaProxy;
			if (!this.m_LookAtIK.solver.SetChain(new Transform[] { this.m_spine01Proxy }, this.m_hipsProxy, null, this.m_EntradaProxy))
			{
				throw new InvalidOperationException();
			}
			this.FixAxis(TipoDeSexIK.vag);
			this.m_initiated = true;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000088D2 File Offset: 0x00006AD2
		private void M_updater_updating()
		{
			if (!this.m_initiated)
			{
				return;
			}
			this.FollowReales();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000088E4 File Offset: 0x00006AE4
		public void FollowReales()
		{
			this.m_spine01Real.SetPositionAndRotation(this.m_spine01Bone.position, this.m_spine01Bone.rotation);
			this.m_hipsReal.SetPositionAndRotation(this.m_hipsBone.position, this.m_hipsBone.rotation);
			this.m_thingsRReal.SetPositionAndRotation(this.m_thingsRBone.position, this.m_thingsRBone.rotation);
			this.m_thingsLReal.SetPositionAndRotation(this.m_thingsLBone.position, this.m_thingsLBone.rotation);
			this.m_vagEntradaReal.SetPositionAndRotation(this.m_vagEntradaBone.position, this.m_vagEntradaBone.rotation);
			this.m_anoEntradaReal.SetPositionAndRotation(this.m_anoEntradaBone.position, this.m_anoEntradaBone.rotation);
			this.m_spine01Proxy.SetPositionAndRotation(this.m_spine01Bone.position, this.m_spine01Bone.rotation);
			this.m_hipsProxy.SetPositionAndRotation(this.m_hipsBone.position, this.m_hipsBone.rotation);
			this.m_thingsRProxy.SetPositionAndRotation(this.m_thingsRBone.position, this.m_thingsRBone.rotation);
			this.m_thingsLProxy.SetPositionAndRotation(this.m_thingsLBone.position, this.m_thingsLBone.rotation);
			this.m_vagEntradaProxy.SetPositionAndRotation(this.m_vagEntradaBone.position, this.m_vagEntradaBone.rotation);
			this.m_anoEntradaProxy.SetPositionAndRotation(this.m_anoEntradaBone.position, this.m_anoEntradaBone.rotation);
			if (this.aplicarPosicionesDeEffector)
			{
				IKEffector effector = this.m_updater.fullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.Body);
				this.m_spine01Real.position = (this.m_spine01Proxy.position = Vector3.Lerp(this.m_spine01Real.position, effector.position, effector.positionWeight));
				Vector3 vector = this.m_hipsProxy.position - (this.m_thingsRProxy.position + this.m_thingsLProxy.position) / 2f;
				IKEffector effector2 = this.m_updater.fullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.LeftThigh);
				IKEffector effector3 = this.m_updater.fullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.RightThigh);
				Vector3 vector2 = Vector3.Lerp(this.m_thingsLProxy.position, effector2.position, effector2.positionWeight);
				Vector3 vector3 = Vector3.Lerp(this.m_thingsRReal.position, effector3.position, effector3.positionWeight);
				this.m_hipsReal.position = (this.m_hipsProxy.position = (vector2 + vector3) / 2f + vector);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00008BAC File Offset: 0x00006DAC
		public void FixAxis(TipoDeSexIK tipo)
		{
			if (!this.actualizarAxis)
			{
				return;
			}
			IHole hole;
			switch (tipo)
			{
			case TipoDeSexIK.vag:
				hole = this.m_vag;
				this.m_EntradaProxy = this.m_vagEntradaProxy;
				goto IL_005A;
			case TipoDeSexIK.anal:
				hole = this.m_ano;
				this.m_EntradaProxy = this.m_anoEntradaProxy;
				goto IL_005A;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
			IL_005A:
			Vector3 normalized = (hole.entrada.position - this.m_hipsBone.position).normalized;
			this.m_LookAtIK.solver.head.axis = Quaternion.Inverse(this.m_LookAtIK.solver.head.transform.rotation) * Quaternion.Euler(this.axisEurleOffset + this.userAxisEurleOffset) * normalized;
			for (int i = 0; i < this.m_LookAtIK.solver.spine.Length; i++)
			{
				IKSolverLookAt.LookAtBone lookAtBone = this.m_LookAtIK.solver.spine[i];
				lookAtBone.axis = Quaternion.Inverse(lookAtBone.transform.rotation) * Quaternion.Euler(this.axisEurleOffset + this.userAxisEurleOffset) * normalized;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00008CF1 File Offset: 0x00006EF1
		private static void TryAddBonesToSpine(Transform bone, IList<Transform> target)
		{
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			target.Add(bone);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00008D13 File Offset: 0x00006F13
		private static Transform TryGetBones(string boneName, Animator Animator)
		{
			if (string.IsNullOrEmpty(boneName))
			{
				return null;
			}
			return Animator.GetBoneTransform(boneName);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00008D28 File Offset: 0x00006F28
		private void OnDrawGizmosSelected()
		{
			if (this.m_initiated && Application.isPlaying)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawSphere(this.m_spine01Proxy.position, 0.01f);
				Gizmos.DrawSphere(this.m_hipsProxy.position, 0.01f);
				Gizmos.DrawSphere(this.m_thingsRProxy.position, 0.01f);
				Gizmos.DrawSphere(this.m_thingsLProxy.position, 0.01f);
				Gizmos.DrawSphere(this.m_vagEntradaProxy.position, 0.01f);
				Gizmos.DrawSphere(this.m_anoEntradaProxy.position, 0.01f);
				Gizmos.DrawLine(this.m_spine01Proxy.position, this.m_hipsProxy.position);
				Gizmos.DrawLine(this.m_hipsProxy.position, this.m_thingsRProxy.position);
				Gizmos.DrawLine(this.m_hipsProxy.position, this.m_thingsLProxy.position);
				Gizmos.DrawLine(this.m_hipsProxy.position, this.m_vagEntradaProxy.position);
				Gizmos.DrawLine(this.m_hipsProxy.position, this.m_anoEntradaProxy.position);
				Gizmos.color = Color.magenta;
				Gizmos.DrawSphere(this.m_spine01Real.position, 0.01f);
				Gizmos.DrawSphere(this.m_hipsReal.position, 0.01f);
				Gizmos.DrawSphere(this.m_thingsRReal.position, 0.01f);
				Gizmos.DrawSphere(this.m_thingsLReal.position, 0.01f);
				Gizmos.DrawSphere(this.m_vagEntradaReal.position, 0.01f);
				Gizmos.DrawSphere(this.m_anoEntradaReal.position, 0.01f);
				Gizmos.DrawLine(this.m_spine01Real.position, this.m_hipsReal.position);
				Gizmos.DrawLine(this.m_hipsReal.position, this.m_thingsRReal.position);
				Gizmos.DrawLine(this.m_hipsReal.position, this.m_thingsLReal.position);
				Gizmos.DrawLine(this.m_hipsReal.position, this.m_vagEntradaReal.position);
				Gizmos.DrawLine(this.m_hipsReal.position, this.m_anoEntradaReal.position);
			}
		}

		// Token: 0x040000E6 RID: 230
		public bool aplicarPosicionesDeEffector = true;

		// Token: 0x040000E7 RID: 231
		public Vector3 axisEurleOffset;

		// Token: 0x040000E8 RID: 232
		public Vector3 userAxisEurleOffset = new Vector3(0f, 0f, 0f);

		// Token: 0x040000E9 RID: 233
		public bool actualizarAxis = true;

		// Token: 0x040000EA RID: 234
		private SexIKUpdater m_updater;

		// Token: 0x040000EB RID: 235
		protected LookAtIK m_LookAtIK;

		// Token: 0x040000EC RID: 236
		protected ICharacter m_Character;

		// Token: 0x040000ED RID: 237
		protected IVagHole m_vag;

		// Token: 0x040000EE RID: 238
		protected IAnusHole m_ano;

		// Token: 0x040000EF RID: 239
		private Transform m_hipsBone;

		// Token: 0x040000F0 RID: 240
		private Transform m_spine01Bone;

		// Token: 0x040000F1 RID: 241
		private Transform m_thingsRBone;

		// Token: 0x040000F2 RID: 242
		private Transform m_thingsLBone;

		// Token: 0x040000F3 RID: 243
		private Transform m_vagEntradaBone;

		// Token: 0x040000F4 RID: 244
		private Transform m_anoEntradaBone;

		// Token: 0x040000F5 RID: 245
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_spine01Proxy;

		// Token: 0x040000F6 RID: 246
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_hipsProxy;

		// Token: 0x040000F7 RID: 247
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_thingsRProxy;

		// Token: 0x040000F8 RID: 248
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_thingsLProxy;

		// Token: 0x040000F9 RID: 249
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_vagEntradaProxy;

		// Token: 0x040000FA RID: 250
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_anoEntradaProxy;

		// Token: 0x040000FB RID: 251
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_EntradaProxy;

		// Token: 0x040000FC RID: 252
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_spine01Real;

		// Token: 0x040000FD RID: 253
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_hipsReal;

		// Token: 0x040000FE RID: 254
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_thingsRReal;

		// Token: 0x040000FF RID: 255
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_thingsLReal;

		// Token: 0x04000100 RID: 256
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_vagEntradaReal;

		// Token: 0x04000101 RID: 257
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_anoEntradaReal;

		// Token: 0x04000102 RID: 258
		private bool m_initiated;
	}
}
