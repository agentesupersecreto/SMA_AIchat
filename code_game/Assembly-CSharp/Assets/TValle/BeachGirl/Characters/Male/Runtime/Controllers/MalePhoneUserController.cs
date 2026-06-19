using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime.Globales;
using Assets.Base.Behaviours.Runtime.Cameras;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.CustomPoses;
using Assets.Productos.Juegos.Reception;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Modelaje.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.ArmaduresSkins;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Modales.Globales;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.TValle.BeachGirl.Characters.Male.Runtime.Controllers
{
	// Token: 0x02000048 RID: 72
	[RequireComponent(typeof(CameraRendingTextureTakeAPhoto))]
	public sealed class MalePhoneUserController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600015B RID: 347 RVA: 0x0000BEEF File Offset: 0x0000A0EF
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600015C RID: 348 RVA: 0x0000BEF8 File Offset: 0x0000A0F8
		// (remove) Token: 0x0600015D RID: 349 RVA: 0x0000BF30 File Offset: 0x0000A130
		public event Action<Texture2D, MalePhoneUserController> onPortraitAcepted;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600015E RID: 350 RVA: 0x0000BF68 File Offset: 0x0000A168
		// (remove) Token: 0x0600015F RID: 351 RVA: 0x0000BFA0 File Offset: 0x0000A1A0
		public event Action<MalePhoneUserController> onPortraitCanceled;

		// Token: 0x06000160 RID: 352 RVA: 0x0000BFD5 File Offset: 0x0000A1D5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CameraRendingTextureTakeAPhoto = base.GetComponent<CameraRendingTextureTakeAPhoto>();
			if (!this.m_CameraRendingTextureTakeAPhoto.isAwaken)
			{
				this.m_CameraRendingTextureTakeAPhoto.ManualAwake();
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000C001 File Offset: 0x0000A201
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000C029 File Offset: 0x0000A229
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.ChangeMode(this.m_mode, true);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000C03E File Offset: 0x0000A23E
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.DisableGizmos();
			this.DisableRopaOnTop();
			this.DisableMakeoverOnTop();
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000C05C File Offset: 0x0000A25C
		public override void OnUpdateEvent1()
		{
			if (!this.femalePortraitEnabled && !this.posePortraitEnabled && !this.ropaPortraitEnabled && !this.gestosPortraitEnabled)
			{
				return;
			}
			if (Singleton<PlayerInputProxy>.instance.toolActions.fire3)
			{
				switch (this.m_mode)
				{
				case MalePhoneUserController.Mode.femalePortrait:
					this.ChangeMode(MalePhoneUserController.Mode.posePortrait, false);
					break;
				case MalePhoneUserController.Mode.posePortrait:
					this.ChangeMode(MalePhoneUserController.Mode.ropaPortrait, false);
					break;
				case MalePhoneUserController.Mode.ropaPortrait:
					this.ChangeMode(MalePhoneUserController.Mode.gestosPortrait, false);
					break;
				case MalePhoneUserController.Mode.gestosPortrait:
					this.ChangeMode(MalePhoneUserController.Mode.makeoverPortrait, false);
					break;
				case MalePhoneUserController.Mode.makeoverPortrait:
					this.ChangeMode(MalePhoneUserController.Mode.femalePortrait, false);
					break;
				default:
					throw new ArgumentOutOfRangeException(this.m_mode.ToString());
				}
			}
			if (!this.m_coolDown.isOn && Singleton<PlayerInputProxy>.instance.fire1.clickedUp)
			{
				try
				{
					switch (this.m_mode)
					{
					case MalePhoneUserController.Mode.femalePortrait:
						this.TakeFemalePortrait();
						break;
					case MalePhoneUserController.Mode.posePortrait:
						this.TakePosePortrait();
						break;
					case MalePhoneUserController.Mode.ropaPortrait:
						this.TakeRopaPortrait();
						break;
					case MalePhoneUserController.Mode.gestosPortrait:
						this.TakeGestosPortrait();
						break;
					case MalePhoneUserController.Mode.makeoverPortrait:
						this.TakeMakeoverPortrait();
						break;
					default:
						throw new ArgumentOutOfRangeException(this.m_mode.ToString());
					}
				}
				finally
				{
					this.m_coolDown.Apply();
				}
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000C1A4 File Offset: 0x0000A3A4
		private MalePhoneUserController.Mode GetMode(MalePhoneUserController.Mode targetMode)
		{
			switch (targetMode)
			{
			case MalePhoneUserController.Mode.femalePortrait:
				if (!this.femalePortraitEnabled)
				{
					targetMode = MalePhoneUserController.Mode.posePortrait;
				}
				break;
			case MalePhoneUserController.Mode.posePortrait:
				if (!this.posePortraitEnabled)
				{
					targetMode = MalePhoneUserController.Mode.ropaPortrait;
				}
				break;
			case MalePhoneUserController.Mode.ropaPortrait:
				if (!this.ropaPortraitEnabled)
				{
					targetMode = MalePhoneUserController.Mode.gestosPortrait;
				}
				break;
			case MalePhoneUserController.Mode.gestosPortrait:
				if (!this.gestosPortraitEnabled)
				{
					targetMode = MalePhoneUserController.Mode.makeoverPortrait;
				}
				break;
			case MalePhoneUserController.Mode.makeoverPortrait:
				if (!this.makeoverPortraitEnabled)
				{
					targetMode = MalePhoneUserController.Mode.femalePortrait;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(targetMode.ToString());
			}
			return targetMode;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000C224 File Offset: 0x0000A424
		public void ChangeMode(MalePhoneUserController.Mode targetMode, bool mute)
		{
			if (!this.femalePortraitEnabled && !this.posePortraitEnabled && !this.ropaPortraitEnabled && !this.gestosPortraitEnabled)
			{
				return;
			}
			int num = typeof(MalePhoneUserController.Mode).GetEnumCount() - 1 - 1;
			for (int i = 0; i < num; i++)
			{
				targetMode = this.GetMode(targetMode);
			}
			switch (targetMode)
			{
			case MalePhoneUserController.Mode.femalePortrait:
				this.m_mode = MalePhoneUserController.Mode.femalePortrait;
				this.OnModeChanged(mute);
				return;
			case MalePhoneUserController.Mode.posePortrait:
			{
				TargetChar instance = TargetChar.instance;
				Character character = ((instance != null) ? instance.character : null);
				if (!(character != null))
				{
					return;
				}
				IInteraccionesDeCharacter componentEnRoot = character.GetComponentEnRoot<IInteraccionesDeCharacter>();
				InteraccionDeCharacter interaccionDeCharacter = ((componentEnRoot != null) ? componentEnRoot.ObtenerFirstEjecutandosePrimaria() : null);
				if (interaccionDeCharacter == null || (interaccionDeCharacter.id != InteraccionPrimariaName.customA.GetInteractionID() && interaccionDeCharacter.id != InteraccionPrimariaName.customB.GetInteractionID()))
				{
					Singleton<MainCanvas>.instance.MostrartMsg("Custom Poses", "Please ensure that the custom pose is activated before attempting to save it.", 3f, false, null, null, null);
					this.ChangeMode(MalePhoneUserController.Mode.ropaPortrait, mute);
					return;
				}
				this.m_mode = MalePhoneUserController.Mode.posePortrait;
				this.OnModeChanged(mute);
				return;
			}
			case MalePhoneUserController.Mode.ropaPortrait:
				this.m_mode = MalePhoneUserController.Mode.ropaPortrait;
				this.OnModeChanged(mute);
				return;
			case MalePhoneUserController.Mode.gestosPortrait:
				this.m_mode = MalePhoneUserController.Mode.gestosPortrait;
				this.OnModeChanged(mute);
				return;
			case MalePhoneUserController.Mode.makeoverPortrait:
				this.m_mode = MalePhoneUserController.Mode.makeoverPortrait;
				this.OnModeChanged(mute);
				return;
			default:
				throw new ArgumentOutOfRangeException(targetMode.ToString());
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000C384 File Offset: 0x0000A584
		public bool TryTakeGenericPortrait(string msg, bool forceToTake)
		{
			if (!Singleton<ModalWindow>.IsInScene || Singleton<ModalWindow>.instance.isShowing)
			{
				return false;
			}
			TargetChar instance = TargetChar.instance;
			IFemaleChar femaleChar = ((instance != null) ? instance.character : null) as IFemaleChar;
			if (femaleChar == null)
			{
				return false;
			}
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
			if ((forceToTake || MalePhoneUserController.IsRenderingFemale(femaleChar, this.m_CameraRendingTextureTakeAPhoto.Camara)) && this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false))
			{
				SavingPortraitDialog panel = Singleton<ModalWindow>.instance.MostrarSavingJobPortraitDialog();
				panel.preguntaString = msg;
				panel.portrait.texture = this.m_lastTaken;
				panel.aceptar.onClick.AddListener(delegate
				{
					Action<Texture2D, MalePhoneUserController> action = this.onPortraitAcepted;
					if (action != null)
					{
						action(this.m_lastTaken, this);
					}
					Singleton<ModalWindow>.instance.Clear(panel);
				});
				panel.cancelar.onClick.AddListener(delegate
				{
					Action<MalePhoneUserController> action2 = this.onPortraitCanceled;
					if (action2 != null)
					{
						action2(this);
					}
					Singleton<ModalWindow>.instance.Clear(panel);
				});
				return true;
			}
			return false;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000C498 File Offset: 0x0000A698
		private void TakeFemalePortrait()
		{
			MalePhoneUserController.<>c__DisplayClass34_0 CS$<>8__locals1 = new MalePhoneUserController.<>c__DisplayClass34_0();
			CS$<>8__locals1.<>4__this = this;
			if (!Singleton<ModalWindow>.IsInScene || Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			TargetChar instance = TargetChar.instance;
			Character character = ((instance != null) ? instance.character : null);
			CS$<>8__locals1.currentFemale = character as IFemaleChar;
			MalePhoneUserController.<>c__DisplayClass34_0 CS$<>8__locals2 = CS$<>8__locals1;
			IFemaleChar currentFemale = CS$<>8__locals1.currentFemale;
			CS$<>8__locals2.asICharacterUnico = ((currentFemale != null) ? currentFemale.self : null) as ICharacterIdentificable;
			if (CS$<>8__locals1.currentFemale == null || CS$<>8__locals1.asICharacterUnico == null)
			{
				return;
			}
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
			if (MalePhoneUserController.IsRenderingFemale(CS$<>8__locals1.currentFemale, this.m_CameraRendingTextureTakeAPhoto.Camara) && this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false))
			{
				CS$<>8__locals1.panel = Singleton<ModalWindow>.instance.MostrarSavingPortraitDialog();
				CS$<>8__locals1.panel.nameDeCosaGuardando = "character";
				CS$<>8__locals1.panel.inputField.text = CS$<>8__locals1.asICharacterUnico.nombreCompleto;
				CS$<>8__locals1.panel.portrait.texture = this.m_lastTaken;
				CS$<>8__locals1.panel.aceptar.onClick.AddListener(delegate
				{
					Action<Texture2D, MalePhoneUserController> action = CS$<>8__locals1.<>4__this.onPortraitAcepted;
					if (action != null)
					{
						action(CS$<>8__locals1.<>4__this.m_lastTaken, CS$<>8__locals1.<>4__this);
					}
					MemoriaJsonGenerica<SavingFemaleCharacterJsonMemoryNode> memoriaJsonGenerica = new MemoriaJsonGenerica<SavingFemaleCharacterJsonMemoryNode>();
					SavingFemaleCharacterJsonMemoryNode savingFemaleCharacterJsonMemoryNode = (SavingFemaleCharacterJsonMemoryNode)memoriaJsonGenerica.root;
					ISujetoIdentificableNpc newNPCAssetFromCharacter = LoaderDeNpcFemeninos.GetNewNPCAssetFromCharacter(CS$<>8__locals1.asICharacterUnico, false);
					try
					{
						if (newNPCAssetFromCharacter == null)
						{
							throw new NotSupportedException("Por ahora solo se puede guardar sujetos de la piscina actual");
						}
						MemoriaDeSujetosNpcFemenina.EscribirNpcAMemoriaCompleto(memoriaJsonGenerica, newNPCAssetFromCharacter, null);
					}
					finally
					{
						newNPCAssetFromCharacter.Destruir();
					}
					IRopaManager componentInChildren = CS$<>8__locals1.currentFemale.self.GetComponentInChildren<IRopaManager>();
					if (componentInChildren != null)
					{
						savingFemaleCharacterJsonMemoryNode.ropa = componentInChildren.GenerarConjuntoDePiezasConEstadoActual<ConjuntoDeRopa>();
						savingFemaleCharacterJsonMemoryNode.ropa.name = "Outfit";
						savingFemaleCharacterJsonMemoryNode.ropa.serialVersionPiezas = (savingFemaleCharacterJsonMemoryNode.ropa.serialVersionMateriales = 2);
					}
					string text = memoriaJsonGenerica.root.Save();
					byte[] bytes = Encoding.UTF8.GetBytes(text);
					SaveLoadCharacters.Guardar(CS$<>8__locals1.panel.inputField.text, CS$<>8__locals1.<>4__this.m_lastTaken, bytes);
					Singleton<ModalWindow>.instance.Clear(CS$<>8__locals1.panel);
					TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
					temporalInfoDialog.duration = 0.5f;
					temporalInfoDialog.info.text = "Saved...";
				});
				CS$<>8__locals1.panel.cancelar.onClick.AddListener(delegate
				{
					Action<MalePhoneUserController> action2 = CS$<>8__locals1.<>4__this.onPortraitCanceled;
					if (action2 != null)
					{
						action2(CS$<>8__locals1.<>4__this);
					}
					Singleton<ModalWindow>.instance.Clear(CS$<>8__locals1.panel);
				});
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000C5F8 File Offset: 0x0000A7F8
		private void TakePosePortrait()
		{
			MalePhoneUserController.<>c__DisplayClass35_0 CS$<>8__locals1 = new MalePhoneUserController.<>c__DisplayClass35_0();
			CS$<>8__locals1.<>4__this = this;
			if (!Singleton<ModalWindow>.IsInScene || Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			MalePhoneUserController.<>c__DisplayClass35_0 CS$<>8__locals2 = CS$<>8__locals1;
			TargetChar instance = TargetChar.instance;
			CS$<>8__locals2.currentChar = ((instance != null) ? instance.character : null);
			IFemaleChar femaleChar = CS$<>8__locals1.currentChar as IFemaleChar;
			if (femaleChar == null)
			{
				return;
			}
			IInteraccionesDeCharacter componentEnRoot = CS$<>8__locals1.currentChar.GetComponentEnRoot<IInteraccionesDeCharacter>();
			CustomPosesDeFemaleCharacter componentEnRoot2 = CS$<>8__locals1.currentChar.GetComponentEnRoot<CustomPosesDeFemaleCharacter>();
			InteraccionDeCharacter interaccionDeCharacter = componentEnRoot.ObtenerFirstEjecutandosePrimaria();
			bool flag;
			componentEnRoot2.ObtenerCurrent(out CS$<>8__locals1.prepararCustomPoseOnEditMode, out CS$<>8__locals1.skeletonGizmos, out flag);
			CS$<>8__locals1.gizmosDeBonesInfo = CS$<>8__locals1.skeletonGizmos.GetComponentsInChildren<GizmoDeBoneRMInfo>();
			if (CS$<>8__locals1.gizmosDeBonesInfo.Length == 0)
			{
				return;
			}
			if (interaccionDeCharacter == null || CS$<>8__locals1.skeletonGizmos == null)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Custom Poses", "Please ensure that the custom pose is activated before attempting to save it.", 3f, false, null, null, null);
				return;
			}
			if (this.m_lastTaken)
			{
				Object.Destroy(this.m_lastTaken);
			}
			this.m_lastTaken = null;
			if (MalePhoneUserController.IsRenderingFemale(femaleChar, this.m_CameraRendingTextureTakeAPhoto.Camara) && this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false))
			{
				CS$<>8__locals1.currentGotoTarget = Singleton<GoToScenaManager>.instance.CurrentGoTo(CS$<>8__locals1.currentChar.animatorRootMotionTransform, out CS$<>8__locals1.currentGoToIsTurnedAround, 0.4f, 45f);
				CS$<>8__locals1.panel = Singleton<ModalWindow>.instance.MostrarSavingPortraitDialog();
				CS$<>8__locals1.panel.nameDeCosaGuardando = "pose";
				if (CS$<>8__locals1.currentGotoTarget == null || CS$<>8__locals1.currentGotoTarget.esDefault)
				{
					CS$<>8__locals1.panel.inputField.text = "My Custom Pose " + DateTime.Now.ToString("yyyy M dd HH mm ss");
				}
				else
				{
					CS$<>8__locals1.panel.inputField.text = "My " + CS$<>8__locals1.currentGotoTarget.nombrable.ObtenerNombreDeCurrentLocalization(NombrableResult.firstUpper) + " Pose " + DateTime.Now.ToString("yyyy M dd HH mm ss");
				}
				CS$<>8__locals1.panel.portrait.texture = this.m_lastTaken;
				CS$<>8__locals1.panel.aceptar.onClick.AddListener(delegate
				{
					Action<Texture2D, MalePhoneUserController> action = CS$<>8__locals1.<>4__this.onPortraitAcepted;
					if (action != null)
					{
						action(CS$<>8__locals1.<>4__this.m_lastTaken, CS$<>8__locals1.<>4__this);
					}
					string text = SaveLoadCustomPoses.GenerarSaveData(CS$<>8__locals1.currentChar, CS$<>8__locals1.skeletonGizmos, CS$<>8__locals1.prepararCustomPoseOnEditMode, CS$<>8__locals1.currentGotoTarget, CS$<>8__locals1.currentGoToIsTurnedAround, CS$<>8__locals1.gizmosDeBonesInfo).root.Save();
					byte[] bytes = Encoding.UTF8.GetBytes(text);
					SaveLoadPoses.Guardar(CS$<>8__locals1.panel.inputField.text, CS$<>8__locals1.<>4__this.m_lastTaken, bytes);
					Singleton<ModalWindow>.instance.Clear(CS$<>8__locals1.panel);
					TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
					temporalInfoDialog.duration = 0.5f;
					temporalInfoDialog.info.text = "Saved...";
				});
				CS$<>8__locals1.panel.cancelar.onClick.AddListener(delegate
				{
					Action<MalePhoneUserController> action2 = CS$<>8__locals1.<>4__this.onPortraitCanceled;
					if (action2 != null)
					{
						action2(CS$<>8__locals1.<>4__this);
					}
					Singleton<ModalWindow>.instance.Clear(CS$<>8__locals1.panel);
				});
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000C850 File Offset: 0x0000AA50
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
				SavingPortraitDialog panel = Singleton<ModalWindow>.instance.MostrarSavingPortraitDialog();
				panel.nameDeCosaGuardando = "outfit";
				panel.inputField.text = "Outfit " + DateTime.Now.ToString("yyyy M dd HH mm ss");
				panel.portrait.texture = this.m_lastTaken;
				panel.aceptar.onClick.AddListener(delegate
				{
					Action<Texture2D, MalePhoneUserController> action = this.onPortraitAcepted;
					if (action != null)
					{
						action(this.m_lastTaken, this);
					}
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
					Action<MalePhoneUserController> action2 = this.onPortraitCanceled;
					if (action2 != null)
					{
						action2(this);
					}
					Singleton<ModalWindow>.instance.Clear(panel);
				});
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000C9C8 File Offset: 0x0000ABC8
		private void TakeGestosPortrait()
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
			if (!MalePhoneUserController.IsRenderingFemale(femaleChar, this.m_CameraRendingTextureTakeAPhoto.Camara))
			{
				return;
			}
			FemaleSkins femaleSkins = femaleChar.skins as FemaleSkins;
			if (femaleSkins == null)
			{
				return;
			}
			Camera camara = this.m_CameraRendingTextureTakeAPhoto.Camara;
			if (!MalePhoneUserController.SkinInFrame(camara, femaleSkins.hitSkins.partes.cabeza))
			{
				return;
			}
			HitSkinBasica hitSkinBasica;
			RaycastHit raycastHit;
			if (!MalePhoneUserController.SkinInVistaAny(camara.transform.position, femaleSkins.hitSkins.partes.cabeza, out hitSkinBasica, out raycastHit))
			{
				return;
			}
			if (!this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false))
			{
				return;
			}
			ControladorDeCCAnimationBlendShapes componentInChildren = femaleChar.self.GetComponentInChildren<ControladorDeCCAnimationBlendShapes>();
			ControladorDeJawV2 componentInChildren2 = femaleChar.self.GetComponentInChildren<ControladorDeJawV2>();
			GestosFacialesToDisk toSave = new GestosFacialesToDisk();
			GestosFacialesShapesToEdit.LoadFromControllers(toSave.gestos, componentInChildren, componentInChildren2);
			toSave.serialVersionMateriales = 2;
			SavingPortraitDialog panel = Singleton<ModalWindow>.instance.MostrarSavingPortraitDialog();
			panel.nameDeCosaGuardando = "gesture";
			panel.inputField.text = "Gesture " + DateTime.Now.ToString("yyyy M dd HH mm ss");
			panel.portrait.texture = this.m_lastTaken;
			panel.aceptar.onClick.AddListener(delegate
			{
				Action<Texture2D, MalePhoneUserController> action = this.onPortraitAcepted;
				if (action != null)
				{
					action(this.m_lastTaken, this);
				}
				toSave.name = panel.inputField.text;
				string text = JsonUtility.ToJson(toSave);
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				SaveLoadGestos.Guardar(panel.inputField.text, this.m_lastTaken, bytes);
				Singleton<ModalWindow>.instance.Clear(panel);
				TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
				temporalInfoDialog.duration = 0.5f;
				temporalInfoDialog.info.text = "Saved...";
			});
			panel.cancelar.onClick.AddListener(delegate
			{
				Action<MalePhoneUserController> action2 = this.onPortraitCanceled;
				if (action2 != null)
				{
					action2(this);
				}
				Singleton<ModalWindow>.instance.Clear(panel);
			});
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000CBA8 File Offset: 0x0000ADA8
		private void TakeMakeoverPortrait()
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
			if (!MalePhoneUserController.IsRenderingFemale(femaleChar, this.m_CameraRendingTextureTakeAPhoto.Camara))
			{
				return;
			}
			FemaleSkins femaleSkins = femaleChar.skins as FemaleSkins;
			if (femaleSkins == null)
			{
				return;
			}
			Camera camara = this.m_CameraRendingTextureTakeAPhoto.Camara;
			if (!MalePhoneUserController.SkinInFrame(camara, femaleSkins.hitSkins.partes.cabeza))
			{
				return;
			}
			HitSkinBasica hitSkinBasica;
			RaycastHit raycastHit;
			if (!MalePhoneUserController.SkinInVistaAny(camara.transform.position, femaleSkins.hitSkins.partes.cabeza, out hitSkinBasica, out raycastHit))
			{
				return;
			}
			if (!this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref this.m_lastTaken, false))
			{
				return;
			}
			MakeoverToDisk toSave = new MakeoverToDisk();
			AlteradoresDeAparienciaFemenina componentInChildren = femaleChar.self.GetComponentInChildren<AlteradoresDeAparienciaFemenina>();
			PanelDeEditarMakeover.SetValoresAModel(toSave.makeover, componentInChildren);
			toSave.serialVersionMateriales = 2;
			SavingPortraitDialog panel = Singleton<ModalWindow>.instance.MostrarSavingPortraitDialog();
			panel.nameDeCosaGuardando = "makeover";
			panel.inputField.text = "Makeover " + DateTime.Now.ToString("yyyy M dd HH mm ss");
			panel.portrait.texture = this.m_lastTaken;
			panel.aceptar.onClick.AddListener(delegate
			{
				Action<Texture2D, MalePhoneUserController> action = this.onPortraitAcepted;
				if (action != null)
				{
					action(this.m_lastTaken, this);
				}
				toSave.name = panel.inputField.text;
				string text = JsonUtility.ToJson(toSave);
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				SaveLoadMakeover.Guardar(panel.inputField.text, this.m_lastTaken, bytes);
				Singleton<ModalWindow>.instance.Clear(panel);
				TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
				temporalInfoDialog.duration = 0.5f;
				temporalInfoDialog.info.text = "Saved...";
			});
			panel.cancelar.onClick.AddListener(delegate
			{
				Action<MalePhoneUserController> action2 = this.onPortraitCanceled;
				if (action2 != null)
				{
					action2(this);
				}
				Singleton<ModalWindow>.instance.Clear(panel);
			});
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000CD78 File Offset: 0x0000AF78
		private void DisableGizmos()
		{
			if (!Singleton<SkeletonEditorMode>.instance.activado)
			{
				for (int i = 0; i < Singleton<CharacteresActivos>.instance.characteres.Count; i++)
				{
					ICharacterUnico characterUnico = Singleton<CharacteresActivos>.instance.characteres[i];
					IReadOnlyList<GizmosDeSkeleton> readOnlyList;
					if (characterUnico == null)
					{
						readOnlyList = null;
					}
					else
					{
						CustomPosesDeFemaleCharacter componentEnRoot = characterUnico.GetComponentEnRoot<CustomPosesDeFemaleCharacter>();
						readOnlyList = ((componentEnRoot != null) ? componentEnRoot.gizmosDeSkeletons : null);
					}
					IReadOnlyList<GizmosDeSkeleton> readOnlyList2 = readOnlyList;
					if (readOnlyList2 != null)
					{
						for (int j = 0; j < readOnlyList2.Count; j++)
						{
							GizmosDeSkeleton gizmosDeSkeleton = readOnlyList2[j];
							if (gizmosDeSkeleton != null)
							{
								gizmosDeSkeleton.modo = GizmosDeSkeleton.ModoV2.inactivo;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000CE00 File Offset: 0x0000B000
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

		// Token: 0x0600016F RID: 367 RVA: 0x0000CE68 File Offset: 0x0000B068
		private void DisableMakeoverOnTop()
		{
			foreach (GameObject gameObject in this.m_clonesDePielMakeoer)
			{
				foreach (Material material in gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterials)
				{
					if (material != null)
					{
						Object.Destroy(material);
					}
				}
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
			this.m_clonesDePielMakeoer.Clear();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000CF00 File Offset: 0x0000B100
		public void PrepareForFemalePortrait()
		{
			for (int i = 0; i < this.m_RopaRenderingCustomPassObjects.Length; i++)
			{
				this.m_RopaRenderingCustomPassObjects[i].SetActive(false);
			}
			for (int j = 0; j < this.m_PoseRenderingCustomPassObjects.Length; j++)
			{
				this.m_PoseRenderingCustomPassObjects[j].SetActive(false);
			}
			this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_femalePortraitLayerMask;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000CF6C File Offset: 0x0000B16C
		private void OnModeChanged(bool mute)
		{
			if (!mute && this.m_ChangeModeSound != null)
			{
				this.m_ChangeModeSound.Play();
			}
			this.DisableGizmos();
			this.DisableRopaOnTop();
			this.DisableMakeoverOnTop();
			string text;
			switch (this.m_mode)
			{
			case MalePhoneUserController.Mode.femalePortrait:
				this.PrepareForFemalePortrait();
				text = "Save Model mode has been activated.";
				break;
			case MalePhoneUserController.Mode.posePortrait:
			{
				if (!Singleton<SkeletonEditorMode>.instance.activado)
				{
					TargetChar instance = TargetChar.instance;
					Character character = ((instance != null) ? instance.character : null);
					if (character != null)
					{
						bool flag;
						GizmosDeSkeleton gizmosDeSkeleton = character.GetComponentEnRoot<CustomPosesDeFemaleCharacter>().ObtenerCurrentGizmosDeSkeleton(out flag);
						if (gizmosDeSkeleton != null)
						{
							gizmosDeSkeleton.modo = GizmosDeSkeleton.ModoV2.gizmosShowing;
						}
					}
				}
				for (int i = 0; i < this.m_RopaRenderingCustomPassObjects.Length; i++)
				{
					this.m_RopaRenderingCustomPassObjects[i].SetActive(false);
				}
				for (int j = 0; j < this.m_PoseRenderingCustomPassObjects.Length; j++)
				{
					this.m_PoseRenderingCustomPassObjects[j].SetActive(true);
				}
				this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_posePortraitLayerMask;
				text = "Save Pose mode has been activated.";
				break;
			}
			case MalePhoneUserController.Mode.ropaPortrait:
			{
				TargetChar instance2 = TargetChar.instance;
				IFemaleChar femaleChar = ((instance2 != null) ? instance2.character : null) as IFemaleChar;
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
							copyOf.sharedMaterials.ForEach(delegate(Material m)
							{
								Object.Destroy(m);
							});
							copyOf.sharedMaterials = piezaDeRopaBase.skinnedMeshRenderer.sharedMaterials;
							copyOf.shadowCastingMode = ShadowCastingMode.Off;
						}
					}
				}
				for (int l = 0; l < this.m_PoseRenderingCustomPassObjects.Length; l++)
				{
					this.m_PoseRenderingCustomPassObjects[l].SetActive(false);
				}
				for (int m2 = 0; m2 < this.m_RopaRenderingCustomPassObjects.Length; m2++)
				{
					this.m_RopaRenderingCustomPassObjects[m2].SetActive(true);
				}
				this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_ropaPortraitLayerMask;
				text = "Save Outfit mode has been activated.";
				break;
			}
			case MalePhoneUserController.Mode.gestosPortrait:
			{
				for (int n = 0; n < this.m_PoseRenderingCustomPassObjects.Length; n++)
				{
					this.m_PoseRenderingCustomPassObjects[n].SetActive(false);
				}
				for (int num = 0; num < this.m_RopaRenderingCustomPassObjects.Length; num++)
				{
					this.m_RopaRenderingCustomPassObjects[num].SetActive(false);
				}
				this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_femalePortraitLayerMask;
				text = "Save Facial Gestures mode has been activated.";
				break;
			}
			case MalePhoneUserController.Mode.makeoverPortrait:
			{
				TargetChar instance3 = TargetChar.instance;
				IFemaleChar femaleChar2 = ((instance3 != null) ? instance3.character : null) as IFemaleChar;
				ICharacter self3 = femaleChar2.self;
				MalePhoneUserController.<>c__DisplayClass43_0 CS$<>8__locals1;
				CS$<>8__locals1.anim = ((self3 != null) ? self3.bodyAnimator : null);
				ICharacter self4 = femaleChar2.self;
				ArmatureSkinsClasificada armatureSkinsClasificada2 = ((self4 != null) ? self4.GetComponentEnRoot<ArmatureSkinsClasificada>() : null);
				if (femaleChar2 != null && CS$<>8__locals1.anim != null && ((armatureSkinsClasificada2 != null) ? armatureSkinsClasificada2.skinPartes : null) != null)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = this.<OnModeChanged>g__ClonePiel|43_2(armatureSkinsClasificada2.skinPartes.body, ref CS$<>8__locals1);
					SkinnedMeshRenderer skinnedMeshRenderer2 = this.<OnModeChanged>g__ClonePiel|43_2(armatureSkinsClasificada2.skinPartes.cejas, ref CS$<>8__locals1);
					SkinnedMeshRenderer skinnedMeshRenderer3 = this.<OnModeChanged>g__ClonePiel|43_2(armatureSkinsClasificada2.skinPartes.ojos, ref CS$<>8__locals1);
					GenericShapeKeyCopier.Add(skinnedMeshRenderer, armatureSkinsClasificada2.skinPartes.body.skinnedMeshRenderer);
					GenericShapeKeyCopier.Add(skinnedMeshRenderer2, armatureSkinsClasificada2.skinPartes.body.skinnedMeshRenderer);
					MalePhoneUserController.<OnModeChanged>g__CloneMats|43_3(skinnedMeshRenderer, armatureSkinsClasificada2.skinPartes.body.skinnedMeshRenderer);
					MalePhoneUserController.<OnModeChanged>g__CloneMats|43_3(skinnedMeshRenderer2, armatureSkinsClasificada2.skinPartes.cejas.skinnedMeshRenderer);
					MalePhoneUserController.<OnModeChanged>g__CloneMats|43_3(skinnedMeshRenderer3, armatureSkinsClasificada2.skinPartes.ojos.skinnedMeshRenderer);
					Material material = null;
					Material material2 = null;
					Material material3 = null;
					Material material4 = null;
					Material material5 = null;
					Material material6 = null;
					ControlladorDeFemalePiel.LoadMaterial(MapaSingleton<MapaSingletonDeMainSkins>.singleton.body, MapaSingleton<MapaSingletonDeFemaleMateriales>.instance.cabeza, CS$<>8__locals1.anim, this, ref material, "CloneParaPortrait_", null);
					ControlladorDeFemalePiel.LoadMaterial(MapaSingleton<MapaSingletonDeMainSkins>.singleton.body, MapaSingleton<MapaSingletonDeFemaleMateriales>.instance.cuerpo, CS$<>8__locals1.anim, this, ref material2, "CloneParaPortrait_", null);
					ControlladorDeFemalePiel.LoadMaterial(MapaSingleton<MapaSingletonDeMainSkins>.singleton.body, MapaSingleton<MapaSingletonDeFemaleMateriales>.instance.pezones, CS$<>8__locals1.anim, this, ref material3, "CloneParaPortrait_", null);
					ControlladorDeFemalePiel.LoadMaterial(MapaSingleton<MapaSingletonDeMainSkins>.singleton.body, MapaSingleton<MapaSingletonDeFemaleMateriales>.instance.labios, CS$<>8__locals1.anim, this, ref material4, "CloneParaPortrait_", null);
					ControlladorDeFemalePiel.LoadMaterial(MapaSingleton<MapaSingletonDeMainSkins>.singleton.body, MapaSingleton<MapaSingletonDeFemaleMateriales>.instance.ano, CS$<>8__locals1.anim, this, ref material5, "CloneParaPortrait_", null);
					ControlladorDeFemalePiel.LoadMaterial(MapaSingleton<MapaSingletonDeMainSkins>.singleton.body, MapaSingleton<MapaSingletonDeFemaleMateriales>.instance.vag, CS$<>8__locals1.anim, this, ref material6, "CloneParaPortrait_", null);
					MapaDeMaterialFields mapaDeMaterialFields = Singleton<MaterialesFieldsNombres>.instance.Obtener();
					MalePhoneUserController.<>c__DisplayClass43_1 CS$<>8__locals2;
					CS$<>8__locals2.m_fileds1 = new MaterialFieldsDeLayerIDs();
					CS$<>8__locals2.m_fileds1.Load(mapaDeMaterialFields.layer1);
					CS$<>8__locals2.m_fileds2 = new MaterialFieldsDeLayerIDs();
					CS$<>8__locals2.m_fileds2.Load(mapaDeMaterialFields.layer2);
					MalePhoneUserController.<OnModeChanged>g__ClearMainTextures|43_1(material, true, false, ref CS$<>8__locals2);
					MalePhoneUserController.<OnModeChanged>g__ClearMainTextures|43_1(material2, true, true, ref CS$<>8__locals2);
					MalePhoneUserController.<OnModeChanged>g__ClearMainTextures|43_1(material3, true, true, ref CS$<>8__locals2);
					MalePhoneUserController.<OnModeChanged>g__ClearMainTextures|43_1(material4, false, false, ref CS$<>8__locals2);
					MalePhoneUserController.<OnModeChanged>g__ClearMainTextures|43_1(material5, true, true, ref CS$<>8__locals2);
					MalePhoneUserController.<OnModeChanged>g__ClearMainTextures|43_1(material6, true, true, ref CS$<>8__locals2);
				}
				for (int num2 = 0; num2 < this.m_PoseRenderingCustomPassObjects.Length; num2++)
				{
					this.m_PoseRenderingCustomPassObjects[num2].SetActive(false);
				}
				for (int num3 = 0; num3 < this.m_RopaRenderingCustomPassObjects.Length; num3++)
				{
					this.m_RopaRenderingCustomPassObjects[num3].SetActive(false);
				}
				this.m_CameraRendingTextureTakeAPhoto.Camara.cullingMask = this.m_makeoverPortraitLayerMask;
				text = "Save Makeover mode has been activated.";
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(this.m_mode.ToString());
			}
			if (!mute)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Phone Camera", text, 1f, false, null, null, null);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000D69C File Offset: 0x0000B89C
		public static bool IsRenderingFemale(IFemaleChar character, Camera phoneCam)
		{
			if (character == null)
			{
				return false;
			}
			Bounds? bounds = null;
			for (int i = 0; i < character.skins.mainSkinsRenderers.Count; i++)
			{
				Bounds bounds2 = character.skins.mainSkinsRenderers[i].bounds;
				if (bounds != null)
				{
					bounds.Value.Encapsulate(bounds2);
				}
				else
				{
					bounds = new Bounds?(bounds2);
				}
			}
			if (bounds == null)
			{
				return false;
			}
			GeometryUtility.CalculateFrustumPlanes(phoneCam, MalePhoneUserController.m_TempPlanes);
			return GeometryUtility.TestPlanesAABB(MalePhoneUserController.m_TempPlanes, bounds.Value);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000D734 File Offset: 0x0000B934
		public static bool SkinInVistaAny(Vector3 camPos, HitSkinBasica skin, out HitSkinBasica skinHitted, out RaycastHit hit)
		{
			for (int i = 0; i < skin.skinColliders.Count; i++)
			{
				if (BodyPartEnumHelpler.ViendoCollider(camPos, skin.skinColliders[i], out hit))
				{
					skinHitted = skin;
					return true;
				}
			}
			skinHitted = null;
			hit = default(RaycastHit);
			return false;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000D77C File Offset: 0x0000B97C
		public static bool SkinInVistaAny(Vector3 camPos, HitSkinBasica skin, out HitSkinBasica skinHitted, out RaycastHit hit, out Side side)
		{
			side = Side.none;
			return MalePhoneUserController.SkinInVistaAny(camPos, skin, out skinHitted, out hit);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000D78B File Offset: 0x0000B98B
		public static bool SkinInVistaAny<T>(Vector3 camPos, FemaleSkins.HitSkins.ParBase<T> par, out HitSkinBasica skinHitted, out RaycastHit hit, out Side side) where T : HitSkinBasica
		{
			if (MalePhoneUserController.SkinInVistaAny(camPos, par.r, out skinHitted, out hit))
			{
				side = Side.R;
				return true;
			}
			if (MalePhoneUserController.SkinInVistaAny(camPos, par.l, out skinHitted, out hit))
			{
				side = Side.L;
				return true;
			}
			side = Side.none;
			return false;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000D7C8 File Offset: 0x0000B9C8
		public static bool SkinInVistaAny<Ta, Tb>(Vector3 camPos, FemaleSkins.HitSkins.Duo<Ta, Tb> par, out HitSkinBasica skinHitted, out RaycastHit hit, out Side side) where Ta : HitSkinBasica where Tb : HitSkinBasica
		{
			side = Side.none;
			return MalePhoneUserController.SkinInVistaAny(camPos, par.a, out skinHitted, out hit) || MalePhoneUserController.SkinInVistaAny(camPos, par.b, out skinHitted, out hit);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000D7F8 File Offset: 0x0000B9F8
		private static bool ColliderInFrame(Camera cam, Collider col)
		{
			GeometryUtility.CalculateFrustumPlanes(cam, MalePhoneUserController.m_TempPlanes);
			return GeometryUtility.TestPlanesAABB(MalePhoneUserController.m_TempPlanes, col.bounds);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000D818 File Offset: 0x0000BA18
		private static bool ColliderInFrame(Camera cam, IReadOnlyList<Collider> cols)
		{
			if (cols.Count == 0)
			{
				return false;
			}
			Bounds bounds = cols[0].bounds;
			for (int i = 1; i < cols.Count; i++)
			{
				bounds.Encapsulate(cols[1].bounds);
			}
			GeometryUtility.CalculateFrustumPlanes(cam, MalePhoneUserController.m_TempPlanes);
			return GeometryUtility.TestPlanesAABB(MalePhoneUserController.m_TempPlanes, bounds);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000D876 File Offset: 0x0000BA76
		public static bool SkinInFrame(Camera cam, HitSkinBasica skin)
		{
			return MalePhoneUserController.ColliderInFrame(cam, skin.skinColliders);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000D884 File Offset: 0x0000BA84
		public static bool SkinInFrameAny<T>(Camera cam, FemaleSkins.HitSkins.ParBase<T> par) where T : HitSkinBasica
		{
			return MalePhoneUserController.ColliderInFrame(cam, par.r.skinColliders) || MalePhoneUserController.ColliderInFrame(cam, par.l.skinColliders);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000D8B6 File Offset: 0x0000BAB6
		public static bool SkinInFrameAny<Ta, Tb>(Camera cam, FemaleSkins.HitSkins.Duo<Ta, Tb> par) where Ta : HitSkinBasica where Tb : HitSkinBasica
		{
			return MalePhoneUserController.ColliderInFrame(cam, par.a.skinColliders) || MalePhoneUserController.ColliderInFrame(cam, par.b.skinColliders);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000D954 File Offset: 0x0000BB54
		[CompilerGenerated]
		internal static void <OnModeChanged>g__ClearMainTextures|43_1(Material mat, bool clearLayer2SecText = true, bool clearLayer2MainText = true, ref MalePhoneUserController.<>c__DisplayClass43_1 A_3)
		{
			mat.SetTexture(A_3.m_fileds1.texture, null);
			mat.SetTexture(A_3.m_fileds1.maskMapTexture, null);
			mat.SetTexture(A_3.m_fileds1.normalTexture, null);
			mat.SetTexture(A_3.m_fileds1.detailTexture, null);
			mat.SetColor(A_3.m_fileds1.textureColor, Color.white);
			if (clearLayer2SecText)
			{
				mat.SetTexture(A_3.m_fileds2.maskMapTexture, null);
				mat.SetTexture(A_3.m_fileds2.normalTexture, null);
				mat.SetTexture(A_3.m_fileds2.detailTexture, null);
			}
			if (clearLayer2MainText)
			{
				mat.SetTexture(A_3.m_fileds2.texture, null);
				mat.SetColor(A_3.m_fileds2.textureColor, Color.white);
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000DA24 File Offset: 0x0000BC24
		[CompilerGenerated]
		private SkinnedMeshRenderer <OnModeChanged>g__ClonePiel|43_2(Skin skin, ref MalePhoneUserController.<>c__DisplayClass43_0 A_2)
		{
			Transform transform = A_2.anim.transform.CreateChild("CloneParaPortrait_" + skin.name, false);
			this.m_clonesDePielMakeoer.Add(transform.gameObject);
			SkinnedMeshRenderer copyOf = transform.gameObject.AddComponent<SkinnedMeshRenderer>().GetCopyOf(skin.skinnedMeshRenderer);
			copyOf.shadowCastingMode = ShadowCastingMode.Off;
			copyOf.gameObject.layer = ConfiguracionGlobal.layersStatic.transparentFX;
			return copyOf;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000DA98 File Offset: 0x0000BC98
		[CompilerGenerated]
		internal static void <OnModeChanged>g__CloneMats|43_3(SkinnedMeshRenderer clone, SkinnedMeshRenderer original)
		{
			clone.sharedMaterials.ForEach(delegate(Material m)
			{
				Object.Destroy(m);
			});
			Material[] sharedMaterials = original.sharedMaterials;
			Material[] array = new Material[sharedMaterials.Length];
			for (int i = 0; i < array.Length; i++)
			{
				Material material = sharedMaterials[i];
				array[i] = Object.Instantiate<Material>(sharedMaterials[i]);
				array[i].name = "CloneParaPortrait_" + material.name;
			}
			clone.sharedMaterials = array;
		}

		// Token: 0x040000C8 RID: 200
		public bool femalePortraitEnabled = true;

		// Token: 0x040000C9 RID: 201
		public bool posePortraitEnabled = true;

		// Token: 0x040000CA RID: 202
		public bool ropaPortraitEnabled = true;

		// Token: 0x040000CB RID: 203
		public bool gestosPortraitEnabled = true;

		// Token: 0x040000CC RID: 204
		public bool makeoverPortraitEnabled = true;

		// Token: 0x040000CD RID: 205
		private CameraRendingTextureTakeAPhoto m_CameraRendingTextureTakeAPhoto;

		// Token: 0x040000CE RID: 206
		[SerializeField]
		private GameObject[] m_PoseRenderingCustomPassObjects;

		// Token: 0x040000CF RID: 207
		[SerializeField]
		private GameObject[] m_RopaRenderingCustomPassObjects;

		// Token: 0x040000D0 RID: 208
		[SerializeField]
		private LayerMask m_femalePortraitLayerMask;

		// Token: 0x040000D1 RID: 209
		[SerializeField]
		private LayerMask m_posePortraitLayerMask;

		// Token: 0x040000D2 RID: 210
		[SerializeField]
		private LayerMask m_ropaPortraitLayerMask;

		// Token: 0x040000D3 RID: 211
		[SerializeField]
		private LayerMask m_makeoverPortraitLayerMask;

		// Token: 0x040000D4 RID: 212
		[SerializeField]
		private Texture2D m_lastTaken;

		// Token: 0x040000D5 RID: 213
		private CoolDown m_coolDown = new CoolDown(1f);

		// Token: 0x040000D6 RID: 214
		[SerializeField]
		private MalePhoneUserController.Mode m_mode;

		// Token: 0x040000D7 RID: 215
		[SerializeField]
		private List<GameObject> m_clonesDeRopa = new List<GameObject>();

		// Token: 0x040000D8 RID: 216
		[SerializeField]
		private List<GameObject> m_clonesDePielMakeoer = new List<GameObject>();

		// Token: 0x040000D9 RID: 217
		[SerializeField]
		private AudioSource m_ChangeModeSound;

		// Token: 0x040000DC RID: 220
		private static Plane[] m_TempPlanes = new Plane[6];

		// Token: 0x020000E5 RID: 229
		public enum Mode
		{
			// Token: 0x04000313 RID: 787
			femalePortrait,
			// Token: 0x04000314 RID: 788
			posePortrait,
			// Token: 0x04000315 RID: 789
			ropaPortrait,
			// Token: 0x04000316 RID: 790
			gestosPortrait,
			// Token: 0x04000317 RID: 791
			makeoverPortrait
		}
	}
}
