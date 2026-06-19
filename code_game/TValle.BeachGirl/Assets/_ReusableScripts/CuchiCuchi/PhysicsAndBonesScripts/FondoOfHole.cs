using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000EF RID: 239
	[Obsolete("", true)]
	public class FondoOfHole : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x000204C0 File Offset: 0x0001E6C0
		public void Arrancar(Circular8BoneChain hole, float extraSize = 0f)
		{
			this.m_hole = hole;
			this.m_extraSize = extraSize;
			float aperturaLocalInternals = this.m_hole.estadoDePuntos.iniciales.aperturaLocalInternals;
			this.m_Trigger = base.gameObject.AddComponent<SphereCollider>();
			this.m_Trigger.isTrigger = true;
			this.m_Trigger.radius = aperturaLocalInternals * 0.5f;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00020520 File Offset: 0x0001E720
		public void CheckPartesEnFondo()
		{
			int num = 0;
			try
			{
				float maxValue = this.m_hole.estadoDePuntos.globalActual.maxValue;
				num = Physics.OverlapBoxNonAlloc(base.transform.position, new Vector3((maxValue + this.m_extraSize) * 0.5f, (maxValue + this.m_extraSize) * 0.5f, 0.0025f), this.m_resultTemp, base.transform.rotation, this.configuracion.penisLayer, QueryTriggerInteraction.Ignore);
				ExtendedMonoBehaviour.FiltrarOverlapEnRigidbody<PenisPart>(this.m_resultTemp, this.m_filtrados, new int?(num));
			}
			finally
			{
				Array.Clear(this.m_resultTemp, 0, num);
				this.m_filtrados.Clear();
			}
		}

		// Token: 0x04000555 RID: 1365
		public const float anchoFondo = 0.005f;

		// Token: 0x04000556 RID: 1366
		public FondoOfHole.Configuracion configuracion = new FondoOfHole.Configuracion();

		// Token: 0x04000557 RID: 1367
		[ReadOnlyUI]
		[SerializeField]
		private Circular8BoneChain m_hole;

		// Token: 0x04000558 RID: 1368
		[ReadOnlyUI]
		[SerializeField]
		private float m_extraSize;

		// Token: 0x04000559 RID: 1369
		private Collider[] m_resultTemp = new Collider[100];

		// Token: 0x0400055A RID: 1370
		private HashSet<PenisPart> m_filtrados = new HashSet<PenisPart>();

		// Token: 0x0400055B RID: 1371
		private SphereCollider m_Trigger;

		// Token: 0x020001C6 RID: 454
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000A20 RID: 2592
			public LayerMask penisLayer = -1;

			// Token: 0x04000A21 RID: 2593
			[Obsolete]
			[NonSerialized]
			public PhysicMaterial material;

			// Token: 0x04000A22 RID: 2594
			[Obsolete]
			[NonSerialized]
			public float maxDepenetrationVelocity = 1E+32f;
		}
	}
}
