using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.Globales.Updater;
using com.ootii.Actors;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020001A6 RID: 422
	public sealed class PelvisMovementController : AplicableBehaviour
	{
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x00031A4D File Offset: 0x0002FC4D
		public override int updateEvent1Index
		{
			get
			{
				return (int)this.m_updateEvent;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x00031A55 File Offset: 0x0002FC55
		public PelvisMovementController.Range zRange
		{
			get
			{
				return this.m_zRange;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x00031A5D File Offset: 0x0002FC5D
		public PelvisMovementController.Range yRange
		{
			get
			{
				return this.m_yRange;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x00031A65 File Offset: 0x0002FC65
		public PelvisMovementController.Range xRange
		{
			get
			{
				return this.m_xRange;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x00031A6D File Offset: 0x0002FC6D
		public Vector3 currentLocalTarget
		{
			get
			{
				return this.m_currentLocalTarget;
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060009F9 RID: 2553 RVA: 0x00031A78 File Offset: 0x0002FC78
		// (remove) Token: 0x060009FA RID: 2554 RVA: 0x00031AB0 File Offset: 0x0002FCB0
		public event UpdatingPelvisPosition updatingPelvisPosition;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060009FB RID: 2555 RVA: 0x00031AE8 File Offset: 0x0002FCE8
		// (remove) Token: 0x060009FC RID: 2556 RVA: 0x00031B20 File Offset: 0x0002FD20
		public event UpdatingPelvisPosition updatingPelvisPositionAfterSmooth;

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x00031B55 File Offset: 0x0002FD55
		public bool isMovingPelvis
		{
			get
			{
				return this.m_isMovingPelvis && base.enabled;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x00031B67 File Offset: 0x0002FD67
		public AnimatorCharacter character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00031B6F File Offset: 0x0002FD6F
		public Transform effectorTransform
		{
			get
			{
				return this.m_effector.transform;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00031B7C File Offset: 0x0002FD7C
		public ModificableDeFloat modificableDeDificultadDeMovimientoX
		{
			get
			{
				return this.m_modificableDeDificultadDeMovimientoX;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00031B84 File Offset: 0x0002FD84
		public ModificableDeFloat modificableDeDificultadDeMovimientoMinusX
		{
			get
			{
				return this.m_modificableDeDificultadDeMovimientoMinusX;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00031B8C File Offset: 0x0002FD8C
		public ModificableDeFloat modificableDeDificultadDeMovimientoY
		{
			get
			{
				return this.m_modificableDeDificultadDeMovimientoY;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00031B94 File Offset: 0x0002FD94
		public ModificableDeFloat modificableDeDificultadDeMovimientoMinusY
		{
			get
			{
				return this.m_modificableDeDificultadDeMovimientoMinusY;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x00031B9C File Offset: 0x0002FD9C
		public ModificableDeFloat modificableDeDificultadDeMovimientoZ
		{
			get
			{
				return this.m_modificableDeDificultadDeMovimientoZ;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x00031BA4 File Offset: 0x0002FDA4
		public ModificableDeFloat modificableDeDificultadDeMovimientoMinusZ
		{
			get
			{
				return this.m_modificableDeDificultadDeMovimientoMinusZ;
			}
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00031BAC File Offset: 0x0002FDAC
		protected override void AwakeUnityEvent()
		{
			this.m_zRange = new PelvisMovementController.Range(-0.5f, 0.475f);
			this.m_yRange = new PelvisMovementController.Range(-1.6f, 0f);
			this.m_xRange = new PelvisMovementController.Range(-0.333f, 0.333f);
			base.AwakeUnityEvent();
			this.m_CharacterController = this.GetComponentEnRoot(false);
			if (this.m_CharacterController == null)
			{
				throw new ArgumentNullException("m_CharacterController", "m_CharacterController null reference.");
			}
			IIKUpdater componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("m_IIKUpdater", "m_IIKUpdater null reference.");
			}
			this.m_Character = this.GetComponentEnRoot(false);
			MonoBehaviour monoBehaviour = this.m_Character;
			if (monoBehaviour == null)
			{
				monoBehaviour = this;
			}
			this.m_Animator = monoBehaviour.GetComponentInChildren<Animator>();
			this.m_ik = monoBehaviour.GetComponentInChildren<IUserFullBodyBipedIK>().IK;
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
			if (this.m_ik == null)
			{
				throw new ArgumentNullException("m_ik", "m_ik null reference.");
			}
			Transform boneTransform = this.m_Animator.GetBoneTransform(HumanBodyBones.Hips);
			this.m_effector = boneTransform.CreateChild(base.name + "_Efector").GetComponentNotNull<LocalEffectorOffset>();
			this.m_effector.transform.rotation = this.m_Animator.transform.rotation;
			int num = componentEnRoot.IDDeIK(this.m_ik);
			int num2 = componentEnRoot.LayerDeIK(this.m_ik);
			bool flag;
			int num3 = componentEnRoot.IndexEnLayerDeIK(this.m_ik, out flag);
			if (componentEnRoot.CantidadDePasadasDeIK(num) < 2)
			{
				throw new NotSupportedException();
			}
			this.m_ik.solver.leftHandEffector.maintainRelativePositionWeight = 0.5f;
			this.m_ik.solver.rightHandEffector.maintainRelativePositionWeight = 0.5f;
			this.m_effector.velocity = 7.2000003f;
			this.m_effector.Init(num2.LayerToIKLayer(), num3.IndexToIKOrder(), IKPassOrderFlag.primero);
			this.AddBendTargets();
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00031DA0 File Offset: 0x0002FFA0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_FootRBend.Init(this.m_Animator, HumanBodyBones.RightFoot, HumanBodyBones.RightLowerLeg, this.m_ik.solver.rightFootEffector);
			this.m_FootLBend.Init(this.m_Animator, HumanBodyBones.LeftFoot, HumanBodyBones.LeftLowerLeg, this.m_ik.solver.leftFootEffector);
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPreSolve = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreSolve, new IKSolver.UpdateDelegate(this.OnIkRead));
			this.Init();
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00002BEA File Offset: 0x00000DEA
		private void Init()
		{
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00002BEA File Offset: 0x00000DEA
		private void AddBendTargets()
		{
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00031E2C File Offset: 0x0003002C
		private void AddBendTargetToLeg(Transform legBone, ref Transform result)
		{
			if (legBone == null)
			{
				throw new ArgumentNullException("legBone", "legBone null reference.");
			}
			result = legBone.CreateChild("_bend Target");
			result.position += this.m_Animator.transform.forward;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00031E81 File Offset: 0x00030081
		private void OnIkRead()
		{
			this.m_FootRBend.OnIkRead();
			this.m_FootLBend.OnIkRead();
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00031E9C File Offset: 0x0003009C
		public override void OnUpdateEvent1()
		{
			if (this.m_currentLocalTarget.x != 0f)
			{
				float num = this.m_effector.transform.InverseTransformDirection(this.m_CharacterController.State.Velocity).x * 2f;
				if (num > 0f && this.m_currentLocalTarget.x > 0f)
				{
					this.m_currentLocalTarget.x = this.m_currentLocalTarget.x - Mathf.Abs(num) * Time.deltaTime;
					if (this.m_currentLocalTarget.x < 0f)
					{
						this.m_currentLocalTarget.x = 0f;
					}
				}
				else if (num < 0f && this.m_currentLocalTarget.x < 0f)
				{
					this.m_currentLocalTarget.x = this.m_currentLocalTarget.x + Mathf.Abs(num) * Time.deltaTime;
					if (this.m_currentLocalTarget.x > 0f)
					{
						this.m_currentLocalTarget.x = 0f;
					}
				}
			}
			if (this.m_currentLocalTarget.x != 0f && Singleton<PlayerInputProxy>.instance.characterMovement.facingPointOfView)
			{
				this.m_currentLocalTarget.x = Mathf.MoveTowards(this.m_currentLocalTarget.x, 0f, Time.deltaTime * this.m_Character.escala);
			}
			UpdatingPelvisPosition updatingPelvisPosition = this.updatingPelvisPosition;
			if (updatingPelvisPosition != null)
			{
				updatingPelvisPosition(ref this.m_currentLocalTarget, this.m_effector.transform, this);
			}
			this.ApplyRanges();
			if (this.m_LegApertureCalcule.use)
			{
				float num2 = this.m_LegApertureCalcule.CalculeAperture(this.m_currentLocalTarget, this.yRange);
				this.m_FootRBend.angle = num2;
				this.m_FootLBend.angle = -num2;
			}
			else
			{
				this.m_FootRBend.angle = (this.m_FootLBend.angle = 0f);
			}
			if (this.activeFeetBendCorrection)
			{
				this.UpdateBendTarget(this.m_FootRBend);
				this.UpdateBendTarget(this.m_FootLBend);
			}
			this.m_isMovingPelvis = !ExtendedMonoBehaviour.AlmostEqual(this.m_effector.leftThighOffset, this.m_currentLocalTarget, 0.001f);
			Vector3 vector = (this.m_effector.leftThighOffset + this.m_effector.rightThighOffset) / 2f;
			if (vector == this.m_currentLocalTarget)
			{
				return;
			}
			Vector3 vector2 = Vector3.SmoothDamp(vector, this.m_currentLocalTarget, ref this.yvelocity, this.smoothTime, this.maxSpeed);
			UpdatingPelvisPosition updatingPelvisPosition2 = this.updatingPelvisPositionAfterSmooth;
			if (updatingPelvisPosition2 != null)
			{
				updatingPelvisPosition2(ref vector2, this.m_effector.transform, this);
			}
			this.m_effector.leftThighOffset = (this.m_effector.rightThighOffset = vector2);
			if (this.m_LegApertureCalcule.use)
			{
				this.m_effector.leftFootOffset = new Vector3(vector2.y / 4f, 0f);
				this.m_effector.rightFootOffset = new Vector3(-vector2.y / 4f, 0f);
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0003219A File Offset: 0x0003039A
		private void UpdateBendTarget(PelvisMovementController.BendTarget bt)
		{
			if (this.m_currentLocalTarget.y < 0f)
			{
				bt.SmoothTurnOn();
				bt.UpdateEffector();
				return;
			}
			bt.SmoothTurnOff();
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x000321C1 File Offset: 0x000303C1
		public void ControlForze(Vector3 pelvisLocalPosition)
		{
			if (pelvisLocalPosition == this.m_currentLocalTarget)
			{
				return;
			}
			this.m_currentLocalTarget = pelvisLocalPosition;
			this.OnTargetChanged();
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x000321DF File Offset: 0x000303DF
		public void Control(Vector3 pelvisLocalPosition)
		{
			pelvisLocalPosition = this.ModificarConDificultad(pelvisLocalPosition);
			if (pelvisLocalPosition == this.m_currentLocalTarget)
			{
				return;
			}
			this.m_currentLocalTarget = pelvisLocalPosition;
			this.OnTargetChanged();
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00032208 File Offset: 0x00030408
		public Vector3 ModificarConDificultad(Vector3 pelvisLocalPosition)
		{
			float num = pelvisLocalPosition.x - this.m_currentLocalTarget.x;
			float num2 = pelvisLocalPosition.y - this.m_currentLocalTarget.y;
			float num3 = pelvisLocalPosition.z - this.m_currentLocalTarget.z;
			if (num >= 0f)
			{
				num = this.m_modificableDeDificultadDeMovimientoX.ModificarValor(num);
			}
			else
			{
				num = this.m_modificableDeDificultadDeMovimientoMinusX.ModificarValor(num);
			}
			if (num2 >= 0f)
			{
				num2 = this.m_modificableDeDificultadDeMovimientoY.ModificarValor(num2);
			}
			else
			{
				num2 = this.m_modificableDeDificultadDeMovimientoMinusY.ModificarValor(num2);
			}
			if (num3 >= 0f)
			{
				num3 = this.m_modificableDeDificultadDeMovimientoZ.ModificarValor(num3);
			}
			else
			{
				num3 = this.m_modificableDeDificultadDeMovimientoMinusZ.ModificarValor(num3);
			}
			pelvisLocalPosition = new Vector3(num + this.m_currentLocalTarget.x, num2 + this.m_currentLocalTarget.y, num3 + this.m_currentLocalTarget.z);
			return pelvisLocalPosition;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x000322EC File Offset: 0x000304EC
		public void AddVerticalDelta(float valorDelta)
		{
			if (valorDelta >= 0f)
			{
				valorDelta = this.m_modificableDeDificultadDeMovimientoY.ModificarValor(valorDelta);
			}
			else
			{
				valorDelta = this.m_modificableDeDificultadDeMovimientoMinusY.ModificarValor(valorDelta);
			}
			if (valorDelta == 0f)
			{
				return;
			}
			this.m_currentLocalTarget.y = this.m_currentLocalTarget.y + valorDelta;
			this.OnTargetChanged();
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0003233E File Offset: 0x0003053E
		public void AddVertical(float valor)
		{
			this.AddVerticalDelta(valor * Time.deltaTime);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00032350 File Offset: 0x00030550
		public void AddHorizontalDelta(float valorDelta)
		{
			if (valorDelta >= 0f)
			{
				valorDelta = this.m_modificableDeDificultadDeMovimientoX.ModificarValor(valorDelta);
			}
			else
			{
				valorDelta = this.m_modificableDeDificultadDeMovimientoMinusX.ModificarValor(valorDelta);
			}
			if (valorDelta == 0f)
			{
				return;
			}
			this.m_currentLocalTarget.x = this.m_currentLocalTarget.x + valorDelta;
			this.OnTargetChanged();
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x000323A2 File Offset: 0x000305A2
		public void AddHorizontal(float valor)
		{
			this.AddHorizontalDelta(valor * Time.deltaTime);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x000323B4 File Offset: 0x000305B4
		public void AddProfundidadDelta(float valorDelta)
		{
			if (valorDelta >= 0f)
			{
				valorDelta = this.m_modificableDeDificultadDeMovimientoZ.ModificarValor(valorDelta);
			}
			else
			{
				valorDelta = this.m_modificableDeDificultadDeMovimientoMinusZ.ModificarValor(valorDelta);
			}
			if (valorDelta == 0f)
			{
				return;
			}
			this.m_currentLocalTarget.z = this.m_currentLocalTarget.z + valorDelta;
			this.OnTargetChanged();
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00032406 File Offset: 0x00030606
		public void AddProfundidad(float valor)
		{
			this.AddProfundidadDelta(valor * Time.deltaTime);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00032415 File Offset: 0x00030615
		public void ResetTarget()
		{
			this.m_currentLocalTarget = Vector3.zero;
			this.OnTargetChanged();
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00032428 File Offset: 0x00030628
		public void ApplyRanges()
		{
			AnimatorCharacter character = this.m_Character;
			float valueOrDefault = ((character != null) ? new float?(character.escala) : null).GetValueOrDefault(base.transform.localScale.Escala());
			this.zRange.Limit(ref this.m_currentLocalTarget.z, valueOrDefault);
			this.yRange.Limit(ref this.m_currentLocalTarget.y, valueOrDefault);
			this.xRange.Limit(ref this.m_currentLocalTarget.x, valueOrDefault);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x000324B2 File Offset: 0x000306B2
		private void OnTargetChanged()
		{
			this.m_effector.weight = this.weight;
			this.ApplyRanges();
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x000324CB File Offset: 0x000306CB
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.OnTargetChanged();
		}

		// Token: 0x04000780 RID: 1920
		[SerializeField]
		private GlobalUpdater.UpdateType m_updateEvent = GlobalUpdater.UpdateType.update3;

		// Token: 0x04000781 RID: 1921
		private Animator m_Animator;

		// Token: 0x04000782 RID: 1922
		private LocalEffectorOffset m_effector;

		// Token: 0x04000783 RID: 1923
		private FullBodyBipedIK m_ik;

		// Token: 0x04000784 RID: 1924
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000785 RID: 1925
		[SerializeReference]
		private PelvisMovementController.Range m_zRange;

		// Token: 0x04000786 RID: 1926
		[SerializeReference]
		private PelvisMovementController.Range m_yRange;

		// Token: 0x04000787 RID: 1927
		[SerializeReference]
		private PelvisMovementController.Range m_xRange;

		// Token: 0x04000788 RID: 1928
		[SerializeField]
		private Vector3 m_currentLocalTarget;

		// Token: 0x04000789 RID: 1929
		public bool activeFeetBendCorrection = true;

		// Token: 0x0400078A RID: 1930
		private Vector3 yvelocity = Vector3.zero;

		// Token: 0x0400078B RID: 1931
		public float smoothTime = 0.1f;

		// Token: 0x0400078C RID: 1932
		public float maxSpeed = 5f;

		// Token: 0x0400078F RID: 1935
		[SerializeField]
		private PelvisMovementController.BendTarget m_FootRBend = new PelvisMovementController.BendTarget();

		// Token: 0x04000790 RID: 1936
		[SerializeField]
		private PelvisMovementController.BendTarget m_FootLBend = new PelvisMovementController.BendTarget();

		// Token: 0x04000791 RID: 1937
		[SerializeField]
		private PelvisMovementController.LegApertureCalcule m_LegApertureCalcule = new PelvisMovementController.LegApertureCalcule();

		// Token: 0x04000792 RID: 1938
		[SerializeField]
		[ReadOnlyUI]
		private bool m_isMovingPelvis;

		// Token: 0x04000793 RID: 1939
		private AnimatorCharacter m_Character;

		// Token: 0x04000794 RID: 1940
		[SerializeField]
		private ModificableDeFloat m_modificableDeDificultadDeMovimientoX = new ModificableDeFloat(1f);

		// Token: 0x04000795 RID: 1941
		[SerializeField]
		private ModificableDeFloat m_modificableDeDificultadDeMovimientoMinusX = new ModificableDeFloat(1f);

		// Token: 0x04000796 RID: 1942
		[SerializeField]
		private ModificableDeFloat m_modificableDeDificultadDeMovimientoY = new ModificableDeFloat(1f);

		// Token: 0x04000797 RID: 1943
		[SerializeField]
		private ModificableDeFloat m_modificableDeDificultadDeMovimientoMinusY = new ModificableDeFloat(1f);

		// Token: 0x04000798 RID: 1944
		[SerializeField]
		private ModificableDeFloat m_modificableDeDificultadDeMovimientoZ = new ModificableDeFloat(1f);

		// Token: 0x04000799 RID: 1945
		[SerializeField]
		private ModificableDeFloat m_modificableDeDificultadDeMovimientoMinusZ = new ModificableDeFloat(1f);

		// Token: 0x0400079A RID: 1946
		private ICharacterController m_CharacterController;

		// Token: 0x020001A7 RID: 423
		[Serializable]
		public class BendTarget
		{
			// Token: 0x06000A1C RID: 2588 RVA: 0x000325AC File Offset: 0x000307AC
			public void Init(Animator animator, HumanBodyBones humanBodyBone, HumanBodyBones prevHumanBodyBone, IKEffector efector)
			{
				if (animator == null)
				{
					throw new ArgumentNullException("animator", "animator null reference.");
				}
				if (efector == null)
				{
					throw new ArgumentNullException("efector", "efector null reference.");
				}
				this.m_Animator = animator;
				this.efector = efector;
				this.m_humanBodyBone = humanBodyBone;
				this.m_prevHumanBodyBone = prevHumanBodyBone;
				this.bone = animator.GetBoneTransform(humanBodyBone);
				this.prevBone = animator.GetBoneTransform(prevHumanBodyBone);
				this.yAxis = this.bone.InverseTransformPoint(this.prevBone.position);
				float num = Vector3.Angle(Vector3.right, this.yAxis);
				float num2 = Vector3.Angle(-Vector3.right, this.yAxis);
				float num3 = Vector3.Angle(Vector3.up, this.yAxis);
				float num4 = Vector3.Angle(-Vector3.up, this.yAxis);
				float num5 = Vector3.Angle(Vector3.forward, this.yAxis);
				float num6 = Vector3.Angle(-Vector3.forward, this.yAxis);
				float num7 = Mathf.Min(new float[] { num, num2, num3, num4, num5, num6 });
				if (num == num7)
				{
					this.yAxis = Vector3.right;
				}
				if (num2 == num7)
				{
					this.yAxis = -Vector3.right;
				}
				if (num3 == num7)
				{
					this.yAxis = Vector3.up;
				}
				if (num4 == num7)
				{
					this.yAxis = -Vector3.up;
				}
				if (num5 == num7)
				{
					this.yAxis = Vector3.forward;
				}
				if (num6 == num7)
				{
					this.yAxis = -Vector3.forward;
				}
			}

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x06000A1D RID: 2589 RVA: 0x00032748 File Offset: 0x00030948
			public Animator animator
			{
				get
				{
					return this.m_Animator;
				}
			}

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x06000A1E RID: 2590 RVA: 0x00032750 File Offset: 0x00030950
			public HumanBodyBones humanBodyBone
			{
				get
				{
					return this.m_humanBodyBone;
				}
			}

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x06000A1F RID: 2591 RVA: 0x00032758 File Offset: 0x00030958
			public HumanBodyBones prevHumanBodyBone
			{
				get
				{
					return this.m_prevHumanBodyBone;
				}
			}

			// Token: 0x06000A20 RID: 2592 RVA: 0x00032760 File Offset: 0x00030960
			public void OnIkRead()
			{
				this.currentRotation = this.bone.rotation;
				if (this.weight < 0.001f)
				{
					this.efector.rotationWeight = 0f;
				}
				else
				{
					this.efector.rotationWeight = this.weight;
				}
				this.SetTargetRotation();
			}

			// Token: 0x06000A21 RID: 2593 RVA: 0x000327B4 File Offset: 0x000309B4
			public void UpdateEffector()
			{
				this.SetTargetRotation();
			}

			// Token: 0x06000A22 RID: 2594 RVA: 0x000327BC File Offset: 0x000309BC
			private void SetTargetRotation()
			{
				if (this.angle != 0f)
				{
					this.smoothAngleAngle = Mathf.SmoothDamp(this.smoothAngleAngle, this.angle, ref this.velangle, this.turnOnSmoothTime);
					this.efector.rotation = this.currentRotation * Quaternion.AngleAxis(this.smoothAngleAngle, this.yAxis);
					return;
				}
				this.efector.rotation = this.currentRotation;
			}

			// Token: 0x06000A23 RID: 2595 RVA: 0x00032832 File Offset: 0x00030A32
			public void SmoothTurnOn()
			{
				if (this.weight == 1f)
				{
					return;
				}
				this.weight = Mathf.SmoothDamp(this.weight, 1f, ref this.vel, this.turnOnSmoothTime);
			}

			// Token: 0x06000A24 RID: 2596 RVA: 0x00032864 File Offset: 0x00030A64
			public void SmoothTurnOff()
			{
				if (this.weight == 0f)
				{
					return;
				}
				this.weight = Mathf.SmoothDamp(this.weight, 0f, ref this.vel, this.turnOffSmoothTime);
			}

			// Token: 0x0400079B RID: 1947
			[Range(0f, 1f)]
			public float weight;

			// Token: 0x0400079C RID: 1948
			[Range(-45f, 45f)]
			public float angle;

			// Token: 0x0400079D RID: 1949
			private float smoothAngleAngle;

			// Token: 0x0400079E RID: 1950
			private Animator m_Animator;

			// Token: 0x0400079F RID: 1951
			[ReadOnlyUI]
			[SerializeField]
			private HumanBodyBones m_humanBodyBone;

			// Token: 0x040007A0 RID: 1952
			[ReadOnlyUI]
			[SerializeField]
			private HumanBodyBones m_prevHumanBodyBone;

			// Token: 0x040007A1 RID: 1953
			[ReadOnlyUI]
			[SerializeField]
			private Transform bone;

			// Token: 0x040007A2 RID: 1954
			[ReadOnlyUI]
			[SerializeField]
			private Transform prevBone;

			// Token: 0x040007A3 RID: 1955
			private IKEffector efector;

			// Token: 0x040007A4 RID: 1956
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 yAxis;

			// Token: 0x040007A5 RID: 1957
			[ReadOnlyUI]
			[SerializeField]
			private Quaternion currentRotation;

			// Token: 0x040007A6 RID: 1958
			public float turnOnSmoothTime = 0.15f;

			// Token: 0x040007A7 RID: 1959
			public float turnOffSmoothTime = 1f;

			// Token: 0x040007A8 RID: 1960
			private float vel;

			// Token: 0x040007A9 RID: 1961
			private float velangle;
		}

		// Token: 0x020001A8 RID: 424
		[Serializable]
		public class LegApertureCalcule
		{
			// Token: 0x06000A26 RID: 2598 RVA: 0x000328B4 File Offset: 0x00030AB4
			public float CalculeAperture(Vector3 currentTarget, PelvisMovementController.Range yRange)
			{
				float num = yRange.MinLimited() * this.yPercentToMaxAperture;
				num = Mathf.Abs(num);
				float num2 = Mathf.Abs(currentTarget.y);
				if (num2 >= num)
				{
					return this.maxAperture;
				}
				return Mathf.Clamp(this.maxAperture * num2 / num, 0f, this.maxAperture);
			}

			// Token: 0x040007AA RID: 1962
			public bool use;

			// Token: 0x040007AB RID: 1963
			[Range(0f, 1f)]
			public float yPercentToMaxAperture = 0.5f;

			// Token: 0x040007AC RID: 1964
			public float maxAperture = 50f;
		}

		// Token: 0x020001A9 RID: 425
		[Serializable]
		public class Range
		{
			// Token: 0x06000A28 RID: 2600 RVA: 0x00032925 File Offset: 0x00030B25
			public Range(float min, float max)
			{
				this.min = min;
				this.max = max;
				if (min > max)
				{
					min = max;
				}
			}

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x06000A29 RID: 2601 RVA: 0x00032962 File Offset: 0x00030B62
			public ModificableDeFloat minModificable
			{
				get
				{
					return this.m_minModificable;
				}
			}

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x06000A2A RID: 2602 RVA: 0x0003296A File Offset: 0x00030B6A
			public ModificableDeFloat maxModificable
			{
				get
				{
					return this.m_maxModificable;
				}
			}

			// Token: 0x06000A2B RID: 2603 RVA: 0x00032974 File Offset: 0x00030B74
			public void Limit(ref float target, float scale)
			{
				float num = this.MinLimited();
				float num2 = this.MaxLimited();
				if (target < num * scale)
				{
					target = num * scale;
					return;
				}
				if (target > num2 * scale)
				{
					target = num2 * scale;
				}
			}

			// Token: 0x06000A2C RID: 2604 RVA: 0x000329A8 File Offset: 0x00030BA8
			public float MinLimited()
			{
				return this.m_minModificable.ModificarValor(this.min);
			}

			// Token: 0x06000A2D RID: 2605 RVA: 0x000329BB File Offset: 0x00030BBB
			public float MaxLimited()
			{
				return this.m_maxModificable.ModificarValor(this.max);
			}

			// Token: 0x040007AD RID: 1965
			private ModificableDeFloat m_minModificable = new ModificableDeFloat(1f);

			// Token: 0x040007AE RID: 1966
			private ModificableDeFloat m_maxModificable = new ModificableDeFloat(1f);

			// Token: 0x040007AF RID: 1967
			public float min;

			// Token: 0x040007B0 RID: 1968
			public float max;
		}
	}
}
