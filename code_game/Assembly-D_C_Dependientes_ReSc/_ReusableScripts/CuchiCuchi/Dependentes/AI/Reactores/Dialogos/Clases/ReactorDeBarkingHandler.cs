using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Textos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases
{
	// Token: 0x02000347 RID: 839
	[Serializable]
	public class ReactorDeBarkingHandler
	{
		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x060014EE RID: 5358 RVA: 0x000630FD File Offset: 0x000612FD
		public float verbosidadModTotal
		{
			get
			{
				return this.config.verbosidadMod * Singleton<ConfiguracionGeneral>.instance.barkingVerbosidadMod;
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060014EF RID: 5359 RVA: 0x00063115 File Offset: 0x00061315
		public IControlladorDeBark controller
		{
			get
			{
				return this.m_controller;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060014F0 RID: 5360 RVA: 0x0006311D File Offset: 0x0006131D
		public Personalidad personalidad
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060014F1 RID: 5361 RVA: 0x00063125 File Offset: 0x00061325
		public DialogoInfo last
		{
			get
			{
				return this.m_last;
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060014F2 RID: 5362 RVA: 0x0006312D File Offset: 0x0006132D
		public float tiempoDesdeLaUltimaReaccion
		{
			get
			{
				return Time.time - this.m_ultimaReaccionTiempo;
			}
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x0006313C File Offset: 0x0006133C
		public void Init(IControlladorDeBark controller, Personalidad personalidad, ReactorDeBarkingHandler.LoadDialogosHandler dialogosLoader, ReactorDeBarkingHandler.DialogosEsValidoHandler validador, ReactorDeBarkingHandler.DialogosElegidoHandler elegido)
		{
			if (dialogosLoader == null)
			{
				throw new ArgumentNullException("dialogosLoader", "dialogosLoader null reference.");
			}
			if (personalidad == null)
			{
				throw new ArgumentNullException("personalidad", "personalidad null reference.");
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller", "controller null reference.");
			}
			if (validador == null)
			{
				throw new ArgumentNullException("validador", "validador null reference.");
			}
			if (elegido == null)
			{
				throw new ArgumentNullException("elejido", "elejido null reference.");
			}
			this.m_controller = controller;
			this.m_personalidad = personalidad;
			this.m_dialogosLoader = dialogosLoader;
			this.m_validador = validador;
			this.m_elegido = elegido;
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x000631D8 File Offset: 0x000613D8
		public string ObtenerTextoDeCalculo(ICalculoDeEstimulo calculo)
		{
			if (this.tiempoDesdeLaUltimaReaccion > this.config.tiempoParaBorrarMemoriaV3)
			{
				this.m_anteriores.Clear();
				this.m_last = null;
			}
			string text;
			try
			{
				Localizacion id = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id;
				object obj = null;
				DialogoInfo dialogoInfo = null;
				for (int i = 0; i < 5; i++)
				{
					ReactorDeBarkingHandler.ObtenerAUsar(id, calculo, this.m_dialogosLoader, this.m_validador, out dialogoInfo, ref obj, this.m_tempDeResultado, this.m_anteriores, this, this.debugLog);
					if (dialogoInfo != null)
					{
						break;
					}
				}
				if (dialogoInfo == null)
				{
					if (this.debugLog)
					{
						Debug.Log("Ningun dialogo seleccionado para calculo. Productor " + (obj as Object).name + "\n" + JsonUtility.ToJson(calculo, true), this.m_validador.Target as Object);
					}
					text = null;
				}
				else if (!this.m_elegido(obj, dialogoInfo, calculo, id, this))
				{
					this.m_last = dialogoInfo;
					this.AddLastToMemory();
					if (this.debugLog)
					{
						Debug.Log("Dialogo seleccionado no es valido. Productor " + (obj as Object).name + "\n" + JsonUtility.ToJson(dialogoInfo, true), this.m_validador.Target as Object);
					}
					text = null;
				}
				else
				{
					string text2 = this.ObtenerTextoDeDialogo(dialogoInfo, calculo);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						this.m_last = dialogoInfo;
						this.AddLastToMemory();
						text = text2;
					}
					else
					{
						if (this.debugLog)
						{
							Debug.Log("texto de dialogo seleccionado no es valido" + ((text2 == null) ? "NULL" : text2) + ". Productor " + (obj as Object).name, this.m_validador.Target as Object);
						}
						text = null;
					}
				}
			}
			finally
			{
				this.m_tempDeResultado.Clear();
			}
			return text;
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x000633A4 File Offset: 0x000615A4
		private static void ObtenerAUsar(Localizacion local, ICalculoDeEstimulo calculo, ReactorDeBarkingHandler.LoadDialogosHandler m_dialogosLoader, ReactorDeBarkingHandler.DialogosEsValidoHandler m_validador, out DialogoInfo a_usar, ref object productor, List<DialogoInfo> m_tempDeResultado, Queue<DialogoInfo> m_anteriores, ReactorDeBarkingHandler handler, bool debugLog)
		{
			a_usar = null;
			m_dialogosLoader(out productor, m_tempDeResultado, calculo, local, productor, handler);
			if (m_tempDeResultado.Count == 0)
			{
				if (debugLog)
				{
					Debug.Log("Ningun dialogo encontrado para calculo. Productor " + (productor as Object).name + "\n" + JsonUtility.ToJson(calculo, true), m_validador.Target as Object);
				}
				return;
			}
			if (m_anteriores.Count > 0)
			{
				for (int i = 0; i < m_tempDeResultado.Count; i++)
				{
					DialogoInfo dialogoInfo = m_tempDeResultado[i];
					if (!m_anteriores.Contains(dialogoInfo) && m_validador(productor, dialogoInfo, calculo, local, handler))
					{
						a_usar = m_tempDeResultado[i];
						break;
					}
				}
			}
			int num = 0;
			while (a_usar == null && num < 10 && m_tempDeResultado.Count > 0)
			{
				try
				{
					int num2 = m_tempDeResultado.RandomIndexConPreferenciaAlPrimero(66f, Mathf.CeilToInt((float)(m_tempDeResultado.Count / 2)));
					a_usar = m_tempDeResultado[num2];
					if (!m_validador(productor, a_usar, calculo, local, handler))
					{
						m_tempDeResultado.Remove(a_usar);
						a_usar = null;
					}
				}
				finally
				{
					num++;
				}
			}
			if (a_usar == null && m_anteriores.Count > 0)
			{
				a_usar = m_anteriores.ToArray().RandomItem<DialogoInfo>();
			}
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x000634EC File Offset: 0x000616EC
		public bool ReaccionarCalculoDelayed(ICalculoDeEstimulo calculo, int prioridad, float delay, bool forzarPuedePonerEnCola, float duracionMod)
		{
			bool flag = this.config.puedePonerEnCola || forzarPuedePonerEnCola;
			if (!this.controller.PuedeMostrarBark(prioridad, ControllerPrioridadConfig.prioridad, ref flag))
			{
				if (this.debugLog)
				{
					Debug.Log("ReaccionarCalculoDelayed-> controllador no puede mostrar bark (delayed)", this.m_validador.Target as Object);
				}
				return false;
			}
			string text = this.ObtenerTextoDeCalculo(calculo);
			float num = (1f / this.verbosidadModTotal).OutPow(2f);
			if (text != null && this.m_controller.DelayedBark<object>(delay, null, null, text, prioridad, ControllerPrioridadConfig.prioridad, true, num * duracionMod, num))
			{
				this.m_ultimaReaccionTiempo = Time.time;
				return true;
			}
			if (this.debugLog)
			{
				Debug.Log(("ReaccionarCalculoDelayed-> controllador hizo bark. test: " + text == null) ? "NULL" : (text + "  (delayed)"), this.m_validador.Target as Object);
			}
			return false;
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x000635C4 File Offset: 0x000617C4
		public bool ReaccionarCalculo(ICalculoDeEstimulo calculo, int prioridad, float duracionMod)
		{
			bool puedePonerEnCola = this.config.puedePonerEnCola;
			if (!this.controller.PuedeMostrarBark(prioridad, ControllerPrioridadConfig.prioridad, ref puedePonerEnCola))
			{
				if (this.debugLog)
				{
					Debug.Log("ReaccionarCalculoDelayed-> controllador no puede mostrar bark", this.m_validador.Target as Object);
				}
				return false;
			}
			string text = this.ObtenerTextoDeCalculo(calculo);
			float num = (1f / this.verbosidadModTotal).OutPow(3f);
			if (text != null && this.m_controller.Bark(text, true, prioridad, ControllerPrioridadConfig.prioridad, num * duracionMod, num))
			{
				this.m_ultimaReaccionTiempo = Time.time;
				return true;
			}
			if (this.debugLog)
			{
				Debug.Log(("ReaccionarCalculoDelayed-> controllador hizo bark. test: " + text == null) ? "NULL" : text, this.m_validador.Target as Object);
			}
			return false;
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0006368C File Offset: 0x0006188C
		private void AddLastToMemory()
		{
			if (this.m_last == null)
			{
				return;
			}
			if (!this.m_anteriores.Contains(this.m_last))
			{
				this.m_anteriores.Enqueue(this.m_last);
			}
			while (this.m_anteriores.Count > this.config.memoriaCountV3)
			{
				this.m_anteriores.Dequeue();
			}
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x000636EC File Offset: 0x000618EC
		private string ObtenerTextoDeDialogo(DialogoInfo dialogoInfo, ICalculoDeEstimulo calculo)
		{
			bool flag = Singleton<DiccionarioDeSinonimos>.IsInScene && Singleton<DiccionarioDeSinonimos>.instance.EsMutable(dialogoInfo);
			RestriccionDeEdad restriccionDeEdad = this.m_personalidad.ObtenerRestriccion();
			string text;
			if (flag)
			{
				text = dialogoInfo.Mutado(Singleton<DiccionarioDeSinonimos>.instance.mutadorConRestriccion, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, restriccionDeEdad, Sexo.noDefinido, calculo.ObtenerDireccionParaDialogos());
			}
			else
			{
				text = dialogoInfo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, calculo.ObtenerDireccionParaDialogos());
			}
			return text;
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x00063763 File Offset: 0x00061963
		public float ModificadorSegunVerbosidad()
		{
			return this.verbosidadModTotal;
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x0006376B File Offset: 0x0006196B
		public float ModificadorSegunPersonalidad()
		{
			return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(this.personalidad.extroversion, 0.25f);
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x00063782 File Offset: 0x00061982
		public float ModificadorSegunPersonalidadReaccion(ICalculoDeEstimulo calculo)
		{
			return ReactorDeBarkingHandler.ModSegunPersonalidad.ObtenerModificador(calculo.emocion.reaccion, this.personalidad.iRespeto, this.personalidad.amabilidadPorPersonalidad);
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x000637AA File Offset: 0x000619AA
		public float ModificadorSegunPersonalidadPrivacidadPropia(ICalculoDeInteracionEstimulante calculo)
		{
			return ReactorDeBarkingHandler.ModSegunPersonalidad.ObtenerModificadorPrivacidad(ReactorSegundario.PartePrincipalEstimulada(calculo, false), this.personalidad, calculo.estimuloBasico.tipoDeEstimulo, this.personalidad.exhibicionismo, this.personalidad.extroversion);
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x000637DF File Offset: 0x000619DF
		public float ModificadorSegunPersonalidadPrivacidadOther(ICalculoDeEstimuloDeParteEstimulante calculo)
		{
			return ReactorDeBarkingHandler.ModSegunPersonalidad.ObtenerModificadorPrivacidad(calculo.estimulanteParte, this.personalidad.exhibicionismo, this.personalidad.extroversion);
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x00063802 File Offset: 0x00061A02
		public float ModificadorSegunPersonalidadNaturalidad(ICalculoDeInteracionEstimulante calculo)
		{
			return ReactorDeBarkingHandler.ModSegunPersonalidad.ObtenerModificadorNaturalidad(ReactorSegundario.PartePrincipalEstimulada(calculo, false), this.personalidad.perverticidad, this.personalidad.exhibicionismo);
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x00063828 File Offset: 0x00061A28
		public float ModificadorTotal(ICalculoDeEstimulo calculo = null)
		{
			float num = this.ModificadorSegunVerbosidad();
			num *= this.ModificadorSegunPersonalidad();
			if (calculo != null)
			{
				num *= this.ModificadorSegunPersonalidadReaccion(calculo);
				ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
				ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
				if (calculoDeInteracionEstimulante != null)
				{
					num *= this.ModificadorSegunPersonalidadPrivacidadPropia(calculoDeInteracionEstimulante);
					num *= this.ModificadorSegunPersonalidadNaturalidad(calculoDeInteracionEstimulante);
				}
				if (calculoDeEstimuloDeParteEstimulante != null)
				{
					num *= this.ModificadorSegunPersonalidadPrivacidadOther(calculoDeEstimuloDeParteEstimulante);
				}
			}
			return num;
		}

		// Token: 0x04000ED8 RID: 3800
		public bool debugLog;

		// Token: 0x04000ED9 RID: 3801
		public ReactorDeBarkingHandler.Config config = new ReactorDeBarkingHandler.Config();

		// Token: 0x04000EDA RID: 3802
		private IControlladorDeBark m_controller;

		// Token: 0x04000EDB RID: 3803
		private Personalidad m_personalidad;

		// Token: 0x04000EDC RID: 3804
		private ReactorDeBarkingHandler.LoadDialogosHandler m_dialogosLoader;

		// Token: 0x04000EDD RID: 3805
		private ReactorDeBarkingHandler.DialogosEsValidoHandler m_validador;

		// Token: 0x04000EDE RID: 3806
		private ReactorDeBarkingHandler.DialogosElegidoHandler m_elegido;

		// Token: 0x04000EDF RID: 3807
		[ReadOnlyUI]
		[SerializeField]
		private DialogoInfo m_last;

		// Token: 0x04000EE0 RID: 3808
		private Queue<DialogoInfo> m_anteriores = new Queue<DialogoInfo>();

		// Token: 0x04000EE1 RID: 3809
		[NonSerialized]
		private float m_ultimaReaccionTiempo;

		// Token: 0x04000EE2 RID: 3810
		private List<DialogoInfo> m_tempDeResultado = new List<DialogoInfo>();

		// Token: 0x02000348 RID: 840
		// (Invoke) Token: 0x06001503 RID: 5379
		public delegate void LoadDialogosHandler(out object productor, List<DialogoInfo> resultados, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler);

		// Token: 0x02000349 RID: 841
		// (Invoke) Token: 0x06001507 RID: 5383
		public delegate bool DialogosEsValidoHandler(object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handler);

		// Token: 0x0200034A RID: 842
		// (Invoke) Token: 0x0600150B RID: 5387
		public delegate bool DialogosElegidoHandler(object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handler);

		// Token: 0x0200034B RID: 843
		[Serializable]
		public class Config
		{
			// Token: 0x04000EE3 RID: 3811
			public bool puedePonerEnCola;

			// Token: 0x04000EE4 RID: 3812
			[Range(0f, 10f)]
			public float verbosidadMod = 1f;

			// Token: 0x04000EE5 RID: 3813
			public float tiempoParaBorrarMemoriaV3 = 240f;

			// Token: 0x04000EE6 RID: 3814
			[Range(0f, 20f)]
			public int memoriaCountV3 = 5;
		}

		// Token: 0x0200034C RID: 844
		public static class ModSegunPersonalidad
		{
			// Token: 0x0600150F RID: 5391 RVA: 0x000638D4 File Offset: 0x00061AD4
			public static float ValueDeHumanTraitScore(HumanTraitScore score, float range = 0.32f)
			{
				switch (score)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1f + range * 0.5f;
				case HumanTraitScore.muyAlto:
					return 1f + range;
				case HumanTraitScore.bajo:
					return 1f / (1f + range * 0.5f);
				case HumanTraitScore.muyBajo:
					return 1f / (1f + range);
				default:
					throw new ArgumentOutOfRangeException(score.ToString());
				}
			}

			// Token: 0x06001510 RID: 5392 RVA: 0x0006394D File Offset: 0x00061B4D
			public static float ValueDePersonalidadRasgoDefaultOne(float rasgoWeigth, float range = 0.32f)
			{
				return Mathf.Lerp(1f, 1f + range, rasgoWeigth);
			}

			// Token: 0x06001511 RID: 5393 RVA: 0x00063961 File Offset: 0x00061B61
			public static float ValueDePersonalidadRasgoFullRange(float rasgoWeigth, float range = 0.32f)
			{
				return MathfExtension.LerpConMedio(1f / (1f + range), 1f, 1f + range, rasgoWeigth);
			}

			// Token: 0x06001512 RID: 5394 RVA: 0x00063982 File Offset: 0x00061B82
			public static float ValueDePersonalidadRasgoDefaultOne(float rasgoWeigthA, float rasgoWeigthB, float range = 0.32f)
			{
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne((rasgoWeigthA + rasgoWeigthB) / 2f, range);
			}

			// Token: 0x06001513 RID: 5395 RVA: 0x00063993 File Offset: 0x00061B93
			public static float ValueDePersonalidadRasgoFullRange(float rasgoWeigthA, float rasgoWeigthB, float range = 0.32f)
			{
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoFullRange((rasgoWeigthA + rasgoWeigthB) / 2f, range);
			}

			// Token: 0x06001514 RID: 5396 RVA: 0x000639A4 File Offset: 0x00061BA4
			public static float ObtenerModificador(HumanTraitScore vervosidadScore, float range = 0.32f)
			{
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadScore, range);
			}

			// Token: 0x06001515 RID: 5397 RVA: 0x000639AD File Offset: 0x00061BAD
			public static float ObtenerModificador(ReaccionHumana reaccion, HumanTraitScore vervosidadNegativaScore, HumanTraitScore vervosidadPositivaScore)
			{
				if (reaccion.EsPositiva())
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadPositivaScore, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadNegativaScore, 0.32f);
			}

			// Token: 0x06001516 RID: 5398 RVA: 0x000639CE File Offset: 0x00061BCE
			public static float ObtenerModificador(ReaccionHumana reaccion, float rasgoWeigthNegativo, float rasgoWeigthPositivo)
			{
				if (reaccion.EsPositiva())
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthPositivo, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthNegativo, 0.32f);
			}

			// Token: 0x06001517 RID: 5399 RVA: 0x000639EF File Offset: 0x00061BEF
			public static float ObtenerModificadorPrivacidad(ParteDelCuerpoHumano parte, Personalidad personalidad, TipoDeEstimulo tipo, HumanTraitScore vervosidadPrivadaScore, HumanTraitScore vervosidadPublicaScore)
			{
				if (personalidad.EsPrivada(parte, tipo))
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadPrivadaScore, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadPublicaScore, 0.32f);
			}

			// Token: 0x06001518 RID: 5400 RVA: 0x00063A13 File Offset: 0x00061C13
			public static float ObtenerModificadorPrivacidad(ParteDelCuerpoHumano parte, Personalidad personalidad, TipoDeEstimulo tipo, float rasgoWeigthPrivada, float rasgoWeigthPublica)
			{
				if (personalidad.EsPrivada(parte, tipo))
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthPrivada, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthPublica, 0.32f);
			}

			// Token: 0x06001519 RID: 5401 RVA: 0x00063A37 File Offset: 0x00061C37
			public static float ObtenerModificadorPrivacidad(ParteQuePuedeEstimular parte, HumanTraitScore vervosidadPrivadaScore, HumanTraitScore vervosidadPublicaScore)
			{
				if (parte.EsPrivada())
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadPrivadaScore, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadPublicaScore, 0.32f);
			}

			// Token: 0x0600151A RID: 5402 RVA: 0x00063A58 File Offset: 0x00061C58
			public static float ObtenerModificadorPrivacidad(ParteQuePuedeEstimular parte, float rasgoWeigthPrivada, float rasgoWeigthPublica)
			{
				if (parte.EsPrivada())
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthPrivada, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthPublica, 0.32f);
			}

			// Token: 0x0600151B RID: 5403 RVA: 0x00063A79 File Offset: 0x00061C79
			public static float ObtenerModificadorNaturalidad(ParteDelCuerpoHumano parte, HumanTraitScore vervosidadNoNaturalScore, HumanTraitScore vervosidadNaturalScore)
			{
				if (parte.EsNoNaturalSocialmenteCoital())
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadNoNaturalScore, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDeHumanTraitScore(vervosidadNaturalScore, 0.32f);
			}

			// Token: 0x0600151C RID: 5404 RVA: 0x00063A9A File Offset: 0x00061C9A
			public static float ObtenerModificadorNaturalidad(ParteDelCuerpoHumano parte, float rasgoWeigthNoNatural, float rasgoWeigthNatural)
			{
				if (parte.EsNoNaturalSocialmenteCoital())
				{
					return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthNoNatural, 0.32f);
				}
				return ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(rasgoWeigthNatural, 0.32f);
			}
		}
	}
}
