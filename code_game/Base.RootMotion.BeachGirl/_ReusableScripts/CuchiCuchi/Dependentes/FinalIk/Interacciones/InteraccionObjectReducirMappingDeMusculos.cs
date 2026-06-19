using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A6 RID: 166
	public abstract class InteraccionObjectReducirMappingDeMusculos : InteraccionObjectComienzaTerminaCallBacks
	{
		// Token: 0x0600066B RID: 1643 RVA: 0x0001F420 File Offset: 0x0001D620
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001F428 File Offset: 0x0001D628
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x0600066D RID: 1645
		protected abstract IReadOnlyList<Transform> ObtenerBonesToUnMap();

		// Token: 0x0600066E RID: 1646 RVA: 0x0001F438 File Offset: 0x0001D638
		protected void Clear()
		{
			if (this.m_modificadorDeMapping.Count > 0)
			{
				for (int i = 0; i < this.m_modificadorDeMapping.Count; i++)
				{
					this.m_modificadorDeMapping[i].TryRemoverDeOwner(true);
				}
			}
			if (this.m_modificadorDePinMinValue.Count > 0)
			{
				for (int j = 0; j < this.m_modificadorDePinMinValue.Count; j++)
				{
					this.m_modificadorDePinMinValue[j].TryRemoverDeOwner(true);
				}
			}
			if (this.m_modificadorDeMuscleDamperMinValue.Count > 0)
			{
				for (int k = 0; k < this.m_modificadorDeMuscleDamperMinValue.Count; k++)
				{
					this.m_modificadorDeMuscleDamperMinValue[k].TryRemoverDeOwner(true);
				}
			}
			if (this.m_modificadorMuscleDamperMinValue.Count > 0)
			{
				for (int l = 0; l < this.m_modificadorMuscleDamperMinValue.Count; l++)
				{
					this.m_modificadorMuscleDamperMinValue[l].TryRemoverDeOwner(true);
				}
			}
			if (this.m_modificadorMuscleDamperMaxValue.Count > 0)
			{
				for (int m = 0; m < this.m_modificadorMuscleDamperMaxValue.Count; m++)
				{
					this.m_modificadorMuscleDamperMaxValue[m].TryRemoverDeOwner(true);
				}
			}
			this.m_modificadorDeMapping.Clear();
			this.m_modificadorDePinMinValue.Clear();
			this.m_modificadorDeMuscleDamperMinValue.Clear();
			this.m_modificadorMuscleDamperMinValue.Clear();
			this.m_modificadorMuscleDamperMaxValue.Clear();
			this.m_Modificables = null;
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0001F59C File Offset: 0x0001D79C
		protected override void OnComienza()
		{
			this.Clear();
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			InteractionObjectV2Base interactionObject = this.m_InteractionObject;
			ICharacter character;
			if (interactionObject == null)
			{
				character = null;
			}
			else
			{
				Interaccion componentInParent = interactionObject.GetComponentInParent<Interaccion>();
				if (componentInParent == null)
				{
					character = null;
				}
				else
				{
					IInteraccionesDeCharacter owner = componentInParent.owner;
					character = ((owner != null) ? owner.character : null);
				}
			}
			ICharacter character2 = character;
			if (character2 == null)
			{
				throw new ArgumentNullException("@character", "@character null reference.");
			}
			this.m_Modificables = character2.GetComponentInChildren<PuppetMusclePropMods>();
			IReadOnlyList<Transform> readOnlyList = this.ObtenerBonesToUnMap();
			if (readOnlyList == null || readOnlyList.Count == 0)
			{
				Debug.LogWarning("Ningun Bone De musculo para cambiar mapping", this);
			}
			if (this.m_Modificables != null)
			{
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					Transform transform = readOnlyList[i];
					if (!(transform == null))
					{
						PuppetMusclePropMods.PropModificables propModificables = this.m_Modificables.ObtenerDeBone(transform);
						if (propModificables != null)
						{
							if (this.mappingConfig.aplicar)
							{
								ModificadorDeFloat modificadorDeFloat = propModificables.modificables.mappingWeight.ObtenerModificadorNotNull(this);
								this.m_modificadorDeMapping.Add(modificadorDeFloat);
							}
							if (this.pinMinValueConfig.aplicar)
							{
								ModificadorDeFloat modificadorDeFloat2 = propModificables.valoresMinimos.pinWeight.ObtenerModificadorNotNull(this);
								this.m_modificadorDePinMinValue.Add(modificadorDeFloat2);
							}
							if (this.muscleWeightMinValueConfig.aplicar)
							{
								ModificadorDeFloat modificadorDeFloat3 = propModificables.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(this);
								this.m_modificadorDeMuscleDamperMinValue.Add(modificadorDeFloat3);
							}
							if (this.muscleDamperMinValueConfig.aplicar)
							{
								ModificadorDeFloat modificadorDeFloat4 = propModificables.valoresMinimos.muscleDamper.ObtenerModificadorNotNull(this);
								this.m_modificadorMuscleDamperMinValue.Add(modificadorDeFloat4);
							}
							if (this.muscleDamperMaxValueConfig.aplicar)
							{
								ModificadorDeFloat modificadorDeFloat5 = propModificables.valoresMaximos.muscleDamper.ObtenerModificadorNotNull(this);
								this.m_modificadorMuscleDamperMaxValue.Add(modificadorDeFloat5);
							}
						}
					}
				}
			}
			for (int j = 0; j < this.m_modificadorDeMapping.Count; j++)
			{
				this.m_modificadorDeMapping[j].valor = new ModificadorDeFloatBase.Data
				{
					valor = this.mappingConfig.onStartMappingMod
				};
			}
			for (int k = 0; k < this.m_modificadorDePinMinValue.Count; k++)
			{
				this.m_modificadorDePinMinValue[k].valor = new ModificadorDeFloatBase.Data
				{
					valor = this.pinMinValueConfig.onStartMinValue
				};
			}
			for (int l = 0; l < this.m_modificadorDeMuscleDamperMinValue.Count; l++)
			{
				this.m_modificadorDeMuscleDamperMinValue[l].valor = new ModificadorDeFloatBase.Data
				{
					valor = this.muscleWeightMinValueConfig.onStartMinValue
				};
			}
			for (int m = 0; m < this.m_modificadorMuscleDamperMinValue.Count; m++)
			{
				this.m_modificadorMuscleDamperMinValue[m].valor = new ModificadorDeFloatBase.Data
				{
					valor = this.muscleDamperMinValueConfig.onStartMinValue
				};
			}
			for (int n = 0; n < this.m_modificadorMuscleDamperMaxValue.Count; n++)
			{
				this.m_modificadorMuscleDamperMaxValue[n].valor = new ModificadorDeFloatBase.Data
				{
					valor = this.muscleDamperMaxValueConfig.onStartMaxValue
				};
			}
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001F8BE File Offset: 0x0001DABE
		protected override void OnTermina()
		{
			this.Clear();
		}

		// Token: 0x04000465 RID: 1125
		[Header("Mapping")]
		public InteraccionObjectReducirMappingDeMusculos.MappingConfig mappingConfig = new InteraccionObjectReducirMappingDeMusculos.MappingConfig();

		// Token: 0x04000466 RID: 1126
		[Header("Pin")]
		public InteraccionObjectReducirMappingDeMusculos.PinMinValueConfig pinMinValueConfig = new InteraccionObjectReducirMappingDeMusculos.PinMinValueConfig();

		// Token: 0x04000467 RID: 1127
		[Header("Spring")]
		public InteraccionObjectReducirMappingDeMusculos.MuscleWeightMinValueConfig muscleWeightMinValueConfig = new InteraccionObjectReducirMappingDeMusculos.MuscleWeightMinValueConfig();

		// Token: 0x04000468 RID: 1128
		[Header("Damper")]
		public InteraccionObjectReducirMappingDeMusculos.MuscleDamperMinValueConfig muscleDamperMinValueConfig = new InteraccionObjectReducirMappingDeMusculos.MuscleDamperMinValueConfig();

		// Token: 0x04000469 RID: 1129
		public InteraccionObjectReducirMappingDeMusculos.MuscleDamperMaxValueConfig muscleDamperMaxValueConfig = new InteraccionObjectReducirMappingDeMusculos.MuscleDamperMaxValueConfig();

		// Token: 0x0400046A RID: 1130
		private PuppetMusclePropMods m_Modificables;

		// Token: 0x0400046B RID: 1131
		private List<ModificadorDeFloat> m_modificadorDeMapping = new List<ModificadorDeFloat>();

		// Token: 0x0400046C RID: 1132
		private List<ModificadorDeFloat> m_modificadorDePinMinValue = new List<ModificadorDeFloat>();

		// Token: 0x0400046D RID: 1133
		private List<ModificadorDeFloat> m_modificadorDeMuscleDamperMinValue = new List<ModificadorDeFloat>();

		// Token: 0x0400046E RID: 1134
		private List<ModificadorDeFloat> m_modificadorMuscleDamperMinValue = new List<ModificadorDeFloat>();

		// Token: 0x0400046F RID: 1135
		private List<ModificadorDeFloat> m_modificadorMuscleDamperMaxValue = new List<ModificadorDeFloat>();

		// Token: 0x02000188 RID: 392
		[Serializable]
		public class MappingConfig
		{
			// Token: 0x040008CE RID: 2254
			public bool aplicar;

			// Token: 0x040008CF RID: 2255
			[Range(0f, 1f)]
			public float onStartMappingMod;
		}

		// Token: 0x02000189 RID: 393
		[Serializable]
		public class PinMinValueConfig
		{
			// Token: 0x040008D0 RID: 2256
			public bool aplicar;

			// Token: 0x040008D1 RID: 2257
			[Range(0f, 1f)]
			public float onStartMinValue = 1f;
		}

		// Token: 0x0200018A RID: 394
		[Serializable]
		public class MuscleWeightMinValueConfig
		{
			// Token: 0x040008D2 RID: 2258
			public bool aplicar;

			// Token: 0x040008D3 RID: 2259
			[Range(0f, 1f)]
			public float onStartMinValue = 1f;
		}

		// Token: 0x0200018B RID: 395
		[Serializable]
		public class MuscleDamperMinValueConfig
		{
			// Token: 0x040008D4 RID: 2260
			public bool aplicar;

			// Token: 0x040008D5 RID: 2261
			[Range(0f, 1f)]
			public float onStartMinValue = 1f;
		}

		// Token: 0x0200018C RID: 396
		[Serializable]
		public class MuscleDamperMaxValueConfig
		{
			// Token: 0x040008D6 RID: 2262
			public bool aplicar;

			// Token: 0x040008D7 RID: 2263
			[Range(0f, 1f)]
			public float onStartMaxValue = 1f;
		}
	}
}
