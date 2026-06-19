using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.CharacterMemoria;
using Assets._ReusableScripts.Globales.Updater;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers.DialogueSystem
{
	// Token: 0x020000C0 RID: 192
	public sealed class EntrevistaDiaSysFunciones : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x00015F83 File Offset: 0x00014183
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00015F8B File Offset: 0x0001418B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00015F99 File Offset: 0x00014199
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_manager = Actividad.running as EntrevistaConFemaleCharacter;
			while (this.m_manager == null)
			{
				yield return null;
				this.m_manager = Actividad.running as EntrevistaConFemaleCharacter;
			}
			this.Registrar();
			yield break;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00015FA8 File Offset: 0x000141A8
		private void Init()
		{
			if (this.m_manager == null)
			{
				throw new ArgumentNullException("m_manager", "m_manager null reference.");
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00015FC8 File Offset: 0x000141C8
		private void Clear()
		{
			this.m_manager = null;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00015FD1 File Offset: 0x000141D1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Registrar();
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00015FE7 File Offset: 0x000141E7
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.UnRegistrar();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00015FF8 File Offset: 0x000141F8
		private void Registrar()
		{
			Lua.RegisterFunction("CurrentCharDePoolEsConocida", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharDePoolEsConocida"));
			Lua.RegisterFunction("CurrentCharRegistrarComoConocida", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharRegistrarComoConocida"));
			Lua.RegisterFunction("CurrentCharRegistrarComoSaludado", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharRegistrarComoSaludado"));
			Lua.RegisterFunction("CurrentCharDePoolEsTimida", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharDePoolEsTimida"));
			Lua.RegisterFunction("CurrentCharDePoolEsPervertida", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharDePoolEsPervertida"));
			Lua.RegisterFunction("CurrentCharDePoolEsRespetuoza", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharDePoolEsRespetuoza"));
			Lua.RegisterFunction("CurrentCharDePoolEsGrosera", this, typeof(EntrevistaDiaSysFunciones).GetMethod("CurrentCharDePoolEsGrosera"));
			Lua.RegisterFunction("ProcPrimerResponceMenu", this, typeof(EntrevistaDiaSysFunciones).GetMethod("ProcPrimerResponceMenu"));
			Lua.RegisterFunction("TerminarEntrevistaUserDefault", this, typeof(EntrevistaDiaSysFunciones).GetMethod("TerminarEntrevistaUserDefault"));
			Lua.RegisterFunction("TerminarEntrevistaUser", this, typeof(EntrevistaDiaSysFunciones).GetMethod("TerminarEntrevistaUser"));
			Lua.RegisterFunction("TerminarEntrevistaInviadaAOtraAgencia", this, typeof(EntrevistaDiaSysFunciones).GetMethod("TerminarEntrevistaInviadaAOtraAgencia"));
			Lua.RegisterFunction("FemaleDespachada", this, typeof(EntrevistaDiaSysFunciones).GetMethod("FemaleDespachada"));
			Lua.RegisterFunction("TerminarEntrevistaSelf", this, typeof(EntrevistaDiaSysFunciones).GetMethod("TerminarEntrevistaSelf"));
			Lua.RegisterFunction("ResponseProc1", this, typeof(EntrevistaDiaSysFunciones).GetMethod("ResponseProc1"));
			Lua.RegisterFunction("RegistrarConversantePreguntoSiActorEstaSeguroDeRetirarla", this, typeof(EntrevistaDiaSysFunciones).GetMethod("RegistrarConversantePreguntoSiActorEstaSeguroDeRetirarla"));
			Lua.RegisterFunction("LeerConversantePreguntoSiActorEstaSeguroDeRetirarla", this, typeof(EntrevistaDiaSysFunciones).GetMethod("LeerConversantePreguntoSiActorEstaSeguroDeRetirarla"));
			this.Init();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000161FC File Offset: 0x000143FC
		private void UnRegistrar()
		{
			Lua.UnregisterFunction("CurrentCharDePoolEsConocida");
			Lua.UnregisterFunction("CurrentCharRegistrarComoConocida");
			Lua.UnregisterFunction("CurrentCharRegistrarComoSaludado");
			Lua.UnregisterFunction("CurrentCharDePoolEsTimida");
			Lua.UnregisterFunction("CurrentCharDePoolEsPervertida");
			Lua.UnregisterFunction("CurrentCharDePoolEsRespetuoza");
			Lua.UnregisterFunction("CurrentCharDePoolEsGrosera");
			Lua.UnregisterFunction("ProcPrimerResponceMenu");
			Lua.UnregisterFunction("TerminarEntrevistaUserDefault");
			Lua.UnregisterFunction("TerminarEntrevistaUser");
			Lua.UnregisterFunction("TerminarEntrevistaInviadaAOtraAgencia");
			Lua.UnregisterFunction("FemaleDespachada");
			Lua.UnregisterFunction("TerminarEntrevistaSelf");
			Lua.UnregisterFunction("ResponseProc1");
			Lua.UnregisterFunction("RegistrarConversantePreguntoSiActorEstaSeguroDeRetirarla");
			Lua.UnregisterFunction("LeerConversantePreguntoSiActorEstaSeguroDeRetirarla");
			this.Clear();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x000162AF File Offset: 0x000144AF
		public void TerminarEntrevistaInviadaAOtraAgencia()
		{
			this.m_manager.femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaAOtraAgencia;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000162C0 File Offset: 0x000144C0
		public void TerminarEntrevistaUser(object interesadoObject)
		{
			bool flag = Convert.ToBoolean(interesadoObject);
			this.FemaleDespachada(flag);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000162DB File Offset: 0x000144DB
		public void TerminarEntrevistaUserDefault()
		{
			this.m_manager.femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorUser;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000162EC File Offset: 0x000144EC
		public void TerminarEntrevistaSelf(object reaccionObj)
		{
			ReaccionHumana reaccionHumana;
			if (!Enum.TryParse<ReaccionHumana>(reaccionObj.ToString(), out reaccionHumana))
			{
				Debug.LogException(new InvalidOperationException(), this);
				return;
			}
			this.FemaleDespachadaSelf(reaccionHumana);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0001631C File Offset: 0x0001451C
		public void FemaleDespachada(bool interesado)
		{
			EntrevistaConFemaleCharacter.FemalePresencia femalePresencia;
			if (interesado)
			{
				femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorUserInteresado;
			}
			else
			{
				femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorUserNoInteresado;
			}
			this.m_manager.femalePresencia = femalePresencia;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00016340 File Offset: 0x00014540
		public void FemaleDespachadaSelf(ReaccionHumana reaccion)
		{
			EntrevistaConFemaleCharacter.FemalePresencia femalePresencia;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion == ReaccionHumana.dolor)
				{
					femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaDolor;
					goto IL_004C;
				}
				if (reaccion == ReaccionHumana.rabia)
				{
					femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaRabia;
					goto IL_004C;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.arousal)
				{
					femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaArousal;
					goto IL_004C;
				}
				if (reaccion == ReaccionHumana.miedo)
				{
					femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaMiedo;
					goto IL_004C;
				}
				if (reaccion == ReaccionHumana.decepcion)
				{
					femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaDecepcion;
					goto IL_004C;
				}
			}
			throw new ArgumentOutOfRangeException(reaccion.ToString());
			IL_004C:
			this.m_manager.femalePresencia = femalePresencia;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x000163A8 File Offset: 0x000145A8
		public void RegistrarConversantePreguntoSiActorEstaSeguroDeRetirarla()
		{
			try
			{
				RegistroDeFuncionesDeCharacterMemoria.RegistrarDatoEnSessionStatic(DialogueLua.GetVariable("ConversantID").AsString, "DESPACHAR_SEGURIDAD_PREGUNTA");
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000163EC File Offset: 0x000145EC
		public bool LeerConversantePreguntoSiActorEstaSeguroDeRetirarla()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.DatoRegistradoEnSessionStatic(DialogueLua.GetVariable("ConversantID").AsString, "DESPACHAR_SEGURIDAD_PREGUNTA");
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00016434 File Offset: 0x00014634
		public bool ProcPrimerResponceMenu(float mod = 1f)
		{
			return Random.value < this.probabilidadDePrimerResponce * mod;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00016445 File Offset: 0x00014645
		public bool CurrentCharDePoolEsConocida()
		{
			return this.m_manager.currentFemaleCharacterMemoriaPermanente.ConoceACurrentMainCharacter();
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00016457 File Offset: 0x00014657
		public void CurrentCharRegistrarComoConocida()
		{
			this.m_manager.currentFemaleCharacterMemoriaPermanente.RegistrarCurrentMainCharacterComoConocido();
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00016469 File Offset: 0x00014669
		public void CurrentCharRegistrarComoSaludado()
		{
			this.m_manager.currentFemaleCharacterMemoriaPermanente.RegistrarCurrentMainCharacterComoSaludado(Singleton<TiempoDeJuego>.instance.now);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00016485 File Offset: 0x00014685
		public bool CurrentCharDePoolEsTimida()
		{
			return this.m_manager.currentFemaleCharacterPersonalidad.timido;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00016497 File Offset: 0x00014697
		public bool CurrentCharDePoolEsPervertida()
		{
			return this.m_manager.currentFemaleCharacterPersonalidad.pervertido;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000164A9 File Offset: 0x000146A9
		public bool CurrentCharDePoolEsRespetuoza()
		{
			return this.m_manager.currentFemaleCharacterPersonalidad.respetuoso;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x000164BB File Offset: 0x000146BB
		public bool CurrentCharDePoolEsGrosera()
		{
			return this.m_manager.currentFemaleCharacterPersonalidad.grosero;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000164D0 File Offset: 0x000146D0
		public bool ResponseProc1(float countFloat, float indexFloat)
		{
			bool flag;
			try
			{
				int num = Mathf.RoundToInt(countFloat);
				int num2 = Mathf.RoundToInt(indexFloat);
				float num3 = 1f / (float)num;
				float num4 = (float)num2 * num3;
				float num5 = (float)(num2 + 1) * num3;
				float num6;
				switch (num)
				{
				case 2:
					num6 = this.m_chances2;
					break;
				case 3:
					num6 = this.m_chances3;
					break;
				case 4:
					num6 = this.m_chances4;
					break;
				case 5:
					num6 = this.m_chances5;
					break;
				case 6:
					num6 = this.m_chances6;
					break;
				default:
					throw new ArgumentOutOfRangeException(num.ToString());
				}
				if (num2 + 1 == num)
				{
					num5 = 1f;
				}
				if (num2 == 0)
				{
					num4 = 0f;
				}
				if (num4 == num5)
				{
					throw new InvalidOperationException();
				}
				flag = num6 >= num4 && num6 <= num5;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x000165B4 File Offset: 0x000147B4
		public override void OnUpdateEvent1()
		{
			this.m_chances2 = Random.value;
			this.m_chances3 = Random.value;
			this.m_chances4 = Random.value;
			this.m_chances5 = Random.value;
			this.m_chances6 = Random.value;
			this.m_chances2UpdateID = (this.m_chances3UpdateID = (this.m_chances4UpdateID = (this.m_chances5UpdateID = (this.m_chances6UpdateID = ForcedUpdateId.current))));
		}

		// Token: 0x04000200 RID: 512
		public float probabilidadDePrimerResponce = 0.15f;

		// Token: 0x04000201 RID: 513
		[ReadOnlyUI]
		[SerializeField]
		private float m_chances2;

		// Token: 0x04000202 RID: 514
		[ReadOnlyUI]
		[SerializeField]
		private float m_chances3;

		// Token: 0x04000203 RID: 515
		[ReadOnlyUI]
		[SerializeField]
		private float m_chances4;

		// Token: 0x04000204 RID: 516
		[ReadOnlyUI]
		[SerializeField]
		private float m_chances5;

		// Token: 0x04000205 RID: 517
		[ReadOnlyUI]
		[SerializeField]
		private float m_chances6;

		// Token: 0x04000206 RID: 518
		private ForcedUpdateId m_chances2UpdateID;

		// Token: 0x04000207 RID: 519
		private ForcedUpdateId m_chances3UpdateID;

		// Token: 0x04000208 RID: 520
		private ForcedUpdateId m_chances4UpdateID;

		// Token: 0x04000209 RID: 521
		private ForcedUpdateId m_chances5UpdateID;

		// Token: 0x0400020A RID: 522
		private ForcedUpdateId m_chances6UpdateID;

		// Token: 0x0400020B RID: 523
		private EntrevistaConFemaleCharacter m_manager;

		// Token: 0x0400020C RID: 524
		private const string DespacharSeguridadPreguntaKey = "DESPACHAR_SEGURIDAD_PREGUNTA";
	}
}
