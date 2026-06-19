using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises
{
	// Token: 0x02000109 RID: 265
	public class PenisPointCollider : BodyPartCollider, IPeneParteCollider
	{
		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x0002689A File Offset: 0x00024A9A
		public CapsuleCollider mainCollider
		{
			get
			{
				return this.m_collider;
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x000268A2 File Offset: 0x00024AA2
		// (set) Token: 0x06000B99 RID: 2969 RVA: 0x000268AF File Offset: 0x00024AAF
		public bool isTrigger
		{
			get
			{
				return this.m_collider.isTrigger;
			}
			set
			{
				this.m_collider.isTrigger = value;
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x000268BD File Offset: 0x00024ABD
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x000268C5 File Offset: 0x00024AC5
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x000268CC File Offset: 0x00024ACC
		public float height
		{
			get
			{
				return this.m_Height;
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x000268D4 File Offset: 0x00024AD4
		public float radius
		{
			get
			{
				return this.m_Radius;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x000268DC File Offset: 0x00024ADC
		public float worldRadius
		{
			get
			{
				return this.m_Radius * this.m_penetrator.worldScale;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x000268F0 File Offset: 0x00024AF0
		public float worldHeight
		{
			get
			{
				return this.m_Height * this.m_penetrator.worldScale;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00026904 File Offset: 0x00024B04
		public Vector3 center
		{
			get
			{
				return this.m_Center;
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0002690C File Offset: 0x00024B0C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_updateAnchoCoroutine = new CoroutineCapsule(this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = false
			});
			this.m_updateAnchoCoroutine.Start(this.CheckAnchoChanged(), null, null);
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0002695A File Offset: 0x00024B5A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (!base.isStared)
			{
				return;
			}
			this.m_forceUpdateCollider = true;
			if (this.m_chain != null && this.m_collider != null)
			{
				this.IgnorarCollisiones();
			}
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00026994 File Offset: 0x00024B94
		private IEnumerator CheckAnchoChanged()
		{
			yield return new WaitForSeconds(0.2f * Random.Range(0.9f, 1.1f));
			for (;;)
			{
				this.UpdateSize(this.m_forceUpdateCollider);
				this.m_forceUpdateCollider = false;
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x000269A4 File Offset: 0x00024BA4
		public void UpdateSize(bool forceUpdateOnOwner)
		{
			bool flag = false;
			float num = this.modificableDeAncho.ModificarValor(this.m_initialRadius);
			if (num != this.m_Radius)
			{
				this.m_Radius = (this.m_collider.radius = num);
				flag = true;
			}
			float num2 = this.modificableDeAlto.ModificarValor(this.m_initialHeight);
			if (num2 != this.m_Height)
			{
				this.m_Height = (this.m_collider.height = num2);
				flag = true;
			}
			if (forceUpdateOnOwner && flag)
			{
				this.m_penetrator.FlagUpdateSizesData();
			}
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00026A28 File Offset: 0x00024C28
		public void IgnorarCollisiones()
		{
			if (this.m_chain.ignorarCollsiionesEntrePuntos)
			{
				ExtendedMonoBehaviour.IgnorarCollisiones(this.m_collider, this.m_chain.currentChildColliders, true);
			}
			if (this.m_chain.ignorarCollsiionesConPadres)
			{
				ExtendedMonoBehaviour.IgnorarCollisiones(this.m_collider, this.m_chain.currentParentColliders, true);
			}
			ExtendedMonoBehaviour.IgnorarCollisiones(this.m_collider, this.m_chain.collidersParaIgnorar, true);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00026A94 File Offset: 0x00024C94
		private void UpdateInitials()
		{
			this.m_Radius = (this.m_initialRadius = this.m_collider.radius);
			this.m_Height = (this.m_initialHeight = this.m_collider.height);
			this.m_Center = (this.m_initialCenter = this.m_collider.center);
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00026AEF File Offset: 0x00024CEF
		public Vector3 GetLastColliderTipWorldPosition()
		{
			if (this.m_physicsFrameId_WorldTipPos.IsCurrent())
			{
				return this.m_LastWorldTipPos;
			}
			this.m_physicsFrameId_WorldTipPos = ForcedFixedUpdateId.current;
			this.m_LastWorldTipPos = this.ColliderTipWorldPosition();
			return this.m_LastWorldTipPos;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00026B22 File Offset: 0x00024D22
		public Vector3 GetLastColliderBaseWorldPosition()
		{
			if (this.m_physicsFrameId_WorldBasePos.IsCurrent())
			{
				return this.m_LastWorldBasePos;
			}
			this.m_physicsFrameId_WorldBasePos = ForcedFixedUpdateId.current;
			this.m_LastWorldBasePos = this.ColliderInitialWorldPosition();
			return this.m_LastWorldBasePos;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00026B55 File Offset: 0x00024D55
		public Vector3 ColliderTipWorldPosition()
		{
			return base.transform.TransformPoint(this.ColliderTipLocalPosition());
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x00026B68 File Offset: 0x00024D68
		public Vector3 ColliderInitialWorldPosition()
		{
			return base.transform.TransformPoint(this.ColliderInitialLocalPosition());
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00026B7C File Offset: 0x00024D7C
		public Vector3 ColliderInitialLocalPosition()
		{
			if (this.m_collider.direction != 2)
			{
				throw new NotImplementedException();
			}
			Vector3 vector;
			if (this.radius * 2f > this.height)
			{
				vector = -Vector3.forward * this.radius + this.center;
			}
			else
			{
				vector = -Vector3.forward * (this.height / 2f) + this.center;
			}
			return vector;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00026BFC File Offset: 0x00024DFC
		public Vector3 ColliderTipLocalPosition()
		{
			if (this.m_collider.direction != 2)
			{
				throw new NotImplementedException();
			}
			Vector3 vector;
			if (this.radius * 2f > this.height)
			{
				vector = Vector3.forward * this.radius + this.center;
			}
			else
			{
				vector = Vector3.forward * (this.height / 2f) + this.center;
			}
			return vector;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x00026C74 File Offset: 0x00024E74
		public void Crear(PenisLinearChain chain, Transform target, int direction)
		{
			float magnitude = base.transform.InverseTransformPoint(target.position).magnitude;
			this.CrearPene(chain, magnitude * 3f, magnitude, direction);
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x00026CAC File Offset: 0x00024EAC
		private void CrearPene(PenisLinearChain chain, float localLargo, float localRadius, int direction)
		{
			this.m_collider = base.gameObject.AddComponent<CapsuleCollider>();
			this.m_collider.direction = direction;
			switch (direction)
			{
			case 0:
				this.m_collider.center = new Vector3(localLargo * 0.16666667f, 0f, 0f);
				break;
			case 1:
				this.m_collider.center = new Vector3(0f, localLargo * 0.16666667f, 0f);
				break;
			case 2:
				this.m_collider.center = new Vector3(0f, 0f, localLargo * 0.16666667f);
				break;
			default:
				throw new ArgumentOutOfRangeException(direction.ToString());
			}
			this.m_collider.radius = localRadius;
			this.m_collider.height = localLargo;
			this.UpdateInitials();
			this.m_chain = chain;
			this.m_penetrator = chain.GetComponent<Penetrador>();
			if (this.m_penetrator == null)
			{
				throw new ArgumentNullException("m_penetrator", "m_penetrator null reference.");
			}
			this.IgnorarCollisiones();
			this.OnCreado();
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00026DC0 File Offset: 0x00024FC0
		public void Crear(PenisLinearChain chain, float localLargo, float localRadius, int direction)
		{
			this.m_collider = base.gameObject.AddComponent<CapsuleCollider>();
			this.m_collider.direction = direction;
			switch (direction)
			{
			case 0:
				this.m_collider.center = new Vector3(localLargo * 0.5f, 0f, 0f);
				break;
			case 1:
				this.m_collider.center = new Vector3(0f, localLargo * 0.5f, 0f);
				break;
			case 2:
				this.m_collider.center = new Vector3(0f, 0f, localLargo * 0.5f);
				break;
			default:
				throw new ArgumentOutOfRangeException(direction.ToString());
			}
			this.m_collider.radius = localRadius;
			this.m_collider.height = localLargo + localRadius * 2f;
			this.UpdateInitials();
			this.m_chain = chain;
			this.m_penetrator = chain.GetComponent<Penetrador>();
			if (this.m_penetrator == null)
			{
				throw new ArgumentNullException("m_penetrator", "m_penetrator null reference.");
			}
			this.IgnorarCollisiones();
			this.OnCreado();
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x00026EDC File Offset: 0x000250DC
		public void Crear(PenisLinearChain chain, PenisPointCollider last, int direction)
		{
			this.m_collider = base.gameObject.AddComponent<CapsuleCollider>();
			this.m_collider.direction = direction;
			switch (direction)
			{
			case 0:
				this.m_collider.center = new Vector3(last.m_collider.center.z, 0f, 0f);
				break;
			case 1:
				this.m_collider.center = new Vector3(0f, last.m_collider.center.z, 0f);
				break;
			case 2:
				this.m_collider.center = new Vector3(0f, 0f, last.m_collider.center.z);
				break;
			default:
				throw new ArgumentOutOfRangeException(direction.ToString());
			}
			this.m_collider.radius = last.m_collider.radius;
			this.m_collider.height = last.m_collider.height;
			this.UpdateInitials();
			this.m_chain = chain;
			this.m_penetrator = chain.GetComponent<Penetrador>();
			if (this.m_penetrator == null)
			{
				throw new ArgumentNullException("m_penetrator", "m_penetrator null reference.");
			}
			this.IgnorarCollisiones();
			this.OnCreado();
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x00027020 File Offset: 0x00025220
		public void CrearCopiando(PenisLinearChain chain, PenisPointCollider toCopy)
		{
			this.m_collider = ExtendedMonoBehaviour.CopyCollider<CapsuleCollider>(base.gameObject, toCopy.m_collider, 1f);
			this.UpdateInitials();
			this.m_chain = chain;
			this.m_penetrator = chain.GetComponent<Penetrador>();
			if (this.m_penetrator == null)
			{
				throw new ArgumentNullException("m_penetrator", "m_penetrator null reference.");
			}
			this.IgnorarCollisiones();
			this.OnCreado();
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0002708C File Offset: 0x0002528C
		protected void OnCreado()
		{
			this.m_misColliders = new HashSet<Collider> { this.m_collider };
			base.initColliders();
		}

		// Token: 0x04000633 RID: 1587
		private CapsuleCollider m_collider;

		// Token: 0x04000634 RID: 1588
		private PenisLinearChain m_chain;

		// Token: 0x04000635 RID: 1589
		private Penetrador m_penetrator;

		// Token: 0x04000636 RID: 1590
		private HashSet<Collider> m_misColliders;

		// Token: 0x04000637 RID: 1591
		[ReadOnlyUI]
		[SerializeField]
		private float m_initialHeight;

		// Token: 0x04000638 RID: 1592
		[ReadOnlyUI]
		[SerializeField]
		private float m_initialRadius;

		// Token: 0x04000639 RID: 1593
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_initialCenter;

		// Token: 0x0400063A RID: 1594
		[ReadOnlyUI]
		[SerializeField]
		private float m_Height;

		// Token: 0x0400063B RID: 1595
		[ReadOnlyUI]
		[SerializeField]
		private float m_Radius;

		// Token: 0x0400063C RID: 1596
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_Center;

		// Token: 0x0400063D RID: 1597
		public ModificableDeFloat modificableDeAncho = new ModificableDeFloat(1f);

		// Token: 0x0400063E RID: 1598
		public ModificableDeFloat modificableDeAlto = new ModificableDeFloat(1f);

		// Token: 0x0400063F RID: 1599
		private ForcedFixedUpdateId m_physicsFrameId_WorldTipPos;

		// Token: 0x04000640 RID: 1600
		private ForcedFixedUpdateId m_physicsFrameId_WorldBasePos;

		// Token: 0x04000641 RID: 1601
		private Vector3 m_LastWorldTipPos;

		// Token: 0x04000642 RID: 1602
		private Vector3 m_LastWorldBasePos;

		// Token: 0x04000643 RID: 1603
		private CoroutineCapsule m_updateAnchoCoroutine;

		// Token: 0x04000644 RID: 1604
		private bool m_forceUpdateCollider = true;
	}
}
