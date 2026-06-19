using System;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003EC RID: 1004
	public class EstimuloPorManipulacionDeBone : InteracionEstimulanteBasica, IEstimuloPorMovimientoDeBone, IInteracionEstimulanteBasica
	{
		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x0005BE0B File Offset: 0x0005A00B
		// (set) Token: 0x060015F3 RID: 5619 RVA: 0x0005BE18 File Offset: 0x0005A018
		public float velocidadRelativaEmulada
		{
			get
			{
				return this.m_DataManipulacion.velocidadRelativaEmulada;
			}
			set
			{
				this.m_DataManipulacion.velocidadRelativaEmulada = value;
			}
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x0005BE26 File Offset: 0x0005A026
		public void AddData(ref ManipulacionDeBoneData data)
		{
			base.AddParteEstimulada(data.manipulando);
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x0005BE38 File Offset: 0x0005A038
		public override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone = resultado as EstimuloPorManipulacionDeBone;
			if (estimuloPorManipulacionDeBone == null)
			{
				return;
			}
			estimuloPorManipulacionDeBone.m_DataManipulacion.velocidadRelativaEmulada = this.m_DataManipulacion.velocidadRelativaEmulada;
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0005BE6E File Offset: 0x0005A06E
		public override void Clear()
		{
			base.Clear();
			this.m_DataManipulacion.velocidadRelativaEmulada = 0f;
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0005BE86 File Offset: 0x0005A086
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			return other is EstimuloPorManipulacionDeBone;
		}

		// Token: 0x04001178 RID: 4472
		[SerializeField]
		private EstimuloPorManipulacionDeBone.DataManipulacion m_DataManipulacion;

		// Token: 0x020003ED RID: 1005
		[Serializable]
		private struct DataManipulacion
		{
			// Token: 0x04001179 RID: 4473
			public float velocidadRelativaEmulada;
		}
	}
}
