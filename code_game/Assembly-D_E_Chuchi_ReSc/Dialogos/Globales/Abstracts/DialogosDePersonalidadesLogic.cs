using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts
{
	// Token: 0x02000200 RID: 512
	[Serializable]
	public class DialogosDePersonalidadesLogic
	{
		// Token: 0x06000BDC RID: 3036 RVA: 0x00034E54 File Offset: 0x00033054
		public void Init(DialogosDePersonalidadesLogic.IDialogos owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_Owner = owner;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00034E70 File Offset: 0x00033070
		public void Obtener(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			bool debugPrintElapse = this.m_Owner.debugPrintElapse;
			if (cultura == Localizacion.None)
			{
				throw new InvalidOperationException();
			}
			try
			{
				for (int i = 0; i < personalidad.Count; i++)
				{
					PersonalidadDinamica.Par par = personalidad[i];
					DialogosDePersonalidadesLogic.DialogosDeRasgo dialogosDeRasgo;
					if (this.m_Owner.diccRasgoADialogoDePersonalidad.TryGetValue(par.rasgo, out dialogosDeRasgo))
					{
						float puntage = par.puntage;
						this.Buscar(puntage, this.m_tempEnvolturas, par.rasgo, dialogosDeRasgo.dialogos, this.m_temp3EnvolturasHast);
						this.m_tempEnvolturas2.AddRange(this.m_tempEnvolturas);
						this.m_tempEnvolturas.Clear();
					}
				}
				if (this.m_tempEnvolturas2.Count == 0)
				{
					return;
				}
				bool flag = calculadorDePuntaje == null;
				for (int j = 0; j < this.m_tempEnvolturas2.Count; j++)
				{
					DialogosDePersonalidadesLogic.ScoreDeDialogo scoreDeDialogo = this.m_tempEnvolturas2[j];
					if (scoreDeDialogo.score > 0.0)
					{
						IEnvolturaCondicionalDeHolders envolturaCondicionalDeHolders = this.m_Owner.diccDialogoDePersonalidadAEnvolturaCondicional[scoreDeDialogo.holderDeDialogos];
						if (!flag)
						{
							scoreDeDialogo.score *= calculadorDePuntaje(envolturaCondicionalDeHolders);
						}
						IDialogosDePersonalidadesPuntajeCalculador dialogosDePersonalidadesPuntajeCalculador = envolturaCondicionalDeHolders as IDialogosDePersonalidadesPuntajeCalculador;
						if (dialogosDePersonalidadesPuntajeCalculador != null)
						{
							scoreDeDialogo.score *= (double)dialogosDePersonalidadesPuntajeCalculador.Calcular(argParaCalcular);
						}
						scoreDeDialogo.score = scoreDeDialogo.score.Random(0.25f);
						if (scoreDeDialogo.score > 0.0)
						{
							this.m_temp.Add(scoreDeDialogo);
						}
					}
				}
				for (int k = 0; k < this.m_temp.Count; k++)
				{
					DialogosDePersonalidadesLogic.ScoreDeDialogo scoreDeDialogo2 = this.m_temp[k];
					int cantidadDeListasDeDialogos = scoreDeDialogo2.holderDeDialogos.cantidadDeListasDeDialogos;
					if (cantidadDeListasDeDialogos > 0)
					{
						int cantidadDeDialogosInfo = scoreDeDialogo2.holderDeDialogos.cantidadDeDialogosInfo;
						if (cantidadDeDialogosInfo > 0)
						{
							int num = Mathf.CeilToInt((float)cantidadDeDialogosInfo / (float)cantidadDeListasDeDialogos);
							if (num == 0)
							{
								throw new InvalidOperationException();
							}
							DialogoInfo dialogoInfo = ((cantidadDeDialogosInfo > 1) ? last : null);
							for (int l = 0; l < num; l++)
							{
								DialogoInfo dialogoInfo2 = scoreDeDialogo2.holderDeDialogos.ObtenerDialogo(cultura, dialogoInfo);
								if (!this.m_temp4.Contains(dialogoInfo2) && dialogoInfo2 != null && dialogoInfo2 != dialogoInfo)
								{
									DialogosDePersonalidadesLogic.ScoreDeDialogo scoreDeDialogo3;
									if (scoreDeDialogo2.dialogo == null)
									{
										scoreDeDialogo2.dialogo = dialogoInfo2;
										scoreDeDialogo2.score *= (double)scoreDeDialogo2.dialogo.chance;
										scoreDeDialogo3 = scoreDeDialogo2;
									}
									else
									{
										DialogosDePersonalidadesLogic.ScoreDeDialogo item = this.m_Owner.poolDeScoreDeEnvoltura.GetItem();
										item.dialogo = dialogoInfo2;
										item.score = (double)item.dialogo.chance * scoreDeDialogo2.score;
										item.holderDeDialogos = scoreDeDialogo2.holderDeDialogos;
										scoreDeDialogo3 = item;
									}
									this.m_temp3.Add(scoreDeDialogo3);
								}
							}
						}
					}
				}
				this.m_temp3.Sort(this.m_Owner.comparison);
				for (int m = 0; m < this.m_temp3.Count; m++)
				{
					DialogosDePersonalidadesLogic.ScoreDeDialogo scoreDeDialogo4 = this.m_temp3[m];
					if (scoreDeDialogo4.dialogo != null && !resultado.Contains(scoreDeDialogo4.dialogo))
					{
						resultado.Add(scoreDeDialogo4.dialogo);
					}
				}
			}
			finally
			{
				for (int n = 0; n < this.m_tempEnvolturas2.Count; n++)
				{
					this.m_Owner.poolDeScoreDeEnvoltura.ReturnItem(this.m_tempEnvolturas2[n]);
				}
				for (int num2 = 0; num2 < this.m_temp3.Count; num2++)
				{
					this.m_Owner.poolDeScoreDeEnvoltura.ReturnItem(this.m_temp3[num2]);
				}
				this.m_temp.Clear();
				this.m_tempEnvolturas2.Clear();
				this.m_tempEnvolturas.Clear();
				this.m_temp3EnvolturasHast.Clear();
				this.m_temp3.Clear();
				this.m_temp4.Clear();
			}
			bool debugPrintElapse2 = this.m_Owner.debugPrintElapse;
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x00035284 File Offset: 0x00033484
		protected void Buscar(float puntajeDeRasgo, IList<DialogosDePersonalidadesLogic.ScoreDeDialogo> resultado, PersonalidadRasgo rasgo, IList<IHolderDeCollecionDeDialogoInfo> grupos, HashSet<IHolderDeCollecionDeDialogoInfo> añadidos)
		{
			bool flag = Random.value >= 0.5f;
			int num = 1;
			if (Random.value >= 0.95f)
			{
				grupos.Shuffle<IHolderDeCollecionDeDialogoInfo>();
			}
			this.Buscar(ref flag, puntajeDeRasgo, resultado, rasgo, grupos, añadidos, ref num);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x000352C8 File Offset: 0x000334C8
		protected void Buscar(ref bool alderecho, float puntajeDeRasgo, IList<DialogosDePersonalidadesLogic.ScoreDeDialogo> resultado, PersonalidadRasgo rasgo, IList<IHolderDeCollecionDeDialogoInfo> grupos, HashSet<IHolderDeCollecionDeDialogoInfo> añadidos, ref int vueltas)
		{
			if (alderecho)
			{
				for (int i = 0; i < grupos.Count; i++)
				{
					IHolderDeCollecionDeDialogoInfo holderDeCollecionDeDialogoInfo = grupos[i];
					float num;
					if (!añadidos.Contains(holderDeCollecionDeDialogoInfo) && holderDeCollecionDeDialogoInfo.Proc(rasgo, puntajeDeRasgo, out num))
					{
						añadidos.Add(holderDeCollecionDeDialogoInfo);
						DialogosDePersonalidadesLogic.ScoreDeDialogo item = this.m_Owner.poolDeScoreDeEnvoltura.GetItem();
						item.holderDeDialogos = holderDeCollecionDeDialogoInfo;
						item.score = (double)(num.Random(0.1f) * holderDeCollecionDeDialogoInfo.modDeScore);
						resultado.Add(item);
					}
				}
			}
			else
			{
				for (int j = grupos.Count - 1; j >= 0; j--)
				{
					IHolderDeCollecionDeDialogoInfo holderDeCollecionDeDialogoInfo2 = grupos[j];
					float num2;
					if (!añadidos.Contains(holderDeCollecionDeDialogoInfo2) && holderDeCollecionDeDialogoInfo2.Proc(rasgo, puntajeDeRasgo, out num2))
					{
						añadidos.Add(holderDeCollecionDeDialogoInfo2);
						DialogosDePersonalidadesLogic.ScoreDeDialogo item2 = this.m_Owner.poolDeScoreDeEnvoltura.GetItem();
						item2.holderDeDialogos = holderDeCollecionDeDialogoInfo2;
						item2.score = (double)(num2.Random(0.1f) * holderDeCollecionDeDialogoInfo2.modDeScore);
						resultado.Add(item2);
					}
				}
			}
			if (vueltas < 5)
			{
				alderecho = Random.value >= 0.5f;
				vueltas++;
				if (Random.value >= 0.975f)
				{
					grupos.Shuffle<IHolderDeCollecionDeDialogoInfo>();
				}
				this.Buscar(ref alderecho, puntajeDeRasgo, resultado, rasgo, grupos, añadidos, ref vueltas);
			}
		}

		// Token: 0x04000957 RID: 2391
		private DialogosDePersonalidadesLogic.IDialogos m_Owner;

		// Token: 0x04000958 RID: 2392
		protected HashSet<IHolderDeCollecionDeDialogoInfo> m_temp3EnvolturasHast = new HashSet<IHolderDeCollecionDeDialogoInfo>();

		// Token: 0x04000959 RID: 2393
		protected List<DialogosDePersonalidadesLogic.ScoreDeDialogo> m_tempEnvolturas = new List<DialogosDePersonalidadesLogic.ScoreDeDialogo>();

		// Token: 0x0400095A RID: 2394
		protected List<DialogosDePersonalidadesLogic.ScoreDeDialogo> m_tempEnvolturas2 = new List<DialogosDePersonalidadesLogic.ScoreDeDialogo>();

		// Token: 0x0400095B RID: 2395
		protected List<DialogosDePersonalidadesLogic.ScoreDeDialogo> m_temp = new List<DialogosDePersonalidadesLogic.ScoreDeDialogo>();

		// Token: 0x0400095C RID: 2396
		protected List<DialogosDePersonalidadesLogic.ScoreDeDialogo> m_temp3 = new List<DialogosDePersonalidadesLogic.ScoreDeDialogo>();

		// Token: 0x0400095D RID: 2397
		protected HashSet<DialogoInfo> m_temp4 = new HashSet<DialogoInfo>();

		// Token: 0x02000201 RID: 513
		public interface IDialogos
		{
			// Token: 0x1700028D RID: 653
			// (get) Token: 0x06000BE1 RID: 3041
			bool debugPrintElapse { get; }

			// Token: 0x1700028E RID: 654
			// (get) Token: 0x06000BE2 RID: 3042
			DiccionaryEnum<PersonalidadRasgo, DialogosDePersonalidadesLogic.DialogosDeRasgo> diccRasgoADialogoDePersonalidad { get; }

			// Token: 0x1700028F RID: 655
			// (get) Token: 0x06000BE3 RID: 3043
			Dictionary<IHolderDeCollecionDeDialogoInfo, IEnvolturaCondicionalDeHolders> diccDialogoDePersonalidadAEnvolturaCondicional { get; }

			// Token: 0x17000290 RID: 656
			// (get) Token: 0x06000BE4 RID: 3044
			SimplePoolDeClearables<DialogosDePersonalidadesLogic.ScoreDeDialogo> poolDeScoreDeEnvoltura { get; }

			// Token: 0x17000291 RID: 657
			// (get) Token: 0x06000BE5 RID: 3045
			Comparison<DialogosDePersonalidadesLogic.ScoreDeDialogo> comparison { get; }
		}

		// Token: 0x02000202 RID: 514
		public class ScoreDeDialogo : IClearable
		{
			// Token: 0x06000BE6 RID: 3046 RVA: 0x00035471 File Offset: 0x00033671
			public void Clear()
			{
				this.dialogo = null;
				this.holderDeDialogos = null;
				this.score = 0.0;
			}

			// Token: 0x0400095E RID: 2398
			public IHolderDeCollecionDeDialogoInfo holderDeDialogos;

			// Token: 0x0400095F RID: 2399
			public DialogoInfo dialogo;

			// Token: 0x04000960 RID: 2400
			public double score;
		}

		// Token: 0x02000203 RID: 515
		[Serializable]
		public class DialogosDeRasgo
		{
			// Token: 0x04000961 RID: 2401
			public PersonalidadRasgo rasgo;

			// Token: 0x04000962 RID: 2402
			public List<IHolderDeCollecionDeDialogoInfo> dialogos;
		}
	}
}
