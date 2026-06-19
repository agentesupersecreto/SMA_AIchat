using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.Interacciones;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.ArmaduresSkins;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200026E RID: 622
	public class MassageController : ControllerColaDePrioridadBase<MassageController.Estado, MassageController.Orden, MassageController.Cola, MassageController, int>
	{
		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06001067 RID: 4199 RVA: 0x00047639 File Offset: 0x00045839
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates3);
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06001068 RID: 4200 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06001069 RID: 4201 RVA: 0x00023905 File Offset: 0x00021B05
		protected override int cantidadDeEstados
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600106A RID: 4202 RVA: 0x0004BF00 File Offset: 0x0004A100
		// (remove) Token: 0x0600106B RID: 4203 RVA: 0x0004BF38 File Offset: 0x0004A138
		public event MassageController.OnUpdateHandJobOrdenHandler onMassageUpdate;

		// Token: 0x0600106C RID: 4204 RVA: 0x0004BF70 File Offset: 0x0004A170
		private void onUpdateHandJobOrdenHandler(Vector3 velocidadPhyscis, Vector3 recorridoPosition, Quaternion recoridoRotation, float recorridoVelocidad, float recorridoWeigth, bool comenzando, bool terminando, bool terminada, ICharacter por, HitSkin porHand, ICharacter to, MaleHitSkinBasica toMaleParte, RecorridoDeMassgeOnMaleBody.Recorrido recorrido)
		{
			MassageController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onMassageUpdate;
			if (onUpdateHandJobOrdenHandler == null)
			{
				return;
			}
			onUpdateHandJobOrdenHandler(velocidadPhyscis, recorridoPosition, recoridoRotation, recorridoVelocidad, recorridoWeigth, comenzando, terminando, terminada, por, porHand, to, toMaleParte, recorrido);
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0004BFA4 File Offset: 0x0004A1A4
		protected override void AwakeUnityEvent()
		{
			this.m_onJobHandlerUpdateProxy = new MassageController.OnUpdateHandJobOrdenHandler(this.onUpdateHandJobOrdenHandler);
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

		// Token: 0x0600106E RID: 4206 RVA: 0x0004C160 File Offset: 0x0004A360
		private void CalcularEnCamillaDeLadoDerecho(RecorridoDeMassgeOnMaleBody.Recorrido recorrido, out Side recorridoSide, out Side massageHadnInterSide, out Side apoyoSide, out PuntoDeApoyoSobreMaleBody apoyo)
		{
			apoyoSide = Side.R;
			recorridoSide = Side.R;
			switch (recorrido)
			{
			case RecorridoDeMassgeOnMaleBody.Recorrido.None:
				massageHadnInterSide = Side.none;
				apoyoSide = Side.none;
				apoyo = PuntoDeApoyoSobreMaleBody.None;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Chest:
				massageHadnInterSide = Side.L;
				apoyo = PuntoDeApoyoSobreMaleBody.Abdomen;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Nipple:
				massageHadnInterSide = Side.L;
				apoyo = PuntoDeApoyoSobreMaleBody.Abdomen;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Shoulder:
				massageHadnInterSide = Side.L;
				apoyo = PuntoDeApoyoSobreMaleBody.Chest;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Abdomen:
				massageHadnInterSide = Side.R;
				apoyo = PuntoDeApoyoSobreMaleBody.Chest;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Groin:
				massageHadnInterSide = Side.R;
				apoyo = PuntoDeApoyoSobreMaleBody.Abdomen;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Leg:
				massageHadnInterSide = Side.R;
				apoyo = PuntoDeApoyoSobreMaleBody.Groin;
				return;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Calf:
				massageHadnInterSide = Side.R;
				apoyo = PuntoDeApoyoSobreMaleBody.Knee;
				return;
			default:
				throw new ArgumentOutOfRangeException(recorrido.ToString());
			}
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x0004C1F4 File Offset: 0x0004A3F4
		public bool DoToConApoyoAutomaticoLadoDerecho(MaleChar todo, RecorridoDeMassgeOnMaleBody.Recorrido recorrido, float velocidad, float slowDownVelocity, float duracion, int prioridad, ControllerPrioridadConfig priConfig)
		{
			Quaternion armatureOrientationOffSet = todo.armatureOrientationOffSet;
			todo.GetComponentEnRoot<RecorridoDeMassgeOnMaleBody>();
			float estatura = this.m_AnimatorCharacter.estatura;
			Side side;
			Side side2;
			Side side3;
			PuntoDeApoyoSobreMaleBody puntoDeApoyoSobreMaleBody;
			this.CalcularEnCamillaDeLadoDerecho(recorrido, out side, out side2, out side3, out puntoDeApoyoSobreMaleBody);
			return this.DoTo(todo, recorrido, side, side2, new Side?(side3), new PuntoDeApoyoSobreMaleBody?(puntoDeApoyoSobreMaleBody), velocidad, slowDownVelocity, duracion, prioridad, priConfig);
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x0004C24C File Offset: 0x0004A44C
		public bool DoTo(MaleChar todo, RecorridoDeMassgeOnMaleBody.Recorrido recorrido, Side recorridoSide, Side massageHadnInterSide, Side? apoyoSide, PuntoDeApoyoSobreMaleBody? apoyo, float velocidad, float slowDownVelocity, float duracion, int prioridad, ControllerPrioridadConfig priConfig)
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
			MassageController.MassageData massageData = new MassageController.MassageData();
			MassageController.RestHandData restHandData = new MassageController.RestHandData();
			restHandData.apoyo = ((apoyo != null) ? apoyo.Value : PuntoDeApoyoSobreMaleBody.None);
			massageData.skeletonOffsetRotation = (restHandData.skeletonOffsetRotation = todo.armatureOrientationOffSet);
			int num;
			InteraccionSegundariaName interaccionSegundariaName;
			InteraccionSegundariaName interaccionSegundariaName2;
			InteraccionSegundariaName interaccionSegundariaName3;
			InteraccionSegundariaName interaccionSegundariaName4;
			if (massageHadnInterSide != Side.L)
			{
				if (massageHadnInterSide != Side.R)
				{
					throw new ArgumentOutOfRangeException(massageHadnInterSide.ToString());
				}
				num = 1;
				interaccionSegundariaName = InteraccionSegundariaName.massageStartHandR;
				interaccionSegundariaName2 = InteraccionSegundariaName.massageMotionHandR;
				interaccionSegundariaName3 = InteraccionSegundariaName.apoyarHandL;
				interaccionSegundariaName4 = InteraccionSegundariaName.lockBodyButHandR;
				massageData.picker = this.m_HandPickController.r;
				massageData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand);
				massageData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerArm);
				massageData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperArm);
				massageData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.r;
				restHandData.picker = this.m_HandPickController.l;
				restHandData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand);
				restHandData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerArm);
				restHandData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperArm);
				restHandData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.l;
			}
			else
			{
				num = 0;
				interaccionSegundariaName = InteraccionSegundariaName.massageStartHandL;
				interaccionSegundariaName2 = InteraccionSegundariaName.massageMotionHandL;
				interaccionSegundariaName3 = InteraccionSegundariaName.apoyarHandR;
				interaccionSegundariaName4 = InteraccionSegundariaName.lockBodyButHandL;
				massageData.picker = this.m_HandPickController.l;
				massageData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand);
				massageData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerArm);
				massageData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperArm);
				massageData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.l;
				restHandData.picker = this.m_HandPickController.r;
				restHandData.muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand);
				restHandData.foreArmMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerArm);
				restHandData.armMuscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperArm);
				restHandData.hitSkin = this.m_FemaleSkins.hitSkins.partes.manos.r;
			}
			RecorridoDeMassgeOnMaleBody componentInChildren = todo.GetComponentInChildren<RecorridoDeMassgeOnMaleBody>();
			if (componentInChildren == null)
			{
				Debug.LogError("no se encontro recorridos en personaje " + todo.nombreCompleto, this);
				return false;
			}
			InteraccionRootRecorridoCircular recorrido2 = componentInChildren.GetRecorrido(recorrido, recorridoSide);
			if (recorrido2 == null)
			{
				Debug.LogError("no se encontro recorrido virtual en personaje " + todo.nombreCompleto, this);
				return false;
			}
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = this.m_interacciones.Obtener(interaccionSegundariaName.GetInteractionID());
			if (((interaccionDeCharacterFemenino != null) ? interaccionDeCharacterFemenino.instancia : null) == null)
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
			massageData.massageStartLayer2Inter = interaccionDeCharacterFemenino.instancia;
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino2 = this.m_interacciones.Obtener(interaccionSegundariaName2.GetInteractionID());
			if (((interaccionDeCharacterFemenino2 != null) ? interaccionDeCharacterFemenino2.instancia : null) == null)
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
			massageData.massageMotionLayer3Inter = interaccionDeCharacterFemenino2.instancia;
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino3 = this.m_interacciones.Obtener(interaccionSegundariaName4.GetInteractionID());
			if (((interaccionDeCharacterFemenino3 != null) ? interaccionDeCharacterFemenino3.instancia : null) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Personaje: ",
					this.m_interacciones.character.nombreCompleto,
					" no tiene interaccion ",
					interaccionSegundariaName4.ToString(),
					" de id ",
					interaccionSegundariaName4.GetInteractionID().ToString()
				}), this);
				return false;
			}
			massageData.lockLayer3Inter = interaccionDeCharacterFemenino3.instancia;
			massageData.pivotsMassageStartLayer2 = massageData.massageStartLayer2Inter.GetComponentInChildren<SurfacePivotDeInteraction>();
			if (massageData.pivotsMassageStartLayer2 == null)
			{
				Debug.LogError("no se encontro pivots en interaccion MassageStart: " + interaccionSegundariaName.ToString(), this);
				return false;
			}
			massageData.pivotsMassageMotionLayer3 = massageData.massageMotionLayer3Inter.GetComponentInChildren<SurfacePivotDeInteraction>();
			if (massageData.pivotsMassageMotionLayer3 == null)
			{
				Debug.LogError("no se encontro pivots en interaccion MassageMotion: " + interaccionSegundariaName2.ToString(), this);
				return false;
			}
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino4 = this.m_interacciones.Obtener(interaccionSegundariaName3.GetInteractionID());
			if (((interaccionDeCharacterFemenino4 != null) ? interaccionDeCharacterFemenino4.instancia : null) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Personaje: ",
					this.m_interacciones.character.nombreCompleto,
					" no tiene interaccion ",
					interaccionSegundariaName3.ToString(),
					" de id ",
					interaccionSegundariaName3.GetInteractionID().ToString()
				}), this);
				return false;
			}
			restHandData.restInter = interaccionDeCharacterFemenino4.instancia;
			restHandData.restPivot = restHandData.restInter.GetComponentInChildren<SurfacePivotDeInteraction>();
			if (restHandData.restPivot == null)
			{
				Debug.LogError("no se encontro pivots en interaccion Apoyo: " + interaccionSegundariaName3.ToString(), this);
				return false;
			}
			if (restHandData.apoyo != PuntoDeApoyoSobreMaleBody.None)
			{
				restHandData.guiaApoyo = componentInChildren.GetApoyo(restHandData.apoyo, recorridoSide);
				if (restHandData.guiaApoyo == null)
				{
					Debug.LogError("no se encontro guia transform: " + restHandData.apoyo.ToString(), this);
					return false;
				}
			}
			bool flag = false;
			MassageController.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, num, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			MassageController.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, num, out tipoDeReUsoDeOrden) && orden2.recorridoDeMassage == recorrido2 && orden2.jobHandData.IgualA(massageData) && (orden2.restHandData == null || orden2.restHandData.IgualA(restHandData)))
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
			MassageController.Orden orden3 = new MassageController.Orden(recorrido, componentEnRoot, componentEnRoot2, massageData, (restHandData.apoyo == PuntoDeApoyoSobreMaleBody.None) ? null : restHandData, recorrido2, this.m_onJobHandlerUpdateProxy, velocidad, slowDownVelocity, num, prioridad, duracion, priConfig, false);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseTipoIdToindex(int id)
		{
			return id;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x0003011F File Offset: 0x0002E31F
		protected override MassageController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x000481D1 File Offset: 0x000463D1
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "try on current Main",
				editorTimeVisible = false
			};
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0004C997 File Offset: 0x0004AB97
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.DoToConApoyoAutomaticoLadoDerecho(CurrentMainCharacter<CurrentMainChar, MainChar>.current.character as MaleChar, RecorridoDeMassgeOnMaleBody.Recorrido.Chest, 1f, 0f, -1f, 0, ControllerPrioridadConfig.prioridad);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0004C9C7 File Offset: 0x0004ABC7
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Stop All",
				editorTimeVisible = false
			};
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x0004C9E0 File Offset: 0x0004ABE0
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			base.DetenerOrdenes();
		}

		// Token: 0x04000BD7 RID: 3031
		public const float minVelocity = 0.25f;

		// Token: 0x04000BD8 RID: 3032
		public const float medVelocity = 1f;

		// Token: 0x04000BD9 RID: 3033
		public const float maxVelocity = 5f;

		// Token: 0x04000BDB RID: 3035
		private ICharacterRespirador m_respirador;

		// Token: 0x04000BDC RID: 3036
		private IInteraccionesDeCharacterFemenino m_interacciones;

		// Token: 0x04000BDD RID: 3037
		private HandPickController m_HandPickController;

		// Token: 0x04000BDE RID: 3038
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000BDF RID: 3039
		private FemaleSkins m_FemaleSkins;

		// Token: 0x04000BE0 RID: 3040
		private AnimatorCharacter m_AnimatorCharacter;

		// Token: 0x04000BE1 RID: 3041
		private Deseos m_Deseos;

		// Token: 0x04000BE2 RID: 3042
		private TurnOffIKIfNoInteraction m_layer3IkTurnerOff;

		// Token: 0x04000BE3 RID: 3043
		private FemaleSimpleAi m_FemaleSimpleAi;

		// Token: 0x04000BE4 RID: 3044
		private MassageController.OnUpdateHandJobOrdenHandler m_onJobHandlerUpdateProxy;

		// Token: 0x0200026F RID: 623
		// (Invoke) Token: 0x0600107A RID: 4218
		public delegate void OnUpdateHandJobOrdenHandler(Vector3 velocidadPhyscis, Vector3 recorridoPosition, Quaternion recoridoRotation, float recorridoVelocidad, float recorridoWeigth, bool comenzando, bool terminando, bool terminada, ICharacter por, HitSkin porHand, ICharacter to, MaleHitSkinBasica toMaleParte, RecorridoDeMassgeOnMaleBody.Recorrido recorrido);

		// Token: 0x02000270 RID: 624
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<MassageController.Estado, MassageController.Orden, MassageController.Cola, MassageController, int>.OrdenBaseDeControllador
		{
			// Token: 0x0600107D RID: 4221 RVA: 0x0004C9F8 File Offset: 0x0004ABF8
			public Orden(RecorridoDeMassgeOnMaleBody.Recorrido Recorrido, MaleSkins targetSkins, PuppetMaster targetPuppet, MassageController.MassageData MassageHandData, MassageController.RestHandData RestHandData, InteraccionRootRecorridoCircular RecorridoDeMassage, MassageController.OnUpdateHandJobOrdenHandler OnUpdated, float Velocidad, float SlowDownVelocity, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, bool duracionEsFixed = false)
				: base(tipoId, prioridad, duracion, priConfig, duracionEsFixed)
			{
				if (targetSkins == null)
				{
					throw new ArgumentNullException("target", "target null reference.");
				}
				if (RecorridoDeMassage == null)
				{
					throw new ArgumentNullException("recorridoDePenetrador", "recorridoDePenetrador null reference.");
				}
				MassageHandData.CheckAndThorw();
				if (RestHandData != null)
				{
					RestHandData.CheckAndThorw();
				}
				this.m_targetSkins = targetSkins;
				this.m_targetPuppet = targetPuppet;
				this.m_massageHandData = MassageHandData;
				this.m_restHandData = RestHandData;
				this.m_usaRest = this.m_restHandData != null;
				this.m_recorridoDeMassage = RecorridoDeMassage;
				this.velocidad = Velocidad;
				this.slowDownVelocity = SlowDownVelocity;
				this.onUpdated = OnUpdated;
				this.m_recorrido = Recorrido;
			}

			// Token: 0x17000417 RID: 1047
			// (get) Token: 0x0600107E RID: 4222 RVA: 0x0004CB0D File Offset: 0x0004AD0D
			public InteraccionRootRecorridoCircular recorridoDeMassage
			{
				get
				{
					return this.m_recorridoDeMassage;
				}
			}

			// Token: 0x17000418 RID: 1048
			// (get) Token: 0x0600107F RID: 4223 RVA: 0x0004CB15 File Offset: 0x0004AD15
			public MassageController.MassageData jobHandData
			{
				get
				{
					return this.m_massageHandData;
				}
			}

			// Token: 0x06001080 RID: 4224 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnDetenidaPorUsuario(MassageController dataUpdate)
			{
			}

			// Token: 0x06001081 RID: 4225 RVA: 0x0004CB20 File Offset: 0x0004AD20
			protected override bool OnTerminando(MassageController dataUpdate, bool primerUpdate, MassageController.Orden ordenEsperandoDetencion)
			{
				if (this.m_handMuscleToHandInterJoint != null)
				{
					Object.Destroy(this.m_handMuscleToHandInterJoint);
					this.m_handMuscleToHandInterJoint = null;
				}
				if (this.m_handKinematic != null)
				{
					Object.Destroy(this.m_handKinematic);
					this.m_handKinematic = null;
				}
				if (this.m_recorridoDeMassage.recorriendo)
				{
					this.m_recorridoDeMassage.StopRecorrido();
				}
				this.m_massageHandData.massageStartLayer2Inter.Detener(true);
				this.m_massageHandData.massageMotionLayer3Inter.Detener(true);
				this.m_massageHandData.lockLayer3Inter.Detener(true);
				this.m_massageHandData.picker.w = Mathf.MoveTowards(this.m_massageHandData.picker.w, 0f, Time.deltaTime * this.closeHandVelocity);
				MassageController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
				if (onUpdateHandJobOrdenHandler != null)
				{
					onUpdateHandJobOrdenHandler(Vector3.zero, this.m_recorridoDeMassage.currentProyectedPoint, this.m_recorridoDeMassage.currentRotationFromTangnts, 0f, this.m_recorridoDeMassage.currentRecorridoWeigth, false, true, false, dataUpdate.m_AnimatorCharacter, this.m_massageHandData.hitSkin, this.m_targetSkins.character, null, this.m_recorrido);
				}
				bool flag = !this.m_massageHandData.massageStartLayer2Inter.ejecutandose && !this.m_massageHandData.massageMotionLayer3Inter.ejecutandose && !this.m_massageHandData.lockLayer3Inter.ejecutandose;
				bool flag2 = this.Apoyo_OnTerminando(dataUpdate, primerUpdate, ordenEsperandoDetencion);
				return flag && flag2;
			}

			// Token: 0x06001082 RID: 4226 RVA: 0x0004CC98 File Offset: 0x0004AE98
			protected override void OnTerminada(MassageController dataUpdate, bool abruptamente)
			{
				this.m_recorridoDeMassage.transformUpdated -= this.FixMassageMotionRotation;
				if (this.m_handMuscleToHandInterJoint != null)
				{
					Object.Destroy(this.m_handMuscleToHandInterJoint);
					this.m_handMuscleToHandInterJoint = null;
				}
				if (this.m_handKinematic != null)
				{
					Object.Destroy(this.m_handKinematic);
					this.m_handKinematic = null;
				}
				MassageController.Orden.IgnoreSkinToSkinsCollisions(this.m_massageHandData.hitSkin, this.m_targetSkins, false);
				this.m_ignoringCollisionWithHandMassage = false;
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_massageHandData.muscle, this.m_targetPuppet, false);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_massageHandData.foreArmMuscle, this.m_targetPuppet, false);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_massageHandData.armMuscle, this.m_targetPuppet, false);
				ModificadorDeBool enableTargetHitSkins = this.m_enableTargetHitSkins;
				if (enableTargetHitSkins != null)
				{
					enableTargetHitSkins.TryRemoverDeOwner(true);
				}
				ModificadorDeBool turnOnLayer3IKOR = this.m_turnOnLayer3IKOR;
				if (turnOnLayer3IKOR != null)
				{
					turnOnLayer3IKOR.TryRemoverDeOwner(true);
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
				ModificadorDeBool cerrandoManoDeMassage = this.m_cerrandoManoDeMassage;
				if (cerrandoManoDeMassage != null)
				{
					cerrandoManoDeMassage.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat cantidadDeDedosParaTomar = this.m_cantidadDeDedosParaTomar;
				if (cantidadDeDedosParaTomar != null)
				{
					cantidadDeDedosParaTomar.TryRemoverDeOwner(true);
				}
				this.m_recorridoDeMassage.ResetRecorrido();
				this.m_recorridoDeMassage.targetTransform = null;
				this.m_massageHandData.picker.useCollision = true;
				this.m_massageHandData.picker.overrideLayerMask = null;
				MassageController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
				if (onUpdateHandJobOrdenHandler != null)
				{
					onUpdateHandJobOrdenHandler(Vector3.zero, this.m_recorridoDeMassage.currentProyectedPoint, this.m_recorridoDeMassage.currentRotationFromTangnts, 0f, this.m_recorridoDeMassage.currentRecorridoWeigth, false, false, true, dataUpdate.m_AnimatorCharacter, this.m_massageHandData.hitSkin, this.m_targetSkins.character, null, this.m_recorrido);
				}
				this.Apoyo_OnTerminada(dataUpdate, abruptamente);
			}

			// Token: 0x06001083 RID: 4227 RVA: 0x0004CE7C File Offset: 0x0004B07C
			protected override void OnStart(MassageController dataUpdate)
			{
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_massageHandData.muscle, this.m_targetPuppet, true);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_massageHandData.foreArmMuscle, this.m_targetPuppet, true);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_massageHandData.armMuscle, this.m_targetPuppet, true);
				this.m_recorridoDeMassage.transformUpdated -= this.FixMassageMotionRotation;
				this.m_recorridoDeMassage.transformUpdated += this.FixMassageMotionRotation;
				this.m_handKinematic = this.m_massageHandData.pivotsMassageMotionLayer3.handnteractionTarget.gameObject.AddComponent<Rigidbody>();
				this.m_handKinematic.isKinematic = true;
				if (!this.m_recorridoDeMassage.init)
				{
					this.m_recorridoDeMassage.Init(this.m_recorridoDeMassage.config, null);
				}
				else
				{
					this.m_recorridoDeMassage.ReInitCurvas();
				}
				this.m_massageHandData.picker.w = 0f;
				this.m_massageHandData.picker.useCollision = false;
				this.m_turnOnLayer3IKOR = dataUpdate.m_layer3IkTurnerOff.forceTurnOnOR.ObtenerModificadorNotNull(dataUpdate);
				this.m_turnOnLayer3IKOR.valor.valor = true;
				this.m_femaleIsUsingHerHand = dataUpdate.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassageModificable(this.m_massageHandData.hitSkin.side).ObtenerModificadorNotNull(dataUpdate);
				this.m_femaleIsUsingHerHand.valor.valor = true;
				this.m_demandaDeOxigeno = dataUpdate.m_respirador.demandaDeOxigenoModificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_demandaDeOxigeno.valor.valor = 1f;
				this.m_cerrandoManoDeMassage = this.m_massageHandData.picker.cerrandoManoOR.ObtenerModificadorNotNull(dataUpdate);
				this.m_cantidadDeDedosParaTomar = this.m_massageHandData.picker.dedosTomandoMinCountMod.ObtenerModificadorNotNull(dataUpdate);
				this.m_cantidadDeDedosParaTomar.valor.valor = 0f;
				MassageController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
				if (onUpdateHandJobOrdenHandler != null)
				{
					onUpdateHandJobOrdenHandler(Vector3.zero, this.m_recorridoDeMassage.currentProyectedPoint, this.m_recorridoDeMassage.currentRotationFromTangnts, 0f, this.m_recorridoDeMassage.currentRecorridoWeigth, true, false, false, dataUpdate.m_AnimatorCharacter, this.m_massageHandData.hitSkin, this.m_targetSkins.character, null, this.m_recorrido);
				}
				this.m_lastFramePosition = this.m_massageHandData.pivotsMassageMotionLayer3.superficiePivot.position;
				this.m_enableTargetHitSkins = this.m_targetSkins.enableHitSkinsOR.ObtenerModificadorNotNull(dataUpdate);
				this.m_enableTargetHitSkins.valor.valor = true;
				this.Apoyo_OnStart(dataUpdate);
			}

			// Token: 0x06001084 RID: 4228 RVA: 0x0004D104 File Offset: 0x0004B304
			private void Apoyo_OnStart(MassageController dataUpdate)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.muscle, this.m_targetPuppet, true);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.foreArmMuscle, this.m_targetPuppet, true);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.armMuscle, this.m_targetPuppet, true);
				this.m_handApoyoKinematic = this.m_restHandData.restPivot.handnteractionTarget.gameObject.AddComponent<Rigidbody>();
				this.m_handApoyoKinematic.isKinematic = true;
				this.m_restHandData.picker.w = 0f;
				this.m_restHandData.picker.useCollision = false;
			}

			// Token: 0x06001085 RID: 4229 RVA: 0x0004D1B1 File Offset: 0x0004B3B1
			private bool Apoyo_DataIsValid(MassageController dataUpdate, bool esPrimerUpdate)
			{
				return !this.m_usaRest || !(this.m_restHandData.guiaApoyo == null);
			}

			// Token: 0x06001086 RID: 4230 RVA: 0x0004D1D4 File Offset: 0x0004B3D4
			private void Apoyo_UpdateOrden(MassageController dataUpdate, bool esPrimerUpdate, ICharacter femChar, float femCharScale)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				if (!this.m_ignoringCollisionWithHandApoyo && this.m_targetSkins.hitSkins.AreEnabled())
				{
					MassageController.Orden.IgnoreSkinToSkinsCollisions(this.m_restHandData.hitSkin, this.m_targetSkins, true);
					this.m_ignoringCollisionWithHandApoyo = true;
				}
				this.m_puedeCrearApoyoMuscleJoints = false;
				MassageController.Orden.UpdateSurfacePivot(this.m_restHandData.restPivot, this.m_restHandData.guiaApoyo, this.m_restHandData.skeletonOffsetRotation, femChar, femCharScale);
			}

			// Token: 0x06001087 RID: 4231 RVA: 0x0004D254 File Offset: 0x0004B454
			private void Apoyo_UpdateOrdenEstado(MassageController dataUpdate, bool esPrimerUpdate)
			{
				if (!this.m_usaRest)
				{
					return;
				}
				MassageController.Orden.ApoyoEstado apoyoEstado = this.GetApoyoEstado(dataUpdate);
				this.UpdateApoyoSegunEstado(apoyoEstado);
				if (apoyoEstado != this.m_lastApoyoEstado)
				{
					this.m_lastApoyoEstado = apoyoEstado;
				}
				if (this.m_puedeCrearApoyoMuscleJoints)
				{
					if (this.m_handMuscleToHandApoyoInterJoint == null)
					{
						this.m_handMuscleToHandApoyoInterJoint = MassageController.Orden.GenerateJoint(this.m_restHandData.muscle, this.m_restHandData.restPivot.handnteractionTarget);
						MassageController.Orden.UpdateJointDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointForce, this.m_restHandData.muscle, 0f, 0f, false);
						MassageController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointAngularForce, this.m_restHandData.muscle, 0f, 0f, false);
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
					MassageController.Orden.UpdateJointDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointForce, this.m_restHandData.muscle, this.m_handMuscleToHandApoyoInterJoint.xDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
					MassageController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandApoyoInterJoint, this.handMuscleJointAngularForce, this.m_restHandData.muscle, this.m_handMuscleToHandApoyoInterJoint.angularXDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
				}
			}

			// Token: 0x06001088 RID: 4232 RVA: 0x0004D3C0 File Offset: 0x0004B5C0
			private bool Apoyo_OnTerminando(MassageController dataUpdate, bool primerUpdate, MassageController.Orden ordenEsperandoDetencion)
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

			// Token: 0x06001089 RID: 4233 RVA: 0x0004D474 File Offset: 0x0004B674
			private void Apoyo_OnTerminada(MassageController dataUpdate, bool abruptamente)
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
				MassageController.Orden.IgnoreSkinToSkinsCollisions(this.m_restHandData.hitSkin, this.m_targetSkins, false);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.muscle, this.m_targetPuppet, false);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.foreArmMuscle, this.m_targetPuppet, false);
				MassageController.Orden.IgnoreMuscleToPuppetCollisions(this.m_restHandData.armMuscle, this.m_targetPuppet, false);
				this.m_ignoringCollisionWithHandApoyo = false;
				this.m_restHandData.picker.useCollision = true;
				this.m_restHandData.picker.overrideLayerMask = null;
			}

			// Token: 0x0600108A RID: 4234 RVA: 0x0004D554 File Offset: 0x0004B754
			protected override bool UpdateOrden(MassageController dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				Interaccion massageStartLayer2Inter = this.m_massageHandData.massageStartLayer2Inter;
				if (((massageStartLayer2Inter != null) ? massageStartLayer2Inter.owner : null) == null)
				{
					return false;
				}
				Interaccion massageMotionLayer3Inter = this.m_massageHandData.massageMotionLayer3Inter;
				if (((massageMotionLayer3Inter != null) ? massageMotionLayer3Inter.owner : null) == null)
				{
					return false;
				}
				if (this.m_massageHandData.massageStartLayer2Inter.owner != dataUpdate.m_interacciones)
				{
					return false;
				}
				if (this.m_massageHandData.massageMotionLayer3Inter.owner != dataUpdate.m_interacciones)
				{
					return false;
				}
				if (this.m_recorridoDeMassage == null)
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
				if (!this.m_ignoringCollisionWithHandMassage && this.m_targetSkins.hitSkins.AreEnabled())
				{
					MassageController.Orden.IgnoreSkinToSkinsCollisions(this.m_massageHandData.hitSkin, this.m_targetSkins, true);
					this.m_ignoringCollisionWithHandMassage = true;
				}
				this.m_cerrandoManoDeMassage.valor.valor = false;
				ICharacter character = this.m_massageHandData.massageStartLayer2Inter.owner.character;
				float escala = character.escala;
				this.m_puedeCrearMuscleJoints = false;
				this.UpdateOxigeno(dataUpdate);
				this.m_recorridoDeMassage.config.velocidad = this.velocidad * this.m_velocidadModSegunSaturacionDeOxigeno;
				this.m_recorridoDeMassage.targetTransform = this.m_massageHandData.pivotsMassageMotionLayer3.superficiePivot;
				this.Apoyo_UpdateOrden(dataUpdate, esPrimerUpdate, character, escala);
				MassageController.Orden.MassageEstado handJobEstado = this.GetHandJobEstado(dataUpdate);
				this.UpdateHandJobSegunEstado(dataUpdate, handJobEstado);
				if (handJobEstado != this.m_lastHandJobEstado)
				{
					this.m_lastHandJobEstado = handJobEstado;
				}
				if (this.m_puedeCrearMuscleJoints)
				{
					if (this.m_handMuscleToHandInterJoint == null)
					{
						this.m_handMuscleToHandInterJoint = MassageController.Orden.GenerateJoint(this.m_massageHandData.muscle, this.m_massageHandData.pivotsMassageMotionLayer3.handnteractionTarget);
						MassageController.Orden.UpdateJointDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointForce, this.m_massageHandData.muscle, 0f, 0f, false);
						MassageController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointAngularForce, this.m_massageHandData.muscle, 0f, 0f, false);
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
					MassageController.Orden.UpdateJointDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointForce, this.m_massageHandData.muscle, this.m_handMuscleToHandInterJoint.xDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
					MassageController.Orden.UpdateJointAngularDrivers(this.m_handMuscleToHandInterJoint, this.handMuscleJointAngularForce, this.m_massageHandData.muscle, this.m_handMuscleToHandInterJoint.angularXDrive.positionSpring, base.estadoDeltaTime, this.lockMuscleJointsOnMaxForces);
				}
				this.Apoyo_UpdateOrdenEstado(dataUpdate, esPrimerUpdate);
				Vector3 position = this.m_massageHandData.pivotsMassageMotionLayer3.superficiePivot.position;
				Vector3 vector = ((base.estadoDeltaTime == 0f) ? Vector3.zero : ((position - this.m_lastFramePosition) / base.estadoDeltaTime));
				MaleHitSkinBasica maleHitSkinBasica;
				Vector3 vector2;
				Vector3 vector3;
				if (handJobEstado == MassageController.Orden.MassageEstado.enMassage && MassageController.Orden.TryGetMassagedMaleSkin(this.m_massageHandData.picker, out maleHitSkinBasica, out vector2, out vector3))
				{
					MassageController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler = this.onUpdated;
					if (onUpdateHandJobOrdenHandler != null)
					{
						onUpdateHandJobOrdenHandler(vector, this.m_recorridoDeMassage.currentProyectedPoint, this.m_recorridoDeMassage.currentRotationFromTangnts, this.velocidad, this.m_recorridoDeMassage.currentRecorridoWeigth, false, false, false, dataUpdate.m_AnimatorCharacter, this.m_massageHandData.hitSkin, this.m_targetSkins.character, maleHitSkinBasica, this.m_recorrido);
					}
				}
				else
				{
					MassageController.OnUpdateHandJobOrdenHandler onUpdateHandJobOrdenHandler2 = this.onUpdated;
					if (onUpdateHandJobOrdenHandler2 != null)
					{
						onUpdateHandJobOrdenHandler2(Vector3.zero, this.m_recorridoDeMassage.currentProyectedPoint, this.m_recorridoDeMassage.currentRotationFromTangnts, 0f, this.m_recorridoDeMassage.currentRecorridoWeigth, true, false, false, dataUpdate.m_AnimatorCharacter, this.m_massageHandData.hitSkin, this.m_targetSkins.character, null, this.m_recorrido);
					}
				}
				this.m_lastFramePosition = position;
				return true;
			}

			// Token: 0x0600108B RID: 4235 RVA: 0x0004D9B8 File Offset: 0x0004BBB8
			private void FarthestRecorridoAndPivotPoses(MassageController dataUpdate)
			{
				if (this.m_recorridoDeMassage.recorriendo)
				{
					this.m_recorridoDeMassage.PauseRecorrido();
				}
				else
				{
					float recorridoFarthestW = this.GetRecorridoFarthestW(dataUpdate);
					this.m_recorridoDeMassage.UpdateTo(recorridoFarthestW, false);
				}
				this.SetPivotToCurrentRecorrido(this.m_massageHandData.pivotsMassageMotionLayer3, this.m_massageHandData.skeletonOffsetRotation);
				this.SetPivotToCurrentRecorrido(this.m_massageHandData.pivotsMassageStartLayer2, this.m_massageHandData.skeletonOffsetRotation);
			}

			// Token: 0x0600108C RID: 4236 RVA: 0x0004DA2C File Offset: 0x0004BC2C
			private float GetRecorridoFarthestW(MassageController dataUpdate)
			{
				Vector3 posicionFinal = dataUpdate.m_AnimatorCharacter.bones.chest.posicionFinal;
				float num;
				this.m_recorridoDeMassage.FindFarthestPointFrom(posicionFinal, out num);
				return num;
			}

			// Token: 0x0600108D RID: 4237 RVA: 0x0004DA60 File Offset: 0x0004BC60
			private void UpdateHandJobSegunEstado(MassageController dataUpdate, MassageController.Orden.MassageEstado estado)
			{
				switch (estado)
				{
				case MassageController.Orden.MassageEstado.None:
					return;
				case MassageController.Orden.MassageEstado.esperandoApoyo:
					this.FarthestRecorridoAndPivotPoses(dataUpdate);
					this.EjecutarLock();
					return;
				case MassageController.Orden.MassageEstado.esperandoEjecutarMassageStart:
					this.FarthestRecorridoAndPivotPoses(dataUpdate);
					this.m_massageHandData.massageStartLayer2Inter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 1f, 1f, false);
					this.EjecutarLock();
					return;
				case MassageController.Orden.MassageEstado.esperandoMassageStartInterMax:
					this.FarthestRecorridoAndPivotPoses(dataUpdate);
					return;
				case MassageController.Orden.MassageEstado.esperandoEjecutarMassageMotion:
					this.FarthestRecorridoAndPivotPoses(dataUpdate);
					this.FixMassageMotionRotation(false);
					this.m_massageHandData.massageMotionLayer3Inter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 2f, 1f, false);
					return;
				case MassageController.Orden.MassageEstado.esperandoMassageMotionInterMax:
					this.FarthestRecorridoAndPivotPoses(dataUpdate);
					this.FixMassageMotionRotation(false);
					this.m_massageHandData.picker.w = Mathf.MoveTowards(this.m_massageHandData.picker.w, 1f, Time.deltaTime * this.closeHandVelocity);
					return;
				case MassageController.Orden.MassageEstado.esperandoCerrarMano:
					this.m_cerrandoManoDeMassage.valor.valor = true;
					this.m_puedeCrearMuscleJoints = true;
					this.FarthestRecorridoAndPivotPoses(dataUpdate);
					this.FixMassageMotionRotation(false);
					this.m_massageHandData.picker.w = Mathf.MoveTowards(this.m_massageHandData.picker.w, 1f, Time.deltaTime * this.closeHandVelocity);
					return;
				case MassageController.Orden.MassageEstado.esperandoStartRecorrido:
				{
					this.m_cerrandoManoDeMassage.valor.valor = true;
					this.m_puedeCrearMuscleJoints = true;
					float recorridoFarthestW = this.GetRecorridoFarthestW(dataUpdate);
					this.m_recorridoDeMassage.UpdateTo(this.m_recorridoDeMassage.currentRecorridoWeigth, true);
					this.m_recorridoDeMassage.StartRecorrido();
					this.SetPivotToRecorrido(this.m_massageHandData.pivotsMassageStartLayer2, this.m_massageHandData.skeletonOffsetRotation, recorridoFarthestW, false);
					return;
				}
				case MassageController.Orden.MassageEstado.enMassage:
				{
					this.m_cerrandoManoDeMassage.valor.valor = true;
					this.m_puedeCrearMuscleJoints = true;
					float recorridoFarthestW2 = this.GetRecorridoFarthestW(dataUpdate);
					if (!this.m_recorridoDeMassage.recorriendo || this.m_recorridoDeMassage.paused)
					{
						this.m_recorridoDeMassage.StartRecorrido();
					}
					this.SetPivotToRecorrido(this.m_massageHandData.pivotsMassageStartLayer2, this.m_massageHandData.skeletonOffsetRotation, recorridoFarthestW2, false);
					this.EjecutarLock();
					return;
				}
				default:
					throw new ArgumentOutOfRangeException(estado.ToString());
				}
			}

			// Token: 0x0600108E RID: 4238 RVA: 0x0004DCAC File Offset: 0x0004BEAC
			private void EjecutarLock()
			{
				if (!this.m_massageHandData.lockLayer3Inter.ejecutandose && !this.m_massageHandData.lockLayer3Inter.EsperandoEjecutarse())
				{
					this.m_massageHandData.lockLayer3Inter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 0.25f, 0.25f, false);
				}
			}

			// Token: 0x0600108F RID: 4239 RVA: 0x0004DD0C File Offset: 0x0004BF0C
			private MassageController.Orden.MassageEstado GetHandJobEstado(MassageController dataUpdate)
			{
				if (this.m_usaRest && !this.m_restHandData.restInter.ejecutandose && !this.m_restHandData.restInter.EsperandoEjecutarse())
				{
					return MassageController.Orden.MassageEstado.esperandoApoyo;
				}
				if (this.m_usaRest && this.m_restHandData.restInter.currentEstado.EstadosTimerWeigthPromedio(0f) < 0.666f)
				{
					return MassageController.Orden.MassageEstado.esperandoApoyo;
				}
				if (!this.m_massageHandData.massageStartLayer2Inter.ejecutandose && !this.m_massageHandData.massageStartLayer2Inter.EsperandoEjecutarse())
				{
					return MassageController.Orden.MassageEstado.esperandoEjecutarMassageStart;
				}
				if (this.m_massageHandData.massageStartLayer2Inter.currentEstado.EstadosTimerWeigthPromedio(0f) < 0.666f)
				{
					return MassageController.Orden.MassageEstado.esperandoMassageStartInterMax;
				}
				if (!this.m_massageHandData.massageMotionLayer3Inter.ejecutandose && !this.m_massageHandData.massageMotionLayer3Inter.EsperandoEjecutarse())
				{
					return MassageController.Orden.MassageEstado.esperandoEjecutarMassageMotion;
				}
				if (!this.m_massageHandData.massageMotionLayer3Inter.currentEstado.EstadosTimerWeigthPromedio(0f).AlmostEqualV2(1f, 1E-45f))
				{
					return MassageController.Orden.MassageEstado.esperandoMassageMotionInterMax;
				}
				if (!this.m_massageHandData.picker.tomando)
				{
					return MassageController.Orden.MassageEstado.esperandoCerrarMano;
				}
				if (!this.m_recorridoDeMassage.recorriendo)
				{
					return MassageController.Orden.MassageEstado.esperandoStartRecorrido;
				}
				return MassageController.Orden.MassageEstado.enMassage;
			}

			// Token: 0x06001090 RID: 4240 RVA: 0x0004DE32 File Offset: 0x0004C032
			private void FixMassageMotionRotation()
			{
				this.FixMassageMotionRotation(true);
			}

			// Token: 0x06001091 RID: 4241 RVA: 0x0004DE3C File Offset: 0x0004C03C
			private void FixMassageMotionRotation(bool AddSkeletonOffset)
			{
				Transform superficiePivot = this.m_massageHandData.pivotsMassageMotionLayer3.superficiePivot;
				Quaternion quaternion;
				if (AddSkeletonOffset)
				{
					quaternion = superficiePivot.rotation * this.m_massageHandData.skeletonOffsetRotation;
				}
				else
				{
					quaternion = superficiePivot.rotation;
				}
				Transform handnteractionPivot = this.m_massageHandData.pivotsMassageStartLayer2.handnteractionPivot;
				Quaternion quaternion2 = Quaternion.LookRotation(quaternion * Vector3.forward, handnteractionPivot.forward);
				superficiePivot.rotation = quaternion2;
			}

			// Token: 0x06001092 RID: 4242 RVA: 0x0004DEAC File Offset: 0x0004C0AC
			private void UpdateOxigeno(MassageController dataUpdate)
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
				this.m_demandaDeOxigeno.valor.valor = MathfExtension.LerpConMedio(1f, 10f, 40f, num2);
			}

			// Token: 0x06001093 RID: 4243 RVA: 0x0004DFA8 File Offset: 0x0004C1A8
			[Obsolete]
			private void UpdateRecorridoVelocidadMod(MassageController dataUpdate)
			{
				float num = Mathf.InverseLerp(0f, 1f, this.m_recorridoDeMassage.currentRecorridoWeigth);
				float num2 = Mathf.InverseLerp(this.recorridoW_ToStartSlowDownTop, 1f, num).InPow(this.velocityInPower);
				float num3 = Mathf.InverseLerp(this.recorridoW_ToStartSlowDownBottom, 0f, num).InPow(this.velocityInPower);
				float num4 = Mathf.Lerp(1f, this.minVelocityMod, num2);
				float num5 = Mathf.Lerp(1f, this.minVelocityMod, num3);
				float num6 = Mathf.InverseLerp(0f, 1f, 1f);
				float num7 = ((num6 >= 1f) ? 0.9f : ((num6 <= 0f) ? 1.1f : 1f));
				this.m_velocidadModSegunRecorridoW = num4 * num5 * num7;
			}

			// Token: 0x06001094 RID: 4244 RVA: 0x0004E07C File Offset: 0x0004C27C
			private static bool TryGetMassagedMaleSkin(HandPickController.Hand picker, out MaleHitSkinBasica maleHitSkin, out Vector3 tomandoPunto, out Vector3 tomandoNormal)
			{
				maleHitSkin = null;
				tomandoPunto = default(Vector3);
				tomandoNormal = default(Vector3);
				ValueTuple<Collider, Vector3, Vector3, int> valueTuple = (from c in picker.collidersTomando
					group c by c.Item1 into g
					select new ValueTuple<Collider, Vector3, Vector3, int>(g.Key, g.FirstOrDefault<ValueTuple<Collider, Vector3, Vector3>>().Item2, g.FirstOrDefault<ValueTuple<Collider, Vector3, Vector3>>().Item3, g.Count<ValueTuple<Collider, Vector3, Vector3>>()) into p
					orderby p.Item4 descending
					select p).FirstOrDefault<ValueTuple<Collider, Vector3, Vector3, int>>();
				if (valueTuple.Item1 == null)
				{
					return false;
				}
				maleHitSkin = MaleHitSkinBasica.ObtenerSkinDeCollider(valueTuple.Item1);
				if (maleHitSkin == null)
				{
					return false;
				}
				tomandoPunto = valueTuple.Item2;
				tomandoNormal = valueTuple.Item3;
				return true;
			}

			// Token: 0x06001095 RID: 4245 RVA: 0x0004E154 File Offset: 0x0004C354
			private void SetPivotToCurrentRecorrido(SurfacePivotDeInteraction pivots, Quaternion skeletonOffsetRotation)
			{
				pivots.superficiePivot.SetPositionAndRotation(this.m_recorridoDeMassage.currentProyectedPoint, this.m_recorridoDeMassage.currentRotationFromTangnts * skeletonOffsetRotation);
			}

			// Token: 0x06001096 RID: 4246 RVA: 0x0004E180 File Offset: 0x0004C380
			private void SetPivotToRecorrido(SurfacePivotDeInteraction pivots, Quaternion skeletonOffsetRotation, float w, bool updateRecorrido)
			{
				if (updateRecorrido)
				{
					this.m_recorridoDeMassage.UpdateTo(w, false);
					pivots.superficiePivot.SetPositionAndRotation(this.m_recorridoDeMassage.currentProyectedPoint, Quaternion.LookRotation(this.m_recorridoDeMassage.currentTangent, this.m_recorridoDeMassage.currentCrossTangent) * skeletonOffsetRotation);
					return;
				}
				Vector3 vector;
				Quaternion quaternion;
				this.m_recorridoDeMassage.Evaluate(w, out vector, out quaternion);
				pivots.superficiePivot.SetPositionAndRotation(vector, quaternion * skeletonOffsetRotation);
			}

			// Token: 0x06001097 RID: 4247 RVA: 0x0004E1FC File Offset: 0x0004C3FC
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

			// Token: 0x06001098 RID: 4248 RVA: 0x0004E2A4 File Offset: 0x0004C4A4
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

			// Token: 0x06001099 RID: 4249 RVA: 0x0004E2E4 File Offset: 0x0004C4E4
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

			// Token: 0x0600109A RID: 4250 RVA: 0x0004E354 File Offset: 0x0004C554
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

			// Token: 0x0600109B RID: 4251 RVA: 0x0004E3E4 File Offset: 0x0004C5E4
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

			// Token: 0x17000419 RID: 1049
			// (get) Token: 0x0600109C RID: 4252 RVA: 0x0004E46A File Offset: 0x0004C66A
			public MassageController.RestHandData restHandData
			{
				get
				{
					return this.m_restHandData;
				}
			}

			// Token: 0x0600109D RID: 4253 RVA: 0x0004E474 File Offset: 0x0004C674
			private void UpdateApoyoSegunEstado(MassageController.Orden.ApoyoEstado estado)
			{
				switch (estado)
				{
				case MassageController.Orden.ApoyoEstado.esperandoEjecutarApoyo:
					this.m_restHandData.restInter.Ejecutar(base.prioridad, base.duracion, base.priConfig, 1f, 1f, false);
					return;
				case MassageController.Orden.ApoyoEstado.esperandoInterMax:
					return;
				case MassageController.Orden.ApoyoEstado.esperandoCerrarMano:
					this.m_puedeCrearApoyoMuscleJoints = true;
					this.m_restHandData.picker.w = Mathf.MoveTowards(this.m_restHandData.picker.w, 1f, Time.deltaTime * this.closeHandVelocity);
					return;
				case MassageController.Orden.ApoyoEstado.enApoyo:
					this.m_puedeCrearApoyoMuscleJoints = true;
					return;
				default:
					throw new ArgumentOutOfRangeException(estado.ToString());
				}
			}

			// Token: 0x0600109E RID: 4254 RVA: 0x0004E524 File Offset: 0x0004C724
			private MassageController.Orden.ApoyoEstado GetApoyoEstado(MassageController dataUpdate)
			{
				if (!this.m_restHandData.restInter.ejecutandose && !this.m_restHandData.restInter.EsperandoEjecutarse())
				{
					return MassageController.Orden.ApoyoEstado.esperandoEjecutarApoyo;
				}
				if (!this.m_restHandData.restInter.currentEstado.EstadosTimerWeigthPromedio(0f).AlmostEqualV2(1f, 1E-45f))
				{
					return MassageController.Orden.ApoyoEstado.esperandoInterMax;
				}
				if (!this.m_restHandData.picker.tomando)
				{
					return MassageController.Orden.ApoyoEstado.esperandoCerrarMano;
				}
				return MassageController.Orden.ApoyoEstado.enApoyo;
			}

			// Token: 0x0600109F RID: 4255 RVA: 0x0004AD29 File Offset: 0x00048F29
			private static void UpdateSurfacePivot(SurfacePivotDeInteraction pivots, Transform guia, Quaternion skeletonOffsetRotation, ICharacter femChar, float femCharScale)
			{
				pivots.superficiePivot.SetPositionAndRotation(guia.position, guia.rotation * skeletonOffsetRotation);
			}

			// Token: 0x04000BE5 RID: 3045
			[SerializeField]
			[ReadOnlyUI]
			private RecorridoDeMassgeOnMaleBody.Recorrido m_recorrido;

			// Token: 0x04000BE6 RID: 3046
			[SerializeField]
			[ReadOnlyUI]
			private PuppetMaster m_targetPuppet;

			// Token: 0x04000BE7 RID: 3047
			[SerializeField]
			[ReadOnlyUI]
			private MaleSkins m_targetSkins;

			// Token: 0x04000BE8 RID: 3048
			[SerializeField]
			[ReadOnlyUI]
			private MassageController.MassageData m_massageHandData;

			// Token: 0x04000BE9 RID: 3049
			[SerializeField]
			[ReadOnlyUI]
			private InteraccionRootRecorridoCircular m_recorridoDeMassage;

			// Token: 0x04000BEA RID: 3050
			public MassageController.OnUpdateHandJobOrdenHandler onUpdated;

			// Token: 0x04000BEB RID: 3051
			public float velocidad;

			// Token: 0x04000BEC RID: 3052
			public float slowDownVelocity;

			// Token: 0x04000BED RID: 3053
			[SerializeField]
			private float velocidadParaMinRecorrido = 4f;

			// Token: 0x04000BEE RID: 3054
			[SerializeField]
			private float minVelocityMod = 0.1f;

			// Token: 0x04000BEF RID: 3055
			[SerializeField]
			private float velocityInPower = 3f;

			// Token: 0x04000BF0 RID: 3056
			[SerializeField]
			private float recorridoW_ToStartSlowDownTop = 0.8f;

			// Token: 0x04000BF1 RID: 3057
			[SerializeField]
			private float recorridoW_ToStartSlowDownBottom = 0.4f;

			// Token: 0x04000BF2 RID: 3058
			public bool lockMuscleJointsOnMaxForces = true;

			// Token: 0x04000BF3 RID: 3059
			public float closeHandVelocity = 2f;

			// Token: 0x04000BF4 RID: 3060
			public float handMuscleJointForce = 20000000f;

			// Token: 0x04000BF5 RID: 3061
			public float handMuscleJointAngularForce = 150000f;

			// Token: 0x04000BF6 RID: 3062
			[ReadOnlyUI]
			[SerializeField]
			private Rigidbody m_handKinematic;

			// Token: 0x04000BF7 RID: 3063
			[ReadOnlyUI]
			[SerializeField]
			private ConfigurableJoint m_handMuscleToHandInterJoint;

			// Token: 0x04000BF8 RID: 3064
			[ReadOnlyUI]
			[SerializeField]
			private MassageController.Orden.MassageEstado m_lastHandJobEstado;

			// Token: 0x04000BF9 RID: 3065
			[Obsolete]
			private float m_velocidadModSegunRecorridoW;

			// Token: 0x04000BFA RID: 3066
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadModSegunSaturacionDeOxigeno;

			// Token: 0x04000BFB RID: 3067
			[ReadOnlyUI]
			[SerializeField]
			private bool m_puedeCrearMuscleJoints;

			// Token: 0x04000BFC RID: 3068
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_lastFramePosition;

			// Token: 0x04000BFD RID: 3069
			[ReadOnlyUI]
			[SerializeField]
			private bool m_ignoringCollisionWithHandMassage;

			// Token: 0x04000BFE RID: 3070
			private ModificadorDeBool m_turnOnLayer3IKOR;

			// Token: 0x04000BFF RID: 3071
			private ModificadorDeBool m_femaleIsUsingHerHand;

			// Token: 0x04000C00 RID: 3072
			[SerializeField]
			private ModificadorDeFloat m_demandaDeOxigeno;

			// Token: 0x04000C01 RID: 3073
			private ModificadorDeBool m_enableTargetHitSkins;

			// Token: 0x04000C02 RID: 3074
			private ModificadorDeBool m_cerrandoManoDeMassage;

			// Token: 0x04000C03 RID: 3075
			private ModificadorDeFloat m_cantidadDeDedosParaTomar;

			// Token: 0x04000C04 RID: 3076
			[SerializeField]
			[ReadOnlyUI]
			private bool m_usaRest;

			// Token: 0x04000C05 RID: 3077
			[SerializeField]
			[ReadOnlyUI]
			private MassageController.RestHandData m_restHandData;

			// Token: 0x04000C06 RID: 3078
			[ReadOnlyUI]
			[SerializeField]
			private Rigidbody m_handApoyoKinematic;

			// Token: 0x04000C07 RID: 3079
			[ReadOnlyUI]
			[SerializeField]
			private ConfigurableJoint m_handMuscleToHandApoyoInterJoint;

			// Token: 0x04000C08 RID: 3080
			[ReadOnlyUI]
			[SerializeField]
			private bool m_puedeCrearApoyoMuscleJoints;

			// Token: 0x04000C09 RID: 3081
			[ReadOnlyUI]
			[SerializeField]
			private bool m_ignoringCollisionWithHandApoyo;

			// Token: 0x04000C0A RID: 3082
			[ReadOnlyUI]
			[SerializeField]
			private MassageController.Orden.ApoyoEstado m_lastApoyoEstado;

			// Token: 0x02000271 RID: 625
			public enum MassageEstado
			{
				// Token: 0x04000C0C RID: 3084
				None,
				// Token: 0x04000C0D RID: 3085
				esperandoApoyo,
				// Token: 0x04000C0E RID: 3086
				esperandoEjecutarMassageStart,
				// Token: 0x04000C0F RID: 3087
				esperandoMassageStartInterMax,
				// Token: 0x04000C10 RID: 3088
				esperandoEjecutarMassageMotion,
				// Token: 0x04000C11 RID: 3089
				esperandoMassageMotionInterMax,
				// Token: 0x04000C12 RID: 3090
				esperandoCerrarMano,
				// Token: 0x04000C13 RID: 3091
				esperandoStartRecorrido,
				// Token: 0x04000C14 RID: 3092
				enMassage
			}

			// Token: 0x02000272 RID: 626
			public enum ApoyoEstado
			{
				// Token: 0x04000C16 RID: 3094
				esperandoEjecutarApoyo,
				// Token: 0x04000C17 RID: 3095
				esperandoInterMax,
				// Token: 0x04000C18 RID: 3096
				esperandoCerrarMano,
				// Token: 0x04000C19 RID: 3097
				enApoyo
			}
		}

		// Token: 0x02000274 RID: 628
		public sealed class Estado : ControllerColaDePrioridadBase<MassageController.Estado, MassageController.Orden, MassageController.Cola, MassageController, int>.StadoBase
		{
		}

		// Token: 0x02000275 RID: 629
		public sealed class Cola : ControllerColaDePrioridadBase<MassageController.Estado, MassageController.Orden, MassageController.Cola, MassageController, int>.ColasBase
		{
		}

		// Token: 0x02000276 RID: 630
		[Serializable]
		public abstract class HandData
		{
			// Token: 0x060010A7 RID: 4263 RVA: 0x0004E5F0 File Offset: 0x0004C7F0
			protected bool IgualA(MassageController.HandData other)
			{
				return other != null && (this.picker == ((other != null) ? other.picker : null) && this.muscle == ((other != null) ? other.muscle : null) && this.foreArmMuscle == ((other != null) ? other.foreArmMuscle : null) && this.armMuscle == ((other != null) ? other.armMuscle : null)) && this.hitSkin == ((other != null) ? other.hitSkin : null);
			}

			// Token: 0x060010A8 RID: 4264 RVA: 0x0004E66C File Offset: 0x0004C86C
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

			// Token: 0x04000C1E RID: 3102
			public HandPickController.Hand picker;

			// Token: 0x04000C1F RID: 3103
			public Muscle muscle;

			// Token: 0x04000C20 RID: 3104
			public Muscle foreArmMuscle;

			// Token: 0x04000C21 RID: 3105
			public Muscle armMuscle;

			// Token: 0x04000C22 RID: 3106
			public HitSkin hitSkin;
		}

		// Token: 0x02000277 RID: 631
		[Serializable]
		public class MassageData : MassageController.HandData
		{
			// Token: 0x060010AA RID: 4266 RVA: 0x0004E6F8 File Offset: 0x0004C8F8
			public bool IgualA(MassageController.MassageData other)
			{
				return base.IgualA(other) && (this.massageStartLayer2Inter == ((other != null) ? other.massageStartLayer2Inter : null) && this.massageMotionLayer3Inter == ((other != null) ? other.massageMotionLayer3Inter : null) && this.lockLayer3Inter == ((other != null) ? other.lockLayer3Inter : null) && this.pivotsMassageStartLayer2 == ((other != null) ? other.pivotsMassageStartLayer2 : null)) && this.pivotsMassageMotionLayer3 == ((other != null) ? other.pivotsMassageMotionLayer3 : null);
			}

			// Token: 0x060010AB RID: 4267 RVA: 0x0004E790 File Offset: 0x0004C990
			public override void CheckAndThorw()
			{
				base.CheckAndThorw();
				if (this.pivotsMassageStartLayer2 == null)
				{
					throw new ArgumentNullException("PivotsGrab", "PivotsGrab null reference.");
				}
				if (this.pivotsMassageMotionLayer3 == null)
				{
					throw new ArgumentNullException("PivotsJob", "PivotsJob null reference.");
				}
				if (this.massageStartLayer2Inter == null)
				{
					throw new ArgumentNullException("grabInter", "grabInter null reference.");
				}
				if (this.massageMotionLayer3Inter == null)
				{
					throw new ArgumentNullException("JobInter", "JobInter null reference.");
				}
				if (this.lockLayer3Inter == null)
				{
					throw new ArgumentNullException("lockInter", "lockInter null reference.");
				}
			}

			// Token: 0x04000C23 RID: 3107
			public Interaccion massageStartLayer2Inter;

			// Token: 0x04000C24 RID: 3108
			public Interaccion massageMotionLayer3Inter;

			// Token: 0x04000C25 RID: 3109
			public Interaccion lockLayer3Inter;

			// Token: 0x04000C26 RID: 3110
			public SurfacePivotDeInteraction pivotsMassageStartLayer2;

			// Token: 0x04000C27 RID: 3111
			public SurfacePivotDeInteraction pivotsMassageMotionLayer3;

			// Token: 0x04000C28 RID: 3112
			public Quaternion skeletonOffsetRotation;
		}

		// Token: 0x02000278 RID: 632
		[Serializable]
		public class RestHandData : MassageController.HandData
		{
			// Token: 0x060010AD RID: 4269 RVA: 0x0004E841 File Offset: 0x0004CA41
			public bool IgualA(MassageController.RestHandData other)
			{
				return base.IgualA(other) && this.restInter == ((other != null) ? other.restInter : null) && this.restPivot == ((other != null) ? other.restPivot : null);
			}

			// Token: 0x060010AE RID: 4270 RVA: 0x0004E880 File Offset: 0x0004CA80
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

			// Token: 0x04000C29 RID: 3113
			public Interaccion restInter;

			// Token: 0x04000C2A RID: 3114
			public SurfacePivotDeInteraction restPivot;

			// Token: 0x04000C2B RID: 3115
			public PuntoDeApoyoSobreMaleBody apoyo;

			// Token: 0x04000C2C RID: 3116
			public Transform guiaApoyo;

			// Token: 0x04000C2D RID: 3117
			public Quaternion skeletonOffsetRotation;
		}
	}
}
