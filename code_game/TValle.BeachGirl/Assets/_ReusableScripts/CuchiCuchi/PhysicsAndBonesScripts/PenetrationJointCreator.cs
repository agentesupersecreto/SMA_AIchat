using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000FB RID: 251
	public class PenetrationJointCreator : CustomMonobehaviour
	{
		// Token: 0x06000AB6 RID: 2742 RVA: 0x0002301A File Offset: 0x0002121A
		public void FlagUpdateDriversConConeTrayectorias(PenetrationJointCreator.GetConeTrayecotiaDataForDriverConfigHandler getTrayectoriaData)
		{
			this.m_GetTrayectoriaData = getTrayectoriaData;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x00023024 File Offset: 0x00021224
		public void Init(Penetraciones penetraciones)
		{
			if (this.m_initiated)
			{
				throw new InvalidOperationException();
			}
			this.m_initiated = true;
			this.m_penetraciones = penetraciones;
			this.m_penetraciones.isDebug = this.debug;
			penetraciones.onPenetrationEnter += this.Penetraciones_onPenetrationEnter;
			penetraciones.onPenetrationStay += this.Penetraciones_onPenetrationStay;
			penetraciones.onPenetrationOut += this.Penetraciones_onPenetrationOut;
			penetraciones.peneOut += this.Penetraciones_peneOut;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x000230A6 File Offset: 0x000212A6
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.LimpiarJoints();
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000230B8 File Offset: 0x000212B8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (quitting)
			{
				return;
			}
			this.m_penetraciones.onPenetrationEnter -= this.Penetraciones_onPenetrationEnter;
			this.m_penetraciones.onPenetrationStay -= this.Penetraciones_onPenetrationStay;
			this.m_penetraciones.onPenetrationOut -= this.Penetraciones_onPenetrationOut;
			this.m_penetraciones.peneOut -= this.Penetraciones_peneOut;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0002312C File Offset: 0x0002132C
		private void Penetraciones_peneOut(IPeneConPartes pene, Penetraciones penetracionesChecker)
		{
			this.LimpiarJoints();
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00023134 File Offset: 0x00021334
		public void LimpiarJoints()
		{
			foreach (KeyValuePair<PenisPart, ConfigurableJoint> keyValuePair in this.m_historialAdentroDesactivados)
			{
				this.DestroyJoint(keyValuePair.Value);
			}
			this.m_historialAdentroDesactivados.Clear();
			foreach (KeyValuePair<PenisPart, ConfigurableJoint> keyValuePair2 in this.m_historial)
			{
				this.DestroyJoint(keyValuePair2.Value);
			}
			this.m_historial.Clear();
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x000231EC File Offset: 0x000213EC
		private void Penetraciones_onPenetrationEnter(PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			try
			{
				this.onPenetrationEnter(parte, hit, penetracionesChecker);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("exepcion en Penetraciones_onPenetrationEnter: " + ex.Message, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00023234 File Offset: 0x00021434
		private void onPenetrationEnter(PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			ConfigurableJoint configurableJoint = null;
			try
			{
				if (this.m_historialAdentroDesactivados.ContainsKey(parte))
				{
					if (this.debug)
					{
						MonoBehaviour.print("parte " + parte.name + " entro. Pero NO se creara joint por q esta parte ya estaba adentro");
					}
					configurableJoint = this.m_historialAdentroDesactivados[parte];
					this.m_historialAdentroDesactivados.Remove(parte);
					this.ActualizarJoint(parte, hit, configurableJoint);
				}
				else
				{
					if (this.debug)
					{
						MonoBehaviour.print("parte " + parte.name + " entro.");
					}
					configurableJoint = this.GetJoint(parte, penetracionesChecker.hole);
					this.ConfigurarJoint(configurableJoint, parte, penetracionesChecker.hole, hit);
				}
			}
			finally
			{
				if (configurableJoint == null)
				{
					throw new ArgumentNullException("created", "created null reference.");
				}
				this.m_historial.Add(parte, configurableJoint);
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00023310 File Offset: 0x00021510
		private void Penetraciones_onPenetrationStay(PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			try
			{
				ConfigurableJoint configurableJoint;
				if (!this.m_historial.TryGetValue(parte, out configurableJoint))
				{
					Debug.LogError("parte " + parte.name + " Stay. Pero no estaba registrada como estando adentro", this);
				}
				else
				{
					this.ActualizarJoint(parte, hit, configurableJoint);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("exepcion en Penetraciones_onPenetrationStay: " + ex.Message, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x00023384 File Offset: 0x00021584
		private void Penetraciones_onPenetrationOut(PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			try
			{
				if (this.debug)
				{
					MonoBehaviour.print("parte " + parte.name + " salio.");
				}
				ConfigurableJoint configurableJoint;
				if (this.m_historial.TryGetValue(parte, out configurableJoint))
				{
					bool flag = true;
					if (parte.GetCurrentState() == PenisPart.PenetrationState.adentroDesactivado && parte.currentPenetratingHole == this.m_penetraciones.hole)
					{
						if (this.debug)
						{
							MonoBehaviour.print("parte " + parte.name + " salio. Pero su joint No sera destruido, por q aun esta adentro");
						}
						flag = false;
						if (!this.m_historialAdentroDesactivados.ContainsKey(parte))
						{
							this.m_historialAdentroDesactivados.Add(parte, configurableJoint);
						}
						this.ActualizarJoint(parte, hit, configurableJoint);
					}
					this.m_historial.Remove(parte);
					if (flag)
					{
						this.m_historialAdentroDesactivados.Remove(parte);
						this.DestroyJoint(configurableJoint);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("exepcion en Penetraciones_onPenetrationOut: " + ex.Message, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00023488 File Offset: 0x00021688
		private void DestroyJoint(ConfigurableJoint joint)
		{
			if (joint)
			{
				Object.Destroy(joint);
			}
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00023498 File Offset: 0x00021698
		private ConfigurableJoint GetJoint(PenisPart parte, BoneStretchedChain hole)
		{
			return hole.centroDePuntos.gameObject.AddComponent<ConfigurableJoint>();
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x000234AC File Offset: 0x000216AC
		private float GetCurrentModDeEntrada(PenisPartHit hit, PenisPart parte, Suavizacion suavizacion, out bool alMaximo)
		{
			alMaximo = true;
			if (hit == null)
			{
				return 1f;
			}
			float num;
			if (parte.deepMod >= suavizacion.penetracionDeParteWParaMaxValores)
			{
				num = 1f;
			}
			else
			{
				num = Mathf.InverseLerp(0f, suavizacion.penetracionDeParteWParaMaxValores, parte.deepMod).InPow(suavizacion.inPower);
			}
			alMaximo = num >= 1f;
			return num;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00023510 File Offset: 0x00021710
		private float GetCurrentModDeProfundidad()
		{
			float penetratedDepthLocalInternals = this.m_penetraciones.hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals;
			float maxProfundidadPhysicsLocal = this.m_penetraciones.hole.maxProfundidadPhysicsLocal;
			float num = PenetrationJointCreator.GetCurrentModDeProfundidad(penetratedDepthLocalInternals, maxProfundidadPhysicsLocal, maxProfundidadPhysicsLocal * 0.2f, 0.5f, 1f, 1f, 10f, 2000f);
			for (int i = 0; i < this.m_penetraciones.hole.hardPointsList.Count; i++)
			{
				HoleVirtualHardPoint holeVirtualHardPoint = this.m_penetraciones.hole.hardPointsList[i];
				float currentModDeProfundidad = PenetrationJointCreator.GetCurrentModDeProfundidad(penetratedDepthLocalInternals, holeVirtualHardPoint.GetProfundidadLocalFromInternals(), holeVirtualHardPoint.GetLocalRadiusFromInternals(), this.configuracion.hardPointsMiddle, this.configuracion.hardPointsInInPower, this.configuracion.hardPointsOutOutPower, this.configuracion.hardPointsDamper * holeVirtualHardPoint.resistenciaMod, this.configuracion.hardPointsDamper * holeVirtualHardPoint.passResistenciaMod);
				num = Mathf.Max(num, currentModDeProfundidad);
			}
			return num;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00023618 File Offset: 0x00021818
		private float GetCurrentModDeProfundidadSpring()
		{
			float penetratedDepthLocalInternals = this.m_penetraciones.hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals;
			float maxProfundidadPhysicsLocal = this.m_penetraciones.hole.maxProfundidadPhysicsLocal;
			float num = PenetrationJointCreator.GetCurrentModDeProfundidadSpring(penetratedDepthLocalInternals, maxProfundidadPhysicsLocal, maxProfundidadPhysicsLocal * 0.2f, 0.5f, 1f, 1f, this.configuracion.zDriveDamperToSpring * 0.1f, this.configuracion.zDriveDamperToSpring);
			for (int i = 0; i < this.m_penetraciones.hole.hardPointsList.Count; i++)
			{
				HoleVirtualHardPoint holeVirtualHardPoint = this.m_penetraciones.hole.hardPointsList[i];
				num = Mathf.Max(num, PenetrationJointCreator.GetCurrentModDeProfundidadSpring(penetratedDepthLocalInternals, holeVirtualHardPoint.GetProfundidadLocalFromInternals(), holeVirtualHardPoint.GetLocalRadiusFromInternals(), this.configuracion.hardPointsMiddle, this.configuracion.hardPointsInInPower, this.configuracion.hardPointsOutOutPower, this.configuracion.hardPointsSpring * holeVirtualHardPoint.resistenciaMod, 0f));
			}
			return num;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0002371C File Offset: 0x0002191C
		private static float GetCurrentModDeProfundidad(float currentPenetractionDistance, float hardPointDistance, float hardPointRange, float centerPointMod, float inInPwr, float outOutPwr, float onSpotHardness = 10f, float onPassedHardness = 2000f)
		{
			float num = hardPointDistance - hardPointRange;
			float num2 = hardPointDistance + hardPointRange;
			float num3 = num + (num2 - num) * centerPointMod;
			float num4 = MathfExtension.InverseLerpConMedio(num, num3, num2, currentPenetractionDistance);
			num4 = num4.InInOutOutPow(inInPwr, outOutPwr, 0.5f);
			return MathfExtension.LerpConMedio(1f, onSpotHardness, onPassedHardness, num4);
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00023764 File Offset: 0x00021964
		private static float GetCurrentModDeProfundidadSpring(float currentPenetractionDistance, float hardPointDistance, float hardPointRange, float centerPointMod, float inInPwr, float outOutPwr, float onSpotSpring, float onPassedSpring)
		{
			float num = hardPointDistance - hardPointRange;
			float num2 = hardPointDistance + hardPointRange;
			float num3 = num + (num2 - num) * centerPointMod;
			float num4 = MathfExtension.InverseLerpConMedio(num, num3, num2, currentPenetractionDistance);
			num4 = num4.InInOutOutPow(inInPwr, outOutPwr, 0.5f);
			return MathfExtension.LerpConMedio(0f, onSpotSpring, onPassedSpring, num4);
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x000237AC File Offset: 0x000219AC
		private float GetCurrentModDeAnchuraVirtual()
		{
			float maxAnchuraVirtualLocal = this.m_penetraciones.hole.maxAnchuraVirtualLocal;
			float maxLimpiaLocalInternals = this.m_penetraciones.hole.estadoDePuntos.actualLocal.maxLimpiaLocalInternals;
			float num = MathfExtension.InverseLerpConMedio(maxAnchuraVirtualLocal * 0.333f, maxAnchuraVirtualLocal, maxAnchuraVirtualLocal * 1.5f, maxLimpiaLocalInternals);
			if (num == 0.5f)
			{
				return 1f;
			}
			if (num > 0.5f)
			{
				num = Mathf.InverseLerp(0.5f, 1f, num);
				num = num.InPow(2f);
				return Mathf.Lerp(1f, 6f, num);
			}
			if (num < 0.5f)
			{
				num = Mathf.InverseLerp(0f, 0.5f, num);
				num = num.OutPow(2f);
				return Mathf.Lerp(0.333f, 1f, num);
			}
			return 1f;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0002387A File Offset: 0x00021A7A
		private void ActualizarJoint(PenisPart parte, PenisPartHit hit, ConfigurableJoint joint)
		{
			this.SetJointDrivers(joint, parte, hit);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00023885 File Offset: 0x00021A85
		private void SetJointDrivers(ConfigurableJoint joint, PenisPart parte, PenisPartHit hit)
		{
			if (this.configuracionConeTrayectorias.useToUpdateDrivers && this.m_GetTrayectoriaData != null)
			{
				this.SetJointDriversConTrayectorias(joint, parte, hit);
				return;
			}
			this.SetJointDriversV1(joint, parte, hit);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x000238B0 File Offset: 0x00021AB0
		private void SetJointDriversConTrayectorias(ConfigurableJoint joint, PenisPart parte, PenisPartHit hit)
		{
			Rigidbody physicBone = parte.physicBone;
			float num = 1f;
			bool flag = true;
			if (this.configuracion.suavizarAlEntrarHole)
			{
				num = this.GetCurrentModDeEntrada(hit, parte, this.configuracion.suavizacion, out flag);
			}
			float num2 = 1f;
			bool flag2 = true;
			if (this.configuracion.suavizarAlEntrarHoleAngular)
			{
				num2 = this.GetCurrentModDeEntrada(hit, parte, this.configuracion.suavizacionAngular, out flag2);
			}
			float num3 = this.zDamperMod;
			if (this.configuracion.endurecerAlPasarMaxProfundidadVirtual)
			{
				num3 = Mathf.Max(num3, this.GetCurrentModDeProfundidad());
			}
			if (this.configuracion.endurecerAlPasarMaxAperturaVirtual)
			{
				num3 *= this.GetCurrentModDeAnchuraVirtual();
			}
			float num4 = 0f;
			if (this.configuracion.devolverAlPasarMaxProfundidadVirtual)
			{
				num4 = this.GetCurrentModDeProfundidadSpring();
			}
			Vector3 lastColliderTipWorldPosition = parte.complementoCollider.GetLastColliderTipWorldPosition();
			Vector3 vector;
			float num5;
			Vector3 vector2;
			Vector3 vector3;
			Vector3 vector4;
			Vector3 vector5;
			float num6;
			float num7;
			this.m_GetTrayectoriaData(lastColliderTipWorldPosition, out vector, out num5, out vector2, out vector3, out vector4, out vector5, out num6, out num7);
			float num8 = Mathf.Min(num5, parte.maxWorldRadius) * 0.99f;
			Vector3 vector6 = lastColliderTipWorldPosition - vector;
			vector6 = ((vector6 == Vector3.zero) ? this.m_penetraciones.hole.worldUpHoleDirection : vector6.normalized);
			Vector3 vector7 = lastColliderTipWorldPosition + vector6 * num8;
			float num9 = Vector3.Distance(Math3d.ProjectPointOnConeSurfaceOrInside(vector4, vector5, num6, vector7, false, float.PositiveInfinity), vector7) / this.m_penetraciones.hole.worldScaleReal;
			float num10 = Mathf.InverseLerp(0f, this.configuracionConeTrayectorias.maxLocalDistanceFromCone, num9);
			num10 = Mathf.Lerp(this.configuracionConeTrayectorias.minWeigth, 1f, num10);
			float num11 = num10 * num;
			float num12 = num10 * num2;
			joint.xDrive = PenetrationJointCreator.GetDrive(this.configuracion.xDriveMassMod, this.configuracion.xDriveSpring * this.configuracionConeTrayectorias.driveMultiplier, this.configuracion.xSpringToDamper, physicBone.mass, num11);
			joint.yDrive = PenetrationJointCreator.GetDrive(this.configuracion.yDriveMassMod, this.configuracion.yDriveSpring * this.configuracionConeTrayectorias.driveMultiplier, this.configuracion.ySpringToDamper, physicBone.mass, num11);
			joint.zDrive = PenetrationJointCreator.GetZDrive(this.configuracion.zDriveMassMod, this.configuracion.zDriveDamperV2 * num3, physicBone.mass, num11, num4);
			joint.angularXDrive = PenetrationJointCreator.GetDrive(this.configuracion.xAngularDriveMassMod, this.configuracion.xAngularDriveSpring * this.configuracionConeTrayectorias.angularDriveMultiplier, this.configuracion.xAngularSpringToDamper, physicBone.mass, num12);
			joint.angularYZDrive = PenetrationJointCreator.GetDrive(this.configuracion.yzAngularDriveMassMod, this.configuracion.yzAngularDriveSpring * this.configuracionConeTrayectorias.angularDriveMultiplier, this.configuracion.yzAngularSpringToDamper, physicBone.mass, num12);
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00023B94 File Offset: 0x00021D94
		private void SetJointDriversV1(ConfigurableJoint joint, PenisPart parte, PenisPartHit hit)
		{
			Rigidbody physicBone = parte.physicBone;
			float num = 1f;
			bool flag = true;
			if (this.configuracion.suavizarAlEntrarHole)
			{
				num = this.GetCurrentModDeEntrada(hit, parte, this.configuracion.suavizacion, out flag);
			}
			float num2 = 1f;
			bool flag2 = true;
			if (this.configuracion.suavizarAlEntrarHoleAngular)
			{
				num2 = this.GetCurrentModDeEntrada(hit, parte, this.configuracion.suavizacionAngular, out flag2);
			}
			float num3 = this.zDamperMod;
			if (this.configuracion.endurecerAlPasarMaxProfundidadVirtual)
			{
				num3 = Mathf.Max(num3, this.GetCurrentModDeProfundidad());
			}
			if (this.configuracion.endurecerAlPasarMaxAperturaVirtual)
			{
				num3 *= this.GetCurrentModDeAnchuraVirtual();
			}
			float num4 = 0f;
			if (this.configuracion.devolverAlPasarMaxProfundidadVirtual)
			{
				num4 = this.GetCurrentModDeProfundidadSpring();
			}
			joint.xDrive = PenetrationJointCreator.GetDrive(this.configuracion.xDriveMassMod, this.configuracion.xDriveSpring, this.configuracion.xSpringToDamper, physicBone.mass, num);
			joint.yDrive = PenetrationJointCreator.GetDrive(this.configuracion.yDriveMassMod, this.configuracion.yDriveSpring, this.configuracion.ySpringToDamper, physicBone.mass, num);
			joint.zDrive = PenetrationJointCreator.GetZDrive(this.configuracion.zDriveMassMod, this.configuracion.zDriveDamperV2 * num3, physicBone.mass, num, num4);
			joint.angularXDrive = PenetrationJointCreator.GetDrive(this.configuracion.xAngularDriveMassMod, this.configuracion.xAngularDriveSpring, this.configuracion.xAngularSpringToDamper, physicBone.mass, num2);
			joint.angularYZDrive = PenetrationJointCreator.GetDrive(this.configuracion.yzAngularDriveMassMod, this.configuracion.yzAngularDriveSpring, this.configuracion.yzAngularSpringToDamper, physicBone.mass, num2);
			if (this.configuracion.lockAngularSiMaxAlcanzado && flag2)
			{
				joint.angularYZDrive = (joint.angularXDrive = new JointDrive
				{
					maximumForce = 3.402823E+38f,
					positionSpring = 1E+21f
				});
			}
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00023D94 File Offset: 0x00021F94
		private void ConfigurarJoint(ConfigurableJoint joint, PenisPart parte, BoneStretchedChain hole, PenisPartHit hit)
		{
			Rigidbody physicBone = parte.physicBone;
			joint.swapBodies = true;
			PenisPoint.Configuracion configuracion = parte.puntoConnectadoAEstaParte.configuracion;
			joint.axis = configuracion.jointAxisAdmin.localRightAxis;
			joint.secondaryAxis = configuracion.jointAxisAdmin.localUpAxis;
			joint.xMotion = ConfigurableJointMotion.Free;
			joint.yMotion = ConfigurableJointMotion.Free;
			joint.zMotion = ConfigurableJointMotion.Free;
			joint.angularXMotion = ConfigurableJointMotion.Free;
			joint.angularYMotion = ConfigurableJointMotion.Free;
			joint.angularZMotion = ConfigurableJointMotion.Free;
			joint.connectedBody = physicBone;
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = Vector3.zero;
			this.SetJointDrivers(joint, parte, hit);
			if (this.calcularTargetRotation)
			{
				Vector3 worldForward = parte.worldForward;
				Vector3 vector = -hole.worldOutHoleDirection;
				Vector3 worldUp = parte.worldUp;
				Vector3 vector2 = joint.transform.InverseTransformDirection(worldForward);
				Vector3 vector3 = joint.transform.InverseTransformDirection(vector);
				Vector3 vector4 = joint.transform.InverseTransformDirection(worldUp);
				Vector3 vector5 = joint.transform.InverseTransformDirection(worldUp);
				Quaternion quaternion = Quaternion.LookRotation(vector2, vector4);
				Quaternion quaternion2 = Quaternion.LookRotation(vector3, vector5);
				joint.targetRotation = quaternion2 * Quaternion.Inverse(quaternion);
			}
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00023EB0 File Offset: 0x000220B0
		public static JointDrive GetZDrive(float massMod, float damper, float mass, float mod, float toSpring)
		{
			JointDrive jointDrive = default(JointDrive);
			jointDrive.positionSpring = 0f;
			if (float.IsPositiveInfinity(damper))
			{
				jointDrive.positionDamper = float.MaxValue;
				if (toSpring > 0f && toSpring < 1f)
				{
					jointDrive.positionSpring = float.MaxValue * toSpring;
				}
				else
				{
					jointDrive.positionSpring = float.MaxValue;
				}
			}
			else
			{
				jointDrive.positionDamper = Mathf.Lerp(damper, mass * damper, massMod) * mod;
				jointDrive.positionSpring = jointDrive.positionDamper * toSpring;
			}
			jointDrive.maximumForce = 3.402823E+38f;
			PenetrationJointCreator.FixJointDrive(ref jointDrive);
			return jointDrive;
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00023F50 File Offset: 0x00022150
		public static JointDrive GetDrive(float massMod, float spring, float springToDamperMod, float mass, float mod)
		{
			JointDrive jointDrive = default(JointDrive);
			float num = Mathf.Lerp(spring, mass * spring, massMod);
			jointDrive.positionSpring = num * mod;
			jointDrive.positionDamper = num * springToDamperMod * mod;
			jointDrive.maximumForce = 3.402823E+38f;
			PenetrationJointCreator.FixJointDrive(ref jointDrive);
			return jointDrive;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00023F9C File Offset: 0x0002219C
		private static JointDrive GetDriveV2(float massMod, float spring, float springToDamperMod, float mass, float springMod, float damperMod)
		{
			JointDrive jointDrive = default(JointDrive);
			float num = Mathf.Lerp(spring, mass * spring, massMod);
			jointDrive.positionSpring = num * springMod;
			jointDrive.positionDamper = num * springToDamperMod * damperMod;
			jointDrive.maximumForce = 3.402823E+38f;
			PenetrationJointCreator.FixJointDrive(ref jointDrive);
			return jointDrive;
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00023FE8 File Offset: 0x000221E8
		private static void FixJointDrive(ref JointDrive drive)
		{
			drive.maximumForce = Mathf.Clamp(drive.maximumForce, float.MinValue, float.MaxValue);
			drive.positionSpring = Mathf.Clamp(drive.positionSpring, float.MinValue, float.MaxValue);
			drive.positionDamper = Mathf.Clamp(drive.positionDamper, float.MinValue, float.MaxValue);
		}

		// Token: 0x040005B7 RID: 1463
		public const float fondoHardPointRadiusMod = 0.2f;

		// Token: 0x040005B8 RID: 1464
		public float zDamperMod = 1f;

		// Token: 0x040005B9 RID: 1465
		public bool debug;

		// Token: 0x040005BA RID: 1466
		public bool calcularTargetRotation = true;

		// Token: 0x040005BB RID: 1467
		private bool m_initiated;

		// Token: 0x040005BC RID: 1468
		private Penetraciones m_penetraciones;

		// Token: 0x040005BD RID: 1469
		public PenetrationJointCreator.Configuracion configuracion = new PenetrationJointCreator.Configuracion();

		// Token: 0x040005BE RID: 1470
		public PenetrationJointCreator.ConfiguracionConeTrayectorias configuracionConeTrayectorias = new PenetrationJointCreator.ConfiguracionConeTrayectorias();

		// Token: 0x040005BF RID: 1471
		private Dictionary<PenisPart, ConfigurableJoint> m_historial = new Dictionary<PenisPart, ConfigurableJoint>();

		// Token: 0x040005C0 RID: 1472
		private Dictionary<PenisPart, ConfigurableJoint> m_historialAdentroDesactivados = new Dictionary<PenisPart, ConfigurableJoint>();

		// Token: 0x040005C1 RID: 1473
		private PenetrationJointCreator.GetConeTrayecotiaDataForDriverConfigHandler m_GetTrayectoriaData;

		// Token: 0x020001D8 RID: 472
		// (Invoke) Token: 0x06000F91 RID: 3985
		public delegate void GetConeTrayecotiaDataForDriverConfigHandler(Vector3 worldPoint, out Vector3 worldPointProyectedToEndStart, out float worldConeRadiusAtPoint, out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius);

		// Token: 0x020001D9 RID: 473
		[Serializable]
		public class ConfiguracionConeTrayectorias
		{
			// Token: 0x04000A5C RID: 2652
			public bool useToUpdateDrivers;

			// Token: 0x04000A5D RID: 2653
			public float driveMultiplier = 5f;

			// Token: 0x04000A5E RID: 2654
			public float angularDriveMultiplier = 5f;

			// Token: 0x04000A5F RID: 2655
			public float minWeigth = 0.01f;

			// Token: 0x04000A60 RID: 2656
			public float maxLocalDistanceFromCone = 0.01f;
		}

		// Token: 0x020001DA RID: 474
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000A61 RID: 2657
			[Range(0f, 1f)]
			public float xDriveMassMod = 1f;

			// Token: 0x04000A62 RID: 2658
			[Range(0f, 1f)]
			public float yDriveMassMod = 1f;

			// Token: 0x04000A63 RID: 2659
			[Range(0f, 1f)]
			public float zDriveMassMod = 1f;

			// Token: 0x04000A64 RID: 2660
			[Range(0f, 1f)]
			public float xAngularDriveMassMod = 1f;

			// Token: 0x04000A65 RID: 2661
			[Range(0f, 1f)]
			public float yzAngularDriveMassMod = 1f;

			// Token: 0x04000A66 RID: 2662
			[Obsolete("", true)]
			[NonSerialized]
			public float maxSpringToDamper = 0.1f;

			// Token: 0x04000A67 RID: 2663
			[Obsolete("", true)]
			[NonSerialized]
			public float maxAngularSpringToDamper = 2f;

			// Token: 0x04000A68 RID: 2664
			public float xDriveSpring = 20000000f;

			// Token: 0x04000A69 RID: 2665
			public float xSpringToDamper = 0.0005f;

			// Token: 0x04000A6A RID: 2666
			public float yDriveSpring = 20000000f;

			// Token: 0x04000A6B RID: 2667
			public float ySpringToDamper = 0.0005f;

			// Token: 0x04000A6C RID: 2668
			public float zDriveDamperToSpring = 3f;

			// Token: 0x04000A6D RID: 2669
			public float zDriveDamperV2 = 1500f;

			// Token: 0x04000A6E RID: 2670
			public float xAngularDriveSpring = 150f;

			// Token: 0x04000A6F RID: 2671
			public float xAngularSpringToDamper = 0.15f;

			// Token: 0x04000A70 RID: 2672
			public float yzAngularDriveSpring = 150f;

			// Token: 0x04000A71 RID: 2673
			public float yzAngularSpringToDamper = 0.15f;

			// Token: 0x04000A72 RID: 2674
			public bool lockAngularSiMaxAlcanzado = true;

			// Token: 0x04000A73 RID: 2675
			[Header("suavizado del joint")]
			public bool suavizarAlEntrarHole = true;

			// Token: 0x04000A74 RID: 2676
			public Suavizacion suavizacion = new Suavizacion
			{
				penetracionDeParteWParaMaxValores = 0.99f,
				inPower = 2f,
				mod = 1f
			};

			// Token: 0x04000A75 RID: 2677
			[Header("suavizado del joint")]
			public bool suavizarAlEntrarHoleAngular = true;

			// Token: 0x04000A76 RID: 2678
			public Suavizacion suavizacionAngular = new Suavizacion
			{
				penetracionDeParteWParaMaxValores = 0.99f,
				inPower = 2f,
				mod = 1f
			};

			// Token: 0x04000A77 RID: 2679
			[Header("endurecido del joint")]
			public bool endurecerAlPasarMaxProfundidadVirtual = true;

			// Token: 0x04000A78 RID: 2680
			public bool devolverAlPasarMaxProfundidadVirtual = true;

			// Token: 0x04000A79 RID: 2681
			public bool endurecerAlPasarMaxAperturaVirtual = true;

			// Token: 0x04000A7A RID: 2682
			[Header("hard points")]
			[Range(0f, 1f)]
			public float hardPointsMiddle = 0.75f;

			// Token: 0x04000A7B RID: 2683
			public float hardPointsSpring = 5f;

			// Token: 0x04000A7C RID: 2684
			public float hardPointsDamper = 25f;

			// Token: 0x04000A7D RID: 2685
			public float hardPointsInInPower = 3f;

			// Token: 0x04000A7E RID: 2686
			public float hardPointsOutOutPower = 3f;
		}
	}
}
