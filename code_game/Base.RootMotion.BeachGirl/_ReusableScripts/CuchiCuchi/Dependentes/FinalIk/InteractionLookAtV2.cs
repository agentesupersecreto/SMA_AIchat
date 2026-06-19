using System;
using Assets.FinalIk;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200006E RID: 110
	[Serializable]
	public sealed class InteractionLookAtV2 : InteractionLookAt
	{
		// Token: 0x06000445 RID: 1093 RVA: 0x00014354 File Offset: 0x00012554
		public InteractionLookAtV2(InteractionLookAt old, ILookAtIK manager, OjosLookAtManager ojosManager, int slotIndex)
		{
			this.ik = manager.mainLookAtIK;
			this.lerpSpeed = old.lerpSpeed;
			this.weightSpeed = old.weightSpeed;
			if (this.weightSpeed <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (manager == null)
			{
				throw new ArgumentNullException("manager", "manager null reference.");
			}
			if (ojosManager == null)
			{
				throw new ArgumentNullException("ojosManager", "ojosManager null reference.");
			}
			this.m_manager = manager;
			this.m_ojosManager = ojosManager;
			this.slotTargetIndex = slotIndex;
			if (this.slotTargetIndex < 0)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x000143F0 File Offset: 0x000125F0
		public override void Look(Transform target, float time)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			this.lookAtTarget = target;
			this.stopLookTime = time;
			if (this.debugLog)
			{
				Debug.Log(this.lookAtTarget.name + " comenzando a mirar con tiempo de ejecucion de: " + (this.stopLookTime - Time.time).ToString(), (Object)this.m_manager);
			}
			if (Time.time >= this.stopLookTime)
			{
				if (Application.isEditor)
				{
					Debug.Break();
				}
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00014484 File Offset: 0x00012684
		public override void Update()
		{
			LookAtTargetWieghtPar lookAtTargetWieghtPar = this.m_manager.targets.segundarios.ObtenerSlot(this.slotTargetIndex);
			LookAtTargetWieghtPar lookAtTargetWieghtPar2 = this.m_ojosManager.segundarios.ObtenerSlot(this.slotTargetIndex);
			try
			{
				if (this.m_manager != null)
				{
					if (!(this.m_ojosManager == null))
					{
						if (!(this.lookAtTarget == null))
						{
							if (this.isPaused)
							{
								this.stopLookTime += Time.deltaTime;
							}
							float num = ((Time.time < this.stopLookTime) ? this.weightSpeed : (-this.weightSpeed));
							this.weight = Mathf.Clamp(this.weight + num * Time.deltaTime, 0f, 1f);
							if (Time.time < this.stopLookTime)
							{
								this.weight = Mathf.Clamp(this.weight, 0.0001f, 1f);
							}
							lookAtTargetWieghtPar.weight = (lookAtTargetWieghtPar2.weight = Interp.Float(this.weight, InterpolationMode.InOutQuintic));
							lookAtTargetWieghtPar.LookAtTarget.Set(this.lookAtTarget.position);
							lookAtTargetWieghtPar.LookAtTarget.config.lookAtVelocityMod = this.lerpSpeed;
							lookAtTargetWieghtPar.LookAtTarget.config.usarMaxAngleDeVision = false;
							lookAtTargetWieghtPar2.LookAtTarget.Set(this.lookAtTarget.position);
							lookAtTargetWieghtPar2.LookAtTarget.config.lookAtVelocityMod = this.lerpSpeed;
							lookAtTargetWieghtPar2.LookAtTarget.config.usarMaxAngleDeVision = false;
							if (this.weight <= 0f)
							{
								if (Time.time < this.stopLookTime)
								{
									Debug.LogWarning(this.lookAtTarget.name + " liberado. antes de tiempo", (Object)this.m_manager);
								}
								if (this.debugLog)
								{
									Debug.Log(this.lookAtTarget.name + " liberado.", (Object)this.m_manager);
								}
								this.lookAtTarget = null;
							}
							this.firstFBBIKSolve = true;
						}
					}
				}
			}
			finally
			{
				if (this.lookAtTarget == null)
				{
					lookAtTargetWieghtPar.LookAtTarget.config.lookAtVelocityMod = 1f;
					lookAtTargetWieghtPar.weight = 0f;
					lookAtTargetWieghtPar.LookAtTarget.Clear();
					lookAtTargetWieghtPar2.LookAtTarget.config.lookAtVelocityMod = 1f;
					lookAtTargetWieghtPar2.weight = 0f;
					lookAtTargetWieghtPar2.LookAtTarget.Clear();
				}
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0001470C File Offset: 0x0001290C
		public Transform ObtenerElLookAtTargetActual()
		{
			return this.lookAtTarget;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00014714 File Offset: 0x00012914
		public override void SolveHead()
		{
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00014716 File Offset: 0x00012916
		public override void SolveSpine()
		{
		}

		// Token: 0x040002D5 RID: 725
		public bool debugLog;

		// Token: 0x040002D6 RID: 726
		private ILookAtIK m_manager;

		// Token: 0x040002D7 RID: 727
		private OjosLookAtManager m_ojosManager;

		// Token: 0x040002D8 RID: 728
		[SerializeField]
		private int slotTargetIndex;
	}
}
