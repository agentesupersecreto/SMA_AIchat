using System;
using System.Collections.Generic;
using System.Text;
using Assets.Base.Behaviours.Runtime.Cameras;
using Assets.Base.RootMotion.BeachGirl.Interacciones;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Controllers;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.ArmaduresSkins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI.Modales.Globales;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores
{
	// Token: 0x020000C4 RID: 196
	[RequireComponent(typeof(CamaraFotograficaDeCharacter))]
	[RequireComponent(typeof(CameraRendingTextureTakeAPhoto))]
	public sealed class MaleCameraUserController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00016EEC File Offset: 0x000150EC
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00016EF4 File Offset: 0x000150F4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CameraRendingTextureTakeAPhoto = base.GetComponent<CameraRendingTextureTakeAPhoto>();
			if (!this.m_CameraRendingTextureTakeAPhoto.isAwaken)
			{
				this.m_CameraRendingTextureTakeAPhoto.ManualAwake();
			}
			this.m_CamaraFotograficaDeCharacter = base.GetComponent<CamaraFotograficaDeCharacter>();
			if (!this.m_CamaraFotograficaDeCharacter.isAwaken)
			{
				this.m_CamaraFotograficaDeCharacter.ManualAwake();
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00016F4F File Offset: 0x0001514F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00016F77 File Offset: 0x00015177
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_femalePortraitLayerMask;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00016F9A File Offset: 0x0001519A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00016FA4 File Offset: 0x000151A4
		public override void OnUpdateEvent1()
		{
			if (!this.modelingShootEnabled)
			{
				return;
			}
			if (!this.m_coolDown.isOn && Singleton<PlayerInputProxy>.instance.fire1.clickedUp)
			{
				try
				{
					this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_femalePortraitLayerMask;
					this.TakeModelingPhootoShoot();
				}
				finally
				{
					this.m_coolDown.Apply();
				}
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00017018 File Offset: 0x00015218
		private void TakeModelingPhootoShoot()
		{
			try
			{
				TargetChar instance = TargetChar.instance;
				Character character = ((instance != null) ? instance.character : null);
				IFemaleChar femaleChar = character as IFemaleChar;
				FemaleCapturablePorCamara femaleCapturablePorCamara;
				if (femaleChar == null)
				{
					femaleCapturablePorCamara = null;
				}
				else
				{
					ICharacter self = femaleChar.self;
					femaleCapturablePorCamara = ((self != null) ? self.GetComponentEnRoot<FemaleCapturablePorCamara>() : null);
				}
				FemaleCapturablePorCamara femaleCapturablePorCamara2 = femaleCapturablePorCamara;
				if (!(femaleCapturablePorCamara2 == null))
				{
					if (this.m_lastTaken)
					{
						Object.Destroy(this.m_lastTaken);
					}
					this.m_lastTaken = null;
					if (MalePhoneUserController.IsRenderingFemale(femaleChar, this.m_CameraRendingTextureTakeAPhoto.Camara) && this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, true))
					{
						Camera camara = this.m_CameraRendingTextureTakeAPhoto.Camara;
						Transform transform = camara.transform;
						Vector3 position = transform.position;
						FemaleSkins femaleSkins = femaleChar.skins as FemaleSkins;
						if (femaleSkins != null)
						{
							CamaraFotograficaDeCharacter camaraFotograficaDeCharacter = this.m_CamaraFotograficaDeCharacter;
							if (((camaraFotograficaDeCharacter != null) ? camaraFotograficaDeCharacter.inmediateOwner : null) != null)
							{
								IInteraccionesDeCharacterFemenino componentEnRoot = femaleSkins.GetComponentEnRoot(false);
								if (componentEnRoot != null)
								{
									InteraccionDeCharacter interaccionDeCharacter = componentEnRoot.ObtenerFirstEjecutandosePrimaria();
									if (interaccionDeCharacter != null)
									{
										Interaccion instancia = interaccionDeCharacter.instancia;
										if (instancia != null)
										{
											instancia.GetComponentInChildren<PoseQueExponePartes>();
										}
									}
								}
								IRopaManager componentEnRoot2 = femaleSkins.GetComponentEnRoot(false);
								bool flag = true;
								bool flag2 = true;
								bool flag3 = true;
								bool flag4 = !componentEnRoot2.Cubriendo(RopaCubre.labios);
								bool flag5 = !componentEnRoot2.Cubriendo(RopaCubre.pezones);
								bool flag6 = !componentEnRoot2.Cubriendo(RopaCubre.ano);
								bool flag7 = !componentEnRoot2.Cubriendo(RopaCubre.labiosVaginales);
								bool flag8 = !componentEnRoot2.Cubriendo(RopaCubre.vaginaHole);
								if (!flag)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(22);
								}
								if (!flag2)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(26);
								}
								if (!flag3)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(29);
								}
								if (!flag4)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(8);
								}
								if (!flag5)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(23);
								}
								if (!flag6)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(31);
								}
								if (!flag7)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(28);
								}
								if (!flag8)
								{
									MaleCameraUserController.m_ignorarTEMP.Add(32);
								}
								bool flag9 = flag4 && MalePhoneUserController.SkinInFrame(camara, femaleSkins.hitSkins.partes.labios);
								bool flag10 = flag && (MalePhoneUserController.SkinInFrameAny<BaseDeTetaSkin>(camara, femaleSkins.hitSkins.partes.senos000) || MalePhoneUserController.SkinInFrameAny<MedioDeTetaSkin>(camara, femaleSkins.hitSkins.partes.senos001));
								bool flag11 = flag5 && MalePhoneUserController.SkinInFrameAny<PezonHitSkin>(camara, femaleSkins.hitSkins.partes.senos002);
								bool flag12 = flag2 && (MalePhoneUserController.SkinInFrameAny<NalgaSkin>(camara, femaleSkins.hitSkins.partes.nalgas) || MalePhoneUserController.SkinInFrameAny<ApertureNalgasHitSkin>(camara, femaleSkins.hitSkins.partes.nalgaAperturas));
								bool flag13 = flag6 && MalePhoneUserController.SkinInFrame(camara, femaleSkins.hitSkins.partes.anusParedes);
								bool flag14 = flag3 && MalePhoneUserController.SkinInFrameAny<SingleSphereProxyHitSkin, SingleSphereProxyHitSkin>(camara, femaleSkins.hitSkins.partes.clitoris);
								bool flag15 = flag7 && (MalePhoneUserController.SkinInFrameAny<VagLabioMultipleHitSkin>(camara, femaleSkins.hitSkins.partes.labiosVaginales) || MalePhoneUserController.SkinInFrame(camara, femaleSkins.hitSkins.partes.labioVaginaleBack));
								bool flag16 = flag8 && MalePhoneUserController.SkinInFrame(camara, femaleSkins.hitSkins.partes.vagParedes);
								HitSkinBasica hitSkinBasica = null;
								RaycastHit raycastHit = default(RaycastHit);
								HitSkinBasica hitSkinBasica2 = null;
								RaycastHit raycastHit2 = default(RaycastHit);
								HitSkinBasica hitSkinBasica3 = null;
								RaycastHit raycastHit3 = default(RaycastHit);
								HitSkinBasica hitSkinBasica4 = null;
								RaycastHit raycastHit4 = default(RaycastHit);
								HitSkinBasica hitSkinBasica5 = null;
								RaycastHit raycastHit5 = default(RaycastHit);
								HitSkinBasica hitSkinBasica6 = null;
								RaycastHit raycastHit6 = default(RaycastHit);
								HitSkinBasica hitSkinBasica7 = null;
								RaycastHit raycastHit7 = default(RaycastHit);
								HitSkinBasica hitSkinBasica8 = null;
								RaycastHit raycastHit8 = default(RaycastHit);
								Side side = Side.none;
								Side side2 = Side.none;
								Side side3 = Side.none;
								Side side4 = Side.none;
								Side side5 = Side.none;
								Side side6 = Side.none;
								Side side7 = Side.none;
								Side side8 = Side.none;
								flag9 = flag9 && MalePhoneUserController.SkinInVistaAny(position, femaleSkins.hitSkins.partes.labios, out hitSkinBasica, out raycastHit, out side);
								flag10 = flag10 && (MalePhoneUserController.SkinInVistaAny<BaseDeTetaSkin>(position, femaleSkins.hitSkins.partes.senos000, out hitSkinBasica2, out raycastHit2, out side2) || MalePhoneUserController.SkinInVistaAny<MedioDeTetaSkin>(position, femaleSkins.hitSkins.partes.senos001, out hitSkinBasica2, out raycastHit2, out side2));
								flag11 = flag11 && MalePhoneUserController.SkinInVistaAny<PezonHitSkin>(position, femaleSkins.hitSkins.partes.senos002, out hitSkinBasica3, out raycastHit3, out side3);
								bool flag17 = flag12 && (MalePhoneUserController.SkinInVistaAny<NalgaSkin>(position, femaleSkins.hitSkins.partes.nalgas, out hitSkinBasica4, out raycastHit4, out side4) || MalePhoneUserController.SkinInVistaAny<ApertureNalgasHitSkin>(position, femaleSkins.hitSkins.partes.nalgaAperturas, out hitSkinBasica4, out raycastHit4, out side4));
								flag13 = flag13 && MalePhoneUserController.SkinInVistaAny(position, femaleSkins.hitSkins.partes.anusParedes, out hitSkinBasica5, out raycastHit5, out side5);
								flag14 = flag14 && MalePhoneUserController.SkinInVistaAny<SingleSphereProxyHitSkin, SingleSphereProxyHitSkin>(position, femaleSkins.hitSkins.partes.clitoris, out hitSkinBasica6, out raycastHit6, out side6);
								flag15 = flag15 && (MalePhoneUserController.SkinInVistaAny<VagLabioMultipleHitSkin>(position, femaleSkins.hitSkins.partes.labiosVaginales, out hitSkinBasica7, out raycastHit7, out side7) || MalePhoneUserController.SkinInVistaAny(position, femaleSkins.hitSkins.partes.labioVaginaleBack, out hitSkinBasica7, out raycastHit7, out side7));
								flag16 = flag16 && MalePhoneUserController.SkinInVistaAny(position, femaleSkins.hitSkins.partes.vagParedes, out hitSkinBasica8, out raycastHit8, out side8);
								Vector3 forward = transform.forward;
								flag9 = flag9 && Vector3.Angle(forward, raycastHit.point - position) <= this.maxAngleToCapture;
								flag10 = flag10 && Vector3.Angle(forward, raycastHit2.point - position) <= this.maxAngleToCapture;
								flag11 = flag11 && Vector3.Angle(forward, raycastHit3.point - position) <= this.maxAngleToCapture;
								bool flag18 = flag17 && Vector3.Angle(forward, raycastHit4.point - position) <= this.maxAngleToCapture;
								flag13 = flag13 && Vector3.Angle(forward, raycastHit5.point - position) <= this.maxAngleToCapture;
								flag14 = flag14 && Vector3.Angle(forward, raycastHit6.point - position) <= this.maxAngleToCapture;
								flag15 = flag15 && Vector3.Angle(forward, raycastHit7.point - position) <= this.maxAngleToCapture;
								flag16 = flag16 && Vector3.Angle(forward, raycastHit8.point - position) <= this.maxAngleToCapture;
								HashSet<int> hashSet = new HashSet<int>();
								if (flag13)
								{
									hashSet.Add(31);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.ano, side5, hitSkinBasica5, raycastHit5, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag16)
								{
									hashSet.Add(32);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.vag, side8, hitSkinBasica8, raycastHit8, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag15)
								{
									hashSet.Add(28);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.labiosVaginales, side7, hitSkinBasica7, raycastHit7, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag14)
								{
									hashSet.Add(29);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.clitoris, side6, hitSkinBasica6, raycastHit6, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag11)
								{
									hashSet.Add(23);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.pezones, side3, hitSkinBasica3, raycastHit3, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag18)
								{
									hashSet.Add(26);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.nalgas, side4, hitSkinBasica4, raycastHit4, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag10)
								{
									hashSet.Add(22);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.senos, side2, hitSkinBasica2, raycastHit2, this.m_CamaraFotograficaDeCharacter);
								}
								if (flag9)
								{
									hashSet.Add(8);
									femaleCapturablePorCamara2.CamaraCapturoParte(ParteDelCuerpoHumano.labios, side, hitSkinBasica, raycastHit, this.m_CamaraFotograficaDeCharacter);
								}
								HitSkinBasica hitSkinBasica9;
								RaycastHit raycastHit9;
								ParteDelCuerpoHumano parteDelCuerpoHumano;
								Side side9;
								if (BodyPartEnumHelpler.ViendoParteDelCuerpo(position, transform.forward, 10f, out hitSkinBasica9, out raycastHit9, out parteDelCuerpoHumano, out side9, character.escala, 0.01f) && !MaleCameraUserController.m_ignorarTEMP.Contains((int)parteDelCuerpoHumano) && hashSet.Add((int)parteDelCuerpoHumano))
								{
									femaleCapturablePorCamara2.CamaraCapturoParte(parteDelCuerpoHumano, side9, hitSkinBasica9, raycastHit9, this.m_CamaraFotograficaDeCharacter);
								}
							}
						}
					}
				}
			}
			finally
			{
				MaleCameraUserController.m_ignorarTEMP.Clear();
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00017840 File Offset: 0x00015A40
		[Obsolete("", true)]
		private void TakeRopaPortrait()
		{
			if (!Singleton<ModalWindow>.IsInScene || Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			TargetChar instance = TargetChar.instance;
			IFemaleChar femaleChar = ((instance != null) ? instance.character : null) as IFemaleChar;
			if (femaleChar == null)
			{
				return;
			}
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
			ConjuntoDeRopaLoader componentInChildren = femaleChar.self.GetComponentInChildren<ConjuntoDeRopaLoader>();
			if (MalePhoneUserController.IsRenderingFemale(femaleChar, this.m_CameraRendingTextureTakeAPhoto.Camara) && this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false) && componentInChildren != null)
			{
				ConjuntoDeRopa conjuntoDeRopaActual = componentInChildren.GenerarConjuntoDePiezasConEstadoActual<ConjuntoDeRopa>();
				conjuntoDeRopaActual.serialVersionPiezas = (conjuntoDeRopaActual.serialVersionMateriales = 2);
				SavingPortraitDialog panel = Singleton<ModalWindow>.instance.MostrarSavingPortraitDialogWide();
				panel.nameDeCosaGuardando = "outfit";
				panel.inputField.text = "Outfit " + DateTime.Now.ToString("yyyy M dd HH mm ss");
				panel.portrait.texture = this.m_lastTaken;
				panel.aceptar.onClick.AddListener(delegate
				{
					conjuntoDeRopaActual.name = panel.inputField.text;
					string text = JsonUtility.ToJson(conjuntoDeRopaActual);
					byte[] bytes = Encoding.UTF8.GetBytes(text);
					SaveLoadOutfit.Guardar(panel.inputField.text, this.m_lastTaken, bytes);
					Singleton<ModalWindow>.instance.Clear(panel);
					TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
					temporalInfoDialog.duration = 0.5f;
					temporalInfoDialog.info.text = "Saved...";
				});
				panel.cancelar.onClick.AddListener(delegate
				{
					Singleton<ModalWindow>.instance.Clear(panel);
				});
			}
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x000179B8 File Offset: 0x00015BB8
		[Obsolete("", true)]
		private void ChangeMode(MaleCameraUserController.Mode targetMode)
		{
			if (!this.modelingShootEnabled && !this.ropaPortraitEnabled)
			{
				return;
			}
			if (!this.modelingShootEnabled)
			{
				targetMode = MaleCameraUserController.Mode.ropaPortrait;
			}
			if (!this.ropaPortraitEnabled)
			{
				targetMode = MaleCameraUserController.Mode.modelingShoot;
			}
			if (targetMode == MaleCameraUserController.Mode.modelingShoot)
			{
				this.mode = MaleCameraUserController.Mode.modelingShoot;
				this.OnModeChanged();
				return;
			}
			if (targetMode != MaleCameraUserController.Mode.ropaPortrait)
			{
				throw new ArgumentOutOfRangeException(targetMode.ToString());
			}
			this.mode = MaleCameraUserController.Mode.ropaPortrait;
			this.OnModeChanged();
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00017A24 File Offset: 0x00015C24
		[Obsolete("", true)]
		private void OnModeChanged()
		{
			this.DisableRopaOnTop();
			MaleCameraUserController.Mode mode = this.mode;
			if (mode == MaleCameraUserController.Mode.modelingShoot)
			{
				for (int i = 0; i < this.m_RopaRenderingCustomPassObjects.Length; i++)
				{
					this.m_RopaRenderingCustomPassObjects[i].SetActive(false);
				}
				this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_femalePortraitLayerMask;
				return;
			}
			if (mode != MaleCameraUserController.Mode.ropaPortrait)
			{
				throw new ArgumentOutOfRangeException(this.mode.ToString());
			}
			TargetChar instance = TargetChar.instance;
			IFemaleChar femaleChar = ((instance != null) ? instance.character : null) as IFemaleChar;
			ICharacter self = femaleChar.self;
			Animator animator = ((self != null) ? self.bodyAnimator : null);
			ICharacter self2 = femaleChar.self;
			ArmatureSkinsClasificada armatureSkinsClasificada = ((self2 != null) ? self2.GetComponentEnRoot<ArmatureSkinsClasificada>() : null);
			if (femaleChar != null && animator != null && ((armatureSkinsClasificada != null) ? armatureSkinsClasificada.skinPartes : null) != null)
			{
				foreach (PiezaDeRopaBase piezaDeRopaBase in animator.GetComponentsInChildren<PiezaDeRopaBase>())
				{
					if (piezaDeRopaBase.isActiveAndEnabled)
					{
						Transform transform = animator.transform.CreateChild("CloneParaPortrait_" + piezaDeRopaBase.name, false);
						this.m_clonesDeRopa.Add(transform.gameObject);
						SkinnedMeshRenderer copyOf = transform.gameObject.AddComponent<SkinnedMeshRenderer>().GetCopyOf(piezaDeRopaBase.skinnedMeshRenderer);
						switch (piezaDeRopaBase.dataDeRopa.layer)
						{
						case RopaLayer.debajoDeRopaInterior:
						case RopaLayer.ropaInterior:
						case RopaLayer.debajoDeAccesorios:
						case RopaLayer.accesorios:
							copyOf.gameObject.layer = ConfiguracionGlobal.layersStatic.penesComplemento;
							break;
						case RopaLayer.debajoDeRopa:
						case RopaLayer.ropa:
						case RopaLayer.debajoDeAbrigo:
						case RopaLayer.abrigo:
							copyOf.gameObject.layer = ConfiguracionGlobal.layersStatic.transparentFX;
							break;
						default:
							throw new ArgumentOutOfRangeException(piezaDeRopaBase.dataDeRopa.layer.ToString());
						}
						copyOf.materials = piezaDeRopaBase.skinnedMeshRenderer.sharedMaterials;
						copyOf.shadowCastingMode = ShadowCastingMode.Off;
					}
				}
			}
			for (int k = 0; k < this.m_RopaRenderingCustomPassObjects.Length; k++)
			{
				this.m_RopaRenderingCustomPassObjects[k].SetActive(true);
			}
			this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_ropaPortraitLayerMask;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00017C5C File Offset: 0x00015E5C
		[Obsolete("", true)]
		private void DisableRopaOnTop()
		{
			foreach (GameObject gameObject in this.m_clonesDeRopa)
			{
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
			this.m_clonesDeRopa.Clear();
		}

		// Token: 0x0400021B RID: 539
		[Obsolete("", true)]
		public bool ropaPortraitEnabled = true;

		// Token: 0x0400021C RID: 540
		[Obsolete("", true)]
		[SerializeField]
		private LayerMask m_ropaPortraitLayerMask;

		// Token: 0x0400021D RID: 541
		[Obsolete("", true)]
		public MaleCameraUserController.Mode mode;

		// Token: 0x0400021E RID: 542
		[Obsolete("", true)]
		[SerializeField]
		private List<GameObject> m_clonesDeRopa = new List<GameObject>();

		// Token: 0x0400021F RID: 543
		[Obsolete("", true)]
		[SerializeField]
		private GameObject[] m_RopaRenderingCustomPassObjects;

		// Token: 0x04000220 RID: 544
		public bool modelingShootEnabled = true;

		// Token: 0x04000221 RID: 545
		private CameraRendingTextureTakeAPhoto m_CameraRendingTextureTakeAPhoto;

		// Token: 0x04000222 RID: 546
		private CamaraFotograficaDeCharacter m_CamaraFotograficaDeCharacter;

		// Token: 0x04000223 RID: 547
		[SerializeField]
		private LayerMask m_femalePortraitLayerMask;

		// Token: 0x04000224 RID: 548
		[SerializeField]
		private Texture2D m_lastTaken;

		// Token: 0x04000225 RID: 549
		private CoolDown m_coolDown = new CoolDown(0.666f);

		// Token: 0x04000226 RID: 550
		public float maxAngleToCapture = 20f;

		// Token: 0x04000227 RID: 551
		private static HashSet<int> m_ignorarTEMP = new HashSet<int>();

		// Token: 0x0200012A RID: 298
		[Obsolete("", true)]
		public enum Mode
		{
			// Token: 0x040003D2 RID: 978
			modelingShoot,
			// Token: 0x040003D3 RID: 979
			ropaPortrait
		}
	}
}
