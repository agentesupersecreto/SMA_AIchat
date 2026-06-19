using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers
{
	// Token: 0x020000F5 RID: 245
	public class InteraccionCheckCollider : InteraccionChecker
	{
		// Token: 0x06000929 RID: 2345 RVA: 0x00029A7F File Offset: 0x00027C7F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_colliderEsValido = new Func<Collider, bool>(this.ColliderEsValido);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00029A99 File Offset: 0x00027C99
		private bool ColliderEsValido(Collider hitted)
		{
			return !base.currentCharacter.ObjetoMePertenece(hitted.transform);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00029AB0 File Offset: 0x00027CB0
		public override bool DoCheck()
		{
			Transform transform;
			Vector3 vector;
			return this.DoCheck(out transform, out vector);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00029AC8 File Offset: 0x00027CC8
		public override bool DoCheck(out Transform obstacle, out Vector3 worldPosition)
		{
			this.m_currentPuppetMaster = base.currentCharacter.GetComponentEnRoot<PuppetMaster>();
			if (this.m_currentPuppetMaster == null)
			{
				throw new ArgumentNullException("m_currentPuppetMaster", "m_currentPuppetMaster null reference.");
			}
			for (int i = 0; i < this.m_Interaccion.datosDeParesDeEfecctors.effectorsInteractions.Count; i++)
			{
				InteraccionEffectorParInfo interaccionEffectorParInfo = this.m_Interaccion.datosDeParesDeEfecctors.effectorsInteractions[i];
				if (interaccionEffectorParInfo.activado && interaccionEffectorParInfo.isValid && this.CheckObj(interaccionEffectorParInfo.interactionObject, out obstacle, out worldPosition))
				{
					return true;
				}
			}
			obstacle = null;
			worldPosition = Vector3.zero;
			return false;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00029B6C File Offset: 0x00027D6C
		private bool CheckObj(InteractionObjectV2Base obj, out Transform obstacle, out Vector3 worldPosition)
		{
			if (obj == null)
			{
				obstacle = null;
				worldPosition = Vector3.zero;
				return false;
			}
			int layerMask = this.checking.GetLayerMask(this.extraLayerMask);
			InteractionTarget[] targets = obj.GetTargets();
			InteractionTargetTValle[] customTargets = obj.GetCustomTargets();
			foreach (InteractionTarget interactionTarget in targets)
			{
				bool flag = this.debugDraw;
				Collider collider;
				if (this.effectorsToCheck.Contains(interactionTarget.effectorType) && this.Check(interactionTarget.transform, interactionTarget.effectorType, layerMask, out collider))
				{
					obstacle = collider.transform;
					worldPosition = collider.transform.position;
					return true;
				}
			}
			foreach (InteractionTargetTValle interactionTargetTValle in customTargets)
			{
				bool flag2 = this.debugDraw;
				Collider collider2;
				if (this.customEffectorsToCheck.Contains(interactionTargetTValle.effectorType) && this.Check(interactionTargetTValle.transform, interactionTargetTValle.effectorType, layerMask, out collider2))
				{
					obstacle = collider2.transform;
					worldPosition = collider2.transform.position;
					return true;
				}
			}
			obstacle = null;
			worldPosition = Vector3.zero;
			return false;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00029C94 File Offset: 0x00027E94
		private bool Check(Transform target, CustomBipedEffector effector, int layerMask, out Collider hitted)
		{
			HumanBodyBones humanBodyBones = effector.ParceAHumanBone();
			return this.Check(target, humanBodyBones, layerMask, out hitted);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00029CB4 File Offset: 0x00027EB4
		private bool Check(Transform target, FullBodyBipedEffector effector, int layerMask, out Collider hitted)
		{
			HumanBodyBones humanBodyBones = effector.ParceAHumanBone();
			return this.Check(target, humanBodyBones, layerMask, out hitted);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00029CD4 File Offset: 0x00027ED4
		private bool Check(Transform target, HumanBodyBones humanBodyBones, int layerMask, out Collider hitted)
		{
			bool flag = base.currentCharacter.bones.Obtener(humanBodyBones) != null;
			Muscle muscle = this.m_currentPuppetMaster.GetMuscle(humanBodyBones);
			if (!flag)
			{
				throw new ArgumentNullException("data", "data null reference.");
			}
			if (muscle == null)
			{
				Debug.LogError("No se encontro musculo de HumanBodyBones: " + humanBodyBones.ToString(), this);
				hitted = null;
				return false;
			}
			return InteraccionChecker.CheckCollider(muscle.colliders[0], target, layerMask, QueryTriggerInteraction.Ignore, this.m_colliderEsValido, out hitted, this.radiusMod, this.debugDraw);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00029D5C File Offset: 0x00027F5C
		[Obsolete("", true)]
		private static bool Check(Vector3 position, float radius, int layerMask, bool debugDraw)
		{
			bool flag = Physics.CheckSphere(position, radius, layerMask, QueryTriggerInteraction.Ignore);
			if (debugDraw)
			{
			}
			return flag;
		}

		// Token: 0x040005BE RID: 1470
		private PuppetMaster m_currentPuppetMaster;

		// Token: 0x040005BF RID: 1471
		public float radiusMod = 0.5f;

		// Token: 0x040005C0 RID: 1472
		public bool debugDraw;

		// Token: 0x040005C1 RID: 1473
		public List<FullBodyBipedEffector> effectorsToCheck = new List<FullBodyBipedEffector>
		{
			FullBodyBipedEffector.Body,
			FullBodyBipedEffector.LeftShoulder,
			FullBodyBipedEffector.RightShoulder,
			FullBodyBipedEffector.LeftThigh,
			FullBodyBipedEffector.RightThigh
		};

		// Token: 0x040005C2 RID: 1474
		public List<CustomBipedEffector> customEffectorsToCheck = new List<CustomBipedEffector> { CustomBipedEffector.head };

		// Token: 0x040005C3 RID: 1475
		private Func<Collider, bool> m_colliderEsValido;
	}
}
