using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos
{
	// Token: 0x02000389 RID: 905
	[Serializable]
	public class EstimuloPorDesvestir : InteracionEstimulanteBasica
	{
		// Token: 0x060013C0 RID: 5056 RVA: 0x00055ECF File Offset: 0x000540CF
		public void AddPieza(string ID, RopaCubre piezaCubirendo, Sexo sexo)
		{
			this.addPieza(ID, piezaCubirendo, sexo);
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x00055EDC File Offset: 0x000540DC
		private void addPieza(string ID, RopaCubre piezaCubirendo, Sexo sexo)
		{
			try
			{
				if (piezaCubirendo == RopaCubre.None)
				{
					IRopaParaAvatar ropaParaAvatar = this.ObtenerMapaDeRopa();
					if (ropaParaAvatar == null)
					{
						Debug.LogWarning("fallo adicion de pieza con id " + ID, base.estimulado);
						Debug.LogException(new InvalidOperationException());
						return;
					}
					MapaDeRopa.RopaData ropaData = ropaParaAvatar.ObtenerData(ID);
					if (ropaData == null)
					{
						Debug.LogError("pieza id " + ID + " no tiene data", base.estimulado);
						return;
					}
					if (piezaCubirendo != RopaCubre.None)
					{
						piezaCubirendo = ropaData.cubreFlag.ObtenerLaDeMenorPrioridad(sexo);
					}
				}
				if (string.IsNullOrWhiteSpace(ID))
				{
					Debug.LogWarning("fallo adicion de pieza con id " + ID, base.estimulado);
					Debug.LogException(new InvalidOperationException());
				}
				else
				{
					if (piezaCubirendo != RopaCubre.None)
					{
						piezaCubirendo.FlagsToCollectionDeParteDelCuerpoHumano(this.m_temp);
					}
					if (this.m_temp.Count == 0)
					{
						this.m_temp.Add(0);
					}
					for (int i = 0; i < this.m_temp.Count; i++)
					{
						base.AddParteEstimulada((ParteDelCuerpoHumano)this.m_temp[i]);
					}
					int num = (int)base.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor);
					if (this.m_temp.Contains(num))
					{
						this.m_DataDesvestir.piezasIDPrincipal = ID;
						this.m_DataDesvestir.PiezasID.Add(ID);
					}
				}
			}
			finally
			{
				this.m_temp.Clear();
				if (string.IsNullOrWhiteSpace(this.m_DataDesvestir.piezasIDPrincipal))
				{
					throw new InvalidOperationException();
				}
			}
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x0005604C File Offset: 0x0005424C
		[Obsolete("usar AddPiezas", true)]
		public void AddPartes(IList<ParteDelCuerpoHumano> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				base.partAdder(partes[i]);
			}
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x0005607C File Offset: 0x0005427C
		[Obsolete("usar AddPiezas", true)]
		public void AddParte(ParteDelCuerpoHumano parte)
		{
			base.partAdder(parte);
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00003B39 File Offset: 0x00001D39
		[Obsolete("", true)]
		public void ActualizarPartePrincipal()
		{
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x0005608C File Offset: 0x0005428C
		public override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			EstimuloPorDesvestir estimuloPorDesvestir = resultado as EstimuloPorDesvestir;
			if (estimuloPorDesvestir == null)
			{
				return;
			}
			if (!convinarPartesEstimuladas)
			{
				estimuloPorDesvestir.m_DataDesvestir.PiezasID.Clear();
			}
			estimuloPorDesvestir.m_DataDesvestir.PiezasID.AddRange(this.m_DataDesvestir.PiezasID);
			estimuloPorDesvestir.m_DataDesvestir.piezasIDPrincipal = this.m_DataDesvestir.piezasIDPrincipal;
			estimuloPorDesvestir.m_DataDesvestir.parcial = this.m_DataDesvestir.parcial;
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x00056106 File Offset: 0x00054306
		public override void Clear()
		{
			base.Clear();
			this.m_DataDesvestir.PiezasID.Clear();
			this.m_DataDesvestir.piezasIDPrincipal = string.Empty;
			this.m_DataDesvestir.parcial = false;
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0005613A File Offset: 0x0005433A
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			return other is EstimuloPorDesvestir;
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x00056147 File Offset: 0x00054347
		public IRopaParaAvatar ObtenerMapaDeRopa()
		{
			RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			if (instance == null)
			{
				throw new ArgumentNullException("instance", "instance de RopaParaAvatar singleton es null reference.");
			}
			return instance;
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x00056164 File Offset: 0x00054364
		[Obsolete("re hacer")]
		public void ObtenerData(List<MapaDeRopa.RopaData> result)
		{
			for (int i = 0; i < this.m_DataDesvestir.PiezasID.Count; i++)
			{
				IRopaParaAvatar ropaParaAvatar = this.ObtenerMapaDeRopa();
				result.Add((ropaParaAvatar != null) ? ropaParaAvatar.ObtenerData(this.m_DataDesvestir.PiezasID[i]) : null);
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060013CA RID: 5066 RVA: 0x000561B5 File Offset: 0x000543B5
		public string PiezasIDPrincipal
		{
			get
			{
				return this.m_DataDesvestir.piezasIDPrincipal;
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x000561C2 File Offset: 0x000543C2
		public IReadOnlyList<string> PiezasID
		{
			get
			{
				return this.m_DataDesvestir.PiezasID;
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060013CC RID: 5068 RVA: 0x000561CF File Offset: 0x000543CF
		// (set) Token: 0x060013CD RID: 5069 RVA: 0x000561DC File Offset: 0x000543DC
		public bool parcial
		{
			get
			{
				return this.m_DataDesvestir.parcial;
			}
			set
			{
				this.m_DataDesvestir.parcial = value;
			}
		}

		// Token: 0x04001070 RID: 4208
		[SerializeField]
		private EstimuloPorDesvestir.DataDesvestir m_DataDesvestir;

		// Token: 0x04001071 RID: 4209
		private HashSetList<int> m_temp = new HashSetList<int>();

		// Token: 0x04001072 RID: 4210
		[Obsolete("Se unificaron los mapas", true)]
		public RopaTipoDeSingleton tipoDeMapaDeRopa;

		// Token: 0x0200038A RID: 906
		[Serializable]
		private struct DataDesvestir
		{
			// Token: 0x170004F6 RID: 1270
			// (get) Token: 0x060013CF RID: 5071 RVA: 0x000561FD File Offset: 0x000543FD
			public List<string> PiezasID
			{
				get
				{
					if (this.m_PiezasID == null)
					{
						this.m_PiezasID = new List<string>();
					}
					return this.m_PiezasID;
				}
			}

			// Token: 0x04001073 RID: 4211
			public string piezasIDPrincipal;

			// Token: 0x04001074 RID: 4212
			public bool parcial;

			// Token: 0x04001075 RID: 4213
			[SerializeField]
			private List<string> m_PiezasID;
		}
	}
}
