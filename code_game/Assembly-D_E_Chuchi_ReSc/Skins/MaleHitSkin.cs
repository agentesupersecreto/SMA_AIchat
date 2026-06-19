using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200003A RID: 58
	public abstract class MaleHitSkin : MaleHitSkinBasica, IStepVelocitySaverEmulated, IStepVelocitySaver
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00004F18 File Offset: 0x00003118
		public sealed override int updateEvent1Index
		{
			get
			{
				return 66;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001BF RID: 447 RVA: 0x0000772F File Offset: 0x0000592F
		public sealed override Rigidbody rigid
		{
			get
			{
				return this.m_rigid;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00007737 File Offset: 0x00005937
		public IMassModifier massModifier
		{
			get
			{
				return this.m_Saver.massModifier;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00007744 File Offset: 0x00005944
		public Vector3 velocidadEnDeltaTime
		{
			get
			{
				return this.m_Saver.velocidadEnDeltaTime;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00007754 File Offset: 0x00005954
		[Obsolete("", true)]
		public Vector3 velocidadEnFixedDeltaTime
		{
			get
			{
				return default(Vector3);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000776A File Offset: 0x0000596A
		public Vector3 metrosPorSegundo
		{
			get
			{
				return this.m_Saver.metrosPorSegundo;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00007777 File Offset: 0x00005977
		public bool usaRigidBody
		{
			get
			{
				return this.m_Saver.usaRigidBody;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00007784 File Offset: 0x00005984
		public Vector3 physicsMetrosPorSegundo
		{
			get
			{
				return this.m_Saver.physicsMetrosPorSegundo;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00007791 File Offset: 0x00005991
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00007799 File Offset: 0x00005999
		public bool autoFollowTarget
		{
			get
			{
				return this.m_autofollowTarget;
			}
			set
			{
				this.m_autofollowTarget = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x000077A2 File Offset: 0x000059A2
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000077AA File Offset: 0x000059AA
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001CA RID: 458 RVA: 0x000077B2 File Offset: 0x000059B2
		public ModificableDeFloat modificableDeFriccionGeneral
		{
			get
			{
				return this.m_modificableDeFriccionGeneral;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001CB RID: 459 RVA: 0x000077BC File Offset: 0x000059BC
		public PhysicMaterial ownPhysicMaterial
		{
			get
			{
				if (this.m_OwnPhysicMaterial == null)
				{
					this.m_OwnPhysicMaterial = this.ObtenerClonePhysicMaterial();
					if (this.m_OwnPhysicMaterial == null)
					{
						throw new ArgumentNullException("m_OwnPhysicMaterial", "m_OwnPhysicMaterial null reference.");
					}
					this.m_defaultStaticFricc = this.m_OwnPhysicMaterial.staticFriction;
					this.m_defaultDynamicFricc = this.m_OwnPhysicMaterial.dynamicFriction;
				}
				return this.m_OwnPhysicMaterial;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001CC RID: 460 RVA: 0x0000515E File Offset: 0x0000335E
		protected virtual bool? isKinematic
		{
			get
			{
				return new bool?(true);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00007829 File Offset: 0x00005A29
		public sealed override ParteQuePuedeEstimular parteQuePuedeEstimular
		{
			get
			{
				return this.m_parte;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00007834 File Offset: 0x00005A34
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_rigid = this.GetComponentNotNull<Rigidbody>();
			if (this.isKinematic != null)
			{
				this.m_rigid.isKinematic = this.isKinematic.Value;
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000787C File Offset: 0x00005A7C
		public virtual void Init(ParteQuePuedeEstimular parte, Transform boneTarget, Skin VisualSkin)
		{
			this.m_parte = parte;
			this.m_Saver = this.rigid.transform.GetComponentNotNull<EmulatedStepVelocitySaver>();
			this.m_myCharacter = base.GetComponentInParent<Character>();
			base.InitBasica(boneTarget, VisualSkin);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000078B0 File Offset: 0x00005AB0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!base.isHitSkinInit)
			{
				Debug.LogWarning("Skin: " + base.GetType().Name + " no fue iniciada.", base.gameObject);
				throw new InvalidOperationException();
			}
			foreach (Collider collider in this.skinColliders)
			{
				collider.sharedMaterial = this.ownPhysicMaterial;
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00004EB4 File Offset: 0x000030B4
		public bool ContieneCollider(Collider collider)
		{
			return this.skinCollidersSet.Contains(collider);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000539B File Offset: 0x0000359B
		protected virtual PhysicMaterial ObtenerClonePhysicMaterial()
		{
			return Object.Instantiate<PhysicMaterial>(Singleton<ColecionDePhysicsMaterials>.instance.skin);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00007940 File Offset: 0x00005B40
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_OwnPhysicMaterial != null)
			{
				Object.DestroyImmediate(this.m_OwnPhysicMaterial);
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000053CE File Offset: 0x000035CE
		public void ObtenerCollider(List<Collider> result)
		{
			base.GetComponentsInChildren<Collider>(result);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007964 File Offset: 0x00005B64
		public override void OnUpdateEvent1()
		{
			float num = this.m_modificableDeFriccionGeneral.ModificarValor(1f);
			if (this.m_LastModFriccionGeneral == null || !ExtendedMonoBehaviour.AlmostEqual(this.m_LastModFriccionGeneral.Value, num, 0.01f))
			{
				this.m_LastModFriccionGeneral = new float?(num);
				this.m_OwnPhysicMaterial.dynamicFriction = this.m_defaultDynamicFricc * num;
				this.m_OwnPhysicMaterial.staticFriction = this.m_defaultStaticFricc * num;
			}
			if (this.m_autofollowTarget)
			{
				base.FollowTargetBone();
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00005A9A File Offset: 0x00003C9A
		string IStepVelocitySaver.get_name()
		{
			return base.name;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool IStepVelocitySaver.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00005AAA File Offset: 0x00003CAA
		void IStepVelocitySaver.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00005AB3 File Offset: 0x00003CB3
		Transform IStepVelocitySaver.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040000EC RID: 236
		private ModificableDeFloat m_modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x040000ED RID: 237
		private float m_defaultStaticFricc;

		// Token: 0x040000EE RID: 238
		private float m_defaultDynamicFricc;

		// Token: 0x040000EF RID: 239
		private float? m_LastModFriccionGeneral;

		// Token: 0x040000F0 RID: 240
		private EmulatedStepVelocitySaver m_Saver;

		// Token: 0x040000F1 RID: 241
		private Character m_myCharacter;

		// Token: 0x040000F2 RID: 242
		[SerializeField]
		[ReadOnlyUI]
		private Rigidbody m_rigid;

		// Token: 0x040000F3 RID: 243
		[SerializeField]
		[ReadOnlyUI]
		private ParteQuePuedeEstimular m_parte;

		// Token: 0x040000F4 RID: 244
		[SerializeField]
		private bool m_autofollowTarget = true;

		// Token: 0x040000F5 RID: 245
		private PhysicMaterial m_OwnPhysicMaterial;
	}
}
