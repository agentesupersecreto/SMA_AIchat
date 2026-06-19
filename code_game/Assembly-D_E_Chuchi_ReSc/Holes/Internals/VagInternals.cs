using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts.Vags;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Unity.Mathematics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals
{
	// Token: 0x020001A1 RID: 417
	public class VagInternals : HoleInternal, IVagInternals, IHoleInternals
	{
		// Token: 0x060009DF RID: 2527 RVA: 0x0002C230 File Offset: 0x0002A430
		public Vector3 GetUterusTipDefaulPosition()
		{
			return this.m_root.TransformPoint(this.m_uterusTipDefaultPosFromRoot);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0002C243 File Offset: 0x0002A443
		private void AwakeDesgaste()
		{
			this.m_desgastable = this.GetComponentEnRoot(false);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0002C252 File Offset: 0x0002A452
		private void UpdateDesgaste()
		{
			this.m_currentDesgaste = this.m_desgastable.anchura.current;
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0002C26C File Offset: 0x0002A46C
		private float2 GetCanalDefaultScale(float defaultScaleX, float defaultScaleY, int index, int cantidad)
		{
			float num = Mathf.InverseLerp((float)cantidad, 1f, (float)(index + 1)).OutPow(this.desgasteConfig.power);
			float num2 = Mathf.Lerp(this.desgasteConfig.minScaleMod, this.desgasteConfig.maxScaleMod, num);
			float num3 = Mathf.Lerp(defaultScaleX, defaultScaleX * num2, this.m_currentDesgaste);
			float num4 = Mathf.Lerp(defaultScaleY, defaultScaleY * num2, this.m_currentDesgaste);
			return new float2(num3, num4);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0002C2E0 File Offset: 0x0002A4E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_VagHoleInnerConstraintsAdder == null)
			{
				throw new ArgumentNullException("m_VagHoleInnerConstraintsAdder", "m_VagHoleInnerConstraintsAdder null reference.");
			}
			this.m_defDistance_OverCanalTip_OverCanalRoot_Max = Vector3.Distance(this.m_overCanalRootBone.position, this.m_overCanalTipBone.position);
			Transform parent = this.m_overCanalTipBone.parent;
			this.m_overCanalTipBone.parent = this.m_overCanalRootBone;
			this.m_overCanalRootBone.localScale = Vector3.one * 0.01f;
			this.m_overCanalTipBone.parent = parent;
			this.m_overCanalTipBone.localScale = Vector3.one;
			this.m_overCanalTipDefaultPosFromOverCanalRoot = this.m_overCanalRootBone.InverseTransformPointUnscaled(this.m_root, this.m_overCanalTipBone.position);
			this.m_defDistance_OverCanalTip_OverCanalRoot_Min = Vector3.Distance(this.m_overCanalRootBone.position, this.m_overCanalTipBone.position);
			this.m_uterusTipDefaultPosFromRoot = this.m_root.InverseTransformPoint(this.m_uterusTip.position);
			this.AwakeDesgaste();
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0002C3EC File Offset: 0x0002A5EC
		private void MountHole()
		{
			ArmatureSkins componentEnRoot = this.m_hole.owner.GetComponentEnRoot<ArmatureSkins>();
			HashSet<Transform> holeBonesSet = new HashSet<Transform>(this.m_holeRoot.GetComponentsInChildren<Transform>());
			Skin.CambiarBonesReferences(componentEnRoot, this.m_SkinnedMeshRenderer, (Transform t) => holeBonesSet.Contains(t));
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0002C43C File Offset: 0x0002A63C
		protected override void Started()
		{
			this.MountHole();
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0002C444 File Offset: 0x0002A644
		protected override void FixRotations()
		{
			base.FixRotations();
			this.ResetScales();
			this.UpdateOverCanalStretchToToTip();
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0002C458 File Offset: 0x0002A658
		private void ResetScales()
		{
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_canal_000, 2f, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 0, 6));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_canal_001, 2f, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 1, 6));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_canal_002, 2f, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 2, 6));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_canal_003, 2f, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 3, 6));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_canal_004, 2f, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 4, 6));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_canal_005, 2f, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 5, 6));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_cervixCapsule_000, 10f, new float2(this.configScaleForCapsule.defaultScaleX, this.configScaleForCapsule.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_VagHoleInnerConstraintsAdder.m_cervixCapsule_001, 10f, new float2(this.configScaleForCapsule.defaultScaleX, this.configScaleForCapsule.defaultScaleY));
			for (int i = 0; i < this.m_overCanal.bones.Count; i++)
			{
				HoleInternal.ResetScaleToStretchTo(this.m_overCanal.bones[i], 10f, this.configScaleForOverCanal.defaultScaleX, this.configScaleForOverCanal.defaultScaleY);
			}
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0002C644 File Offset: 0x0002A844
		private void UpdateOverCanalStretchToToTip()
		{
			Vector3 vector = this.m_overCanalRootBone.TransformPointUnscaled(this.m_root, this.m_overCanalTipDefaultPosFromOverCanalRoot);
			this.m_overCanalTipBone.position = Vector3.Lerp(this.m_overCanalTipBone.position, vector, Time.fixedDeltaTime * 10f);
			this.m_overCanalRootBone.localScale = Vector3.Lerp(this.m_overCanalRootBone.localScale, Vector3.one * 0.01f, Time.fixedDeltaTime * 10f);
			this.m_currentOverCanalPenetrationW = Mathf.Lerp(this.m_currentOverCanalPenetrationW, 0f, Time.fixedDeltaTime * 10f);
			if (this.m_hole.isPenetrated)
			{
				HoleInternal.InternalPoint internalPoint = this.m_AllPuntosDicc[this.m_overCanalRootBone];
				Vector3 vector2;
				Vector3 vector3;
				Vector3 vector4;
				this.m_hole.PenetradoPor().GetPuntaStartTipWorldPositions(1.025f, out vector2, out vector3, out vector4);
				Vector3 vector5 = Math3d.ProjectPointOnLine(vector3, vector4, vector);
				Vector3 vector6 = this.m_hole.entrada.position - vector5;
				Vector3 vector7 = vector3 - vector5;
				if (Vector3.Dot(vector6, vector7) < 0f)
				{
					float num = internalPoint.penetrationInfluenceW.OutPow(this.tipPositionByPenetrationOutPower);
					Vector3 vector8 = Math3d.ProjectPointOnPlane(vector4, vector3, this.m_overCanalTipBone.position);
					this.m_overCanalTipBone.position = Vector3.Lerp(this.m_overCanalTipBone.position, vector8, num);
					float num2 = Vector3.Distance(vector, this.m_overCanalTipBone.position);
					float num3 = MathfExtension.InverseLerpUnclamped(this.m_defDistance_OverCanalTip_OverCanalRoot_Min, this.m_defDistance_OverCanalTip_OverCanalRoot_Max, num2);
					this.m_currentOverCanalPenetrationW = num3 * num;
					this.m_overCanalRootBone.localScale = Vector3.LerpUnclamped(Vector3.one * 0.01f, Vector3.one, this.m_currentOverCanalPenetrationW);
				}
			}
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0002C804 File Offset: 0x0002AA04
		protected override void AfterElasticLoops()
		{
			base.AfterElasticLoops();
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_canal_000, this.configScaleForCanal, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 0, 6));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_canal_001, this.configScaleForCanal, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 1, 6));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_canal_002, this.configScaleForCanal, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 2, 6));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_canal_003, this.configScaleForCanal, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 3, 6));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_canal_004, this.configScaleForCanal, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 4, 6));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_canal_005, this.configScaleForCanal, this.GetCanalDefaultScale(this.configScaleForCanal.defaultScaleX, this.configScaleForCanal.defaultScaleY, 5, 6));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_cervixCapsule_000, this.configScaleForCapsule, new float2(this.configScaleForCapsule.defaultScaleX, this.configScaleForCapsule.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_VagHoleInnerConstraintsAdder.m_cervixCapsule_001, this.configScaleForCapsule, new float2(this.configScaleForCapsule.defaultScaleX, this.configScaleForCapsule.defaultScaleY));
			for (int i = 0; i < this.m_overCanal.bones.Count; i++)
			{
				HoleInternal.SetScaleToStretchTo(this, this.m_overCanal.bones[i], this.configScaleForOverCanal);
			}
			this.UpdateCervix();
			this.UpdateUterus();
			this.UpdateDesgaste();
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0002CA04 File Offset: 0x0002AC04
		private void UpdateCervix()
		{
			HoleInternal.InternalPoint internalPoint = this.m_AllPuntosDicc[this.m_cervix];
			Vector3 vector = internalPoint.root.TransformPoint(internalPoint.defaultPositionFromRoot);
			this.UpdateCervixCollisions(vector);
			this.UpdateCervixPosePorDisplacement(vector);
			this.UpdateCervixPose();
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0002CA4C File Offset: 0x0002AC4C
		private void UpdateUterus()
		{
			float num = Mathf.Lerp(this.m_uterusTip.localScale.z, 1f, Time.fixedDeltaTime * 2f);
			float num2 = 1f / Mathf.Sqrt(num);
			num2 = ((num2 > 2.25f) ? 2.25f : num2);
			this.m_uterusTip.localScale = new Vector3(num2, num2, num);
			Vector3 vector = Math3d.ProjectPointOnLine(this.m_muscleAbdomen.position, this.m_muscleAbdomen.forward, this.m_uterusTip.position);
			if (Vector3.Dot(this.m_muscleAbdomen.forward, vector - this.m_muscleAbdomen.position) > 0f)
			{
				float num3 = Vector3.Distance(vector, this.m_muscleAbdomen.position) * this.m_internalsWorldScale;
				this.m_uterusTip.position = Math3d.ProjectPointOnPlane(this.m_muscleAbdomen.forward, this.m_muscleAbdomen.position, this.m_uterusTip.position);
				float num4 = Mathf.InverseLerp(0f, this.m_uterusToCervixDefaultDistance, num3);
				float num5 = Mathf.Lerp(1f, 0.001f, num4);
				float num6 = 1f / Mathf.Sqrt(num5);
				num6 = ((num6 > 2.25f) ? 2.25f : num6);
				this.m_uterusTip.localScale = new Vector3(num6, num6, num5);
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0002CBAC File Offset: 0x0002ADAC
		protected override bool MaxAngleLateral1PointsOfRanges(out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius)
		{
			worldStartPoint = this.m_hole.entrada.position;
			worldEndPoint = this.m_hole.fondoPhysics.position;
			worldNormal = -this.m_hole.worldOutHoleDirection;
			worldConePoint = worldStartPoint + worldNormal * this.configLateral.point1Retroceso * this.m_hole.owner.escala;
			coneAngle = this.configLateral.maxAngle1;
			worldConeMaxRadius = Vector3.Distance(worldConePoint, worldEndPoint) * Mathf.Tan(coneAngle * 0.017453292f);
			worldStartPoint += worldNormal * this.m_hole.owner.escala * 0.001f;
			return true;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0002B9ED File Offset: 0x00029BED
		protected override void MaxAngleLateralLastPointsOfRanges(out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius)
		{
			this.MaxAngleLateral1PointsOfRanges(out worldStartPoint, out worldEndPoint, out worldNormal, out worldConePoint, out coneAngle, out worldConeMaxRadius);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0002CCA4 File Offset: 0x0002AEA4
		protected override void ProducePoints(List<HoleInternal.InternalPoint> puntos)
		{
			for (int i = 0; i < this.m_cervixCap.bones.Count; i++)
			{
				Transform transform = this.m_cervixCap.bones[i];
				puntos.Add(new HoleInternal.InternalPoint(i)
				{
					punto = transform,
					root = this.m_cervixCap.root,
					config = this.m_cervixCap.config
				});
			}
			for (int j = 0; j < this.m_overCanal.bones.Count; j++)
			{
				Transform transform2 = this.m_overCanal.bones[j];
				puntos.Add(new HoleInternal.InternalPoint(j)
				{
					punto = transform2,
					root = this.m_overCanal.root,
					config = this.m_overCanal.config
				});
			}
			this.ProduceCervixPoints(puntos);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0002CD7C File Offset: 0x0002AF7C
		private void ProduceCervixPoints(List<HoleInternal.InternalPoint> puntos)
		{
			puntos.Add(new HoleInternal.InternalPoint(0)
			{
				punto = this.m_cervix,
				root = this.m_capsule,
				config = this.cervixPenetrationConfig
			});
			puntos.Add(new HoleInternal.InternalPoint(1)
			{
				punto = this.m_cervixPivot,
				root = this.m_capsule,
				config = this.cervixPenetrationConfig
			});
			puntos.Add(new HoleInternal.InternalPoint(2)
			{
				punto = this.m_uterusTip,
				root = this.m_capsule,
				config = this.cervixPenetrationConfig
			});
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0002CE1C File Offset: 0x0002B01C
		protected override void ProduceElasticPoints(List<HoleInternal.ElasticInternalPoint> puntos)
		{
			HoleInternal.ProduceSetionElasticPoints(puntos, null, this.m_canal, this.m_cervixCapRoot, true);
			puntos.Add(new HoleInternal.ElasticInternalPoint(0)
			{
				punto = this.m_cervixCapRoot.bones.First<Transform>(),
				root = this.m_cervixCapRoot.root,
				previus = this.m_canal.bones.Last<Transform>(),
				next = this.m_overCanalRoot.bones.First<Transform>(),
				config = this.m_cervixCapRoot.config,
				nextSmoothTimeMod = this.m_cervixCapRoot.nextSmoothTimeMod,
				previusSmoothTimeMod = this.m_cervixCapRoot.previusSmoothTimeMod,
				rootSmoothTimeMod = this.m_cervixCapRoot.rootSmoothTimeMod,
				canChangePositionToProyectedPenisPosition = true
			});
			puntos.Add(new HoleInternal.ElasticInternalPoint(0)
			{
				punto = this.m_overCanalRoot.bones.First<Transform>(),
				root = this.m_overCanalRoot.root,
				previus = this.m_cervixCapRoot.bones.First<Transform>(),
				next = this.m_overCanalTipBone,
				config = this.m_overCanalRoot.config,
				nextSmoothTimeMod = this.m_overCanalRoot.nextSmoothTimeMod,
				previusSmoothTimeMod = this.m_overCanalRoot.previusSmoothTimeMod,
				rootSmoothTimeMod = this.m_overCanalRoot.rootSmoothTimeMod,
				canChangePositionToProyectedPenisPosition = true
			});
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0002CF87 File Offset: 0x0002B187
		public ModificableDeFloat cervixPoseModificable
		{
			get
			{
				return this.m_cervixPoseModificable;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x0002CF8F File Offset: 0x0002B18F
		public SphereCollider cervixCollider
		{
			get
			{
				return this.m_cervixCollider;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x0002CF97 File Offset: 0x0002B197
		public Transform cervixPivot
		{
			get
			{
				return this.m_cervixPivot;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x0002CF9F File Offset: 0x0002B19F
		public Transform uterusTip
		{
			get
			{
				return this.m_uterusTip;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x0002CFA7 File Offset: 0x0002B1A7
		public Transform uterus
		{
			get
			{
				return this.m_uterus;
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0002CFB0 File Offset: 0x0002B1B0
		protected override void Starting()
		{
			this.m_cervixCollider = this.m_cervixPivot.GetComponentNotNull<SphereCollider>();
			this.m_cervixCollider.isTrigger = true;
			this.m_cervixCollisionLayerMask = ConfiguracionGlobal.layersStatic.penes.ToLayerMask();
			this.m_uterusToCervixDefaultDistance = Vector3.Distance(this.m_root.InverseTransformPoint(this.m_cervix.position), this.m_root.InverseTransformPoint(this.m_uterusTip.position));
			this.m_localUterusTipPosFromCervix = this.m_cervix.InverseTransformPoint(this.m_uterusTip.position);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0002D042 File Offset: 0x0002B242
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_cervixCollider != null)
			{
				Object.Destroy(this.m_cervixCollider);
			}
			this.m_cervixCollider = null;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0002D06C File Offset: 0x0002B26C
		private void UpdateCervixCollisions(Vector3 cervixDefWPos)
		{
			float num = this.m_cervixPivot.lossyScale.Escala();
			this.m_cervixCollider.radius = this.configCervixCollisions.localColliderRadius;
			HoleInternal.InternalPoint internalPoint = this.m_AllPuntosDicc[this.m_uterusTip];
			Vector3 vector = internalPoint.root.TransformPoint(internalPoint.defaultPositionFromRoot);
			this.m_cervixPoseWPorCollision = Mathf.Lerp(this.m_cervixPoseWPorCollision, 1f, Time.fixedDeltaTime * 2f);
			this.m_cervix.position = Vector3.Lerp(this.m_cervix.position, cervixDefWPos, Time.fixedDeltaTime * 2f);
			this.m_uterusTip.position = Vector3.Lerp(this.m_uterusTip.position, vector, Time.fixedDeltaTime * 2f);
			int num2 = 0;
			try
			{
				num2 = Physics.OverlapSphereNonAlloc(this.m_cervixPivot.position, this.m_cervixCollider.radius * num, VagInternals.m_overlapingCervixResult, this.m_cervixCollisionLayerMask, QueryTriggerInteraction.Ignore);
				if (num2 > 0)
				{
					Vector3 position = this.m_cervixCollider.transform.position;
					Quaternion rotation = this.m_cervixCollider.transform.rotation;
					Vector3 vector2 = Vector3.zero;
					for (int i = 0; i < num2; i++)
					{
						Collider collider = VagInternals.m_overlapingCervixResult[i];
						Transform transform = collider.transform;
						Vector3 vector3;
						float num3;
						if (Physics.ComputePenetration(this.m_cervixCollider, position, rotation, collider, transform.position, transform.rotation, out vector3, out num3))
						{
							vector2 += vector3.normalized * num3;
						}
					}
					if (vector2 != Vector3.zero)
					{
						Vector3 forward = this.m_muscleAbdomen.forward;
						if (Vector3.Dot(vector2, forward) > 0f)
						{
							Vector3 vector4 = Vector3.Project(vector2, forward);
							this.m_cervix.position = this.m_cervix.position + vector4;
							this.m_uterusTip.position = this.m_cervix.TransformPoint(this.m_localUterusTipPosFromCervix);
						}
					}
				}
			}
			finally
			{
				Array.Clear(VagInternals.m_overlapingCervixResult, 0, num2);
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0002D28C File Offset: 0x0002B48C
		private void UpdateCervixPosePorDisplacement(Vector3 cervixDefWPos)
		{
			float num = Vector3.Distance(cervixDefWPos, this.m_cervix.position) / this.m_worldScale;
			this.m_cervixPoseWPorCollision = 1f - Mathf.InverseLerp(0f, this.configCervixCollisions.localDisplacementToReposoPose, num);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0002D2D4 File Offset: 0x0002B4D4
		private void UpdateCervixPose()
		{
			Transform capsule = this.m_capsule;
			HoleInternal.InternalPoint internalPoint = this.m_AllPuntosDicc[this.m_cervix];
			HoleInternal.InternalPoint internalPoint2 = this.m_AllPuntosDicc[this.m_cervixPivot];
			internalPoint.ResetRotation();
			internalPoint2.ResetRotation();
			float num = this.m_cervixPoseModificable.ModificarValor(this.m_cervixPoseWPorCollision);
			Quaternion quaternion = Quaternion.AngleAxis(this.configCervixCollisions.reposoPoseAngle * num * 0.5f, -capsule.right);
			this.m_cervix.rotation = quaternion * this.m_cervix.rotation;
			this.m_cervixPivot.rotation = quaternion * this.m_cervixPivot.rotation;
		}

		// Token: 0x040007C8 RID: 1992
		[Header("Vag")]
		[SerializeField]
		private VagHoleInnerConstraintsAdder m_VagHoleInnerConstraintsAdder;

		// Token: 0x040007C9 RID: 1993
		public HoleInternal.ConfigLateral configLateral = new HoleInternal.ConfigLateral();

		// Token: 0x040007CA RID: 1994
		[Header("Puntos Elasticos")]
		[SerializeField]
		private HoleInternal.Seccion m_canal = new HoleInternal.Seccion();

		// Token: 0x040007CB RID: 1995
		[SerializeField]
		private HoleInternal.Seccion m_cervixCapRoot = new HoleInternal.Seccion();

		// Token: 0x040007CC RID: 1996
		[SerializeField]
		private HoleInternal.Seccion m_overCanalRoot = new HoleInternal.Seccion();

		// Token: 0x040007CD RID: 1997
		[Header("Puntos")]
		[SerializeField]
		private HoleInternal.Seccion m_cervixCap = new HoleInternal.Seccion();

		// Token: 0x040007CE RID: 1998
		[SerializeField]
		private HoleInternal.Seccion m_overCanal = new HoleInternal.Seccion();

		// Token: 0x040007CF RID: 1999
		[SerializeField]
		private HoleInternal.Seccion m_uterusTipSeccion = new HoleInternal.Seccion();

		// Token: 0x040007D0 RID: 2000
		[SerializeField]
		private Transform m_overCanalRootBone;

		// Token: 0x040007D1 RID: 2001
		[SerializeField]
		private Transform m_overCanalTipBone;

		// Token: 0x040007D2 RID: 2002
		[Header("Vag Configs")]
		public float tipPositionByPenetrationOutPower = 1f;

		// Token: 0x040007D3 RID: 2003
		public HoleInternal.ConfigScale configScaleForCanal = new HoleInternal.ConfigScale();

		// Token: 0x040007D4 RID: 2004
		public HoleInternal.ConfigScale configScaleForCapsule = new HoleInternal.ConfigScale();

		// Token: 0x040007D5 RID: 2005
		public HoleInternal.ConfigScale configScaleForOverCanal = new HoleInternal.ConfigScale();

		// Token: 0x040007D6 RID: 2006
		private float m_defDistance_OverCanalTip_OverCanalRoot_Min;

		// Token: 0x040007D7 RID: 2007
		private float m_defDistance_OverCanalTip_OverCanalRoot_Max;

		// Token: 0x040007D8 RID: 2008
		private Vector3 m_overCanalTipDefaultPosFromOverCanalRoot;

		// Token: 0x040007D9 RID: 2009
		private float m_currentOverCanalPenetrationW;

		// Token: 0x040007DA RID: 2010
		private Vector3 m_uterusTipDefaultPosFromRoot;

		// Token: 0x040007DB RID: 2011
		[Header("Vag Cervix")]
		public float cervixPoseW = 1f;

		// Token: 0x040007DC RID: 2012
		public HoleInternal.ConfigPenetration cervixPenetrationConfig = new HoleInternal.ConfigPenetration();

		// Token: 0x040007DD RID: 2013
		public VagInternals.ConfigCervixCollisions configCervixCollisions = new VagInternals.ConfigCervixCollisions();

		// Token: 0x040007DE RID: 2014
		[SerializeField]
		private Transform m_capsule;

		// Token: 0x040007DF RID: 2015
		[SerializeField]
		private Transform m_cervix;

		// Token: 0x040007E0 RID: 2016
		[SerializeField]
		private Transform m_cervixPivot;

		// Token: 0x040007E1 RID: 2017
		[SerializeField]
		private Transform m_uterus;

		// Token: 0x040007E2 RID: 2018
		[SerializeField]
		private Transform m_uterusTip;

		// Token: 0x040007E3 RID: 2019
		[SerializeField]
		private Transform m_muscleAbdomen;

		// Token: 0x040007E4 RID: 2020
		[SerializeField]
		[ReadOnlyUI]
		private float m_cervixPoseWPorCollision = 1f;

		// Token: 0x040007E5 RID: 2021
		[SerializeField]
		private ModificableDeFloat m_cervixPoseModificable = new ModificableDeFloat(1f);

		// Token: 0x040007E6 RID: 2022
		private SphereCollider m_cervixCollider;

		// Token: 0x040007E7 RID: 2023
		private int m_cervixCollisionLayerMask;

		// Token: 0x040007E8 RID: 2024
		[ReadOnlyUI]
		[SerializeField]
		private float m_uterusToCervixDefaultDistance;

		// Token: 0x040007E9 RID: 2025
		private Vector3 m_localUterusTipPosFromCervix;

		// Token: 0x040007EA RID: 2026
		private static Collider[] m_overlapingCervixResult = new Collider[100];

		// Token: 0x040007EB RID: 2027
		private IVagDesgastable m_desgastable;

		// Token: 0x040007EC RID: 2028
		[Header("Desgaste")]
		public VagInternals.DesgasteConfig desgasteConfig = new VagInternals.DesgasteConfig();

		// Token: 0x040007ED RID: 2029
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentDesgaste;

		// Token: 0x040007EE RID: 2030
		[Header("Hole Mount")]
		[SerializeField]
		private Transform m_holeRoot;

		// Token: 0x020001A2 RID: 418
		[Serializable]
		public class ConfigCervixCollisions
		{
			// Token: 0x040007EF RID: 2031
			public float localColliderRadius = 0.0055f;

			// Token: 0x040007F0 RID: 2032
			public float localDisplacementToReposoPose = 0.01f;

			// Token: 0x040007F1 RID: 2033
			public float reposoPoseAngle = 80f;
		}

		// Token: 0x020001A3 RID: 419
		[Serializable]
		public class DesgasteConfig
		{
			// Token: 0x040007F2 RID: 2034
			public float power = 3f;

			// Token: 0x040007F3 RID: 2035
			public float maxScaleMod = 12f;

			// Token: 0x040007F4 RID: 2036
			public float minScaleMod = 6f;
		}
	}
}
