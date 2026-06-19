using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas.Skins
{
	// Token: 0x02000158 RID: 344
	[Obsolete("", true)]
	public class ParticulasDeSemenParaSkins : ParticulasParaHitSkin
	{
		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060007C9 RID: 1993 RVA: 0x00024158 File Offset: 0x00022358
		// (remove) Token: 0x060007CA RID: 1994 RVA: 0x00024190 File Offset: 0x00022390
		public event ParticulasDeSemenParaSkins.OnCollisionDeSemenHandler collisionedPorSemen;

		// Token: 0x060007CB RID: 1995 RVA: 0x000241C8 File Offset: 0x000223C8
		protected override ParticleSystem ProducirParticleSystem()
		{
			ParticleSystem particleSystem = Object.Instantiate<ParticleSystem>(Singleton<ColleccionDeParticulas>.instance.semenParaSkin);
			particleSystem.name = "Semen Particulas Para Skin " + this.m_HitSkinBasica.name;
			particleSystem.transform.parent = base.transform;
			particleSystem.transform.localRotation = Quaternion.identity;
			particleSystem.transform.localPosition = Vector3.zero;
			particleSystem.transform.localScale = Vector3.one;
			this.m_SemenParticles = particleSystem.GetComponent<SemenParticles>();
			if (this.m_SemenParticles == null)
			{
				throw new ArgumentNullException("m_SemenParticles", "m_SemenParticles null reference.");
			}
			ParticleSystem.MainModule main = particleSystem.main;
			main.simulationSpace = ParticleSystemSimulationSpace.Local;
			main.gravityModifierMultiplier *= 0.33f;
			main.playOnAwake = false;
			particleSystem.gameObject.SetActive(false);
			particleSystem.gameObject.SetActive(true);
			particleSystem.Stop();
			ParticleSystem.CollisionModule collision = particleSystem.collision;
			collision.sendCollisionMessages = false;
			collision.dampen = new ParticleSystem.MinMaxCurve(0.95f, 1f);
			collision.bounce = new ParticleSystem.MinMaxCurve(0f, 0.18f);
			collision.lifetimeLoss = 0f;
			collision.collidesWith = MapaSingleton<ConfiguracionGlobal>.instance.layers.layerMaskToSemenConHoles;
			ParticleSystem.ShapeModule shape = particleSystem.shape;
			shape.scale = Vector3.one * 0.01f;
			if (base.GetComponentInParent<SkinnedMeshRenderer>() != null)
			{
				this.applyShapeToPosition = true;
				shape.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
				this.m_SkinnedMeshRenderer = (shape.skinnedMeshRenderer = base.GetComponentInParent<SkinnedMeshRenderer>());
				shape.meshShapeType = ParticleSystemMeshShapeType.Triangle;
				shape.useMeshColors = false;
			}
			else
			{
				shape.shapeType = ParticleSystemShapeType.Box;
				this.applyShapeToPosition = false;
			}
			ParticleSystem.EmissionModule emission = particleSystem.emission;
			emission.rateOverDistanceMultiplier = 0f;
			emission.rateOverTimeMultiplier = 0f;
			emission.SetBursts(new ParticleSystem.Burst[0]);
			emission.burstCount = 0;
			return particleSystem;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x000243C4 File Offset: 0x000225C4
		protected override void OnParticulasCollisionandoConCollider(ParticleSystem particlesSysContraCollider, ParticleCollisionBroadCaster broadCaster)
		{
			SemenParticles component = particlesSysContraCollider.GetComponent<SemenParticles>();
			if (component == null)
			{
				return;
			}
			if (this.m_targets.Count == 0)
			{
				return;
			}
			int num = 0;
			if (this.m_targets.Count > 1)
			{
				for (int i = 0; i < this.m_targets.Count; i++)
				{
					int num2 = component.particulas.GetCollisionEvents(this.m_targets[i], this.collisionEvents_Temp);
					if (num2 > 0)
					{
						for (int j = 0; j < num2; j++)
						{
							if (num + j >= this.collisionEvents.Count)
							{
								this.collisionEvents.Add(this.collisionEvents_Temp[j]);
							}
							else
							{
								this.collisionEvents[num + j] = this.collisionEvents_Temp[j];
							}
						}
						num += num2;
					}
				}
			}
			else
			{
				num = component.particulas.GetCollisionEvents(this.m_targets[0], this.collisionEvents);
			}
			if (num == 0)
			{
				return;
			}
			Matrix4x4 matrix4x;
			if (this.m_SkinnedMeshRenderer != null)
			{
				if (!this.usarRootBone)
				{
					matrix4x = this.m_ParticleSystem.transform.worldToLocalMatrix;
				}
				else
				{
					matrix4x = this.m_SkinnedMeshRenderer.rootBone.worldToLocalMatrix;
				}
			}
			else
			{
				matrix4x = this.m_ParticleSystem.transform.worldToLocalMatrix;
			}
			if (this.inverseMatrix)
			{
				matrix4x = matrix4x.inverse;
			}
			int num3 = Mathf.Min(num, this.collisionEvents.Count);
			for (int k = 0; k < num; k++)
			{
				ParticleCollisionEvent particleCollisionEvent = this.collisionEvents[k];
				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
				if (!this.transformar)
				{
					emitParams.velocity = particleCollisionEvent.velocity * this.velocityTransferMod;
				}
				else
				{
					emitParams.velocity = matrix4x.MultiplyVector(particleCollisionEvent.velocity * this.velocityTransferMod);
				}
				if (!this.transformar)
				{
					emitParams.position = particleCollisionEvent.intersection;
				}
				else
				{
					emitParams.position = matrix4x.MultiplyPoint3x4(particleCollisionEvent.intersection);
				}
				emitParams.applyShapeToPosition = this.applyShapeToPosition;
				if (this.debugDrawEmits)
				{
					if (emitParams.velocity == Vector3.zero)
					{
						if (!this.transformar)
						{
						}
					}
					else
					{
						bool flag = this.transformar;
					}
				}
				this.m_ParticleSystem.Emit(emitParams, 1);
			}
			if (num > 0)
			{
				this.m_SemenParticles.flagToSkipUpdate = true;
				this.m_SemenParticles.SimularPor(this.m_ParticleSystem.main.startLifetime.constantMax);
			}
			ParticulasDeSemenParaSkins.OnCollisionDeSemenHandler onCollisionDeSemenHandler = this.collisionedPorSemen;
			if (onCollisionDeSemenHandler == null)
			{
				return;
			}
			onCollisionDeSemenHandler(this, this.m_HitSkinBasica, component, broadCaster, num3, this.collisionEvents);
		}

		// Token: 0x0400061E RID: 1566
		public bool debugDrawEmits;

		// Token: 0x0400061F RID: 1567
		public bool applyShapeToPosition;

		// Token: 0x04000620 RID: 1568
		public bool transformar = true;

		// Token: 0x04000621 RID: 1569
		public bool usarRootBone = true;

		// Token: 0x04000622 RID: 1570
		[Range(0f, 1f)]
		public float velocityTransferMod;

		// Token: 0x04000623 RID: 1571
		public bool inverseMatrix;

		// Token: 0x04000624 RID: 1572
		private List<ParticleCollisionEvent> collisionEvents_Temp = new List<ParticleCollisionEvent>(200);

		// Token: 0x04000625 RID: 1573
		private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>(200);

		// Token: 0x04000627 RID: 1575
		private SkinnedMeshRenderer m_SkinnedMeshRenderer;

		// Token: 0x04000628 RID: 1576
		private SemenParticles m_SemenParticles;

		// Token: 0x02000159 RID: 345
		// (Invoke) Token: 0x060007CF RID: 1999
		public delegate void OnCollisionDeSemenHandler(ParticulasDeSemenParaSkins particlesParaSkin, HitSkinBasica skin, SemenParticles semenCollisionando, ParticleCollisionBroadCaster broadCaster, int count, List<ParticleCollisionEvent> collisionEvents);
	}
}
