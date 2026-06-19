using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using RootMotion.Dynamics;
using RootMotion.Dynamics.TavoRootMotion;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet
{
	// Token: 0x02000010 RID: 16
	[RequireComponent(typeof(PuppetMaster))]
	[RequireComponent(typeof(IPuppetUpdater))]
	[RequireComponent(typeof(PuppetMusclePropMods))]
	public class PuppetMuscleModsSegunOffsets : CustomMonobehaviour
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00004F4C File Offset: 0x0000314C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetMaster = base.GetComponent<PuppetMaster>();
			this.m_Updater = base.GetComponent<IPuppetUpdater>();
			this.m_PropModsHolder = base.GetComponent<PuppetMusclePropMods>();
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_ICharacter", "m_ICharacter null reference.");
			}
			if (!this.m_PuppetMaster.initiated)
			{
				PuppetMaster puppetMaster = this.m_PuppetMaster;
				puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPupperInitiated));
				return;
			}
			this.OnPupperInitiated();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004FE3 File Offset: 0x000031E3
		private void OnPupperInitiated()
		{
			this.CrearMods();
			if (!this.m_musclesSubcribed)
			{
				this.SubscribeToMuscles();
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004FF9 File Offset: 0x000031F9
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (!this.m_musclesSubcribed)
			{
				this.SubscribeToMuscles();
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000500F File Offset: 0x0000320F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.UnsubscribeToMuscles();
			this.ResetMods();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00005024 File Offset: 0x00003224
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_pinMods.ForEach(delegate(ModificadorDeFloat m)
			{
				m.TryRemoverDeOwner(true);
			});
			this.m_springMods.ForEach(delegate(ModificadorDeFloat m)
			{
				m.TryRemoverDeOwner(true);
			});
			this.m_damperMods.ForEach(delegate(ModificadorDeFloat m)
			{
				m.TryRemoverDeOwner(true);
			});
			this.m_pinMods = null;
			this.m_springMods = null;
			this.m_damperMods = null;
			this.m_pinModsPorTarget = null;
			this.m_springModsPorTarget = null;
			this.m_damperModsPorTarget = null;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000050E0 File Offset: 0x000032E0
		private void SubscribeToMuscles()
		{
			for (int i = 0; i < this.m_PuppetMaster.muscles.Length; i++)
			{
				this.m_PuppetMaster.muscles[i].updating += this.PuppetMuscleModsSegunOffsets_updating;
			}
			this.m_musclesSubcribed = true;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000512C File Offset: 0x0000332C
		private void UnsubscribeToMuscles()
		{
			for (int i = 0; i < this.m_PuppetMaster.muscles.Length; i++)
			{
				Muscle muscle = this.m_PuppetMaster.muscles[i];
				if (muscle != null)
				{
					muscle.updating -= this.PuppetMuscleModsSegunOffsets_updating;
				}
			}
			this.m_musclesSubcribed = false;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000517C File Offset: 0x0000337C
		private void CrearMods()
		{
			for (int i = 0; i < this.m_PuppetMaster.muscles.Length; i++)
			{
				Muscle muscle = this.m_PuppetMaster.muscles[i];
				PuppetMusclePropMods.PropModificables propModificables = this.m_PropModsHolder.Obtener(muscle);
				object obj = ((propModificables != null) ? propModificables.modificables : null);
				PuppetMusclePropMods.PropModificables propModificables2 = this.m_PropModsHolder.Obtener(muscle);
				ModificadorDeFloat modificadorDeFloat = ((propModificables2 != null) ? propModificables2.valoresMinimos : null).pinWeight.ObtenerModificadorNotNull(this);
				object obj2 = obj;
				ModificadorDeFloat modificadorDeFloat2 = obj2.muscleWeight.ObtenerModificadorNotNull(this);
				ModificadorDeFloat modificadorDeFloat3 = obj2.muscleDamper.ObtenerModificadorNotNull(this);
				this.m_pinModsPorTarget.Add(muscle.target, modificadorDeFloat);
				this.m_springModsPorTarget.Add(muscle.target, modificadorDeFloat2);
				this.m_damperModsPorTarget.Add(muscle.target, modificadorDeFloat3);
				this.m_pinMods.Add(modificadorDeFloat);
				this.m_springMods.Add(modificadorDeFloat2);
				this.m_damperMods.Add(modificadorDeFloat3);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005268 File Offset: 0x00003468
		private void PuppetMuscleModsSegunOffsets_updating(Muscle obj)
		{
			if (!base.enabled)
			{
				return;
			}
			MusclePinChangeSegunDistanceOffsets pinConfig = this.GetPinConfig(obj.grupo);
			ModificadorDeFloat modificadorDeFloat = this.m_pinModsPorTarget[obj.target];
			if (pinConfig.activated)
			{
				PuppetMusclePropMods.PropModificables propModificables = this.m_PropModsHolder.Obtener(obj);
				float num = Vector3.Distance(obj.targetAnimatedPosition, obj.rigidbody.position);
				num /= this.m_ICharacter.escala;
				float num2 = Mathf.InverseLerp(0f, pinConfig.distanceToMaxPinChange, num);
				num2 = num2.InPow(pinConfig.distanceInPower);
				modificadorDeFloat.valor.valor = Mathf.Clamp01(propModificables.valoresReales.pinWeight + pinConfig.maxPin * num2);
				modificadorDeFloat.valor.valor = (ExtendedMonoBehaviour.AlmostEqual(modificadorDeFloat.valor.valor, 0f, 0.01f) ? 0f : modificadorDeFloat.valor.valor);
				if (Application.isEditor)
				{
					this.SetOffset(this.m_currentDistances, num, obj.grupo);
				}
			}
			else
			{
				modificadorDeFloat.valor.valor = 0f;
			}
			MusclePropModsSegunRotationOffsets springDamperConfig = this.GetSpringDamperConfig(obj.grupo);
			ModificadorDeFloat modificadorDeFloat2 = this.m_springModsPorTarget[obj.target];
			ModificadorDeFloat modificadorDeFloat3 = this.m_damperModsPorTarget[obj.target];
			if (springDamperConfig.activated)
			{
				Quaternion quaternion = Quaternion.Inverse(obj.parentRotationTValle) * obj.rigidbody.rotation;
				float num3 = Quaternion.Angle(obj.localRotationBeforeMap, quaternion);
				float num4 = Mathf.InverseLerp(0f, springDamperConfig.angleToMaxModChange, num3);
				num4 = num4.InPow(springDamperConfig.angleInPower);
				modificadorDeFloat2.valor.valor = Mathf.Lerp(1f, springDamperConfig.maxSpringMod, num4);
				modificadorDeFloat3.valor.valor = Mathf.Lerp(1f, springDamperConfig.maxDamperMod, num4);
				if (Application.isEditor)
				{
					this.SetOffset(this.m_currentAngles, num3, obj.grupo);
					return;
				}
			}
			else
			{
				modificadorDeFloat2.valor.valor = 1f;
				modificadorDeFloat3.valor.valor = 1f;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005491 File Offset: 0x00003691
		public void ResetMods()
		{
			this.ResetPinMods();
			this.ResetSpringDamperMods();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000549F File Offset: 0x0000369F
		public void ResetPinMods()
		{
			this.m_pinMods.ForEach(delegate(ModificadorDeFloat m)
			{
				m.valor.valor = 0f;
			});
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000054CC File Offset: 0x000036CC
		public void ResetSpringDamperMods()
		{
			this.m_springMods.ForEach(delegate(ModificadorDeFloat m)
			{
				m.valor.valor = 1f;
			});
			this.m_damperMods.ForEach(delegate(ModificadorDeFloat m)
			{
				m.valor.valor = 1f;
			});
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005530 File Offset: 0x00003730
		public MusclePropModsSegunRotationOffsets GetSpringDamperConfig(Muscle.GroupCompleto grupo)
		{
			switch (grupo)
			{
			case Muscle.GroupCompleto.Hips:
				return this.springDamperMods.hips;
			case Muscle.GroupCompleto.Spine:
				return this.springDamperMods.spine1;
			case Muscle.GroupCompleto.Head:
				return this.springDamperMods.head;
			case Muscle.GroupCompleto.Arm:
				return this.springDamperMods.upperarms;
			case Muscle.GroupCompleto.Hand:
				return this.springDamperMods.hands;
			case Muscle.GroupCompleto.Leg:
				return this.springDamperMods.thighs;
			case Muscle.GroupCompleto.Foot:
				return this.springDamperMods.feets;
			default:
				switch (grupo)
				{
				case Muscle.GroupCompleto.Neck:
					return this.springDamperMods.neck;
				case Muscle.GroupCompleto.Chest:
					return this.springDamperMods.spine2;
				case Muscle.GroupCompleto.ForeArm:
					return this.springDamperMods.forearms;
				case Muscle.GroupCompleto.Calf:
					return this.springDamperMods.calfs;
				case Muscle.GroupCompleto.Shoulder:
					return this.springDamperMods.shoulders;
				default:
					throw new ArgumentOutOfRangeException(grupo.ToString());
				}
				break;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005624 File Offset: 0x00003824
		public MusclePinChangeSegunDistanceOffsets GetPinConfig(Muscle.GroupCompleto grupo)
		{
			switch (grupo)
			{
			case Muscle.GroupCompleto.Hips:
				return this.pinMods.hips;
			case Muscle.GroupCompleto.Spine:
				return this.pinMods.spine1;
			case Muscle.GroupCompleto.Head:
				return this.pinMods.head;
			case Muscle.GroupCompleto.Arm:
				return this.pinMods.upperarms;
			case Muscle.GroupCompleto.Hand:
				return this.pinMods.hands;
			case Muscle.GroupCompleto.Leg:
				return this.pinMods.thighs;
			case Muscle.GroupCompleto.Foot:
				return this.pinMods.feets;
			default:
				switch (grupo)
				{
				case Muscle.GroupCompleto.Neck:
					return this.pinMods.neck;
				case Muscle.GroupCompleto.Chest:
					return this.pinMods.spine2;
				case Muscle.GroupCompleto.ForeArm:
					return this.pinMods.forearms;
				case Muscle.GroupCompleto.Calf:
					return this.pinMods.calfs;
				case Muscle.GroupCompleto.Shoulder:
					return this.pinMods.shoulders;
				default:
					throw new ArgumentOutOfRangeException(grupo.ToString());
				}
				break;
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005718 File Offset: 0x00003918
		private void SetOffset(PuppetMuscleModsSegunOffsets.CurrentVals<float> target, float valor, Muscle.GroupCompleto grupo)
		{
			switch (grupo)
			{
			case Muscle.GroupCompleto.Hips:
				target.hips = valor;
				return;
			case Muscle.GroupCompleto.Spine:
				target.spine1 = valor;
				return;
			case Muscle.GroupCompleto.Head:
				target.head = valor;
				return;
			case Muscle.GroupCompleto.Arm:
				target.upperarms = valor;
				return;
			case Muscle.GroupCompleto.Hand:
				target.hands = valor;
				return;
			case Muscle.GroupCompleto.Leg:
				target.thighs = valor;
				return;
			case Muscle.GroupCompleto.Foot:
				target.feets = valor;
				return;
			default:
				switch (grupo)
				{
				case Muscle.GroupCompleto.Neck:
					target.neck = valor;
					return;
				case Muscle.GroupCompleto.Chest:
					target.spine2 = valor;
					return;
				case Muscle.GroupCompleto.ForeArm:
					target.forearms = valor;
					return;
				case Muscle.GroupCompleto.Calf:
					target.calfs = valor;
					return;
				case Muscle.GroupCompleto.Shoulder:
					target.shoulders = valor;
					return;
				default:
					throw new ArgumentOutOfRangeException(grupo.ToString());
				}
				break;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000057D8 File Offset: 0x000039D8
		public void LoadOnFemale(MusclescConfigPinChangeSegunDistanceOffsets PinMods, FemaleAnimController femaleController)
		{
			PinMods.AplicarOnFemale(this.pinMods, femaleController);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000057E7 File Offset: 0x000039E7
		public void LoadOnFemale(MusclesConfigPropModsSegunRotationOffsets SpringDamperMods, FemaleAnimController femaleController)
		{
			SpringDamperMods.AplicarOnFemale(this.springDamperMods, femaleController);
		}

		// Token: 0x0400003A RID: 58
		[SerializeField]
		private MusclescConfigPinChangeSegunDistanceOffsets pinMods = MusclescConfigPinChangeSegunDistanceOffsets.defaultDesactivado;

		// Token: 0x0400003B RID: 59
		[SerializeField]
		private MusclesConfigPropModsSegunRotationOffsets springDamperMods = MusclesConfigPropModsSegunRotationOffsets.defaultDesactivado;

		// Token: 0x0400003C RID: 60
		[SerializeField]
		private PuppetMuscleModsSegunOffsets.CurrentVals<float> m_currentDistances = new PuppetMuscleModsSegunOffsets.CurrentVals<float>();

		// Token: 0x0400003D RID: 61
		[SerializeField]
		private PuppetMuscleModsSegunOffsets.CurrentVals<float> m_currentAngles = new PuppetMuscleModsSegunOffsets.CurrentVals<float>();

		// Token: 0x0400003E RID: 62
		[SerializeField]
		[ReadOnlyUI]
		private bool m_musclesSubcribed;

		// Token: 0x0400003F RID: 63
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000040 RID: 64
		private IPuppetUpdater m_Updater;

		// Token: 0x04000041 RID: 65
		private PuppetMusclePropMods m_PropModsHolder;

		// Token: 0x04000042 RID: 66
		private ICharacter m_ICharacter;

		// Token: 0x04000043 RID: 67
		private List<ModificadorDeFloat> m_pinMods = new List<ModificadorDeFloat>();

		// Token: 0x04000044 RID: 68
		private List<ModificadorDeFloat> m_springMods = new List<ModificadorDeFloat>();

		// Token: 0x04000045 RID: 69
		private List<ModificadorDeFloat> m_damperMods = new List<ModificadorDeFloat>();

		// Token: 0x04000046 RID: 70
		private Dictionary<Transform, ModificadorDeFloat> m_pinModsPorTarget = new Dictionary<Transform, ModificadorDeFloat>();

		// Token: 0x04000047 RID: 71
		private Dictionary<Transform, ModificadorDeFloat> m_springModsPorTarget = new Dictionary<Transform, ModificadorDeFloat>();

		// Token: 0x04000048 RID: 72
		private Dictionary<Transform, ModificadorDeFloat> m_damperModsPorTarget = new Dictionary<Transform, ModificadorDeFloat>();

		// Token: 0x02000115 RID: 277
		[Serializable]
		public class CurrentVals<T>
		{
			// Token: 0x0400068A RID: 1674
			[Header("Spine")]
			public T hips;

			// Token: 0x0400068B RID: 1675
			public T spine1;

			// Token: 0x0400068C RID: 1676
			public T spine2;

			// Token: 0x0400068D RID: 1677
			public T neck;

			// Token: 0x0400068E RID: 1678
			public T head;

			// Token: 0x0400068F RID: 1679
			[Header("Legs")]
			public T thighs;

			// Token: 0x04000690 RID: 1680
			public T calfs;

			// Token: 0x04000691 RID: 1681
			public T feets;

			// Token: 0x04000692 RID: 1682
			[Header("Arms")]
			public T shoulders;

			// Token: 0x04000693 RID: 1683
			public T upperarms;

			// Token: 0x04000694 RID: 1684
			public T forearms;

			// Token: 0x04000695 RID: 1685
			public T hands;
		}
	}
}
