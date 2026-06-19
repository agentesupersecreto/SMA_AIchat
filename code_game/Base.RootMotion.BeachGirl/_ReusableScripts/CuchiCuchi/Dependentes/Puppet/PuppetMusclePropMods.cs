using System;
using System.Collections.Generic;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000106 RID: 262
	[RequireComponent(typeof(PuppetMaster))]
	[RequireComponent(typeof(IJustPuppetEvents))]
	public sealed class PuppetMusclePropMods : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x0002DBCA File Offset: 0x0002BDCA
		public IReadOnlyList<PuppetMusclePropMods.PropModificables> propModificables
		{
			get
			{
				return this.m_modificables;
			}
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0002DBD2 File Offset: 0x0002BDD2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.Init();
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0002DBE0 File Offset: 0x0002BDE0
		private void Init()
		{
			if (this.m_initiated || !Application.isPlaying)
			{
				return;
			}
			this.m_initiated = true;
			this.m_PuppetMaster = base.GetComponent<PuppetMaster>();
			this.m_puppetUpdaterEvents = base.GetComponent<IJustPuppetEvents>();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			this.m_anim = componentInParent.bodyAnimator;
			this.OnPostInitiatePuppet();
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0002DC35 File Offset: 0x0002BE35
		public PuppetMusclePropMods.PropModificables Obtener(Muscle muscle)
		{
			if (!this.m_initiated)
			{
				this.Init();
			}
			return this.m_modificablesDeBone[muscle.target];
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0002DC56 File Offset: 0x0002BE56
		public PuppetMusclePropMods.PropModificables Obtener(HumanBodyBones humanBodyBones)
		{
			if (!this.m_initiated)
			{
				this.Init();
			}
			return this.ObtenerDeBone(this.m_anim.GetBoneTransform(humanBodyBones));
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0002DC78 File Offset: 0x0002BE78
		public PuppetMusclePropMods.PropModificables ObtenerDeBone(Transform bone)
		{
			if (!this.m_initiated)
			{
				this.Init();
			}
			PuppetMusclePropMods.PropModificables propModificables;
			if (!this.m_modificablesDeBone.TryGetValue(bone, out propModificables))
			{
				return null;
			}
			return propModificables;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x0002DCA8 File Offset: 0x0002BEA8
		private void OnPostInitiatePuppet()
		{
			Func<float> func = () => this.m_smoothTime;
			foreach (Muscle muscle in this.m_PuppetMaster.muscles)
			{
				PuppetMusclePropMods.PropModificables propModificables = new PuppetMusclePropMods.PropModificables();
				propModificables.Init(muscle, func);
				this.m_modificablesDeBone.Add(muscle.target, propModificables);
				this.m_modificables.Add(propModificables);
			}
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x0002DD10 File Offset: 0x0002BF10
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_puppetUpdaterEvents != null)
			{
				this.m_puppetUpdaterEvents.justFixedUpdating += this.OnJustUpdating;
				this.m_puppetUpdaterEvents.justFixedUpdated += this.OnJustUpdated;
				this.m_puppetUpdaterEvents.justUpdating += this.OnJustUpdating;
				this.m_puppetUpdaterEvents.justUpdated += this.OnJustUpdated;
				this.m_puppetUpdaterEvents.justLateUpdating += this.OnJustUpdating;
				this.m_puppetUpdaterEvents.justLateUpdated += this.OnJustUpdated;
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0002DDB8 File Offset: 0x0002BFB8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_puppetUpdaterEvents != null)
			{
				this.m_puppetUpdaterEvents.justFixedUpdating -= this.OnJustUpdating;
				this.m_puppetUpdaterEvents.justFixedUpdated -= this.OnJustUpdated;
				this.m_puppetUpdaterEvents.justUpdating -= this.OnJustUpdating;
				this.m_puppetUpdaterEvents.justUpdated -= this.OnJustUpdated;
				this.m_puppetUpdaterEvents.justLateUpdating -= this.OnJustUpdating;
				this.m_puppetUpdaterEvents.justLateUpdated -= this.OnJustUpdated;
			}
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0002DE64 File Offset: 0x0002C064
		private void OnJustUpdating(PuppetMasterUpdater arg1, PuppetMaster arg2)
		{
			for (int i = 0; i < this.m_modificables.Count; i++)
			{
				this.m_modificables[i].Updating();
			}
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x0002DE98 File Offset: 0x0002C098
		private void OnJustUpdated(PuppetMasterUpdater arg1, PuppetMaster arg2)
		{
			for (int i = 0; i < this.m_modificables.Count; i++)
			{
				this.m_modificables[i].Updated();
			}
		}

		// Token: 0x04000639 RID: 1593
		[SerializeField]
		private float m_smoothTime = 1f;

		// Token: 0x0400063A RID: 1594
		private PuppetMaster m_PuppetMaster;

		// Token: 0x0400063B RID: 1595
		private IJustPuppetEvents m_puppetUpdaterEvents;

		// Token: 0x0400063C RID: 1596
		private Animator m_anim;

		// Token: 0x0400063D RID: 1597
		[SerializeField]
		private List<PuppetMusclePropMods.PropModificables> m_modificables = new List<PuppetMusclePropMods.PropModificables>();

		// Token: 0x0400063E RID: 1598
		private Dictionary<Transform, PuppetMusclePropMods.PropModificables> m_modificablesDeBone = new Dictionary<Transform, PuppetMusclePropMods.PropModificables>();

		// Token: 0x0400063F RID: 1599
		[NonSerialized]
		private bool m_initiated;

		// Token: 0x020001CF RID: 463
		[Serializable]
		public class PropModificables
		{
			// Token: 0x17000288 RID: 648
			// (get) Token: 0x06000D2F RID: 3375 RVA: 0x0003A0BE File Offset: 0x000382BE
			public PuppetMusclePropMods.PropModificables.Modificables modificables
			{
				get
				{
					return this.m_Modificables;
				}
			}

			// Token: 0x17000289 RID: 649
			// (get) Token: 0x06000D30 RID: 3376 RVA: 0x0003A0C6 File Offset: 0x000382C6
			public PuppetMusclePropMods.PropModificables.ValoresMinimos valoresMinimos
			{
				get
				{
					return this.m_ValoresMinimos;
				}
			}

			// Token: 0x1700028A RID: 650
			// (get) Token: 0x06000D31 RID: 3377 RVA: 0x0003A0CE File Offset: 0x000382CE
			public PuppetMusclePropMods.PropModificables.ValoresMaximos valoresMaximos
			{
				get
				{
					return this.m_ValoresMaximos;
				}
			}

			// Token: 0x1700028B RID: 651
			// (get) Token: 0x06000D32 RID: 3378 RVA: 0x0003A0D6 File Offset: 0x000382D6
			public PuppetMusclePropMods.PropModificables.Props valoresReales
			{
				get
				{
					return this.m_puppetValues;
				}
			}

			// Token: 0x1700028C RID: 652
			// (get) Token: 0x06000D33 RID: 3379 RVA: 0x0003A0DE File Offset: 0x000382DE
			public bool updating
			{
				get
				{
					return this.m_updating;
				}
			}

			// Token: 0x06000D34 RID: 3380 RVA: 0x0003A0E6 File Offset: 0x000382E6
			public void Init(Muscle muscle, Func<float> timeGetter)
			{
				if (muscle == null)
				{
					throw new ArgumentNullException("muscle", "muscle null reference.");
				}
				this.muscle = muscle;
				this.name = muscle.name;
				this.m_timeGetter = timeGetter;
			}

			// Token: 0x06000D35 RID: 3381 RVA: 0x0003A118 File Offset: 0x00038318
			public void Updating()
			{
				try
				{
					if (this.m_updating)
					{
						throw new InvalidOperationException();
					}
					this.m_updating = true;
					if (this.m_primerUpdate)
					{
						this.m_primerUpdate = false;
						this.m_puppetValuesModificados.Save(this.muscle);
						this.m_puppetValuesModificados.SaveMass(this.muscle);
						this.m_puppetValues.SaveMass(this.muscle);
					}
					this.m_puppetValues.Save(this.muscle);
					this.m_puppetValues.LoadMass(this.muscle);
					this.HacerModificaciones();
					float num = Time.time - this.m_lastTime;
					this.SmoothModificaciones(num, this.m_timeGetter());
					this.m_puppetValuesModificados.Load(this.muscle);
					this.m_puppetValuesModificados.LoadMass(this.muscle);
				}
				finally
				{
					this.m_lastTime = Time.time;
				}
			}

			// Token: 0x06000D36 RID: 3382 RVA: 0x0003A204 File Offset: 0x00038404
			private void HacerModificaciones()
			{
				this.m_resultValues.mappingWeight = this.m_ValoresMinimos.mappingWeight.MaximoValorIncluyendo(this.muscle.props.mappingWeight);
				this.m_resultValues.pinWeight = this.m_ValoresMinimos.pinWeight.MaximoValorIncluyendo(this.muscle.props.pinWeight);
				this.m_resultValues.muscleWeight = this.m_ValoresMinimos.muscleWeight.MaximoValorIncluyendo(this.muscle.props.muscleWeight);
				this.m_resultValues.muscleDamper = this.m_ValoresMinimos.muscleDamper.MaximoValorIncluyendo(this.muscle.props.muscleDamper);
				this.m_resultValues.muscleMass = this.m_ValoresMinimos.muscleMass.MaximoValorIncluyendo(this.muscle.rigidbody.mass);
				this.m_resultValues.mappingWeight = this.m_Modificables.mappingWeight.ModificarValor(this.m_resultValues.mappingWeight);
				this.m_resultValues.pinWeight = this.m_Modificables.pinWeight.ModificarValor(this.m_resultValues.pinWeight);
				this.m_resultValues.muscleWeight = this.m_Modificables.muscleWeight.ModificarValor(this.m_resultValues.muscleWeight);
				this.m_resultValues.muscleDamper = this.m_Modificables.muscleDamper.ModificarValor(this.m_resultValues.muscleDamper);
				this.m_resultValues.muscleMass = this.m_Modificables.muscleMass.ModificarValor(this.m_resultValues.muscleMass);
				this.m_resultValues.mappingWeight = this.m_ValoresMaximos.mappingWeight.MinimoValorIncluyendo(this.m_resultValues.mappingWeight);
				this.m_resultValues.pinWeight = this.m_ValoresMaximos.pinWeight.MinimoValorIncluyendo(this.m_resultValues.pinWeight);
				this.m_resultValues.muscleWeight = this.m_ValoresMaximos.muscleWeight.MinimoValorIncluyendo(this.m_resultValues.muscleWeight);
				this.m_resultValues.muscleDamper = this.m_ValoresMaximos.muscleDamper.MinimoValorIncluyendo(this.m_resultValues.muscleDamper);
				this.m_resultValues.muscleMass = this.m_ValoresMaximos.muscleMass.MinimoValorIncluyendo(this.m_resultValues.muscleMass);
			}

			// Token: 0x06000D37 RID: 3383 RVA: 0x0003A464 File Offset: 0x00038664
			private void SmoothModificaciones(float deltaTime, float timeSmooth)
			{
				float num = ((deltaTime <= 0f) ? Time.deltaTime : deltaTime);
				this.m_puppetValuesModificados.mappingWeight = Mathf.SmoothDamp(this.m_puppetValuesModificados.mappingWeight, this.m_resultValues.mappingWeight, ref this.m_mappingWeightCurrentVel, timeSmooth, float.PositiveInfinity, num);
				this.m_puppetValuesModificados.pinWeight = Mathf.SmoothDamp(this.m_puppetValuesModificados.pinWeight, this.m_resultValues.pinWeight, ref this.m_pinWeightCurrentVel, timeSmooth, float.PositiveInfinity, num);
				this.m_puppetValuesModificados.muscleWeight = Mathf.SmoothDamp(this.m_puppetValuesModificados.muscleWeight, this.m_resultValues.muscleWeight, ref this.m_muscleWeightCurrentVel, timeSmooth, float.PositiveInfinity, num);
				this.m_puppetValuesModificados.muscleDamper = Mathf.SmoothDamp(this.m_puppetValuesModificados.muscleDamper, this.m_resultValues.muscleDamper, ref this.m_muscleDamperCurrentVel, timeSmooth, float.PositiveInfinity, num);
				this.m_puppetValuesModificados.muscleMass = Mathf.SmoothDamp(this.m_puppetValuesModificados.muscleMass, this.m_resultValues.muscleMass, ref this.m_muscleMassCurrentVel, timeSmooth, float.PositiveInfinity, deltaTime);
				this.m_puppetValuesModificados.mappingWeight = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.mappingWeight, this.m_resultValues.mappingWeight, 0.001f) ? this.m_resultValues.mappingWeight : this.m_puppetValuesModificados.mappingWeight);
				this.m_puppetValuesModificados.pinWeight = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.pinWeight, this.m_resultValues.pinWeight, 0.001f) ? this.m_resultValues.pinWeight : this.m_puppetValuesModificados.pinWeight);
				this.m_puppetValuesModificados.muscleWeight = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.muscleWeight, this.m_resultValues.muscleWeight, 0.001f) ? this.m_resultValues.muscleWeight : this.m_puppetValuesModificados.muscleWeight);
				this.m_puppetValuesModificados.muscleDamper = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.muscleDamper, this.m_resultValues.muscleDamper, 0.001f) ? this.m_resultValues.muscleDamper : this.m_puppetValuesModificados.muscleDamper);
				this.m_puppetValuesModificados.muscleMass = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.muscleMass, this.m_resultValues.muscleMass, 0.001f) ? this.m_resultValues.muscleMass : this.m_puppetValuesModificados.muscleMass);
				this.m_puppetValuesModificados.mappingWeight = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.mappingWeight, 0f, 1E-05f) ? 0f : this.m_puppetValuesModificados.mappingWeight);
				this.m_puppetValuesModificados.pinWeight = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.pinWeight, 0f, 1E-05f) ? 0f : this.m_puppetValuesModificados.pinWeight);
				this.m_puppetValuesModificados.muscleWeight = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.muscleWeight, 0f, 1E-05f) ? 0f : this.m_puppetValuesModificados.muscleWeight);
				this.m_puppetValuesModificados.muscleDamper = (MathfExtension.AlmostEqual(this.m_puppetValuesModificados.muscleDamper, 0f, 1E-05f) ? 0f : this.m_puppetValuesModificados.muscleDamper);
			}

			// Token: 0x06000D38 RID: 3384 RVA: 0x0003A7C0 File Offset: 0x000389C0
			public void Updated()
			{
				if (!this.m_updating)
				{
					throw new InvalidOperationException();
				}
				this.m_updating = false;
				if (Application.isEditor && !this.m_puppetValuesModificados.Igual(this.muscle))
				{
					Debug.LogWarning("props de musculo " + this.muscle.name + ", fueron cambiadas mientras se esta actualizando, esto puede causar problemas", this.muscle.rigidbody);
				}
				this.m_puppetValues.Load(this.muscle);
			}

			// Token: 0x040009E4 RID: 2532
			public string name;

			// Token: 0x040009E5 RID: 2533
			public Muscle muscle;

			// Token: 0x040009E6 RID: 2534
			[SerializeField]
			private PuppetMusclePropMods.PropModificables.Modificables m_Modificables = new PuppetMusclePropMods.PropModificables.Modificables();

			// Token: 0x040009E7 RID: 2535
			[SerializeField]
			private PuppetMusclePropMods.PropModificables.ValoresMinimos m_ValoresMinimos = new PuppetMusclePropMods.PropModificables.ValoresMinimos();

			// Token: 0x040009E8 RID: 2536
			[SerializeField]
			private PuppetMusclePropMods.PropModificables.ValoresMaximos m_ValoresMaximos = new PuppetMusclePropMods.PropModificables.ValoresMaximos();

			// Token: 0x040009E9 RID: 2537
			[NonSerialized]
			private bool m_primerUpdate = true;

			// Token: 0x040009EA RID: 2538
			private bool m_updating;

			// Token: 0x040009EB RID: 2539
			[SerializeField]
			private PuppetMusclePropMods.PropModificables.Props m_puppetValues;

			// Token: 0x040009EC RID: 2540
			[SerializeField]
			private PuppetMusclePropMods.PropModificables.Props m_resultValues;

			// Token: 0x040009ED RID: 2541
			[SerializeField]
			private PuppetMusclePropMods.PropModificables.Props m_puppetValuesModificados;

			// Token: 0x040009EE RID: 2542
			private Func<float> m_timeGetter;

			// Token: 0x040009EF RID: 2543
			private float m_lastTime;

			// Token: 0x040009F0 RID: 2544
			private float m_mappingWeightCurrentVel;

			// Token: 0x040009F1 RID: 2545
			private float m_pinWeightCurrentVel;

			// Token: 0x040009F2 RID: 2546
			private float m_muscleWeightCurrentVel;

			// Token: 0x040009F3 RID: 2547
			private float m_muscleDamperCurrentVel;

			// Token: 0x040009F4 RID: 2548
			private float m_muscleMassCurrentVel;

			// Token: 0x020001EB RID: 491
			[Serializable]
			public class Modificables
			{
				// Token: 0x1700028D RID: 653
				// (get) Token: 0x06000D72 RID: 3442 RVA: 0x0003B44C File Offset: 0x0003964C
				public ModificableDeFloat mappingWeight
				{
					get
					{
						return this.m_mappingWeight;
					}
				}

				// Token: 0x1700028E RID: 654
				// (get) Token: 0x06000D73 RID: 3443 RVA: 0x0003B454 File Offset: 0x00039654
				public ModificableDeFloat pinWeight
				{
					get
					{
						return this.m_pinWeight;
					}
				}

				// Token: 0x1700028F RID: 655
				// (get) Token: 0x06000D74 RID: 3444 RVA: 0x0003B45C File Offset: 0x0003965C
				public ModificableDeFloat muscleWeight
				{
					get
					{
						return this.m_muscleWeight;
					}
				}

				// Token: 0x17000290 RID: 656
				// (get) Token: 0x06000D75 RID: 3445 RVA: 0x0003B464 File Offset: 0x00039664
				public ModificableDeFloat muscleDamper
				{
					get
					{
						return this.m_muscleDamper;
					}
				}

				// Token: 0x17000291 RID: 657
				// (get) Token: 0x06000D76 RID: 3446 RVA: 0x0003B46C File Offset: 0x0003966C
				public ModificableDeFloat muscleMass
				{
					get
					{
						return this.m_muscleMass;
					}
				}

				// Token: 0x04000A54 RID: 2644
				[SerializeField]
				private ModificableDeFloat m_mappingWeight = new ModificableDeFloat(1f);

				// Token: 0x04000A55 RID: 2645
				[SerializeField]
				private ModificableDeFloat m_pinWeight = new ModificableDeFloat(1f);

				// Token: 0x04000A56 RID: 2646
				[SerializeField]
				private ModificableDeFloat m_muscleWeight = new ModificableDeFloat(1f);

				// Token: 0x04000A57 RID: 2647
				[SerializeField]
				private ModificableDeFloat m_muscleDamper = new ModificableDeFloat(1f);

				// Token: 0x04000A58 RID: 2648
				[SerializeField]
				private ModificableDeFloat m_muscleMass = new ModificableDeFloat(1f);
			}

			// Token: 0x020001EC RID: 492
			[Serializable]
			public class ValoresMinimos
			{
				// Token: 0x17000292 RID: 658
				// (get) Token: 0x06000D78 RID: 3448 RVA: 0x0003B4D7 File Offset: 0x000396D7
				public ModificableDeFloat mappingWeight
				{
					get
					{
						return this.m_mappingWeight;
					}
				}

				// Token: 0x17000293 RID: 659
				// (get) Token: 0x06000D79 RID: 3449 RVA: 0x0003B4DF File Offset: 0x000396DF
				public ModificableDeFloat pinWeight
				{
					get
					{
						return this.m_pinWeight;
					}
				}

				// Token: 0x17000294 RID: 660
				// (get) Token: 0x06000D7A RID: 3450 RVA: 0x0003B4E7 File Offset: 0x000396E7
				public ModificableDeFloat muscleWeight
				{
					get
					{
						return this.m_muscleWeight;
					}
				}

				// Token: 0x17000295 RID: 661
				// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0003B4EF File Offset: 0x000396EF
				public ModificableDeFloat muscleDamper
				{
					get
					{
						return this.m_muscleDamper;
					}
				}

				// Token: 0x17000296 RID: 662
				// (get) Token: 0x06000D7C RID: 3452 RVA: 0x0003B4F7 File Offset: 0x000396F7
				public ModificableDeFloat muscleMass
				{
					get
					{
						return this.m_muscleMass;
					}
				}

				// Token: 0x04000A59 RID: 2649
				[SerializeField]
				private ModificableDeFloat m_mappingWeight = new ModificableDeFloat(0f);

				// Token: 0x04000A5A RID: 2650
				[SerializeField]
				private ModificableDeFloat m_pinWeight = new ModificableDeFloat(0f);

				// Token: 0x04000A5B RID: 2651
				[SerializeField]
				private ModificableDeFloat m_muscleWeight = new ModificableDeFloat(0f);

				// Token: 0x04000A5C RID: 2652
				[SerializeField]
				private ModificableDeFloat m_muscleDamper = new ModificableDeFloat(0f);

				// Token: 0x04000A5D RID: 2653
				[SerializeField]
				private ModificableDeFloat m_muscleMass = new ModificableDeFloat(0f);
			}

			// Token: 0x020001ED RID: 493
			[Serializable]
			public class ValoresMaximos
			{
				// Token: 0x17000297 RID: 663
				// (get) Token: 0x06000D7E RID: 3454 RVA: 0x0003B563 File Offset: 0x00039763
				public ModificableDeFloat mappingWeight
				{
					get
					{
						return this.m_mappingWeight;
					}
				}

				// Token: 0x17000298 RID: 664
				// (get) Token: 0x06000D7F RID: 3455 RVA: 0x0003B56B File Offset: 0x0003976B
				public ModificableDeFloat pinWeight
				{
					get
					{
						return this.m_pinWeight;
					}
				}

				// Token: 0x17000299 RID: 665
				// (get) Token: 0x06000D80 RID: 3456 RVA: 0x0003B573 File Offset: 0x00039773
				public ModificableDeFloat muscleWeight
				{
					get
					{
						return this.m_muscleWeight;
					}
				}

				// Token: 0x1700029A RID: 666
				// (get) Token: 0x06000D81 RID: 3457 RVA: 0x0003B57B File Offset: 0x0003977B
				public ModificableDeFloat muscleDamper
				{
					get
					{
						return this.m_muscleDamper;
					}
				}

				// Token: 0x1700029B RID: 667
				// (get) Token: 0x06000D82 RID: 3458 RVA: 0x0003B583 File Offset: 0x00039783
				public ModificableDeFloat muscleMass
				{
					get
					{
						return this.m_muscleMass;
					}
				}

				// Token: 0x04000A5E RID: 2654
				[SerializeField]
				private ModificableDeFloat m_mappingWeight = new ModificableDeFloat(1f);

				// Token: 0x04000A5F RID: 2655
				[SerializeField]
				private ModificableDeFloat m_pinWeight = new ModificableDeFloat(1f);

				// Token: 0x04000A60 RID: 2656
				[SerializeField]
				private ModificableDeFloat m_muscleWeight = new ModificableDeFloat(1f);

				// Token: 0x04000A61 RID: 2657
				[SerializeField]
				private ModificableDeFloat m_muscleDamper = new ModificableDeFloat(1f);

				// Token: 0x04000A62 RID: 2658
				[SerializeField]
				private ModificableDeFloat m_muscleMass = new ModificableDeFloat(1E+12f);
			}

			// Token: 0x020001EE RID: 494
			[Serializable]
			public struct Props
			{
				// Token: 0x06000D84 RID: 3460 RVA: 0x0003B5F0 File Offset: 0x000397F0
				public void Clamp()
				{
					this.mappingWeight = Mathf.Clamp(this.mappingWeight, 0f, 1f);
					this.pinWeight = Mathf.Clamp(this.pinWeight, 0f, 1f);
					this.muscleWeight = Mathf.Clamp(this.muscleWeight, 0f, 1000f);
					this.muscleDamper = Mathf.Clamp(this.muscleDamper, 0f, 1000f);
					this.muscleMass = Mathf.Clamp(this.muscleMass, 0f, float.MaxValue);
				}

				// Token: 0x06000D85 RID: 3461 RVA: 0x0003B684 File Offset: 0x00039884
				public void Save(Muscle muscle)
				{
					this.mappingWeight = muscle.props.mappingWeight;
					this.pinWeight = muscle.props.pinWeight;
					this.muscleWeight = muscle.props.muscleWeight;
					this.muscleDamper = muscle.props.muscleDamper;
				}

				// Token: 0x06000D86 RID: 3462 RVA: 0x0003B6D8 File Offset: 0x000398D8
				public void Load(Muscle muscle)
				{
					muscle.props.mappingWeight = this.mappingWeight;
					muscle.props.pinWeight = this.pinWeight;
					muscle.props.muscleWeight = this.muscleWeight;
					muscle.props.muscleDamper = this.muscleDamper;
				}

				// Token: 0x06000D87 RID: 3463 RVA: 0x0003B729 File Offset: 0x00039929
				public void SaveMass(Muscle muscle)
				{
					this.muscleMass = muscle.rigidbody.mass;
				}

				// Token: 0x06000D88 RID: 3464 RVA: 0x0003B73C File Offset: 0x0003993C
				public void LoadMass(Muscle muscle)
				{
					muscle.rigidbody.mass = this.muscleMass;
				}

				// Token: 0x06000D89 RID: 3465 RVA: 0x0003B750 File Offset: 0x00039950
				public bool Igual(Muscle muscle)
				{
					return ExtendedMonoBehaviour.AlmostEqual(muscle.props.mappingWeight, this.mappingWeight, 0.0001f) && ExtendedMonoBehaviour.AlmostEqual(muscle.props.pinWeight, this.pinWeight, 0.0001f) && ExtendedMonoBehaviour.AlmostEqual(muscle.props.muscleWeight, this.muscleWeight, 0.0001f) && ExtendedMonoBehaviour.AlmostEqual(muscle.props.muscleDamper, this.muscleDamper, 0.0001f);
				}

				// Token: 0x04000A63 RID: 2659
				[Range(0f, 1f)]
				public float mappingWeight;

				// Token: 0x04000A64 RID: 2660
				[Range(0f, 1f)]
				public float pinWeight;

				// Token: 0x04000A65 RID: 2661
				[Range(0f, 10f)]
				public float muscleWeight;

				// Token: 0x04000A66 RID: 2662
				[Range(0f, 10f)]
				public float muscleDamper;

				// Token: 0x04000A67 RID: 2663
				public float muscleMass;
			}
		}
	}
}
