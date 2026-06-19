using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Bones.Runtime.BoneColliders;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts;
using Assets._ReusableScripts.BoneColliders;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.VertExmotions
{
	// Token: 0x02000008 RID: 8
	public sealed class SensoresDeMaleCharacter : SensoresDeCharacter
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000251E File Offset: 0x0000071E
		public ModificableDeBool puedeProducirSensoresParaManoAND
		{
			get
			{
				return this.m_puedeProducirSensoresParaManoAND;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002526 File Offset: 0x00000726
		public ModificableDeBool puedeProducirSensoresParaFingerAND
		{
			get
			{
				return this.m_puedeProducirSensoresParaFingerAND;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000252E File Offset: 0x0000072E
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.meshGeneralModsUpdate1);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002537 File Offset: 0x00000737
		protected override int maxSensorCount
		{
			get
			{
				return 59;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000253C File Offset: 0x0000073C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
			this.m_modsDeLayers = new SensoresUtils.LayerMods[] { this.skinMods, this.ropaMods, this.ropaInteriorMods, this.ropaExteriorMods, this.subSkinMods };
			this.m_stateChanger = new SensoresUtils.CambiarEstadoDeSensoresHandler(base.CambiarEstadoDeSensores);
			this.m_presupuestoDeEstado.Add(0, new SensoresDeMaleCharacter.PresupuestoNone());
			this.m_presupuestoDeEstado.Add(2, new SensoresDeMaleCharacter.PresupuestoMano());
			this.m_presupuestoDeEstado.Add(1, new SensoresDeMaleCharacter.PresupuestoPene());
			this.m_presupuestoDeEstado.Add(5, new SensoresDeMaleCharacter.PresupuestoPeneMano());
			this.m_presupuestoDeEstado.Add(3, new SensoresDeMaleCharacter.PresupuestoDedo());
			this.m_presupuestoDeEstado.Add(6, new SensoresDeMaleCharacter.PresupuestoPeneDedo());
			this.m_presupuestoDeEstado.Add(4, new SensoresDeMaleCharacter.PresupuestoProp());
			this.m_presupuestoDeEstado.Add(7, new SensoresDeMaleCharacter.PresupuestoPropPene());
			this.m_presupuestoDeEstado.Add(8, new SensoresDeMaleCharacter.PresupuestoPropMano());
			this.m_presupuestoDeEstado.Add(9, new SensoresDeMaleCharacter.PresupuestoPropDedo());
			this.m_presupuestoDeEstado.Add(11, new SensoresDeMaleCharacter.PresupuestoPropPeneDedo());
			this.m_presupuestoDeEstado.Add(10, new SensoresDeMaleCharacter.PresupuestoPropPeneMano());
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000266F File Offset: 0x0000086F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_currentEstado = SensoresDeMaleCharacter.Estado.None;
			this.UpdateCurrentPresupuesto();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002685 File Offset: 0x00000885
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_Penis == null || this.m_finger == null)
			{
				this.m_Penis = this.GetComponentEnRoot(true);
				this.m_finger = this.GetComponentEnRoot(true);
				yield return null;
			}
			this.handController = this.GetComponentEnRoot(false);
			if (this.handController == null)
			{
				throw new ArgumentNullException("handController", "handController null reference.");
			}
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_PuppetExtraColliders = this.GetComponentEnRoot(false);
			if (this.m_PuppetExtraColliders == null)
			{
				throw new ArgumentNullException("m_PuppetExtraColliders", "m_PuppetExtraColliders null reference.");
			}
			yield break;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002694 File Offset: 0x00000894
		public override void OnUpdateEvent1()
		{
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			if (((current != null) ? current.character : null) == null)
			{
				return;
			}
			try
			{
				bool flag = false;
				bool flag2 = false;
				int num = 0;
				int num2 = 0;
				Singleton<CharacteresActivos>.instance.GetSlavesDe<IToyPropCharacter>(this.m_character, this.m_ToyPropsTEMP, this.m_ToyPropsSetTEMP);
				for (int i = 0; i < this.m_ToyPropsTEMP.Count; i++)
				{
					IToyPropCharacter toyPropCharacter = this.m_ToyPropsTEMP[i];
					IPeneConPartes peneConPartes = ((toyPropCharacter != null) ? toyPropCharacter.sexualProp : null) as IPeneConPartes;
					IPropPeneConPartes propPeneConPartes = peneConPartes as IPropPeneConPartes;
					if (peneConPartes != null && (propPeneConPartes == null || propPeneConPartes.propEstaActivo))
					{
						flag = true;
						num++;
						this.m_PropsPenesTEMP.Add(peneConPartes);
					}
				}
				Singleton<CharacteresActivos>.instance.GetSlavesDeIgnoring<IPropCharacter>(this.m_character, this.m_PropsTEMP, this.m_ToyPropsSetTEMP);
				for (int j = 0; j < this.m_PropsTEMP.Count; j++)
				{
					IPropCharacter propCharacter = this.m_PropsTEMP[j];
					IGrabablePropConSensores grabablePropConSensores = ((propCharacter != null) ? propCharacter.prop : null) as IGrabablePropConSensores;
					if (grabablePropConSensores != null && grabablePropConSensores.propEstaActivo)
					{
						flag2 = true;
						num2++;
						this.m_PropsGrabablesTEMP.Add(grabablePropConSensores);
					}
				}
				bool flag3 = !this.m_Penis.hidden && this.m_Penis.currentRealErectionValue >= 1f && this.m_Penis.isVisible;
				bool flag4 = this.handController.enabled && this.handController.tipoDePose == HandTipoDePose.massage && this.m_puedeProducirSensoresParaManoAND.And(true);
				bool flag5 = this.handController.enabled && this.handController.tipoDePose == HandTipoDePose.finger && this.m_puedeProducirSensoresParaFingerAND.And(true);
				this.m_currentEstado = this.GetEstado(flag || flag2, flag3, flag4, flag5);
				this.m_currentPenePropsCount = num;
				this.m_currentNonPenePropsCount = num2;
				this.UpdateCurrentPresupuesto();
			}
			finally
			{
				this.m_PropsPenesTEMP.Clear();
				this.m_ToyPropsTEMP.Clear();
				this.m_ToyPropsSetTEMP.Clear();
				this.m_PropsTEMP.Clear();
				this.m_PropsGrabablesTEMP.Clear();
				this.m_lastEstado = this.m_currentEstado;
				this.m_lastPenePropsCount = this.m_currentPenePropsCount;
				this.m_lastNonPenePropsCount = this.m_currentNonPenePropsCount;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000028E8 File Offset: 0x00000AE8
		private void UpdateCurrentPresupuesto()
		{
			SensoresDeCharacter.Presupuesto presupuesto = this.GetPresupuesto(this.m_currentEstado);
			if (this.m_currentEstado != this.m_lastEstado || this.m_currentPenePropsCount != this.m_lastPenePropsCount || this.m_currentNonPenePropsCount != this.m_lastNonPenePropsCount)
			{
				this.GetPresupuesto(this.m_lastEstado).OnTermina(this, this.m_sensoresDisponibles);
				presupuesto.OnComienza(this, this.m_sensoresDisponibles);
			}
			presupuesto.Update(this, this.m_sensoresDisponibles);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002960 File Offset: 0x00000B60
		private SensoresDeMaleCharacter.Estado GetEstado(bool tieneProp, bool tienePene, bool tieneMano, bool tieneDedo)
		{
			if (!tieneProp && !tienePene && !tieneMano && !tieneDedo)
			{
				return SensoresDeMaleCharacter.Estado.None;
			}
			if (tieneProp && tienePene && tieneMano && tieneDedo)
			{
				Debug.LogError("TODO, aun no es compatible con prop,pene,mano,dedo");
				return SensoresDeMaleCharacter.Estado.None;
			}
			if (tieneProp && tienePene && tieneDedo)
			{
				return SensoresDeMaleCharacter.Estado.propPeneDedo;
			}
			if (tieneProp && tienePene && tieneMano)
			{
				return SensoresDeMaleCharacter.Estado.propPeneMano;
			}
			if (tieneProp && tienePene)
			{
				return SensoresDeMaleCharacter.Estado.propPene;
			}
			if (tieneProp && tieneDedo)
			{
				return SensoresDeMaleCharacter.Estado.propDedo;
			}
			if (tieneProp && tieneMano)
			{
				return SensoresDeMaleCharacter.Estado.propMano;
			}
			if (tieneProp)
			{
				return SensoresDeMaleCharacter.Estado.prop;
			}
			if (tienePene && tieneMano)
			{
				return SensoresDeMaleCharacter.Estado.peneMano;
			}
			if (tienePene && tieneDedo)
			{
				return SensoresDeMaleCharacter.Estado.peneDedo;
			}
			if (tienePene)
			{
				return SensoresDeMaleCharacter.Estado.pene;
			}
			if (tieneMano)
			{
				return SensoresDeMaleCharacter.Estado.mano;
			}
			if (tieneDedo)
			{
				return SensoresDeMaleCharacter.Estado.dedo;
			}
			return SensoresDeMaleCharacter.Estado.None;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000029E4 File Offset: 0x00000BE4
		private SensoresDeCharacter.Presupuesto GetPresupuesto(SensoresDeMaleCharacter.Estado estado)
		{
			SensoresDeCharacter.Presupuesto presupuesto;
			this.m_presupuestoDeEstado.TryGetValue((int)estado, out presupuesto);
			return presupuesto;
		}

		// Token: 0x04000006 RID: 6
		[SerializeField]
		private ModificableDeBool m_puedeProducirSensoresParaManoAND = new ModificableDeBool(true);

		// Token: 0x04000007 RID: 7
		[SerializeField]
		private ModificableDeBool m_puedeProducirSensoresParaFingerAND = new ModificableDeBool(true);

		// Token: 0x04000008 RID: 8
		private Penis m_Penis;

		// Token: 0x04000009 RID: 9
		private Finger m_finger;

		// Token: 0x0400000A RID: 10
		private HandControllerV2 handController;

		// Token: 0x0400000B RID: 11
		private MaleChar m_character;

		// Token: 0x0400000C RID: 12
		private PuppetExtraColliders m_PuppetExtraColliders;

		// Token: 0x0400000D RID: 13
		[ReadOnlyUI]
		[SerializeField]
		private SensoresDeMaleCharacter.Estado m_currentEstado;

		// Token: 0x0400000E RID: 14
		[ReadOnlyUI]
		[SerializeField]
		private SensoresDeMaleCharacter.Estado m_lastEstado;

		// Token: 0x0400000F RID: 15
		[ReadOnlyUI]
		[SerializeField]
		private int m_currentPenePropsCount;

		// Token: 0x04000010 RID: 16
		[ReadOnlyUI]
		[SerializeField]
		private int m_currentNonPenePropsCount;

		// Token: 0x04000011 RID: 17
		[ReadOnlyUI]
		[SerializeField]
		private int m_lastPenePropsCount;

		// Token: 0x04000012 RID: 18
		[ReadOnlyUI]
		[SerializeField]
		private int m_lastNonPenePropsCount;

		// Token: 0x04000013 RID: 19
		private Dictionary<int, SensoresDeCharacter.Presupuesto> m_presupuestoDeEstado = new Dictionary<int, SensoresDeCharacter.Presupuesto>();

		// Token: 0x04000014 RID: 20
		private SensoresUtils.CambiarEstadoDeSensoresHandler m_stateChanger;

		// Token: 0x04000015 RID: 21
		[Header("SensorConfigs")]
		public SensoresUtils.Config paraPeneConfig = new SensoresUtils.Config
		{
			minPower = 3.8f,
			maxPower = 3.4f,
			widthToMinPower = 0.07f,
			widthToMaxPower = 0.02f,
			motionFactor = 0f,
			onPenetrationPower = 2.4f
		};

		// Token: 0x04000016 RID: 22
		public SensoresUtils.Config paraDedoConfig = new SensoresUtils.Config
		{
			minPower = 12f,
			maxPower = 12f,
			widthToMinPower = 1f,
			widthToMaxPower = 1f,
			envelopRadiusMod = 10f,
			inflateFromRadius = 0.05f,
			motionFactor = 0f,
			onPenetrationPower = 12f
		};

		// Token: 0x04000017 RID: 23
		public SensoresUtils.Config paraFingerConfig = new SensoresUtils.Config
		{
			minPower = 20f,
			maxPower = 10f,
			widthToMinPower = 0.03f,
			widthToMaxPower = 0.01f,
			envelopRadiusMod = 3f,
			inflateFromRadius = 0.125f,
			motionFactor = 0f,
			onPenetrationPower = 20f
		};

		// Token: 0x04000018 RID: 24
		[Header("Layer Modifications")]
		public SensoresUtils.LayerMods subSkinMods = new SensoresUtils.LayerMods
		{
			inflate = 2f
		};

		// Token: 0x04000019 RID: 25
		public SensoresUtils.LayerMods skinMods = new SensoresUtils.LayerMods();

		// Token: 0x0400001A RID: 26
		public SensoresUtils.LayerMods ropaInteriorMods = new SensoresUtils.LayerMods
		{
			inflate = 0.8333333f
		};

		// Token: 0x0400001B RID: 27
		public SensoresUtils.LayerMods ropaMods = new SensoresUtils.LayerMods
		{
			inflate = 0.666666f
		};

		// Token: 0x0400001C RID: 28
		public SensoresUtils.LayerMods ropaExteriorMods = new SensoresUtils.LayerMods
		{
			inflate = 0.5f
		};

		// Token: 0x0400001D RID: 29
		private SensoresUtils.LayerMods[] m_modsDeLayers;

		// Token: 0x0400001E RID: 30
		private List<IToyPropCharacter> m_ToyPropsTEMP = new List<IToyPropCharacter>();

		// Token: 0x0400001F RID: 31
		private HashSet<IToyPropCharacter> m_ToyPropsSetTEMP = new HashSet<IToyPropCharacter>();

		// Token: 0x04000020 RID: 32
		private List<IPeneConPartes> m_PropsPenesTEMP = new List<IPeneConPartes>();

		// Token: 0x04000021 RID: 33
		private List<IPropCharacter> m_PropsTEMP = new List<IPropCharacter>();

		// Token: 0x04000022 RID: 34
		private List<IGrabablePropConSensores> m_PropsGrabablesTEMP = new List<IGrabablePropConSensores>();

		// Token: 0x02000009 RID: 9
		public enum Estado
		{
			// Token: 0x04000024 RID: 36
			None,
			// Token: 0x04000025 RID: 37
			pene,
			// Token: 0x04000026 RID: 38
			mano,
			// Token: 0x04000027 RID: 39
			dedo,
			// Token: 0x04000028 RID: 40
			prop,
			// Token: 0x04000029 RID: 41
			peneMano,
			// Token: 0x0400002A RID: 42
			peneDedo,
			// Token: 0x0400002B RID: 43
			propPene,
			// Token: 0x0400002C RID: 44
			propMano,
			// Token: 0x0400002D RID: 45
			propDedo,
			// Token: 0x0400002E RID: 46
			propPeneMano,
			// Token: 0x0400002F RID: 47
			propPeneDedo
		}

		// Token: 0x0200000A RID: 10
		public class PresupuestoNone : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000025 RID: 37 RVA: 0x00002BE7 File Offset: 0x00000DE7
			public override int count
			{
				get
				{
					return 0;
				}
			}

			// Token: 0x06000026 RID: 38 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
			}

			// Token: 0x06000027 RID: 39 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
			}

			// Token: 0x06000028 RID: 40 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
			}
		}

		// Token: 0x0200000B RID: 11
		public class PresupuestoMano : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000006 RID: 6
			// (get) Token: 0x0600002A RID: 42 RVA: 0x00002BF4 File Offset: 0x00000DF4
			public override int count
			{
				get
				{
					return this.pulgar.Length + this.indice.Length + this.corazon.Length + this.angular.Length + this.menique.Length;
				}
			}

			// Token: 0x0600002B RID: 43 RVA: 0x00002C24 File Offset: 0x00000E24
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				this.pulgar = new SensoresUtils.SensorDeCapsuleData[4];
				this.indice = new SensoresUtils.SensorDeCapsuleData[4];
				this.corazon = new SensoresUtils.SensorDeCapsuleData[4];
				this.angular = new SensoresUtils.SensorDeCapsuleData[4];
				this.menique = new SensoresUtils.SensorDeCapsuleData[4];
				Queue<SensorConLayers> queue = new Queue<SensorConLayers>(todosLosSensores);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(this.pulgar, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(this.indice, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(this.corazon, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(this.angular, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(this.menique, queue);
				SensoresDeMaleCharacter.PresupuestoMano.SetFigersPointsAutoCalculeState(owner as SensoresDeMaleCharacter, true);
				owner.CambiarEstadoDeSensores(this.pulgar.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(this.indice.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(this.corazon.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(this.angular.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(this.menique.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
			}

			// Token: 0x0600002C RID: 44 RVA: 0x00002DD0 File Offset: 0x00000FD0
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				if (owner.updateSensores)
				{
					SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
					float num;
					SensoresDeMaleCharacter.PresupuestoMano.UpdateFingersState(sensoresDeMaleCharacter, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, out num, this.pulgar, this.indice, this.corazon, this.angular, this.menique);
					float num2 = Mathf.InverseLerp(0.975f, 1f, sensoresDeMaleCharacter.handController.weigth.InPow(4f));
					SensoresUtils.DedoDeMassageLinkedSensoresFullUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, num, 5, this.pulgar, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresFullUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, num, 5, this.indice, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresFullUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, num, 5, this.corazon, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresFullUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, num, 5, this.angular, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresFullUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, num, 5, this.menique, sensoresDeMaleCharacter.m_modsDeLayers, num2);
				}
				if (owner.debugDraw)
				{
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(this.pulgar.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(this.indice.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(this.corazon.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(this.angular.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(this.menique.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
				}
			}

			// Token: 0x0600002D RID: 45 RVA: 0x0000302C File Offset: 0x0000122C
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				if (sensoresDeMaleCharacter.m_PuppetExtraColliders != null)
				{
					SensoresDeMaleCharacter.PresupuestoMano.SetFigersPointsAutoCalculeState(sensoresDeMaleCharacter, false);
				}
				this.pulgar = null;
				this.indice = null;
				this.corazon = null;
				this.angular = null;
				this.menique = null;
			}

			// Token: 0x0600002E RID: 46 RVA: 0x00003078 File Offset: 0x00001278
			public static void UpdateFingersState(SensoresDeMaleCharacter owner, ICharacter targetChar, out float handRadius, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> pulgar, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> indice, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> corazon, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> angular, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> menique)
			{
				Side side = owner.handController.side;
				CreadorDeCollidersParaManos creadorDeCollidersParaManos;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(owner.handController.side.ToString());
					}
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosR;
				}
				else
				{
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosL;
				}
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeColliders(pulgar, targetChar, creadorDeCollidersParaManos.colliders.thumbDistal, creadorDeCollidersParaManos.colliders.thumbIntermediate, creadorDeCollidersParaManos.colliders.thumbProximal, creadorDeCollidersParaManos.colliders.handTothumb, 1f);
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeColliders(indice, targetChar, creadorDeCollidersParaManos.colliders.indexDistal, creadorDeCollidersParaManos.colliders.indexIntermediate, creadorDeCollidersParaManos.colliders.indexProximal, creadorDeCollidersParaManos.colliders.handToindex, 1f);
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeColliders(corazon, targetChar, creadorDeCollidersParaManos.colliders.middleDistal, creadorDeCollidersParaManos.colliders.middleIntermediate, creadorDeCollidersParaManos.colliders.middleProximal, creadorDeCollidersParaManos.colliders.handTomiddle, 1f);
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeColliders(angular, targetChar, creadorDeCollidersParaManos.colliders.ringDistal, creadorDeCollidersParaManos.colliders.ringIntermediate, creadorDeCollidersParaManos.colliders.ringProximal, creadorDeCollidersParaManos.colliders.handToring, 1f);
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeColliders(menique, targetChar, creadorDeCollidersParaManos.colliders.littleDistal, creadorDeCollidersParaManos.colliders.littleIntermediate, creadorDeCollidersParaManos.colliders.littleProximal, creadorDeCollidersParaManos.colliders.handTolittle, 1f);
				handRadius = creadorDeCollidersParaManos.localMedidas.handAncho2 * 2f * 0.5f * owner.m_character.escala;
			}

			// Token: 0x0600002F RID: 47 RVA: 0x00003214 File Offset: 0x00001414
			public static void SetFigersPointsAutoCalculeState(SensoresDeMaleCharacter owner, bool estate)
			{
				Side side = owner.handController.side;
				CreadorDeCollidersParaManos creadorDeCollidersParaManos;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(owner.handController.side.ToString());
					}
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosR;
				}
				else
				{
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosL;
				}
				CapsuleParteCollider thumbDistal = creadorDeCollidersParaManos.colliders.thumbDistal;
				CapsuleParteCollider thumbIntermediate = creadorDeCollidersParaManos.colliders.thumbIntermediate;
				CapsuleParteCollider thumbProximal = creadorDeCollidersParaManos.colliders.thumbProximal;
				CapsuleParteCollider handTothumb = creadorDeCollidersParaManos.colliders.handTothumb;
				CapsuleParteCollider indexDistal = creadorDeCollidersParaManos.colliders.indexDistal;
				CapsuleParteCollider indexIntermediate = creadorDeCollidersParaManos.colliders.indexIntermediate;
				CapsuleParteCollider indexProximal = creadorDeCollidersParaManos.colliders.indexProximal;
				CapsuleParteCollider handToindex = creadorDeCollidersParaManos.colliders.handToindex;
				CapsuleParteCollider middleDistal = creadorDeCollidersParaManos.colliders.middleDistal;
				CapsuleParteCollider middleIntermediate = creadorDeCollidersParaManos.colliders.middleIntermediate;
				CapsuleParteCollider middleProximal = creadorDeCollidersParaManos.colliders.middleProximal;
				CapsuleParteCollider handTomiddle = creadorDeCollidersParaManos.colliders.handTomiddle;
				CapsuleParteCollider ringDistal = creadorDeCollidersParaManos.colliders.ringDistal;
				CapsuleParteCollider ringIntermediate = creadorDeCollidersParaManos.colliders.ringIntermediate;
				CapsuleParteCollider ringProximal = creadorDeCollidersParaManos.colliders.ringProximal;
				CapsuleParteCollider handToring = creadorDeCollidersParaManos.colliders.handToring;
				CapsuleParteCollider littleDistal = creadorDeCollidersParaManos.colliders.littleDistal;
				CapsuleParteCollider littleIntermediate = creadorDeCollidersParaManos.colliders.littleIntermediate;
				CapsuleParteCollider littleProximal = creadorDeCollidersParaManos.colliders.littleProximal;
				creadorDeCollidersParaManos.colliders.handTolittle.constantCalculeCapsulePuntos = estate;
				littleProximal.constantCalculeCapsulePuntos = estate;
				littleIntermediate.constantCalculeCapsulePuntos = estate;
				littleDistal.constantCalculeCapsulePuntos = estate;
				handToring.constantCalculeCapsulePuntos = estate;
				ringProximal.constantCalculeCapsulePuntos = estate;
				ringIntermediate.constantCalculeCapsulePuntos = estate;
				ringDistal.constantCalculeCapsulePuntos = estate;
				handTomiddle.constantCalculeCapsulePuntos = estate;
				middleProximal.constantCalculeCapsulePuntos = estate;
				middleIntermediate.constantCalculeCapsulePuntos = estate;
				middleDistal.constantCalculeCapsulePuntos = estate;
				handToindex.constantCalculeCapsulePuntos = estate;
				indexProximal.constantCalculeCapsulePuntos = estate;
				indexIntermediate.constantCalculeCapsulePuntos = estate;
				indexDistal.constantCalculeCapsulePuntos = estate;
				handTothumb.constantCalculeCapsulePuntos = estate;
				thumbProximal.constantCalculeCapsulePuntos = estate;
				thumbIntermediate.constantCalculeCapsulePuntos = estate;
				thumbDistal.constantCalculeCapsulePuntos = estate;
			}

			// Token: 0x06000030 RID: 48 RVA: 0x0000340C File Offset: 0x0000160C
			private static void UpdateRadiusDeColliders(IReadOnlyList<SensoresUtils.SensorDeCapsuleData> target, ICharacter targetChar, ICapsuleParteCollider distal, ICapsuleParteCollider intermediate, ICapsuleParteCollider proximal, ICapsuleParteCollider toHand, float radiusMod)
			{
				if (!target.ContieneIndexReadOnly(0))
				{
					return;
				}
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeCollider(target[0], distal, targetChar, radiusMod);
				if (!target.ContieneIndexReadOnly(1))
				{
					return;
				}
				SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeCollider(target[1], intermediate, targetChar, radiusMod);
				if (target.ContieneIndexReadOnly(2))
				{
					SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeCollider(target[2], proximal, targetChar, radiusMod);
					if (target.ContieneIndexReadOnly(3))
					{
						SensoresDeMaleCharacter.PresupuestoMano.UpdateRadiusDeCollider(target[3], toHand, targetChar, radiusMod);
					}
					return;
				}
			}

			// Token: 0x06000031 RID: 49 RVA: 0x00003488 File Offset: 0x00001688
			private static void UpdateRadiusDeCollider(SensoresUtils.SensorDeCapsuleData par, ICapsuleParteCollider collider, ICharacter targetChar, float radiusMod)
			{
				par.worldpoint0 = collider.worldpoint0;
				par.worldpoint1 = collider.worldpoint1;
				par.sensorRadius = collider.radius * 2f * collider.lastFollowEscale * radiusMod;
				par.worldHeight = collider.height * collider.lastFollowEscale;
				par.width = collider.radius * 2f * (collider.lastFollowEscale / targetChar.escala);
			}

			// Token: 0x04000030 RID: 48
			private SensoresUtils.SensorDeCapsuleData[] pulgar;

			// Token: 0x04000031 RID: 49
			private SensoresUtils.SensorDeCapsuleData[] indice;

			// Token: 0x04000032 RID: 50
			private SensoresUtils.SensorDeCapsuleData[] corazon;

			// Token: 0x04000033 RID: 51
			private SensoresUtils.SensorDeCapsuleData[] angular;

			// Token: 0x04000034 RID: 52
			private SensoresUtils.SensorDeCapsuleData[] menique;
		}

		// Token: 0x0200000D RID: 13
		public static class PresupuestoPeneHelper
		{
			// Token: 0x0600003F RID: 63 RVA: 0x00003510 File Offset: 0x00001710
			public static void OnComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, ref List<SensorConLayers> linkedDePenisParts, int startIndex)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				int count = todosLosSensores.Count;
				Queue<SensorConLayers> queue = new Queue<SensorConLayers>(count - startIndex);
				for (int i = startIndex; i < count; i++)
				{
					queue.Enqueue(todosLosSensores[i]);
				}
				linkedDePenisParts = SensoresUtils.PeneALinkedSensorsFull(sensoresDeMaleCharacter.m_Penis, queue);
				owner.CambiarEstadoDeSensores(linkedDePenisParts, true, true);
			}

			// Token: 0x06000040 RID: 64 RVA: 0x00003568 File Offset: 0x00001768
			public static void Update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> linkedDePenisParts)
			{
				if (owner.updateSensores)
				{
					SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
					SensoresUtils.PeneLinkedSensorsFullUpdateV2(sensoresDeMaleCharacter.paraPeneConfig, owner.updateSensoresProperties, sensoresDeMaleCharacter.m_Penis, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, linkedDePenisParts, sensoresDeMaleCharacter.m_modsDeLayers, 0, 1);
				}
				if (owner.debugDraw)
				{
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(linkedDePenisParts, Color.white, owner.debugDrawInflate);
				}
			}

			// Token: 0x06000041 RID: 65 RVA: 0x000035C7 File Offset: 0x000017C7
			public static void OnTermina(SensoresDeCharacter owner, ref List<SensorConLayers> linkedDePenisParts)
			{
				linkedDePenisParts = null;
			}
		}

		// Token: 0x0200000E RID: 14
		public static class PresupuestoMano15Helper
		{
			// Token: 0x06000042 RID: 66 RVA: 0x000035CC File Offset: 0x000017CC
			public static void OnComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, ref SensoresUtils.SensorDeCapsuleData[] pulgar, ref SensoresUtils.SensorDeCapsuleData[] indice, ref SensoresUtils.SensorDeCapsuleData[] corazon, ref SensoresUtils.SensorDeCapsuleData[] angular, ref SensoresUtils.SensorDeCapsuleData[] menique, int startIndex)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				pulgar = new SensoresUtils.SensorDeCapsuleData[3];
				indice = new SensoresUtils.SensorDeCapsuleData[3];
				corazon = new SensoresUtils.SensorDeCapsuleData[3];
				angular = new SensoresUtils.SensorDeCapsuleData[3];
				menique = new SensoresUtils.SensorDeCapsuleData[3];
				int count = todosLosSensores.Count;
				Queue<SensorConLayers> queue = new Queue<SensorConLayers>(count - startIndex);
				for (int i = startIndex; i < count; i++)
				{
					queue.Enqueue(todosLosSensores[i]);
				}
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(pulgar, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(indice, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(corazon, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(angular, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(menique, queue);
				SensoresDeMaleCharacter.PresupuestoMano.SetFigersPointsAutoCalculeState(sensoresDeMaleCharacter, true);
				owner.CambiarEstadoDeSensores(pulgar.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(indice.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(corazon.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(angular.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
				owner.CambiarEstadoDeSensores(menique.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
			}

			// Token: 0x06000043 RID: 67 RVA: 0x0000376C File Offset: 0x0000196C
			public static void Update(SensoresDeCharacter owner, bool usarHandControllerWeigth, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> pulgar, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> indice, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> corazon, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> angular, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> menique)
			{
				if (owner.updateSensores)
				{
					SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
					float num;
					SensoresDeMaleCharacter.PresupuestoMano.UpdateFingersState(sensoresDeMaleCharacter, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, out num, pulgar, indice, corazon, angular, menique);
					float num2 = (usarHandControllerWeigth ? Mathf.InverseLerp(0.975f, 1f, sensoresDeMaleCharacter.handController.weigth.InPow(4f)) : 1f);
					SensoresUtils.DedoDeMassageLinkedSensoresHalfUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, pulgar, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresHalfUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, indice, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresHalfUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, corazon, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresHalfUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, angular, sensoresDeMaleCharacter.m_modsDeLayers, num2);
					SensoresUtils.DedoDeMassageLinkedSensoresHalfUpdate(sensoresDeMaleCharacter.paraDedoConfig, owner.updateSensoresProperties, menique, sensoresDeMaleCharacter.m_modsDeLayers, num2);
				}
				if (owner.debugDraw)
				{
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(pulgar.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(indice.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(corazon.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(angular.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(menique.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
				}
			}

			// Token: 0x06000044 RID: 68 RVA: 0x00003984 File Offset: 0x00001B84
			public static void OnTermina(SensoresDeCharacter owner, ref SensoresUtils.SensorDeCapsuleData[] pulgar, ref SensoresUtils.SensorDeCapsuleData[] indice, ref SensoresUtils.SensorDeCapsuleData[] corazon, ref SensoresUtils.SensorDeCapsuleData[] angular, ref SensoresUtils.SensorDeCapsuleData[] menique)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				if (sensoresDeMaleCharacter.m_PuppetExtraColliders != null)
				{
					SensoresDeMaleCharacter.PresupuestoMano.SetFigersPointsAutoCalculeState(sensoresDeMaleCharacter, false);
				}
				pulgar = null;
				indice = null;
				corazon = null;
				angular = null;
				menique = null;
			}
		}

		// Token: 0x02000010 RID: 16
		public static class PresupuestoDedoHelper
		{
			// Token: 0x06000051 RID: 81 RVA: 0x000039CC File Offset: 0x00001BCC
			public static void OnComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, ref List<SensorConLayers> indice, ref SensoresUtils.SensorDeCapsuleData[] nudillos, int startIndex)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				nudillos = new SensoresUtils.SensorDeCapsuleData[3];
				int count = todosLosSensores.Count;
				Queue<SensorConLayers> queue = new Queue<SensorConLayers>(count - startIndex);
				for (int i = startIndex; i < count; i++)
				{
					queue.Enqueue(todosLosSensores[i]);
				}
				indice = SensoresUtils.PeneALinkedSensorsFull(sensoresDeMaleCharacter.m_finger, queue);
				SensoresUtils.DedoDeMassageTransfomrsALinkedSensoresFull(nudillos, queue);
				SensoresDeMaleCharacter.PresupuestoDedoHelper.SetFigersPointsAutoCalculeState(sensoresDeMaleCharacter, true);
				owner.CambiarEstadoDeSensores(indice, true, true);
				owner.CambiarEstadoDeSensores(nudillos.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), true, true);
			}

			// Token: 0x06000052 RID: 82 RVA: 0x00003A70 File Offset: 0x00001C70
			public static void Update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> indice, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> nudillos)
			{
				if (owner.updateSensores)
				{
					SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
					SensoresDeMaleCharacter.PresupuestoDedoHelper.UpdateFingersState(sensoresDeMaleCharacter, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, nudillos);
					SensoresUtils.PeneLinkedSensorsFullUpdateV2(sensoresDeMaleCharacter.paraFingerConfig, owner.updateSensoresProperties, sensoresDeMaleCharacter.m_finger, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, indice, sensoresDeMaleCharacter.m_modsDeLayers, 0, 1);
					SensoresUtils.NudillosLinkedSensoresFullUpdate(sensoresDeMaleCharacter.paraFingerConfig, owner.updateSensoresProperties, nudillos, sensoresDeMaleCharacter.m_modsDeLayers, Mathf.InverseLerp(0.975f, 1f, sensoresDeMaleCharacter.handController.weigth.InPow(4f)));
				}
				if (owner.debugDraw)
				{
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(indice, Color.white, owner.debugDrawInflate);
					SensoresDeCharacter.Presupuesto.DebugDrawSensores(nudillos.Select((SensoresUtils.SensorDeCapsuleData par) => par.sensor).ToArray<SensorConLayers>(), Color.white, owner.debugDrawInflate);
				}
			}

			// Token: 0x06000053 RID: 83 RVA: 0x00003B58 File Offset: 0x00001D58
			public static void OnTermina(SensoresDeCharacter owner, ref List<SensorConLayers> indice, ref SensoresUtils.SensorDeCapsuleData[] nudillos)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				if (sensoresDeMaleCharacter.m_PuppetExtraColliders != null)
				{
					SensoresDeMaleCharacter.PresupuestoDedoHelper.SetFigersPointsAutoCalculeState(sensoresDeMaleCharacter, false);
				}
				indice = null;
				nudillos = null;
			}

			// Token: 0x06000054 RID: 84 RVA: 0x00003B88 File Offset: 0x00001D88
			public static void UpdateFingersState(SensoresDeMaleCharacter owner, ICharacter targetChar, IReadOnlyList<SensoresUtils.SensorDeCapsuleData> nudillos)
			{
				Side side = owner.handController.side;
				CreadorDeCollidersParaManos creadorDeCollidersParaManos;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(owner.handController.side.ToString());
					}
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosR;
				}
				else
				{
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosL;
				}
				SensoresDeMaleCharacter.PresupuestoDedoHelper.UpdateRadiusDeCollidersNudillos(nudillos, targetChar, creadorDeCollidersParaManos.colliders.middleProximal, creadorDeCollidersParaManos.colliders.ringProximal, creadorDeCollidersParaManos.colliders.littleProximal, 1f);
			}

			// Token: 0x06000055 RID: 85 RVA: 0x00003C10 File Offset: 0x00001E10
			public static void SetFigersPointsAutoCalculeState(SensoresDeMaleCharacter owner, bool estate)
			{
				Side side = owner.handController.side;
				CreadorDeCollidersParaManos creadorDeCollidersParaManos;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(owner.handController.side.ToString());
					}
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosR;
				}
				else
				{
					creadorDeCollidersParaManos = owner.m_PuppetExtraColliders.CreadorDeCollidersParaManosL;
				}
				CapsuleParteCollider middleProximal = creadorDeCollidersParaManos.colliders.middleProximal;
				CapsuleParteCollider ringProximal = creadorDeCollidersParaManos.colliders.ringProximal;
				creadorDeCollidersParaManos.colliders.littleProximal.constantCalculeCapsulePuntos = estate;
				ringProximal.constantCalculeCapsulePuntos = estate;
				middleProximal.constantCalculeCapsulePuntos = estate;
			}

			// Token: 0x06000056 RID: 86 RVA: 0x00003CA4 File Offset: 0x00001EA4
			private static void UpdateRadiusDeCollidersNudillos(IReadOnlyList<SensoresUtils.SensorDeCapsuleData> target, ICharacter targetChar, ICapsuleParteCollider proximalMiddle, ICapsuleParteCollider proximalRing, ICapsuleParteCollider proximalLittle, float radiusMod)
			{
				if (!target.ContieneIndexReadOnly(0))
				{
					return;
				}
				SensoresDeMaleCharacter.PresupuestoDedoHelper.UpdateRadiusDeCollider(target[0], proximalMiddle, targetChar, radiusMod);
				if (!target.ContieneIndexReadOnly(1))
				{
					return;
				}
				SensoresDeMaleCharacter.PresupuestoDedoHelper.UpdateRadiusDeCollider(target[1], proximalRing, targetChar, radiusMod);
				if (target.ContieneIndexReadOnly(2))
				{
					SensoresDeMaleCharacter.PresupuestoDedoHelper.UpdateRadiusDeCollider(target[2], proximalLittle, targetChar, radiusMod);
					return;
				}
			}

			// Token: 0x06000057 RID: 87 RVA: 0x00003D04 File Offset: 0x00001F04
			private static void UpdateRadiusDeCollider(SensoresUtils.SensorDeCapsuleData par, ICapsuleParteCollider collider, ICharacter targetChar, float radiusMod)
			{
				par.worldpoint0 = collider.worldpoint0;
				par.worldpoint1 = collider.worldpoint1;
				par.sensorRadius = collider.radius * 2f * collider.lastFollowEscale * radiusMod;
				par.worldHeight = collider.height * collider.lastFollowEscale;
				par.width = collider.radius * 2f * (collider.lastFollowEscale / targetChar.escala);
			}
		}

		// Token: 0x02000012 RID: 18
		public class PresupuestoPene : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000007 RID: 7
			// (get) Token: 0x0600005C RID: 92 RVA: 0x00003D83 File Offset: 0x00001F83
			public override int count
			{
				get
				{
					return this.linkedDePenisParts.Count;
				}
			}

			// Token: 0x0600005D RID: 93 RVA: 0x00003D90 File Offset: 0x00001F90
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnComienza(owner, todosLosSensores, ref this.linkedDePenisParts, 0);
			}

			// Token: 0x0600005E RID: 94 RVA: 0x00003DA0 File Offset: 0x00001FA0
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPeneHelper.Update(owner, this.linkedDePenisParts);
			}

			// Token: 0x0600005F RID: 95 RVA: 0x00003DAE File Offset: 0x00001FAE
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnTermina(owner, ref this.linkedDePenisParts);
			}

			// Token: 0x0400004E RID: 78
			private List<SensorConLayers> linkedDePenisParts;
		}

		// Token: 0x02000013 RID: 19
		public class PresupuestoPeneMano : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000061 RID: 97 RVA: 0x00003DBC File Offset: 0x00001FBC
			public override int count
			{
				get
				{
					return this.linkedDePenisParts.Count + this.pulgar.Length + this.indice.Length + this.corazon.Length + this.angular.Length + this.menique.Length;
				}
			}

			// Token: 0x06000062 RID: 98 RVA: 0x00003DF6 File Offset: 0x00001FF6
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.OnComienza(owner, todosLosSensores, ref this.pulgar, ref this.indice, ref this.corazon, ref this.angular, ref this.menique, 0);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnComienza(owner, todosLosSensores, ref this.linkedDePenisParts, 15);
			}

			// Token: 0x06000063 RID: 99 RVA: 0x00003E2D File Offset: 0x0000202D
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.Update(owner, true, this.pulgar, this.indice, this.corazon, this.angular, this.menique);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.Update(owner, this.linkedDePenisParts);
			}

			// Token: 0x06000064 RID: 100 RVA: 0x00003E60 File Offset: 0x00002060
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.OnTermina(owner, ref this.pulgar, ref this.indice, ref this.corazon, ref this.angular, ref this.menique);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnTermina(owner, ref this.linkedDePenisParts);
			}

			// Token: 0x0400004F RID: 79
			private SensoresUtils.SensorDeCapsuleData[] pulgar;

			// Token: 0x04000050 RID: 80
			private SensoresUtils.SensorDeCapsuleData[] indice;

			// Token: 0x04000051 RID: 81
			private SensoresUtils.SensorDeCapsuleData[] corazon;

			// Token: 0x04000052 RID: 82
			private SensoresUtils.SensorDeCapsuleData[] angular;

			// Token: 0x04000053 RID: 83
			private SensoresUtils.SensorDeCapsuleData[] menique;

			// Token: 0x04000054 RID: 84
			private List<SensorConLayers> linkedDePenisParts;
		}

		// Token: 0x02000014 RID: 20
		public class PresupuestoDedo : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000066 RID: 102 RVA: 0x00003E92 File Offset: 0x00002092
			public override int count
			{
				get
				{
					return this.indice.Count + this.nudillos.Length;
				}
			}

			// Token: 0x06000067 RID: 103 RVA: 0x00003EA8 File Offset: 0x000020A8
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnComienza(owner, todosLosSensores, ref this.indice, ref this.nudillos, 0);
			}

			// Token: 0x06000068 RID: 104 RVA: 0x00003EBE File Offset: 0x000020BE
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.Update(owner, this.indice, this.nudillos);
			}

			// Token: 0x06000069 RID: 105 RVA: 0x00003ED2 File Offset: 0x000020D2
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnTermina(owner, ref this.indice, ref this.nudillos);
			}

			// Token: 0x04000055 RID: 85
			private List<SensorConLayers> indice;

			// Token: 0x04000056 RID: 86
			private SensoresUtils.SensorDeCapsuleData[] nudillos;
		}

		// Token: 0x02000015 RID: 21
		public class PresupuestoPeneDedo : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600006B RID: 107 RVA: 0x00003EE6 File Offset: 0x000020E6
			public override int count
			{
				get
				{
					return this.indice.Count + this.nudillos.Length + this.linkedDePenisParts.Count;
				}
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00003F08 File Offset: 0x00002108
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnComienza(owner, todosLosSensores, ref this.indice, ref this.nudillos, 0);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnComienza(owner, todosLosSensores, ref this.linkedDePenisParts, this.indice.Count + this.nudillos.Length);
			}

			// Token: 0x0600006D RID: 109 RVA: 0x00003F3F File Offset: 0x0000213F
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.Update(owner, this.indice, this.nudillos);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.Update(owner, this.linkedDePenisParts);
			}

			// Token: 0x0600006E RID: 110 RVA: 0x00003F5F File Offset: 0x0000215F
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnTermina(owner, ref this.indice, ref this.nudillos);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnTermina(owner, ref this.linkedDePenisParts);
			}

			// Token: 0x04000057 RID: 87
			private List<SensorConLayers> indice;

			// Token: 0x04000058 RID: 88
			private SensoresUtils.SensorDeCapsuleData[] nudillos;

			// Token: 0x04000059 RID: 89
			private List<SensorConLayers> linkedDePenisParts;
		}

		// Token: 0x02000016 RID: 22
		public static class PresupuestoNonPenePropsHelper
		{
			// Token: 0x06000070 RID: 112 RVA: 0x00003F80 File Offset: 0x00002180
			public static int OnComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, ref SensorConLayers[][] propsSensors, int startIndex, IReadOnlyList<IGrabablePropConSensores> currentProps, ref IGrabablePropConSensores[] currentPropsCopy)
			{
				int num = 0;
				if (currentProps.Count > 10)
				{
					Debug.LogError("no se pueden tener mas de 5 props sexuales penetrables en scena");
				}
				currentPropsCopy = currentProps.ToArray<IGrabablePropConSensores>();
				propsSensors = new SensorConLayers[currentProps.Count][];
				int num2 = startIndex;
				for (int i = 0; i < currentProps.Count; i++)
				{
					IGrabablePropConSensores grabablePropConSensores = currentProps[i];
					grabablePropConSensores.UpdateSensorsData();
					if (grabablePropConSensores.sensorsData.Count > 5)
					{
						Debug.LogError("la maxima cantidad compatible de partes para prop es 5");
					}
					int count = grabablePropConSensores.sensorsData.Count;
					num += count;
					SensorConLayers[] array = new SensorConLayers[count];
					for (int j = 0; j < count; j++)
					{
						array[j] = todosLosSensores[num2];
						num2++;
					}
					propsSensors[i] = array;
					owner.CambiarEstadoDeSensores(array, grabablePropConSensores.linkedSensors, true);
				}
				return num;
			}

			// Token: 0x06000071 RID: 113 RVA: 0x0000404C File Offset: 0x0000224C
			public static void Update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers[]> penisSensors, IReadOnlyList<IGrabablePropConSensores> currentProps, SensoresUtils.Config config, SensoresUtils.LayerMods[] modsDeLayers)
			{
				if (owner.updateSensores)
				{
					Character character = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character;
					for (int i = 0; i < penisSensors.Count; i++)
					{
						SensorConLayers[] array = penisSensors[i];
						SensoresUtils.PropLinkedSensorsUpdate(config, owner.updateSensoresProperties, currentProps[i], character, array, modsDeLayers);
					}
				}
				if (owner.debugDraw)
				{
					for (int j = 0; j < penisSensors.Count; j++)
					{
						SensoresDeCharacter.Presupuesto.DebugDrawSensores(penisSensors[j], Color.white, owner.debugDrawInflate);
					}
				}
			}

			// Token: 0x06000072 RID: 114 RVA: 0x000040CC File Offset: 0x000022CC
			public static void OnTermina(SensoresDeCharacter owner, ref SensorConLayers[][] penisSensors, ref IGrabablePropConSensores[] currentPropsCopy)
			{
				for (int i = 0; i < penisSensors.Length; i++)
				{
					penisSensors[i] = null;
				}
				penisSensors = null;
				currentPropsCopy = null;
			}
		}

		// Token: 0x02000017 RID: 23
		public static class PresupuestoPenePropsHelper
		{
			// Token: 0x06000073 RID: 115 RVA: 0x000040F4 File Offset: 0x000022F4
			public static int OnComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores, ref SensorConLayers[][] penisSensors, int startIndex, IReadOnlyList<IPeneConPartes> currentPropsPenes, ref IPeneConPartes[] currentPropsPenesCopy, out int step)
			{
				int num = 0;
				if (currentPropsPenes.Count > 5)
				{
					Debug.LogError("no se pueden tener mas de 5 props sexuales penetrables en scena");
				}
				bool flag = currentPropsPenes.Count > 3;
				if (flag)
				{
					Debug.LogError("props en scena usaran version economica para ahorrar sensores, verificar que todo este bien");
				}
				currentPropsPenesCopy = currentPropsPenes.ToArray<IPeneConPartes>();
				step = (flag ? 2 : 1);
				penisSensors = new SensorConLayers[currentPropsPenes.Count][];
				int num2 = startIndex;
				for (int i = 0; i < currentPropsPenes.Count; i++)
				{
					IPeneConPartes peneConPartes = currentPropsPenes[i];
					if (peneConPartes.countDePartes > 10)
					{
						Debug.LogError("la maxima cantidad compatible de partes para prop es 10");
					}
					int num3 = Mathf.CeilToInt((float)peneConPartes.countDePartes / (float)step);
					int num4 = 1 + num3;
					num += num4;
					SensorConLayers[] array = new SensorConLayers[num4];
					for (int j = 0; j < num4; j++)
					{
						array[j] = todosLosSensores[num2];
						num2++;
					}
					penisSensors[i] = array;
					owner.CambiarEstadoDeSensores(array, true, true);
				}
				return num;
			}

			// Token: 0x06000074 RID: 116 RVA: 0x000041DC File Offset: 0x000023DC
			public static void Update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers[]> penisSensors, IReadOnlyList<IPeneConPartes> currentPropsPenes, SensoresUtils.Config config, SensoresUtils.LayerMods[] modsDeLayers, int step)
			{
				if (owner.updateSensores)
				{
					Character character = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character;
					for (int i = 0; i < penisSensors.Count; i++)
					{
						SensorConLayers[] array = penisSensors[i];
						SensoresUtils.PenePropLinkedSensorsUpdate(config, owner.updateSensoresProperties, currentPropsPenes[i], character, array, modsDeLayers, step);
					}
				}
				if (owner.debugDraw)
				{
					for (int j = 0; j < penisSensors.Count; j++)
					{
						SensoresDeCharacter.Presupuesto.DebugDrawSensores(penisSensors[j], Color.white, owner.debugDrawInflate);
					}
				}
			}

			// Token: 0x06000075 RID: 117 RVA: 0x00004260 File Offset: 0x00002460
			public static void OnTermina(SensoresDeCharacter owner, ref SensorConLayers[][] penisSensors, ref IPeneConPartes[] currentPropsPenesCopy)
			{
				for (int i = 0; i < penisSensors.Length; i++)
				{
					penisSensors[i] = null;
				}
				penisSensors = null;
				currentPropsPenesCopy = null;
			}
		}

		// Token: 0x02000018 RID: 24
		public class PresupuestoProp : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000076 RID: 118 RVA: 0x00004287 File Offset: 0x00002487
			public override int count
			{
				get
				{
					return this.penePropsData.m_propsSensorCount + this.penePropsData.m_propsSensorCount;
				}
			}

			// Token: 0x06000077 RID: 119 RVA: 0x000042A0 File Offset: 0x000024A0
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				this.penePropsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.penePropsData.penisSensors, 0, sensoresDeMaleCharacter.m_PropsPenesTEMP, ref this.penePropsData.currentPropsPenesCopy, out this.penePropsData.step);
				this.propsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.propsData.sensors, this.penePropsData.m_propsSensorCount, sensoresDeMaleCharacter.m_PropsGrabablesTEMP, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x06000078 RID: 120 RVA: 0x00004328 File Offset: 0x00002528
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.Update(owner, this.penePropsData.penisSensors, this.penePropsData.currentPropsPenesCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers, this.penePropsData.step);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.Update(owner, this.propsData.sensors, this.propsData.currentPropsCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers);
			}

			// Token: 0x06000079 RID: 121 RVA: 0x00004397 File Offset: 0x00002597
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnTermina(owner, ref this.penePropsData.penisSensors, ref this.penePropsData.currentPropsPenesCopy);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnTermina(owner, ref this.propsData.sensors, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x0400005A RID: 90
			private SensoresDeMaleCharacter.PresupuestoProp.PenePropsData penePropsData = new SensoresDeMaleCharacter.PresupuestoProp.PenePropsData();

			// Token: 0x0400005B RID: 91
			private SensoresDeMaleCharacter.PresupuestoProp.PropsData propsData = new SensoresDeMaleCharacter.PresupuestoProp.PropsData();

			// Token: 0x02000019 RID: 25
			public class PenePropsData
			{
				// Token: 0x0400005C RID: 92
				public SensorConLayers[][] penisSensors;

				// Token: 0x0400005D RID: 93
				public int step;

				// Token: 0x0400005E RID: 94
				public IPeneConPartes[] currentPropsPenesCopy;

				// Token: 0x0400005F RID: 95
				public int m_propsSensorCount;
			}

			// Token: 0x0200001A RID: 26
			public class PropsData
			{
				// Token: 0x04000060 RID: 96
				public SensorConLayers[][] sensors;

				// Token: 0x04000061 RID: 97
				public IGrabablePropConSensores[] currentPropsCopy;

				// Token: 0x04000062 RID: 98
				public int m_propsSensorCount;
			}
		}

		// Token: 0x0200001B RID: 27
		public class PresupuestoPropPene : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600007D RID: 125 RVA: 0x000043EF File Offset: 0x000025EF
			public override int count
			{
				get
				{
					return this.penePropsData.m_propsSensorCount + this.penePropsData.m_propsSensorCount + this.linkedDePenisParts.Count;
				}
			}

			// Token: 0x0600007E RID: 126 RVA: 0x00004414 File Offset: 0x00002614
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnComienza(owner, todosLosSensores, ref this.linkedDePenisParts, 0);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				this.penePropsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.penePropsData.penisSensors, this.linkedDePenisParts.Count, sensoresDeMaleCharacter.m_PropsPenesTEMP, ref this.penePropsData.currentPropsPenesCopy, out this.penePropsData.step);
				this.propsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.propsData.sensors, this.linkedDePenisParts.Count + this.penePropsData.m_propsSensorCount, sensoresDeMaleCharacter.m_PropsGrabablesTEMP, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x0600007F RID: 127 RVA: 0x000044C0 File Offset: 0x000026C0
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPeneHelper.Update(owner, this.linkedDePenisParts);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.Update(owner, this.penePropsData.penisSensors, this.penePropsData.currentPropsPenesCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers, this.penePropsData.step);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.Update(owner, this.propsData.sensors, this.propsData.currentPropsCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers);
			}

			// Token: 0x06000080 RID: 128 RVA: 0x0000453C File Offset: 0x0000273C
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnTermina(owner, ref this.linkedDePenisParts);
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnTermina(owner, ref this.penePropsData.penisSensors, ref this.penePropsData.currentPropsPenesCopy);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnTermina(owner, ref this.propsData.sensors, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x04000063 RID: 99
			private SensoresDeMaleCharacter.PresupuestoProp.PenePropsData penePropsData = new SensoresDeMaleCharacter.PresupuestoProp.PenePropsData();

			// Token: 0x04000064 RID: 100
			private SensoresDeMaleCharacter.PresupuestoProp.PropsData propsData = new SensoresDeMaleCharacter.PresupuestoProp.PropsData();

			// Token: 0x04000065 RID: 101
			private List<SensorConLayers> linkedDePenisParts;
		}

		// Token: 0x0200001C RID: 28
		public class PresupuestoPropMano : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000082 RID: 130 RVA: 0x000045AC File Offset: 0x000027AC
			public override int count
			{
				get
				{
					return this.penePropsData.m_propsSensorCount + this.penePropsData.m_propsSensorCount + this.pulgar.Length + this.indice.Length + this.corazon.Length + this.angular.Length + this.menique.Length;
				}
			}

			// Token: 0x06000083 RID: 131 RVA: 0x00004600 File Offset: 0x00002800
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.OnComienza(owner, todosLosSensores, ref this.pulgar, ref this.indice, ref this.corazon, ref this.angular, ref this.menique, 0);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				this.penePropsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.penePropsData.penisSensors, 15, sensoresDeMaleCharacter.m_PropsPenesTEMP, ref this.penePropsData.currentPropsPenesCopy, out this.penePropsData.step);
				this.propsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.propsData.sensors, 15 + this.penePropsData.m_propsSensorCount, sensoresDeMaleCharacter.m_PropsGrabablesTEMP, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x06000084 RID: 132 RVA: 0x000046B4 File Offset: 0x000028B4
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.Update(owner, false, this.pulgar, this.indice, this.corazon, this.angular, this.menique);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.Update(owner, this.penePropsData.penisSensors, this.penePropsData.currentPropsPenesCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers, this.penePropsData.step);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.Update(owner, this.propsData.sensors, this.propsData.currentPropsCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers);
			}

			// Token: 0x06000085 RID: 133 RVA: 0x00004748 File Offset: 0x00002948
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.OnTermina(owner, ref this.pulgar, ref this.indice, ref this.corazon, ref this.angular, ref this.menique);
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnTermina(owner, ref this.penePropsData.penisSensors, ref this.penePropsData.currentPropsPenesCopy);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnTermina(owner, ref this.propsData.sensors, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x04000066 RID: 102
			private SensoresDeMaleCharacter.PresupuestoProp.PenePropsData penePropsData = new SensoresDeMaleCharacter.PresupuestoProp.PenePropsData();

			// Token: 0x04000067 RID: 103
			private SensoresDeMaleCharacter.PresupuestoProp.PropsData propsData = new SensoresDeMaleCharacter.PresupuestoProp.PropsData();

			// Token: 0x04000068 RID: 104
			private SensoresUtils.SensorDeCapsuleData[] pulgar;

			// Token: 0x04000069 RID: 105
			private SensoresUtils.SensorDeCapsuleData[] indice;

			// Token: 0x0400006A RID: 106
			private SensoresUtils.SensorDeCapsuleData[] corazon;

			// Token: 0x0400006B RID: 107
			private SensoresUtils.SensorDeCapsuleData[] angular;

			// Token: 0x0400006C RID: 108
			private SensoresUtils.SensorDeCapsuleData[] menique;
		}

		// Token: 0x0200001D RID: 29
		public class PresupuestoPropPeneMano : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000087 RID: 135 RVA: 0x000047D0 File Offset: 0x000029D0
			public override int count
			{
				get
				{
					return this.linkedDePenisParts.Count + this.penePropsData.m_propsSensorCount + this.penePropsData.m_propsSensorCount + this.pulgar.Length + this.indice.Length + this.corazon.Length + this.angular.Length + this.menique.Length;
				}
			}

			// Token: 0x06000088 RID: 136 RVA: 0x00004830 File Offset: 0x00002A30
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.OnComienza(owner, todosLosSensores, ref this.pulgar, ref this.indice, ref this.corazon, ref this.angular, ref this.menique, 0);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnComienza(owner, todosLosSensores, ref this.linkedDePenisParts, 15);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				this.penePropsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.penePropsData.penisSensors, 15 + this.linkedDePenisParts.Count, sensoresDeMaleCharacter.m_PropsPenesTEMP, ref this.penePropsData.currentPropsPenesCopy, out this.penePropsData.step);
				this.propsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.propsData.sensors, 15 + this.linkedDePenisParts.Count + this.penePropsData.m_propsSensorCount, sensoresDeMaleCharacter.m_PropsGrabablesTEMP, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x06000089 RID: 137 RVA: 0x00004908 File Offset: 0x00002B08
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.Update(owner, false, this.pulgar, this.indice, this.corazon, this.angular, this.menique);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.Update(owner, this.linkedDePenisParts);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.Update(owner, this.penePropsData.penisSensors, this.penePropsData.currentPropsPenesCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers, this.penePropsData.step);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.Update(owner, this.propsData.sensors, this.propsData.currentPropsCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers);
			}

			// Token: 0x0600008A RID: 138 RVA: 0x000049A8 File Offset: 0x00002BA8
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoMano15Helper.OnTermina(owner, ref this.pulgar, ref this.indice, ref this.corazon, ref this.angular, ref this.menique);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnTermina(owner, ref this.linkedDePenisParts);
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnTermina(owner, ref this.penePropsData.penisSensors, ref this.penePropsData.currentPropsPenesCopy);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnTermina(owner, ref this.propsData.sensors, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x0400006D RID: 109
			private SensoresUtils.SensorDeCapsuleData[] pulgar;

			// Token: 0x0400006E RID: 110
			private SensoresUtils.SensorDeCapsuleData[] indice;

			// Token: 0x0400006F RID: 111
			private SensoresUtils.SensorDeCapsuleData[] corazon;

			// Token: 0x04000070 RID: 112
			private SensoresUtils.SensorDeCapsuleData[] angular;

			// Token: 0x04000071 RID: 113
			private SensoresUtils.SensorDeCapsuleData[] menique;

			// Token: 0x04000072 RID: 114
			private List<SensorConLayers> linkedDePenisParts;

			// Token: 0x04000073 RID: 115
			private SensoresDeMaleCharacter.PresupuestoProp.PenePropsData penePropsData = new SensoresDeMaleCharacter.PresupuestoProp.PenePropsData();

			// Token: 0x04000074 RID: 116
			private SensoresDeMaleCharacter.PresupuestoProp.PropsData propsData = new SensoresDeMaleCharacter.PresupuestoProp.PropsData();
		}

		// Token: 0x0200001E RID: 30
		public class PresupuestoPropDedo : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600008C RID: 140 RVA: 0x00004A3B File Offset: 0x00002C3B
			public override int count
			{
				get
				{
					return this.penePropsData.m_propsSensorCount + this.penePropsData.m_propsSensorCount + this.indice.Count + this.nudillos.Length;
				}
			}

			// Token: 0x0600008D RID: 141 RVA: 0x00004A6C File Offset: 0x00002C6C
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnComienza(owner, todosLosSensores, ref this.indice, ref this.nudillos, 0);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				this.penePropsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.penePropsData.penisSensors, this.indice.Count + this.nudillos.Length, sensoresDeMaleCharacter.m_PropsPenesTEMP, ref this.penePropsData.currentPropsPenesCopy, out this.penePropsData.step);
				this.propsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.propsData.sensors, this.indice.Count + this.nudillos.Length + this.penePropsData.m_propsSensorCount, sensoresDeMaleCharacter.m_PropsGrabablesTEMP, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x0600008E RID: 142 RVA: 0x00004B30 File Offset: 0x00002D30
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.Update(owner, this.indice, this.nudillos);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.Update(owner, this.penePropsData.penisSensors, this.penePropsData.currentPropsPenesCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers, this.penePropsData.step);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.Update(owner, this.propsData.sensors, this.propsData.currentPropsCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers);
			}

			// Token: 0x0600008F RID: 143 RVA: 0x00004BB4 File Offset: 0x00002DB4
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnTermina(owner, ref this.indice, ref this.nudillos);
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnTermina(owner, ref this.penePropsData.penisSensors, ref this.penePropsData.currentPropsPenesCopy);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnTermina(owner, ref this.propsData.sensors, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x04000075 RID: 117
			private List<SensorConLayers> indice;

			// Token: 0x04000076 RID: 118
			private SensoresUtils.SensorDeCapsuleData[] nudillos;

			// Token: 0x04000077 RID: 119
			private SensoresDeMaleCharacter.PresupuestoProp.PenePropsData penePropsData = new SensoresDeMaleCharacter.PresupuestoProp.PenePropsData();

			// Token: 0x04000078 RID: 120
			private SensoresDeMaleCharacter.PresupuestoProp.PropsData propsData = new SensoresDeMaleCharacter.PresupuestoProp.PropsData();
		}

		// Token: 0x0200001F RID: 31
		public class PresupuestoPropPeneDedo : SensoresDeCharacter.Presupuesto
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000091 RID: 145 RVA: 0x00004C29 File Offset: 0x00002E29
			public override int count
			{
				get
				{
					return this.linkedDePenisParts.Count + this.penePropsData.m_propsSensorCount + this.penePropsData.m_propsSensorCount + this.indice.Count + this.nudillos.Length;
				}
			}

			// Token: 0x06000092 RID: 146 RVA: 0x00004C64 File Offset: 0x00002E64
			protected override void onComienza(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnComienza(owner, todosLosSensores, ref this.indice, ref this.nudillos, 0);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnComienza(owner, todosLosSensores, ref this.linkedDePenisParts, this.indice.Count + this.nudillos.Length);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				this.penePropsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.penePropsData.penisSensors, this.indice.Count + this.nudillos.Length + this.linkedDePenisParts.Count, sensoresDeMaleCharacter.m_PropsPenesTEMP, ref this.penePropsData.currentPropsPenesCopy, out this.penePropsData.step);
				this.propsData.m_propsSensorCount = SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnComienza(owner, todosLosSensores, ref this.propsData.sensors, this.indice.Count + this.nudillos.Length + this.linkedDePenisParts.Count + this.penePropsData.m_propsSensorCount, sensoresDeMaleCharacter.m_PropsGrabablesTEMP, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x06000093 RID: 147 RVA: 0x00004D60 File Offset: 0x00002F60
			protected override void update(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.Update(owner, this.indice, this.nudillos);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.Update(owner, this.linkedDePenisParts);
				SensoresDeMaleCharacter sensoresDeMaleCharacter = owner as SensoresDeMaleCharacter;
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.Update(owner, this.penePropsData.penisSensors, this.penePropsData.currentPropsPenesCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers, this.penePropsData.step);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.Update(owner, this.propsData.sensors, this.propsData.currentPropsCopy, sensoresDeMaleCharacter.paraPeneConfig, sensoresDeMaleCharacter.m_modsDeLayers);
			}

			// Token: 0x06000094 RID: 148 RVA: 0x00004DF0 File Offset: 0x00002FF0
			protected override void onTermina(SensoresDeCharacter owner, IReadOnlyList<SensorConLayers> todosLosSensores)
			{
				SensoresDeMaleCharacter.PresupuestoDedoHelper.OnTermina(owner, ref this.indice, ref this.nudillos);
				SensoresDeMaleCharacter.PresupuestoPeneHelper.OnTermina(owner, ref this.linkedDePenisParts);
				SensoresDeMaleCharacter.PresupuestoPenePropsHelper.OnTermina(owner, ref this.penePropsData.penisSensors, ref this.penePropsData.currentPropsPenesCopy);
				SensoresDeMaleCharacter.PresupuestoNonPenePropsHelper.OnTermina(owner, ref this.propsData.sensors, ref this.propsData.currentPropsCopy);
			}

			// Token: 0x04000079 RID: 121
			private List<SensorConLayers> indice;

			// Token: 0x0400007A RID: 122
			private SensoresUtils.SensorDeCapsuleData[] nudillos;

			// Token: 0x0400007B RID: 123
			private List<SensorConLayers> linkedDePenisParts;

			// Token: 0x0400007C RID: 124
			private SensoresDeMaleCharacter.PresupuestoProp.PenePropsData penePropsData = new SensoresDeMaleCharacter.PresupuestoProp.PenePropsData();

			// Token: 0x0400007D RID: 125
			private SensoresDeMaleCharacter.PresupuestoProp.PropsData propsData = new SensoresDeMaleCharacter.PresupuestoProp.PropsData();
		}
	}
}
