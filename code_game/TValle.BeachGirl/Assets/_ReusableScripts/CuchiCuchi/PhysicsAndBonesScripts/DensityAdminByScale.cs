using System;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F6 RID: 246
	public class DensityAdminByScale : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x14000053 RID: 83
		// (add) Token: 0x06000A69 RID: 2665 RVA: 0x00021CEC File Offset: 0x0001FEEC
		// (remove) Token: 0x06000A6A RID: 2666 RVA: 0x00021D24 File Offset: 0x0001FF24
		public event DensityAdminByScale.VolumenChangedHandler LocalVolumenChanged;

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x06000A6B RID: 2667 RVA: 0x00021D5C File Offset: 0x0001FF5C
		// (remove) Token: 0x06000A6C RID: 2668 RVA: 0x00021D94 File Offset: 0x0001FF94
		public event DensityAdminByScale.VolumenChangedHandler NonStrechedVolumenChanged;

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x00021DC9 File Offset: 0x0001FFC9
		// (set) Token: 0x06000A6E RID: 2670 RVA: 0x00021DD1 File Offset: 0x0001FFD1
		public GlobalUpdater.UpdateType updateEvent
		{
			get
			{
				return this.m_UpdateEvent;
			}
			set
			{
				this.m_UpdateEvent = value;
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00021DDA File Offset: 0x0001FFDA
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x00021DE2 File Offset: 0x0001FFE2
		public float initialMass
		{
			get
			{
				return this.m_initialMass;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x00021DEA File Offset: 0x0001FFEA
		public float currentNonStrechedMass
		{
			get
			{
				return this.m_currentNonStrechedMass;
			}
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00021DF4 File Offset: 0x0001FFF4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			float num;
			float num2;
			this.m_initialScale = this.GetCurrentScale(out num, out num2);
			if (Mathf.Abs(num - 1f) > 0.001f)
			{
				throw new InvalidOperationException();
			}
			this.m_initialNonStrechedScale = (this.m_lastNonStrechedScale = num);
			this.m_lastLocalScale = num2;
			if (this.userCalculedInitialVolumen <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (!this.scaler.IsChildOf(this.nonStrechedParent))
			{
				throw new InvalidOperationException();
			}
			this.combinedCurrentVolumen = (this.m_initialVolumen = this.userCalculedInitialVolumen);
			this.m_currentNonStrechedMass = (this.m_initialMass = (this.rigid.mass = MaterialDensityMap.MassOf(this.material, this.combinedCurrentVolumen)));
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00021EB6 File Offset: 0x000200B6
		public float CalculeCurrentVolumen()
		{
			return this.GetCurrentVolumen();
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00021EC0 File Offset: 0x000200C0
		private float GetCurrentVolumen()
		{
			float num;
			float num2;
			return this.GetCurrentScale(out num, out num2) * this.m_initialVolumen / this.m_initialScale;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00021EE8 File Offset: 0x000200E8
		private float GetCurrentScale()
		{
			float num;
			float num2;
			return this.GetCurrentScale(out num, out num2);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00021F00 File Offset: 0x00020100
		private float GetCurrentScale(out float nonStrechedScale, out float localScale)
		{
			Vector3 localScale2 = this.scaler.localScale;
			Vector3 lossyScale = this.nonStrechedParent.lossyScale;
			localScale = localScale2.x * localScale2.y * localScale2.z;
			nonStrechedScale = lossyScale.x * lossyScale.y * lossyScale.z;
			return nonStrechedScale * localScale;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x00021F58 File Offset: 0x00020158
		private static float GetScale(bool islocal, Transform target)
		{
			Vector3 vector;
			if (islocal)
			{
				vector = target.localScale;
			}
			else
			{
				vector = target.lossyScale;
			}
			return vector.x * vector.y * vector.z;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00021F8C File Offset: 0x0002018C
		public override void OnUpdateEvent1()
		{
			Vector3 lossyScale = this.scaler.lossyScale;
			float num;
			float num2;
			this.GetCurrentScale(out num, out num2);
			bool flag = false;
			if (Mathf.Abs(num2 - this.m_lastLocalScale) > 0.001f)
			{
				this.m_lastLocalScale = num2;
				flag = true;
			}
			if (Mathf.Abs(num - this.m_lastNonStrechedScale) > 0.001f)
			{
				this.m_lastNonStrechedScale = num;
				flag = true;
				float num3 = num / this.m_initialNonStrechedScale;
				this.m_currentNonStrechedMass = this.m_initialMass * num3;
			}
			if (flag)
			{
				this.combinedCurrentVolumen = this.GetCurrentVolumen();
				this.rigid.mass = MaterialDensityMap.MassOf(this.material, this.combinedCurrentVolumen);
			}
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00022040 File Offset: 0x00020240
		protected void OnLocalVolumenChanged(float initialVolumne, float lastVolumen, float newVolumen)
		{
			DensityAdminByScale.VolumenChangedHandler localVolumenChanged = this.LocalVolumenChanged;
			if (localVolumenChanged != null)
			{
				localVolumenChanged(this, initialVolumne, lastVolumen, newVolumen);
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00022064 File Offset: 0x00020264
		protected void OnNonStrechedVolumenChanged(float initialVolumne, float lastVolumen, float newVolumen)
		{
			DensityAdminByScale.VolumenChangedHandler nonStrechedVolumenChanged = this.NonStrechedVolumenChanged;
			if (nonStrechedVolumenChanged != null)
			{
				nonStrechedVolumenChanged(this, initialVolumne, lastVolumen, newVolumen);
			}
		}

		// Token: 0x04000584 RID: 1412
		private const float margen = 0.001f;

		// Token: 0x04000587 RID: 1415
		public Transform scaler;

		// Token: 0x04000588 RID: 1416
		public Rigidbody rigid;

		// Token: 0x04000589 RID: 1417
		public Transform nonStrechedParent;

		// Token: 0x0400058A RID: 1418
		public MaterialDensityMap.Material material;

		// Token: 0x0400058B RID: 1419
		[Tooltip("se multiplica por la escala del bone para saber el volumen actual")]
		public float userCalculedInitialVolumen = -1f;

		// Token: 0x0400058C RID: 1420
		[ReadOnlyUI]
		public float combinedCurrentVolumen;

		// Token: 0x0400058D RID: 1421
		[SerializeField]
		[ReadOnlyUI]
		private float m_initialScale;

		// Token: 0x0400058E RID: 1422
		[SerializeField]
		[ReadOnlyUI]
		private float m_initialMass;

		// Token: 0x0400058F RID: 1423
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentNonStrechedMass;

		// Token: 0x04000590 RID: 1424
		private float m_initialVolumen;

		// Token: 0x04000591 RID: 1425
		private float m_lastLocalScale;

		// Token: 0x04000592 RID: 1426
		private float m_lastNonStrechedScale;

		// Token: 0x04000593 RID: 1427
		private float m_initialNonStrechedScale;

		// Token: 0x04000594 RID: 1428
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.fixedUpdate1;

		// Token: 0x020001CF RID: 463
		// (Invoke) Token: 0x06000F7A RID: 3962
		public delegate void VolumenChangedHandler(DensityAdminByScale sender, float initialVolumne, float lastVolumen, float newVolumen);
	}
}
