using System;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Auras;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Trabajos
{
	// Token: 0x02000102 RID: 258
	public class RegistroDeFuncionesDeContratacionDeModelos : CustomMonobehaviour
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x00030D48 File Offset: 0x0002EF48
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("CurrentModelIsHired", this, base.GetType().GetMethod("CurrentModelIsHired"));
			Lua.RegisterFunction("HireCurrentModel", this, base.GetType().GetMethod("HireCurrentModel"));
			Lua.RegisterFunction("GetSalaryOfferAceptanceW", this, base.GetType().GetMethod("GetSalaryOfferAceptanceW"));
			Lua.RegisterFunction("ResetHiringVariables", this, base.GetType().GetMethod("ResetHiringVariables"));
			Lua.RegisterFunction("SetSalarioResultToEmplyerOffer", this, base.GetType().GetMethod("SetSalarioResultToEmplyerOffer"));
			Lua.RegisterFunction("SetSalarioResultToModelOffer", this, base.GetType().GetMethod("SetSalarioResultToModelOffer"));
			Lua.RegisterFunction("GetComisionOfferAceptanceW", this, base.GetType().GetMethod("GetComisionOfferAceptanceW"));
			Lua.RegisterFunction("SetComisionResultToEmplyerOffer", this, base.GetType().GetMethod("SetComisionResultToEmplyerOffer"));
			Lua.RegisterFunction("SetComisionResultToModelOffer", this, base.GetType().GetMethod("SetComisionResultToModelOffer"));
			Lua.RegisterFunction("DesistHiring", this, base.GetType().GetMethod("DesistHiring"));
			Lua.RegisterFunction("FireCurrentModel", this, base.GetType().GetMethod("FireCurrentModel"));
			Lua.RegisterFunction("ModeloIsSorryForFired", this, base.GetType().GetMethod("ModeloIsSorryForFired"));
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00030EA0 File Offset: 0x0002F0A0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("CurrentModelIsHired");
			Lua.UnregisterFunction("HireCurrentModel");
			Lua.UnregisterFunction("GetSalaryOfferAceptanceW");
			Lua.UnregisterFunction("ResetHiringVariables");
			Lua.UnregisterFunction("SetSalarioResultToEmplyerOffer");
			Lua.UnregisterFunction("SetSalarioResultToModelOffer");
			Lua.UnregisterFunction("GetComisionOfferAceptanceW");
			Lua.UnregisterFunction("SetComisionResultToEmplyerOffer");
			Lua.UnregisterFunction("SetComisionResultToModelOffer");
			Lua.UnregisterFunction("DesistHiring");
			Lua.UnregisterFunction("FireCurrentModel");
			Lua.UnregisterFunction("ModeloIsSorryForFired");
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00030F2C File Offset: 0x0002F12C
		private FemaleChar GetcurrentFemaleCharacterFromOfficeActividad()
		{
			return ((ActividadConMaleAndFemaleCharacter)Actividad.running).currentFemaleCharacter;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00030F3D File Offset: 0x0002F13D
		private MaleChar GetcurrentMaleCharacterFromOfficeActividad()
		{
			return Singleton<ActividadesManager>.instance.current.mainPlayerCharacter as MaleChar;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00030F53 File Offset: 0x0002F153
		private FemaleCharacterModelo GetcurrentFemaleCharacterModeloFromOfficeActividad()
		{
			return ((ActividadConMaleAndFemaleCharacter)Actividad.running).currentFemaleCharacter.GetComponentInChildren<FemaleCharacterModelo>();
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00030F69 File Offset: 0x0002F169
		private Texture2D GetPortraitFromOfficeActividad()
		{
			SelfPortraitCamera componentInChildren = this.GetcurrentFemaleCharacterFromOfficeActividad().GetComponentInChildren<SelfPortraitCamera>();
			if (componentInChildren == null)
			{
				return null;
			}
			return componentInChildren.TakeFemalePortrait();
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00030F84 File Offset: 0x0002F184
		public void ResetHiringVariables()
		{
			try
			{
				DialogueLua.SetVariable("SALARIO_OFERTA", -1f);
				DialogueLua.SetVariable("SALARIO_CONTRA_OFERTA", -1f);
				DialogueLua.SetVariable("SALARIO_DEFECTO", -1f);
				DialogueLua.SetVariable("SALARIO_RESULT", -1f);
				DialogueLua.SetVariable("COMISION_OFERTA", -1f);
				DialogueLua.SetVariable("COMISION_CONTRA_OFERTA", -1f);
				DialogueLua.SetVariable("COMISION_DEFECTO", -1f);
				DialogueLua.SetVariable("COMISION_RESULT", -1f);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0003104C File Offset: 0x0002F24C
		public void SetComisionResultToEmplyerOffer()
		{
			try
			{
				float asFloat = DialogueLua.GetVariable("COMISION_OFERTA").AsFloat;
				DialogueLua.SetVariable("COMISION_RESULT", asFloat);
				BuffDeCharacter componentInChildren = this.GetcurrentFemaleCharacterFromOfficeActividad().GetComponentInChildren<BuffDeCharacter>();
				if (componentInChildren == null)
				{
					Debug.LogException(new ArgumentNullException("bufable", "bufable null reference."), this);
				}
				float desiredComisionByPobrezaYAvaricia = this.GetcurrentFemaleCharacterModeloFromOfficeActividad().GetDesiredComisionByPobrezaYAvaricia();
				MaleChar maleChar = this.GetcurrentMaleCharacterFromOfficeActividad();
				int num = Mathf.RoundToInt(asFloat - desiredComisionByPobrezaYAvaricia);
				if (num > 0)
				{
					num = Mathf.Clamp(num, 1, 10);
					BuffMap map = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.FavorabilityByCommission");
					if (map == null)
					{
						Debug.LogException(new ArgumentNullException("map", "map null reference."));
					}
					Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
					BuffOnFavorabilityTowardCharacterValueArg buffOnFavorabilityTowardCharacterValueArg;
					if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnFavorabilityTowardCharacterValueArg>(efecto.argumentoID, out buffOnFavorabilityTowardCharacterValueArg))
					{
						Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
					}
					buffOnFavorabilityTowardCharacterValueArg.towardID = maleChar.ID_UnicoString;
					buffOnFavorabilityTowardCharacterValueArg.add = (float)num;
					DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, maleChar.ID_UnicoString, buffOnFavorabilityTowardCharacterValueArg, null);
					if (eventoBuff == null)
					{
						Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
					}
					eventoBuff.showSmallMsgOnStart = true;
					eventoBuff.showSmallMsgOnEnd = true;
					componentInChildren.eventos.AddOrStackUp(eventoBuff, false, false);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x000311DC File Offset: 0x0002F3DC
		public void SetComisionResultToModelOffer()
		{
			try
			{
				DialogueLua.SetVariable("COMISION_RESULT", DialogueLua.GetVariable("COMISION_CONTRA_OFERTA").AsFloat);
				throw new NotSupportedException("ya no es necesario, ahora la oferta de la female se pasa a la male");
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00031230 File Offset: 0x0002F430
		public void SetSalarioResultToEmplyerOffer()
		{
			try
			{
				float asFloat = DialogueLua.GetVariable("SALARIO_OFERTA").AsFloat;
				DialogueLua.SetVariable("SALARIO_RESULT", asFloat);
				float desiredSalaryByPobrezaYAvaricia = this.GetcurrentFemaleCharacterModeloFromOfficeActividad().GetDesiredSalaryByPobrezaYAvaricia();
				MaleChar maleChar = this.GetcurrentMaleCharacterFromOfficeActividad();
				float num = asFloat / desiredSalaryByPobrezaYAvaricia;
				BuffDeCharacter componentInChildren = this.GetcurrentFemaleCharacterFromOfficeActividad().GetComponentInChildren<BuffDeCharacter>();
				if (componentInChildren == null)
				{
					Debug.LogException(new ArgumentNullException("bufable", "bufable null reference."), this);
				}
				if (num > 1f)
				{
					float num2 = Mathf.InverseLerp(1f, 10f, num);
					num2 = num2.OutPow(3f);
					float num3 = Mathf.Lerp(0f, 35f, num2);
					BuffMap map = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.FavorabilityBySalary");
					if (map == null)
					{
						Debug.LogException(new ArgumentNullException("map", "map null reference."));
					}
					Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
					BuffOnFavorabilityTowardCharacterValueArg buffOnFavorabilityTowardCharacterValueArg;
					if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnFavorabilityTowardCharacterValueArg>(efecto.argumentoID, out buffOnFavorabilityTowardCharacterValueArg))
					{
						Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
					}
					buffOnFavorabilityTowardCharacterValueArg.towardID = maleChar.ID_UnicoString;
					buffOnFavorabilityTowardCharacterValueArg.add = num3;
					DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, maleChar.ID_UnicoString, buffOnFavorabilityTowardCharacterValueArg, null);
					if (eventoBuff == null)
					{
						Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
					}
					eventoBuff.showSmallMsgOnStart = true;
					eventoBuff.showSmallMsgOnEnd = true;
					componentInChildren.eventos.AddOrStackUp(eventoBuff, false, false);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000313E8 File Offset: 0x0002F5E8
		public void SetSalarioResultToModelOffer()
		{
			try
			{
				DialogueLua.SetVariable("SALARIO_RESULT", DialogueLua.GetVariable("SALARIO_CONTRA_OFERTA").AsFloat);
				throw new NotSupportedException("ya no es necesario, ahora la oferta de la female se pasa a la male");
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0003143C File Offset: 0x0002F63C
		public float GetComisionOfferAceptanceW()
		{
			float num4;
			try
			{
				float desiredComisionByPobrezaYAvaricia = this.GetcurrentFemaleCharacterModeloFromOfficeActividad().GetDesiredComisionByPobrezaYAvaricia();
				float asFloat = DialogueLua.GetVariable("COMISION_OFERTA").AsFloat;
				float num = DialogueLua.GetVariable("COMISION_CONTRA_OFERTA").AsFloat;
				float num2 = asFloat / desiredComisionByPobrezaYAvaricia;
				if (num2 < 0.8f)
				{
					if (num <= 0f)
					{
						num = (float)Mathf.RoundToInt((desiredComisionByPobrezaYAvaricia / 100f).OutPow(2f) * 100f);
						DialogueLua.SetVariable("COMISION_CONTRA_OFERTA", num);
					}
					else
					{
						float num3 = (desiredComisionByPobrezaYAvaricia * 0.8f / 100f).OutPow(2f) * 100f;
						num = Mathf.Lerp(desiredComisionByPobrezaYAvaricia * 0.8f, num3, (1f - num2).InPow(2f));
						num = (float)Mathf.RoundToInt(num);
						DialogueLua.SetVariable("COMISION_CONTRA_OFERTA", num);
					}
				}
				DialogueLua.SetVariable("COMISION_DEFECTO", asFloat + 1f);
				num4 = num2;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num4 = 0f;
			}
			return num4;
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00031558 File Offset: 0x0002F758
		public float GetSalaryOfferAceptanceW()
		{
			float num3;
			try
			{
				float desiredSalaryByPobrezaYAvaricia = this.GetcurrentFemaleCharacterModeloFromOfficeActividad().GetDesiredSalaryByPobrezaYAvaricia();
				float asFloat = DialogueLua.GetVariable("SALARIO_OFERTA").AsFloat;
				float num = DialogueLua.GetVariable("SALARIO_CONTRA_OFERTA").AsFloat;
				float num2 = asFloat / desiredSalaryByPobrezaYAvaricia;
				if (num2 < 0.8f)
				{
					if (num <= 0f)
					{
						num = desiredSalaryByPobrezaYAvaricia * 2f;
						DialogueLua.SetVariable("SALARIO_CONTRA_OFERTA", num);
					}
					else
					{
						num = Mathf.Lerp(desiredSalaryByPobrezaYAvaricia * 0.8f, desiredSalaryByPobrezaYAvaricia * 0.8f * 2f, (1f - num2).InPow(2f));
						num = Mathf.Round(num / 5f) * 5f;
						DialogueLua.SetVariable("SALARIO_CONTRA_OFERTA", num);
					}
				}
				DialogueLua.SetVariable("SALARIO_DEFECTO", asFloat + 5f);
				num3 = num2;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num3 = 0f;
			}
			return num3;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00031654 File Offset: 0x0002F854
		public bool CurrentModelIsHired()
		{
			bool flag;
			try
			{
				SMAGameplayController instance = Singleton<SMAGameplayController>.instance;
				string text = this.GetcurrentFemaleCharacterFromOfficeActividad().ID_Unico.ToString();
				flag = instance.IsHired(text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000316A4 File Offset: 0x0002F8A4
		public void DesistHiring()
		{
			try
			{
				this.RemoveBuffBySalary();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000316D4 File Offset: 0x0002F8D4
		private void RemoveBuffBySalary()
		{
			Component component = this.GetcurrentFemaleCharacterFromOfficeActividad();
			MaleChar maleChar = this.GetcurrentMaleCharacterFromOfficeActividad();
			BuffDeCharacter componentInChildren = component.GetComponentInChildren<BuffDeCharacter>();
			if (componentInChildren == null)
			{
				Debug.LogException(new ArgumentNullException("bufable", "bufable null reference."), this);
			}
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityBySalary", maleChar.ID_UnicoString);
			string text2 = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByCommission", maleChar.ID_UnicoString);
			componentInChildren.eventos.Remove(text);
			componentInChildren.eventos.Remove(text2);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0003174C File Offset: 0x0002F94C
		public void HireCurrentModel()
		{
			try
			{
				SMAGameplayController instance = Singleton<SMAGameplayController>.instance;
				FemaleChar femaleChar = this.GetcurrentFemaleCharacterFromOfficeActividad();
				string text = femaleChar.ID_Unico.ToString();
				float asFloat = DialogueLua.GetVariable("COMISION_RESULT").AsFloat;
				float asFloat2 = DialogueLua.GetVariable("SALARIO_RESULT").AsFloat;
				if (!instance.TryHire(text, asFloat2, asFloat, this.GetPortraitFromOfficeActividad(), true, femaleChar))
				{
					ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarConfirmacion();
					dialog.SetPreguntaText("It was not possible to hire this model.");
					dialog.noMostrarOtraVezToggle.interactable = false;
					dialog.cancelar.gameObject.SetActive(false);
					dialog.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
					});
				}
				else
				{
					EntrevistaScoreFemaleFromPool entrevistaScoreFemaleFromPool = Actividad.running as EntrevistaScoreFemaleFromPool;
					if (entrevistaScoreFemaleFromPool == null)
					{
						Debug.LogError("modelo contratada, pero no se pudo finalizar campaing, actividad instance es invalida");
					}
					else
					{
						entrevistaScoreFemaleFromPool.FlagModelWasHired();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00031870 File Offset: 0x0002FA70
		public bool ModeloIsSorryForFired()
		{
			bool flag2;
			try
			{
				MaleChar maleChar = this.GetcurrentMaleCharacterFromOfficeActividad();
				ICharacterKarma componentEnRoot = maleChar.GetComponentEnRoot<ICharacterKarma>();
				componentEnRoot.UpdateValor();
				float valor = componentEnRoot.valor;
				bool flag = valor < 0f;
				float num = Mathf.Abs(valor) / 100f;
				FemaleChar femaleChar = this.GetcurrentFemaleCharacterFromOfficeActividad();
				ConcentToHeroMinimoDeFemale componentEnRoot2 = femaleChar.GetComponentEnRoot<ConcentToHeroMinimoDeFemale>();
				ConsentToHero componentEnRoot3 = femaleChar.GetComponentEnRoot<ConsentToHero>();
				Component componentEnRoot4 = femaleChar.GetComponentEnRoot<Rage>();
				EmocionHacia componentNotNull = componentEnRoot3.GetComponentNotNull<EmocionHacia>();
				EmocionHacia componentNotNull2 = componentEnRoot4.GetComponentNotNull<EmocionHacia>();
				float num2 = componentEnRoot2.total + componentNotNull.EstimadoPara(maleChar.ID_UnicoString);
				float num3 = componentNotNull2.EstimadoPara(maleChar.ID_UnicoString);
				float num4 = num2 * (flag ? 1f : num);
				num3 *= (flag ? num : 1f);
				flag2 = num4 - num3 > 0f;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00031940 File Offset: 0x0002FB40
		public void FireCurrentModel()
		{
			try
			{
				SMAGameplayController instance = Singleton<SMAGameplayController>.instance;
				FemaleChar femaleChar = this.GetcurrentFemaleCharacterFromOfficeActividad();
				string text = femaleChar.ID_Unico.ToString();
				float num;
				if (!instance.TryFire(text, out num))
				{
					ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarConfirmacion();
					dialog.SetPreguntaText("It was not possible to fire this model.");
					dialog.noMostrarOtraVezToggle.interactable = false;
					dialog.cancelar.gameObject.SetActive(false);
					dialog.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
					});
				}
				else
				{
					this.RemoveBuffBySalary();
					MeetingHiredFemaleModel meetingHiredFemaleModel = Actividad.running as MeetingHiredFemaleModel;
					if (meetingHiredFemaleModel == null)
					{
						Debug.LogError("actividad instance es invalida");
					}
					else
					{
						meetingHiredFemaleModel.FlagModelWasFired();
						CharacterWallet componentEnRoot = this.GetcurrentMaleCharacterFromOfficeActividad().GetComponentEnRoot<CharacterWallet>();
						DateTime now = Singleton<TiempoDeJuego>.instance.now;
						DateTime dateTime = now.Next(DayOfWeek.Friday);
						DateTime dateTime2 = now.Last(DayOfWeek.Monday);
						int num2 = (int)Math.Ceiling((now - dateTime2).TotalDays);
						int num3 = (int)Math.Ceiling((dateTime - now).TotalDays);
						float num4 = num / 5f;
						float num5 = (float)num2 * num4;
						float num6 = (float)num2 * 0.5f * (float)num3;
						componentEnRoot.Change("fiat", -(num5 + num6), femaleChar.nombreCompleto);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}
	}
}
