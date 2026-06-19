using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x02000237 RID: 567
	public sealed class ControlladorDeGestosFacialesEmocionales : ControllerColaDePrioridadBase<ControlladorDeGestosFacialesEmocionales.Estado, ControlladorDeGestosFacialesEmocionales.Orden, ControlladorDeGestosFacialesEmocionales.Cola, ControlladorDeGestosFacialesEmocionales, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion>
	{
		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x0003AB06 File Offset: 0x00038D06
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdate1);
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public override int updateEvent2Index
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0003AB11 File Offset: 0x00038D11
		public ControlladorDeGestosFacialesEmocionales.BocaConfig bocaConfig
		{
			get
			{
				return this.m_BocaConfig;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x0003AB19 File Offset: 0x00038D19
		public ControlladorDeGestosFacialesEmocionales.Config config
		{
			get
			{
				return this.m_Config;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x0003AB21 File Offset: 0x00038D21
		protected override int cantidadDeEstados
		{
			get
			{
				if (this.m_cantidadDeEstados == null)
				{
					this.m_cantidadDeEstados = new int?(typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumCount());
				}
				return this.m_cantidadDeEstados.Value;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x0003AB55 File Offset: 0x00038D55
		public ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues expresionsXYValues
		{
			get
			{
				return this.m_ExpresionsXYValues;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x0003AB5D File Offset: 0x00038D5D
		public ControlladorDeGestosFacialesEmocionales.ExpresionsValuesBoca expresionsValuesBoca
		{
			get
			{
				return this.m_ExpresionsValuesBoca;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x0003AB68 File Offset: 0x00038D68
		public float usarBocaProcMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.muecas);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 33f;
				case HumanTraitScore.alto:
					return 49.5f;
				case HumanTraitScore.muyAlto:
					return 66f;
				case HumanTraitScore.bajo:
					return 22f;
				case HumanTraitScore.muyBajo:
					return 16.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0003ABD0 File Offset: 0x00038DD0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Personalidad = this.GetComponentEnCharacter(false);
			this.m_suprimidos.Clear();
			this.m_exagerados.Clear();
			foreach (int num in typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumValoresInt())
			{
				this.m_suprimidos.Add(num, new ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted
				{
					tipo = (ControlladorDeGestosFacialesEmocionales.TipoDeExpresion)num,
					weight = 0f
				});
				this.m_exagerados.Add(num, new ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued
				{
					tipo = (ControlladorDeGestosFacialesEmocionales.TipoDeExpresion)num,
					weight = 0f,
					minValue = 0f
				});
			}
			this.m_CharacterHablador = this.GetComponentEnRoot(false);
			if (this.m_CharacterHablador == null)
			{
				throw new ArgumentNullException("m_CharacterHablador", "m_CharacterHablador null reference.");
			}
			this.m_IControladorDeGestosDeBoca = this.GetComponentEnRoot(false);
			if (this.m_IControladorDeGestosDeBoca == null)
			{
				throw new ArgumentNullException("m_IControladorDeGestosDeBoca", "m_IControladorDeGestosDeBoca null reference.");
			}
			this.m_Animator = base.GetComponentInParent<Character>().headAnimator;
			this.m_AnimatorValues.Init(this);
			this.m_DefaultValues.Init(this);
			this.m_UserValues.Init(this);
			this.m_ExpresionsValuesBoca.Init(this);
			this.m_ExpresionsXYValues.Init(this);
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0003AD30 File Offset: 0x00038F30
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.m_DefaultValues.SendValueToAnimator();
			}
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0003AD4B File Offset: 0x00038F4B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_DefaultValues.SendValueToAnimator();
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x000224C1 File Offset: 0x000206C1
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0003AD60 File Offset: 0x00038F60
		public override void OnUpdateEvent2()
		{
			if (!this.m_usaraBocaPorPersonalidadCoolDown.isOn)
			{
				this.m_usaraBocaPorPersonalidad = this.usarBocaProcMod.ProcPorSegundoV2(ref this.m_lastBocaTickChance, ref this.m_lastBocaProcTimeChance, this.m_usaraBocaPorPersonalidadCoolDown.current, 1f);
				this.m_usaraBocaPorPersonalidadCoolDown.Apply();
			}
			this.m_AnimatorValues.Convinar(this.m_DefaultValues, this.m_UserValues);
			this.m_AnimatorValues.SendValueToAnimatorSmooth(this.m_suprimidos, this.m_exagerados);
			this.m_ExpresionsValuesBoca.Update(this.m_AnimatorValues);
			this.m_ExpresionsValuesBoca.SendValueToAnimator();
			this.m_ExpresionsXYValues.UpdateAndSendValuesToAnimator();
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0003AE07 File Offset: 0x00039007
		protected override void OnOrderBeforePrimerUpdate(ControlladorDeGestosFacialesEmocionales.Orden orden)
		{
			base.OnOrderBeforePrimerUpdate(orden);
			this.m_ExpresionsXYValues.ProcChance();
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0003AE1C File Offset: 0x0003901C
		public void ExagerarTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float time, float weight = 1f, float minValue = 0f)
		{
			try
			{
				this.DejarDeSuprimirTipoDeExpresion(tipo);
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued tipoDeExpresionCoolDownParWeightedMinValued = this.m_exagerados[(int)tipo];
				tipoDeExpresionCoolDownParWeightedMinValued.ApplyNext(time);
				tipoDeExpresionCoolDownParWeightedMinValued.weight = weight;
				tipoDeExpresionCoolDownParWeightedMinValued.minValue = minValue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0003AE64 File Offset: 0x00039064
		public void DejarDeExagerarTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo)
		{
			try
			{
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued tipoDeExpresionCoolDownParWeightedMinValued = this.m_exagerados[(int)tipo];
				tipoDeExpresionCoolDownParWeightedMinValued.ApplyNext(-1f);
				tipoDeExpresionCoolDownParWeightedMinValued.weight = 0f;
				tipoDeExpresionCoolDownParWeightedMinValued.minValue = 0f;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0003AEB0 File Offset: 0x000390B0
		public void SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float time, float weight = 1f)
		{
			try
			{
				this.DejarDeExagerarTipoDeExpresion(tipo);
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted tipoDeExpresionCoolDownParWeighted = this.m_suprimidos[(int)tipo];
				tipoDeExpresionCoolDownParWeighted.ApplyNext(time);
				tipoDeExpresionCoolDownParWeighted.weight = weight;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0003AEF0 File Offset: 0x000390F0
		public void DejarDeSuprimirTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo)
		{
			try
			{
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted tipoDeExpresionCoolDownParWeighted = this.m_suprimidos[(int)tipo];
				tipoDeExpresionCoolDownParWeighted.ApplyNext(-1f);
				tipoDeExpresionCoolDownParWeighted.weight = 0f;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x0003AF34 File Offset: 0x00039134
		public void ExagerarPor(float time)
		{
			if (this.m_ExageradorCoolDown.left < time)
			{
				this.m_ExageradorCoolDown.ApplyNext(time);
			}
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x0003AF50 File Offset: 0x00039150
		public void DejarDeExagerar()
		{
			this.m_ExageradorCoolDown.ApplyNext(0f);
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0003AF64 File Offset: 0x00039164
		public bool TryExagerarYSuprimirOtros(ReaccionHumana reaccion, float duracion, float exageracion = 1f, float supresion = 0.666f, float minValue = 0f, float? chanceToChangeFacialDirectionsMod = null)
		{
			ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion;
			if (!reaccion.TryParceAExpresion(out tipoDeExpresion))
			{
				return false;
			}
			this.ExagerarYSuprimirOtros(tipoDeExpresion, duracion, exageracion, supresion, minValue, chanceToChangeFacialDirectionsMod);
			return true;
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x0003AF90 File Offset: 0x00039190
		public void ExagerarYSuprimirOtros(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float duracion, float exageracion = 1f, float supresion = 0.666f, float exageracionMinValue = 0f, float? chanceToChangeFacialDirectionsMod = null)
		{
			int enumCount = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumCount();
			IReadOnlyList<int> enumValoresInt = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumValoresInt();
			this.DejarDeSuprimirTipoDeExpresion(tipo);
			this.ExagerarTipoDeExpresionPor(tipo, duracion, exageracion, exageracionMinValue);
			if (chanceToChangeFacialDirectionsMod != null)
			{
				this.m_ExpresionsXYValues.flagNextUpdateToProc = true;
				this.m_ExpresionsXYValues.flagChanceToRotateFacialXYParamsMod = chanceToChangeFacialDirectionsMod.Value;
			}
			for (int i = 0; i < enumCount; i++)
			{
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion = (ControlladorDeGestosFacialesEmocionales.TipoDeExpresion)enumValoresInt[i];
				if (tipo != tipoDeExpresion)
				{
					this.DejarDeExagerarTipoDeExpresion(tipoDeExpresion);
					this.SuprimirTipoDeExpresionPor(tipoDeExpresion, duracion, supresion);
				}
			}
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x0003B020 File Offset: 0x00039220
		public void ExagerarYSuprimirOtros(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoA, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoB, float duracion, float exageracionA = 1f, float exageracionB = 1f, float supresion = 0.666f, float exageracionMinValue = 0f, float? chanceToChangeFacialDirectionsMod = null)
		{
			int enumCount = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumCount();
			IReadOnlyList<int> enumValoresInt = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumValoresInt();
			this.DejarDeSuprimirTipoDeExpresion(tipoA);
			this.ExagerarTipoDeExpresionPor(tipoA, duracion, exageracionA, exageracionMinValue);
			this.DejarDeSuprimirTipoDeExpresion(tipoB);
			this.ExagerarTipoDeExpresionPor(tipoB, duracion, exageracionB, exageracionMinValue);
			if (chanceToChangeFacialDirectionsMod != null)
			{
				this.m_ExpresionsXYValues.flagNextUpdateToProc = true;
				this.m_ExpresionsXYValues.flagChanceToRotateFacialXYParamsMod = chanceToChangeFacialDirectionsMod.Value;
			}
			for (int i = 0; i < enumCount; i++)
			{
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion = (ControlladorDeGestosFacialesEmocionales.TipoDeExpresion)enumValoresInt[i];
				if (tipoA != tipoDeExpresion && tipoB != tipoDeExpresion)
				{
					this.DejarDeExagerarTipoDeExpresion(tipoDeExpresion);
					this.SuprimirTipoDeExpresionPor(tipoDeExpresion, duracion, supresion);
				}
			}
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0003B0C8 File Offset: 0x000392C8
		public bool Cambiar(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float duracion, float weight, bool altaPrioridad = true, bool? usarBoca = null, float? chanceToChangeFacialDirectionsMod = null)
		{
			weight = Mathf.Clamp01(weight);
			ControlladorDeGestosFacialesEmocionales.Orden orden;
			bool flag = base.TipoDeOrdenEstaLibre(tipo, out orden);
			if (!flag && orden.altaPrioridad && !altaPrioridad)
			{
				return false;
			}
			if (orden != null && weight < orden.weight)
			{
				return false;
			}
			bool flag2 = ((usarBoca != null) ? usarBoca.Value : this.m_usaraBocaPorPersonalidad);
			ControllerPrioridadConfig controllerPrioridadConfig = (altaPrioridad ? ControllerPrioridadConfig.prioridad : ControllerPrioridadConfig.baja);
			if (chanceToChangeFacialDirectionsMod != null)
			{
				this.m_ExpresionsXYValues.flagNextUpdateToProc = true;
				this.m_ExpresionsXYValues.flagChanceToRotateFacialXYParamsMod = chanceToChangeFacialDirectionsMod.Value;
			}
			if (!flag)
			{
				orden.priConfig = controllerPrioridadConfig;
				orden.weight = weight;
				orden.altaPrioridad = altaPrioridad;
				if (flag2 != orden.usarBoca)
				{
					orden.usarBoca = flag2;
					orden.flagToUpdateUsarBoca = true;
				}
				base.ResusarOrden(orden, duracion, -1, null, null);
				return true;
			}
			base.Inyectar(new ControlladorDeGestosFacialesEmocionales.Orden(tipo, duracion, weight, flag2, altaPrioridad)
			{
				priConfig = controllerPrioridadConfig
			}, true);
			return true;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0000386D File Offset: 0x00001A6D
		public override ControlladorDeGestosFacialesEmocionales.TipoDeExpresion ParseIndexToTipoId(int index)
		{
			return (ControlladorDeGestosFacialesEmocionales.TipoDeExpresion)index;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x0000386D File Offset: 0x00001A6D
		public override int ParseTipoIdToindex(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoid)
		{
			return (int)tipoid;
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x0001A9B9 File Offset: 0x00018BB9
		protected override ControlladorDeGestosFacialesEmocionales ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x04000AA5 RID: 2725
		private int? m_cantidadDeEstados;

		// Token: 0x04000AA6 RID: 2726
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.Config m_Config = new ControlladorDeGestosFacialesEmocionales.Config();

		// Token: 0x04000AA7 RID: 2727
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.BocaConfig m_BocaConfig = new ControlladorDeGestosFacialesEmocionales.BocaConfig();

		// Token: 0x04000AA8 RID: 2728
		[ReadOnlyUI]
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado m_AnimatorValues = new ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado();

		// Token: 0x04000AA9 RID: 2729
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.ExpresionsValues m_DefaultValues = new ControlladorDeGestosFacialesEmocionales.ExpresionsValues();

		// Token: 0x04000AAA RID: 2730
		[ReadOnlyUI]
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.ExpresionsValues m_UserValues = new ControlladorDeGestosFacialesEmocionales.ExpresionsValues();

		// Token: 0x04000AAB RID: 2731
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.ExpresionsValuesBoca m_ExpresionsValuesBoca = new ControlladorDeGestosFacialesEmocionales.ExpresionsValuesBoca();

		// Token: 0x04000AAC RID: 2732
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues m_ExpresionsXYValues = new ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues();

		// Token: 0x04000AAD RID: 2733
		private Animator m_Animator;

		// Token: 0x04000AAE RID: 2734
		[SerializeField]
		private CoolDown m_ExageradorCoolDown = new CoolDown();

		// Token: 0x04000AAF RID: 2735
		[Obsolete("", true)]
		[SerializeField]
		private float m_currentModDeGestosFaciales = 1f;

		// Token: 0x04000AB0 RID: 2736
		private CoolDown m_usaraBocaPorPersonalidadCoolDown = new CoolDown(1f);

		// Token: 0x04000AB1 RID: 2737
		[ReadOnlyUI]
		[SerializeField]
		private bool m_usaraBocaPorPersonalidad;

		// Token: 0x04000AB2 RID: 2738
		private float m_lastBocaTickChance;

		// Token: 0x04000AB3 RID: 2739
		private float m_lastBocaProcTimeChance;

		// Token: 0x04000AB4 RID: 2740
		[ReadOnlyUI]
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.IntKeyDictionaryTipoDeExpresionCoolDownParWeighted m_suprimidos = new ControlladorDeGestosFacialesEmocionales.IntKeyDictionaryTipoDeExpresionCoolDownParWeighted();

		// Token: 0x04000AB5 RID: 2741
		[ReadOnlyUI]
		[SerializeField]
		private ControlladorDeGestosFacialesEmocionales.IntKeyDictionaryTipoDeExpresionCoolDownParWeightedMinValued m_exagerados = new ControlladorDeGestosFacialesEmocionales.IntKeyDictionaryTipoDeExpresionCoolDownParWeightedMinValued();

		// Token: 0x04000AB6 RID: 2742
		private ICharacterHablador m_CharacterHablador;

		// Token: 0x04000AB7 RID: 2743
		private IControladorDeGestosDeBoca m_IControladorDeGestosDeBoca;

		// Token: 0x04000AB8 RID: 2744
		private Personalidad m_Personalidad;

		// Token: 0x02000238 RID: 568
		[Serializable]
		public class IntKeyDictionaryTipoDeExpresionCoolDownParWeighted : SerializableDictionary<int, ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted>
		{
		}

		// Token: 0x02000239 RID: 569
		[Serializable]
		public class IntKeyDictionaryTipoDeExpresionCoolDownParWeightedMinValued : SerializableDictionary<int, ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued>
		{
		}

		// Token: 0x0200023A RID: 570
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeGestosFacialesEmocionales.Estado, ControlladorDeGestosFacialesEmocionales.Orden, ControlladorDeGestosFacialesEmocionales.Cola, ControlladorDeGestosFacialesEmocionales, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion>.OrdenBaseDeControllador
		{
			// Token: 0x06000CD0 RID: 3280 RVA: 0x0003B258 File Offset: 0x00039458
			public Orden(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoId, float duracion, float weight, bool usarBoca, bool altaPrioridad)
				: base(tipoId, duracion)
			{
				this.weight = weight;
				this.usarBoca = usarBoca;
				altaPrioridad = altaPrioridad;
			}

			// Token: 0x06000CD1 RID: 3281 RVA: 0x0003B275 File Offset: 0x00039475
			private ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor GetValor(ControlladorDeGestosFacialesEmocionales controller)
			{
				return controller.m_UserValues.GetValor(base.tipoId);
			}

			// Token: 0x06000CD2 RID: 3282 RVA: 0x0003B288 File Offset: 0x00039488
			protected override void OnDetenidaPorUsuario(ControlladorDeGestosFacialesEmocionales dataUpdate)
			{
				this.GetValor(dataUpdate).valor = 0f;
			}

			// Token: 0x06000CD3 RID: 3283 RVA: 0x0003B29C File Offset: 0x0003949C
			protected override bool UpdateOrden(ControlladorDeGestosFacialesEmocionales dataUpdate, bool esPrimerUpdate)
			{
				ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor = this.GetValor(dataUpdate);
				if (this.Termino())
				{
					valor.valor = 0f;
					return false;
				}
				if (esPrimerUpdate || this.flagToUpdateUsarBoca)
				{
					dataUpdate.m_ExpresionsValuesBoca.SetUsoDeBoca(base.tipoId, this.usarBoca, base.permanente ? dataUpdate.m_ExpresionsValuesBoca.GenerateNewDuration() : base.tiempoRestante);
				}
				valor.valor = this.weight;
				this.flagToUpdateUsarBoca = false;
				return true;
			}

			// Token: 0x06000CD4 RID: 3284 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnTerminada(ControlladorDeGestosFacialesEmocionales dataUpdate, bool abruptamente)
			{
			}

			// Token: 0x06000CD5 RID: 3285 RVA: 0x00005F51 File Offset: 0x00004151
			protected override bool OnTerminando(ControlladorDeGestosFacialesEmocionales dataUpdate, bool primerUpdate, ControlladorDeGestosFacialesEmocionales.Orden esperandoDetencion)
			{
				return true;
			}

			// Token: 0x06000CD6 RID: 3286 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnStart(ControlladorDeGestosFacialesEmocionales dataUpdate)
			{
			}

			// Token: 0x04000AB9 RID: 2745
			public float weight;

			// Token: 0x04000ABA RID: 2746
			public bool usarBoca;

			// Token: 0x04000ABB RID: 2747
			public bool flagToUpdateUsarBoca;

			// Token: 0x04000ABC RID: 2748
			public bool altaPrioridad;
		}

		// Token: 0x0200023B RID: 571
		public sealed class Estado : ControllerColaDePrioridadBase<ControlladorDeGestosFacialesEmocionales.Estado, ControlladorDeGestosFacialesEmocionales.Orden, ControlladorDeGestosFacialesEmocionales.Cola, ControlladorDeGestosFacialesEmocionales, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion>.StadoBase
		{
		}

		// Token: 0x0200023C RID: 572
		public sealed class Cola : ControllerColaDePrioridadBase<ControlladorDeGestosFacialesEmocionales.Estado, ControlladorDeGestosFacialesEmocionales.Orden, ControlladorDeGestosFacialesEmocionales.Cola, ControlladorDeGestosFacialesEmocionales, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion>.ColasBase
		{
		}

		// Token: 0x0200023D RID: 573
		[Serializable]
		public class TipoDeExpresionCoolDownPar
		{
			// Token: 0x06000CD9 RID: 3289 RVA: 0x0003B327 File Offset: 0x00039527
			public void ApplyNext(float duracion)
			{
				this.m_coolDown.ApplyNext(duracion);
				this.m_isOnLast = this.m_coolDown.isOn;
			}

			// Token: 0x170002D7 RID: 727
			// (get) Token: 0x06000CDA RID: 3290 RVA: 0x0003B346 File Offset: 0x00039546
			public bool isOn
			{
				get
				{
					this.m_isOnLast = this.m_coolDown.isOn;
					return this.m_isOnLast;
				}
			}

			// Token: 0x04000ABD RID: 2749
			public ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo;

			// Token: 0x04000ABE RID: 2750
			[SerializeField]
			private CoolDown m_coolDown = new CoolDown();

			// Token: 0x04000ABF RID: 2751
			[SerializeField]
			private bool m_isOnLast;
		}

		// Token: 0x0200023E RID: 574
		[Serializable]
		public class TipoDeExpresionCoolDownParWeighted : ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownPar
		{
			// Token: 0x170002D8 RID: 728
			// (get) Token: 0x06000CDC RID: 3292 RVA: 0x0003B372 File Offset: 0x00039572
			// (set) Token: 0x06000CDD RID: 3293 RVA: 0x0003B37A File Offset: 0x0003957A
			public float weight
			{
				get
				{
					return this.m_weight;
				}
				set
				{
					this.m_weight = Mathf.Clamp01(value);
				}
			}

			// Token: 0x04000AC0 RID: 2752
			[SerializeField]
			private float m_weight = 1f;
		}

		// Token: 0x0200023F RID: 575
		[Serializable]
		public class TipoDeExpresionCoolDownParWeightedMinValued : ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted
		{
			// Token: 0x170002D9 RID: 729
			// (get) Token: 0x06000CDF RID: 3295 RVA: 0x0003B39B File Offset: 0x0003959B
			// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x0003B3A3 File Offset: 0x000395A3
			public float minValue
			{
				get
				{
					return this.m_minValue;
				}
				set
				{
					this.m_minValue = Mathf.Clamp01(value);
				}
			}

			// Token: 0x04000AC1 RID: 2753
			[SerializeField]
			private float m_minValue;
		}

		// Token: 0x02000240 RID: 576
		[Serializable]
		public class ExpresionsValuesResultado : ControlladorDeGestosFacialesEmocionales.ExpresionsValues
		{
			// Token: 0x170002DA RID: 730
			// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x0003B3B9 File Offset: 0x000395B9
			public ControlladorDeGestosFacialesEmocionales.ExpresionsValues enviados
			{
				get
				{
					return this.m_enviados;
				}
			}

			// Token: 0x06000CE3 RID: 3299 RVA: 0x0003B3C1 File Offset: 0x000395C1
			public override void Init(ControlladorDeGestosFacialesEmocionales controlladorDeGestosFaciales)
			{
				base.Init(controlladorDeGestosFaciales);
				this.m_enviados.Init(controlladorDeGestosFaciales);
			}

			// Token: 0x06000CE4 RID: 3300 RVA: 0x0003B3D8 File Offset: 0x000395D8
			public void OutPow(float p)
			{
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					this.m_valores[i].valor.OutPow(p);
				}
			}

			// Token: 0x06000CE5 RID: 3301 RVA: 0x0003B414 File Offset: 0x00039614
			public void Normalizar()
			{
				float num = 0f;
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					num += this.m_valores[i].valor;
				}
				if (num <= 0f)
				{
					return;
				}
				for (int j = 0; j < this.m_valores.Count; j++)
				{
					this.m_valores[j].valor /= num;
				}
			}

			// Token: 0x06000CE6 RID: 3302 RVA: 0x0003B48C File Offset: 0x0003968C
			public void Convinar(ControlladorDeGestosFacialesEmocionales.ExpresionsValues defaultValues, ControlladorDeGestosFacialesEmocionales.ExpresionsValues usarValues)
			{
				if (defaultValues == this)
				{
					throw new InvalidOperationException();
				}
				if (usarValues == this)
				{
					throw new InvalidOperationException();
				}
				float num = 0f;
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor = this.m_valores[i];
					float value = defaultValues.GetValue(valor.tipo);
					float value2 = usarValues.GetValue(valor.tipo);
					float num2 = Mathf.Clamp01(value + value2);
					base.SetValue(valor.tipo, num2);
					if (num2 > num)
					{
						num = num2;
					}
				}
				if (this.m_ControlladorDeGestosFaciales.m_ExageradorCoolDown.isOn)
				{
					for (int j = 0; j < this.m_valores.Count; j++)
					{
						ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor2 = this.m_valores[j];
						float num3 = this.m_ControlladorDeGestosFaciales.m_Config.exagerarPower * this.m_ControlladorDeGestosFaciales.m_Config.modDeExagerarPower;
						if (valor2.valor >= num)
						{
							valor2.valor = valor2.valor.OutPow(num3);
						}
						else
						{
							valor2.valor = valor2.valor.InPow(num3);
						}
					}
				}
			}

			// Token: 0x06000CE7 RID: 3303 RVA: 0x0003B5A8 File Offset: 0x000397A8
			public void SendValueToAnimatorSmooth(IDictionary<int, ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted> suprimidos, IDictionary<int, ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued> exagerados)
			{
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor = this.m_valores[i];
					if (valor.tipo == ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.sorpresa)
					{
						if (!ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado.alertado)
						{
							ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado.alertado = true;
							if (Application.isEditor)
							{
								Debug.LogWarning("TipoDeExpresion.sorpresa no esta desarrollada");
							}
						}
					}
					else if (valor.tipo == ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.aburrimiento)
					{
						if (!ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado.alertado2)
						{
							ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado.alertado2 = true;
							if (Application.isEditor)
							{
								Debug.LogWarning("TipoDeExpresion.aburrimiento no esta desarrollada");
							}
						}
					}
					else
					{
						float num;
						float num2;
						float num3;
						if (!ControlladorDeGestosFacialesEmocionales.ExpresionsValues.EstaEnCoolDown(valor.tipo, exagerados, out num, out num2))
						{
							num3 = valor.valor;
						}
						else
						{
							num3 = Mathf.LerpUnclamped(valor.valor, valor.valor.OutPow(this.m_ControlladorDeGestosFaciales.m_Config.exagerarPower * this.m_ControlladorDeGestosFaciales.m_Config.modDeExagerarPower), num);
							num3 = Mathf.Max(num2, num3);
						}
						float num4;
						if (ControlladorDeGestosFacialesEmocionales.ExpresionsValues.EstaEnCoolDown(valor.tipo, suprimidos, out num4))
						{
							num3 = Mathf.LerpUnclamped(num3, 0f, num4);
						}
						num3 = Mathf.Clamp01(num3);
						this.m_enviados.SetValue(valor.tipo, num3);
						int num5 = valor.tipo.Hash();
						float @float = this.m_ControlladorDeGestosFaciales.m_Animator.GetFloat(num5);
						this.m_ControlladorDeGestosFaciales.m_Animator.SetFloat(num5, num3, (@float < num3) ? this.m_ControlladorDeGestosFaciales.m_Config.timeToSmoothIncreasing : this.m_ControlladorDeGestosFaciales.m_Config.timeToSmoothDecreasing, Time.deltaTime);
					}
				}
			}

			// Token: 0x04000AC2 RID: 2754
			[ReadOnlyUI]
			[SerializeField]
			private ControlladorDeGestosFacialesEmocionales.ExpresionsValues m_enviados = new ControlladorDeGestosFacialesEmocionales.ExpresionsValues();

			// Token: 0x04000AC3 RID: 2755
			public static bool alertado;

			// Token: 0x04000AC4 RID: 2756
			public static bool alertado2;
		}

		// Token: 0x02000241 RID: 577
		[Serializable]
		public class ExpresionsValues
		{
			// Token: 0x170002DB RID: 731
			// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0003B753 File Offset: 0x00039953
			public IReadOnlyList<ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor> valores
			{
				get
				{
					return this.m_valores;
				}
			}

			// Token: 0x06000CEA RID: 3306 RVA: 0x0003B75C File Offset: 0x0003995C
			public virtual void Init(ControlladorDeGestosFacialesEmocionales controlladorDeGestosFaciales)
			{
				this.m_ControlladorDeGestosFaciales = controlladorDeGestosFaciales;
				IEnumerable<ControlladorDeGestosFacialesEmocionales.TipoDeExpresion> enumerable = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumValoresInt().Cast<ControlladorDeGestosFacialesEmocionales.TipoDeExpresion>();
				this.m_valores = new List<ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor>();
				foreach (ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion in enumerable)
				{
					this.m_valores.Add(new ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor(tipoDeExpresion)
					{
						valor = 0f
					});
				}
			}

			// Token: 0x06000CEB RID: 3307 RVA: 0x0003B7E0 File Offset: 0x000399E0
			public void SetValue(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float val)
			{
				try
				{
					val = Mathf.Clamp01(val);
					this.m_valores[(int)tipo].valor = val;
				}
				catch (Exception ex)
				{
					Debug.LogWarning("e ahead", this.m_ControlladorDeGestosFaciales);
					throw ex;
				}
			}

			// Token: 0x06000CEC RID: 3308 RVA: 0x0003B82C File Offset: 0x00039A2C
			public ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor GetValor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo)
			{
				ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor;
				try
				{
					valor = this.m_valores[(int)tipo];
				}
				catch (Exception ex)
				{
					Debug.LogWarning("e ahead", this.m_ControlladorDeGestosFaciales);
					throw ex;
				}
				return valor;
			}

			// Token: 0x06000CED RID: 3309 RVA: 0x0003B86C File Offset: 0x00039A6C
			public float GetValue(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo)
			{
				float valor;
				try
				{
					valor = this.m_valores[(int)tipo].valor;
				}
				catch (Exception ex)
				{
					Debug.LogWarning("e ahead", this.m_ControlladorDeGestosFaciales);
					throw ex;
				}
				return valor;
			}

			// Token: 0x06000CEE RID: 3310 RVA: 0x0003B8B0 File Offset: 0x00039AB0
			public ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor GetMaxValue()
			{
				ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor = null;
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor2 = this.m_valores[i];
					if (valor == null || valor2.valor > valor.valor)
					{
						valor = valor2;
					}
				}
				return valor;
			}

			// Token: 0x06000CEF RID: 3311 RVA: 0x0003B8F8 File Offset: 0x00039AF8
			public static bool EstaEnCoolDown(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, IDictionary<int, ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted> coolDowns, out float weight)
			{
				weight = 0f;
				if (coolDowns == null)
				{
					return false;
				}
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeighted tipoDeExpresionCoolDownParWeighted;
				if (!coolDowns.TryGetValue((int)tipo, out tipoDeExpresionCoolDownParWeighted))
				{
					return false;
				}
				weight = tipoDeExpresionCoolDownParWeighted.weight;
				return tipoDeExpresionCoolDownParWeighted.isOn;
			}

			// Token: 0x06000CF0 RID: 3312 RVA: 0x0003B92C File Offset: 0x00039B2C
			public static bool EstaEnCoolDown(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, IDictionary<int, ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued> coolDowns, out float weight, out float minvalue)
			{
				minvalue = (weight = 0f);
				if (coolDowns == null)
				{
					return false;
				}
				ControlladorDeGestosFacialesEmocionales.TipoDeExpresionCoolDownParWeightedMinValued tipoDeExpresionCoolDownParWeightedMinValued;
				if (!coolDowns.TryGetValue((int)tipo, out tipoDeExpresionCoolDownParWeightedMinValued))
				{
					return false;
				}
				minvalue = tipoDeExpresionCoolDownParWeightedMinValued.minValue;
				weight = tipoDeExpresionCoolDownParWeightedMinValued.weight;
				return tipoDeExpresionCoolDownParWeightedMinValued.isOn;
			}

			// Token: 0x06000CF1 RID: 3313 RVA: 0x0003B970 File Offset: 0x00039B70
			public void SendValueToAnimator()
			{
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor valor = this.m_valores[i];
					if (valor.tipo == ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.sorpresa)
					{
						if (!ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado.alertado)
						{
							ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado.alertado = true;
							Debug.LogWarning("TipoDeExpresion.sorpresa no esta desarrollada");
						}
					}
					else
					{
						this.m_ControlladorDeGestosFaciales.m_Animator.SetFloat(valor.tipo.Hash(), valor.valor);
					}
				}
			}

			// Token: 0x06000CF2 RID: 3314 RVA: 0x0003B9E4 File Offset: 0x00039BE4
			public void Normalizar(IList<float> result)
			{
				float num = 0f;
				for (int i = 0; i < this.m_valores.Count; i++)
				{
					num += this.m_valores[i].valor;
				}
				for (int j = 0; j < this.m_valores.Count; j++)
				{
					result[j] = this.m_valores[j].valor / num;
				}
			}

			// Token: 0x04000AC5 RID: 2757
			[SerializeField]
			protected List<ControlladorDeGestosFacialesEmocionales.ExpresionsValues.Valor> m_valores;

			// Token: 0x04000AC6 RID: 2758
			protected ControlladorDeGestosFacialesEmocionales m_ControlladorDeGestosFaciales;

			// Token: 0x02000242 RID: 578
			[Serializable]
			public class Valor
			{
				// Token: 0x06000CF4 RID: 3316 RVA: 0x0003BA51 File Offset: 0x00039C51
				public Valor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo)
				{
					this.m_tipo = tipo;
				}

				// Token: 0x170002DC RID: 732
				// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x0003BA60 File Offset: 0x00039C60
				public ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo
				{
					get
					{
						return this.m_tipo;
					}
				}

				// Token: 0x04000AC7 RID: 2759
				[SerializeField]
				[ReadOnlyUI]
				private ControlladorDeGestosFacialesEmocionales.TipoDeExpresion m_tipo;

				// Token: 0x04000AC8 RID: 2760
				public float valor;
			}
		}

		// Token: 0x02000243 RID: 579
		[Serializable]
		public class ExpresionsValuesBoca
		{
			// Token: 0x170002DD RID: 733
			// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x0003BA68 File Offset: 0x00039C68
			public float value
			{
				get
				{
					return this.m_value;
				}
			}

			// Token: 0x170002DE RID: 734
			// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x0003BA70 File Offset: 0x00039C70
			// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x0003BA78 File Offset: 0x00039C78
			public float targetValueByOrders
			{
				get
				{
					return this.m_targetValueByOrders;
				}
				set
				{
					this.m_targetValueByOrders = Mathf.Clamp01(value);
				}
			}

			// Token: 0x170002DF RID: 735
			// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x0003BA86 File Offset: 0x00039C86
			// (set) Token: 0x06000CFA RID: 3322 RVA: 0x0003BA8E File Offset: 0x00039C8E
			public float targetValueByOverrride
			{
				get
				{
					return this.m_targetValueByOverrride;
				}
				set
				{
					this.m_targetValueByOverrride = Mathf.Clamp01(value);
				}
			}

			// Token: 0x06000CFB RID: 3323 RVA: 0x0003BA9C File Offset: 0x00039C9C
			public void Init(ControlladorDeGestosFacialesEmocionales controllador)
			{
				this.m_controllador = controllador;
				IReadOnlyList<int> enumValoresInt = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumValoresInt();
				foreach (int num in enumValoresInt)
				{
					this.m_usandoBoca.Add(num, false);
					this.m_usandoBocaCloseTime.Add(num, 0f);
				}
				this.m_enviadosNormalizados = new float[enumValoresInt.Count];
			}

			// Token: 0x06000CFC RID: 3324 RVA: 0x0003BB24 File Offset: 0x00039D24
			public void SendValueToAnimator()
			{
				float num = this.m_controllador.m_Animator.GetFloat(AnimatorParamsDicc.bocaDiscursoHash);
				num = Mathf.Clamp01(num);
				this.m_controllador.m_Animator.SetFloat(AnimatorParamsDicc.bocaEmoHash, Mathf.Lerp(Mathf.Clamp01(this.m_value), 0f, Mathf.Clamp(num, 0f, 0.6666f)));
			}

			// Token: 0x06000CFD RID: 3325 RVA: 0x0003BB88 File Offset: 0x00039D88
			public void DejarDeUsar()
			{
				this.closeTimeByOverride = null;
				this.closeTimeByOrders = null;
				this.m_targetValueByOrders = 0f;
				this.m_targetValueByOverrride = 0f;
				this.durationOverride = 0f;
			}

			// Token: 0x06000CFE RID: 3326 RVA: 0x0003BBC4 File Offset: 0x00039DC4
			public void Update(ControlladorDeGestosFacialesEmocionales.ExpresionsValuesResultado expresionsValuesResultado)
			{
				try
				{
					if (this.m_controllador.m_AnimatorValues.GetMaxValue().valor > 0f)
					{
						expresionsValuesResultado.enviados.Normalizar(this.m_enviadosNormalizados);
						float num = 0f;
						IReadOnlyList<int> enumValoresInt = typeof(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion).GetEnumValoresInt();
						for (int i = 0; i < enumValoresInt.Count; i++)
						{
							float num2 = this.m_enviadosNormalizados[i];
							bool flag = this.m_usandoBoca[i];
							num += num2 * (flag ? 1f : (-1f));
						}
						this.targetValueByOrders = num;
						if (this.flagUpdateBocaCloseTime)
						{
							this.flagUpdateBocaCloseTime = false;
							float num3 = 0f;
							for (int j = 0; j < enumValoresInt.Count; j++)
							{
								float num4 = this.m_enviadosNormalizados[j];
								bool flag2 = this.m_usandoBoca[j];
								float num5 = this.m_usandoBocaCloseTime[j] - Time.time;
								if (flag2 && num5 > 0f)
								{
									num3 += num4 * num5;
								}
							}
							this.closeTimeByOrders = new float?(Time.time + num3);
						}
					}
					this.UpdateCloseTime();
				}
				finally
				{
					float num6;
					bool flag3 = ControlladorDeGestosFacialesEmocionales.ExpresionsValuesBoca.TimeIsOut(ref this.closeTimeByOrders, out num6);
					float num7;
					bool flag4 = ControlladorDeGestosFacialesEmocionales.ExpresionsValuesBoca.TimeIsOut(ref this.closeTimeByOverride, out num7);
					if (flag3)
					{
						this.m_targetValueByOrders = 0f;
					}
					if (flag4)
					{
						this.m_targetValueByOverrride = 0f;
					}
					float num8 = Mathf.Max(this.m_targetValueByOrders, this.m_targetValueByOverrride);
					this.m_left = Mathf.Max(num6, num7);
					this.m_value = MathfExtension.SmoothDamp(this.m_value, num8, ref this.vel, this.m_controllador.m_Config.timeToSmoothIncreasing, this.m_controllador.m_Config.timeToSmoothDecreasing);
				}
			}

			// Token: 0x06000CFF RID: 3327 RVA: 0x0003BD98 File Offset: 0x00039F98
			private static bool TimeIsOut(ref float? closeTime, out float left)
			{
				if (closeTime != null && closeTime.Value <= Time.time)
				{
					left = 0f;
					closeTime = null;
					return true;
				}
				if (closeTime == null)
				{
					left = 0f;
					return true;
				}
				left = closeTime.Value - Time.time;
				return false;
			}

			// Token: 0x06000D00 RID: 3328 RVA: 0x0003BDEC File Offset: 0x00039FEC
			public void SetUsoDeBoca(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, bool usar, float duration)
			{
				this.m_usandoBoca[(int)tipo] = usar;
				this.m_usandoBocaCloseTime[(int)tipo] = duration + Time.time;
				this.flagUpdateBocaCloseTime = true;
			}

			// Token: 0x06000D01 RID: 3329 RVA: 0x0003BE22 File Offset: 0x0003A022
			public float GenerateNewDuration()
			{
				return this.m_controllador.m_BocaConfig.avarageTimeOpen * Random.Range(0.25f, 1.75f);
			}

			// Token: 0x06000D02 RID: 3330 RVA: 0x0003BE44 File Offset: 0x0003A044
			private void UpdateCloseTime()
			{
				if (this.durationOverride > 0f)
				{
					this.closeTimeByOverride = new float?(Time.time + this.durationOverride);
					this.durationOverride = 0f;
				}
			}

			// Token: 0x04000AC9 RID: 2761
			public bool flagUpdateBocaCloseTime;

			// Token: 0x04000ACA RID: 2762
			public float durationOverride = -1f;

			// Token: 0x04000ACB RID: 2763
			[SerializeField]
			private IntKeyBooleanValueDictionary m_usandoBoca = new IntKeyBooleanValueDictionary();

			// Token: 0x04000ACC RID: 2764
			[SerializeField]
			private IntKeyFloatValueDictionary m_usandoBocaCloseTime = new IntKeyFloatValueDictionary();

			// Token: 0x04000ACD RID: 2765
			[SerializeField]
			private float[] m_enviadosNormalizados;

			// Token: 0x04000ACE RID: 2766
			[ReadOnlyUI]
			[SerializeField]
			private float m_value;

			// Token: 0x04000ACF RID: 2767
			[SerializeField]
			private float m_targetValueByOrders;

			// Token: 0x04000AD0 RID: 2768
			[SerializeField]
			private float m_targetValueByOverrride;

			// Token: 0x04000AD1 RID: 2769
			[SerializeField]
			private float m_left;

			// Token: 0x04000AD2 RID: 2770
			private float? closeTimeByOverride;

			// Token: 0x04000AD3 RID: 2771
			private float? closeTimeByOrders;

			// Token: 0x04000AD4 RID: 2772
			private float vel;

			// Token: 0x04000AD5 RID: 2773
			private ControlladorDeGestosFacialesEmocionales m_controllador;
		}

		// Token: 0x02000244 RID: 580
		[Serializable]
		public class ExpresionsXYValues
		{
			// Token: 0x06000D04 RID: 3332 RVA: 0x0003BE9E File Offset: 0x0003A09E
			public void Init(ControlladorDeGestosFacialesEmocionales controllador)
			{
				this.m_controllador = controllador;
				ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues.CorrectDirections(ref this.m_targetFacialDirection);
				ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues.CorrectDirections(ref this.m_targetBocalDirection);
			}

			// Token: 0x06000D05 RID: 3333 RVA: 0x0003BEC0 File Offset: 0x0003A0C0
			private static void CorrectDirections(ref Vector2 vec)
			{
				if (vec.sqrMagnitude == 0f)
				{
					vec = Random.insideUnitCircle.normalized;
				}
				if (vec.sqrMagnitude != 1f)
				{
					vec = vec.normalized;
				}
			}

			// Token: 0x170002E0 RID: 736
			// (get) Token: 0x06000D06 RID: 3334 RVA: 0x0003BF06 File Offset: 0x0003A106
			// (set) Token: 0x06000D07 RID: 3335 RVA: 0x0003BF10 File Offset: 0x0003A110
			public Vector2 userTargetFacialDirection
			{
				get
				{
					return this.m_userTargetFacialDirection;
				}
				set
				{
					this.m_targetFacialDirection = value;
					this.m_userTargetFacialDirection = value;
				}
			}

			// Token: 0x170002E1 RID: 737
			// (get) Token: 0x06000D08 RID: 3336 RVA: 0x0003BF2D File Offset: 0x0003A12D
			// (set) Token: 0x06000D09 RID: 3337 RVA: 0x0003BF38 File Offset: 0x0003A138
			public Vector2 userTargetBocalDirection
			{
				get
				{
					return this.m_userTargetBocalDirection;
				}
				set
				{
					this.m_targetBocalDirection = value;
					this.m_userTargetBocalDirection = value;
				}
			}

			// Token: 0x170002E2 RID: 738
			// (get) Token: 0x06000D0A RID: 3338 RVA: 0x0003BF55 File Offset: 0x0003A155
			// (set) Token: 0x06000D0B RID: 3339 RVA: 0x0003BF5D File Offset: 0x0003A15D
			public Vector2 currentFacialDirection
			{
				get
				{
					return this.m_currentFacialDirection;
				}
				set
				{
					this.m_currentFacialDirection = value;
				}
			}

			// Token: 0x170002E3 RID: 739
			// (get) Token: 0x06000D0C RID: 3340 RVA: 0x0003BF66 File Offset: 0x0003A166
			// (set) Token: 0x06000D0D RID: 3341 RVA: 0x0003BF6E File Offset: 0x0003A16E
			public Vector2 currentBocalDirection
			{
				get
				{
					return this.m_currentBocalDirection;
				}
				set
				{
					this.m_currentBocalDirection = value;
				}
			}

			// Token: 0x06000D0E RID: 3342 RVA: 0x0003BF78 File Offset: 0x0003A178
			public void ProcChance()
			{
				float num = this.flagChanceToRotateFacialXYParamsMod;
				this.flagChanceToRotateFacialXYParamsMod = 1f;
				this.flagNextUpdateToProc = false;
				if (!ExtendedMonoBehaviour.IsProc(this.m_controllador.m_Config.chanceToRotateFacialXYParams, num))
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues.procOn(this.userTargetFacialDirection, ref this.m_targetFacialDirection, ref this.m_targetFacialDirectionLastAxis);
				ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues.procOn(this.userTargetBocalDirection, ref this.m_targetBocalDirection, ref this.m_targetBocalDirectionLastAxis);
			}

			// Token: 0x06000D0F RID: 3343 RVA: 0x0003BFE8 File Offset: 0x0003A1E8
			private static void procOn(Vector2 userTarget, ref Vector2 targetResult, ref float lastAngleOffset)
			{
				float num = Random.Range(-30f, 30f);
				lastAngleOffset += num;
				if (Mathf.Abs(lastAngleOffset) > 30f)
				{
					lastAngleOffset = 0f;
				}
				targetResult = userTarget.Rotate(lastAngleOffset);
			}

			// Token: 0x06000D10 RID: 3344 RVA: 0x0003C030 File Offset: 0x0003A230
			public void UpdateAndSendValuesToAnimator()
			{
				ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues.CorrectDirections(ref this.m_targetFacialDirection);
				ControlladorDeGestosFacialesEmocionales.ExpresionsXYValues.CorrectDirections(ref this.m_targetBocalDirection);
				if (this.flagNextUpdateToProc)
				{
					this.ProcChance();
				}
				if (this.m_currentFacialDirection != this.m_targetFacialDirection)
				{
					this.m_currentFacialDirection = Vector2.SmoothDamp(this.m_currentFacialDirection, this.m_targetFacialDirection, ref this.facialVel, 0.25f, 9999f, Time.deltaTime).normalized;
				}
				if (this.m_currentBocalDirection != this.m_targetBocalDirection)
				{
					this.m_currentBocalDirection = Vector2.SmoothDamp(this.m_currentBocalDirection, this.m_targetBocalDirection, ref this.bocaVel, 0.25f, 9999f, Time.deltaTime).normalized;
				}
				this.m_controllador.m_Animator.SetFloat(AnimatorParamsDicc.faceXHash, this.m_currentFacialDirection.x);
				this.m_controllador.m_Animator.SetFloat(AnimatorParamsDicc.faceYHash, this.m_currentFacialDirection.y);
				this.m_controllador.m_Animator.SetFloat(AnimatorParamsDicc.bocaXHash, this.m_currentBocalDirection.x);
				this.m_controllador.m_Animator.SetFloat(AnimatorParamsDicc.bocaYHash, this.m_currentBocalDirection.y);
			}

			// Token: 0x04000AD6 RID: 2774
			private ControlladorDeGestosFacialesEmocionales m_controllador;

			// Token: 0x04000AD7 RID: 2775
			private Vector2 m_userTargetFacialDirection;

			// Token: 0x04000AD8 RID: 2776
			private Vector2 m_userTargetBocalDirection;

			// Token: 0x04000AD9 RID: 2777
			public float flagChanceToRotateFacialXYParamsMod = 1f;

			// Token: 0x04000ADA RID: 2778
			[SerializeField]
			private Vector2 m_targetFacialDirection;

			// Token: 0x04000ADB RID: 2779
			[SerializeField]
			private Vector2 m_targetBocalDirection;

			// Token: 0x04000ADC RID: 2780
			[SerializeField]
			private float m_targetFacialDirectionLastAxis;

			// Token: 0x04000ADD RID: 2781
			[SerializeField]
			private float m_targetBocalDirectionLastAxis;

			// Token: 0x04000ADE RID: 2782
			public bool flagNextUpdateToProc;

			// Token: 0x04000ADF RID: 2783
			[ReadOnlyUI]
			[SerializeField]
			private Vector2 m_currentFacialDirection;

			// Token: 0x04000AE0 RID: 2784
			[ReadOnlyUI]
			[SerializeField]
			private Vector2 m_currentBocalDirection;

			// Token: 0x04000AE1 RID: 2785
			private Vector2 facialVel;

			// Token: 0x04000AE2 RID: 2786
			private Vector2 bocaVel;
		}

		// Token: 0x02000245 RID: 581
		[Serializable]
		public class Config
		{
			// Token: 0x04000AE3 RID: 2787
			[Range(0f, 100f)]
			public float chanceToRotateFacialXYParams = 2f;

			// Token: 0x04000AE4 RID: 2788
			public float timeToSmoothIncreasing = 0.11f;

			// Token: 0x04000AE5 RID: 2789
			public float timeToSmoothDecreasing = 0.3333f;

			// Token: 0x04000AE6 RID: 2790
			public float exagerarPower = 4f;

			// Token: 0x04000AE7 RID: 2791
			public float modDeExagerarPower = 1f;
		}

		// Token: 0x02000246 RID: 582
		[Serializable]
		public class BocaConfig
		{
			// Token: 0x04000AE8 RID: 2792
			public float avarageTimeOpen = 8f;

			// Token: 0x04000AE9 RID: 2793
			[Obsolete("", true)]
			[Range(0f, 100f)]
			public float chanceToOpenPorSegundo = 10f;

			// Token: 0x04000AEA RID: 2794
			[Obsolete("", true)]
			[Range(0f, 100f)]
			public float chanceRestartTimeOpenPorSegundo = 1f;
		}

		// Token: 0x02000247 RID: 583
		public enum TipoDeExpresion
		{
			// Token: 0x04000AEC RID: 2796
			alegria,
			// Token: 0x04000AED RID: 2797
			placer,
			// Token: 0x04000AEE RID: 2798
			dolor,
			// Token: 0x04000AEF RID: 2799
			rabia,
			// Token: 0x04000AF0 RID: 2800
			sorpresa,
			// Token: 0x04000AF1 RID: 2801
			aburrimiento,
			// Token: 0x04000AF2 RID: 2802
			miedo
		}
	}
}
