using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000077 RID: 119
	public abstract class ModificadorDeContactosUserBase<TData> : AplicableCustomMonobehaviour where TData : struct
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x000082BF File Offset: 0x000064BF
		public IReadOnlyList<Collider> colliders
		{
			get
			{
				return this.m_Colliders;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060002A3 RID: 675
		public abstract TData data { get; }

		// Token: 0x060002A4 RID: 676
		public abstract void UpdateData();

		// Token: 0x060002A5 RID: 677
		protected abstract void Subcribe();

		// Token: 0x060002A6 RID: 678
		protected abstract void UnSubcribe();

		// Token: 0x060002A7 RID: 679 RVA: 0x000082C7 File Offset: 0x000064C7
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x000082DB File Offset: 0x000064DB
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.Subcribe();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000082E9 File Offset: 0x000064E9
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Subcribe();
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000082FF File Offset: 0x000064FF
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (base.isStared)
			{
				this.UnSubcribe();
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00008318 File Offset: 0x00006518
		public void InitializedIgnoring(IReadOnlyList<Collider> IgnoreColliders = null)
		{
			if (base.isInitiated)
			{
				throw new InvalidOperationException();
			}
			this.m_Colliders = new List<Collider>();
			base.GetComponentsInChildren<Collider>(this.m_Colliders);
			this.m_Colliders = this.m_Colliders.Where((Collider col) => !col.isTrigger).ToList<Collider>();
			if (IgnoreColliders != null && IgnoreColliders.Count > 0)
			{
				this.m_Colliders = this.m_Colliders.Except(IgnoreColliders).ToList<Collider>();
			}
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000083AE File Offset: 0x000065AE
		public void InitializedIncluding(IEnumerable<Collider> including)
		{
			if (base.isInitiated)
			{
				throw new InvalidOperationException();
			}
			if (including == null)
			{
				throw new ArgumentNullException("including", "including null reference.");
			}
			this.m_Colliders = new List<Collider>(including);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000083EC File Offset: 0x000065EC
		public void InitializedIncluding(Collider including)
		{
			if (base.isInitiated)
			{
				throw new InvalidOperationException();
			}
			if (including == null)
			{
				throw new ArgumentNullException("including", "including null reference.");
			}
			this.m_Colliders = new List<Collider> { including };
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000843E File Offset: 0x0000663E
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (!base.isInitiated)
			{
				this.InitializedIgnoring(null);
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00008455 File Offset: 0x00006655
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Init",
				editorTimeVisible = false
			};
		}

		// Token: 0x040001AA RID: 426
		[SerializeField]
		private List<Collider> m_Colliders;
	}
}
