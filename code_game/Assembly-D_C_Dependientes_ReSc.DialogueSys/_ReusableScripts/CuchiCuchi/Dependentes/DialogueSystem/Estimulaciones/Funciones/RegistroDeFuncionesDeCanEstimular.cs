using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Textos;
using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Funciones
{
	// Token: 0x0200005F RID: 95
	public sealed class RegistroDeFuncionesDeCanEstimular : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000E81E File Offset: 0x0000CA1E
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000E826 File Offset: 0x0000CA26
		public static DialogoInfoParteDelCuerpo DialogoLocalParteDelCuerpo_NombreReal(ParteDelCuerpoHumano parte)
		{
			return Singleton<NombresLocalizadosDePartes>.instance.ObtenerRealDeCurrentLocalization(parte);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000E834 File Offset: 0x0000CA34
		public static DialogoInfoParteDelCuerpo DialogoLocalParteDelCuerpo(ParteDelCuerpoHumano parte, bool usarPrimero)
		{
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
			if (usarPrimero)
			{
				dialogoInfoParteDelCuerpo = Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroDeCurrentLocalization(parte);
			}
			else
			{
				dialogoInfoParteDelCuerpo = Singleton<NombresLocalizadosDePartes>.instance.ObtenerDeCurrentLocalization(parte);
			}
			return dialogoInfoParteDelCuerpo;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000E85F File Offset: 0x0000CA5F
		public static string NombreLocalizadoMutadoDeParteDelCuerpoHumano(RestriccionDeEdad restriccion, Sexo sexRestriction, ParteDelCuerpoHumano parte, bool usarPrimero)
		{
			return RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parte, usarPrimero), restriccion, sexRestriction, parte);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000E870 File Offset: 0x0000CA70
		public static string NombreLocalizadoMutadoDeParteDelCuerpoHumano(DialogoInfoParteDelCuerpo diag, RestriccionDeEdad restriccion, Sexo sexRestriction, ParteDelCuerpoHumano parte)
		{
			if (diag == null)
			{
				string text = parte.ToString();
				Debug.LogError("No se pudo hallar nombre de parte del cuerpo localizado, " + text);
				return text;
			}
			return diag.Mutado(Singleton<DiccionarioDeSinonimos>.instance.mutadorConRestriccion, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, restriccion, sexRestriction, 2);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
		public static ParteDelCuerpoHumano ObtenerParteDelCuerpoHumano(string parte)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (Enum.TryParse<ParteDelCuerpoHumano>(parte, out parteDelCuerpoHumano))
			{
				return parteDelCuerpoHumano;
			}
			Debug.LogError("No se pudo convertir string: " + parte + " a enum.");
			return ParteDelCuerpoHumano.pecho;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		public static bool TryObtenerParteDelCuerpoHumano(string parte, out ParteDelCuerpoHumano main, out ParteDelCuerpoHumano[] otras)
		{
			otras = null;
			parte = parte.Replace("\"", "");
			int num = parte.IndexOf('{');
			int num2 = parte.IndexOf('}');
			HashSet<ParteDelCuerpoHumano> hashSet = new HashSet<ParteDelCuerpoHumano>();
			string text = null;
			bool flag;
			if (num < 0 || num2 < 0)
			{
				flag = parte.TryObtenerParteDelCuerpoHumano(out main);
			}
			else
			{
				flag = parte.Substring(0, num).TryObtenerParteDelCuerpoHumano(out main);
				text = parte.Substring(num, num2 - num + 1);
			}
			if (flag)
			{
				hashSet.Add(main);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text2 = text.Replace("{", "[\"").Replace("}", "\"]").Replace(",", "\",\"");
				string text3 = "{ \"partes\" : " + text2 + "}";
				RegistroDeFuncionesDeCanEstimular.Wrapper<string> wrapper = null;
				try
				{
					wrapper = JsonUtility.FromJson<RegistroDeFuncionesDeCanEstimular.Wrapper<string>>(text3);
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
				}
				if (wrapper != null)
				{
					for (int i = 0; i < wrapper.partes.Length; i++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (wrapper.partes[i].TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
						{
							hashSet.Add(parteDelCuerpoHumano);
						}
					}
				}
			}
			otras = hashSet.ToArray<ParteDelCuerpoHumano>();
			return flag;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000EA24 File Offset: 0x0000CC24
		public static Character ObtenerCharacter(string id)
		{
			Guid guid;
			try
			{
				guid = Guid.Parse(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000EA58 File Offset: 0x0000CC58
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_RegistroDeFuncionesDeAI = DialogueManager.Instance.GetComponentInChildren<RegistroDeFuncionesDeAI>();
			if (this.m_RegistroDeFuncionesDeAI == null)
			{
				throw new ArgumentNullException("m_RegistroDeFuncionesDeAI", "m_RegistroDeFuncionesDeAI null reference.");
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000EA90 File Offset: 0x0000CC90
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<MainDialogueSystemEvents>.instance.conversacionStart += this.Instance_conversacionStart;
			Singleton<MainDialogueSystemEvents>.instance.conversacionEnd += this.Instance_conversacionEnd;
			Lua.RegisterFunction("ParteGeneralSeleccionada", this, base.GetType().GetMethod("ParteGeneralSeleccionada"));
			Lua.RegisterFunction("YourPartLocalizado", this, base.GetType().GetMethod("YourPartLocalizado"));
			Lua.RegisterFunction("MiPartLocalizado", this, base.GetType().GetMethod("MiPartLocalizado"));
			Lua.RegisterFunction("EsoCosaLocalizado", this, base.GetType().GetMethod("EsoCosaLocalizado"));
			Lua.RegisterFunction("PartLocalizado", this, base.GetType().GetMethod("PartLocalizado"));
			Lua.RegisterFunction("ChangeTextDePartesDesdeMale", this, base.GetType().GetMethod("ChangeTextDePartesDesdeMale"));
			Lua.RegisterFunction("EsConsentidoRespuestaSeraDiferente", this, base.GetType().GetMethod("EsConsentidoRespuestaSeraDiferente"));
			Lua.RegisterFunction("EstimuloEsConsentidoOffset", this, base.GetType().GetMethod("EstimuloEsConsentidoOffset"));
			Lua.RegisterFunction("EstimuloLastOffset", this, base.GetType().GetMethod("EstimuloLastOffset"));
			Lua.RegisterFunction("AskedEstimuloRegistrar", this, base.GetType().GetMethod("AskedEstimuloRegistrar"));
			Lua.RegisterFunction("RemoverEstimuloDesHieloDeSelected", this, base.GetType().GetMethod("RemoverEstimuloDesHieloDeSelected"));
			Lua.RegisterFunction("TodosEstimulosConsentidos", this, base.GetType().GetMethod("TodosEstimulosConsentidos"));
			Lua.RegisterFunction("NingunaEstimuloConsentidos", this, base.GetType().GetMethod("NingunaEstimuloConsentidos"));
			Lua.RegisterFunction("OnMultiplePreguntasConsecutivas", this, base.GetType().GetMethod("OnMultiplePreguntasConsecutivas"));
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000EC4C File Offset: 0x0000CE4C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<MainDialogueSystemEvents>.IsInScene)
			{
				Singleton<MainDialogueSystemEvents>.instance.conversacionStart -= this.Instance_conversacionStart;
				Singleton<MainDialogueSystemEvents>.instance.conversacionEnd -= this.Instance_conversacionEnd;
			}
			Lua.UnregisterFunction("ParteGeneralSeleccionada");
			Lua.UnregisterFunction("YourPartLocalizado");
			Lua.UnregisterFunction("MiPartLocalizado");
			Lua.UnregisterFunction("EsoCosaLocalizado");
			Lua.UnregisterFunction("PartLocalizado");
			Lua.UnregisterFunction("ChangeTextDePartesDesdeMale");
			Lua.UnregisterFunction("EsConsentidoRespuestaSeraDiferente");
			Lua.UnregisterFunction("EstimuloEsConsentidoOffset");
			Lua.UnregisterFunction("EstimuloLastOffset");
			Lua.UnregisterFunction("AskedEstimuloRegistrar");
			Lua.UnregisterFunction("RemoverEstimuloDesHieloDeSelected");
			Lua.UnregisterFunction("TodosEstimulosConsentidos");
			Lua.UnregisterFunction("NingunaEstimuloConsentidos");
			Lua.UnregisterFunction("OnMultiplePreguntasConsecutivas");
			this.Clear();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000ED25 File Offset: 0x0000CF25
		private void Instance_conversacionStart()
		{
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000ED27 File Offset: 0x0000CF27
		private void Clear()
		{
			this.m_actor = null;
			this.m_conversant = null;
			List<string> preguntandoMains = this.m_preguntandoMains;
			if (preguntandoMains != null)
			{
				preguntandoMains.Clear();
			}
			this.m_preguntandoMainsIndex = -1;
			ModificadorDeBool conversantPuedeConversar = this.m_conversantPuedeConversar;
			if (conversantPuedeConversar == null)
			{
				return;
			}
			conversantPuedeConversar.TryRemoverDeOwner(true);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000ED61 File Offset: 0x0000CF61
		private void Instance_conversacionEnd()
		{
			this.m_flagCheckPreguntandoFaltantes = true;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000ED6C File Offset: 0x0000CF6C
		public override void OnUpdateEvent1()
		{
			if (!this.m_flagCheckPreguntandoFaltantes)
			{
				return;
			}
			this.m_flagCheckPreguntandoFaltantes = false;
			if (this.m_preguntandoMainsIndex < 0)
			{
				this.Clear();
				return;
			}
			IReadOnlyList<int> keySelectedVariables = OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.GetKeySelectedVariables();
			int preguntandoMainsIndex = this.m_preguntandoMainsIndex;
			this.m_preguntandoMainsIndex++;
			if (!keySelectedVariables.ContieneIndexReadOnly(this.m_preguntandoMainsIndex))
			{
				this.Clear();
				return;
			}
			LuaTable luaTable = new LuaTable();
			luaTable.AddValue(new LuaString("timido"));
			luaTable.AddValue(new LuaString("extrovertido"));
			luaTable.AddValue(new LuaString("pervertido"));
			luaTable.AddValue(new LuaString("respetuoso"));
			luaTable.AddValue(new LuaString("grosero"));
			string text = this.m_RegistroDeFuncionesDeAI.MaxTipoDePersonalidad(Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID, luaTable);
			bool flag = this.m_RegistroDeFuncionesDeAI.EsDeshonesto(Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID);
			if (text == "grosero" || flag)
			{
				this.Clear();
				return;
			}
			if (this.NingunaEstimuloConsentidos() || this.TodosEstimulosConsentidos())
			{
				this.Clear();
				return;
			}
			OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.SetLastVariables(keySelectedVariables, preguntandoMainsIndex);
			OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.SetVariables(this.m_conversant.GetComponentInChildren<Personalidad>(), OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.GetTipoDeEstimuloTactil(), keySelectedVariables, this.m_preguntandoMainsIndex, this.m_actor, this.m_conversant);
			DialogueManager.Instance.StartConversation(this.conversationDeMultipleCanI, this.m_actor.bodyAnimator.transform, this.m_conversant.bodyAnimator.transform);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000EED8 File Offset: 0x0000D0D8
		public void OnMultiplePreguntasConsecutivas(string actor, string conversant)
		{
			try
			{
				this.m_actor = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(actor);
				this.m_conversant = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(conversant);
				if (this.m_actor == null)
				{
					throw new ArgumentNullException("m_actor", "m_actor null reference.");
				}
				if (this.m_conversant == null)
				{
					throw new ArgumentNullException("m_conversant", "m_conversant null reference.");
				}
				this.m_preguntandoMainsIndex = 0;
				CharacterPuedeConversar componentInChildren = this.m_conversant.GetComponentInChildren<CharacterPuedeConversar>();
				this.m_conversantPuedeConversar = ((componentInChildren != null) ? componentInChildren.puedeConversarModificable.ObtenerModificadorNotNull(this) : null);
				if (this.m_conversantPuedeConversar != null)
				{
					this.m_conversantPuedeConversar.valor.valor = false;
				}
				this.m_preguntandoMains.Clear();
				if (Application.isEditor)
				{
					foreach (int num in OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.GetKeySelectedVariables())
					{
						this.m_preguntandoMains.Add(OpcionesDeTHSDonaDeCanIDisponibles.mainSelected[num].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000F000 File Offset: 0x0000D200
		public string ParteGeneralSeleccionada(string id)
		{
			string text;
			try
			{
				float asFloat = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
				int tipoEspecifico = Convert.ToInt32(asFloat);
				Guid guid = Guid.Parse(id);
				OpcionesDeTHSDonaDeCanIDisponibles opcionesDeTHSDonaDeCanIDisponibles = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentsInChildren<OpcionesDeTHSDonaDeCanIDisponibles>().FirstOrDefault((OpcionesDeTHSDonaDeCanIDisponibles o) => o.TipoID == tipoEspecifico);
				if (opcionesDeTHSDonaDeCanIDisponibles == null)
				{
					throw new ArgumentNullException("currentOpciones", "currentOpciones null reference.");
				}
				int num = opcionesDeTHSDonaDeCanIDisponibles.selectedKeys.Last<int>();
				text = OpcionesDeTHSDonaDeCanIDisponibles.opciones[num].ToLowerInvariant();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000F0B4 File Offset: 0x0000D2B4
		public string EsoCosaLocalizado(string parteString)
		{
			string text;
			try
			{
				text = ObtenerDialogosUtil.ObtenerEsoCosa(RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(parteString), false).plural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000F0FC File Offset: 0x0000D2FC
		public string YourPartLocalizado(string id, string parteString)
		{
			string text2;
			try
			{
				Character character = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id);
				ParteDelCuerpoHumano parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(parteString);
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parteDelCuerpoHumano, false);
				string text;
				if (character is FemaleChar)
				{
					Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), Sexo.noDefinido, parteDelCuerpoHumano);
				}
				else
				{
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.noDefinido, parteDelCuerpoHumano);
				}
				text2 = ObtenerDialogosUtil.ObtenerPosesivoSegundaPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.dada) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000F1B8 File Offset: 0x0000D3B8
		public string MiPartLocalizado(string id, string parteString)
		{
			string text2;
			try
			{
				Character character = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id);
				ParteDelCuerpoHumano parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(parteString);
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parteDelCuerpoHumano, false);
				string text;
				if (character is FemaleChar)
				{
					Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), Sexo.noDefinido, parteDelCuerpoHumano);
				}
				else
				{
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.noDefinido, parteDelCuerpoHumano);
				}
				text2 = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000F274 File Offset: 0x0000D474
		public string PartLocalizado(string id, string parteString)
		{
			string text2;
			try
			{
				Character character = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id);
				ParteDelCuerpoHumano parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(parteString);
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parteDelCuerpoHumano, false);
				string text;
				if (character is FemaleChar)
				{
					Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), Sexo.noDefinido, parteDelCuerpoHumano);
				}
				else
				{
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.noDefinido, parteDelCuerpoHumano);
				}
				text2 = text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000F318 File Offset: 0x0000D518
		[Obsolete("", true)]
		public void AskedTouchPartMany(string id, float currentOffset, LuaTable seleccion)
		{
			try
			{
				if (seleccion.Length != 0)
				{
					List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(seleccion.Length);
					using (IEnumerator<LuaValue> enumerator = seleccion.ListValues.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
							{
								list.Add(parteDelCuerpoHumano);
							}
						}
					}
					if (list.Count != 0)
					{
						RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id).GetComponentInChildrenNotNull<MemoriaDeRegistroDeCanI>().RegistrarCaressOffset(list, currentOffset);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000F3C0 File Offset: 0x0000D5C0
		[Obsolete("", true)]
		public void RemoverCaressDesHieloDeSelected(string id, LuaTable seleccion)
		{
			try
			{
				if (seleccion.Length != 0)
				{
					List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(seleccion.Length);
					using (IEnumerator<LuaValue> enumerator = seleccion.ListValues.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
							{
								list.Add(parteDelCuerpoHumano);
							}
						}
					}
					if (list.Count != 0)
					{
						DesHielo componentInChildrenNotNull = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id).GetComponentInChildrenNotNull<DesHielo>();
						for (int i = 0; i < list.Count; i++)
						{
							componentInChildrenNotNull.SetTactilTo(100f, list[i], DireccionDeEstimulo.recibida, TipoDeEstimuloTactil.caricia);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000F490 File Offset: 0x0000D690
		[Obsolete("", true)]
		public bool TodosCaressConsentidos(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id).GetComponentInChildren<ConsentNecesario>().TodosConsentidosSinJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000F4DC File Offset: 0x0000D6DC
		[Obsolete("", true)]
		public bool NingunaCaressConsentidos(string id)
		{
			bool flag;
			try
			{
				flag = !RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id).GetComponentInChildren<ConsentNecesario>().AlgunoConsentidoSinJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000F528 File Offset: 0x0000D728
		[Obsolete("", true)]
		public float CaressEsConsentidoOffset(string id, LuaTable partes)
		{
			float num;
			try
			{
				List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(partes.Length);
				using (IEnumerator<LuaValue> enumerator = partes.ListValues.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
						{
							list.Add(parteDelCuerpoHumano);
						}
					}
				}
				if (list.Count == 0)
				{
					num = 0f;
				}
				else
				{
					ConsentNecesario componentInChildren = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id).GetComponentInChildren<ConsentNecesario>();
					if (componentInChildren == null)
					{
						throw new ArgumentNullException("consentNecesario", "consentNecesario null reference.");
					}
					float num2 = float.MaxValue;
					foreach (ParteDelCuerpoHumano parteDelCuerpoHumano2 in list)
					{
						float num3;
						float num4;
						componentInChildren.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, ParteQuePuedeEstimular.manos, out num3, out num4, 1f, null, null, null);
						num2 = Mathf.Min(num2, num3);
					}
					num = num2;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0f;
			}
			return num;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000F658 File Offset: 0x0000D858
		[Obsolete("", true)]
		public float CaressLastOffset(string id, LuaTable partes)
		{
			float num;
			try
			{
				List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(partes.Length);
				using (IEnumerator<LuaValue> enumerator = partes.ListValues.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
						{
							list.Add(parteDelCuerpoHumano);
						}
					}
				}
				if (list.Count == 0)
				{
					num = 0f;
				}
				else
				{
					num = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(id).GetComponentInChildrenNotNull<MemoriaDeRegistroDeCanI>().ObtenerCaressOffsetRegistrado(list);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0f;
			}
			return num;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000F704 File Offset: 0x0000D904
		public bool EsConsentidoRespuestaSeraDiferente(float last, float current)
		{
			bool flag;
			try
			{
				if (last < 0f)
				{
					flag = false;
				}
				else if (last < 0.8f && current >= 0.8f)
				{
					flag = true;
				}
				else if (last >= 0.8f && last < 0.95f && (current >= 0.95f || current < 0.8f))
				{
					flag = true;
				}
				else if (last >= 0.95f && last < 1.05f && (current >= 1.05f || current < 0.95f))
				{
					flag = true;
				}
				else if (last >= 1.05f && last < 1.25f && (current >= 1.25f || current < 1.05f))
				{
					flag = true;
				}
				else if (last >= 1.25f && current < 1.25f)
				{
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000F7D8 File Offset: 0x0000D9D8
		public float EstimuloEsConsentidoOffset(LuaTable partes)
		{
			float num;
			try
			{
				string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
				float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
				float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
				TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
				ParteQuePuedeEstimular parteQuePuedeEstimular = Convert.ToInt32(asFloat2).ObtenerEstimulanteDeTipoDeEstimuloEspecifico(tipoDeEstimulo);
				List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(partes.Length);
				using (IEnumerator<LuaValue> enumerator = partes.ListValues.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
						{
							list.Add(parteDelCuerpoHumano);
						}
					}
				}
				if (list.Count == 0)
				{
					num = 0f;
				}
				else
				{
					ConsentNecesario componentInChildren = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(lastConversantID).GetComponentInChildren<ConsentNecesario>();
					if (componentInChildren == null)
					{
						throw new ArgumentNullException("consentNecesario", "consentNecesario null reference.");
					}
					float num2 = float.MaxValue;
					foreach (ParteDelCuerpoHumano parteDelCuerpoHumano2 in list)
					{
						float num3;
						float num4;
						componentInChildren.EsConsentidoConJerarquia(tipoDeEstimulo, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular, out num3, out num4, 1f, null, null, null);
						num2 = Mathf.Min(num2, num3);
					}
					num = num2;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0f;
			}
			return num;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000F980 File Offset: 0x0000DB80
		public float EstimuloLastOffset(LuaTable partes)
		{
			float num2;
			try
			{
				string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
				float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
				float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
				TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
				int num = Convert.ToInt32(asFloat2);
				List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(partes.Length);
				using (IEnumerator<LuaValue> enumerator = partes.ListValues.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
						{
							list.Add(parteDelCuerpoHumano);
						}
					}
				}
				if (list.Count == 0)
				{
					num2 = 0f;
				}
				else
				{
					num2 = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(lastConversantID).GetComponentInChildrenNotNull<MemoriaDeRegistroDeCanI>().ObtenerEstimuloOffsetRegistrado(list, tipoDeEstimulo, num);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num2 = 0f;
			}
			return num2;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000FA7C File Offset: 0x0000DC7C
		public void AskedEstimuloRegistrar(float currentOffset, LuaTable seleccion)
		{
			try
			{
				if (seleccion.Length != 0)
				{
					string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
					float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
					float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
					TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
					int num = Convert.ToInt32(asFloat2);
					List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(seleccion.Length);
					using (IEnumerator<LuaValue> enumerator = seleccion.ListValues.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
							{
								list.Add(parteDelCuerpoHumano);
							}
						}
					}
					if (list.Count != 0)
					{
						RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(lastConversantID).GetComponentInChildrenNotNull<MemoriaDeRegistroDeCanI>().RegistrarEstimuloffset(list, tipoDeEstimulo, num, currentOffset);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000FB74 File Offset: 0x0000DD74
		public void RemoverEstimuloDesHieloDeSelected(LuaTable seleccion)
		{
			try
			{
				if (seleccion.Length != 0)
				{
					string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
					float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
					float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
					TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
					Convert.ToInt32(asFloat2);
					List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>(seleccion.Length);
					using (IEnumerator<LuaValue> enumerator = seleccion.ListValues.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
							{
								list.Add(parteDelCuerpoHumano);
							}
						}
					}
					if (list.Count != 0)
					{
						DesHielo componentInChildrenNotNull = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(lastConversantID).GetComponentInChildrenNotNull<DesHielo>();
						for (int i = 0; i < list.Count; i++)
						{
							if (tipoDeEstimulo != TipoDeEstimulo.tactil)
							{
								if (tipoDeEstimulo != TipoDeEstimulo.visual)
								{
									if (tipoDeEstimulo != TipoDeEstimulo.coital)
									{
										throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
									}
									componentInChildrenNotNull.SetCoitalTo(100f, list[i], DireccionDeEstimulo.recibida, (TipoDeEstimuloCoital)asFloat2);
								}
								else
								{
									componentInChildrenNotNull.SetVisualTo(100f, list[i], DireccionDeEstimulo.recibida, (TipoDeEstimuloVisual)asFloat2);
								}
							}
							else
							{
								componentInChildrenNotNull.SetTactilTo(100f, list[i], DireccionDeEstimulo.recibida, (TipoDeEstimuloTactil)asFloat2);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		public bool TodosEstimulosConsentidos()
		{
			bool flag;
			try
			{
				string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
				float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
				float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
				TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
				int num = Convert.ToInt32(asFloat2);
				flag = RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(lastConversantID).GetComponentInChildren<ConsentNecesario>().TodosConsentidosSinJerarquia(tipoDeEstimulo, DireccionDeEstimulo.recibida, num.ObtenerEstimulanteDeTipoDeEstimuloEspecifico(tipoDeEstimulo), null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000FD8C File Offset: 0x0000DF8C
		public bool NingunaEstimuloConsentidos()
		{
			bool flag;
			try
			{
				string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
				float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
				float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
				TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
				int num = Convert.ToInt32(asFloat2);
				flag = !RegistroDeFuncionesDeCanEstimular.ObtenerCharacter(lastConversantID).GetComponentInChildren<ConsentNecesario>().AlgunoConsentidoSinJerarquia(tipoDeEstimulo, DireccionDeEstimulo.recibida, num.ObtenerEstimulanteDeTipoDeEstimuloEspecifico(tipoDeEstimulo), null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000FE20 File Offset: 0x0000E020
		public void ChangeTextDePartesDesdeMale()
		{
			try
			{
				Action<DialogueEntry, ParteDelCuerpoHumano[], ParteDelCuerpoHumano> action = delegate(DialogueEntry diag, ParteDelCuerpoHumano[] partes, ParteDelCuerpoHumano main)
				{
					if (partes.Length == 1)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = partes[0];
						string text = string.Concat(new string[]
						{
							"Variable[\"PARTE_SELEC_MAIN\"]=\"",
							main.ToString(),
							"\";\nVariable[\"PARTES_SELEC\"]={\"",
							parteDelCuerpoHumano.ToString(),
							"\"};"
						});
						diag.userScript = text;
						return;
					}
					if (partes.Length > 1)
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < partes.Length; i++)
						{
							stringBuilder.Append('"');
							stringBuilder.Append(partes[i].ToString());
							stringBuilder.Append('"');
							if (!i.IsLastIndex(partes.Length))
							{
								stringBuilder.Append(',');
							}
						}
						StringBuilder stringBuilder2 = new StringBuilder();
						stringBuilder2.Append('{');
						stringBuilder2.Append(stringBuilder);
						stringBuilder2.Append('}');
						string text2 = stringBuilder2.ToString();
						string text3 = string.Concat(new string[]
						{
							"Variable[\"PARTE_SELEC_MAIN\"]=\"",
							main.ToString(),
							"\";\nVariable[\"PARTES_SELEC\"]=",
							text2,
							";"
						});
						diag.userScript = text3;
					}
				};
				ConversationState currentConversationState = DialogueManager.CurrentConversationState;
				this.ChangeParteText(currentConversationState.subtitle.dialogueEntry, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.noDefinido, true, action);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000FE94 File Offset: 0x0000E094
		private void ChangeParteText(DialogueEntry entry, RestriccionDeEdad restriccion, Sexo sexRestriction, bool enLaMismaConversacion, Action<DialogueEntry, ParteDelCuerpoHumano[], ParteDelCuerpoHumano> onChanged)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry", "entry null reference.");
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			ParteDelCuerpoHumano[] array;
			if (PixelCrushers.DialogueSystem.Field.FieldExists(entry.fields, "ParteDelCuerpoHumano") && RegistroDeFuncionesDeCanEstimular.TryObtenerParteDelCuerpoHumano(entry.Title, out parteDelCuerpoHumano, out array))
			{
				string text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(restriccion, sexRestriction, parteDelCuerpoHumano, false);
				text = text.FirstLetterOrDefaultToUpperCaseOthersToLower();
				entry.DefaultMenuText = text;
				entry.MenuText = text;
				entry.LocalizedMenuText = text;
				entry.DefaultDialogueText = "...";
				entry.DialogueText = "...";
				entry.LocalizedDialogueText = "...";
				if (onChanged != null)
				{
					onChanged(entry, array, parteDelCuerpoHumano);
				}
			}
			int conversationID = entry.conversationID;
			for (int i = 0; i < entry.outgoingLinks.Count; i++)
			{
				Link link = entry.outgoingLinks[i];
				if (!enLaMismaConversacion || link.destinationConversationID == conversationID)
				{
					DialogueEntry dialogueEntry = DialogueManager.MasterDatabase.GetDialogueEntry(link.destinationConversationID, link.destinationDialogueID);
					this.ChangeParteText(dialogueEntry, restriccion, sexRestriction, enLaMismaConversacion, onChanged);
				}
			}
		}

		// Token: 0x04000130 RID: 304
		private RegistroDeFuncionesDeAI m_RegistroDeFuncionesDeAI;

		// Token: 0x04000131 RID: 305
		[ConversationPopup(false)]
		public string conversationDeMultipleCanI;

		// Token: 0x04000132 RID: 306
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagCheckPreguntandoFaltantes;

		// Token: 0x04000133 RID: 307
		[ReadOnlyUI]
		[SerializeField]
		private int m_preguntandoMainsIndex = -1;

		// Token: 0x04000134 RID: 308
		[ReadOnlyUI]
		[SerializeField]
		private List<string> m_preguntandoMains = new List<string>();

		// Token: 0x04000135 RID: 309
		[ReadOnlyUI]
		[SerializeField]
		private Character m_actor;

		// Token: 0x04000136 RID: 310
		[ReadOnlyUI]
		[SerializeField]
		private Character m_conversant;

		// Token: 0x04000137 RID: 311
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeBool m_conversantPuedeConversar;

		// Token: 0x02000095 RID: 149
		[Serializable]
		private class Wrapper<T>
		{
			// Token: 0x040001B9 RID: 441
			public T[] partes;
		}
	}
}
