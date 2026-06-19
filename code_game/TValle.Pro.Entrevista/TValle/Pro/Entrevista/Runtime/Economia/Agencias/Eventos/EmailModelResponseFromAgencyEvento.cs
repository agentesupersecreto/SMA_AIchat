using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos
{
	// Token: 0x020000D1 RID: 209
	[Serializable]
	public sealed class EmailModelResponseFromAgencyEvento : EmailFromAgenciesRecivedEvento
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060007BC RID: 1980 RVA: 0x0002C480 File Offset: 0x0002A680
		public AgencyEarningsArg agencyEarningsArg
		{
			get
			{
				return this.incomeEfectoArg as AgencyEarningsArg;
			}
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0002C490 File Offset: 0x0002A690
		protected override void NoVolatilStared()
		{
			base.NoVolatilStared();
			if (!this.m_wasStarted)
			{
				Agencia agencia = Singleton<OtrasAgencias>.instance.ObtenerAgencia(this.agencyID);
				if (!string.IsNullOrWhiteSpace(this.incomeEfectoID) && !string.IsNullOrWhiteSpace(this.incomeEfectoArgID) && this.incomeEfectoArg != null)
				{
					Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(this.incomeEfectoID);
					if (efecto == null)
					{
						Debug.LogError("No se encontro efecto con id: " + this.incomeEfectoID, base.owner);
					}
					else
					{
						efecto.Apply(base.owner, this.incomeEfectoArg, 1, this, agencia);
					}
				}
				if (!string.IsNullOrWhiteSpace(this.incomeChangeWithAgencyBuffID))
				{
					BuffMap map = Singleton<BuffManager>.instance.GetMap(this.incomeChangeWithAgencyBuffID);
					if (map == null)
					{
						Debug.LogError("No se encontro buff con id: " + this.incomeChangeWithAgencyBuffID, base.owner);
					}
					else
					{
						Component owner = base.owner;
						BuffDeCharacter buffDeCharacter = ((owner != null) ? owner.GetComponentEnRoot(false) : null);
						if (buffDeCharacter == null)
						{
							Debug.LogError("No se encontro buff de character", base.owner);
						}
						BuffEvento eventoBuff = map.GetEventoBuff(this.StartDateTime, this.agencyID, new AgencyIncomeChangeArg
						{
							agenciaID = this.agencyID
						}, null);
						buffDeCharacter.eventos.AddOrStackUp(eventoBuff, true, true);
					}
				}
			}
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias/" + this.agencyID, true);
			for (int i = 0; i < this.bonusDesblokeados.Count; i++)
			{
				jsonMemoryNode.FindChildNotNull<IJsonMemoryNode>(this.bonusDesblokeados[i]).AddData("EsUnlocked", true, true);
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0002C624 File Offset: 0x0002A824
		protected override void GuardarEventoAMemoria(IJsonMemoryNode eventoMem)
		{
			base.GuardarEventoAMemoria(eventoMem);
			eventoMem.AddData("acepted", this.acepted, true);
			if (!string.IsNullOrWhiteSpace(this.incomeEfectoID))
			{
				eventoMem.AddData("incomeEfectoID", this.incomeEfectoID, true);
			}
			if (!string.IsNullOrWhiteSpace(this.incomeEfectoArgID))
			{
				eventoMem.AddData("incomeEfectoArgID", this.incomeEfectoArgID, true);
			}
			if (this.incomeEfectoArg != null)
			{
				eventoMem.AddDataObject("incomeEfectoArg", this.incomeEfectoArg, true);
			}
			eventoMem.AddData("incomeChangeWithAgencyBuffID", this.incomeChangeWithAgencyBuffID, true);
			eventoMem.AddData("bonusDesblokeados", this.bonusDesblokeados, true);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0002C6C8 File Offset: 0x0002A8C8
		protected override void CargarEventoDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			base.CargarEventoDesdeMemoria(eventoMem, eventoID);
			this.acepted = eventoMem.FindDataBool("acepted", false);
			this.incomeEfectoID = eventoMem.FindData("incomeEfectoID");
			this.incomeEfectoArgID = eventoMem.FindData("incomeEfectoArgID");
			if (!string.IsNullOrWhiteSpace(this.incomeEfectoArgID))
			{
				Type argumentoType = Singleton<ArgumentosDeEfectosManager>.instance.GetArgumentoType(this.incomeEfectoArgID);
				if (argumentoType != null && !eventoMem.TryFindDataObject("incomeEfectoArg", argumentoType, out this.incomeEfectoArg, null))
				{
					Debug.LogError("No se pudo cargar arguemnto de efecto de cambio de dinero", base.owner);
				}
			}
			this.incomeChangeWithAgencyBuffID = eventoMem.FindData("incomeChangeWithAgencyBuffID");
			if (!eventoMem.TryFindDataArrayEmpty("bonusDesblokeados", out this.bonusDesblokeados))
			{
				Debug.LogError("No se pudo cargar bonus desblokeados desde memoria", base.owner);
			}
		}

		// Token: 0x04000469 RID: 1129
		public bool acepted;

		// Token: 0x0400046A RID: 1130
		public string incomeEfectoID;

		// Token: 0x0400046B RID: 1131
		public string incomeEfectoArgID;

		// Token: 0x0400046C RID: 1132
		[SerializeReference]
		public ArgumentoDeEfecto incomeEfectoArg;

		// Token: 0x0400046D RID: 1133
		public string incomeChangeWithAgencyBuffID;

		// Token: 0x0400046E RID: 1134
		public List<string> bonusDesblokeados = new List<string>();
	}
}
