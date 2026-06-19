using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E9 RID: 1001
	public class EstimuloPorCambiarPose : InteracionEstimulanteBasica, IEstimuloPorCambiarPose, IInteracionEstimulanteBasica
	{
		// Token: 0x060015E1 RID: 5601 RVA: 0x0005BB9C File Offset: 0x00059D9C
		public void AddPose(ref CambioDePoseData data)
		{
			try
			{
				int poseID = data.poseID;
				if (poseID == 0)
				{
					Debug.LogWarning("fallo adicion de pose con id " + poseID.ToString(), base.estimulado);
					Debug.LogException(new InvalidOperationException());
				}
				else
				{
					for (int i = 0; i < data.referenciaDeExponiendoPartes.Count; i++)
					{
						base.AddParteEstimulada(data.referenciaDeExponiendoPartes[i]);
					}
					int num = (int)base.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor);
					if (data.referenciaDeExponiendoPartesSet.Contains(num))
					{
						this.m_DataCambiarPose.poseIDPrincipal = poseID;
					}
				}
			}
			finally
			{
				if (this.m_DataCambiarPose.poseIDPrincipal == 0)
				{
					throw new InvalidOperationException();
				}
			}
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x00003B39 File Offset: 0x00001D39
		[Obsolete("", true)]
		public void ActualizarPartePrincipal()
		{
		}

		// Token: 0x060015E3 RID: 5603 RVA: 0x0005BC4C File Offset: 0x00059E4C
		public override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			EstimuloPorCambiarPose estimuloPorCambiarPose = resultado as EstimuloPorCambiarPose;
			if (estimuloPorCambiarPose == null)
			{
				return;
			}
			estimuloPorCambiarPose.m_DataCambiarPose.orden = this.m_DataCambiarPose.orden;
			if (!convinarPartesEstimuladas)
			{
				estimuloPorCambiarPose.m_DataCambiarPose.posesID.Clear();
			}
			estimuloPorCambiarPose.m_DataCambiarPose.posesID.AddRange(this.m_DataCambiarPose.posesID);
			estimuloPorCambiarPose.m_DataCambiarPose.poseIDPrincipal = this.m_DataCambiarPose.poseIDPrincipal;
			estimuloPorCambiarPose.m_DataCambiarPose.cambioManualmente = this.m_DataCambiarPose.cambioManualmente;
			estimuloPorCambiarPose.m_DataCambiarPose.velocidadRelativaEmulada = this.m_DataCambiarPose.velocidadRelativaEmulada;
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x0005BCF4 File Offset: 0x00059EF4
		public override void Clear()
		{
			base.Clear();
			this.m_DataCambiarPose.posesID.Clear();
			this.m_DataCambiarPose.poseIDPrincipal = 0;
			this.m_DataCambiarPose.orden = EstimuloPorCambiarPose.Estado.None;
			this.m_DataCambiarPose.cambioManualmente = false;
			this.m_DataCambiarPose.velocidadRelativaEmulada = 0f;
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0005BD4C File Offset: 0x00059F4C
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			EstimuloPorCambiarPose estimuloPorCambiarPose = other as EstimuloPorCambiarPose;
			return estimuloPorCambiarPose != null && estimuloPorCambiarPose.m_DataCambiarPose.orden == this.m_DataCambiarPose.orden;
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x060015E6 RID: 5606 RVA: 0x0005BD7D File Offset: 0x00059F7D
		// (set) Token: 0x060015E7 RID: 5607 RVA: 0x0005BD8A File Offset: 0x00059F8A
		public bool cambioManualmente
		{
			get
			{
				return this.m_DataCambiarPose.cambioManualmente;
			}
			set
			{
				this.m_DataCambiarPose.cambioManualmente = value;
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x0005BD98 File Offset: 0x00059F98
		// (set) Token: 0x060015E9 RID: 5609 RVA: 0x0005BDA5 File Offset: 0x00059FA5
		public float velocidadRelativaEmulada
		{
			get
			{
				return this.m_DataCambiarPose.velocidadRelativaEmulada;
			}
			set
			{
				this.m_DataCambiarPose.velocidadRelativaEmulada = value;
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x0005BDB3 File Offset: 0x00059FB3
		public int poseIDPrincipal
		{
			get
			{
				return this.m_DataCambiarPose.poseIDPrincipal;
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x060015EB RID: 5611 RVA: 0x0005BDC0 File Offset: 0x00059FC0
		// (set) Token: 0x060015EC RID: 5612 RVA: 0x0005BDCD File Offset: 0x00059FCD
		public EstimuloPorCambiarPose.Estado orden
		{
			get
			{
				return this.m_DataCambiarPose.orden;
			}
			set
			{
				this.m_DataCambiarPose.orden = value;
			}
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x060015ED RID: 5613 RVA: 0x0005BDDB File Offset: 0x00059FDB
		public IReadOnlyList<int> posesID
		{
			get
			{
				return this.m_DataCambiarPose.posesID;
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x060015EE RID: 5614 RVA: 0x00004252 File Offset: 0x00002452
		// (set) Token: 0x060015EF RID: 5615 RVA: 0x00005A42 File Offset: 0x00003C42
		public TipoDeEstimuloCambiarPose tipoDeEstimuloCambiarPose
		{
			get
			{
				return TipoDeEstimuloCambiarPose.None;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x0400116E RID: 4462
		[SerializeField]
		private EstimuloPorCambiarPose.DataCambiarPose m_DataCambiarPose;

		// Token: 0x020003EA RID: 1002
		[Serializable]
		private struct DataCambiarPose
		{
			// Token: 0x1700055C RID: 1372
			// (get) Token: 0x060015F1 RID: 5617 RVA: 0x0005BDF0 File Offset: 0x00059FF0
			public List<int> posesID
			{
				get
				{
					if (this.m_posesID == null)
					{
						this.m_posesID = new List<int>();
					}
					return this.m_posesID;
				}
			}

			// Token: 0x0400116F RID: 4463
			public int poseIDPrincipal;

			// Token: 0x04001170 RID: 4464
			[SerializeField]
			private List<int> m_posesID;

			// Token: 0x04001171 RID: 4465
			public EstimuloPorCambiarPose.Estado orden;

			// Token: 0x04001172 RID: 4466
			public bool cambioManualmente;

			// Token: 0x04001173 RID: 4467
			public float velocidadRelativaEmulada;
		}

		// Token: 0x020003EB RID: 1003
		public enum Estado
		{
			// Token: 0x04001175 RID: 4469
			None,
			// Token: 0x04001176 RID: 4470
			ejecutada,
			// Token: 0x04001177 RID: 4471
			detenida
		}
	}
}
