using System;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000F2 RID: 242
	public sealed class EstetoscopioPiel : PiezaDeRopaBase
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x0001BC3C File Offset: 0x00019E3C
		public bool enPosicionFinal
		{
			get
			{
				return this.m_estetoscopioEnPosicionFinal && this.m_orejerasEnPosicionFinal;
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001BC50 File Offset: 0x00019E50
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.estetoscopioRoot == null)
			{
				throw new ArgumentNullException("estetoscopioRoot", "estetoscopioRoot null reference.");
			}
			if (this.centroDeOregerasBone == null)
			{
				throw new ArgumentNullException("centroDeOregerasBone", "centroDeOregerasBone null reference.");
			}
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001BCA0 File Offset: 0x00019EA0
		protected override void Added(ArmatureSkins owner)
		{
			base.Added(owner);
			this.m_currentUser = owner.GetComponentEnRoot(false);
			if (this.m_currentUser == null)
			{
				throw new ArgumentNullException("@m_currentUser", "m_currentUserchar null reference.");
			}
			this.m_currentUserNeckDatos = this.m_currentUser.bones.neck;
			this.m_currentUserChestDatos = this.m_currentUser.bones.chest;
			this.m_currentUserHeadDatos = this.m_currentUser.bones.head;
			this.m_lastEstado = EstetoscopioPiel.Estado.toNeck;
			this.flagInstantMovement = true;
			this.SetToNeck();
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001BD38 File Offset: 0x00019F38
		protected override void Removed(ArmatureSkins owner)
		{
			base.Removed(owner);
			this.m_targetLastLossyScale = Vector3.zero;
			this.m_currentUser = null;
			this.m_currentUserNeckDatos = null;
			this.m_currentUserHeadDatos = null;
			this.m_currentUserChestDatos = null;
			this.m_estetoscopioEnPosicionFinal = (this.m_orejerasEnPosicionFinal = false);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001BD84 File Offset: 0x00019F84
		public void SetToEars()
		{
			Vector3 localEarFormHeadL = this.m_currentUser.localEarFormHeadL;
			Vector3 localEarFormHeadR = this.m_currentUser.localEarFormHeadR;
			Vector3 vector = (localEarFormHeadL + localEarFormHeadR) / 2f;
			DatosDeBoneBase currentUserHeadDatos = this.m_currentUserHeadDatos;
			this.centroDeOregerasBone.InverseTransformPoint(this.centroDeOregerasBone.position);
			Quaternion quaternion = this.ObtenerRotationGlobalOnHead();
			Vector3 vector2 = currentUserHeadDatos.transform.TransformPoint(vector);
			this.m_CurrentLocalSourceDeEstetoscopio.position = currentUserHeadDatos.transform.InverseTransformPoint(this.centroDeOregerasBone.position);
			this.m_CurrentLocalSourceDeEstetoscopio.rotation = Quaternion.Inverse(currentUserHeadDatos.transform.rotation) * this.centroDeOregerasBone.rotation;
			this.m_CurrentLocalTargetDeEstetoscopio.position = currentUserHeadDatos.transform.InverseTransformPoint(vector2);
			this.m_CurrentLocalTargetDeEstetoscopio.rotation = Quaternion.Inverse(currentUserHeadDatos.transform.rotation) * quaternion;
			this.m_CurrentLocalSourceDeOrejeraL = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraL.transform.position);
			this.m_CurrentLocalSourceDeOrejeraR = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraR.transform.position);
			Vector3 vector3 = currentUserHeadDatos.transform.TransformPoint(localEarFormHeadL);
			Vector3 vector4 = currentUserHeadDatos.transform.TransformPoint(localEarFormHeadR);
			float num = Vector3.Distance(vector3, vector4) * 0.5f * this.orejerasApertureMod;
			float num2 = Vector3.Distance(this.orejeraL.transform.position, this.centroDeOregerasBone.position);
			float num3 = Vector3.Distance(this.orejeraR.transform.position, this.centroDeOregerasBone.position);
			this.m_CurrentLocalTargetDeOrejeraL = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraL.transform.TransformPoint(-this.orejeraL.rootBone.boneLocalForward * (num - num2)));
			this.m_CurrentLocalTargetDeOrejeraR = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraR.transform.TransformPoint(-this.orejeraR.rootBone.boneLocalForward * (num - num3)));
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001BFAC File Offset: 0x0001A1AC
		private Quaternion ObtenerRotationGlobalOnHead()
		{
			return Quaternion.LookRotation(Math3d.ProjectVectorOnPlane(this.m_currentUserChestDatos.currentUp, this.m_currentUserHeadDatos.currentForward), this.m_currentUserHeadDatos.currentUp) * Quaternion.Euler(this.headEstadoConfig.angleOffSet);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001BFF9 File Offset: 0x0001A1F9
		private Quaternion ObtenerRotationLocalOnHead()
		{
			return Quaternion.Inverse(this.m_currentUserHeadDatos.transform.rotation) * this.ObtenerRotationGlobalOnHead();
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0001C01C File Offset: 0x0001A21C
		public void SetToNeck()
		{
			DatosDeNeck currentUserNeckDatos = this.m_currentUserNeckDatos;
			Matrix4x4 identity = Matrix4x4.identity;
			Quaternion quaternion = currentUserNeckDatos.initialCurrentWorldRotationDesdeChest;
			identity.SetTRS(currentUserNeckDatos.initialCurrentWorldPositionDesdeChest, quaternion, currentUserNeckDatos.transform.lossyScale);
			Vector3 vector = identity.MultiplyPoint3x4(this.neckEstadoConfig.offset);
			quaternion *= Quaternion.Euler(this.neckEstadoConfig.angleOffSet);
			this.m_CurrentLocalSourceDeEstetoscopio.position = this.m_currentUserChestDatos.transform.InverseTransformPoint(this.centroDeOregerasBone.position);
			this.m_CurrentLocalSourceDeEstetoscopio.rotation = Quaternion.Inverse(this.m_currentUserChestDatos.transform.rotation) * this.centroDeOregerasBone.rotation;
			this.m_CurrentLocalTargetDeEstetoscopio.position = this.m_currentUserChestDatos.transform.InverseTransformPoint(vector);
			this.m_CurrentLocalTargetDeEstetoscopio.rotation = Quaternion.Inverse(this.m_currentUserChestDatos.transform.rotation) * quaternion;
			this.m_CurrentLocalSourceDeOrejeraL = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraL.transform.position);
			this.m_CurrentLocalSourceDeOrejeraR = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraR.transform.position);
			this.m_CurrentLocalTargetDeOrejeraL = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraL.transform.parent.TransformPoint(this.orejeraL.initialLocalPosition));
			this.m_CurrentLocalTargetDeOrejeraR = this.centroDeOregerasBone.InverseTransformPoint(this.orejeraL.transform.parent.TransformPoint(this.orejeraR.initialLocalPosition));
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0001C1BC File Offset: 0x0001A3BC
		private float AnimationCurveLargo(AnimationCurve curve)
		{
			return curve[curve.length - 1].time;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001C1E0 File Offset: 0x0001A3E0
		private void UpdateRoot()
		{
			EstetoscopioPiel.Estado estado = this.estado;
			AnimationCurve animationCurve;
			AnimationCurve animationCurve2;
			DatosDeBoneBase datosDeBoneBase;
			if (estado != EstetoscopioPiel.Estado.toNeck)
			{
				if (estado != EstetoscopioPiel.Estado.toEars)
				{
					throw new ArgumentOutOfRangeException(this.estado.ToString());
				}
				animationCurve = this.curvasConfig.toEarsCentro;
				animationCurve2 = this.curvasConfig.toEarsOrejeras;
				datosDeBoneBase = this.m_currentUserHeadDatos;
				this.m_CurrentLocalTargetDeEstetoscopio.rotation = this.ObtenerRotationLocalOnHead();
			}
			else
			{
				animationCurve = this.curvasConfig.toNeckCentro;
				animationCurve2 = this.curvasConfig.toNeckOrejeras;
				datosDeBoneBase = this.m_currentUserChestDatos;
			}
			if (animationCurve.length <= 1)
			{
				throw new NotSupportedException();
			}
			if (animationCurve2.length <= 1)
			{
				throw new NotSupportedException();
			}
			if (this.flagInstantMovement || this.m_estetoscopioEnPosicionFinal)
			{
				this.centroDeOregerasBone.position = datosDeBoneBase.transform.TransformPoint(this.m_CurrentLocalTargetDeEstetoscopio.position);
				this.centroDeOregerasBone.rotation = datosDeBoneBase.transform.rotation * this.m_CurrentLocalTargetDeEstetoscopio.rotation;
				this.m_estetoscopioEnPosicionFinal = true;
			}
			else
			{
				float num = Mathf.Abs(Time.time - this.m_lastStartTime);
				float num2 = Mathf.InverseLerp(0f, this.timeToChangeState, num);
				float num3 = Mathf.Lerp(0f, this.AnimationCurveLargo(animationCurve), num2);
				num3 = animationCurve.Evaluate(num3);
				Vector3 vector = Vector3.LerpUnclamped(this.m_CurrentLocalSourceDeEstetoscopio.position, this.m_CurrentLocalTargetDeEstetoscopio.position, num3);
				Quaternion quaternion = Quaternion.LerpUnclamped(this.m_CurrentLocalSourceDeEstetoscopio.rotation, this.m_CurrentLocalTargetDeEstetoscopio.rotation, num3);
				this.centroDeOregerasBone.position = datosDeBoneBase.transform.TransformPoint(vector);
				this.centroDeOregerasBone.rotation = datosDeBoneBase.transform.rotation * quaternion;
				if (num2 >= 1f)
				{
					this.m_estetoscopioEnPosicionFinal = true;
				}
			}
			Vector3 lossyScale = datosDeBoneBase.transform.lossyScale;
			if (this.m_targetLastLossyScale != lossyScale)
			{
				this.m_targetLastLossyScale = lossyScale;
				this.centroDeOregerasBone.localScale = Vector3.Scale(lossyScale, Vector3.one * this.initialScale);
			}
			if (this.flagInstantMovement || this.m_orejerasEnPosicionFinal)
			{
				this.orejeraL.transform.position = this.centroDeOregerasBone.TransformPoint(this.m_CurrentLocalTargetDeOrejeraL);
				this.orejeraR.transform.position = this.centroDeOregerasBone.TransformPoint(this.m_CurrentLocalTargetDeOrejeraR);
				this.m_orejerasEnPosicionFinal = true;
			}
			else
			{
				float num4 = Mathf.Abs(Time.time - this.m_lastStartTime);
				float num5 = Mathf.InverseLerp(0f, this.timeToChangeStateOrejeras, num4);
				float num6 = Mathf.Lerp(0f, this.AnimationCurveLargo(animationCurve2), num5);
				num6 = animationCurve2.Evaluate(num6);
				Vector3 vector2 = Vector3.LerpUnclamped(this.m_CurrentLocalSourceDeOrejeraL, this.m_CurrentLocalTargetDeOrejeraL, num6);
				Vector3 vector3 = Vector3.LerpUnclamped(this.m_CurrentLocalSourceDeOrejeraR, this.m_CurrentLocalTargetDeOrejeraR, num6);
				this.orejeraL.transform.position = this.centroDeOregerasBone.TransformPoint(vector2);
				this.orejeraR.transform.position = this.centroDeOregerasBone.TransformPoint(vector3);
				if (num5 >= 1f)
				{
					this.m_orejerasEnPosicionFinal = true;
				}
			}
			this.flagInstantMovement = false;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0001C518 File Offset: 0x0001A718
		public void ActualizarEstado()
		{
			if (!base.skinIsAdded)
			{
				return;
			}
			if (this.estado == this.m_lastEstado)
			{
				return;
			}
			this.m_estetoscopioEnPosicionFinal = (this.m_orejerasEnPosicionFinal = false);
			this.m_lastStartTime = Time.time;
			this.m_lastEstado = this.estado;
			EstetoscopioPiel.Estado estado = this.estado;
			if (estado == EstetoscopioPiel.Estado.toNeck)
			{
				this.SetToNeck();
				return;
			}
			if (estado != EstetoscopioPiel.Estado.toEars)
			{
				throw new ArgumentOutOfRangeException(this.estado.ToString());
			}
			this.SetToEars();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0001C598 File Offset: 0x0001A798
		public void ActualizarTransforms()
		{
			if (!base.skinIsAdded)
			{
				return;
			}
			this.UpdateRoot();
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001C5A9 File Offset: 0x0001A7A9
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Set ToNeck",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0001C5C4 File Offset: 0x0001A7C4
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.m_lastEstado = (this.estado = EstetoscopioPiel.Estado.toNeck);
			this.flagInstantMovement = true;
			this.SetToNeck();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Set ToEars",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0001C610 File Offset: 0x0001A810
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.m_lastEstado = (this.estado = EstetoscopioPiel.Estado.toEars);
			this.flagInstantMovement = true;
			this.SetToEars();
		}

		// Token: 0x040003EC RID: 1004
		public float timeToChangeState = 0.9f;

		// Token: 0x040003ED RID: 1005
		public float timeToChangeStateOrejeras = 0.9f;

		// Token: 0x040003EE RID: 1006
		public float initialScale = 0.75f;

		// Token: 0x040003EF RID: 1007
		public float orejerasApertureMod = 1.25f;

		// Token: 0x040003F0 RID: 1008
		public EstetoscopioPiel.Estado estado;

		// Token: 0x040003F1 RID: 1009
		public EstetoscopioPiel.CurvasConfig curvasConfig = new EstetoscopioPiel.CurvasConfig();

		// Token: 0x040003F2 RID: 1010
		public EstetoscopioPiel.EstadoConfig neckEstadoConfig = new EstetoscopioPiel.EstadoConfig
		{
			angleOffSet = new Vector3(218f, 0f, 0f),
			offset = new Vector3(0f, 0.058f, -0.04f)
		};

		// Token: 0x040003F3 RID: 1011
		public EstetoscopioPiel.EstadoConfig headEstadoConfig = new EstetoscopioPiel.EstadoConfig
		{
			angleOffSet = new Vector3(235f, 0f, 0f),
			offset = new Vector3(0f, 0f, 0f)
		};

		// Token: 0x040003F4 RID: 1012
		private EstetoscopioPiel.Estado m_lastEstado;

		// Token: 0x040003F5 RID: 1013
		private EstetoscopioPiel.TransformEstado m_CurrentLocalSourceDeEstetoscopio;

		// Token: 0x040003F6 RID: 1014
		private EstetoscopioPiel.TransformEstado m_CurrentLocalTargetDeEstetoscopio;

		// Token: 0x040003F7 RID: 1015
		private Vector3 m_CurrentLocalSourceDeOrejeraL;

		// Token: 0x040003F8 RID: 1016
		private Vector3 m_CurrentLocalTargetDeOrejeraL;

		// Token: 0x040003F9 RID: 1017
		private Vector3 m_CurrentLocalSourceDeOrejeraR;

		// Token: 0x040003FA RID: 1018
		private Vector3 m_CurrentLocalTargetDeOrejeraR;

		// Token: 0x040003FB RID: 1019
		[SerializeField]
		private Transform estetoscopioRoot;

		// Token: 0x040003FC RID: 1020
		[SerializeField]
		private Transform centroDeOregerasBone;

		// Token: 0x040003FD RID: 1021
		[SerializeField]
		private BoneHijo orejeraL;

		// Token: 0x040003FE RID: 1022
		[SerializeField]
		private BoneHijo orejeraR;

		// Token: 0x040003FF RID: 1023
		private AnimatorCharacter m_currentUser;

		// Token: 0x04000400 RID: 1024
		private DatosDeNeck m_currentUserNeckDatos;

		// Token: 0x04000401 RID: 1025
		private DatosDeBoneBase m_currentUserChestDatos;

		// Token: 0x04000402 RID: 1026
		private DatosDeBoneBase m_currentUserHeadDatos;

		// Token: 0x04000403 RID: 1027
		private Vector3 m_targetLastLossyScale;

		// Token: 0x04000404 RID: 1028
		public bool flagInstantMovement;

		// Token: 0x04000405 RID: 1029
		private float m_lastStartTime;

		// Token: 0x04000406 RID: 1030
		[SerializeField]
		[ReadOnlyUI]
		private bool m_estetoscopioEnPosicionFinal;

		// Token: 0x04000407 RID: 1031
		[SerializeField]
		[ReadOnlyUI]
		private bool m_orejerasEnPosicionFinal;

		// Token: 0x020000F3 RID: 243
		[Serializable]
		public class EstadoConfig
		{
			// Token: 0x04000408 RID: 1032
			public Vector3 angleOffSet;

			// Token: 0x04000409 RID: 1033
			public Vector3 offset;
		}

		// Token: 0x020000F4 RID: 244
		[Serializable]
		public struct TransformEstado
		{
			// Token: 0x0400040A RID: 1034
			public Vector3 position;

			// Token: 0x0400040B RID: 1035
			public Quaternion rotation;
		}

		// Token: 0x020000F5 RID: 245
		[Serializable]
		public class CurvasConfig
		{
			// Token: 0x0400040C RID: 1036
			public AnimationCurve toNeckCentro;

			// Token: 0x0400040D RID: 1037
			public AnimationCurve toEarsCentro;

			// Token: 0x0400040E RID: 1038
			public AnimationCurve toNeckOrejeras;

			// Token: 0x0400040F RID: 1039
			public AnimationCurve toEarsOrejeras;
		}

		// Token: 0x020000F6 RID: 246
		public enum Estado
		{
			// Token: 0x04000411 RID: 1041
			toNeck,
			// Token: 0x04000412 RID: 1042
			toEars
		}
	}
}
