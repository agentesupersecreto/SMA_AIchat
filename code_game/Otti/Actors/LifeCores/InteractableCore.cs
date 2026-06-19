using System;
using System.Collections.Generic;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000AE RID: 174
	public class InteractableCore : MonoBehaviour, IInteractableCore, ILifeCore
	{
		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x000308EF File Offset: 0x0002EAEF
		// (set) Token: 0x06000999 RID: 2457 RVA: 0x000308F7 File Offset: 0x0002EAF7
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x00030900 File Offset: 0x0002EB00
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x00030908 File Offset: 0x0002EB08
		public string Motion
		{
			get
			{
				return this._Motion;
			}
			set
			{
				this._Motion = value;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x00030911 File Offset: 0x0002EB11
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x00030919 File Offset: 0x0002EB19
		public int Form
		{
			get
			{
				return this._Form;
			}
			set
			{
				this._Form = value;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x00030922 File Offset: 0x0002EB22
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x0003092A File Offset: 0x0002EB2A
		public bool ForcePosition
		{
			get
			{
				return this._ForcePosition;
			}
			set
			{
				this._ForcePosition = value;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x00030933 File Offset: 0x0002EB33
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x0003093B File Offset: 0x0002EB3B
		public bool ForceRotation
		{
			get
			{
				return this._ForceRotation;
			}
			set
			{
				this._ForceRotation = value;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x00030944 File Offset: 0x0002EB44
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x0003094C File Offset: 0x0002EB4C
		public Transform TargetLocation
		{
			get
			{
				return this._TargetLocation;
			}
			set
			{
				this._TargetLocation = value;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x00030955 File Offset: 0x0002EB55
		// (set) Token: 0x060009A5 RID: 2469 RVA: 0x0003095D File Offset: 0x0002EB5D
		public float TargetDistance
		{
			get
			{
				return this._TargetDistance;
			}
			set
			{
				this._TargetDistance = value;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x00030966 File Offset: 0x0002EB66
		// (set) Token: 0x060009A7 RID: 2471 RVA: 0x0003096E File Offset: 0x0002EB6E
		public bool UseRaycast
		{
			get
			{
				return this._UseRaycast;
			}
			set
			{
				this._UseRaycast = value;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x00030977 File Offset: 0x0002EB77
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0003097F File Offset: 0x0002EB7F
		public Collider RaycastCollider
		{
			get
			{
				return this._RaycastCollider;
			}
			set
			{
				this._RaycastCollider = value;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x00030988 File Offset: 0x0002EB88
		// (set) Token: 0x060009AB RID: 2475 RVA: 0x00030990 File Offset: 0x0002EB90
		public Collider TriggerCollider
		{
			get
			{
				return this._TriggerCollider;
			}
			set
			{
				this._TriggerCollider = value;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x00030999 File Offset: 0x0002EB99
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x000309A1 File Offset: 0x0002EBA1
		public Renderer HighlightRenderer
		{
			get
			{
				return this._HighlightRenderer;
			}
			set
			{
				this._HighlightRenderer = value;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x000309AA File Offset: 0x0002EBAA
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x000309B2 File Offset: 0x0002EBB2
		public Material HighlightMaterial
		{
			get
			{
				return this._HighlightMaterial;
			}
			set
			{
				this._HighlightMaterial = value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x000309BB File Offset: 0x0002EBBB
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x000309C3 File Offset: 0x0002EBC3
		public Color HighlightColor
		{
			get
			{
				return this._HighlightColor;
			}
			set
			{
				this._HighlightColor = value;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x000309CC File Offset: 0x0002EBCC
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x000309D4 File Offset: 0x0002EBD4
		public bool HasFocus
		{
			get
			{
				return this.mHasFocus;
			}
			set
			{
				this.mHasFocus = value;
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000309E0 File Offset: 0x0002EBE0
		protected virtual void Start()
		{
			if (this._TriggerCollider != null)
			{
				this.mTriggeredList = new List<Collider>();
				ColliderProxy colliderProxy = this._TriggerCollider.gameObject.GetComponent<ColliderProxy>();
				if (colliderProxy == null)
				{
					colliderProxy = this._TriggerCollider.gameObject.AddComponent<ColliderProxy>();
				}
				colliderProxy.Target = base.gameObject;
			}
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00030A3D File Offset: 0x0002EC3D
		protected virtual void LateUpdate()
		{
			if (!this.mHasFocus && this.mMaterialInstance != null)
			{
				this.StopFocus();
			}
			this.mHasFocus = false;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00030A64 File Offset: 0x0002EC64
		public virtual bool TestActivator(Transform rActivator)
		{
			if (this._TriggerCollider != null)
			{
				for (int i = this.mTriggeredList.Count - 1; i >= 0; i--)
				{
					if (this.mTriggeredList[i] == null)
					{
						this.mTriggeredList.RemoveAt(i);
					}
					else if (this.mTriggeredList[i].transform == rActivator)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x00030AD2 File Offset: 0x0002ECD2
		public virtual void StartFocus()
		{
			this.mHasFocus = true;
			if (this.mMaterialInstance == null)
			{
				this.AddMaterial(this._HighlightRenderer, this._HighlightMaterial);
			}
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00030AFB File Offset: 0x0002ECFB
		public virtual void StopFocus()
		{
			if (this.mMaterialInstance != null)
			{
				this.RemoveMaterial(this._HighlightRenderer, this.mMaterialInstance);
			}
			this.mHasFocus = false;
			this.mMaterialInstance = null;
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00030B2C File Offset: 0x0002ED2C
		public virtual void OnActivated(BasicInteraction rMotion)
		{
			this.mMotion = rMotion;
			if (this.ActivatedEvent != null)
			{
				Message message = Message.Allocate();
				message.ID = EnumMessageID.MSG_INTERACTION_ACTIVATE;
				message.Data = base.gameObject;
				this.ActivatedEvent.Invoke(message);
				Message.Release(message);
			}
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00030B77 File Offset: 0x0002ED77
		public virtual void OnActivatedCompleted()
		{
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00030B79 File Offset: 0x0002ED79
		protected virtual void OnTriggerEnter(Collider rCollider)
		{
			if (rCollider == null)
			{
				return;
			}
			if (!this.mTriggeredList.Contains(rCollider))
			{
				this.mTriggeredList.Add(rCollider);
			}
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00030B9F File Offset: 0x0002ED9F
		protected virtual void OnTriggerStay(Collider rCollider)
		{
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00030BA1 File Offset: 0x0002EDA1
		protected virtual void OnTriggerExit(Collider rCollider)
		{
			if (this.mTriggeredList.Contains(rCollider))
			{
				this.mTriggeredList.Remove(rCollider);
			}
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00030BC0 File Offset: 0x0002EDC0
		protected virtual void AddMaterial(Renderer rRenderer, Material rMaterial)
		{
			if (rRenderer == null)
			{
				return;
			}
			if (rMaterial == null)
			{
				return;
			}
			if (rRenderer != null)
			{
				for (int i = 0; i < rRenderer.materials.Length; i++)
				{
					if (rRenderer.materials[i] == this.mMaterialInstance)
					{
						return;
					}
				}
				Material[] array = new Material[rRenderer.materials.Length + 1];
				Array.Copy(rRenderer.materials, array, rRenderer.materials.Length);
				array[rRenderer.materials.Length] = rMaterial;
				rRenderer.materials = array;
				this.mMaterialInstance = rRenderer.materials[rRenderer.materials.Length - 1];
				for (int j = 0; j < InteractableCore.MATERIAL_COLORS.Length; j++)
				{
					if (this.mMaterialInstance.HasProperty(InteractableCore.MATERIAL_COLORS[j]))
					{
						this.mMaterialInstance.SetColor(InteractableCore.MATERIAL_COLORS[j], this.HighlightColor);
						return;
					}
				}
			}
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00030CA4 File Offset: 0x0002EEA4
		protected virtual void RemoveMaterial(Renderer rRenderer, Material rMaterialInstance)
		{
			if (rRenderer == null)
			{
				return;
			}
			if (rMaterialInstance == null)
			{
				return;
			}
			if (rRenderer != null)
			{
				bool flag = false;
				for (int i = 0; i < rRenderer.materials.Length; i++)
				{
					if (rRenderer.materials[i] == this.mMaterialInstance)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return;
				}
				int num = 0;
				Material[] array = new Material[rRenderer.materials.Length - 1];
				for (int j = 0; j < rRenderer.materials.Length; j++)
				{
					if (rRenderer.materials[j] != rMaterialInstance)
					{
						array[num] = rRenderer.materials[j];
						num++;
					}
				}
				rRenderer.materials = array;
				this.mMaterialInstance = null;
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00030DD9 File Offset: 0x0002EFD9
		GameObject ILifeCore.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004BE RID: 1214
		private static string[] MATERIAL_COLORS = new string[] { "_Color", "_MainColor", "_BorderColor", "_OutlineColor" };

		// Token: 0x040004BF RID: 1215
		public bool _IsEnabled = true;

		// Token: 0x040004C0 RID: 1216
		public string _Motion = "BasicInteraction";

		// Token: 0x040004C1 RID: 1217
		public int _Form;

		// Token: 0x040004C2 RID: 1218
		public bool _ForcePosition = true;

		// Token: 0x040004C3 RID: 1219
		public bool _ForceRotation = true;

		// Token: 0x040004C4 RID: 1220
		public Transform _TargetLocation;

		// Token: 0x040004C5 RID: 1221
		public float _TargetDistance = 2f;

		// Token: 0x040004C6 RID: 1222
		public bool _UseRaycast = true;

		// Token: 0x040004C7 RID: 1223
		public Collider _RaycastCollider;

		// Token: 0x040004C8 RID: 1224
		public Collider _TriggerCollider;

		// Token: 0x040004C9 RID: 1225
		public Renderer _HighlightRenderer;

		// Token: 0x040004CA RID: 1226
		public Material _HighlightMaterial;

		// Token: 0x040004CB RID: 1227
		public Color _HighlightColor = Color.white;

		// Token: 0x040004CC RID: 1228
		protected bool mHasFocus;

		// Token: 0x040004CD RID: 1229
		public MessageEvent ActivatedEvent;

		// Token: 0x040004CE RID: 1230
		protected Material mMaterialInstance;

		// Token: 0x040004CF RID: 1231
		protected MotionController mActivator;

		// Token: 0x040004D0 RID: 1232
		protected BasicInteraction mMotion;

		// Token: 0x040004D1 RID: 1233
		protected List<Collider> mTriggeredList;
	}
}
