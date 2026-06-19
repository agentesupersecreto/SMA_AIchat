using System;
using System.Collections.Generic;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Textos;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos
{
	// Token: 0x02000007 RID: 7
	public sealed class ControlladorDeBarkDePersonalidad : ControllerColaDePrioridadBase<ControlladorDeBarkDePersonalidad.Estado, ControlladorDeBarkDePersonalidad.Orden, ControlladorDeBarkDePersonalidad.Cola, ControlladorDeBarkDePersonalidad, int>, IControlladorDeBark
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002836 File Offset: 0x00000A36
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002839 File Offset: 0x00000A39
		protected sealed override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002841 File Offset: 0x00000A41
		private bool PuedeHablar(out bool duracionEsIndefinida)
		{
			return this.m_puedeHablarDelegados.PuedeIntentarHablar(out duracionEsIndefinida);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002850 File Offset: 0x00000A50
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (!Singleton<MainDialogueSystemEvents>.IsInScene)
			{
				Debug.LogWarning("No hay MainDialogueSystemEvents en scena");
				return;
			}
			this.m_Gestuable = this.GetComponentEnRoot(false);
			if (this.m_Gestuable == null)
			{
				throw new ArgumentNullException("m_Gestuable", "m_Gestuable null reference.");
			}
			this.m_barkUI = this.GetComponentEnCharacter(false);
			this.m_LipSync = this.GetComponentEnCharacter(false);
			DialogueSystemEvents dialogueSystemEvents = Singleton<MainDialogueSystemEvents>.instance.dialogueSystemEvents;
			dialogueSystemEvents.conversationEvents.onConversationStart.AddListener(new UnityAction<Transform>(this.onConversationStart));
			dialogueSystemEvents.conversationEvents.onConversationEnd.AddListener(new UnityAction<Transform>(this.onConversationEnds));
			this.m_initialAlpha = this.m_barkUI.barkText.color.a;
			this.UpdatePuedeHablarDelegados();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002916 File Offset: 0x00000B16
		public void UpdatePuedeHablarDelegados()
		{
			this.m_puedeHablarDelegados = this.GetComponentsEnRoot(false);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002928 File Offset: 0x00000B28
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_conversacionEnCurso = false;
			if (!Singleton<MainDialogueSystemEvents>.IsInScene)
			{
				return;
			}
			DialogueSystemEvents dialogueSystemEvents = Singleton<MainDialogueSystemEvents>.instance.dialogueSystemEvents;
			dialogueSystemEvents.conversationEvents.onConversationStart.RemoveListener(new UnityAction<Transform>(this.onConversationStart));
			dialogueSystemEvents.conversationEvents.onConversationEnd.RemoveListener(new UnityAction<Transform>(this.onConversationEnds));
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000298C File Offset: 0x00000B8C
		private void onConversationStart(Transform actor)
		{
			this.m_conversacionEnCurso = true;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002995 File Offset: 0x00000B95
		private void onConversationEnds(Transform actor)
		{
			this.m_conversacionEnCurso = false;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000029A0 File Offset: 0x00000BA0
		public bool PuedeMostrarBark(int prioridad, ControllerPrioridadConfig priConfig, ref bool puedePonerEnCola)
		{
			bool flag;
			ControlladorDeBarkDePersonalidad.Orden orden;
			bool flag2;
			bool flag3;
			return prioridad >= this.m_minPrioridad && !this.m_conversacionEnCurso && this.PuedeHablar(out flag) && !(this.m_barkUI == null) && this.m_barkUI.ShouldShowText() && base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, prioridad, priConfig, out flag3, ref puedePonerEnCola, false);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A00 File Offset: 0x00000C00
		public bool PuedeMostrarBark(int prioridad, ControllerPrioridadConfig priConfig, out ControlladorDeBarkDePersonalidad.Orden ordenOcupandoSlot, out bool librePorquePrioridadEsMayor, out bool entraraACola, ref bool puedePonerEnCola)
		{
			ordenOcupandoSlot = null;
			librePorquePrioridadEsMayor = false;
			entraraACola = false;
			bool flag;
			return prioridad >= this.m_minPrioridad && !this.m_conversacionEnCurso && this.PuedeHablar(out flag) && base.VerificarSiPuedeEjecutarse(out ordenOcupandoSlot, out librePorquePrioridadEsMayor, 0, prioridad, priConfig, out entraraACola, ref puedePonerEnCola, false);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A50 File Offset: 0x00000C50
		public bool MuteClearing(float duracion)
		{
			bool flag = this.ClearBark();
			if (this.m_puedeActualizarse)
			{
				this.m_puedeActualizarse = false;
				flag = GlobalUpdater.instancia.Invokar<ControlladorDeBarkDePersonalidad>(delegate(ControlladorDeBarkDePersonalidad c)
				{
					c.m_puedeActualizarse = true;
				}, duracion, this) || flag;
			}
			return flag;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public void FlagMinPrioridad(int MinPrioridad, float duracion)
		{
			this.m_minPrioridad = MinPrioridad;
			Action<ControlladorDeBarkDePersonalidad> action = delegate(ControlladorDeBarkDePersonalidad c)
			{
				c.m_minPrioridad = int.MinValue;
			};
			GlobalUpdater.instancia.InvokarDeInmediato(action);
			GlobalUpdater.instancia.Invokar<ControlladorDeBarkDePersonalidad>(action, duracion, this);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002AF4 File Offset: 0x00000CF4
		public bool DelayedBark<TData>(float delay, TData extradata, Action<TData, bool> callBack, string dialogo, int prioridad, ControllerPrioridadConfig priConfig, bool vocalizar, float duracionModPorLetra = 1f, float duracionMod = 1f)
		{
			if (delay <= 0f)
			{
				bool flag = this.Bark(dialogo, vocalizar, prioridad, priConfig, duracionModPorLetra, duracionMod);
				Action<TData, bool> callBack2 = callBack;
				if (callBack2 != null)
				{
					callBack2(extradata, flag);
				}
				return true;
			}
			ControlladorDeBarkDePersonalidad.DelayedBarkData data = default(ControlladorDeBarkDePersonalidad.DelayedBarkData);
			data.vocalizar = vocalizar;
			data.dialogo = dialogo;
			data.prioridad = prioridad;
			data.priConfig = priConfig;
			data.duracionModPorLetra = duracionModPorLetra;
			data.duracionMod = duracionMod;
			return GlobalUpdater.instancia.Invokar(delegate
			{
				bool flag2 = this.Bark(data.dialogo, data.vocalizar, data.prioridad, data.priConfig, data.duracionModPorLetra, data.duracionMod);
				Action<TData, bool> callBack3 = callBack;
				if (callBack3 == null)
				{
					return;
				}
				callBack3(extradata, flag2);
			}, delay);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002BC4 File Offset: 0x00000DC4
		public bool ClearBark()
		{
			bool flag = base.currentStado.AlgunaEjecutandose();
			flag = base.currentCola.RemoverTodas() || flag;
			base.ForzarDetenerOrdenes();
			return flag;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002BF4 File Offset: 0x00000DF4
		public bool Bark(string dialogo, bool vocalizar, int prioridad, ControllerPrioridadConfig priConfig, float duracionModPorLetra = 1f, float duracionMod = 1f)
		{
			if (dialogo == null || dialogo.Length == 0)
			{
				throw new ArgumentNullException("dialogo", "dialogo null reference.");
			}
			bool flag = true;
			ControlladorDeBarkDePersonalidad.Orden orden;
			bool flag2;
			bool flag3;
			if (!this.PuedeMostrarBark(prioridad, priConfig, out orden, out flag2, out flag3, ref flag))
			{
				return false;
			}
			float num = 5f * duracionMod + (float)dialogo.Length * 0.2f * duracionModPorLetra;
			if (base.PuedeAcumularse(orden, priConfig, 0) && orden.dialogoText == dialogo)
			{
				if (!vocalizar)
				{
					base.ResusarOrden(orden, num, prioridad, null, null);
				}
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			ControlladorDeBarkDePersonalidad.Orden orden2 = new ControlladorDeBarkDePersonalidad.Orden(dialogo, vocalizar, 0, prioridad, num, priConfig);
			base.Procesar(orden == null, flag2, priConfig, orden2, true, false);
			return true;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002CA2 File Offset: 0x00000EA2
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002CA5 File Offset: 0x00000EA5
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002CA8 File Offset: 0x00000EA8
		protected override ControlladorDeBarkDePersonalidad ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002CAB File Offset: 0x00000EAB
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			if (string.IsNullOrWhiteSpace(this.m_debugBark))
			{
				return base.Boton2();
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Pronunciar Debug",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002CD8 File Offset: 0x00000ED8
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Bark(this.m_debugBark, true, 0, ControllerPrioridadConfig.prioridad, 1f, 1f);
		}

		// Token: 0x0400000E RID: 14
		[SerializeField]
		private string m_colorDeLetrasPronunciadas = "#808080ff";

		// Token: 0x0400000F RID: 15
		[SerializeField]
		private float m_initialAlpha;

		// Token: 0x04000010 RID: 16
		[SerializeField]
		[ReadOnlyUI]
		private int m_minPrioridad = int.MinValue;

		// Token: 0x04000011 RID: 17
		[SerializeField]
		[ReadOnlyUI]
		private bool m_conversacionEnCurso;

		// Token: 0x04000012 RID: 18
		private UnityUIBarkUITValle m_barkUI;

		// Token: 0x04000013 RID: 19
		[Obsolete("", true)]
		private ControladorDeLipSync m_ControladorDeLipSync;

		// Token: 0x04000014 RID: 20
		private ControladorDeLipSync m_LipSync;

		// Token: 0x04000015 RID: 21
		private ICharacterGestuable m_Gestuable;

		// Token: 0x04000016 RID: 22
		private ICharacterPuedeHablar[] m_puedeHablarDelegados;

		// Token: 0x04000017 RID: 23
		[Header("Editor Debug")]
		[SerializeField]
		private string m_debugBark = string.Empty;

		// Token: 0x02000079 RID: 121
		private struct DelayedBarkData
		{
			// Token: 0x04000163 RID: 355
			public bool vocalizar;

			// Token: 0x04000164 RID: 356
			public string dialogo;

			// Token: 0x04000165 RID: 357
			public int prioridad;

			// Token: 0x04000166 RID: 358
			public ControllerPrioridadConfig priConfig;

			// Token: 0x04000167 RID: 359
			public float duracionModPorLetra;

			// Token: 0x04000168 RID: 360
			public float duracionMod;
		}

		// Token: 0x0200007A RID: 122
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeBarkDePersonalidad.Estado, ControlladorDeBarkDePersonalidad.Orden, ControlladorDeBarkDePersonalidad.Cola, ControlladorDeBarkDePersonalidad, int>.OrdenBaseDeControllador
		{
			// Token: 0x060003D0 RID: 976 RVA: 0x00014CAC File Offset: 0x00012EAC
			[Obsolete("debe resivir string", true)]
			public Orden(DialogoInfo dialogo, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, bool puedeMutar, RestriccionDeEdad? restrccion)
				: base(tipoId, prioridad, duracion, priConfig, false)
			{
				if (dialogo == null)
				{
					throw new ArgumentNullException("dialogo", "dialogo null reference.");
				}
				this.dialogo = dialogo;
				this.m_puedeMutar = puedeMutar;
				this.m_restriccion = restrccion;
			}

			// Token: 0x060003D1 RID: 977 RVA: 0x00014CE5 File Offset: 0x00012EE5
			public Orden(string dialogo, bool vocalizar, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig)
				: base(tipoId, prioridad, duracion, priConfig, false)
			{
				if (string.IsNullOrEmpty(dialogo))
				{
					throw new ArgumentNullException("dialogo", "dialogo null reference.");
				}
				this.dialogoText = dialogo;
				this.vocalizar = vocalizar;
			}

			// Token: 0x060003D2 RID: 978 RVA: 0x00014D1B File Offset: 0x00012F1B
			protected override void OnDetenidaPorUsuario(ControlladorDeBarkDePersonalidad dataUpdate)
			{
			}

			// Token: 0x060003D3 RID: 979 RVA: 0x00014D1D File Offset: 0x00012F1D
			protected override bool OnTerminando(ControlladorDeBarkDePersonalidad dataUpdate, bool primerUpdate, ControlladorDeBarkDePersonalidad.Orden ordenEsperandoDetencion)
			{
				return true;
			}

			// Token: 0x060003D4 RID: 980 RVA: 0x00014D20 File Offset: 0x00012F20
			protected override void OnTerminada(ControlladorDeBarkDePersonalidad dataUpdate, bool abruptamente)
			{
				this.m_lastPronunciadaCount = 0;
				ControladorDeLipSync.Orden orden = this.slave;
				if (orden != null)
				{
					orden.Detener(false);
				}
				this.slave = null;
				dataUpdate.m_barkUI.Hide();
				Dictionary<TextoPronunciable.Palabra, string> textoDePalabra = this.m_textoDePalabra;
				if (textoDePalabra == null)
				{
					return;
				}
				textoDePalabra.Clear();
			}

			// Token: 0x060003D5 RID: 981 RVA: 0x00014D5D File Offset: 0x00012F5D
			protected override void OnStart(ControlladorDeBarkDePersonalidad dataUpdate)
			{
			}

			// Token: 0x060003D6 RID: 982 RVA: 0x00014D60 File Offset: 0x00012F60
			protected override bool UpdateOrden(ControlladorDeBarkDePersonalidad dataUpdate, bool esPrimerUpdate)
			{
				if (!this.Termino())
				{
					UnityUIBarkUITValle barkUI = dataUpdate.m_barkUI;
					if (!(((barkUI != null) ? barkUI.barkText : null) == null))
					{
						if (!esPrimerUpdate && this.vocalizar && (this.slave == null || this.slave.Termino()))
						{
							return false;
						}
						if (dataUpdate.m_conversacionEnCurso || dataUpdate.m_barkUI == null)
						{
							return false;
						}
						bool flag;
						if (!dataUpdate.PuedeHablar(out flag))
						{
							if (flag)
							{
								return false;
							}
							this.ReducirPrioridad();
							base.EsperarFrame();
							return true;
						}
						else
						{
							if (!dataUpdate.m_barkUI.IsPlaying && !dataUpdate.m_barkUI.BarkPermanente(this.dialogoText, "NONE"))
							{
								return false;
							}
							if (esPrimerUpdate)
							{
								if (this.vocalizar)
								{
									dataUpdate.m_barkUI.barkText.text = string.Empty;
									Color color = dataUpdate.m_barkUI.barkText.color;
									color.a = dataUpdate.m_initialAlpha;
									dataUpdate.m_barkUI.barkText.color = color;
								}
								else
								{
									Color color2 = dataUpdate.m_barkUI.barkText.color;
									color2.a = 1f;
									dataUpdate.m_barkUI.barkText.color = color2;
								}
								if (this.vocalizar)
								{
									this.m_textoDePalabra = new Dictionary<TextoPronunciable.Palabra, string>();
									if (dataUpdate.m_LipSync == null)
									{
										return false;
									}
									this.slave = dataUpdate.m_LipSync.PronunciarTexto(this.dialogoText);
									if (this.slave == null)
									{
										return false;
									}
									float duracion = this.slave.duracion;
									if (duracion <= 0f)
									{
										return false;
									}
									if (duracion > base.duracion)
									{
										base.ChangeDuracion(duracion);
									}
								}
								return true;
							}
							this.ReducirPrioridad();
							this.UpdateText(dataUpdate);
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060003D7 RID: 983 RVA: 0x00014F0B File Offset: 0x0001310B
			private void ReducirPrioridad()
			{
				if (base.permanente && base.currentTime > 3f)
				{
					base.DisminuirPrioridadAcumulativaDelta(0.999f);
					return;
				}
				if (base.currentTimeMod > 0.2f)
				{
					base.DisminuirPrioridadAcumulativaDelta(0.999f);
				}
			}

			// Token: 0x060003D8 RID: 984 RVA: 0x00014F48 File Offset: 0x00013148
			private void UpdateText(ControlladorDeBarkDePersonalidad dataUpdate)
			{
				if (this.vocalizar)
				{
					if (this.m_lastPronunciadaCount == this.slave.pronunciadas.Count)
					{
						return;
					}
					this.m_lastPronunciadaCount = this.slave.pronunciadas.Count;
					try
					{
						if (this.slave.pronunciadas.Count > 0)
						{
							ControlladorDeBarkDePersonalidad.Orden.m_TEMP.Append("<color=");
							ControlladorDeBarkDePersonalidad.Orden.m_TEMP.Append(dataUpdate.m_colorDeLetrasPronunciadas);
							ControlladorDeBarkDePersonalidad.Orden.m_TEMP.Append(">");
						}
						for (int i = 0; i < this.slave.pronunciadas.Count; i++)
						{
							TextoPronunciable.Palabra palabra = this.slave.pronunciadas[i];
							string text;
							if (!this.m_textoDePalabra.TryGetValue(palabra, out text))
							{
								try
								{
									palabra.ObtenerTextoAlterado(ControlladorDeBarkDePersonalidad.Orden.m_TEMP2, dataUpdate.m_Gestuable.estadoDeBocaPorUser);
									text = ControlladorDeBarkDePersonalidad.Orden.m_TEMP2.ToString();
									this.m_textoDePalabra.Add(palabra, text);
								}
								finally
								{
									ControlladorDeBarkDePersonalidad.Orden.m_TEMP2.Clear();
								}
							}
							ControlladorDeBarkDePersonalidad.Orden.m_TEMP.Append(text);
						}
						if (this.slave.pronunciadas.Count > 0)
						{
							ControlladorDeBarkDePersonalidad.Orden.m_TEMP.Append("</color>");
						}
						foreach (TextoPronunciable.Palabra palabra2 in this.slave.porPronunciar)
						{
							palabra2.ObtenerTexto(ControlladorDeBarkDePersonalidad.Orden.m_TEMP);
						}
						dataUpdate.m_barkUI.barkText.text = ControlladorDeBarkDePersonalidad.Orden.m_TEMP.ToString();
					}
					finally
					{
						ControlladorDeBarkDePersonalidad.Orden.m_TEMP.Clear();
					}
				}
			}

			// Token: 0x04000169 RID: 361
			[NonSerialized]
			public ControladorDeLipSync.Orden slave;

			// Token: 0x0400016A RID: 362
			public bool vocalizar;

			// Token: 0x0400016B RID: 363
			public string dialogoText;

			// Token: 0x0400016C RID: 364
			public DialogoInfo dialogo;

			// Token: 0x0400016D RID: 365
			private bool m_puedeMutar;

			// Token: 0x0400016E RID: 366
			private RestriccionDeEdad? m_restriccion;

			// Token: 0x0400016F RID: 367
			private int m_lastPronunciadaCount;

			// Token: 0x04000170 RID: 368
			private static StringBuilder m_TEMP = new StringBuilder();

			// Token: 0x04000171 RID: 369
			private static StringBuilder m_TEMP2 = new StringBuilder();

			// Token: 0x04000172 RID: 370
			private Dictionary<TextoPronunciable.Palabra, string> m_textoDePalabra;
		}

		// Token: 0x0200007B RID: 123
		public sealed class Estado : ControllerColaDePrioridadBase<ControlladorDeBarkDePersonalidad.Estado, ControlladorDeBarkDePersonalidad.Orden, ControlladorDeBarkDePersonalidad.Cola, ControlladorDeBarkDePersonalidad, int>.StadoBase
		{
		}

		// Token: 0x0200007C RID: 124
		public sealed class Cola : ControllerColaDePrioridadBase<ControlladorDeBarkDePersonalidad.Estado, ControlladorDeBarkDePersonalidad.Orden, ControlladorDeBarkDePersonalidad.Cola, ControlladorDeBarkDePersonalidad, int>.ColasBase
		{
		}
	}
}
