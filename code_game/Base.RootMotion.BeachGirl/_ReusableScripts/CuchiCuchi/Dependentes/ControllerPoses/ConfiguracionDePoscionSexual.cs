using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Puppet;
using Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Mapas.Configuraciones;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scriptables;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses
{
	// Token: 0x020000C9 RID: 201
	[CreateAssetMenu(fileName = "Configuracion De Poscion Sexual", menuName = "Objetos/CuChiCuChi/ConfiguracionDePoscionSexual")]
	public class ConfiguracionDePoscionSexual : ScriptableObject
	{
		// Token: 0x0600074C RID: 1868 RVA: 0x00023254 File Offset: 0x00021454
		public void AplicarOnFemale(PuppetMaster puppet, FemaleAnimController femaleController, bool puppetModoPorAnimatorState)
		{
			Animator targetAnimator = puppet.targetAnimator;
			if (targetAnimator == null)
			{
				throw new ArgumentNullException("animator", "animator null reference.");
			}
			this.animatorConfig.animatorConfig.AplicarOnFemale(targetAnimator, femaleController);
			this.musclesConfig.musclesConfig.AplicarOnFemale(puppet, femaleController);
			this.puppetConfig.puppetConfig.flagPuppetModoPorAnimatorState = puppetModoPorAnimatorState;
			this.puppetConfig.puppetConfig.AplicarOnFemale(puppet, femaleController);
			if (this.controller != null)
			{
				targetAnimator.runtimeAnimatorController = this.controller;
			}
			PuppetMuscleModsSegunOffsets componentInChildren = puppet.GetComponentInChildren<PuppetMuscleModsSegunOffsets>();
			if (componentInChildren == null)
			{
				Debug.LogWarning("No se podran cargar configuraciones de modificacion por q el holder es nullo", puppet);
			}
			else
			{
				if (this.musclesPinModsConfig != null)
				{
					componentInChildren.LoadOnFemale(this.musclesPinModsConfig.configs, femaleController);
				}
				else
				{
					componentInChildren.ResetPinMods();
				}
				if (this.musclesSpriDampModsConfig != null)
				{
					componentInChildren.LoadOnFemale(this.musclesSpriDampModsConfig.configs, femaleController);
				}
				else
				{
					componentInChildren.ResetSpringDamperMods();
				}
			}
			foreach (Muscle muscle in puppet.muscles)
			{
				bool flag = true;
				if (this.colliders.MuscleEsManos(targetAnimator, muscle))
				{
					flag = this.colliders.manos;
				}
				else if (this.colliders.MuscleEsAnteBrazo(targetAnimator, muscle))
				{
					flag = this.colliders.anteBrazos;
				}
				else if (this.colliders.MuscleEsBrazo(targetAnimator, muscle))
				{
					flag = this.colliders.brazos;
				}
				else if (this.colliders.MuscleEsPies(targetAnimator, muscle))
				{
					flag = this.colliders.pies;
				}
				else if (this.colliders.MuscleEsCanillas(targetAnimator, muscle))
				{
					flag = this.colliders.canillas;
				}
				else if (this.colliders.MuscleEsPiernas(targetAnimator, muscle))
				{
					flag = this.colliders.pirnas;
				}
				this.DisableColliders(flag, muscle);
			}
			Muscle muscle2 = puppet.GetMuscle(targetAnimator, HumanBodyBones.Spine);
			Muscle muscle3 = puppet.GetMuscle(targetAnimator, HumanBodyBones.Chest);
			Muscle muscle4 = puppet.GetMuscle(targetAnimator, HumanBodyBones.Head);
			Muscle muscle5 = puppet.GetMuscle(targetAnimator, HumanBodyBones.Neck);
			Muscle muscle6 = puppet.GetMuscle(targetAnimator, HumanBodyBones.LeftShoulder);
			Muscle muscle7 = puppet.GetMuscle(targetAnimator, HumanBodyBones.RightShoulder);
			Muscle muscle8 = puppet.GetMuscle(targetAnimator, HumanBodyBones.LeftUpperArm);
			Muscle muscle9 = puppet.GetMuscle(targetAnimator, HumanBodyBones.RightUpperArm);
			Muscle muscle10 = puppet.GetMuscle(targetAnimator, HumanBodyBones.LeftLowerArm);
			Muscle muscle11 = puppet.GetMuscle(targetAnimator, HumanBodyBones.RightLowerArm);
			Muscle muscle12 = puppet.GetMuscle(targetAnimator, HumanBodyBones.LeftLowerLeg);
			Muscle muscle13 = puppet.GetMuscle(targetAnimator, HumanBodyBones.RightLowerLeg);
			Muscle muscle14 = puppet.GetMuscle(targetAnimator, HumanBodyBones.LeftUpperLeg);
			Muscle muscle15 = puppet.GetMuscle(targetAnimator, HumanBodyBones.RightUpperLeg);
			if (this.limitarRotaciones.Spine1)
			{
				this.Limitar(muscle2, this.limitarRotaciones.spine1RotationLimits);
			}
			else
			{
				this.Liberar(muscle2);
			}
			if (this.limitarRotaciones.Spine2)
			{
				this.Limitar(muscle3, this.limitarRotaciones.spine2RotationLimits);
			}
			else
			{
				this.Liberar(muscle3);
			}
			if (this.limitarRotaciones.Neck)
			{
				this.Limitar(muscle5, this.limitarRotaciones.neckRotationLimits);
			}
			else
			{
				this.Liberar(muscle5);
			}
			if (this.limitarRotaciones.Head)
			{
				this.Limitar(muscle4, this.limitarRotaciones.headRotationLimitsV2);
			}
			else
			{
				this.Liberar(muscle4);
			}
			if (this.limitarRotaciones.Shoulders)
			{
				this.Limitar(muscle6, this.limitarRotaciones.shouldersRotationLimits);
				this.Limitar(muscle7, this.limitarRotaciones.shouldersRotationLimits);
			}
			else
			{
				this.Liberar(muscle6);
				this.Liberar(muscle7);
			}
			if (this.limitarRotaciones.Arms)
			{
				this.Limitar(muscle8, this.limitarRotaciones.armsRotationLimits);
				this.Limitar(muscle9, this.limitarRotaciones.armsRotationLimits);
			}
			else
			{
				this.Liberar(muscle8);
				this.Liberar(muscle9);
			}
			if (this.limitarRotaciones.elbow)
			{
				this.Limitar(muscle10, this.limitarRotaciones.elbowRotationLimitsV3);
				this.Limitar(muscle11, this.limitarRotaciones.elbowRotationLimitsV3);
			}
			else
			{
				this.Liberar(muscle10);
				this.Liberar(muscle11);
			}
			if (this.limitarRotaciones.knees)
			{
				this.Limitar(muscle12, this.limitarRotaciones.kneesRotationLimits);
				this.Limitar(muscle13, this.limitarRotaciones.kneesRotationLimits);
			}
			else
			{
				this.Liberar(muscle12);
				this.Liberar(muscle13);
			}
			if (this.limitarRotaciones.thighs)
			{
				this.Limitar(muscle14, this.limitarRotaciones.thighsRotationLimits);
				this.Limitar(muscle15, this.limitarRotaciones.thighsRotationLimits);
				return;
			}
			this.Liberar(muscle14);
			this.Liberar(muscle15);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x000236D0 File Offset: 0x000218D0
		private void Limitar(Muscle muscle, ConfiguracionDePoscionSexual.RotationLimits limites)
		{
			this.Liberar(muscle);
			ConfiguracionDePoscionSexual.RotationLimits.Usos usos = limites.usos;
			if (((int)usos).HasFlag(1))
			{
				muscle.joint.angularXMotion = ConfigurableJointMotion.Limited;
			}
			if (((int)usos).HasFlag(2))
			{
				muscle.joint.angularYMotion = ConfigurableJointMotion.Limited;
			}
			if (((int)usos).HasFlag(3))
			{
				muscle.joint.angularZMotion = ConfigurableJointMotion.Limited;
			}
			SoftJointLimit lowAngularXLimit = muscle.joint.lowAngularXLimit;
			SoftJointLimit highAngularXLimit = muscle.joint.highAngularXLimit;
			SoftJointLimit angularYLimit = muscle.joint.angularYLimit;
			SoftJointLimit angularZLimit = muscle.joint.angularZLimit;
			lowAngularXLimit.limit = limites.lowX;
			highAngularXLimit.limit = limites.highX;
			angularYLimit.limit = limites.Y;
			angularZLimit.limit = limites.Z;
			muscle.joint.lowAngularXLimit = lowAngularXLimit;
			muscle.joint.highAngularXLimit = highAngularXLimit;
			muscle.joint.angularYLimit = angularYLimit;
			muscle.joint.angularZLimit = angularZLimit;
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000237BC File Offset: 0x000219BC
		private void Liberar(Muscle muscle)
		{
			muscle.joint.angularXMotion = ConfigurableJointMotion.Free;
			muscle.joint.angularYMotion = ConfigurableJointMotion.Free;
			muscle.joint.angularZMotion = ConfigurableJointMotion.Free;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000237E4 File Offset: 0x000219E4
		private void DisableColliders(bool enable, Muscle muscle)
		{
			Collider[] array;
			if (!enable)
			{
				array = muscle.colliders;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].isTrigger = true;
				}
				return;
			}
			array = muscle.colliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].isTrigger = false;
			}
		}

		// Token: 0x040004EE RID: 1262
		public TipoDePose pose;

		// Token: 0x040004EF RID: 1263
		[Header("Config Mapas")]
		public RuntimeAnimatorController controller;

		// Token: 0x040004F0 RID: 1264
		public ReusableAnimatorConfig animatorConfig;

		// Token: 0x040004F1 RID: 1265
		public ReusablePuppetConfig puppetConfig;

		// Token: 0x040004F2 RID: 1266
		public ReusableMusclesConfig musclesConfig;

		// Token: 0x040004F3 RID: 1267
		[Header("Modficadores Config Mapas")]
		public ReusableMusclesPinChangePorOffsetsConfig musclesPinModsConfig;

		// Token: 0x040004F4 RID: 1268
		public ReusableMusclesPropsModsPorOffsetsConfig musclesSpriDampModsConfig;

		// Token: 0x040004F5 RID: 1269
		[Header("Muscles Configs")]
		[Tooltip("Crea ataduras del puppet hacia a posicion de animacion/IK")]
		public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2 atadurasAAnimacionV2 = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2();

		// Token: 0x040004F6 RID: 1270
		[Obsolete("ahora podemos definir weight", true)]
		[NonSerialized]
		public ConfiguracionDePoscionSexual.AtadurasAAnimacion atadurasAAnimacion = new ConfiguracionDePoscionSexual.AtadurasAAnimacion();

		// Token: 0x040004F7 RID: 1271
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		[NonSerialized]
		public ConfiguracionDePoscionSexual.AtadurasAMuscles atadurasAMuscles = new ConfiguracionDePoscionSexual.AtadurasAMuscles();

		// Token: 0x040004F8 RID: 1272
		public ConfiguracionDePoscionSexual.Ataduras ataduras = new ConfiguracionDePoscionSexual.Ataduras();

		// Token: 0x040004F9 RID: 1273
		public ConfiguracionDePoscionSexual.Colliders colliders = new ConfiguracionDePoscionSexual.Colliders();

		// Token: 0x040004FA RID: 1274
		public ConfiguracionDePoscionSexual.LimitarRotaciones limitarRotaciones = new ConfiguracionDePoscionSexual.LimitarRotaciones();

		// Token: 0x02000196 RID: 406
		[Serializable]
		public class LimitarRotaciones
		{
			// Token: 0x04000907 RID: 2311
			public bool Spine1;

			// Token: 0x04000908 RID: 2312
			public bool Spine2;

			// Token: 0x04000909 RID: 2313
			public bool Neck;

			// Token: 0x0400090A RID: 2314
			public bool Head;

			// Token: 0x0400090B RID: 2315
			public bool Shoulders;

			// Token: 0x0400090C RID: 2316
			public bool Arms;

			// Token: 0x0400090D RID: 2317
			[Header("Generalmente estan siempre limitados")]
			public bool knees = true;

			// Token: 0x0400090E RID: 2318
			public bool elbow = true;

			// Token: 0x0400090F RID: 2319
			public bool thighs = true;

			// Token: 0x04000910 RID: 2320
			[Header("Limites en angulos")]
			public ConfiguracionDePoscionSexual.RotationLimits spine1RotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -40f,
				highX = 40f,
				Y = 40f,
				Z = 40f
			};

			// Token: 0x04000911 RID: 2321
			public ConfiguracionDePoscionSexual.RotationLimits spine2RotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -40f,
				highX = 40f,
				Y = 40f,
				Z = 40f
			};

			// Token: 0x04000912 RID: 2322
			public ConfiguracionDePoscionSexual.RotationLimits neckRotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -40f,
				highX = 40f,
				Y = 40f,
				Z = 40f
			};

			// Token: 0x04000913 RID: 2323
			public ConfiguracionDePoscionSexual.RotationLimits headRotationLimitsV2 = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -45f,
				highX = 45f,
				Y = 40f,
				Z = 80f
			};

			// Token: 0x04000914 RID: 2324
			public ConfiguracionDePoscionSexual.RotationLimits shouldersRotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -25f,
				highX = 40f,
				Y = 17f,
				Z = 15f
			};

			// Token: 0x04000915 RID: 2325
			public ConfiguracionDePoscionSexual.RotationLimits kneesRotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -6f,
				highX = 150f,
				Y = 10f,
				Z = 30f
			};

			// Token: 0x04000916 RID: 2326
			public ConfiguracionDePoscionSexual.RotationLimits armsRotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -40f,
				highX = 125f,
				Y = 110f,
				Z = 110f
			};

			// Token: 0x04000917 RID: 2327
			public ConfiguracionDePoscionSexual.RotationLimits elbowRotationLimitsV3 = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -5f,
				highX = 155f,
				Y = 45f,
				Z = 90f
			};

			// Token: 0x04000918 RID: 2328
			public ConfiguracionDePoscionSexual.RotationLimits thighsRotationLimits = new ConfiguracionDePoscionSexual.RotationLimits
			{
				usos = ConfiguracionDePoscionSexual.RotationLimits.Usos.all,
				lowX = -120f,
				highX = 45f,
				Y = 50f,
				Z = 50f
			};
		}

		// Token: 0x02000197 RID: 407
		[Serializable]
		public class Ataduras
		{
			// Token: 0x04000919 RID: 2329
			public float delay = 1f;

			// Token: 0x0400091A RID: 2330
			public TipoDeAtadura hips;

			// Token: 0x0400091B RID: 2331
			public TipoDeAtadura manoR;

			// Token: 0x0400091C RID: 2332
			public TipoDeAtadura manoL;

			// Token: 0x0400091D RID: 2333
			public TipoDeAtadura canillaR;

			// Token: 0x0400091E RID: 2334
			public TipoDeAtadura canillaL;

			// Token: 0x0400091F RID: 2335
			public TipoDeAtadura pieR;

			// Token: 0x04000920 RID: 2336
			public TipoDeAtadura pieL;
		}

		// Token: 0x02000198 RID: 408
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		public class AtadurasAMuscles
		{
			// Token: 0x04000921 RID: 2337
			public float delay = 0.1f;

			// Token: 0x04000922 RID: 2338
			public ConfiguracionDePoscionSexual.AtadurasAMuscles.AtaduraAMuscle manoR;

			// Token: 0x04000923 RID: 2339
			public ConfiguracionDePoscionSexual.AtadurasAMuscles.AtaduraAMuscle manoL;

			// Token: 0x020001E8 RID: 488
			[Serializable]
			public class AtaduraAMuscle
			{
				// Token: 0x04000A49 RID: 2633
				public bool activar;

				// Token: 0x04000A4A RID: 2634
				public TipoDeMuscleAlQueSePuedeAtar target;
			}
		}

		// Token: 0x02000199 RID: 409
		[Serializable]
		public class AtadurasAAnimacionV2
		{
			// Token: 0x04000924 RID: 2340
			public float delay = 1f;

			// Token: 0x04000925 RID: 2341
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion hipsR = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x04000926 RID: 2342
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion hipsL = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x04000927 RID: 2343
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion manoR = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x04000928 RID: 2344
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion manoL = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x04000929 RID: 2345
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion pieR = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x0400092A RID: 2346
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion pieL = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x0400092B RID: 2347
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion rodillaR = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x0400092C RID: 2348
			public ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion rodillaL = new ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion();

			// Token: 0x020001E9 RID: 489
			[Serializable]
			public class AtaduraAAnimacion
			{
				// Token: 0x04000A4B RID: 2635
				public bool activar;

				// Token: 0x04000A4C RID: 2636
				[Range(0f, 1f)]
				public float weight = 1f;

				// Token: 0x04000A4D RID: 2637
				[Tooltip("esta atadura no sera posible. ni manual ni automaticamente")]
				public bool ignorar;
			}
		}

		// Token: 0x0200019A RID: 410
		[Obsolete("usar v2", true)]
		[Serializable]
		public class AtadurasAAnimacion
		{
			// Token: 0x0400092D RID: 2349
			public float delay = 1f;

			// Token: 0x0400092E RID: 2350
			public bool hipsR;

			// Token: 0x0400092F RID: 2351
			public bool hipsL;

			// Token: 0x04000930 RID: 2352
			public bool manoR;

			// Token: 0x04000931 RID: 2353
			public bool manoL;

			// Token: 0x04000932 RID: 2354
			public bool pieR;

			// Token: 0x04000933 RID: 2355
			public bool pieL;

			// Token: 0x04000934 RID: 2356
			public bool rodillaR;

			// Token: 0x04000935 RID: 2357
			public bool rodillaL;
		}

		// Token: 0x0200019B RID: 411
		[Serializable]
		public struct RotationLimits
		{
			// Token: 0x04000936 RID: 2358
			public ConfiguracionDePoscionSexual.RotationLimits.Usos usos;

			// Token: 0x04000937 RID: 2359
			[Range(-177f, 177f)]
			public float lowX;

			// Token: 0x04000938 RID: 2360
			[Range(-177f, 177f)]
			public float highX;

			// Token: 0x04000939 RID: 2361
			[Range(3f, 177f)]
			public float Y;

			// Token: 0x0400093A RID: 2362
			[Range(3f, 177f)]
			public float Z;

			// Token: 0x020001EA RID: 490
			[Flags]
			public enum Usos
			{
				// Token: 0x04000A4F RID: 2639
				None = 0,
				// Token: 0x04000A50 RID: 2640
				x = 1,
				// Token: 0x04000A51 RID: 2641
				y = 2,
				// Token: 0x04000A52 RID: 2642
				z = 3,
				// Token: 0x04000A53 RID: 2643
				all = -1
			}
		}

		// Token: 0x0200019C RID: 412
		[Serializable]
		public class Colliders
		{
			// Token: 0x06000C6B RID: 3179 RVA: 0x00037DAD File Offset: 0x00035FAD
			public bool MuscleEsManos(Animator anim, Muscle muscle)
			{
				return this.MuscleEs(HumanBodyBones.LeftHand, anim, muscle) || this.MuscleEs(HumanBodyBones.RightHand, anim, muscle);
			}

			// Token: 0x06000C6C RID: 3180 RVA: 0x00037DC7 File Offset: 0x00035FC7
			public bool MuscleEsAnteBrazo(Animator anim, Muscle muscle)
			{
				return this.MuscleEs(HumanBodyBones.LeftLowerArm, anim, muscle) || this.MuscleEs(HumanBodyBones.RightLowerArm, anim, muscle);
			}

			// Token: 0x06000C6D RID: 3181 RVA: 0x00037DE1 File Offset: 0x00035FE1
			public bool MuscleEsBrazo(Animator anim, Muscle muscle)
			{
				return this.MuscleEs(HumanBodyBones.LeftUpperArm, anim, muscle) || this.MuscleEs(HumanBodyBones.RightUpperArm, anim, muscle);
			}

			// Token: 0x06000C6E RID: 3182 RVA: 0x00037DFB File Offset: 0x00035FFB
			public bool MuscleEsPies(Animator anim, Muscle muscle)
			{
				return this.MuscleEs(HumanBodyBones.LeftFoot, anim, muscle) || this.MuscleEs(HumanBodyBones.RightFoot, anim, muscle);
			}

			// Token: 0x06000C6F RID: 3183 RVA: 0x00037E13 File Offset: 0x00036013
			public bool MuscleEsCanillas(Animator anim, Muscle muscle)
			{
				return this.MuscleEs(HumanBodyBones.LeftLowerLeg, anim, muscle) || this.MuscleEs(HumanBodyBones.RightLowerLeg, anim, muscle);
			}

			// Token: 0x06000C70 RID: 3184 RVA: 0x00037E2B File Offset: 0x0003602B
			public bool MuscleEsPiernas(Animator anim, Muscle muscle)
			{
				return this.MuscleEs(HumanBodyBones.LeftUpperLeg, anim, muscle) || this.MuscleEs(HumanBodyBones.RightUpperLeg, anim, muscle);
			}

			// Token: 0x06000C71 RID: 3185 RVA: 0x00037E44 File Offset: 0x00036044
			public bool MuscleEs(HumanBodyBones bone, Animator anim, Muscle muscle)
			{
				Transform boneTransform = anim.GetBoneTransform(bone);
				return muscle.target == boneTransform;
			}

			// Token: 0x0400093B RID: 2363
			public bool manos = true;

			// Token: 0x0400093C RID: 2364
			public bool anteBrazos = true;

			// Token: 0x0400093D RID: 2365
			public bool brazos = true;

			// Token: 0x0400093E RID: 2366
			public bool pirnas = true;

			// Token: 0x0400093F RID: 2367
			public bool canillas = true;

			// Token: 0x04000940 RID: 2368
			public bool pies = true;
		}
	}
}
