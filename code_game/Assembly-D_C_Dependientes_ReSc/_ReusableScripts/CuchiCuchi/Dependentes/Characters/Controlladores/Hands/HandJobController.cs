using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.Interacciones;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.ArmaduresSkins;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Interactables.Penetradores;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200025C RID: 604
	public class HandJobController : ControllerColaDePrioridadBase<HandJobController.Estado, HandJobController.Orden, HandJobController.Cola, HandJobController, int>
	{
		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x00047639 File Offset: 0x00045839
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates3);
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x00023905 File Offset: 0x00021B05
		protected override int cantidadDeEstados
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000FE6 RID: 4070 RVA: 0x00047644 File Offset: 0x00045844
		// (remove) Token: 0x06000FE7 RID: 4071 RVA: 0x0004767C File Offset: 0x0004587C
		public event HandJobController.OnUpdateHandJobOrdenHandler onJobHandlerUpdate;

		// Token: 0x06000FE8 RID: 4072 RVA: 0x000476B4 File Offset: 0x000458B4
		private void onUpdateHandJobOrdenHandler(Vector3 velocidadPhyscis, Vector3 recorridoPosition, Quaternion recoridoRotation, float recorridoVelocidad, float recorridoWeigth, bool comenzando, bool terminando, bool terminada, ICharacter por, HitSkin porHand, ICharacter to, Penetrador toPenetrator)
		{
			HandJobController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onJobHandlerUpdate;
			if (onUpdateHandJobOrdenHandler == null)
			{
				return;
			}
			onUpdateHandJobOrdenHandler(velocidadPhyscis, recorridoPosition, recoridoRotation, recorridoVelocidad, recorridoWeigth, comenzando, terminando, terminada, por, porHand, to, toPenetrator);
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x000476E8 File Offset: 0x000458E8
		protected override void AwakeUnityEvent()
		{
			this.m_onJobHandlerUpdateProxy = new HandJobController.OnUpdateHandJobOrdenHandler(this.onUpdateHandJobOrdenHandler);
			base.AwakeUnityEvent();
			this.m_interacciones = this.GetComponentEnRoot(false);
			if (this.m_interacciones == null)
			{
				throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
			}
			this.m_HandPickController = this.GetComponentEnRoot(false);
			if (this.m_HandPickController == null)
			{
				throw new ArgumentNullException("m_HandPickController", "m_HandPickController null reference.");
			}
			this.m_PuppetMaster = this.GetComponentEnRoot(false);
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			this.m_FemaleSkins = this.GetComponentEnRoot(false);
			if (this.m_FemaleSkins == null)
			{
				throw new ArgumentNullException("m_FemaleSkins", "m_FemaleSkins null reference.");
			}
			this.m_AnimatorCharacter = this.GetComponentEnRoot(false);
			if (this.m_AnimatorCharacter == null)
			{
				throw new ArgumentNullException("m_AnimatorCharacter", "m_AnimatorCharacter null reference.");
			}
			this.m_Deseos = this.GetComponentEnRoot(false);
			if (this.m_Deseos == null)
			{
				throw new ArgumentNullException("m_Deseos", "m_Deseos null reference.");
			}
			this.m_FemaleSimpleAi = this.GetComponentEnRoot(false);
			if (this.m_FemaleSimpleAi == null)
			{
				throw new ArgumentNullException("m_FemaleSimpleAi", "m_FemaleSimpleAi null reference.");
			}
			this.m_respirador = this.GetComponentEnRoot(false);
			if (this.m_respirador == null)
			{
				throw new ArgumentNullException("m_respirador", "m_respirador null reference.");
			}
			FemaleFullBodyBipedIKs componentEnRoot = this.GetComponentEnRoot(false);
			TurnOffIKIfNoInteraction turnOffIKIfNoInteraction;
			if (componentEnRoot == null)
			{
				turnOffIKIfNoInteraction = null;
			}
			else
			{
				FullBodyBipedIK fullBodyBipedIK = componentEnRoot.terciarios.First<FullBodyBipedIK>();
				turnOffIKIfNoInteraction = ((fullBodyBipedIK != null) ? fullBodyBipedIK.GetComponent<TurnOffIKIfNoInteraction>() : null);
			}
			this.m_layer3IkTurnerOff = turnOffIKIfNoInteraction;
			if (this.m_layer3IkTurnerOff == null)
			{
				throw new ArgumentNullException("m_layer3IkTurnerOff", "m_layer3IkTurnerOff null reference.");
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x000478A4 File Offset: 0x00045AA4
		public bool DoToConApoyoAutomatico(MaleChar todo, Side handJobSide, float velocidad, float slowDownVelocity, float duracion, int prioridad, ControllerPrioridadConfig priConfig)
		{
			Quaternion armatureOrientationOffSet = todo.armatureOrientationOffSet;
			RecorridoDeMassgeOnMaleBody componentEnRoot = todo.GetComponentEnRoot<RecorridoDeMassgeOnMaleBody>();
			float estatura = this.m_AnimatorCharacter.estatura;
			Side side;
			Vector3 vector;
			Quaternion quaternion;
			if (handJobSide != Side.L)
			{
				if (handJobSide != Side.R)
				{
					throw new ArgumentOutOfRangeException(handJobSide.ToString());
				}
				side = handJobSide;
				DatosDeHumanBone shoulderL = this.m_AnimatorCharacter.bones.shoulderL;
				vector = shoulderL.posicionFinal;
				quaternion = shoulderL.rotacionFinal * shoulderL.offSetToForward;
			}
			else
			{
				side = handJobSide;
				DatosDeHumanBone shoulderR = this.m_AnimatorCharacter.bones.shoulderR;
				vector = shoulderR.posicionFinal;
				quaternion = shoulderR.rotacionFinal * shoulderR.offSetToForward;
			}
			PuntoDeApoyoSobreMaleBody? puntoDeApoyoSobreMaleBody = null;
			float num = float.MinValue;
			foreach (object obj in typeof(PuntoDeApoyoSobreMaleBody).GetEnumValoresLimpiosObject())
			{
				PuntoDeApoyoSobreMaleBody puntoDeApoyoSobreMaleBody2 = (PuntoDeApoyoSobreMaleBody)obj;
				Transform apoyo = componentEnRoot.GetApoyo(puntoDeApoyoSobreMaleBody2, side);
				float num2 = Vector3.Angle(apoyo.rotation * armatureOrientationOffSet * -Vector3.forward, quaternion * Vector3.forward);
				float num3 = Vector3.Distance(vector, apoyo.position);
				float num4 = Mathf.InverseLerp(180f, 0f, num2).InPow(3f);
				float num5 = Mathf.InverseLerp(estatura, 0f, num3).InPow(3f);
				float num6 = num4 * num5;
				if (num6 > num)
				{
					puntoDeApoyoSobreMaleBody = new PuntoDeApoyoSobreMaleBody?(puntoDeApoyoSobreMaleBody2);
					num = num6;
				}
			}
			return this.DoTo(todo, handJobSide, (num > 0f) ? puntoDeApoyoSobreMaleBody : null, velocidad, slowDownVelocity, duracion, prioridad, priConfig);
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x00047A7C File Offset: 0x00045C7C
		public bool DoTo(MaleChar todo, Side handJobSide, PuntoDeApoyoSobreMaleBody? apoyo, float velocidad, float slowDownVelocity, float duracion, int prioridad, ControllerPrioridadConfig priConfig)
		{
			MaleSkins componentEnRoot = todo.GetComponentEnRoot<MaleSkins>();
			if (componentEnRoot == null)
			{
				Debug.LogError("no se encontro skin de male en personaje " + todo.nombreCompleto, this);
				return false;
			}
			PuppetMaster componentEnRoot2 = todo.GetComponentEnRoot<PuppetMaster>();
			if (componentEnRoot2 == null)
			{
				Debug.LogError("no se encontro puppet de male en personaje " + todo.nombreCompleto, this);
				return false;
			}
			HandJobController.JobHandData jobHandData = new HandJobController.JobHandData();
			HandJobController.RestHandData restHandData = new HandJobController.RestHandData();
			restHandData.apoyo = ((apoyo != null) ? apoyo.Value : PuntoDeApoyoSobreMaleBody.None);
			restHandData.skeletonOffsetRotation = todo.armatureOrientationOffSet;
			int num;
			string text;
			string text2;
			InteraccionSegundariaName interaccionSegundariaName;
			Side side;
			InteraccionSegundariaName interaccionSegundariaName2;
			if (handJobSide != Side.L)
			{
				if (handJobSide != Side.R)
				{
					throw new ArgumentOutOfRangeException(handJobSide.ToString());
				}
				num = 1;
				text = "tvalle.inter.HandJobGrabInMaleR";
				text2 = "tvalle.inter.HandJobInMaleR";
				interaccionSegundariaName = InteraccionSegundariaName.apoyarHandL;
				side = handJobSide;
				interaccionSegundariaName2 = InteraccionSegundariaName.lockBodyButHandR;
				jobHandData.picker = this.m_HandPickController.r;
				jobHandData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand);
				jobHandData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerArm);
				jobHandData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperArm);
				jobHandData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.r;
				restHandData.picker = this.m_HandPickController.l;
				restHandData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand);
				restHandData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerArm);
				restHandData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperArm);
				restHandData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.l;
			}
			else
			{
				num = 0;
				text = "tvalle.inter.HandJobGrabInMaleL";
				text2 = "tvalle.inter.HandJobInMaleL";
				interaccionSegundariaName = InteraccionSegundariaName.apoyarHandR;
				side = handJobSide;
				interaccionSegundariaName2 = InteraccionSegundariaName.lockBodyButHandL;
				jobHandData.picker = this.m_HandPickController.l;
				jobHandData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand);
				jobHandData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerArm);
				jobHandData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperArm);
				jobHandData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.l;
				restHandData.picker = this.m_HandPickController.r;
				restHandData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand);
				restHandData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerArm);
				restHandData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperArm);
				restHandData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.r;
			}
			RecorridoDeLinearesOnMaleBody componentInChildren = todo.GetComponentInChildren<RecorridoDeLinearesOnMaleBody>();
			if (componentInChildren == null)
			{
				Debug.LogError("no se encontro recorridos en personaje " + todo.nombreCompleto, this);
				return false;
			}
			RecorridoDeMassgeOnMaleBody componentInChildren2 = todo.GetComponentInChildren<RecorridoDeMassgeOnMaleBody>();
			if (componentInChildren2 == null)
			{
				Debug.LogError("no se encontro recorridos en personaje " + todo.nombreCompleto, this);
				return false;
			}
			InteraccionRootRecorridoLinear peneVirtual = componentInChildren.peneVirtual;
			RecorridoLinearDePenetradorVirtual recorridoLinearDePenetradorVirtual = ((peneVirtual != null) ? peneVirtual.GetComponent<RecorridoLinearDePenetradorVirtual>() : null);
			if (recorridoLinearDePenetradorVirtual == null)
			{
				Debug.LogError("no se encontro recorrido virtual en personaje " + todo.nombreCompleto, this);
				return false;
			}
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = this.m_interacciones.Obtener(text.GetHashCode());
			if (((interaccionDeCharacterFemenino != null) ? interaccionDeCharacterFemenino.instancia : null) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Personaje: ",
					this.m_interacciones.character.nombreCompleto,
					" no tiene interaccion ",
					text,
					" de id ",
					text.GetHashCode().ToString()
				}), this);
				return false;
			}
			jobHandData.grabInter = interaccionDeCharacterFemenino.instancia;
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino2 = this.m_interacciones.Obtener(text2.GetHashCode());
			if (((interaccionDeCharacterFemenino2 != null) ? interaccionDeCharacterFemenino2.instancia : null) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Personaje: ",
					this.m_interacciones.character.nombreCompleto,
					" no tiene interaccion ",
					text2,
					" de id ",
					text2.GetHashCode().ToString()
				}), this);
				return false;
			}
			jobHandData.jobInter = interaccionDeCharacterFemenino2.instancia;
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino3 = this.m_interacciones.Obtener(interaccionSegundariaName2.GetInteractionID());
			if (((interaccionDeCharacterFemenino3 != null) ? interaccionDeCharacterFemenino3.instancia : null) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Personaje: ",
					this.m_interacciones.character.nombreCompleto,
					" no tiene interaccion ",
					interaccionSegundariaName2.ToString(),
					" de id ",
					interaccionSegundariaName2.GetInteractionID().ToString()
				}), this);
				return false;
			}
			jobHandData.lockInter = interaccionDeCharacterFemenino3.instancia;
			jobHandData.pivotsGrab = jobHandData.grabInter.GetComponentInChildren<SurfaceAndCenterPivotDeInteraction>();
			if (jobHandData.pivotsGrab == null)
			{
				Debug.LogError("no se encontro pivots en interaccion grab: " + text, this);
				return false;
			}
			jobHandData.pivotsJob = jobHandData.jobInter.GetComponentInChildren<SurfaceAndCenterPivotDeInteraction>();
			if (jobHandData.pivotsJob == null)
			{
				Debug.LogError("no se encontro pivots en interaccion grab: " + text2, this);
				return false;
			}
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino4 = this.m_interacciones.Obtener(interaccionSegundariaName.GetInteractionID());
			if (((interaccionDeCharacterFemenino4 != null) ? interaccionDeCharacterFemenino4.instancia : null) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Personaje: ",
					this.m_interacciones.character.nombreCompleto,
					" no tiene interaccion ",
					interaccionSegundariaName.ToString(),
					" de id ",
					interaccionSegundariaName.GetInteractionID().ToString()
				}), this);
				return false;
			}
			restHandData.restInter = interaccionDeCharacterFemenino4.instancia;
			restHandData.restPivot = restHandData.restInter.GetComponentInChildren<SurfacePivotDeInteraction>();
			if (restHandData.restPivot == null)
			{
				Debug.LogError("no se encontro pivots en interaccion grab: " + interaccionSegundariaName.ToString(), this);
				return false;
			}
			if (restHandData.apoyo != PuntoDeApoyoSobreMaleBody.None)
			{
				restHandData.guiaApoyo = componentInChildren2.GetApoyo(restHandData.apoyo, side);
				if (restHandData.guiaApoyo == null)
				{
					Debug.LogError("no se encontro guia transform: " + restHandData.apoyo.ToString(), this);
					return false;
				}
			}
			bool flag = false;
			HandJobController.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, num, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			HandJobController.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, num, out tipoDeReUsoDeOrden) && orden2.recorridoDePenetrador == recorridoLinearDePenetradorVirtual && orden2.jobHandData.IgualA(jobHandData) && (orden2.restHandData == null || orden2.restHandData.IgualA(restHandData)))
			{
				orden2.velocidad = velocidad;
				orden2.slowDownVelocity = slowDownVelocity;
				base.AcumularseORevivir(orden2, duracion, prioridad, tipoDeReUsoDeOrden, null, null);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			HandJobController.Orden orden3 = new HandJobController.Orden(componentEnRoot, componentEnRoot2, jobHandData, (restHandData.apoyo == PuntoDeApoyoSobreMaleBody.None) ? null : restHandData, recorridoLinearDePenetradorVirtual, this.m_onJobHandlerUpdateProxy, velocidad, slowDownVelocity, num, prioridad, duracion, priConfig, false);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseTipoIdToindex(int id)
		{
			return id;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x0003011F File Offset: 0x0002E31F
		protected override HandJobController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x000481D1 File Offset: 0x000463D1
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "try on current Main",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x000481EA File Offset: 0x000463EA
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.DoToConApoyoAutomatico(CurrentMainCharacter<CurrentMainChar, MainChar>.current.character as MaleChar, Side.R, 1f, 0f, -1f, 0, ControllerPrioridadConfig.prioridad);
		}

		// Token: 0x04000B40 RID: 2880
		public const float minVelocity = 0.25f;

		// Token: 0x04000B41 RID: 2881
		public const float medVelocity = 1f;

		// Token: 0x04000B42 RID: 2882
		public const float maxVelocity = 5f;

		// Token: 0x04000B43 RID: 2883
		public const string handJobGrabInterLId = "tvalle.inter.HandJobGrabInMaleL";

		// Token: 0x04000B44 RID: 2884
		public const string handJobGrabInterRId = "tvalle.inter.HandJobGrabInMaleR";

		// Token: 0x04000B45 RID: 2885
		public const string handJobInterLId = "tvalle.inter.HandJobInMaleL";

		// Token: 0x04000B46 RID: 2886
		public const string handJobInterRId = "tvalle.inter.HandJobInMaleR";

		// Token: 0x04000B48 RID: 2888
		private ICharacterRespirador m_respirador;

		// Token: 0x04000B49 RID: 2889
		private IInteraccionesDeCharacterFemenino m_interacciones;

		// Token: 0x04000B4A RID: 2890
		private HandPickController m_HandPickController;

		// Token: 0x04000B4B RID: 2891
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000B4C RID: 2892
		private FemaleSkins m_FemaleSkins;

		// Token: 0x04000B4D RID: 2893
		private AnimatorCharacter m_AnimatorCharacter;

		// Token: 0x04000B4E RID: 2894
		private Deseos m_Deseos;

		// Token: 0x04000B4F RID: 2895
		private TurnOffIKIfNoInteraction m_layer3IkTurnerOff;

		// Token: 0x04000B50 RID: 2896
		private FemaleSimpleAi m_FemaleSimpleAi;

		// Token: 0x04000B51 RID: 2897
		private HandJobController.OnUpdateHandJobOrdenHandler m_onJobHandlerUpdateProxy;

		// Token: 0x0200025D RID: 605
		// (Invoke) Token: 0x06000FF3 RID: 4083
		public delegate void OnUpdateHandJobOrdenHandler(Vector3 velocidadPhyscis, Vector3 recorridoPosition, Quaternion recoridoRotation, float recorridoVelocidad, float recorridoWeigth, bool comenzando, bool terminando, bool terminada, ICharacter por, HitSkin porHand, ICharacter to, Penetrador toPenetrator);

		// Token: 0x0200025E RID: 606
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<HandJobController.Estado, HandJobController.Orden, HandJobController.Cola, HandJobController, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000FF6 RID: 4086 RVA: 0x00048224 File Offset: 0x00046424
			public Orden(MaleSkins targetSkins, PuppetMaster targetPuppet, HandJobController.JobHandData jobHandData, HandJobController.RestHandData restHandData, RecorridoLinearDePenetradorVirtual RecorridoDePenetrador, HandJobController.OnUpdateHandJobOrdenHandler OnUpdated, float Velocidad, float SlowDownVelocity, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, bool duracionEsFixed = false)
				: base(tipoId, prioridad, duracion, priConfig, duracionEsFixed)
			{
				if (targetSkins == null)
				{
					throw new ArgumentNullException("target", "target null reference.");
				}
				if (RecorridoDePenetrador == null)
				{
					throw new ArgumentNullException("recorridoDePenetrador", "recorridoDePenetrador null reference.");
				}
				jobHandData.CheckAndThorw();
				if (restHandData != null)
				{
					restHandData.CheckAndThorw();
				}
				this.slowDownVelocity = SlowDownVelocity;
				this.m_targetSkins = targetSkins;
				this.m_targetPuppet = targetPuppet;
				this.m_jobHandData = jobHandData;
				this.m_restHandData = restHandData;
				this.m_usaRest = this.m_restHandData != null;
				this.m_recorridoDePenetrador = RecorridoDePenetrador;
				this.velocidad = Velocidad;
				this.onUpdated = OnUpdated;
			}

			// Token: 0x170003F8 RID: 1016
			// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x0004836E File Offset: 0x0004656E
			public RecorridoLinearDePenetradorVirtual recorridoDePenetrador
			{
				get
				{
					return this.m_recorridoDePenetrador;
				}
			}

			// Token: 0x170003F9 RID: 1017
			// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x00048376 File Offset: 0x00046576
			public HandJobController.JobHandData jobHandData
			{
				get
				{
					return this.m_jobHandData;
				}
			}

			// Token: 0x06000FF9 RID: 4089 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnDetenidaPorUsuario(HandJobController dataUpdate)
			{
			}

			// Token: 0x06000FFA RID: 4090 RVA: 0x00048380 File Offset: 0x00046580
			protected override bool OnTerminando(HandJobController dataUpdate, bool primerUpdate, HandJobController.Orden ordenEsperandoDetencion)
			{
				if (this.m_GenericPenetrationJointCreator != null)
				{
					Object.Destroy(this.m_GenericPenetrationJointCreator);
					this.m_GenericPenetrationJointCreator = null;
				}
				if (this.m_handMuscleToHandInterJoint != null)
				{
					Object.Destroy(this.m_handMuscleToHandInterJoint);
					this.m_handMuscleToHandInterJoint = null;
				}
				if (this.m_penetrationKinematic != null)
				{
					Object.Destroy(this.m_penetrationKinematic);
					this.m_penetrationKinematic = null;
				}
				if (this.m_handKinematic != null)
				{
					Object.Destroy(this.m_handKinematic);
					this.m_handKinematic = null;
				}
				if (this.m_handHole != null)
				{
					Object.Destroy(this.m_handHole.gameObject);
					this.m_handHole = null;
				}
				if (this.m_recorridoDePenetrador.recorrido.recorriendo)
				{
					this.m_recorridoDePenetrador.recorrido.StopRecorrido();
				}
				this.m_jobHandData.grabInter.Detener(true);
				this.m_jobHandData.jobInter.Detener(true);
				this.m_jobHandData.lockInter.Detener(true);
				this.m_jobHandData.picker.w = Mathf.MoveTowards(this.m_jobHandData.picker.w, 0f, Time.deltaTime * this.closeHandVelocity);
				HandJobController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
				if (onUpdateHandJobOrdenHandler != null)
				{
					onUpdateHandJobOrdenHandler(Vector3.zero, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, this.m_recorridoDePenetrador.recorrido.currentRotationFromTangnts, 0f, this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, false, true, false, dataUpdate.m_AnimatorCharacter, this.m_jobHandData.hitSkin, this.m_recorridoDePenetrador.penetrador.GetRootOwner(), this.m_recorridoDePenetrador.penetrador);
				}
				bool flag = !this.m_jobHandData.grabInter.ejecutandose && !this.m_jobHandData.jobInter.ejecutandose && !this.m_jobHandData.lockInter.ejecutandose;
				bool flag2 = this.Apoyo_OnTerminando(dataUpdate, primerUpdate, ordenEsperandoDetencion);
				return flag && flag2;
			}

			// Token: 0x06000FFB RID: 4091 RVA: 0x00048580 File Offset: 0x00046780
			protected override void OnTerminada(HandJobController dataUpdate, bool abruptamente)
			{
				if (this.m_GenericPenetrationJointCreator != null)
				{
					Object.Destroy(this.m_GenericPenetrationJointCreator);
					this.m_GenericPenetrationJointCreator = null;
				}
				if (this.m_handMuscleToHandInterJoint != null)
				{
					Object.Destroy(this.m_handMuscleToHandInterJoint);
					this.m_handMuscleToHandInterJoint = null;
				}
				if (this.m_penetrationKinematic != null)
				{
					Object.Destroy(this.m_penetrationKinematic);
					this.m_penetrationKinematic = null;
				}
				if (this.m_handKinematic != null)
				{
					Object.Destroy(this.m_handKinematic);
					this.m_handKinematic = null;
				}
				if (this.m_handHole != null)
				{
					Object.Destroy(this.m_handHole.gameObject);
					this.m_handHole = null;
				}
				HandJobController.Orden.IgnoreSkinToSkinsCollisions(this.m_jobHandData.hitSkin, this.m_targetSkins, false);
				this.m_ignoringCollisionWithHandJob = false;
				this.IgnoreHandToDickCollisions(this.m_jobHandData.hitSkin, false);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_jobHandData.muscle, this.m_targetPuppet, false);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_jobHandData.foreArmMuscle, this.m_targetPuppet, false);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_jobHandData.armMuscle, this.m_targetPuppet, false);
				ModificadorDeFloat handSizeModZ = this.m_handSizeModZ;
				if (handSizeModZ != null)
				{
					handSizeModZ.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat handSizeModX = this.m_handSizeModX;
				if (handSizeModX != null)
				{
					handSizeModX.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat foreArmHeigthMod = this.m_ForeArmHeigthMod;
				if (foreArmHeigthMod != null)
				{
					foreArmHeigthMod.TryRemoverDeOwner(true);
				}
				ModificadorDeBool dickEstirable = this.m_dickEstirable;
				if (dickEstirable != null)
				{
					dickEstirable.TryRemoverDeOwner(true);
				}
				ModificadorDeBool turnOnJobLayerIKOR = this.m_turnOnJobLayerIKOR;
				if (turnOnJobLayerIKOR != null)
				{
					turnOnJobLayerIKOR.TryRemoverDeOwner(true);
				}
				ModificadorDeBool femaleIsUsingHerHand = this.m_femaleIsUsingHerHand;
				if (femaleIsUsingHerHand != null)
				{
					femaleIsUsingHerHand.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat demandaDeOxigeno = this.m_demandaDeOxigeno;
				if (demandaDeOxigeno != null)
				{
					demandaDeOxigeno.TryRemoverDeOwner(true);
				}
				this.m_recorridoDePenetrador.recorrido.targetTransform = null;
				this.m_recorridoDePenetrador.recorrido.minWeigth = 0f;
				this.m_recorridoDePenetrador.recorrido.ResetRecorrido();
				this.m_jobHandData.picker.useCollision = true;
				this.m_jobHandData.picker.overrideLayerMask = null;
				HandJobController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
				if (onUpdateHandJobOrdenHandler != null)
				{
					onUpdateHandJobOrdenHandler(Vector3.zero, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, this.m_recorridoDePenetrador.recorrido.currentRotationFromTangnts, 0f, this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, false, false, true, dataUpdate.m_AnimatorCharacter, this.m_jobHandData.hitSkin, this.m_recorridoDePenetrador.penetrador.GetRootOwner(), this.m_recorridoDePenetrador.penetrador);
				}
				this.Apoyo_OnTerminada(dataUpdate, abruptamente);
			}

			// Token: 0x06000FFC RID: 4092 RVA: 0x0004880C File Offset: 0x00046A0C
			protected override void OnStart(HandJobController dataUpdate)
			{
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_jobHandData.muscle, this.m_targetPuppet, true);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_jobHandData.foreArmMuscle, this.m_targetPuppet, true);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_jobHandData.armMuscle, this.m_targetPuppet, true);
				this.m_handHole = this.m_jobHandData.muscle.target.CreateChild("HandHole" + base.tipoId.ToString());
				this.m_penetrationKinematic = this.m_handHole.gameObject.AddComponent<Rigidbody>();
				this.m_penetrationKinematic.isKinematic = true;
				this.m_handKinematic = this.m_jobHandData.pivotsJob.handInteractionTarget.gameObject.AddComponent<Rigidbody>();
				this.m_handKinematic.isKinematic = true;
				this.UpdateHandHole(dataUpdate);
				this.m_GenericPenetrationJointCreator = dataUpdate.gameObject.AddComponent<GenericPenetrationJointCreator>();
				this.m_GenericPenetrationJointCreator.Init(this.m_recorridoDePenetrador.penetrador, this.m_handHole, Vector3.forward, true);
				if (!this.m_recorridoDePenetrador.recorrido.init)
				{
					this.m_recorridoDePenetrador.recorrido.Init(this.m_recorridoDePenetrador.recorrido.config, null);
				}
				else
				{
					this.m_recorridoDePenetrador.recorrido.ReInitCurvas();
				}
				this.m_recorridoDePenetrador.recorrido.minWeigth = 0f;
				this.m_jobHandData.picker.w = 0f;
				this.m_jobHandData.picker.useCollision = false;
				this.m_jobHandData.picker.overrideLayerMask = new LayerMask?(this.m_jobHandData.picker.owner.castingLayer & ~ConfiguracionGlobal.layersStatic.skins.ToLayerMask());
				PuppetPartMainColliderVolumer component = this.m_jobHandData.muscle.rigidbody.GetComponent<PuppetPartMainColliderVolumer>();
				PuppetPartMainColliderVolumer component2 = this.m_jobHandData.foreArmMuscle.rigidbody.GetComponent<PuppetPartMainColliderVolumer>();
				this.m_handSizeModZ = component.boxModificable.sizeZ.modificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_handSizeModX = component.boxModificable.sizeX.modificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_ForeArmHeigthMod = component2.capsuleModificable.height.modificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_handSizeModZ.valor.valor = 0.35f;
				this.m_handSizeModX.valor.valor = 0.35f;
				this.m_ForeArmHeigthMod.valor.valor = 0.8f;
				this.m_dickEstirable = this.m_recorridoDePenetrador.penetrador.penisLinearChain.puedeEstirarModificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_dickEstirable.valor.valor = true;
				this.m_turnOnJobLayerIKOR = dataUpdate.m_layer3IkTurnerOff.forceTurnOnOR.ObtenerModificadorNotNull(dataUpdate);
				this.m_turnOnJobLayerIKOR.valor.valor = true;
				this.m_femaleIsUsingHerHand = dataUpdate.m_FemaleSimpleAi.GetIsInteractingWithHerHandsSexModificable(this.m_jobHandData.hitSkin.side).ObtenerModificadorNotNull(dataUpdate);
				this.m_femaleIsUsingHerHand.valor.valor = true;
				this.m_demandaDeOxigeno = dataUpdate.m_respirador.demandaDeOxigenoModificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_demandaDeOxigeno.valor.valor = 1f;
				HandJobController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
				if (onUpdateHandJobOrdenHandler != null)
				{
					onUpdateHandJobOrdenHandler(Vector3.zero, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, this.m_recorridoDePenetrador.recorrido.currentRotationFromTangnts, 0f, this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, true, false, false, dataUpdate.m_AnimatorCharacter, this.m_jobHandData.hitSkin, this.m_recorridoDePenetrador.penetrador.GetRootOwner(), this.m_recorridoDePenetrador.penetrador);
				}
				this.m_lastFrameDirection = this.m_jobHandData.pivotsJob.centerPivot.position - this.m_recorridoDePenetrador.penetrador.penisLinearChain.puntoBaseTransform.position;
				this.Apoyo_OnStart(dataUpdate);
			}

			// Token: 0x06000FFD RID: 4093 RVA: 0x00048C18 File Offset: 0x00046E18
			private void Apoyo_OnStart(HandJobController dataUpdate)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.muscle, this.m_targetPuppet, true);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.foreArmMuscle, this.m_targetPuppet, true);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.armMuscle, this.m_targetPuppet, true);
				this.m_handApoyoKinematic = this.m_restHandData.restPivot.handnteractionTarget.gameObject.AddComponent<Rigidbody>();
				this.m_handApoyoKinematic.isKinematic = true;
				this.m_restHandData.picker.w = 0f;
				this.m_restHandData.picker.useCollision = false;
				this.m_enableTargetHitSkins = this.m_targetSkins.enableHitSkinsOR.ObtenerModificadorNotNull(dataUpdate);
				this.m_enableTargetHitSkins.valor.valor = true;
			}

			// Token: 0x06000FFE RID: 4094 RVA: 0x00048CED File Offset: 0x00046EED
			private bool Apoyo_DataIsValid(HandJobController dataUpdate, bool esPrimerUpdate)
			{
				return !this.m_usaRest || !(this.m_restHandData.guiaApoyo == null);
			}

			// Token: 0x06000FFF RID: 4095 RVA: 0x00048D10 File Offset: 0x00046F10
			private void Apoyo_UpdateOrden(HandJobController dataUpdate, bool esPrimerUpdate, ICharacter femChar, float femCharScale)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				if (!this.m_ignoringCollisionWithHandApoyo && this.m_targetSkins.hitSkins.AreEnabled())
				{
					HandJobController.Orden.IgnoreSkinToSkinsCollisions(this.m_restHandData.hitSkin, this.m_targetSkins, true);
					this.m_ignoringCollisionWithHandApoyo = true;
				}
				this.m_puedeCrearApoyoMuscleJoints = false;
				HandJobController.Orden.UpdateSurfacePivot(this.m_restHandData.restPivot, this.m_restHandData.guiaApoyo, this.m_restHandData.skeletonOffsetRotation, femChar, femCharScale);
			}

			// Token: 0x06001000 RID: 4096 RVA: 0x00048D90 File Offset: 0x00046F90
			private void Apoyo_UpdateOrdenEstado(HandJobController dataUpdate, bool esPrimerUpdate)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				HandJobController.Orden.ApoyoEstado apoyoEstado = this.GetApoyoEstado(dataUpdate);
				this.UpdateApoyoSegunEstado(apoyoEstado);
				if (apoyoEstado != this.m_lastApoyoEstado)
				{
					this.m_lastApoyoEstado = apoyoEstado;
				}
				if (this.m_puedeCrearApoyoMuscleJoints)
				{
					if (this.m_handMuscleToHandApoyoInterJoint == null)
					{
						this.m_handMuscleToHandApoyoInterJoint = HandJobController.Orden.GenerateJoint(this.m_restHandData.muscle, this.m_restHandData.restPivot.handnteractionTarget);
						HandJobController.Orden.UpdateJointDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointForce, this.m_restHandData.muscle, 0f, 0f, false);
						HandJobController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointAngularForce, this.m_restHandData.muscle, 0f, 0f, false);
					}
				}
				else
				{
					if (this.m_handMuscleToHandApoyoInterJoint != null)
					{
						Object.Destroy(this.m_handMuscleToHandApoyoInterJoint);
					}
					this.m_handMuscleToHandApoyoInterJoint = null;
				}
				if (this.m_handMuscleToHandApoyoInterJoint != null)
				{
					HandJobController.Orden.UpdateJointDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointForce, this.m_restHandData.muscle, this.m_handMuscleToHandApoyoInterJoint.xDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
					HandJobController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointAngularForce, this.m_restHandData.muscle, this.m_handMuscleToHandApoyoInterJoint.angularXDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
				}
			}

			// Token: 0x06001001 RID: 4097 RVA: 0x00048EFC File Offset: 0x000470FC
			private bool Apoyo_OnTerminando(HandJobController dataUpdate, bool primerUpdate, HandJobController.Orden ordenEsperandoDetencion)
			{
				if (!this.m_usaRest)
				{
					return true;
				}
				if (this.m_handMuscleToHandApoyoInterJoint != null)
				{
					Object.Destroy(this.m_handMuscleToHandApoyoInterJoint);
					this.m_handMuscleToHandApoyoInterJoint = null;
				}
				if (this.m_handApoyoKinematic != null)
				{
					Object.Destroy(this.m_handApoyoKinematic);
					this.m_handApoyoKinematic = null;
				}
				this.m_restHandData.restInter.Detener(true);
				this.m_restHandData.picker.w = Mathf.MoveTowards(this.m_restHandData.picker.w, 0f, Time.deltaTime * this.closeHandVelocity);
				return !this.m_restHandData.restInter.ejecutandose;
			}

			// Token: 0x06001002 RID: 4098 RVA: 0x00048FB0 File Offset: 0x000471B0
			private void Apoyo_OnTerminada(HandJobController dataUpdate, bool abruptamente)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				if (this.m_handMuscleToHandApoyoInterJoint != null)
				{
					Object.Destroy(this.m_handMuscleToHandApoyoInterJoint);
					this.m_handMuscleToHandApoyoInterJoint = null;
				}
				if (this.m_handApoyoKinematic != null)
				{
					Object.Destroy(this.m_handApoyoKinematic);
					this.m_handApoyoKinematic = null;
				}
				HandJobController.Orden.IgnoreSkinToSkinsCollisions(this.m_restHandData.hitSkin, this.m_targetSkins, false);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.muscle, this.m_targetPuppet, false);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.foreArmMuscle, this.m_targetPuppet, false);
				HandJobController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.armMuscle, this.m_targetPuppet, false);
				this.m_ignoringCollisionWithHandApoyo = false;
				ModificadorDeBool enableTargetHitSkins = this.m_enableTargetHitSkins;
				if (enableTargetHitSkins != null)
				{
					enableTargetHitSkins.TryRemoverDeOwner(true);
				}
				this.m_restHandData.picker.useCollision = true;
				this.m_restHandData.picker.overrideLayerMask = null;
			}

			// Token: 0x06001003 RID: 4099 RVA: 0x000490A4 File Offset: 0x000472A4
			protected override bool UpdateOrden(HandJobController dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				Interaccion grabInter = this.m_jobHandData.grabInter;
				if (((grabInter != null) ? grabInter.owner : null) == null)
				{
					return false;
				}
				Interaccion jobInter = this.m_jobHandData.jobInter;
				if (((jobInter != null) ? jobInter.owner : null) == null)
				{
					return false;
				}
				if (this.m_jobHandData.grabInter.owner != dataUpdate.m_interacciones)
				{
					return false;
				}
				if (this.m_jobHandData.jobInter.owner != dataUpdate.m_interacciones)
				{
					return false;
				}
				RecorridoLinearDePenetradorVirtual recorridoDePenetrador = this.m_recorridoDePenetrador;
				if (((recorridoDePenetrador != null) ? recorridoDePenetrador.penetrador : null) == null)
				{
					return false;
				}
				if (this.m_recorridoDePenetrador.penetrador.hidden)
				{
					return false;
				}
				if (!this.Apoyo_DataIsValid(dataUpdate, esPrimerUpdate))
				{
					return false;
				}
				float num = MathfExtension.InverseLerpConMedio(0.25f, 1f, 5f, this.velocidad).InInOutOutPow(2f, 4f, 0.5f);
				num = MathfExtension.LerpConMedio(0.1f, 1f, 10f, num);
				this.velocidad -= this.slowDownVelocity * base.estadoDeltaTime * num;
				this.velocidad = Mathf.Clamp(this.velocidad, 0.25f, 5f);
				ICharacter character = this.m_jobHandData.grabInter.owner.character;
				float escala = character.escala;
				float num2 = this.m_jobHandData.muscle.target.lossyScale.Escala();
				Penetrador penetrador = this.m_recorridoDePenetrador.penetrador;
				this.UpdateHandHole(dataUpdate);
				this.UpdateHandJobDirectionLabios(dataUpdate);
				this.UpdateElasticity();
				HandJobController.Orden.UpdateSurfacePivot(this.m_jobHandData.pivotsGrab, character, penetrador, num2);
				HandJobController.Orden.UpdateSurfacePivotAndTwistFromMaster(this.m_jobHandData.pivotsJob, this.m_jobHandData.pivotsGrab);
				this.UpdateMinWDeRecorrido(character, penetrador, num2);
				this.m_puedeCrearPenetrationJoints = false;
				this.m_puedeCrearMuscleJoints = false;
				this.IgnoreHandToDickCollisions(this.m_jobHandData.hitSkin, true);
				this.UpdateRecorridoVelocidadMod(dataUpdate);
				this.UpdateOxigeno(dataUpdate);
				this.m_recorridoDePenetrador.recorrido.config.velocidad = this.velocidad * this.m_velocidadModSegunRecorridoW * this.m_velocidadModSegunSaturacionDeOxigeno;
				this.m_recorridoDePenetrador.recorrido.targetTransform = this.m_jobHandData.pivotsJob.centerPivot;
				this.Apoyo_UpdateOrden(dataUpdate, esPrimerUpdate, character, escala);
				HandJobController.Orden.HandJobEstado handJobEstado = this.GetHandJobEstado(dataUpdate);
				this.UpdateHandJobSegunEstado(handJobEstado);
				if (handJobEstado != this.m_lastHandJobEstado)
				{
					this.m_lastHandJobEstado = handJobEstado;
				}
				if (!this.m_ignoringCollisionWithHandJob && this.m_targetSkins.hitSkins.AreEnabled())
				{
					HandJobController.Orden.IgnoreSkinToSkinsCollisions(this.m_jobHandData.hitSkin, this.m_targetSkins, true);
					this.m_ignoringCollisionWithHandJob = true;
				}
				this.m_GenericPenetrationJointCreator.enabled = this.m_puedeCrearPenetrationJoints;
				if (this.m_puedeCrearMuscleJoints)
				{
					if (this.m_handMuscleToHandInterJoint == null)
					{
						this.m_handMuscleToHandInterJoint = HandJobController.Orden.GenerateJoint(this.m_jobHandData.muscle, this.m_jobHandData.pivotsJob.handInteractionTarget);
						HandJobController.Orden.UpdateJointDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointForce, this.m_jobHandData.muscle, 0f, 0f, false);
						HandJobController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointAngularForce, this.m_jobHandData.muscle, 0f, 0f, false);
					}
				}
				else
				{
					if (this.m_handMuscleToHandInterJoint != null)
					{
						Object.Destroy(this.m_handMuscleToHandInterJoint);
					}
					this.m_handMuscleToHandInterJoint = null;
				}
				if (this.m_handMuscleToHandInterJoint != null)
				{
					HandJobController.Orden.UpdateJointDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointForce, this.m_jobHandData.muscle, this.m_handMuscleToHandInterJoint.xDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
					HandJobController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointAngularForce, this.m_jobHandData.muscle, this.m_handMuscleToHandInterJoint.angularXDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
				}
				this.Apoyo_UpdateOrdenEstado(dataUpdate, esPrimerUpdate);
				Vector3 vector = this.m_jobHandData.pivotsJob.centerPivot.position - this.m_recorridoDePenetrador.penetrador.penisLinearChain.puntoBaseTransform.position;
				Vector3 vector2 = ((base.estadoDeltaTime == 0f) ? Vector3.zero : ((vector - this.m_lastFrameDirection) / base.estadoDeltaTime));
				if (handJobEstado == HandJobController.Orden.HandJobEstado.enJob)
				{
					HandJobController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
					if (onUpdateHandJobOrdenHandler != null)
					{
						onUpdateHandJobOrdenHandler(vector2, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, this.m_recorridoDePenetrador.recorrido.currentRotationFromTangnts, this.velocidad, this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, false, false, false, dataUpdate.m_AnimatorCharacter, this.m_jobHandData.hitSkin, this.m_recorridoDePenetrador.penetrador.GetRootOwner(), this.m_recorridoDePenetrador.penetrador);
					}
				}
				else
				{
					HandJobController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler2 = this.onUpdated;
					if (onUpdateHandJobOrdenHandler2 != null)
					{
						onUpdateHandJobOrdenHandler2(Vector3.zero, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, this.m_recorridoDePenetrador.recorrido.currentRotationFromTangnts, 0f, this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, true, false, false, dataUpdate.m_AnimatorCharacter, this.m_jobHandData.hitSkin, this.m_recorridoDePenetrador.penetrador.GetRootOwner(), this.m_recorridoDePenetrador.penetrador);
					}
				}
				this.m_lastFrameDirection = vector;
				return true;
			}

			// Token: 0x06001004 RID: 4100 RVA: 0x00049608 File Offset: 0x00047808
			private void InitialRecorridoAndPivotPoses()
			{
				if (this.m_recorridoDePenetrador.recorrido.recorriendo)
				{
					this.m_recorridoDePenetrador.recorrido.PauseRecorrido();
				}
				else
				{
					this.m_recorridoDePenetrador.recorrido.UpdateTo(1f, false);
				}
				this.SetPivotCenterToCurrentTip(this.m_jobHandData.pivotsJob);
				this.SetPivotCenterToCurrentTip(this.m_jobHandData.pivotsGrab);
			}

			// Token: 0x06001005 RID: 4101 RVA: 0x00049674 File Offset: 0x00047874
			private void GrabHandPoseToJobPose()
			{
				Transform handInteractionTarget = this.m_jobHandData.pivotsGrab.handInteractionTarget;
				this.m_jobHandData.pivotsJob.handInteractionTarget.SetPositionAndRotation(handInteractionTarget.position, handInteractionTarget.rotation);
			}

			// Token: 0x06001006 RID: 4102 RVA: 0x000496B3 File Offset: 0x000478B3
			private float GetMinWDeRecorridoDeGrab()
			{
				return Mathf.Lerp(this.m_recorridoDePenetrador.recorrido.minWeigth, 1f, 0.25f);
			}

			// Token: 0x06001007 RID: 4103 RVA: 0x000496D4 File Offset: 0x000478D4
			private void UpdateHandJobSegunEstado(HandJobController.Orden.HandJobEstado estado)
			{
				switch (estado)
				{
				case HandJobController.Orden.HandJobEstado.None:
					return;
				case HandJobController.Orden.HandJobEstado.esperandoApoyo:
					this.InitialRecorridoAndPivotPoses();
					this.EjecutarLock();
					return;
				case HandJobController.Orden.HandJobEstado.esperandoEjecutarGrab:
					this.InitialRecorridoAndPivotPoses();
					this.m_jobHandData.grabInter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 1f, 1f, false);
					this.EjecutarLock();
					return;
				case HandJobController.Orden.HandJobEstado.esperandoInterMax:
					this.InitialRecorridoAndPivotPoses();
					return;
				case HandJobController.Orden.HandJobEstado.esperandoCerrarMano:
					this.m_puedeCrearMuscleJoints = true;
					this.InitialRecorridoAndPivotPoses();
					this.GrabHandPoseToJobPose();
					this.m_jobHandData.picker.w = Mathf.MoveTowards(this.m_jobHandData.picker.w, 1f, Time.deltaTime * this.closeHandVelocity);
					return;
				case HandJobController.Orden.HandJobEstado.esperandoPivotsAEndRecorrido:
				{
					this.m_puedeCrearPenetrationJoints = true;
					this.m_puedeCrearMuscleJoints = true;
					this.m_recorridoDePenetrador.recorrido.UpdateTo(1f, false);
					Vector3 vector = this.m_jobHandData.pivotsJob.centerPivot.position;
					Quaternion quaternion = this.m_jobHandData.pivotsJob.centerPivot.rotation;
					vector = Vector3.Lerp(vector, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, Time.deltaTime * 3f);
					quaternion = Quaternion.Slerp(quaternion, Quaternion.LookRotation(this.m_recorridoDePenetrador.recorrido.currentTangent, this.m_recorridoDePenetrador.recorrido.currentCrossTangent), Time.deltaTime * 3f);
					this.m_jobHandData.pivotsJob.centerPivot.SetPositionAndRotation(vector, quaternion);
					Vector3 vector2 = this.m_jobHandData.pivotsGrab.centerPivot.position;
					Quaternion quaternion2 = this.m_jobHandData.pivotsGrab.centerPivot.rotation;
					vector2 = Vector3.Lerp(vector2, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, Time.deltaTime * 3f);
					quaternion2 = Quaternion.Slerp(quaternion2, Quaternion.LookRotation(this.m_recorridoDePenetrador.recorrido.currentTangent, this.m_recorridoDePenetrador.recorrido.currentCrossTangent), Time.deltaTime * 3f);
					this.m_jobHandData.pivotsGrab.centerPivot.SetPositionAndRotation(vector2, quaternion2);
					this.GrabHandPoseToJobPose();
					return;
				}
				case HandJobController.Orden.HandJobEstado.esperandoEjecutarJob:
					this.m_puedeCrearPenetrationJoints = true;
					this.m_puedeCrearMuscleJoints = true;
					if (this.m_recorridoDePenetrador.recorrido.recorriendo)
					{
						this.m_recorridoDePenetrador.recorrido.PauseRecorrido();
					}
					else
					{
						this.m_recorridoDePenetrador.recorrido.UpdateTo(1f, false);
					}
					this.SetPivotCenterToRecorrido(this.m_jobHandData.pivotsJob, 1f, false);
					this.SetPivotCenterToRecorrido(this.m_jobHandData.pivotsGrab, 1f, false);
					this.m_jobHandData.jobInter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 1f, 1f, false);
					this.EjecutarLock();
					this.GrabHandPoseToJobPose();
					return;
				case HandJobController.Orden.HandJobEstado.esperandoPivotsAFinalPositions:
				{
					this.m_puedeCrearPenetrationJoints = true;
					this.m_puedeCrearMuscleJoints = true;
					this.m_recorridoDePenetrador.recorrido.UpdateTo(this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, false);
					Vector3 vector3 = this.m_jobHandData.pivotsJob.centerPivot.position;
					Quaternion quaternion3 = this.m_jobHandData.pivotsJob.centerPivot.rotation;
					vector3 = Vector3.Lerp(vector3, this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, Time.deltaTime * 3f);
					quaternion3 = Quaternion.Slerp(quaternion3, Quaternion.LookRotation(this.m_recorridoDePenetrador.recorrido.currentTangent, this.m_recorridoDePenetrador.recorrido.currentCrossTangent), Time.deltaTime * 3f);
					this.m_jobHandData.pivotsJob.centerPivot.SetPositionAndRotation(vector3, quaternion3);
					Vector3 vector4 = this.m_jobHandData.pivotsGrab.centerPivot.position;
					Quaternion quaternion4 = this.m_jobHandData.pivotsGrab.centerPivot.rotation;
					Vector3 vector5;
					Quaternion quaternion5;
					this.m_recorridoDePenetrador.recorrido.Evaluate(0f, out vector5, out quaternion5);
					vector4 = Vector3.Lerp(vector4, vector5, Time.deltaTime * 3f);
					quaternion4 = Quaternion.Slerp(quaternion4, quaternion5, Time.deltaTime * 3f);
					this.m_jobHandData.pivotsGrab.centerPivot.SetPositionAndRotation(vector4, quaternion4);
					return;
				}
				case HandJobController.Orden.HandJobEstado.esperandoStartRecorrido:
					this.m_puedeCrearPenetrationJoints = true;
					this.m_puedeCrearMuscleJoints = true;
					this.m_recorridoDePenetrador.recorrido.UpdateTo(this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth, true);
					this.m_recorridoDePenetrador.recorrido.StartRecorrido();
					this.SetPivotCenterToRecorrido(this.m_jobHandData.pivotsGrab, 0f, false);
					return;
				case HandJobController.Orden.HandJobEstado.enJob:
					this.m_puedeCrearPenetrationJoints = true;
					this.m_puedeCrearMuscleJoints = true;
					if (!this.m_recorridoDePenetrador.recorrido.recorriendo || this.m_recorridoDePenetrador.recorrido.paused)
					{
						this.m_recorridoDePenetrador.recorrido.StartRecorrido();
					}
					this.SetPivotCenterToRecorrido(this.m_jobHandData.pivotsGrab, 0f, false);
					this.EjecutarLock();
					return;
				default:
					throw new ArgumentOutOfRangeException(estado.ToString());
				}
			}

			// Token: 0x06001008 RID: 4104 RVA: 0x00049BEC File Offset: 0x00047DEC
			private void EjecutarLock()
			{
				if (!this.m_jobHandData.lockInter.ejecutandose && !this.m_jobHandData.lockInter.EsperandoEjecutarse())
				{
					this.m_jobHandData.lockInter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 0.25f, 0.25f, false);
				}
			}

			// Token: 0x06001009 RID: 4105 RVA: 0x00049C4C File Offset: 0x00047E4C
			private HandJobController.Orden.HandJobEstado GetHandJobEstado(HandJobController dataUpdate)
			{
				if (this.m_usaRest && !this.m_restHandData.restInter.ejecutandose && !this.m_restHandData.restInter.EsperandoEjecutarse())
				{
					return HandJobController.Orden.HandJobEstado.esperandoApoyo;
				}
				if (this.m_usaRest && this.m_restHandData.restInter.currentEstado.EstadosTimerWeigthPromedio(0f) < 0.666f)
				{
					return HandJobController.Orden.HandJobEstado.esperandoApoyo;
				}
				if (!this.m_jobHandData.grabInter.ejecutandose && !this.m_jobHandData.grabInter.EsperandoEjecutarse())
				{
					return HandJobController.Orden.HandJobEstado.esperandoEjecutarGrab;
				}
				if (!this.m_jobHandData.grabInter.currentEstado.EstadosTimerWeigthPromedio(0f).AlmostEqualV2(1f, 1E-45f))
				{
					return HandJobController.Orden.HandJobEstado.esperandoInterMax;
				}
				if (!this.m_jobHandData.picker.tomando)
				{
					return HandJobController.Orden.HandJobEstado.esperandoCerrarMano;
				}
				if ((this.m_lastHandJobEstado == HandJobController.Orden.HandJobEstado.esperandoCerrarMano || this.m_lastHandJobEstado == HandJobController.Orden.HandJobEstado.esperandoPivotsAEndRecorrido) && !this.m_recorridoDePenetrador.recorrido.recorriendo && !this.m_recorridoDePenetrador.recorrido.paused)
				{
					Vector3 vector;
					Quaternion quaternion;
					this.m_recorridoDePenetrador.recorrido.Evaluate(1f, out vector, out quaternion);
					if (Vector3.Distance(vector, this.m_jobHandData.pivotsGrab.centerPivot.position) > 0.003f || Quaternion.Angle(quaternion, this.m_jobHandData.pivotsGrab.centerPivot.rotation) > 1f)
					{
						return HandJobController.Orden.HandJobEstado.esperandoPivotsAEndRecorrido;
					}
					if (Vector3.Distance(vector, this.m_jobHandData.pivotsJob.centerPivot.position) > 0.003f || Quaternion.Angle(quaternion, this.m_jobHandData.pivotsJob.centerPivot.rotation) > 1f)
					{
						return HandJobController.Orden.HandJobEstado.esperandoPivotsAEndRecorrido;
					}
				}
				if (!this.m_jobHandData.jobInter.ejecutandose && !this.m_jobHandData.jobInter.EsperandoEjecutarse())
				{
					return HandJobController.Orden.HandJobEstado.esperandoEjecutarJob;
				}
				if (Vector3.Distance(this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, this.m_jobHandData.pivotsJob.centerPivot.position) > 0.003f || Quaternion.Angle(Quaternion.LookRotation(this.m_recorridoDePenetrador.recorrido.currentTangent, this.m_recorridoDePenetrador.recorrido.currentCrossTangent), this.m_jobHandData.pivotsJob.centerPivot.rotation) > 1f)
				{
					return HandJobController.Orden.HandJobEstado.esperandoPivotsAFinalPositions;
				}
				Vector3 vector2;
				Quaternion quaternion2;
				this.m_recorridoDePenetrador.recorrido.Evaluate(0f, out vector2, out quaternion2);
				if (Vector3.Distance(vector2, this.m_jobHandData.pivotsGrab.centerPivot.position) > 0.01f || Quaternion.Angle(quaternion2, this.m_jobHandData.pivotsGrab.centerPivot.rotation) > 5f)
				{
					return HandJobController.Orden.HandJobEstado.esperandoPivotsAFinalPositions;
				}
				if (!this.m_recorridoDePenetrador.recorrido.recorriendo)
				{
					return HandJobController.Orden.HandJobEstado.esperandoStartRecorrido;
				}
				return HandJobController.Orden.HandJobEstado.enJob;
			}

			// Token: 0x0600100A RID: 4106 RVA: 0x00049F14 File Offset: 0x00048114
			private void UpdateOxigeno(HandJobController dataUpdate)
			{
				switch (dataUpdate.m_respirador.cansancioEstado)
				{
				case CanzancioEstado.descanzado:
				case CanzancioEstado.estaCanzandonse:
					this.m_velocidadModSegunSaturacionDeOxigeno = Mathf.MoveTowards(this.m_velocidadModSegunSaturacionDeOxigeno, 1f, base.estadoDeltaTime * 0.25f);
					break;
				case CanzancioEstado.canzado:
				case CanzancioEstado.estaDescanzandose:
				{
					float num = 0.25f / this.velocidad;
					this.m_velocidadModSegunSaturacionDeOxigeno = Mathf.MoveTowards(this.m_velocidadModSegunSaturacionDeOxigeno, num, base.estadoDeltaTime * 0.5f);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException(dataUpdate.m_respirador.cansancioEstado.ToString());
				}
				float num2 = MathfExtension.InverseLerpConMedio(0.25f, 1f, 5f, this.velocidad * this.m_velocidadModSegunSaturacionDeOxigeno).InInOutOutPow(2f, 1f, 0.5f);
				this.m_demandaDeOxigeno.valor.valor = MathfExtension.LerpConMedio(1f, 12f, 48f, num2);
			}

			// Token: 0x0600100B RID: 4107 RVA: 0x0004A010 File Offset: 0x00048210
			private void UpdateRecorridoVelocidadMod(HandJobController dataUpdate)
			{
				float num = Mathf.InverseLerp(this.m_recorridoDePenetrador.recorrido.minWeigth, this.m_recorridoDePenetrador.recorrido.maxWeigth, this.m_recorridoDePenetrador.recorrido.currentRecorridoWeigth);
				float num2 = Mathf.InverseLerp(this.recorridoW_ToStartSlowDownTop, 1f, num).InPow(this.velocityInPower);
				float num3 = Mathf.InverseLerp(this.recorridoW_ToStartSlowDownBottom, 0f, num).InPow(this.velocityInPower);
				float num4 = Mathf.Lerp(1f, this.minVelocityMod, num2);
				float num5 = Mathf.Lerp(1f, this.minVelocityMod, num3);
				float num6 = Mathf.InverseLerp(this.m_recorridoDePenetrador.recorrido.minWeigth, this.m_recorridoDePenetrador.recorrido.maxWeigth, this.m_recorridoDePenetrador.recorrido.recorridoWeigthTarget);
				float num7 = ((num6 >= 1f) ? 0.9f : ((num6 <= 0f) ? 1.1f : 1f));
				this.m_velocidadModSegunRecorridoW = num4 * num5 * num7;
			}

			// Token: 0x0600100C RID: 4108 RVA: 0x0004A120 File Offset: 0x00048320
			private void UpdateHandHole(HandJobController dataUpdate)
			{
				Vector3 vector = this.m_jobHandData.pivotsJob.handInteractionTarget.InverseTransformPoint(this.m_jobHandData.pivotsJob.centerPivot.position);
				this.m_handHole.localPosition = vector;
				this.m_handHole.rotation = this.m_jobHandData.pivotsJob.centerPivot.rotation;
			}

			// Token: 0x0600100D RID: 4109 RVA: 0x0004A184 File Offset: 0x00048384
			private static Vector3 GetScapeDir(Vector3 localMaxDeseoDirection)
			{
				Vector3 vector;
				if (localMaxDeseoDirection.x > 0f)
				{
					if (localMaxDeseoDirection.y > 0f)
					{
						vector = new Vector3(-0.4f, -0.2f, 1f);
					}
					else
					{
						vector = new Vector3(-0.4f, 0.2f, 1f);
					}
				}
				else if (localMaxDeseoDirection.y > 0f)
				{
					vector = new Vector3(0.4f, -0.2f, 1f);
				}
				else
				{
					vector = new Vector3(0.4f, 0.2f, 1f);
				}
				return vector.normalized;
			}

			// Token: 0x0600100E RID: 4110 RVA: 0x0004A220 File Offset: 0x00048420
			private void UpdateHandJobDirectionLabios(HandJobController dataUpdate)
			{
				Transform transform = this.m_recorridoDePenetrador.transform;
				float num = dataUpdate.m_Deseos.valores.labiosModBySexThresholds;
				num = MathfExtension.InverseLerpConMedio(-1f, 0.333f, 1f, num);
				Vector3 position = transform.position;
				Vector3 vector = (dataUpdate.m_AnimatorCharacter.bones.eyeL.posicionFinal + dataUpdate.m_AnimatorCharacter.bones.eyeR.posicionFinal) / 2f;
				vector = (vector + dataUpdate.m_AnimatorCharacter.bones.bocaEntrada.posicionFinal) / 2f;
				Vector3 vector2 = transform.InverseTransformDirection((vector - position).normalized);
				Vector3 vector3 = MathfExtension.LerpConMedio(HandJobController.Orden.GetScapeDir(vector2), Vector3.forward, vector2, num, 1f, 1f).normalized;
				vector3 = Math3dTvalle.ProjectPointInsideCone(Vector3.forward, Vector3.zero, 33f, 1f, vector3).normalized;
				this.m_recorridoDePenetrador.localForward = vector3;
			}

			// Token: 0x0600100F RID: 4111 RVA: 0x0004A338 File Offset: 0x00048538
			private void UpdateHandJobDirectionAll(HandJobController dataUpdate)
			{
				Transform transform = this.m_recorridoDePenetrador.transform;
				float num = dataUpdate.m_Deseos.valores.labiosModBySexThresholds;
				float num2 = dataUpdate.m_Deseos.valores.senosModBySexThresholds;
				float num3 = dataUpdate.m_Deseos.valores.traseroModBySexThresholds;
				float num4 = dataUpdate.m_Deseos.valores.entrepiernaModBySexThresholds;
				num = MathfExtension.InverseLerpConMedio(-1f, 0.333f, 1f, num);
				num2 = MathfExtension.InverseLerpConMedio(-1f, 0.333f, 1f, num2);
				num3 = MathfExtension.InverseLerpConMedio(-1f, 0.333f, 1f, num3);
				num4 = MathfExtension.InverseLerpConMedio(-1f, 0.333f, 1f, num4);
				Vector3 position = transform.position;
				Vector3 vector = transform.InverseTransformDirection((dataUpdate.m_AnimatorCharacter.bones.bocaEntrada.posicionFinal - position).normalized);
				Vector3 vector2 = transform.InverseTransformDirection((dataUpdate.m_AnimatorCharacter.bones.chest.posicionFinal - position).normalized);
				Vector3 vector3 = transform.InverseTransformDirection((dataUpdate.m_AnimatorCharacter.bones.hips.posicionFinal - position).normalized);
				Vector3 scapeDir = HandJobController.Orden.GetScapeDir(vector);
				Vector3 scapeDir2 = HandJobController.Orden.GetScapeDir(vector2);
				Vector3 scapeDir3 = HandJobController.Orden.GetScapeDir(vector3);
				Vector3 vector4 = MathfExtension.LerpConMedio(scapeDir, Vector3.forward, vector, num, 1f, 1f);
				Vector3 vector5 = MathfExtension.LerpConMedio(scapeDir2, Vector3.forward, vector2, num2, 1f, 1f);
				Vector3 vector6 = MathfExtension.LerpConMedio(scapeDir3, Vector3.forward, vector3, num4, 1f, 1f);
				Vector3 vector7 = MathfExtension.LerpConMedio(scapeDir3, Vector3.forward, vector3, num3, 1f, 1f);
				Vector3 vector8 = (vector4 + vector5 + vector6 + vector7).normalized;
				vector8 = Math3dTvalle.ProjectPointInsideCone(Vector3.forward, Vector3.zero, 33f, 1f, vector8).normalized;
				this.m_recorridoDePenetrador.localForward = vector8;
			}

			// Token: 0x06001010 RID: 4112 RVA: 0x0004A550 File Offset: 0x00048750
			private void UpdateElasticity()
			{
				if (!this.updateElasticity)
				{
					return;
				}
				float worldScaleIgnorandoEreccion = this.m_recorridoDePenetrador.penetrador.worldScaleIgnorandoEreccion;
				float num = this.m_recorridoDePenetrador.penetrador.currentRealErectionValue / 100f;
				float num2 = MathfExtension.InverseLerpConMedio(3f, 0.75f, 0.3333f, worldScaleIgnorandoEreccion);
				float num3 = Mathf.Lerp(MathfExtension.LerpConMedio(this.minPhysicsElasticity, 3f, this.maxPhysicsElasticity, num2.InPow(2f)), this.physicsElasticityOnMaxErection, num.InPow(2f));
				float num4 = Mathf.Lerp(this.minRecorridoElasticity, this.maxRecorridoElasticity, num2);
				this.m_GenericPenetrationJointCreator.configuracionV2.zDriveDamperToSpring = num3;
				this.m_recorridoDePenetrador.ignorarEreccionWeigth = num4;
			}

			// Token: 0x06001011 RID: 4113 RVA: 0x0004A610 File Offset: 0x00048810
			private static void UpdateSurfacePivot(SurfaceAndCenterPivotDeInteraction pivots, ICharacter femChar, Penetrador dick, float femCharHandScale)
			{
				pivots.centerPivot.localScale = Vector3.one * femCharHandScale;
				float num = dick.worldMaxWidth * 0.5f / femCharHandScale;
				pivots.surfacePivot.localPosition = new Vector3(0f, 0f, num);
			}

			// Token: 0x06001012 RID: 4114 RVA: 0x0004A660 File Offset: 0x00048860
			private static void UpdateSurfacePivotAndTwistFromMaster(SurfaceAndCenterPivotDeInteraction slave, SurfaceAndCenterPivotDeInteraction master)
			{
				slave.centerPivot.localScale = master.centerPivot.localScale;
				slave.interactionTargetPivot.localRotation = master.interactionTargetPivot.localRotation;
				slave.surfacePivot.localPosition = master.surfacePivot.localPosition;
			}

			// Token: 0x06001013 RID: 4115 RVA: 0x0004A6B0 File Offset: 0x000488B0
			private void UpdateMinWDeRecorrido(ICharacter femChar, Penetrador dick, float femCharHandScale)
			{
				float num = femChar.defaultHandWidth * femCharHandScale;
				float num2 = dick.worldLengthFromUnderSkin - dick.worldLength + num * 0.8f;
				float worldWeight = this.m_recorridoDePenetrador.recorrido.curvas.GetWorldWeight(num2);
				this.m_recorridoDePenetrador.recorrido.minWeigth = Mathf.Clamp(worldWeight, 0f, 0.9f);
				float largo = this.m_recorridoDePenetrador.recorrido.curvas.largo;
				float num3 = largo * 0.2f;
				float num4 = num * 1.5f;
				float num5 = Mathf.Min(num3, num4);
				float worldWeight2 = this.m_recorridoDePenetrador.recorrido.curvas.GetWorldWeight(largo - num5);
				float num6 = Mathf.InverseLerp(0.5f, this.velocidadParaMinRecorrido, this.velocidad);
				float num7 = Mathf.Lerp(this.m_recorridoDePenetrador.recorrido.minWeigth, worldWeight2, num6);
				this.m_recorridoDePenetrador.recorrido.minWeigth = Mathf.Max(this.m_recorridoDePenetrador.recorrido.minWeigth, num7);
				this.m_recorridoDePenetrador.recorrido.minWeigth = Mathf.Clamp(this.m_recorridoDePenetrador.recorrido.minWeigth, 0f, 0.99f);
			}

			// Token: 0x06001014 RID: 4116 RVA: 0x0004A7E8 File Offset: 0x000489E8
			private void SetPivotCenterToCurrentTip(SurfaceAndCenterPivotDeInteraction pivots)
			{
				Transform tipPhysics = this.m_recorridoDePenetrador.penetrador.tipPhysics;
				pivots.centerPivot.SetPositionAndRotation(tipPhysics.position, tipPhysics.rotation);
			}

			// Token: 0x06001015 RID: 4117 RVA: 0x0004A820 File Offset: 0x00048A20
			private void SetPivotCenterToRecorrido(SurfaceAndCenterPivotDeInteraction pivots, float w, bool updateRecorrido)
			{
				if (updateRecorrido)
				{
					this.m_recorridoDePenetrador.recorrido.UpdateTo(w, false);
					pivots.centerPivot.SetPositionAndRotation(this.m_recorridoDePenetrador.recorrido.currentProyectedPoint, Quaternion.LookRotation(this.m_recorridoDePenetrador.recorrido.currentTangent, this.m_recorridoDePenetrador.recorrido.currentCrossTangent));
					return;
				}
				Vector3 vector;
				Quaternion quaternion;
				this.m_recorridoDePenetrador.recorrido.Evaluate(w, out vector, out quaternion);
				pivots.centerPivot.SetPositionAndRotation(vector, quaternion);
			}

			// Token: 0x06001016 RID: 4118 RVA: 0x0004A8A8 File Offset: 0x00048AA8
			private static ConfigurableJoint GenerateJoint(Muscle muscle, Transform interTargetTransform)
			{
				Transform transform = muscle.rigidbody.transform;
				Vector3 position = transform.position;
				Quaternion rotation = transform.rotation;
				transform.SetPositionAndRotation(interTargetTransform.position, interTargetTransform.rotation);
				ConfigurableJoint configurableJoint = interTargetTransform.gameObject.AddComponent<ConfigurableJoint>();
				configurableJoint.autoConfigureConnectedAnchor = false;
				configurableJoint.anchor = (configurableJoint.connectedAnchor = Vector3.zero);
				configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
				configurableJoint.xMotion = ConfigurableJointMotion.Free;
				configurableJoint.yMotion = ConfigurableJointMotion.Free;
				configurableJoint.zMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
				configurableJoint.connectedBody = muscle.rigidbody;
				transform.SetPositionAndRotation(position, rotation);
				return configurableJoint;
			}

			// Token: 0x06001017 RID: 4119 RVA: 0x0004A950 File Offset: 0x00048B50
			private static void IgnoreSkinToSkinsCollisions(HitSkin hitSkin, IHitSkinnedCharacter skinnedChar, bool ignore)
			{
				List<Collider> skinColliders = hitSkin.skinColliders;
				for (int i = 0; i < skinColliders.Count; i++)
				{
					Collider collider = skinColliders[i];
					if (!(collider == null))
					{
						skinnedChar.IgnoreSkinCollisionsVersus(collider, ignore);
					}
				}
			}

			// Token: 0x06001018 RID: 4120 RVA: 0x0004A990 File Offset: 0x00048B90
			private static void IgnoreMuscleToPuppetCollisions(Muscle muscle, PuppetMaster puppetChar, bool ignore)
			{
				for (int i = 0; i < puppetChar.muscles.Length; i++)
				{
					Muscle muscle2 = puppetChar.muscles[i];
					for (int j = 0; j < muscle2.colliders.Length; j++)
					{
						Collider collider = muscle2.colliders[j];
						for (int k = 0; k < muscle.colliders.Length; k++)
						{
							Collider collider2 = muscle.colliders[k];
							Physics.IgnoreCollision(collider, collider2, ignore);
						}
					}
				}
			}

			// Token: 0x06001019 RID: 4121 RVA: 0x0004AA00 File Offset: 0x00048C00
			private void IgnoreHandToDickCollisions(HitSkin handHitSkin, bool ignore)
			{
				List<Collider> skinColliders = handHitSkin.skinColliders;
				for (int i = 0; i < this.m_recorridoDePenetrador.penetrador.partesEnOrden.Count; i++)
				{
					PenisPart penisPart = this.m_recorridoDePenetrador.penetrador.partesEnOrden[i];
					CapsuleCollider capsuleCollider;
					if (penisPart == null)
					{
						capsuleCollider = null;
					}
					else
					{
						PenisPointCollider mainCollider = penisPart.mainCollider;
						capsuleCollider = ((mainCollider != null) ? mainCollider.mainCollider : null);
					}
					CapsuleCollider capsuleCollider2 = capsuleCollider;
					CapsuleCollider capsuleCollider3;
					if (penisPart == null)
					{
						capsuleCollider3 = null;
					}
					else
					{
						PenisPointCollider complementoCollider = penisPart.complementoCollider;
						capsuleCollider3 = ((complementoCollider != null) ? complementoCollider.mainCollider : null);
					}
					CapsuleCollider capsuleCollider4 = capsuleCollider3;
					if (!(capsuleCollider4 == null) || !(capsuleCollider2 == null))
					{
						for (int j = 0; j < skinColliders.Count; j++)
						{
							Collider collider = skinColliders[j];
							if (!(collider == null))
							{
								if (capsuleCollider2 != null)
								{
									Physics.IgnoreCollision(capsuleCollider2, collider, ignore);
								}
								if (capsuleCollider4 != null)
								{
									Physics.IgnoreCollision(capsuleCollider4, collider, ignore);
								}
							}
						}
					}
				}
			}

			// Token: 0x0600101A RID: 4122 RVA: 0x0004AAE4 File Offset: 0x00048CE4
			private static void UpdateJointDrivers(ConfigurableJoint m_handMuscleToHandInterJoint, float handMuscleJointForce, Muscle m_jobHandData, float currentValue, float deltaTime, bool lockIfMax)
			{
				float num = handMuscleJointForce * m_jobHandData.rigidbody.mass;
				JointDrive jointDrive = default(JointDrive);
				float num2 = Mathf.MoveTowards(currentValue, num, num * deltaTime * 0.2f);
				jointDrive.positionSpring = num2;
				jointDrive.positionDamper = 0f;
				jointDrive.maximumForce = 3.402823E+38f;
				m_handMuscleToHandInterJoint.xDrive = jointDrive;
				m_handMuscleToHandInterJoint.yDrive = jointDrive;
				m_handMuscleToHandInterJoint.zDrive = jointDrive;
				if (num.AlmostEqualV2(num2, 1E-45f))
				{
					m_handMuscleToHandInterJoint.xMotion = ConfigurableJointMotion.Locked;
					m_handMuscleToHandInterJoint.yMotion = ConfigurableJointMotion.Locked;
					m_handMuscleToHandInterJoint.zMotion = ConfigurableJointMotion.Locked;
				}
			}

			// Token: 0x0600101B RID: 4123 RVA: 0x0004AB74 File Offset: 0x00048D74
			private static void UpdateJointAngularDrivers(ConfigurableJoint m_handMuscleToHandInterJoint, float handMuscleJointAngularForce, Muscle m_jobHandData, float currentValue, float deltaTime, bool lockIfMax)
			{
				float num = handMuscleJointAngularForce * m_jobHandData.rigidbody.mass;
				JointDrive jointDrive = default(JointDrive);
				float num2 = Mathf.MoveTowards(currentValue, num, num * deltaTime * 0.2f);
				jointDrive.positionSpring = num2;
				jointDrive.positionDamper = 0f;
				jointDrive.maximumForce = 3.402823E+38f;
				m_handMuscleToHandInterJoint.angularXDrive = jointDrive;
				m_handMuscleToHandInterJoint.angularYZDrive = jointDrive;
				if (num.AlmostEqualV2(num2, 1E-45f))
				{
					m_handMuscleToHandInterJoint.angularXMotion = ConfigurableJointMotion.Locked;
					m_handMuscleToHandInterJoint.angularYMotion = ConfigurableJointMotion.Locked;
					m_handMuscleToHandInterJoint.angularZMotion = ConfigurableJointMotion.Locked;
				}
			}

			// Token: 0x170003FA RID: 1018
			// (get) Token: 0x0600101C RID: 4124 RVA: 0x0004ABFA File Offset: 0x00048DFA
			public HandJobController.RestHandData restHandData
			{
				get
				{
					return this.m_restHandData;
				}
			}

			// Token: 0x0600101D RID: 4125 RVA: 0x0004AC04 File Offset: 0x00048E04
			private void UpdateApoyoSegunEstado(HandJobController.Orden.ApoyoEstado estado)
			{
				switch (estado)
				{
				case HandJobController.Orden.ApoyoEstado.esperandoEjecutarApoyo:
					this.m_restHandData.restInter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 1f, 1f, false);
					return;
				case HandJobController.Orden.ApoyoEstado.esperandoInterMax:
					return;
				case HandJobController.Orden.ApoyoEstado.esperandoCerrarMano:
					this.m_puedeCrearApoyoMuscleJoints = true;
					this.m_restHandData.picker.w = Mathf.MoveTowards(this.m_restHandData.picker.w, 1f, Time.deltaTime * this.closeHandVelocity);
					return;
				case HandJobController.Orden.ApoyoEstado.enApoyo:
					this.m_puedeCrearApoyoMuscleJoints = true;
					return;
				default:
					throw new ArgumentOutOfRangeException(estado.ToString());
				}
			}

			// Token: 0x0600101E RID: 4126 RVA: 0x0004ACB4 File Offset: 0x00048EB4
			private HandJobController.Orden.ApoyoEstado GetApoyoEstado(HandJobController dataUpdate)
			{
				if (!this.m_restHandData.restInter.ejecutandose && !this.m_restHandData.restInter.EsperandoEjecutarse())
				{
					return HandJobController.Orden.ApoyoEstado.esperandoEjecutarApoyo;
				}
				if (!this.m_restHandData.restInter.currentEstado.EstadosTimerWeigthPromedio(0f).AlmostEqualV2(1f, 1E-45f))
				{
					return HandJobController.Orden.ApoyoEstado.esperandoInterMax;
				}
				if (!this.m_restHandData.picker.tomando)
				{
					return HandJobController.Orden.ApoyoEstado.esperandoCerrarMano;
				}
				return HandJobController.Orden.ApoyoEstado.enApoyo;
			}

			// Token: 0x0600101F RID: 4127 RVA: 0x0004AD29 File Offset: 0x00048F29
			private static void UpdateSurfacePivot(SurfacePivotDeInteraction pivots, Transform guia, Quaternion skeletonOffsetRotation, ICharacter femChar, float femCharScale)
			{
				pivots.superficiePivot.SetPositionAndRotation(guia.position, guia.rotation * skeletonOffsetRotation);
			}

			// Token: 0x04000B52 RID: 2898
			[SerializeField]
			[ReadOnlyUI]
			private PuppetMaster m_targetPuppet;

			// Token: 0x04000B53 RID: 2899
			[SerializeField]
			[ReadOnlyUI]
			private MaleSkins m_targetSkins;

			// Token: 0x04000B54 RID: 2900
			[SerializeField]
			[ReadOnlyUI]
			private HandJobController.JobHandData m_jobHandData;

			// Token: 0x04000B55 RID: 2901
			[SerializeField]
			[ReadOnlyUI]
			private RecorridoLinearDePenetradorVirtual m_recorridoDePenetrador;

			// Token: 0x04000B56 RID: 2902
			public HandJobController.OnUpdateHandJobOrdenHandler onUpdated;

			// Token: 0x04000B57 RID: 2903
			public float velocidad;

			// Token: 0x04000B58 RID: 2904
			public float slowDownVelocity;

			// Token: 0x04000B59 RID: 2905
			[SerializeField]
			private float velocidadParaMinRecorrido = 4f;

			// Token: 0x04000B5A RID: 2906
			[SerializeField]
			private float minVelocityMod = 0.1f;

			// Token: 0x04000B5B RID: 2907
			[SerializeField]
			private float velocityInPower = 3f;

			// Token: 0x04000B5C RID: 2908
			[SerializeField]
			private float recorridoW_ToStartSlowDownTop = 0.8f;

			// Token: 0x04000B5D RID: 2909
			[SerializeField]
			private float recorridoW_ToStartSlowDownBottom = 0.4f;

			// Token: 0x04000B5E RID: 2910
			public bool lockMuscleJointsOnMaxForces = true;

			// Token: 0x04000B5F RID: 2911
			public float closeHandVelocity = 2f;

			// Token: 0x04000B60 RID: 2912
			public float handMuscleJointForce = 20000000f;

			// Token: 0x04000B61 RID: 2913
			public float handMuscleJointAngularForce = 150000f;

			// Token: 0x04000B62 RID: 2914
			public bool updateElasticity = true;

			// Token: 0x04000B63 RID: 2915
			public float minPhysicsElasticity = 1f;

			// Token: 0x04000B64 RID: 2916
			public float maxPhysicsElasticity = 4f;

			// Token: 0x04000B65 RID: 2917
			public float physicsElasticityOnMaxErection = 0.5f;

			// Token: 0x04000B66 RID: 2918
			public float minRecorridoElasticity = 0.2f;

			// Token: 0x04000B67 RID: 2919
			public float maxRecorridoElasticity = 1f;

			// Token: 0x04000B68 RID: 2920
			[ReadOnlyUI]
			[SerializeField]
			private Rigidbody m_penetrationKinematic;

			// Token: 0x04000B69 RID: 2921
			[ReadOnlyUI]
			[SerializeField]
			private Rigidbody m_handKinematic;

			// Token: 0x04000B6A RID: 2922
			[ReadOnlyUI]
			[SerializeField]
			private GenericPenetrationJointCreator m_GenericPenetrationJointCreator;

			// Token: 0x04000B6B RID: 2923
			[ReadOnlyUI]
			[SerializeField]
			private Transform m_handHole;

			// Token: 0x04000B6C RID: 2924
			[ReadOnlyUI]
			[SerializeField]
			private ConfigurableJoint m_handMuscleToHandInterJoint;

			// Token: 0x04000B6D RID: 2925
			[ReadOnlyUI]
			[SerializeField]
			private HandJobController.Orden.HandJobEstado m_lastHandJobEstado;

			// Token: 0x04000B6E RID: 2926
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadModSegunRecorridoW;

			// Token: 0x04000B6F RID: 2927
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadModSegunSaturacionDeOxigeno;

			// Token: 0x04000B70 RID: 2928
			[ReadOnlyUI]
			[SerializeField]
			private bool m_puedeCrearPenetrationJoints;

			// Token: 0x04000B71 RID: 2929
			[ReadOnlyUI]
			[SerializeField]
			private bool m_puedeCrearMuscleJoints;

			// Token: 0x04000B72 RID: 2930
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_lastFrameDirection;

			// Token: 0x04000B73 RID: 2931
			[ReadOnlyUI]
			[SerializeField]
			private bool m_ignoringCollisionWithHandJob;

			// Token: 0x04000B74 RID: 2932
			private ModificadorDeFloat m_handSizeModZ;

			// Token: 0x04000B75 RID: 2933
			private ModificadorDeFloat m_handSizeModX;

			// Token: 0x04000B76 RID: 2934
			private ModificadorDeFloat m_ForeArmHeigthMod;

			// Token: 0x04000B77 RID: 2935
			private ModificadorDeBool m_dickEstirable;

			// Token: 0x04000B78 RID: 2936
			private ModificadorDeBool m_turnOnJobLayerIKOR;

			// Token: 0x04000B79 RID: 2937
			private ModificadorDeBool m_femaleIsUsingHerHand;

			// Token: 0x04000B7A RID: 2938
			[SerializeField]
			private ModificadorDeFloat m_demandaDeOxigeno;

			// Token: 0x04000B7B RID: 2939
			[SerializeField]
			[ReadOnlyUI]
			private bool m_usaRest;

			// Token: 0x04000B7C RID: 2940
			[SerializeField]
			[ReadOnlyUI]
			private HandJobController.RestHandData m_restHandData;

			// Token: 0x04000B7D RID: 2941
			[ReadOnlyUI]
			[SerializeField]
			private Rigidbody m_handApoyoKinematic;

			// Token: 0x04000B7E RID: 2942
			[ReadOnlyUI]
			[SerializeField]
			private ConfigurableJoint m_handMuscleToHandApoyoInterJoint;

			// Token: 0x04000B7F RID: 2943
			[ReadOnlyUI]
			[SerializeField]
			private bool m_puedeCrearApoyoMuscleJoints;

			// Token: 0x04000B80 RID: 2944
			[ReadOnlyUI]
			[SerializeField]
			private bool m_ignoringCollisionWithHandApoyo;

			// Token: 0x04000B81 RID: 2945
			[ReadOnlyUI]
			[SerializeField]
			private HandJobController.Orden.ApoyoEstado m_lastApoyoEstado;

			// Token: 0x04000B82 RID: 2946
			private ModificadorDeBool m_enableTargetHitSkins;

			// Token: 0x0200025F RID: 607
			public enum HandJobEstado
			{
				// Token: 0x04000B84 RID: 2948
				None,
				// Token: 0x04000B85 RID: 2949
				esperandoApoyo,
				// Token: 0x04000B86 RID: 2950
				esperandoEjecutarGrab,
				// Token: 0x04000B87 RID: 2951
				esperandoInterMax,
				// Token: 0x04000B88 RID: 2952
				esperandoCerrarMano,
				// Token: 0x04000B89 RID: 2953
				esperandoPivotsAEndRecorrido,
				// Token: 0x04000B8A RID: 2954
				esperandoEjecutarJob,
				// Token: 0x04000B8B RID: 2955
				esperandoPivotsAFinalPositions,
				// Token: 0x04000B8C RID: 2956
				esperandoStartRecorrido,
				// Token: 0x04000B8D RID: 2957
				enJob
			}

			// Token: 0x02000260 RID: 608
			public enum ApoyoEstado
			{
				// Token: 0x04000B8F RID: 2959
				esperandoEjecutarApoyo,
				// Token: 0x04000B90 RID: 2960
				esperandoInterMax,
				// Token: 0x04000B91 RID: 2961
				esperandoCerrarMano,
				// Token: 0x04000B92 RID: 2962
				enApoyo
			}
		}

		// Token: 0x02000261 RID: 609
		public sealed class Estado : ControllerColaDePrioridadBase<HandJobController.Estado, HandJobController.Orden, HandJobController.Cola, HandJobController, int>.StadoBase
		{
		}

		// Token: 0x02000262 RID: 610
		public sealed class Cola : ControllerColaDePrioridadBase<HandJobController.Estado, HandJobController.Orden, HandJobController.Cola, HandJobController, int>.ColasBase
		{
		}

		// Token: 0x02000263 RID: 611
		[Serializable]
		public abstract class HandData
		{
			// Token: 0x06001022 RID: 4130 RVA: 0x0004AD58 File Offset: 0x00048F58
			protected bool IgualA(HandJobController.HandData other)
			{
				return this.picker == ((other != null) ? other.picker : null) && this.muscle == ((other != null) ? other.muscle : null) && this.foreArmMuscle == ((other != null) ? other.foreArmMuscle : null) && this.armMuscle == ((other != null) ? other.armMuscle : null) && this.hitSkin == ((other != null) ? other.hitSkin : null);
			}

			// Token: 0x06001023 RID: 4131 RVA: 0x0004ADD0 File Offset: 0x00048FD0
			public virtual void CheckAndThorw()
			{
				if (this.picker == null)
				{
					throw new ArgumentNullException("handPicker", "handPicker null reference.");
				}
				if (this.muscle == null)
				{
					throw new ArgumentNullException("handMuscle", "handMuscle null reference.");
				}
				if (this.foreArmMuscle == null)
				{
					throw new ArgumentNullException("ForeArmMuscle", "ForeArmMuscle null reference.");
				}
				if (this.armMuscle == null)
				{
					throw new ArgumentNullException("armMuscle", "armMuscle null reference.");
				}
				if (this.hitSkin == null)
				{
					throw new ArgumentNullException("handHitSkin", "handHitSkin null reference.");
				}
			}

			// Token: 0x04000B93 RID: 2963
			public HandPickController.Hand picker;

			// Token: 0x04000B94 RID: 2964
			public Muscle muscle;

			// Token: 0x04000B95 RID: 2965
			public Muscle foreArmMuscle;

			// Token: 0x04000B96 RID: 2966
			public Muscle armMuscle;

			// Token: 0x04000B97 RID: 2967
			public HitSkin hitSkin;
		}

		// Token: 0x02000264 RID: 612
		[Serializable]
		public class JobHandData : HandJobController.HandData
		{
			// Token: 0x06001025 RID: 4133 RVA: 0x0004AE5C File Offset: 0x0004905C
			public bool IgualA(HandJobController.JobHandData other)
			{
				return base.IgualA(other) && (this.grabInter == ((other != null) ? other.grabInter : null) && this.jobInter == ((other != null) ? other.jobInter : null) && this.lockInter == ((other != null) ? other.lockInter : null) && this.pivotsGrab == ((other != null) ? other.pivotsGrab : null)) && this.pivotsJob == ((other != null) ? other.pivotsJob : null);
			}

			// Token: 0x06001026 RID: 4134 RVA: 0x0004AEF4 File Offset: 0x000490F4
			public override void CheckAndThorw()
			{
				base.CheckAndThorw();
				if (this.pivotsGrab == null)
				{
					throw new ArgumentNullException("PivotsGrab", "PivotsGrab null reference.");
				}
				if (this.pivotsJob == null)
				{
					throw new ArgumentNullException("PivotsJob", "PivotsJob null reference.");
				}
				if (this.grabInter == null)
				{
					throw new ArgumentNullException("grabInter", "grabInter null reference.");
				}
				if (this.jobInter == null)
				{
					throw new ArgumentNullException("JobInter", "JobInter null reference.");
				}
				if (this.lockInter == null)
				{
					throw new ArgumentNullException("lockInter", "lockInter null reference.");
				}
				this.pivotsGrab.CheckAndThorw();
				this.pivotsJob.CheckAndThorw();
				InteractionTarget component = this.pivotsJob.handInteractionTarget.GetComponent<InteractionTarget>();
				if (component.twistWeight > 0f || component.swingWeight > 0f)
				{
					Debug.LogError("la mano job NO deberia tener mas aniomaciones, solo bajar y subir");
				}
			}

			// Token: 0x04000B98 RID: 2968
			public Interaccion grabInter;

			// Token: 0x04000B99 RID: 2969
			public Interaccion jobInter;

			// Token: 0x04000B9A RID: 2970
			public Interaccion lockInter;

			// Token: 0x04000B9B RID: 2971
			public SurfaceAndCenterPivotDeInteraction pivotsGrab;

			// Token: 0x04000B9C RID: 2972
			public SurfaceAndCenterPivotDeInteraction pivotsJob;
		}

		// Token: 0x02000265 RID: 613
		[Serializable]
		public class RestHandData : HandJobController.HandData
		{
			// Token: 0x06001028 RID: 4136 RVA: 0x0004AFF0 File Offset: 0x000491F0
			public bool IgualA(HandJobController.RestHandData other)
			{
				return base.IgualA(other) && this.restInter == ((other != null) ? other.restInter : null) && this.restPivot == ((other != null) ? other.restPivot : null);
			}

			// Token: 0x06001029 RID: 4137 RVA: 0x0004B030 File Offset: 0x00049230
			public override void CheckAndThorw()
			{
				base.CheckAndThorw();
				if (this.apoyo == PuntoDeApoyoSobreMaleBody.None)
				{
					throw new ArgumentNullException("apoyo", "apoyo null reference.");
				}
				if (this.restPivot == null)
				{
					throw new ArgumentNullException("restPivot", "restPivot null reference.");
				}
				if (this.restInter == null)
				{
					throw new ArgumentNullException("restInter", "restInter null reference.");
				}
				if (this.guiaApoyo == null)
				{
					throw new ArgumentNullException("restInter", "restInter null reference.");
				}
			}

			// Token: 0x04000B9D RID: 2973
			public Interaccion restInter;

			// Token: 0x04000B9E RID: 2974
			public SurfacePivotDeInteraction restPivot;

			// Token: 0x04000B9F RID: 2975
			public PuntoDeApoyoSobreMaleBody apoyo;

			// Token: 0x04000BA0 RID: 2976
			public Transform guiaApoyo;

			// Token: 0x04000BA1 RID: 2977
			public Quaternion skeletonOffsetRotation;
		}
	}
}
