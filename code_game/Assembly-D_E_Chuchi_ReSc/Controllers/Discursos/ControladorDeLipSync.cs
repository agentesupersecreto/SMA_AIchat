using System;
using System.Collections.Generic;
using System.Text;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos
{
	// Token: 0x0200025F RID: 607
	public sealed class ControladorDeLipSync : ControllerColaDePrioridadBase<ControladorDeLipSync.Stado, ControladorDeLipSync.Orden, ControladorDeLipSync.Colas, ControladorDeLipSync, int>, ICharacterHablador, IControladorDeLipSync, IControllerColaDePrioridad
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00006060 File Offset: 0x00004260
		[Obsolete("", true)]
		public ICharacterPuedeHablar puedeHablarModificador
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000D8D RID: 3469 RVA: 0x0003F090 File Offset: 0x0003D290
		public bool puedeBalcusear
		{
			get
			{
				bool flag;
				return !this.estaHablando && this.m_puedeHablarDelegados.PuedeIntentarHablar(out flag);
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x0003F0B4 File Offset: 0x0003D2B4
		public bool puedeHablarConClaridad
		{
			get
			{
				bool flag;
				return !this.estaHablando && this.m_puedeHablarDelegados.PuedeHablarConClaridad(out flag);
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x0003F0D8 File Offset: 0x0003D2D8
		bool ICharacterHablador.estaHablando
		{
			get
			{
				return this.estaHablando;
			}
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x0003F0E0 File Offset: 0x0003D2E0
		public bool Hablar(string texto)
		{
			return (this.puedeBalcusear || this.puedeHablarConClaridad) && this.Pronunciar(texto);
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x00005F51 File Offset: 0x00004151
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000D92 RID: 3474 RVA: 0x00014087 File Offset: 0x00012287
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x0003F0FC File Offset: 0x0003D2FC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_puedeHablarDelegados = this.GetComponentsEnRoot(false);
			this.m_Animator = base.GetComponentInParent<Character>().headAnimator;
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0003F14B File Offset: 0x0003D34B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_bufferDeWs.Clear();
			this.estaHablando = false;
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x0003F168 File Offset: 0x0003D368
		protected override void ControllerUpdated()
		{
			this.currents.A1 = this.MoveTowards(this.delegados.A1.weight, this.targets.A1);
			this.currents.A2 = this.MoveTowards(this.delegados.A2.weight, this.targets.A2);
			this.currents.A3 = this.MoveTowards(this.delegados.A3.weight, this.targets.A3);
			this.currents.B1 = this.MoveTowards(this.delegados.B1.weight, this.targets.B1);
			this.currents.B2 = this.MoveTowards(this.delegados.B2.weight, this.targets.B2);
			this.currents.B3 = this.MoveTowards(this.delegados.B3.weight, this.targets.B3);
			this.currents.C1 = this.MoveTowards(this.delegados.C1.weight, this.targets.C1);
			this.currents.C2 = this.MoveTowards(this.delegados.C2.weight, this.targets.C2);
			this.currents.D1 = this.MoveTowards(this.delegados.D1.weight, this.targets.D1);
			this.currents.D2 = this.MoveTowards(this.delegados.D2.weight, this.targets.D2);
			float num = 0f;
			if (this.aplicarWeightsADelegados)
			{
				this.delegados.A1.weight = this.currents.A1;
				this.delegados.A2.weight = this.currents.A2;
				this.delegados.A3.weight = this.currents.A3;
				this.delegados.B1.weight = this.currents.B1;
				this.delegados.B2.weight = this.currents.B2;
				this.delegados.B3.weight = this.currents.B3;
				this.delegados.C1.weight = this.currents.C1;
				this.delegados.C2.weight = this.currents.C2;
				this.delegados.D1.weight = this.currents.D1;
				this.delegados.D2.weight = this.currents.D2;
				this.m_bufferDeWs.Add((float)((this.currents.Suma() > 0f) ? 1 : 0));
			}
			else
			{
				num = this.delegados.A1.weight + this.delegados.A2.weight + this.delegados.A3.weight + this.delegados.B1.weight + this.delegados.B2.weight + this.delegados.B3.weight + this.delegados.C1.weight + this.delegados.C2.weight + this.delegados.D1.weight + this.delegados.D2.weight;
				this.m_bufferDeWs.Add((float)((this.currents.Suma() > 0f) ? 1 : 0));
			}
			this.m_Animator.SetFloat(AnimatorParamsDicc.bocaDiscursoHash, Mathf.Clamp01(this.m_bufferDeWs.suavizado));
			this.estaHablando = base.currentStado.AlgunaEjecutandose() || num > 0f;
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x0003F57D File Offset: 0x0003D77D
		private float MoveTowards(float current, float target)
		{
			if (current > target)
			{
				return Mathf.MoveTowards(current, target, Time.deltaTime * this.config.pronunciarOutVelocity);
			}
			if (current < target)
			{
				return Mathf.MoveTowards(current, target, Time.deltaTime * this.config.pronunciarInVelocity);
			}
			return target;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0003F5BC File Offset: 0x0003D7BC
		public bool PronunciarForzar(string texto)
		{
			ControladorDeLipSync.Orden orden;
			return this.Pronunciar(texto, true, out orden);
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x0003F5D4 File Offset: 0x0003D7D4
		public bool Pronunciar(string texto)
		{
			ControladorDeLipSync.Orden orden;
			return this.Pronunciar(texto, false, out orden);
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x0003F5EC File Offset: 0x0003D7EC
		public ControladorDeLipSync.Orden PronunciarTexto(string texto)
		{
			ControladorDeLipSync.Orden orden;
			if (this.Pronunciar(texto, false, out orden))
			{
				return orden;
			}
			return null;
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x0003F608 File Offset: 0x0003D808
		public IOrdenDeController PronunciarTexto2(string texto)
		{
			return this.PronunciarTexto(texto);
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x0003F614 File Offset: 0x0003D814
		private bool Pronunciar(string texto, bool forzar, out ControladorDeLipSync.Orden orden)
		{
			orden = null;
			if (string.IsNullOrWhiteSpace(texto))
			{
				return false;
			}
			bool flag = false;
			int num = 0;
			int num2 = 0;
			ControllerPrioridadConfig controllerPrioridadConfig = (forzar ? ControllerPrioridadConfig.interrumpir : ControllerPrioridadConfig.baja);
			ControladorDeLipSync.Orden orden2;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden2, out flag2, num, num2, controllerPrioridadConfig, out flag3, ref flag, false))
			{
				return false;
			}
			if (!flag && flag3)
			{
				return false;
			}
			TextoPronunciable textoPronunciable = DecoDeTexto.Decodificar(texto, this.m_poolDeTextoPronunciable);
			if (textoPronunciable == null || textoPronunciable.duracionTotal <= 0f)
			{
				return false;
			}
			orden = new ControladorDeLipSync.Orden(textoPronunciable, num, num2, textoPronunciable.duracionTotal * this.config.duracionPorLetra + this.config.duracionDePausaAlFinal, controllerPrioridadConfig);
			base.Procesar(orden2 == null, flag2, controllerPrioridadConfig, orden, true, false);
			return true;
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x0000386D File Offset: 0x00001A6D
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x0000386D File Offset: 0x00001A6D
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x0001A9B9 File Offset: 0x00018BB9
		protected override ControladorDeLipSync ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x0003F6C4 File Offset: 0x0003D8C4
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			if (string.IsNullOrWhiteSpace(this.m_debugPronunciar))
			{
				return base.Boton2();
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Pronunciar Debug",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x0003F6F1 File Offset: 0x0003D8F1
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Pronunciar(this.m_debugPronunciar);
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x0003F706 File Offset: 0x0003D906
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			if (string.IsNullOrWhiteSpace(this.m_debugPronunciar))
			{
				return base.Boton3();
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Test Decodificacion",
				playTimeVisible = false
			};
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x0003F734 File Offset: 0x0003D934
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			TextoPronunciable textoPronunciable = DecoDeTexto.Decodificar(this.m_debugPronunciar, null);
			Debug.Log(textoPronunciable.ObtenerTexto());
			Debug.Log(textoPronunciable.ObtenerPronunciacion(true));
			HandleTextFile.WriteTextFile(GameFolders.GameDebugPrintPath("TextLipSyncDeco"), JsonUtility.ToJson(textoPronunciable, true));
		}

		// Token: 0x04000B99 RID: 2969
		private ICharacterPuedeHablar[] m_puedeHablarDelegados;

		// Token: 0x04000B9A RID: 2970
		public bool estaHablando;

		// Token: 0x04000B9B RID: 2971
		private SimplePoolDeClearables<TextoPronunciable> m_poolDeTextoPronunciable = new SimplePoolDeClearables<TextoPronunciable>();

		// Token: 0x04000B9C RID: 2972
		public bool aplicarWeightsADelegados = true;

		// Token: 0x04000B9D RID: 2973
		public bool debugLog;

		// Token: 0x04000B9E RID: 2974
		public ControladorDeLipSync.Valores targets = new ControladorDeLipSync.Valores();

		// Token: 0x04000B9F RID: 2975
		public ControladorDeLipSync.Valores currents = new ControladorDeLipSync.Valores();

		// Token: 0x04000BA0 RID: 2976
		public ControladorDeLipSync.Config config = new ControladorDeLipSync.Config();

		// Token: 0x04000BA1 RID: 2977
		public PhonemeDelegados delegados = new PhonemeDelegados();

		// Token: 0x04000BA2 RID: 2978
		private Animator m_Animator;

		// Token: 0x04000BA3 RID: 2979
		private SmoothFloats m_bufferDeWs = new SmoothFloats(25);

		// Token: 0x04000BA4 RID: 2980
		[Header("Editor Debug")]
		[SerializeField]
		private string m_debugPronunciar = string.Empty;

		// Token: 0x02000260 RID: 608
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControladorDeLipSync.Stado, ControladorDeLipSync.Orden, ControladorDeLipSync.Colas, ControladorDeLipSync, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000DA4 RID: 3492 RVA: 0x0003F7ED File Offset: 0x0003D9ED
			public Orden(TextoPronunciable texto, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig)
				: base(tipoId, prioridad, duracion, priConfig, true)
			{
				if (texto == null)
				{
					throw new ArgumentNullException("texto", "texto null reference.");
				}
				if (texto.duracionTotal <= 0f)
				{
					throw new InvalidOperationException();
				}
				this.texto = texto;
			}

			// Token: 0x06000DA5 RID: 3493 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnDetenidaPorUsuario(ControladorDeLipSync dataUpdate)
			{
			}

			// Token: 0x06000DA6 RID: 3494 RVA: 0x00005F51 File Offset: 0x00004151
			protected override bool OnTerminando(ControladorDeLipSync dataUpdate, bool primerUpdate, ControladorDeLipSync.Orden ordenEsperandoDetencion)
			{
				return true;
			}

			// Token: 0x06000DA7 RID: 3495 RVA: 0x0003F82C File Offset: 0x0003DA2C
			protected override void OnTerminada(ControladorDeLipSync dataUpdate, bool abruptamente)
			{
				this.m_esperandoTerminarTime = 0f;
				dataUpdate.targets.SetAllToZero();
				dataUpdate.m_poolDeTextoPronunciable.ReturnItem(this.texto);
				this.texto = null;
				Queue<TextoPronunciable.Palabra> queue = this.porPronunciar;
				if (queue != null)
				{
					queue.Clear();
				}
				List<TextoPronunciable.Palabra> list = this.pronunciadas;
				if (list == null)
				{
					return;
				}
				list.Clear();
			}

			// Token: 0x06000DA8 RID: 3496 RVA: 0x0003F888 File Offset: 0x0003DA88
			protected override void OnStart(ControladorDeLipSync dataUpdate)
			{
				this.porPronunciar = new Queue<TextoPronunciable.Palabra>(this.texto.palabras.Count);
				this.pronunciadas = new List<TextoPronunciable.Palabra>(this.texto.palabras.Count);
				for (int i = 0; i < this.texto.palabras.Count; i++)
				{
					TextoPronunciable.Palabra palabra = this.texto.palabras[i];
					this.porPronunciar.Enqueue(palabra);
				}
				if (this.porPronunciar.Count == 0)
				{
					throw new InvalidOperationException();
				}
				if (Application.isEditor || Debug.isDebugBuild)
				{
					try
					{
						foreach (TextoPronunciable.Palabra palabra2 in this.porPronunciar)
						{
							palabra2.ObtenerTexto(ControladorDeLipSync.Orden.m_TEMP);
						}
						this.porPronunciarDebug = ControladorDeLipSync.Orden.m_TEMP.ToString();
					}
					finally
					{
						ControladorDeLipSync.Orden.m_TEMP.Clear();
					}
				}
			}

			// Token: 0x06000DA9 RID: 3497 RVA: 0x0003F998 File Offset: 0x0003DB98
			private void OnNuevaPalabraPronunciada()
			{
				TextoPronunciable.Palabra palabra;
				do
				{
					palabra = this.porPronunciar.Dequeue();
					this.pronunciadas.Add(palabra);
				}
				while (this.porPronunciar.Count > 0 && this.m_LastPalabra != palabra);
				if (Application.isEditor || Debug.isDebugBuild)
				{
					try
					{
						foreach (TextoPronunciable.Palabra palabra2 in this.porPronunciar)
						{
							palabra2.ObtenerTexto(ControladorDeLipSync.Orden.m_TEMP);
						}
						this.porPronunciarDebug = ControladorDeLipSync.Orden.m_TEMP.ToString();
					}
					finally
					{
						ControladorDeLipSync.Orden.m_TEMP.Clear();
					}
					try
					{
						foreach (TextoPronunciable.Palabra palabra3 in this.pronunciadas)
						{
							palabra3.ObtenerTexto(ControladorDeLipSync.Orden.m_TEMP);
						}
						this.pronunciadoDebug = ControladorDeLipSync.Orden.m_TEMP.ToString();
					}
					finally
					{
						ControladorDeLipSync.Orden.m_TEMP.Clear();
					}
				}
			}

			// Token: 0x06000DAA RID: 3498 RVA: 0x0003FAC8 File Offset: 0x0003DCC8
			protected override bool UpdateOrden(ControladorDeLipSync dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				ControladorDeLipSync.Config config = dataUpdate.config;
				float num = base.ObtenerCurrentTimeMod(config.duracionDePausaAlFinal);
				TextoPronunciable.Palabra palabra;
				SilabaPronunciableEnTiempo silabaPronunciableEnTiempo;
				CasillaPronunciable casillaPronunciable;
				RangeValueV2 rangeValueV;
				bool flag;
				CasillaPronunciable casillaPronunciable2;
				RangeValueV2 rangeValueV2;
				bool flag2;
				bool flag3;
				if (!this.texto.Dequeue(num, out palabra, out silabaPronunciableEnTiempo, out casillaPronunciable, out rangeValueV, out flag, out casillaPronunciable2, out rangeValueV2, out flag2, out flag3))
				{
					this.m_esperandoTerminarTime += base.estadoDeltaTime;
					if (this.m_esperandoTerminarTime >= config.duracionDePausaAlFinal)
					{
						return false;
					}
				}
				if (palabra != null && palabra != this.m_LastPalabra)
				{
					this.m_LastPalabra = palabra;
					this.OnNuevaPalabraPronunciada();
				}
				if (dataUpdate.debugLog)
				{
					Debug.Log("Pass:");
				}
				if (casillaPronunciable.tipo != TipoDeCasillaPronunciable.extencion)
				{
					dataUpdate.targets.SetAllToZero();
				}
				else
				{
					dataUpdate.targets.MoveAllTowards(0f, Time.deltaTime * config.pronunciarOutVelocity * 0.3f);
				}
				if (flag2)
				{
					this.PronunciarCasilla(dataUpdate, num, ref casillaPronunciable, rangeValueV, config.vocalMinMedioMod, config.vocalMaxMedioMod, config.vocalEntrandoOutPower, config.vocalSaliendoInPower);
				}
				else
				{
					this.PronunciarCasilla(dataUpdate, num, ref casillaPronunciable, rangeValueV, config.silabaMinMedioMod, config.silabaMaxMedioMod, config.silabaEntrandoOutPower, config.silabaSaliendoInPower);
				}
				if (flag)
				{
					if (flag3)
					{
						this.PronunciarCasilla(dataUpdate, num, ref casillaPronunciable2, rangeValueV2, config.vocalMinMedioMod, config.vocalMaxMedioMod, config.vocalEntrandoOutPower, config.vocalSaliendoInPower);
					}
					else
					{
						this.PronunciarCasilla(dataUpdate, num, ref casillaPronunciable2, rangeValueV2, config.silabaMinMedioMod, config.silabaMaxMedioMod, config.silabaEntrandoOutPower, config.silabaSaliendoInPower);
					}
				}
				return true;
			}

			// Token: 0x06000DAB RID: 3499 RVA: 0x0003FC40 File Offset: 0x0003DE40
			private void PronunciarCasilla(ControladorDeLipSync dataUpdate, float timeMod, ref CasillaPronunciable casilla, RangeValueV2 range, float minMedioMod, float maxMedioMod, float entrandoOutPower, float saliendoInPower)
			{
				switch (casilla.tipo)
				{
				case TipoDeCasillaPronunciable.None:
					if (dataUpdate.debugLog)
					{
						Debug.Log("Pronunciando |" + ((casilla.casilla.tipo == TipoDeCasilla.simple) ? casilla.casilla.primer.@char.ToString() : (casilla.casilla.primer.@char.ToString() + casilla.casilla.segundo.@char.ToString())) + "| con Stop");
						return;
					}
					break;
				case TipoDeCasillaPronunciable.Phoneme:
				{
					float num = this.texto.TimepotranscurridoModABuscandoTime(timeMod);
					if (num > range.max || num < range.min)
					{
						throw new InvalidOperationException("se esta generando mal el range");
					}
					float num2 = range.InverseLerpAlMedio(num, minMedioMod, maxMedioMod, entrandoOutPower, saliendoInPower);
					switch (casilla.phenome)
					{
					case Phoneme.None:
						break;
					case Phoneme.A1:
						dataUpdate.targets.A1 = num2;
						break;
					case Phoneme.A2:
						dataUpdate.targets.A2 = num2;
						break;
					case Phoneme.A3:
						dataUpdate.targets.A3 = num2;
						break;
					case Phoneme.B1:
						dataUpdate.targets.B1 = num2;
						break;
					case Phoneme.B2:
						dataUpdate.targets.B2 = num2;
						break;
					case Phoneme.B3:
						dataUpdate.targets.B3 = num2;
						break;
					case Phoneme.C1:
						dataUpdate.targets.C1 = num2;
						break;
					case Phoneme.C2:
						dataUpdate.targets.C2 = num2;
						break;
					case Phoneme.D1:
						dataUpdate.targets.D1 = num2;
						break;
					case Phoneme.D2:
						dataUpdate.targets.D2 = num2;
						break;
					default:
						throw new ArgumentOutOfRangeException(casilla.phenome.ToString());
					}
					if (dataUpdate.debugLog)
					{
						Debug.Log("Pronunciando |" + ((casilla.casilla.tipo == TipoDeCasilla.simple) ? casilla.casilla.primer.@char.ToString() : (casilla.casilla.primer.@char.ToString() + casilla.casilla.segundo.@char.ToString())) + "| con Phoneme: " + casilla.phenome.ToString());
						return;
					}
					break;
				}
				case TipoDeCasillaPronunciable.extencion:
					if (dataUpdate.debugLog)
					{
						Debug.Log("Pronunciando |" + ((casilla.casilla.tipo == TipoDeCasilla.simple) ? casilla.casilla.primer.@char.ToString() : (casilla.casilla.primer.@char.ToString() + casilla.casilla.segundo.@char.ToString())) + "| Extendiendo ");
						return;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException(casilla.tipo.ToString());
				}
			}

			// Token: 0x04000BA5 RID: 2981
			public TextoPronunciable texto;

			// Token: 0x04000BA6 RID: 2982
			public Queue<TextoPronunciable.Palabra> porPronunciar;

			// Token: 0x04000BA7 RID: 2983
			public List<TextoPronunciable.Palabra> pronunciadas;

			// Token: 0x04000BA8 RID: 2984
			public string porPronunciarDebug;

			// Token: 0x04000BA9 RID: 2985
			public string pronunciadoDebug;

			// Token: 0x04000BAA RID: 2986
			private TextoPronunciable.Palabra m_LastPalabra;

			// Token: 0x04000BAB RID: 2987
			private float m_esperandoTerminarTime;

			// Token: 0x04000BAC RID: 2988
			private static StringBuilder m_TEMP = new StringBuilder();
		}

		// Token: 0x02000261 RID: 609
		public sealed class Colas : ControllerColaDePrioridadBase<ControladorDeLipSync.Stado, ControladorDeLipSync.Orden, ControladorDeLipSync.Colas, ControladorDeLipSync, int>.ColasBase
		{
		}

		// Token: 0x02000262 RID: 610
		public sealed class Stado : ControllerColaDePrioridadBase<ControladorDeLipSync.Stado, ControladorDeLipSync.Orden, ControladorDeLipSync.Colas, ControladorDeLipSync, int>.StadoBase
		{
		}

		// Token: 0x02000263 RID: 611
		[Serializable]
		public class Config
		{
			// Token: 0x04000BAD RID: 2989
			public float duracionDePausaAlFinal = 3f;

			// Token: 0x04000BAE RID: 2990
			public float duracionPorLetra = 0.1f;

			// Token: 0x04000BAF RID: 2991
			public float pronunciarInVelocity = 15f;

			// Token: 0x04000BB0 RID: 2992
			public float pronunciarOutVelocity = 15f;

			// Token: 0x04000BB1 RID: 2993
			[Header("silabas")]
			public float silabaMinMedioMod;

			// Token: 0x04000BB2 RID: 2994
			public float silabaMaxMedioMod = 0.5f;

			// Token: 0x04000BB3 RID: 2995
			public float silabaEntrandoOutPower = 3f;

			// Token: 0x04000BB4 RID: 2996
			public float silabaSaliendoInPower = 1f;

			// Token: 0x04000BB5 RID: 2997
			[Header("vacales")]
			public float vocalMinMedioMod = 0.5f;

			// Token: 0x04000BB6 RID: 2998
			public float vocalMaxMedioMod = 1f;

			// Token: 0x04000BB7 RID: 2999
			public float vocalEntrandoOutPower = 1f;

			// Token: 0x04000BB8 RID: 3000
			public float vocalSaliendoInPower = 3f;
		}

		// Token: 0x02000264 RID: 612
		[Serializable]
		public class Valores
		{
			// Token: 0x06000DB0 RID: 3504 RVA: 0x0003FFB8 File Offset: 0x0003E1B8
			public void SetAllToZero()
			{
				this.A1 = (this.A2 = (this.A3 = (this.B1 = (this.B2 = (this.B3 = (this.C1 = (this.C2 = (this.D1 = (this.D2 = 0f)))))))));
			}

			// Token: 0x06000DB1 RID: 3505 RVA: 0x00040024 File Offset: 0x0003E224
			public void MoveAllTowards(float target, float delta)
			{
				this.A1 = Mathf.MoveTowards(this.A1, target, delta);
				this.A2 = Mathf.MoveTowards(this.A2, target, delta);
				this.A3 = Mathf.MoveTowards(this.A3, target, delta);
				this.B1 = Mathf.MoveTowards(this.B1, target, delta);
				this.B2 = Mathf.MoveTowards(this.B2, target, delta);
				this.B3 = Mathf.MoveTowards(this.B3, target, delta);
				this.C1 = Mathf.MoveTowards(this.C1, target, delta);
				this.C2 = Mathf.MoveTowards(this.C2, target, delta);
				this.D1 = Mathf.MoveTowards(this.D1, target, delta);
				this.D2 = Mathf.MoveTowards(this.D2, target, delta);
			}

			// Token: 0x06000DB2 RID: 3506 RVA: 0x000400F0 File Offset: 0x0003E2F0
			public void SetAllToOne()
			{
				this.A1 = (this.A2 = (this.A3 = (this.B1 = (this.B2 = (this.B3 = (this.C1 = (this.C2 = (this.D1 = (this.D2 = 1f)))))))));
			}

			// Token: 0x06000DB3 RID: 3507 RVA: 0x0004015C File Offset: 0x0003E35C
			public float Suma()
			{
				return this.A1 + this.A2 + this.A3 + this.B1 + this.B2 + this.B3 + this.C1 + this.C2 + this.D1 + this.D2;
			}

			// Token: 0x04000BB9 RID: 3001
			public float A1 = 1f;

			// Token: 0x04000BBA RID: 3002
			public float A2 = 1f;

			// Token: 0x04000BBB RID: 3003
			public float A3 = 1f;

			// Token: 0x04000BBC RID: 3004
			public float B1 = 1f;

			// Token: 0x04000BBD RID: 3005
			public float B2 = 1f;

			// Token: 0x04000BBE RID: 3006
			public float B3 = 1f;

			// Token: 0x04000BBF RID: 3007
			public float C1 = 1f;

			// Token: 0x04000BC0 RID: 3008
			public float C2 = 1f;

			// Token: 0x04000BC1 RID: 3009
			public float D1 = 1f;

			// Token: 0x04000BC2 RID: 3010
			public float D2 = 1f;
		}
	}
}
