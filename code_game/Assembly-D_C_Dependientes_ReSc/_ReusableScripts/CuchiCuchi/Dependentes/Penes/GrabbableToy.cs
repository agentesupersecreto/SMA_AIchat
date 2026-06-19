using System;
using System.Collections;
using Assets.SystemasConstraints._Abstract;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets.TValle.BeachGirl.Runtime.Males;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Penes
{
	// Token: 0x0200015A RID: 346
	public class GrabbableToy : GrabbableDefinedProp, IGrabableToy, IGrabableProp, IDefinedProp
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00025914 File Offset: 0x00023B14
		public override Transform physcisRoot
		{
			get
			{
				if (!base.isStared)
				{
					return base.physcisRoot;
				}
				return this.m_toyPenis.penisLinearChain.transform;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x00025935 File Offset: 0x00023B35
		public override Transform skeletonRoot
		{
			get
			{
				if (!base.isStared)
				{
					return base.skeletonRoot;
				}
				return this.m_toyPenis.penisLinearChain.puntoBaseTransform;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00025956 File Offset: 0x00023B56
		public override float worldLength
		{
			get
			{
				if (!base.isStared)
				{
					return base.worldLength;
				}
				return this.m_toyPenis.worldLength;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x00025972 File Offset: 0x00023B72
		public Toy toy
		{
			get
			{
				return this.m_toyPenis;
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0002597C File Offset: 0x00023B7C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_armatureRoot.GetComponentNotNull<ConstrainedSkeleton>().Reset();
			CharacterToyAdder component = base.GetComponent<CharacterToyAdder>();
			if (component == null)
			{
				throw new ArgumentNullException("adder", "adder null reference.");
			}
			if (component.wasAdded)
			{
				throw new InvalidOperationException("racing problem in toy");
			}
			component.afterAdded += this.OnToyPenisCreated;
			this.AwakeSensorsLogic();
			base.SetManualStart();
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x000259F0 File Offset: 0x00023BF0
		private void AwakeSensorsLogic()
		{
			if (this.m_sensorBase == null)
			{
				throw new ArgumentNullException("m_sensorBase", "m_sensorBase null reference.");
			}
			this.m_baseSensorSphere = this.m_sensorBase.GetComponent<EmulatedSphereTrigger>();
			if (this.m_baseSensorSphere == null)
			{
				throw new ArgumentNullException("m_baseSensorSphere", "m_baseSensorSphere null reference.");
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00025A4C File Offset: 0x00023C4C
		private void OnToyPenisCreated(BehaviourAdder obj)
		{
			this.m_basePartMassGetter = (obj as CharacterToyAdder).PelvisMassGetter();
			this.m_toyPenis = (Toy)obj.addedResult;
			this.m_toyPenis.tipoDeProp = this.m_tipoDeProrp;
			this.m_followers = this.m_armatureRoot.GetComponentsInChildren<BaseTrasnFormCopiador>();
			base.ManualStart();
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00025AA3 File Offset: 0x00023CA3
		protected override void OnGrabedR(Interaccion obj)
		{
			if (!this.m_toyPenis.isPenetrating)
			{
				base.SetGrabbedHierarchy(Side.R, obj, this.m_poserRtoationOffset, true, 0f, 1f);
				return;
			}
			base.SetGrabbedHierarchyDelayed(Side.R, obj);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00025AD4 File Offset: 0x00023CD4
		protected override void OnDropedR(Interaccion obj)
		{
			BoneStretchedChain boneStretchedChain;
			if (!this.m_toyPenis.IsPenetratingHole(out boneStretchedChain))
			{
				base.SetNotGrabbedHierarchy();
				return;
			}
			base.SetNotGrabbedButActivatedHierarchy(obj, boneStretchedChain);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00025B00 File Offset: 0x00023D00
		protected override void Pre_SetNotGrabbedHierarchy()
		{
			base.Pre_SetNotGrabbedHierarchy();
			this.StopSavingHoleForces();
			GlobalUpdater.Corrutina followPenetratedHoleCorutina = this.m_followPenetratedHoleCorutina;
			if (followPenetratedHoleCorutina != null)
			{
				followPenetratedHoleCorutina.Stop();
			}
			this.m_followPenetratedHoleCorutina = null;
			ForcedFixedJoint component = this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.GetComponent<ForcedFixedJoint>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			this.m_followers.ForEach(delegate(BaseTrasnFormCopiador f)
			{
				f.ResetPose();
				f.enabled = false;
			});
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00025B88 File Offset: 0x00023D88
		protected override void On_SetNotGrabbedHierarchy(Vector3 pos, Quaternion rot, Vector3 scale)
		{
			base.On_SetNotGrabbedHierarchy(pos, rot, scale);
			this.m_toyPenis.transform.parent = this.m_root;
			this.m_toyPenis.penisLinearChain.rootPointEsKinematico = true;
			this.m_toyPenis.gameObject.SetActive(false);
			this.m_toyPenis.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			this.m_toyPenis.transform.localScale = Vector3.one;
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00025C05 File Offset: 0x00023E05
		protected override void Post_SetNotGrabbedHierarchy()
		{
			base.Post_SetNotGrabbedHierarchy();
			this.m_toyPenis.penisLinearChain.FixPointsEnOrdenAsc();
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00025C1D File Offset: 0x00023E1D
		protected override void Pre_SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
			base.Pre_SetGrabbedHierarchyDelayed(side, obj);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00025C27 File Offset: 0x00023E27
		protected override void On_SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
			base.On_SetGrabbedHierarchyDelayed(side, obj);
			this.m_toyPenis.penisLinearChain.rootPointEsKinematico = true;
			this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.isKinematic = true;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00025C5D File Offset: 0x00023E5D
		protected override void Post_SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
			base.Post_SetGrabbedHierarchyDelayed(side, obj);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00025C67 File Offset: 0x00023E67
		protected override void Pre_SetGrabbedHierarchy(Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
			base.Pre_SetGrabbedHierarchy(side, obj, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime);
			this.StopSavingHoleForces();
			GlobalUpdater.Corrutina followPenetratedHoleCorutina = this.m_followPenetratedHoleCorutina;
			if (followPenetratedHoleCorutina != null)
			{
				followPenetratedHoleCorutina.Stop();
			}
			this.m_followPenetratedHoleCorutina = null;
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00025C98 File Offset: 0x00023E98
		protected override void On_SetGrabbedHierarchy(Rigidbody muscleRigid, Vector3 pos, Quaternion rot, Vector3 scale, Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
			base.On_SetGrabbedHierarchy(muscleRigid, pos, rot, scale, side, obj, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime);
			this.m_toyPenis.transform.parent = muscleRigid.transform;
			this.m_toyPenis.penisLinearChain.rootPointEsKinematico = false;
			this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.isKinematic = false;
			this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.useGravity = false;
			this.m_toyPenis.transform.SetPositionAndRotation(pos, rot);
			this.m_toyPenis.transform.localScale = scale;
			this.m_followers.ForEach(delegate(BaseTrasnFormCopiador f)
			{
				f.InverseFollow();
			});
			this.m_toyPenis.gameObject.SetActive(true);
			this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.mass = this.m_basePartMassGetter();
			this.m_followers.ForEach(delegate(BaseTrasnFormCopiador f)
			{
				f.enabled = true;
			});
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00025DC8 File Offset: 0x00023FC8
		protected override void Post_SetGrabbedHierarchy(Rigidbody muscleRigid, Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
			base.Post_SetGrabbedHierarchy(muscleRigid, side, obj, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime);
			ForcedFixedJoint forcedFixedJoint = this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.gameObject.AddComponent<ForcedFixedJoint>();
			forcedFixedJoint.connectedBody = muscleRigid;
			forcedFixedJoint.ManualStart();
			forcedFixedJoint.connectedMassScale = 5f;
			forcedFixedJoint.enabled = false;
			forcedFixedJoint.enabled = true;
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00025E2C File Offset: 0x0002402C
		protected override void Pre_SetNotGrabbedButActivatedHierarchy(Interaccion obj, object attachedTo)
		{
			base.Pre_SetNotGrabbedButActivatedHierarchy(obj, attachedTo);
			this.StartSavingHoleForces();
			GlobalUpdater.Corrutina followPenetratedHoleCorutina = this.m_followPenetratedHoleCorutina;
			if (followPenetratedHoleCorutina != null)
			{
				followPenetratedHoleCorutina.Stop();
			}
			this.m_followPenetratedHoleCorutina = null;
			ForcedFixedJoint component = this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.GetComponent<ForcedFixedJoint>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			BoneStretchedChain boneStretchedChain = attachedTo as BoneStretchedChain;
			this.m_followPenetratedHoleCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdateAfterCameraController, this, this.FollorPenetratedHoleRutine(this.m_root, boneStretchedChain), null);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00025EB4 File Offset: 0x000240B4
		protected override void On_SetNotGrabbedButActivatedHierarchy(Vector3 pos, Quaternion rot, Vector3 scale, Interaccion obj, object attachedTo)
		{
			base.On_SetNotGrabbedButActivatedHierarchy(pos, rot, scale, obj, attachedTo);
			this.m_toyPenis.transform.parent = base.transform;
			this.m_toyPenis.penisLinearChain.rootPointEsKinematico = true;
			this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.useGravity = false;
			this.m_toyPenis.penisLinearChain.rootPunto.jointRigidbody.isKinematic = true;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00025F2B File Offset: 0x0002412B
		protected override void Post_SetNotGrabbedButActivatedHierarchy(Interaccion obj, object attachedTo)
		{
			base.Post_SetNotGrabbedButActivatedHierarchy(obj, attachedTo);
			this.m_followers.ForEach(delegate(BaseTrasnFormCopiador f)
			{
				f.ResetPose();
				f.enabled = true;
			});
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00025F5F File Offset: 0x0002415F
		private IEnumerator FollorPenetratedHoleRutine(Transform toy, IHole hole)
		{
			Transform entrada = hole.entrada;
			Vector3 localPosition = entrada.InverseTransformPoint(toy.position);
			Vector3 currentLocalPosition = localPosition;
			Vector3 localUpDir = entrada.InverseTransformDirection(toy.up);
			entrada.InverseTransformDirection(toy.forward);
			Vector3 localDepenetrationDir = entrada.InverseTransformDirection(hole.worldOutHoleDirection);
			Vector3 currentLocalDepenetrationDisplacement = Vector3.zero;
			Quaternion localRotation = Quaternion.Inverse(entrada.rotation) * toy.rotation;
			Quaternion currentLocalRotation = localRotation;
			float startWorldDistanceToyToHole = Vector3.Distance(toy.position, entrada.position);
			bool atRestPose = false;
			float? startDist = null;
			Vector3 SmoothDampVelocity = Vector3.zero;
			while (this.m_toyPenis.isPenetrating)
			{
				Vector3 worldOutHoleDirection = hole.worldOutHoleDirection;
				if (!atRestPose)
				{
					Vector3 vector = entrada.position + worldOutHoleDirection * startWorldDistanceToyToHole;
					Vector3 vector2 = entrada.InverseTransformPoint(vector);
					Quaternion quaternion = Quaternion.LookRotation(entrada.InverseTransformDirection(-worldOutHoleDirection), localUpDir);
					if (startDist == null)
					{
						startDist = new float?(Vector3.Distance(localPosition, vector2));
					}
					currentLocalPosition = Vector3.SmoothDamp(currentLocalPosition, vector2, ref SmoothDampVelocity, 0.075f);
					float num2;
					if (startDist.Value > 0.0001f)
					{
						float num = Vector3.Distance(currentLocalPosition, vector2);
						num2 = 1f - Mathf.Clamp01(num / startDist.Value);
					}
					else
					{
						num2 = 1f;
					}
					currentLocalRotation = Quaternion.Slerp(localRotation, quaternion, num2);
					atRestPose = ExtendedMonoBehaviour.AlmostEqual(vector2, currentLocalPosition, 0.001f) && ExtendedMonoBehaviour.AlmostEqual(quaternion, currentLocalRotation, 0.1f);
				}
				this.m_depenetrationVelocidadAcumulada *= Mathf.Exp(-this.m_depenetrationDamperV3 * Time.deltaTime);
				this.m_depenetrationVelocidadAcumulada = Mathf.Clamp(this.m_depenetrationVelocidadAcumulada, 0f, this.m_depenetrationMaxSpeedV3);
				float num3 = this.m_depenetrationVelocidadAcumulada * Time.deltaTime;
				currentLocalDepenetrationDisplacement += localDepenetrationDir * num3;
				this.m_depenetrationVelocidadAcumulada -= num3;
				Vector3 vector3 = entrada.TransformPoint(currentLocalPosition + currentLocalDepenetrationDisplacement);
				Quaternion quaternion2 = entrada.rotation * currentLocalRotation;
				toy.SetPositionAndRotation(vector3, quaternion2);
				yield return null;
			}
			base.SetNotGrabbedHierarchy();
			yield break;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00025F7C File Offset: 0x0002417C
		protected override bool FollowHandBone()
		{
			return !this.m_toyPenis.isPenetrating;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00025F8C File Offset: 0x0002418C
		private void StartSavingHoleForces()
		{
			if (!this.m_toyPenis.IsPenetratingHole(out this.m_currentHole))
			{
				throw new InvalidOperationException();
			}
			if (this.m_currentHole != null)
			{
				this.m_currentHoleOwnerForces = this.m_currentHole.GetComponentInParent<SkinCollisionForceTransfer>();
				if (this.m_currentHoleOwnerForces != null)
				{
					this.m_currentHoleOwnerForces.onFuerzasPorPenetracion -= this.M_currentHoleOwnerForces_onFuerzasPorPenetracion;
					this.m_currentHoleOwnerForces.onFuerzasPorPenetracion += this.M_currentHoleOwnerForces_onFuerzasPorPenetracion;
				}
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0002600D File Offset: 0x0002420D
		private void StopSavingHoleForces()
		{
			if (this.m_currentHoleOwnerForces != null)
			{
				this.m_currentHoleOwnerForces.onFuerzasPorPenetracion -= this.M_currentHoleOwnerForces_onFuerzasPorPenetracion;
			}
			this.m_currentHole = null;
			this.m_currentHoleOwnerForces = null;
			this.m_depenetrationVelocidadAcumulada = 0f;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00026050 File Offset: 0x00024250
		private void M_currentHoleOwnerForces_onFuerzasPorPenetracion(Vector3 point, Vector3 realForce, Vector3 usedForce, ColisionBasicaV2 collision, SkinCollisionForceTransfer sender)
		{
			if (this.m_currentHole == null)
			{
				sender.onFuerzasPorPenetracion -= this.M_currentHoleOwnerForces_onFuerzasPorPenetracion;
				this.StopSavingHoleForces();
				return;
			}
			if (!collision.colliderChocandonos.transform.IsChildOf(this.m_toyPenis.penisLinearChain.transform))
			{
				return;
			}
			if (realForce.sqrMagnitude <= 0f)
			{
				return;
			}
			Vector3 worldOutHoleDirection = this.m_currentHole.worldOutHoleDirection;
			realForce *= this.m_depenetrationForceModV3;
			Vector3 vector = realForce * -1f;
			vector /= this.m_toyPenis.totalMass + this.m_basePartMassGetter();
			vector = Math3d.ProjectIfFacing(vector, worldOutHoleDirection);
			this.m_depenetrationVelocidadAcumulada += vector.magnitude;
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00026118 File Offset: 0x00024318
		public Transform sensorBase
		{
			get
			{
				return this.m_sensorBase;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00026120 File Offset: 0x00024320
		public float sensorBaseWorldRadius
		{
			get
			{
				return this.m_toyPenis.worldScaleIgnorandoEreccion * this.m_baseSensorSphere.radius;
			}
		}

		// Token: 0x04000599 RID: 1433
		[Header("Toy")]
		private Func<float> m_basePartMassGetter;

		// Token: 0x0400059A RID: 1434
		[SerializeField]
		[ReadOnlyUI]
		private Toy m_toyPenis;

		// Token: 0x0400059B RID: 1435
		[SerializeField]
		[ReadOnlyUI]
		private BaseTrasnFormCopiador[] m_followers;

		// Token: 0x0400059C RID: 1436
		private GlobalUpdater.Corrutina m_followPenetratedHoleCorutina;

		// Token: 0x0400059D RID: 1437
		[Header("Penetrating")]
		[SerializeField]
		private float m_depenetrationForceModV3 = 0.01f;

		// Token: 0x0400059E RID: 1438
		[SerializeField]
		private float m_depenetrationDamperV3 = 12f;

		// Token: 0x0400059F RID: 1439
		[SerializeField]
		private float m_depenetrationMaxSpeedV3 = 0.1f;

		// Token: 0x040005A0 RID: 1440
		[SerializeField]
		[ReadOnlyUI]
		private BoneStretchedChain m_currentHole;

		// Token: 0x040005A1 RID: 1441
		[SerializeField]
		[ReadOnlyUI]
		private SkinCollisionForceTransfer m_currentHoleOwnerForces;

		// Token: 0x040005A2 RID: 1442
		[SerializeField]
		[ReadOnlyUI]
		private float m_depenetrationVelocidadAcumulada;

		// Token: 0x040005A3 RID: 1443
		[Header("Sensor")]
		[SerializeField]
		private Transform m_sensorBase;

		// Token: 0x040005A4 RID: 1444
		protected EmulatedSphereTrigger m_baseSensorSphere;
	}
}
