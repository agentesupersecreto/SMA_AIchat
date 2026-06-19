using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts
{
	// Token: 0x020001FE RID: 510
	public abstract class DialogosDePersonalidadesBase<TSingle> : Singleton<TSingle>, IDialogosDePersonalidades, DialogosDePersonalidadesLogic.IDialogos where TSingle : DialogosDePersonalidadesBase<TSingle>
	{
		// Token: 0x06000BCD RID: 3021
		public abstract void ObtenerDialogos(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null);

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x00034B28 File Offset: 0x00032D28
		private IReadOnlyList<IEnvolturaCondicionalDeHolders> envolturasDeUser
		{
			get
			{
				return this.m_envolturasDeUser;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x00034B30 File Offset: 0x00032D30
		bool DialogosDePersonalidadesLogic.IDialogos.debugPrintElapse
		{
			get
			{
				return this.debugPrintElapse;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00034B38 File Offset: 0x00032D38
		DiccionaryEnum<PersonalidadRasgo, DialogosDePersonalidadesLogic.DialogosDeRasgo> DialogosDePersonalidadesLogic.IDialogos.diccRasgoADialogoDePersonalidad
		{
			get
			{
				return this.m_diccRasgoADialogoDePersonalidad;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00034B40 File Offset: 0x00032D40
		Dictionary<IHolderDeCollecionDeDialogoInfo, IEnvolturaCondicionalDeHolders> DialogosDePersonalidadesLogic.IDialogos.diccDialogoDePersonalidadAEnvolturaCondicional
		{
			get
			{
				return this.m_diccDialogoDePersonalidadAEnvolturaCondicional;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x00034B48 File Offset: 0x00032D48
		SimplePoolDeClearables<DialogosDePersonalidadesLogic.ScoreDeDialogo> DialogosDePersonalidadesLogic.IDialogos.poolDeScoreDeEnvoltura
		{
			get
			{
				return this.m_poolDeScoreDeEnvoltura;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x00034B50 File Offset: 0x00032D50
		Comparison<DialogosDePersonalidadesLogic.ScoreDeDialogo> DialogosDePersonalidadesLogic.IDialogos.comparison
		{
			get
			{
				return this.comparison;
			}
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x00034B58 File Offset: 0x00032D58
		protected override void InitData(bool esEditorTime)
		{
			if (this.envolturasDeUser.Count == 0)
			{
				throw new InvalidOperationException();
			}
			this.m_diccRasgoADialogoDePersonalidad = new DiccionaryEnum<PersonalidadRasgo, DialogosDePersonalidadesLogic.DialogosDeRasgo>((PersonalidadRasgo i) => (int)i);
			this.m_diccDialogoDePersonalidadAEnvolturaCondicional = new Dictionary<IHolderDeCollecionDeDialogoInfo, IEnvolturaCondicionalDeHolders>();
			IEnumerable<IEnvolturaCondicionalDeHolders> enumerable = this.envolturasDeUser.Distinct<IEnvolturaCondicionalDeHolders>();
			this.comparison = new Comparison<DialogosDePersonalidadesLogic.ScoreDeDialogo>(DialogosDePersonalidadesBase<TSingle>.Comparacion);
			foreach (object obj in typeof(PersonalidadRasgo).GetEnumValoresObject())
			{
				PersonalidadRasgo personalidadRasgo = (PersonalidadRasgo)obj;
				DialogosDePersonalidadesLogic.DialogosDeRasgo dialogosDeRasgo;
				if (!this.m_diccRasgoADialogoDePersonalidad.TryGetValue(personalidadRasgo, out dialogosDeRasgo))
				{
					dialogosDeRasgo = new DialogosDePersonalidadesLogic.DialogosDeRasgo
					{
						rasgo = personalidadRasgo,
						dialogos = new List<IHolderDeCollecionDeDialogoInfo>()
					};
					this.m_diccRasgoADialogoDePersonalidad.Add(personalidadRasgo, dialogosDeRasgo);
				}
			}
			foreach (KeyValuePair<int, DialogosDePersonalidadesLogic.DialogosDeRasgo> keyValuePair in this.m_diccRasgoADialogoDePersonalidad)
			{
				foreach (IEnvolturaCondicionalDeHolders envolturaCondicionalDeHolders in enumerable)
				{
					if (envolturaCondicionalDeHolders.IsValid())
					{
						foreach (IHolderDeCollecionDeDialogoInfo holderDeCollecionDeDialogoInfo in envolturaCondicionalDeHolders.grupos)
						{
							if (holderDeCollecionDeDialogoInfo.paraCualquierRasgo || holderDeCollecionDeDialogoInfo.ContieneRasgo((PersonalidadRasgo)keyValuePair.Key))
							{
								keyValuePair.Value.dialogos.Add(holderDeCollecionDeDialogoInfo);
							}
						}
					}
				}
			}
			foreach (IEnvolturaCondicionalDeHolders envolturaCondicionalDeHolders2 in enumerable)
			{
				if (envolturaCondicionalDeHolders2.IsValid())
				{
					foreach (IHolderDeCollecionDeDialogoInfo holderDeCollecionDeDialogoInfo2 in envolturaCondicionalDeHolders2.grupos)
					{
						if (!this.m_diccDialogoDePersonalidadAEnvolturaCondicional.ContainsKey(holderDeCollecionDeDialogoInfo2))
						{
							this.m_diccDialogoDePersonalidadAEnvolturaCondicional.Add(holderDeCollecionDeDialogoInfo2, envolturaCondicionalDeHolders2);
						}
					}
				}
			}
			this.m_DialogosDePersonalidadesLogic.Init(this);
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x00003BC5 File Offset: 0x00001DC5
		[Obsolete("", true)]
		public bool EsMutable(DialogoInfo diag)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x00034DE0 File Offset: 0x00032FE0
		private static int Comparacion(DialogosDePersonalidadesLogic.ScoreDeDialogo x, DialogosDePersonalidadesLogic.ScoreDeDialogo y)
		{
			double score = y.score;
			double num = score;
			if (x != y)
			{
				num = x.score;
			}
			return score.CompareTo(num);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x00034E09 File Offset: 0x00033009
		public void Obtener(IList<DialogoInfo> resultado, PersonalidadDinamica personalidad, Localizacion cultura, object argParaCalcular = null, DialogoInfo last = null, CalculadorDePuntajeDeEnvoltura calculadorDePuntaje = null)
		{
			this.m_DialogosDePersonalidadesLogic.Obtener(resultado, personalidad, cultura, argParaCalcular, last, calculadorDePuntaje);
		}

		// Token: 0x0400094D RID: 2381
		public bool debugPrintElapse;

		// Token: 0x0400094E RID: 2382
		[SerializeField]
		private DialogosDePersonalidadesLogic m_DialogosDePersonalidadesLogic;

		// Token: 0x0400094F RID: 2383
		[SerializeField]
		[ConstraintType(typeof(IEnvolturaCondicionalDeHolders), required = true)]
		protected List<EnvolturaCondicionalDeGrupoDeDialogos> m_envolturasDeUser = new List<EnvolturaCondicionalDeGrupoDeDialogos>();

		// Token: 0x04000950 RID: 2384
		protected SimplePoolDeClearables<DialogosDePersonalidadesLogic.ScoreDeDialogo> m_poolDeScoreDeEnvoltura = new SimplePoolDeClearables<DialogosDePersonalidadesLogic.ScoreDeDialogo>();

		// Token: 0x04000951 RID: 2385
		protected Comparison<DialogosDePersonalidadesLogic.ScoreDeDialogo> comparison;

		// Token: 0x04000952 RID: 2386
		protected DiccionaryEnum<PersonalidadRasgo, DialogosDePersonalidadesLogic.DialogosDeRasgo> m_diccRasgoADialogoDePersonalidad;

		// Token: 0x04000953 RID: 2387
		protected Dictionary<IHolderDeCollecionDeDialogoInfo, IEnvolturaCondicionalDeHolders> m_diccDialogoDePersonalidadAEnvolturaCondicional;

		// Token: 0x04000954 RID: 2388
		[Obsolete("", true)]
		private Dictionary<DialogoInfo, bool> m_dialogoEsMutableDicc = new Dictionary<DialogoInfo, bool>();
	}
}
