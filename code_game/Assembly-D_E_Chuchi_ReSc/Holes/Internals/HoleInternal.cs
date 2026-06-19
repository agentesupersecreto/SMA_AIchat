using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer;
using Assets.SystemasConstraints._Abstract;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Skins;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals
{
	// Token: 0x02000192 RID: 402
	public abstract class HoleInternal : CustomUpdatedMonobehaviourBase, IHoleInternals
	{
		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00029C3E File Offset: 0x00027E3E
		public SkinnedMeshRenderer skinnedMeshRenderer
		{
			get
			{
				return this.m_SkinnedMeshRenderer;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x00029C46 File Offset: 0x00027E46
		public Transform root
		{
			get
			{
				return this.m_root;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00029C4E File Offset: 0x00027E4E
		public ConstrainedSkeleton skeleton
		{
			get
			{
				return this.m_ConstrainedSkeleton;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x00029C56 File Offset: 0x00027E56
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedAfterUpdateEmulacionDeEventosDeColision);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x00014087 File Offset: 0x00012287
		public sealed override GlobalUpdater.UpdateType? updateEvent6
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x00029C5F File Offset: 0x00027E5F
		public float worldScale
		{
			get
			{
				if (!base.isAwaken)
				{
					return 1f;
				}
				return this.m_worldScale;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x00029C75 File Offset: 0x00027E75
		public ModificableDeFloat scaleModificador
		{
			get
			{
				return this.m_scaleModificador;
			}
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00029C80 File Offset: 0x00027E80
		protected override void AwakeUnityEvent()
		{
			this.m_worldScale = ((this.m_root != null) ? this.m_root.lossyScale.Escala() : 1f);
			IFemaleSkins componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot.isAwaken)
			{
				this.Skins_mainSkinsAdded(componentEnRoot);
			}
			else
			{
				componentEnRoot.mainSkinsAdded += this.Skins_mainSkinsAdded;
			}
			this.InitPuntos();
			base.AwakeUnityEvent();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
			if (this.m_SkinnedMeshRenderer == null)
			{
				throw new ArgumentNullException("m_SkinnedMeshRenderer", "m_SkinnedMeshRenderer null reference.");
			}
			if (this.m_ConstrainedSkeleton == null)
			{
				throw new ArgumentNullException("m_ConstrainedSkeleton", "m_ConstrainedSkeleton null reference.");
			}
			this.m_ConstrainedSkeleton.Init(this.m_SkinnedMeshRenderer);
			base.SetYieldStart();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00029D60 File Offset: 0x00027F60
		private void Skins_mainSkinsAdded(object sender)
		{
			this.m_skin = ((IFemaleSkins)sender).AddSkin<HoleInternalSkin>(typeof(HoleInternalSkin), this.m_SkinnedMeshRenderer, SkinConfig.nothing, false, false, null, null, null, null);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00029D99 File Offset: 0x00027F99
		protected sealed override void StartUnityEvent()
		{
			throw new NotSupportedException("se esta usando el yield start");
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00029DA5 File Offset: 0x00027FA5
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_worldScale = this.m_root.lossyScale.Escala();
			this.Starting();
			while (!this.m_hole.isStared)
			{
				yield return null;
			}
			this.OverrideInitialConfigToHole();
			this.Started();
			yield break;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x00029DB4 File Offset: 0x00027FB4
		private void OverrideInitialConfigToHole()
		{
			this.m_driverDataConfigHandler = new PenetrationJointCreator.GetConeTrayecotiaDataForDriverConfigHandler(this.GetRangesForWorldPoint);
			this.m_hole.penetrationJointCreator.configuracionConeTrayectorias.useToUpdateDrivers = true;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00029DE0 File Offset: 0x00027FE0
		private void OverrideConstantConfigToHole()
		{
			this.m_overridingCastingTrayectos.Clear();
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			Vector3 vector4;
			float num;
			float num2;
			if (this.MaxAngleLateral1PointsOfRanges(out vector, out vector2, out vector3, out vector4, out num, out num2))
			{
				Vector3 vector5 = (vector + vector2) / 2f;
				this.m_overridingCastingTrayectos.Add(new ValueTuple<Vector3, Vector3, float>(vector2, vector5, num2));
				this.m_overridingCastingTrayectos.Add(new ValueTuple<Vector3, Vector3, float>(vector5, vector, num2 / 1.5f));
			}
			this.m_hole.penetraciones.SetMultipleTrayectoCalculadorDePenetracion(this.m_overridingCastingTrayectos);
			this.m_hole.penetrationJointCreator.FlagUpdateDriversConConeTrayectorias(this.m_driverDataConfigHandler);
		}

		// Token: 0x06000973 RID: 2419
		protected abstract void Starting();

		// Token: 0x06000974 RID: 2420
		protected abstract void Started();

		// Token: 0x06000975 RID: 2421 RVA: 0x00029E7C File Offset: 0x0002807C
		private void InitPuntos()
		{
			this.m_solver = this.GetComponentEnRoot(false);
			if (this.m_solver == null)
			{
				throw new ArgumentNullException("m_solver", "m_solver null reference.");
			}
			if (!this.m_solver.isAwaken)
			{
				this.m_solver.ManualAwake();
			}
			this.m_AllPuntosDicc = new Dictionary<Transform, HoleInternal.InternalPoint>();
			this.m_puntos = new List<HoleInternal.InternalPoint>();
			this.m_ElasticPuntos = new List<HoleInternal.ElasticInternalPoint>();
			this.ProducePoints(this.m_puntos);
			this.ProduceElasticPoints(this.m_ElasticPuntos);
			for (int i = 0; i < this.m_puntos.Count; i++)
			{
				HoleInternal.InternalPoint internalPoint = this.m_puntos[i];
				this.m_AllPuntosDicc.Add(internalPoint.punto, internalPoint);
				internalPoint.Init(this, i);
				internalPoint.UpdateDefaults(this.m_root);
			}
			for (int j = 0; j < this.m_ElasticPuntos.Count; j++)
			{
				HoleInternal.ElasticInternalPoint elasticInternalPoint = this.m_ElasticPuntos[j];
				this.m_AllPuntosDicc.Add(elasticInternalPoint.punto, elasticInternalPoint);
				elasticInternalPoint.Init(this, j);
				elasticInternalPoint.UpdateDefaults(this.m_root);
			}
		}

		// Token: 0x06000976 RID: 2422
		protected abstract bool MaxAngleLateral1PointsOfRanges(out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius);

		// Token: 0x06000977 RID: 2423
		protected abstract void MaxAngleLateralLastPointsOfRanges(out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius);

		// Token: 0x06000978 RID: 2424 RVA: 0x00029F98 File Offset: 0x00028198
		public void GetRangesForWorldPoint(Vector3 worldPoint, out Vector3 worldPointProyectedToEndStart, out float worldConeRadiusAtPoint, out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius)
		{
			if (this.MaxAngleLateral1PointsOfRanges(out worldStartPoint, out worldEndPoint, out worldNormal, out worldConePoint, out coneAngle, out worldConeMaxRadius) && this.TryGetRangesForWorldPoint(worldPoint, worldStartPoint, worldEndPoint))
			{
				worldPointProyectedToEndStart = Math3d.ProjectPointOnLine(worldConePoint, worldEndPoint - worldConePoint, worldPoint);
				worldConeRadiusAtPoint = Vector3.Distance(worldConePoint, worldPointProyectedToEndStart) * Mathf.Tan(coneAngle * 0.017453292f);
				return;
			}
			this.MaxAngleLateralLastPointsOfRanges(out worldStartPoint, out worldEndPoint, out worldNormal, out worldConePoint, out coneAngle, out worldConeMaxRadius);
			worldPointProyectedToEndStart = Math3d.ProjectPointOnLine(worldConePoint, worldEndPoint - worldConePoint, worldPoint);
			worldConeRadiusAtPoint = Vector3.Distance(worldConePoint, worldPointProyectedToEndStart) * Mathf.Tan(coneAngle * 0.017453292f);
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0002A078 File Offset: 0x00028278
		private bool TryGetRangesForWorldPoint(Vector3 worldPoint, Vector3 worldStartPoint, Vector3 worldEndPoint)
		{
			Vector3 vector = worldStartPoint - worldPoint;
			Vector3 vector2 = worldEndPoint - worldPoint;
			return Vector3.Dot(vector, vector2) <= 0f;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0002A0A4 File Offset: 0x000282A4
		public sealed override void OnUpdateEvent1()
		{
			this.OverrideConstantConfigToHole();
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0002A0AC File Offset: 0x000282AC
		public override void OnUpdateEvent6()
		{
			Vector3 vector = this.m_scaleModificador.ModificarValor(this.m_targetScale) * Vector3.one;
			if (!MathfExtension.AlmostEqual(vector, this.m_root.localScale, 0.001f))
			{
				this.m_root.localScale = vector;
			}
			this.m_worldScale = this.m_root.lossyScale.Escala();
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnDrawGizmosSelected()
		{
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0002A110 File Offset: 0x00028310
		public static void ResetScaleToStretchTo(StretchToPhysicsUserForSkeleton stretchTo, float vel, float2 defaultScaleXY)
		{
			Vector3 localScale = stretchTo.constrained.localScale;
			float num = Mathf.Lerp(stretchTo.userScaleX, defaultScaleXY.x, Time.fixedDeltaTime * vel);
			float num2 = Mathf.Lerp(stretchTo.userScaleY, defaultScaleXY.y, Time.fixedDeltaTime * vel);
			stretchTo.userScaleX = num;
			stretchTo.userScaleY = num2;
			stretchTo.constrained.localScale = new Vector3(num, num2, localScale.z);
			stretchTo.flagUpdateConfig = true;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0002A188 File Offset: 0x00028388
		public static void ResetScaleToStretchTo(Transform bone, float vel, float defaultScaleX = 1f, float defaultScaleY = 1f)
		{
			Vector3 localScale = bone.localScale;
			float num = Mathf.Lerp(localScale.x, defaultScaleX, Time.fixedDeltaTime * vel);
			float num2 = Mathf.Lerp(localScale.y, defaultScaleY, Time.fixedDeltaTime * vel);
			bone.localScale = new Vector3(num, num2, localScale.z);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0002A1D8 File Offset: 0x000283D8
		public static void SetScaleToStretchTo(HoleInternal internals, StretchToPhysicsUserForSkeleton stretchTo, HoleInternal.ConfigScale configScale, float2 defaultScaleXY)
		{
			Transform constrained = stretchTo.constrained;
			float num;
			float num2;
			float num3;
			if (!internals.CalcularEscalaDeBone(out num, out num2, out num3, stretchTo.constrained, configScale.escalaPorLocalPenisRadiusX, configScale.escalaPorLocalPenisRadiusY, configScale.penetrationInfluenceOutPower, defaultScaleXY.x, defaultScaleXY.y))
			{
				return;
			}
			stretchTo.userScaleX = num;
			stretchTo.userScaleY = num2;
			stretchTo.flagUpdateConfig = true;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0002A234 File Offset: 0x00028434
		public static void SetScaleToStretchTo(HoleInternal internals, Transform bone, HoleInternal.ConfigScale configScale)
		{
			float num;
			float num2;
			float num3;
			if (!internals.CalcularEscalaDeBone(out num, out num2, out num3, bone, configScale.escalaPorLocalPenisRadiusX, configScale.escalaPorLocalPenisRadiusY, configScale.penetrationInfluenceOutPower, configScale.defaultScaleX, configScale.defaultScaleY))
			{
				return;
			}
			float num4 = 1f;
			if (configScale.ignoreParentScale)
			{
				num4 = 1f / bone.parent.localScale.Escala();
				num4 = Mathf.Lerp(1f, num4, num3);
			}
			Vector3 localScale = bone.localScale;
			bone.localScale = new Vector3(num * num4, num2 * num4, localScale.z);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0002A2C4 File Offset: 0x000284C4
		public static void ProduceSetionPoints(List<HoleInternal.InternalPoint> puntos, HoleInternal.Seccion section)
		{
			for (int i = 0; i < section.bones.Count; i++)
			{
				Transform transform = section.bones[i];
				puntos.Add(new HoleInternal.InternalPoint(i)
				{
					punto = transform,
					root = section.root,
					config = section.config
				});
			}
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0002A320 File Offset: 0x00028520
		public static void ProduceSetionElasticPoints(List<HoleInternal.ElasticInternalPoint> puntos, HoleInternal.Seccion prevSection, HoleInternal.Seccion section, HoleInternal.Seccion nextSection, bool canChangePositionToProyectedPenisPosition)
		{
			for (int i = 0; i < section.bones.Count; i++)
			{
				Transform transform = section.bones[i];
				Transform transform2;
				if (!section.bones.ContieneIndex(i - 1))
				{
					if (prevSection == null)
					{
						transform2 = null;
					}
					else
					{
						List<Transform> bones = prevSection.bones;
						transform2 = ((bones != null) ? bones.LastOrDefault<Transform>() : null);
					}
				}
				else
				{
					transform2 = section.bones[i - 1];
				}
				Transform transform3 = transform2;
				Transform transform4;
				if (!section.bones.ContieneIndex(i + 1))
				{
					if (nextSection == null)
					{
						transform4 = null;
					}
					else
					{
						List<Transform> bones2 = nextSection.bones;
						transform4 = ((bones2 != null) ? bones2.FirstOrDefault<Transform>() : null);
					}
				}
				else
				{
					transform4 = section.bones[i + 1];
				}
				Transform transform5 = transform4;
				puntos.Add(new HoleInternal.ElasticInternalPoint(i)
				{
					punto = transform,
					root = section.root,
					previus = transform3,
					next = transform5,
					config = section.config,
					nextSmoothTimeMod = section.nextSmoothTimeMod,
					previusSmoothTimeMod = section.previusSmoothTimeMod,
					rootSmoothTimeMod = section.rootSmoothTimeMod,
					canChangePositionToProyectedPenisPosition = canChangePositionToProyectedPenisPosition
				});
			}
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0002A430 File Offset: 0x00028630
		public Vector3 ProyectTo(Vector3 worldPosition)
		{
			for (int i = this.elasticPuntos.Count - 1 - 1; i >= 0; i--)
			{
				HoleInternal.ElasticInternalPoint elasticInternalPoint = this.elasticPuntos[i];
				Transform transform = ((elasticInternalPoint.next != null) ? elasticInternalPoint.next : (this.elasticPuntos.ContieneIndexReadOnly(i + 1) ? this.elasticPuntos[i + 1].punto : null));
				if (!(transform == null))
				{
					Vector3 position = elasticInternalPoint.punto.position;
					Vector3 position2 = transform.position;
					Vector3 vector = Math3d.ProjectPointOnLine(position, position2 - position, worldPosition);
					if (Math3d.PointOnWhichSideOfLineSegment(position, position2, vector) == 0)
					{
						return Math3d.ProjectPointOnLine(position, (position2 - position).normalized, worldPosition);
					}
				}
			}
			return Math3d.ProjectPointOnLineSegment(this.elasticPuntos.First<HoleInternal.ElasticInternalPoint>().punto.position, this.elasticPuntos.Last<HoleInternal.ElasticInternalPoint>().punto.position, worldPosition);
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0002A52A File Offset: 0x0002872A
		public float internalsWorldScale
		{
			get
			{
				return this.m_internalsWorldScale;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0002A532 File Offset: 0x00028732
		public IReadOnlyList<HoleInternal.ElasticInternalPoint> elasticPuntos
		{
			get
			{
				return this.m_ElasticPuntos;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0002A53A File Offset: 0x0002873A
		public IReadOnlyDictionary<Transform, HoleInternal.InternalPoint> allPuntosDicc
		{
			get
			{
				return this.m_AllPuntosDicc;
			}
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0002A542 File Offset: 0x00028742
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_solver.Add(this);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0002A556 File Offset: 0x00028756
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_solver.Remove(this);
		}

		// Token: 0x06000989 RID: 2441
		protected abstract void ProducePoints(List<HoleInternal.InternalPoint> puntos);

		// Token: 0x0600098A RID: 2442
		protected abstract void ProduceElasticPoints(List<HoleInternal.ElasticInternalPoint> puntos);

		// Token: 0x0600098B RID: 2443 RVA: 0x0002A56B File Offset: 0x0002876B
		public void PreSolving()
		{
			this.m_internalsWorldScale = this.m_root.lossyScale.Escala();
			this.FixRotations();
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0002A589 File Offset: 0x00028789
		public void PostSolve()
		{
			this.AfterElasticLoops();
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0002A594 File Offset: 0x00028794
		protected virtual void FixRotations()
		{
			for (int i = 0; i < this.m_puntos.Count; i++)
			{
				HoleInternal.InternalPoint internalPoint = this.m_puntos[i];
				if (internalPoint.fixRotation)
				{
					internalPoint.ResetRotation();
				}
			}
			for (int j = 0; j < this.m_ElasticPuntos.Count; j++)
			{
				HoleInternal.ElasticInternalPoint elasticInternalPoint = this.m_ElasticPuntos[j];
				if (elasticInternalPoint.fixRotation)
				{
					elasticInternalPoint.ResetRotation();
				}
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AfterElasticLoops()
		{
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0002A603 File Offset: 0x00028803
		public void SolvePuntoPenetration()
		{
			this.SolvePuntoPenetration(this.m_puntos, 10f, false, 1);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0002A618 File Offset: 0x00028818
		public void SolveElasticPuntoPenetration(int loopsTotalCount)
		{
			this.SolvePuntoPenetration(this.m_ElasticPuntos, 2f, true, loopsTotalCount);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0002A630 File Offset: 0x00028830
		private void SolvePuntoPenetration(IReadOnlyList<HoleInternal.InternalPoint> puntos, float restoreVel, bool changePositionToProyectedPenisPosition, int loopsTotalCount)
		{
			for (int i = 0; i < puntos.Count; i++)
			{
				HoleInternal.InternalPoint internalPoint = puntos[i];
				internalPoint.penetrationInfluenceW = Mathf.Lerp(internalPoint.penetrationInfluenceW, 0f, Time.fixedDeltaTime * restoreVel / (float)loopsTotalCount);
				internalPoint.penetrationWorldRadius = Mathf.Lerp(internalPoint.penetrationWorldRadius, internalPoint.config.defaultLocalRadiusV2 * internalPoint.owner.m_worldScale * (1f + (float)internalPoint.sectionIndex * internalPoint.config.localRadiusIncreaseByIndex), Time.fixedDeltaTime * restoreVel / (float)loopsTotalCount);
			}
			if (this.m_hole.isPenetrated)
			{
				IPene pene = this.m_hole.PenetradoPor();
				for (int j = 0; j < puntos.Count; j++)
				{
					HoleInternal.InternalPoint internalPoint2 = puntos[j];
					Vector3 vector;
					Vector3 vector2;
					float num;
					float num2;
					if (internalPoint2.TryGetPenetrationData(this.m_hole, pene, this.m_hole.entrada.position, out vector, out vector2, out num, out num2, internalPoint2.debugDraw, 1.333f))
					{
						internalPoint2.penetrationInfluenceW = num;
						internalPoint2.penetrationWorldRadius = num2;
						if (internalPoint2.canChangePositionToProyectedPenisPosition && changePositionToProyectedPenisPosition)
						{
							internalPoint2.UpdatePenetrationPosition(vector);
						}
					}
				}
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0002A758 File Offset: 0x00028958
		public bool CalcularEscalaDeBone(out float scaleX, out float scaleY, out float penetrationInfluenceW, Transform puntoBone, float escalaPorLocalPenisRadiusX, float escalaPorLocalPenisRadiusY, float penetrationInfluenceOutPower, float defaultScaleX = 1f, float defaultScaleY = 1f)
		{
			penetrationInfluenceW = 0f;
			scaleX = defaultScaleX;
			scaleY = defaultScaleY;
			HoleInternal.InternalPoint internalPoint;
			if (!this.m_AllPuntosDicc.TryGetValue(puntoBone, out internalPoint) || internalPoint.penetrationInfluenceW <= 0f)
			{
				return false;
			}
			penetrationInfluenceW = internalPoint.penetrationInfluenceW.OutPow(penetrationInfluenceOutPower);
			float num = internalPoint.penetrationWorldRadius / this.m_worldScale;
			float num2 = num * escalaPorLocalPenisRadiusX;
			float num3 = num * escalaPorLocalPenisRadiusY;
			scaleX = Mathf.Lerp(defaultScaleX, num2, penetrationInfluenceW);
			scaleY = Mathf.Lerp(defaultScaleY, num3, penetrationInfluenceW);
			return true;
		}

		// Token: 0x04000749 RID: 1865
		public const float restoreVelocitySlow = 2f;

		// Token: 0x0400074A RID: 1866
		public const float restoreVelocityFast = 10f;

		// Token: 0x0400074B RID: 1867
		[SerializeField]
		protected BoneStretchedChain m_hole;

		// Token: 0x0400074C RID: 1868
		[SerializeField]
		protected Transform m_root;

		// Token: 0x0400074D RID: 1869
		[SerializeField]
		protected SkinnedMeshRenderer m_SkinnedMeshRenderer;

		// Token: 0x0400074E RID: 1870
		[SerializeField]
		protected ConstrainedSkeleton m_ConstrainedSkeleton;

		// Token: 0x0400074F RID: 1871
		[SerializeField]
		private float m_targetScale = 1f;

		// Token: 0x04000750 RID: 1872
		[SerializeField]
		[ReadOnlyUI]
		protected float m_worldScale = 1f;

		// Token: 0x04000751 RID: 1873
		[SerializeField]
		[ReadOnlyUI]
		protected HoleInternalSkin m_skin;

		// Token: 0x04000752 RID: 1874
		[SerializeField]
		private ModificableDeFloat m_scaleModificador = new ModificableDeFloat(1f);

		// Token: 0x04000753 RID: 1875
		[TupleElementNames(new string[] { "start", "end", "radius" })]
		private List<ValueTuple<Vector3, Vector3, float>> m_overridingCastingTrayectos = new List<ValueTuple<Vector3, Vector3, float>>();

		// Token: 0x04000754 RID: 1876
		private PenetrationJointCreator.GetConeTrayecotiaDataForDriverConfigHandler m_driverDataConfigHandler;

		// Token: 0x04000755 RID: 1877
		[Header("Puntos")]
		public float maxWidthInfluenceW = 0.333f;

		// Token: 0x04000756 RID: 1878
		[SerializeField]
		private List<HoleInternal.InternalPoint> m_puntos;

		// Token: 0x04000757 RID: 1879
		[SerializeField]
		private List<HoleInternal.ElasticInternalPoint> m_ElasticPuntos;

		// Token: 0x04000758 RID: 1880
		protected Dictionary<Transform, HoleInternal.InternalPoint> m_AllPuntosDicc;

		// Token: 0x04000759 RID: 1881
		private HoleInternalPointsSolver m_solver;

		// Token: 0x0400075A RID: 1882
		protected float m_internalsWorldScale = 1f;

		// Token: 0x02000193 RID: 403
		[Serializable]
		public class ConfigLateral
		{
			// Token: 0x0400075B RID: 1883
			public float maxAngle1;

			// Token: 0x0400075C RID: 1884
			public float point1Retroceso;
		}

		// Token: 0x02000194 RID: 404
		[Serializable]
		public class ConfigPenetration
		{
			// Token: 0x0400075D RID: 1885
			public float maxPuntaPenetrationV2 = 0.6666f;

			// Token: 0x0400075E RID: 1886
			public float maxPuntaPenetrationInPower = 2f;

			// Token: 0x0400075F RID: 1887
			public float defaultLocalRadiusV2 = 0.01f;

			// Token: 0x04000760 RID: 1888
			public float localRadiusIncreaseByIndex;
		}

		// Token: 0x02000195 RID: 405
		[Serializable]
		public class Seccion
		{
			// Token: 0x04000761 RID: 1889
			public HoleInternal.ConfigPenetration config = new HoleInternal.ConfigPenetration();

			// Token: 0x04000762 RID: 1890
			public Transform root;

			// Token: 0x04000763 RID: 1891
			public List<Transform> bones = new List<Transform>();

			// Token: 0x04000764 RID: 1892
			public float rootSmoothTimeMod = 1f;

			// Token: 0x04000765 RID: 1893
			public float previusSmoothTimeMod = 1f;

			// Token: 0x04000766 RID: 1894
			public float nextSmoothTimeMod = 1f;
		}

		// Token: 0x02000196 RID: 406
		[Serializable]
		public class InternalPoint
		{
			// Token: 0x06000997 RID: 2455 RVA: 0x0002A896 File Offset: 0x00028A96
			public InternalPoint()
			{
			}

			// Token: 0x06000998 RID: 2456 RVA: 0x0002A8A5 File Offset: 0x00028AA5
			public InternalPoint(int SectionIndex)
			{
				this.sectionIndex = SectionIndex;
			}

			// Token: 0x1700021C RID: 540
			// (get) Token: 0x06000999 RID: 2457 RVA: 0x0002A8BB File Offset: 0x00028ABB
			public HoleInternal owner
			{
				get
				{
					return this.m_owner;
				}
			}

			// Token: 0x0600099A RID: 2458 RVA: 0x0002A8C3 File Offset: 0x00028AC3
			public void Init(HoleInternal Owner, int Index)
			{
				this.m_owner = Owner;
				this.index = Index;
			}

			// Token: 0x0600099B RID: 2459 RVA: 0x0002A8D4 File Offset: 0x00028AD4
			public virtual void UpdateDefaults(Transform holeInternalRoot)
			{
				this.penetrationInfluenceW = 0f;
				this.penetrationWorldRadius = this.config.defaultLocalRadiusV2 * this.m_owner.m_worldScale * (1f + (float)this.sectionIndex * this.config.localRadiusIncreaseByIndex);
				this.defaultRotationFromRoot = Quaternion.Inverse(this.root.rotation) * this.punto.rotation;
				this.defaultPositionFromRoot = this.root.InverseTransformPoint(this.punto.position);
			}

			// Token: 0x0600099C RID: 2460 RVA: 0x0002A965 File Offset: 0x00028B65
			public void ResetRotation()
			{
				this.punto.rotation = this.root.rotation * this.defaultRotationFromRoot;
			}

			// Token: 0x0600099D RID: 2461 RVA: 0x0002A988 File Offset: 0x00028B88
			public bool TryGetPenetrationData(BoneStretchedChain hole, IPene penetrator, Vector3 holeEntrataWPos, out Vector3 ProyectedToPenisPosition, out Vector3 penetratorTipWPos, out float penetrationW, out float penetrationRadius, bool debugDraw, float lengthBonusAPuntaMod = 1.333f)
			{
				penetratorTipWPos = (ProyectedToPenisPosition = Vector3.zero);
				penetrationW = 0f;
				penetrationRadius = 0f;
				Vector3 vector;
				Vector3 vector2;
				Vector3 vector3;
				penetrator.GetPuntaStartTipWorldPositions(lengthBonusAPuntaMod, out vector, out vector2, out vector3);
				Vector3 vector4 = this.root.TransformPoint(this.defaultPositionFromRoot);
				Vector3 vector5 = Math3d.ProjectPointOnLine(vector2, vector3, vector4);
				Vector3 vector6 = vector2 - vector5;
				bool flag = Vector3.Dot(holeEntrataWPos - vector5, vector6) < 0f;
				if (flag)
				{
					float num = penetrator.worldMaxWidth / 2f;
					Vector3 vector7;
					Vector3 vector8;
					float num3;
					IPeneParte peneParte;
					int num2 = penetrator.PuntaPenetration(vector5, lengthBonusAPuntaMod, out penetratorTipWPos, out vector7, out vector8, out num3, out peneParte);
					if (num2 == 2)
					{
						penetrationW = 0f;
						penetrationRadius = ((peneParte != null) ? Mathf.Lerp(peneParte.maxWorldRadius, num, this.owner.maxWidthInfluenceW) : num);
						flag = false;
					}
					else if (num2 == 0 && num3 < this.config.maxPuntaPenetrationV2)
					{
						penetrationW = Mathf.InverseLerp(0f, this.config.maxPuntaPenetrationV2, num3);
						penetrationRadius = ((peneParte != null) ? Mathf.Lerp(peneParte.maxWorldRadius, num, this.owner.maxWidthInfluenceW) : num);
						ProyectedToPenisPosition = vector8;
					}
					else
					{
						IPeneParte peneParte2;
						ProyectedToPenisPosition = penetrator.ProyectTo(vector5, out peneParte2);
						penetrationW = 1f;
						penetrationRadius = ((peneParte2 != null) ? Mathf.Lerp(peneParte2.maxWorldRadius, num, this.owner.maxWidthInfluenceW) : num);
					}
				}
				return flag;
			}

			// Token: 0x0600099E RID: 2462 RVA: 0x0002AB0B File Offset: 0x00028D0B
			public void UpdatePenetrationPosition(Vector3 ProyectedToPenisPosition)
			{
				this.punto.position = Vector3.Lerp(this.punto.position, ProyectedToPenisPosition, this.penetrationInfluenceW.InPow(this.config.maxPuntaPenetrationInPower));
			}

			// Token: 0x0600099F RID: 2463 RVA: 0x0002AB40 File Offset: 0x00028D40
			public void ForzeUpdatePositionByPenetration(BoneStretchedChain hole)
			{
				Vector3 vector = this.root.TransformPoint(this.defaultPositionFromRoot);
				this.punto.position = Vector3.Lerp(this.punto.position, vector, Time.fixedDeltaTime * 10f);
				if (hole.isPenetrated)
				{
					IPene pene = hole.PenetradoPor();
					Vector3 vector2;
					Vector3 vector3;
					float num;
					float num2;
					if (this.TryGetPenetrationData(hole, pene, hole.entrada.position, out vector2, out vector3, out num, out num2, this.debugDraw, 1.333f))
					{
						this.UpdatePenetrationPosition(vector2);
					}
				}
			}

			// Token: 0x060009A0 RID: 2464 RVA: 0x0002ABC4 File Offset: 0x00028DC4
			public void ForzeUpdatePositionByPenetrationTip(BoneStretchedChain hole)
			{
				Vector3 vector = this.root.TransformPoint(this.defaultPositionFromRoot);
				this.punto.position = Vector3.Lerp(this.punto.position, vector, Time.fixedDeltaTime * 10f);
				if (hole.isPenetrated)
				{
					IPene pene = hole.PenetradoPor();
					Vector3 vector2;
					Vector3 vector3;
					float num;
					float num2;
					if (this.TryGetPenetrationData(hole, pene, hole.entrada.position, out vector2, out vector3, out num, out num2, this.debugDraw, 1f))
					{
						this.UpdatePenetrationPosition(vector3);
					}
				}
			}

			// Token: 0x04000767 RID: 1895
			protected HoleInternal m_owner;

			// Token: 0x04000768 RID: 1896
			public int index;

			// Token: 0x04000769 RID: 1897
			public int sectionIndex;

			// Token: 0x0400076A RID: 1898
			public HoleInternal.ConfigPenetration config;

			// Token: 0x0400076B RID: 1899
			public bool debugDraw;

			// Token: 0x0400076C RID: 1900
			public bool fixRotation = true;

			// Token: 0x0400076D RID: 1901
			public bool canChangePositionToProyectedPenisPosition;

			// Token: 0x0400076E RID: 1902
			public Transform punto;

			// Token: 0x0400076F RID: 1903
			public Transform root;

			// Token: 0x04000770 RID: 1904
			public Quaternion defaultRotationFromRoot;

			// Token: 0x04000771 RID: 1905
			public Vector3 defaultPositionFromRoot;

			// Token: 0x04000772 RID: 1906
			public float penetrationInfluenceW;

			// Token: 0x04000773 RID: 1907
			public float penetrationWorldRadius;
		}

		// Token: 0x02000197 RID: 407
		[Serializable]
		public class ElasticInternalPoint : HoleInternal.InternalPoint, SistemaLocalDePuntosElasticosDeInternal.IUser, IUserDeSystemaLocal<SistemaLocalDePuntosElasticosDeInternal>, IUserDeSystema<SistemaLocalDePuntosElasticosDeInternal>, IUserDeSystema, IUserDeSystemaLocal
		{
			// Token: 0x060009A1 RID: 2465 RVA: 0x0002AC48 File Offset: 0x00028E48
			public ElasticInternalPoint()
			{
			}

			// Token: 0x060009A2 RID: 2466 RVA: 0x0002AC71 File Offset: 0x00028E71
			public ElasticInternalPoint(int SectionIndex)
				: base(SectionIndex)
			{
			}

			// Token: 0x060009A3 RID: 2467 RVA: 0x0002AC9C File Offset: 0x00028E9C
			public override void UpdateDefaults(Transform holeInternalRoot)
			{
				base.UpdateDefaults(holeInternalRoot);
				this.defaultPositionFromPrevius = (this.previus ? this.previus.InverseTransformPointUnscaled(holeInternalRoot, this.punto.position) : Vector3.zero);
				this.defaultPositionFromNext = (this.next ? this.next.InverseTransformPointUnscaled(holeInternalRoot, this.punto.position) : Vector3.zero);
				this.usaPrev = this.previus != null;
				this.usaNext = this.next != null;
				this.m_instanceID = this.punto.GetInstanceID();
			}

			// Token: 0x060009A4 RID: 2468 RVA: 0x0002AD48 File Offset: 0x00028F48
			public void SolveElasticToPrevius(HoleInternalPointsSolver.ConfigElastic config, int loopsTotalCount)
			{
				if (this.usaPrev)
				{
					HoleInternal.ElasticInternalPoint.SolveElasticTo(this.punto, this.previus, this.m_owner.root, ref this.currentPositionFromPrevius, this.defaultPositionFromPrevius, ref this.m_previusVel, false, config.previusSmoothTime * this.previusSmoothTimeMod, loopsTotalCount, this.debugDraw, Color.red);
				}
			}

			// Token: 0x060009A5 RID: 2469 RVA: 0x0002ADA8 File Offset: 0x00028FA8
			public void SolveElasticToNext(HoleInternalPointsSolver.ConfigElastic config, int loopsTotalCount)
			{
				if (this.usaNext)
				{
					HoleInternal.ElasticInternalPoint.SolveElasticTo(this.punto, this.next, this.m_owner.root, ref this.currentPositionFromNext, this.defaultPositionFromNext, ref this.m_nextVel, false, config.nextSmoothTime * this.nextSmoothTimeMod, loopsTotalCount, this.debugDraw, Color.blue);
				}
			}

			// Token: 0x060009A6 RID: 2470 RVA: 0x0002AE08 File Offset: 0x00029008
			public void SolveElasticToRoot(HoleInternalPointsSolver.ConfigElastic config, int loopsTotalCount)
			{
				HoleInternal.ElasticInternalPoint.SolveElasticTo(this.punto, this.root, this.m_owner.root, ref this.currentPositionFromRoot, this.defaultPositionFromRoot, ref this.m_rootVel, true, config.rootSmoothTime * this.rootSmoothTimeMod, loopsTotalCount, this.debugDraw, Color.yellow);
			}

			// Token: 0x060009A7 RID: 2471 RVA: 0x0002AE60 File Offset: 0x00029060
			private static void SolveElasticTo(Transform self, Transform other, Transform holeInternalRoot, ref Vector3 currentPos, Vector3 defaultPos, ref Vector3 currentVelocity, bool esRoot, float elasticSmoothTime, int loopsTotalCount, bool debugDraw, Color debugDrawColor)
			{
				if (elasticSmoothTime < 0f)
				{
					return;
				}
				currentPos = (esRoot ? other.InverseTransformPoint(self.position) : other.InverseTransformPointUnscaled(holeInternalRoot, self.position));
				currentPos = Vector3.SmoothDamp(currentPos, defaultPos, ref currentVelocity, elasticSmoothTime, float.PositiveInfinity, Time.fixedDeltaTime / (float)loopsTotalCount);
				self.position = (esRoot ? other.TransformPoint(currentPos) : other.TransformPointUnscaled(holeInternalRoot, currentPos));
				if (debugDraw)
				{
					if (!esRoot)
					{
						other.TransformPointUnscaled(holeInternalRoot, defaultPos);
						return;
					}
					other.TransformPoint(defaultPos);
				}
			}

			// Token: 0x1700021D RID: 541
			// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0002AF02 File Offset: 0x00029102
			int IUserDeSystema.instanceID
			{
				get
				{
					return this.m_instanceID;
				}
			}

			// Token: 0x1700021E RID: 542
			// (get) Token: 0x060009A9 RID: 2473 RVA: 0x0002AF0A File Offset: 0x0002910A
			float SistemaLocalDePuntosElasticosDeInternal.IUser.worldRadius
			{
				get
				{
					return this.penetrationWorldRadius;
				}
			}

			// Token: 0x1700021F RID: 543
			// (get) Token: 0x060009AA RID: 2474 RVA: 0x00005F51 File Offset: 0x00004151
			// (set) Token: 0x060009AB RID: 2475 RVA: 0x00005A42 File Offset: 0x00003C42
			public bool enabled
			{
				get
				{
					return true;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x060009AC RID: 2476 RVA: 0x0002AF14 File Offset: 0x00029114
			void IUserDeSystema<SistemaLocalDePuntosElasticosDeInternal>.Scheduling(SistemaLocalDePuntosElasticosDeInternal system, bool firstSchedulingForUser)
			{
				if (firstSchedulingForUser)
				{
					system.UpdateInitialData(this, base.owner, this.root, this.previus, this.punto, this.next, this.defaultPositionFromRoot, this.defaultPositionFromPrevius, this.defaultPositionFromNext);
				}
				system.UpdateConfigData(this, this.previusSmoothTimeMod, this.nextSmoothTimeMod, this.rootSmoothTimeMod);
			}

			// Token: 0x060009AD RID: 2477 RVA: 0x00003B39 File Offset: 0x00001D39
			void IUserDeSystema<SistemaLocalDePuntosElasticosDeInternal>.Completed(SistemaLocalDePuntosElasticosDeInternal system)
			{
			}

			// Token: 0x060009AE RID: 2478 RVA: 0x00003B39 File Offset: 0x00001D39
			void IUserDeSystemaLocal.OnSystemaDisabled()
			{
			}

			// Token: 0x060009AF RID: 2479 RVA: 0x00003B39 File Offset: 0x00001D39
			void IUserDeSystemaLocal.OnSystemaReEnabled()
			{
			}

			// Token: 0x060009B0 RID: 2480 RVA: 0x00003B39 File Offset: 0x00001D39
			void IUserDeSystemaLocal.OnSystemaDestroyed()
			{
			}

			// Token: 0x04000774 RID: 1908
			public Transform previus;

			// Token: 0x04000775 RID: 1909
			public bool usaPrev;

			// Token: 0x04000776 RID: 1910
			public Vector3 defaultPositionFromPrevius;

			// Token: 0x04000777 RID: 1911
			public Vector3 currentPositionFromPrevius;

			// Token: 0x04000778 RID: 1912
			public Transform next;

			// Token: 0x04000779 RID: 1913
			public bool usaNext;

			// Token: 0x0400077A RID: 1914
			public Vector3 defaultPositionFromNext;

			// Token: 0x0400077B RID: 1915
			public Vector3 currentPositionFromNext;

			// Token: 0x0400077C RID: 1916
			public Vector3 currentPositionFromRoot;

			// Token: 0x0400077D RID: 1917
			private Vector3 m_rootVel;

			// Token: 0x0400077E RID: 1918
			private Vector3 m_previusVel;

			// Token: 0x0400077F RID: 1919
			private Vector3 m_nextVel;

			// Token: 0x04000780 RID: 1920
			public float rootSmoothTimeMod = 1f;

			// Token: 0x04000781 RID: 1921
			public float previusSmoothTimeMod = 1f;

			// Token: 0x04000782 RID: 1922
			public float nextSmoothTimeMod = 1f;

			// Token: 0x04000783 RID: 1923
			private int m_instanceID;

			// Token: 0x04000784 RID: 1924
			private static ProfilerMarker SmoothDampMarker = new ProfilerMarker("ElasticInternalPoint.SmoothDamp");

			// Token: 0x04000785 RID: 1925
			private static ProfilerMarker CurrentPosMarker = new ProfilerMarker("ElasticInternalPoint.CurrentPos");

			// Token: 0x04000786 RID: 1926
			private static ProfilerMarker SelfPositionMarker = new ProfilerMarker("ElasticInternalPoint.SelfPosition");
		}

		// Token: 0x02000198 RID: 408
		[Serializable]
		public class ConfigScale
		{
			// Token: 0x04000787 RID: 1927
			public float defaultScaleX = 1f;

			// Token: 0x04000788 RID: 1928
			public float defaultScaleY = 1f;

			// Token: 0x04000789 RID: 1929
			public float escalaPorLocalPenisRadiusX = 1f;

			// Token: 0x0400078A RID: 1930
			public float escalaPorLocalPenisRadiusY = 1f;

			// Token: 0x0400078B RID: 1931
			public float penetrationInfluenceOutPower = 1f;

			// Token: 0x0400078C RID: 1932
			public bool ignoreParentScale;
		}
	}
}
