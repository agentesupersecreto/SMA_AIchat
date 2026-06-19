using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes
{
	// Token: 0x020003FC RID: 1020
	public class GenericAgarranteObjeto : AgarranteObjeto
	{
		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x0600164B RID: 5707 RVA: 0x0005CC36 File Offset: 0x0005AE36
		public override bool agarrando
		{
			get
			{
				return this.m_agarrando;
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x0600164C RID: 5708 RVA: 0x0005CC3E File Offset: 0x0005AE3E
		public override bool agarrandoPhysicsAndAgarrandoUserControl
		{
			get
			{
				return this.m_puedeAgarrandoPhysicsAND.And(this.m_agarrando);
			}
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x0600164D RID: 5709 RVA: 0x0005CC51 File Offset: 0x0005AE51
		public override Vector3 currentAgarrandoPosicionCentral
		{
			get
			{
				return this.m_WorldPresionPointCentral;
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x0600164E RID: 5710 RVA: 0x0005CC51 File Offset: 0x0005AE51
		public override Vector3 currentAgarrandoPosicionA
		{
			get
			{
				return this.m_WorldPresionPointCentral;
			}
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x0600164F RID: 5711 RVA: 0x0005CC51 File Offset: 0x0005AE51
		public override Vector3 currentAgarrandoPosicionB
		{
			get
			{
				return this.m_WorldPresionPointCentral;
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06001650 RID: 5712 RVA: 0x0005CC51 File Offset: 0x0005AE51
		public override Vector3 currentAgarrandoPosicionC
		{
			get
			{
				return this.m_WorldPresionPointCentral;
			}
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x0005CC51 File Offset: 0x0005AE51
		public override Vector3 currentAgarrandoPosicionD
		{
			get
			{
				return this.m_WorldPresionPointCentral;
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001652 RID: 5714 RVA: 0x0005CC59 File Offset: 0x0005AE59
		public override Vector3 startAgarrandoPosicion
		{
			get
			{
				return this.m_startWorldPresionPoint;
			}
		}

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06001653 RID: 5715 RVA: 0x0005CC61 File Offset: 0x0005AE61
		public override ModificableDeBool puedeAgarrandoPhysicsAND
		{
			get
			{
				return this.m_puedeAgarrandoPhysicsAND;
			}
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0005CC69 File Offset: 0x0005AE69
		public override bool EstaAgarrando(bool incluirObjectoPhysico, bool incluirSosteniendo, float? userInputToForze)
		{
			return (incluirSosteniendo && base.sosteniendo) || this.m_agarrando;
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x0005CC80 File Offset: 0x0005AE80
		public void ComenzarAgarrar(Vector3 startWorldPosition)
		{
			this.m_agarrando = true;
			this.m_WorldPresionPointCentral = startWorldPosition;
			this.m_startWorldPresionPoint = startWorldPosition;
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x0005CCA4 File Offset: 0x0005AEA4
		public void ActualizarAgarrarPosition(Vector3 worldPosition)
		{
			if (!this.m_agarrando)
			{
				return;
			}
			this.m_WorldPresionPointCentral = worldPosition;
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x0005CCB6 File Offset: 0x0005AEB6
		public void FinalizarAgarrado()
		{
			this.m_agarrando = false;
		}

		// Token: 0x040011AB RID: 4523
		private ModificableDeBool m_puedeAgarrandoPhysicsAND = new ModificableDeBool(true);

		// Token: 0x040011AC RID: 4524
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_startWorldPresionPoint;

		// Token: 0x040011AD RID: 4525
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_WorldPresionPointCentral;

		// Token: 0x040011AE RID: 4526
		[ReadOnlyUI]
		[SerializeField]
		private bool m_agarrando;
	}
}
