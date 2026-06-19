using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x02000111 RID: 273
	public class VagLipMiddleBackPointCreator : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x00028E49 File Offset: 0x00027049
		public VagLabiaPoint vagLabiaPoint
		{
			get
			{
				return this.m_VagLabiaPoint;
			}
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00028E54 File Offset: 0x00027054
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Transform transform = this.CrearTransParaPoint();
			this.vagLabiaPointConfiguracion = this.vagLabiaPointConfiguracion.Clone();
			this.vagLabiaPointConfiguracion.useMinDistance = false;
			VagLabiaSide.LoadPoint(ref this.m_VagLabiaPoint, this.vagLabia, this.vagLabiaPointConfiguracion, base.transform, transform, Side.B, ChainPointStretcherJoint.ConfigTipo.vagLipsBack, this.colliderConfig, false, float.MaxValue);
			this.m_VagLabiaPoint.gameObject.layer = base.gameObject.layer;
			this.m_VagLabiaPoint.densityMod = this.configuracion.densityMod;
			this.m_VagLabiaPoint.driversMod = this.configuracion.driversMod;
			this.m_VagLabiaPoint.ManualStart();
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00028F0C File Offset: 0x0002710C
		private Transform CrearTransParaPoint()
		{
			Vector3 vector = base.transform.TransformDirection(this.configuracion.localDirectionToCreate.normalized);
			Vector3 vector2 = base.transform.position + vector * this.configuracion.distance;
			Transform transform = new GameObject(base.name + "_Point").transform;
			transform.parent = base.transform.parent;
			transform.position = vector2;
			transform.rotation = base.transform.rotation;
			return transform;
		}

		// Token: 0x0400068B RID: 1675
		public VagLabia vagLabia;

		// Token: 0x0400068C RID: 1676
		public VagLipMiddleBackPointCreator.Configuracion configuracion = new VagLipMiddleBackPointCreator.Configuracion();

		// Token: 0x0400068D RID: 1677
		public VagLabiaPointColliders.Configuracion colliderConfig = new VagLabiaPointColliders.Configuracion();

		// Token: 0x0400068E RID: 1678
		public VagLabiaPoint.VagLabiaPointConfiguracion vagLabiaPointConfiguracion = new VagLabiaPoint.VagLabiaPointConfiguracion();

		// Token: 0x0400068F RID: 1679
		private VagLabiaPoint m_VagLabiaPoint;

		// Token: 0x020001F2 RID: 498
		[Serializable]
		public class Configuracion
		{
			// Token: 0x06000FC3 RID: 4035 RVA: 0x000351C8 File Offset: 0x000333C8
			public Configuracion()
			{
			}

			// Token: 0x06000FC4 RID: 4036 RVA: 0x00035250 File Offset: 0x00033450
			public Configuracion(float densityMod, float driversMod)
			{
				this.densityMod = densityMod;
				this.driversMod = driversMod;
			}

			// Token: 0x04000AC4 RID: 2756
			public Vector3 localDirectionToCreate = new Vector3(0f, 1f, -0.666f);

			// Token: 0x04000AC5 RID: 2757
			public float distance = 0.0125f;

			// Token: 0x04000AC6 RID: 2758
			public Vector3 localDirectionToBeUp = Vector3.forward;

			// Token: 0x04000AC7 RID: 2759
			public float densityMod = 2f;

			// Token: 0x04000AC8 RID: 2760
			public float driversMod = 2f;

			// Token: 0x04000AC9 RID: 2761
			public float radiusModInitialMod = 0.333f;

			// Token: 0x04000ACA RID: 2762
			public float radiusModPenMod = 0.333f;

			// Token: 0x04000ACB RID: 2763
			public float initiaOffsetMod = 1f;

			// Token: 0x04000ACC RID: 2764
			public float penOffsetMod = 2f;
		}
	}
}
