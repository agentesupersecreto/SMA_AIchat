using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.VertExmotions
{
	// Token: 0x02000036 RID: 54
	public class SensoresDeSelfInternals : SensoresDeCharacter
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000104 RID: 260 RVA: 0x0000252E File Offset: 0x0000072E
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.meshGeneralModsUpdate1);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00007306 File Offset: 0x00005506
		protected override int maxSensorCount
		{
			get
			{
				return 22;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000730C File Offset: 0x0000550C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
			this.m_modsDeLayers = new SensoresUtils.LayerMods[] { this.skinMods, this.ropaMods, this.ropaInteriorMods, this.ropaExteriorMods, this.subSkinMods };
			this.m_stateChanger = new SensoresUtils.CambiarEstadoDeSensoresHandler(base.CambiarEstadoDeSensores);
			this.m_presupuestoDeEstado.Add(0, new SensoresDeSelfInternals.PresupuestoNone());
			this.m_presupuestoDeEstado.Add(1, new SensoresDeSelfInternals.PresupuestoUterusIntestinal());
			this.m_presupuestoDeEstado.Add(2, new SensoresDeSelfInternals.PresupuestoUterusIntestinoAndVagPenetrated());
			this.m_presupuestoDeEstado.Add(3, new SensoresDeSelfInternals.PresupuestoUterusIntestinoAndAnusPenetrated());
			this.m_presupuestoDeEstado.Add(4, new SensoresDeSelfInternals.PresupuestoUterusAndVagAndAnusPenetrated());
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000073C5 File Offset: 0x000055C5
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_currentEstado = SensoresDeSelfInternals.Estado.None;
			this.UpdateCurrentPresupuesto();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000073DB File Offset: 0x000055DB
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_vag = this.GetComponentEnRoot(false);
			this.m_VagInternals = this.GetComponentEnRoot(false);
			this.m_anus = this.GetComponentEnRoot(false);
			this.m_anusInternals = this.GetComponentEnRoot(false);
			this.m_GuiasParaInteracionesDeRopaHelper = this.GetComponentEnRoot(false);
			if (this.m_GuiasParaInteracionesDeRopaHelper == null)
			{
				throw new ArgumentNullException("m_GuiasParaInteracionesDeRopaHelper", "m_GuiasParaInteracionesDeRopaHelper null reference.");
			}
			this.m_anusAcumulable = this.m_anus.GetComponent<ISemenAcumulable>();
			while (this.m_anusAcumulable == null)
			{
				yield return null;
				this.m_anusAcumulable = this.m_anus.GetComponent<ISemenAcumulable>();
			}
			yield break;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000073EC File Offset: 0x000055EC
		public override void OnUpdateEvent1()
		{
			try
			{
				bool flag = this.m_VagInternals != null;
				bool isPenetrated = this.m_vag.isPenetrated;
				bool isPenetrated2 = this.m_anus.isPenetrated;
				bool flag2 = false;
				this.m_currentEstado = this.GetEstado(flag, isPenetrated, isPenetrated2, flag2);
				this.UpdateCurrentPresupuesto();
			}
			finally
			{
				this.m_lastEstado = this.m_currentEstado;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00007458 File Offset: 0x00005658
		private void UpdateCurrentPresupuesto()
		{
			SensoresDeCharacter.Presupuesto presupuesto = this.GetPresupuesto(this.m_currentEstado);
			if (this.m_currentEstado != this.m_lastEstado)
			{
				this.GetPresupuesto(this.m_lastEstado).OnTermina(this, this.m_sensoresDisponibles);
				presupuesto.OnComienza(this, this.m_sensoresDisponibles);
			}
			presupuesto.Update(this, this.m_sensoresDisponibles);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000074B2 File Offset: 0x000056B2
		private SensoresDeSelfInternals.Estado GetEstado(bool tieneUtero, bool vagPenetrated, bool AnusPenetrated, bool BocaPenetrated)
		{
			if (this.m_forcedEstado != SensoresDeSelfInternals.Estado.None)
			{
				return this.m_forcedEstado;
			}
			if (!tieneUtero && !vagPenetrated && !AnusPenetrated && !BocaPenetrated)
			{
				return SensoresDeSelfInternals.Estado.None;
			}
			if (!tieneUtero)
			{
				return SensoresDeSelfInternals.Estado.None;
			}
			if (vagPenetrated && AnusPenetrated)
			{
				return SensoresDeSelfInternals.Estado.uterusIntestinalAndAnusAndVagPenetrated;
			}
			if (vagPenetrated)
			{
				return SensoresDeSelfInternals.Estado.uterusIntestinalAndVagPenetrated;
			}
			if (AnusPenetrated)
			{
				return SensoresDeSelfInternals.Estado.uterusIntestinalAndAnusPenetrated;
			}
			return SensoresDeSelfInternals.Estado.uterusIntestinal;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000074EC File Offset: 0x000056EC
		private SensoresDeCharacter.Presupuesto GetPresupuesto(SensoresDeSelfInternals.Estado estado)
		{
			SensoresDeCharacter.Presupuesto presupuesto;
			this.m_presupuestoDeEstado.TryGetValue((int)estado, out presupuesto);
			return presupuesto;
		}

		// Token: 0x040000CA RID: 202
		private const int presupuestoParaPeneOrProp = 8;

		// Token: 0x040000CB RID: 203
		[Header("Internals Configs")]
		public float uterusInitialRadius = 0.02f;

		// Token: 0x040000CC RID: 204
		public float uterusMaxRadius = 0.1f;

		// Token: 0x040000CD RID: 205
		public float intestinalInitialRadius = 0.001f;

		// Token: 0x040000CE RID: 206
		public float intestinalMaxRadius = 0.3f;

		// Token: 0x040000CF RID: 207
		[SerializeField]
		private float m_intestinalForwardVsBackwardsW = 0.5f;

		// Token: 0x040000D0 RID: 208
		[SerializeField]
		private float m_intestinalUpwardsVsDownwardsW = 0.5f;

		// Token: 0x040000D1 RID: 209
		[Header("SensorConfigs")]
		public SensoresUtils.ConfigSimple configUterus = new SensoresUtils.ConfigSimple();

		// Token: 0x040000D2 RID: 210
		public SensoresUtils.ConfigSimple configIntestine = new SensoresUtils.ConfigSimple();

		// Token: 0x040000D3 RID: 211
		public SensoresDeSelfInternals.InternalConfig configVag = new SensoresDeSelfInternals.InternalConfig();

		// Token: 0x040000D4 RID: 212
		public SensoresDeSelfInternals.InternalConfig configAnus = new SensoresDeSelfInternals.InternalConfig();

		// Token: 0x040000D5 RID: 213
		[Header("Layer Modifications")]
		public SensoresUtils.LayerMods subSkinMods = new SensoresUtils.LayerMods
		{
			inflate = 0.5f
		};

		// Token: 0x040000D6 RID: 214
		public SensoresUtils.LayerMods skinMods = new SensoresUtils.LayerMods();

		// Token: 0x040000D7 RID: 215
		public SensoresUtils.LayerMods ropaInteriorMods = new SensoresUtils.LayerMods
		{
			inflate = 1.2f
		};

		// Token: 0x040000D8 RID: 216
		public SensoresUtils.LayerMods ropaMods = new SensoresUtils.LayerMods
		{
			inflate = 1.5000015f
		};

		// Token: 0x040000D9 RID: 217
		public SensoresUtils.LayerMods ropaExteriorMods = new SensoresUtils.LayerMods
		{
			inflate = 2f
		};

		// Token: 0x040000DA RID: 218
		[ReadOnlyUI]
		[SerializeField]
		private SensoresDeSelfInternals.Estado m_forcedEstado;

		// Token: 0x040000DB RID: 219
		[ReadOnlyUI]
		[SerializeField]
		private SensoresDeSelfInternals.Estado m_currentEstado;

		// Token: 0x040000DC RID: 220
		[ReadOnlyUI]
		[SerializeField]
		private SensoresDeSelfInternals.Estado m_lastEstado;

		// Token: 0x040000DD RID: 221
		private SensoresUtils.LayerMods[] m_modsDeLayers;

		// Token: 0x040000DE RID: 222
		private SensoresUtils.CambiarEstadoDeSensoresHandler m_stateChanger;

		// Token: 0x040000DF RID: 223
		private Dictionary<int, SensoresDeCharacter.Presupuesto> m_presupuestoDeEstado = new Dictionary<int, SensoresDeCharacter.Presupuesto>();

		// Token: 0x040000E0 RID: 224
		private VagHole m_vag;

		// Token: 0x040000E1 RID: 225
		private VagInternals m_VagInternals;

		// Token: 0x040000E2 RID: 226
		private AnusHole m_anus;

		// Token: 0x040000E3 RID: 227
		private AnusInternals m_anusInternals;

		// Token: 0x040000E4 RID: 228
		private GuiasParaInteracionesDeRopaHelper m_GuiasParaInteracionesDeRopaHelper;

		// Token: 0x040000E5 RID: 229
		private ISemenAcumulable m_anusAcumulable;

		// Token: 0x02000037 RID: 55
		[Serializable]
		public class InternalConfig : SensoresUtils.ConfigSimple
		{
			// Token: 0x040000E6 RID: 230
			public float baseToTipW = 1f;
		}

		// Token: 0x02000038 RID: 56
		public enum Estado
		{
			// Token: 0x040000E8 RID: 232
			None,
			// Token: 0x040000E9 RID: 233
			uterusIntestinal,
			// Token: 0x040000EA RID: 234
			uterusIntestinalAndVagPenetrated,
			// Token: 0x040000EB RID: 235
			uterusIntestinalAndAnusPenetrated,
			// Token: 0x040000EC RID: 236
			uterusIntestinalAndAnusAndVagPenetrated
		}

		// Token: 0x02000039 RID: 57
		public class PresupuestoNone : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700002D RID: 45
			// (get) Token: 0x0600010F RID: 271 RVA: 0x00002BE7 File Offset: 0x00000DE7
			public override int count
			{
				get
				{
					return 0;
				}
			}

			// Token: 0x06000110 RID: 272 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
			}

			// Token: 0x06000111 RID: 273 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
			}

			// Token: 0x06000112 RID: 274 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
			}
		}

		// Token: 0x0200003A RID: 58
		public class PresupuestoUterusIntestinal : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x06000114 RID: 276 RVA: 0x0000760E File Offset: 0x0000580E
			public override int count
			{
				get
				{
					return this.uterus.Length;
				}
			}

			// Token: 0x06000115 RID: 277 RVA: 0x00007618 File Offset: 0x00005818
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.uterus = new SensorConLayers[2];
				this.uterus[0] = todosLosSensores[0];
				this.uterus[1] = todosLosSensores[1];
				owner.CambiarEstadoDeSensores(this.uterus, false, true);
			}

			// Token: 0x06000116 RID: 278 RVA: 0x00007654 File Offset: 0x00005854
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				if (owner.updateSensores)
				{
					SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
					Transform uterusTip = sensoresDeSelfInternals.m_VagInternals.uterusTip;
					float internalsWorldScale = sensoresDeSelfInternals.m_VagInternals.internalsWorldScale;
					float num = Mathf.Lerp(1f, uterusTip.localScale.x, 0.333f);
					float num2 = Mathf.Clamp(sensoresDeSelfInternals.uterusInitialRadius * num, sensoresDeSelfInternals.uterusInitialRadius, sensoresDeSelfInternals.uterusMaxRadius);
					Vector3 vector = Vector3.Lerp(sensoresDeSelfInternals.m_VagInternals.GetUterusTipDefaulPosition(), sensoresDeSelfInternals.m_VagInternals.uterus.position, 0.333f);
					SensoresUtils.UpdateSensor(owner.updateSensoresProperties, this.uterus[0], vector, num2 * internalsWorldScale, -uterusTip.forward, sensoresDeSelfInternals.configUterus, sensoresDeSelfInternals.m_modsDeLayers, float.MaxValue);
					Transform exposeTorzo_001_F = sensoresDeSelfInternals.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_001_F;
					Transform exposeTorzo_001_B = sensoresDeSelfInternals.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_001_B;
					Transform exposeTorzo_F = sensoresDeSelfInternals.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_F;
					Transform exposeTorzo_B = sensoresDeSelfInternals.m_GuiasParaInteracionesDeRopaHelper.guias.ExposeTorzo_B;
					Vector3 vector2 = Vector3.Lerp(exposeTorzo_001_F.position, exposeTorzo_001_B.position, sensoresDeSelfInternals.m_intestinalForwardVsBackwardsW);
					Vector3 vector3 = Vector3.Lerp(exposeTorzo_F.position, exposeTorzo_B.position, sensoresDeSelfInternals.m_intestinalForwardVsBackwardsW);
					Vector3 vector4 = Vector3.Lerp(vector2, vector3, sensoresDeSelfInternals.m_intestinalUpwardsVsDownwardsW);
					Vector3 vector5 = exposeTorzo_F.position - exposeTorzo_B.position;
					float escala = sensoresDeSelfInternals.m_anus.owner.escala;
					float num3;
					float num4;
					sensoresDeSelfInternals.m_anusAcumulable.MililitrosAcumuladosTotal(out num3, out num4);
					this.m_currentIntestinalLLenadoW = Mathf.MoveTowards(this.m_currentIntestinalLLenadoW, num4, Time.deltaTime * 0.333f);
					float num5;
					if (this.m_currentIntestinalLLenadoW <= 1f)
					{
						num5 = Mathf.Lerp(sensoresDeSelfInternals.intestinalInitialRadius, sensoresDeSelfInternals.intestinalMaxRadius, this.m_currentIntestinalLLenadoW);
					}
					else
					{
						num5 = Mathf.Lerp(sensoresDeSelfInternals.intestinalMaxRadius, sensoresDeSelfInternals.intestinalMaxRadius * 1.25f, this.m_currentIntestinalLLenadoW - 1f);
					}
					SensoresUtils.UpdateSensor(owner.updateSensoresProperties, this.uterus[1], vector4, num5 * escala, vector5, sensoresDeSelfInternals.configIntestine, sensoresDeSelfInternals.m_modsDeLayers, float.MaxValue);
				}
				if (owner.debugDraw)
				{
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(this.uterus, Color.white, owner.debugDrawInflate);
				}
			}

			// Token: 0x06000117 RID: 279 RVA: 0x00007891 File Offset: 0x00005A91
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.uterus = null;
			}

			// Token: 0x040000ED RID: 237
			private SensorConLayers[] uterus;

			// Token: 0x040000EE RID: 238
			private float m_currentIntestinalLLenadoW;
		}

		// Token: 0x0200003B RID: 59
		public static class PresupuestoInternalPenetratedHelper
		{
			// Token: 0x06000119 RID: 281 RVA: 0x0000789C File Offset: 0x00005A9C
			public static void OnComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, Circular8BoneChain hole, ref SensorConLayers[] penisInHoleSensors, int startIndex)
			{
				int countDePartes = hole.PenetradoPor().countDePartes;
				penisInHoleSensors = new SensorConLayers[countDePartes];
				for (int i = 0; i < countDePartes; i++)
				{
					penisInHoleSensors[i] = todosLosSensores[i + startIndex];
				}
				owner.CambiarEstadoDeSensores(penisInHoleSensors, true, true);
			}

			// Token: 0x0600011A RID: 282 RVA: 0x000078E4 File Offset: 0x00005AE4
			public static void Update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, Circular8BoneChain hole, ref SensorConLayers[] penisInHoleSensors, SensoresDeSelfInternals.InternalConfig config, SensoresUtils.LayerMods[] modsDeLayers)
			{
				if (owner.updateSensores)
				{
					IPeneConPartes peneConPartes = hole.PenetradoPor() as IPeneConPartes;
					SensoresUtils.InternalsLinkedSensorsFullUpdate(config, owner.updateSensoresProperties, hole, peneConPartes, penisInHoleSensors, modsDeLayers, config.baseToTipW);
				}
				if (owner.debugDraw)
				{
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(penisInHoleSensors, Color.white, owner.debugDrawInflate);
				}
			}

			// Token: 0x0600011B RID: 283 RVA: 0x00007939 File Offset: 0x00005B39
			public static void OnTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, ref SensorConLayers[] penisInHoleSensors)
			{
				penisInHoleSensors = null;
			}
		}

		// Token: 0x0200003C RID: 60
		public class PresupuestoUterusIntestinoAndVagPenetrated : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700002F RID: 47
			// (get) Token: 0x0600011C RID: 284 RVA: 0x0000793E File Offset: 0x00005B3E
			public override int count
			{
				get
				{
					return this.m_uterusIntestinoPre.count + this.m_penisSensonrs.Length;
				}
			}

			// Token: 0x0600011D RID: 285 RVA: 0x00007954 File Offset: 0x00005B54
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
				this.m_uterusIntestinoPre = sensoresDeSelfInternals.GetPresupuesto(SensoresDeSelfInternals.Estado.uterusIntestinal);
				this.m_uterusIntestinoPre.OnComienza(owner, todosLosSensores);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnComienza(owner, todosLosSensores, sensoresDeSelfInternals.m_vag, ref this.m_penisSensonrs, this.m_uterusIntestinoPre.count);
			}

			// Token: 0x0600011E RID: 286 RVA: 0x000079A0 File Offset: 0x00005BA0
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.m_uterusIntestinoPre.Update(owner, todosLosSensores);
				SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.Update(owner, todosLosSensores, sensoresDeSelfInternals.m_vag, ref this.m_penisSensonrs, sensoresDeSelfInternals.configVag, sensoresDeSelfInternals.m_modsDeLayers);
			}

			// Token: 0x0600011F RID: 287 RVA: 0x000079E0 File Offset: 0x00005BE0
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.m_uterusIntestinoPre.OnTermina(owner, todosLosSensores);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnTermina(owner, todosLosSensores, ref this.m_penisSensonrs);
			}

			// Token: 0x040000EF RID: 239
			private SensoresDeCharacter.Presupuesto m_uterusIntestinoPre;

			// Token: 0x040000F0 RID: 240
			private SensorConLayers[] m_penisSensonrs;
		}

		// Token: 0x0200003D RID: 61
		public class PresupuestoUterusIntestinoAndAnusPenetrated : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000121 RID: 289 RVA: 0x000079FC File Offset: 0x00005BFC
			public override int count
			{
				get
				{
					return this.m_uterusIntestinoPre.count + this.m_penisSensonrs.Length;
				}
			}

			// Token: 0x06000122 RID: 290 RVA: 0x00007A14 File Offset: 0x00005C14
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
				this.m_uterusIntestinoPre = sensoresDeSelfInternals.GetPresupuesto(SensoresDeSelfInternals.Estado.uterusIntestinal);
				this.m_uterusIntestinoPre.OnComienza(owner, todosLosSensores);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnComienza(owner, todosLosSensores, sensoresDeSelfInternals.m_anus, ref this.m_penisSensonrs, this.m_uterusIntestinoPre.count);
			}

			// Token: 0x06000123 RID: 291 RVA: 0x00007A60 File Offset: 0x00005C60
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.m_uterusIntestinoPre.Update(owner, todosLosSensores);
				SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.Update(owner, todosLosSensores, sensoresDeSelfInternals.m_anus, ref this.m_penisSensonrs, sensoresDeSelfInternals.configAnus, sensoresDeSelfInternals.m_modsDeLayers);
			}

			// Token: 0x06000124 RID: 292 RVA: 0x00007AA0 File Offset: 0x00005CA0
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.m_uterusIntestinoPre.OnTermina(owner, todosLosSensores);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnTermina(owner, todosLosSensores, ref this.m_penisSensonrs);
			}

			// Token: 0x040000F1 RID: 241
			private SensoresDeCharacter.Presupuesto m_uterusIntestinoPre;

			// Token: 0x040000F2 RID: 242
			private SensorConLayers[] m_penisSensonrs;
		}

		// Token: 0x0200003E RID: 62
		public class PresupuestoUterusAndVagAndAnusPenetrated : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000126 RID: 294 RVA: 0x00007ABC File Offset: 0x00005CBC
			public override int count
			{
				get
				{
					return this.m_uterusPre.count + this.m_penisVagSensonrs.Length + this.m_penisAnalSensonrs.Length;
				}
			}

			// Token: 0x06000127 RID: 295 RVA: 0x00007ADC File Offset: 0x00005CDC
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
				this.m_uterusPre = sensoresDeSelfInternals.GetPresupuesto(SensoresDeSelfInternals.Estado.uterusIntestinal);
				this.m_uterusPre.OnComienza(owner, todosLosSensores);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnComienza(owner, todosLosSensores, sensoresDeSelfInternals.m_vag, ref this.m_penisVagSensonrs, this.m_uterusPre.count);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnComienza(owner, todosLosSensores, sensoresDeSelfInternals.m_anus, ref this.m_penisAnalSensonrs, this.m_uterusPre.count + sensoresDeSelfInternals.m_vag.PenetradoPor().countDePartes);
			}

			// Token: 0x06000128 RID: 296 RVA: 0x00007B58 File Offset: 0x00005D58
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.m_uterusPre.Update(owner, todosLosSensores);
				SensoresDeSelfInternals sensoresDeSelfInternals = owner as SensoresDeSelfInternals;
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.Update(owner, todosLosSensores, sensoresDeSelfInternals.m_vag, ref this.m_penisVagSensonrs, sensoresDeSelfInternals.configVag, sensoresDeSelfInternals.m_modsDeLayers);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.Update(owner, todosLosSensores, sensoresDeSelfInternals.m_anus, ref this.m_penisAnalSensonrs, sensoresDeSelfInternals.configAnus, sensoresDeSelfInternals.m_modsDeLayers);
			}

			// Token: 0x06000129 RID: 297 RVA: 0x00007BB7 File Offset: 0x00005DB7
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.m_uterusPre.OnTermina(owner, todosLosSensores);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnTermina(owner, todosLosSensores, ref this.m_penisVagSensonrs);
				SensoresDeSelfInternals.PresupuestoInternalPenetratedHelper.OnTermina(owner, todosLosSensores, ref this.m_penisAnalSensonrs);
			}

			// Token: 0x040000F3 RID: 243
			private SensoresDeCharacter.Presupuesto m_uterusPre;

			// Token: 0x040000F4 RID: 244
			private SensorConLayers[] m_penisVagSensonrs;

			// Token: 0x040000F5 RID: 245
			private SensorConLayers[] m_penisAnalSensonrs;
		}
	}
}
