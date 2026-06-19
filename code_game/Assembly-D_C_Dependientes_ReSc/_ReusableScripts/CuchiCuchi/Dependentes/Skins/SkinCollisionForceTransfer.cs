using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Characters.Holes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.CuchiCuchi.Holes.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins
{
	// Token: 0x02000041 RID: 65
	[RequireComponent(typeof(FemaleSkins))]
	public class SkinCollisionForceTransfer : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000132 RID: 306 RVA: 0x00007CD4 File Offset: 0x00005ED4
		// (remove) Token: 0x06000133 RID: 307 RVA: 0x00007D0C File Offset: 0x00005F0C
		public event SkinCollisionForceTransfer.OnFuerzasPorPenetracionHandler onFuerzasPorPenetracion;

		// Token: 0x06000134 RID: 308 RVA: 0x00007D41 File Offset: 0x00005F41
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.LoadDefaultsModsLayer();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00007D50 File Offset: 0x00005F50
		private void LoadDefaultsModsLayer()
		{
			this.m_modsDeLayer.Add(0, this.m_defaultLayerMod);
			ConfiguracionGlobal.Layers layers = MapaSingleton<ConfiguracionGlobal>.instance.layers;
			this.m_modsDeLayer.Add(layers.penes, 1f);
			this.m_modsDeLayer.Add(layers.touchingHand, 2f);
			this.m_modsDeLayer.Add(layers.ragdoll, 1f);
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00007DD0 File Offset: 0x00005FD0
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.fixedUpdate2);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00007DDC File Offset: 0x00005FDC
		protected sealed override void AwakeUnityEvent()
		{
			if (this.m_modsDeLayer == null)
			{
				this.LoadDefaultsModsLayer();
			}
			base.AwakeUnityEvent();
			this.m_ToBehaviourForceSender = new BufferDeFuerzas.FuerzaAplicadaHandler(this.OnFuerzaAplicadaHandler);
			this.m_FemaleSkins = base.GetComponent<FemaleSkins>();
			this.m_PuppetMasterUpdater = this.m_FemaleSkins.GetComponentInChildren<PuppetMasterUpdater>();
			if (this.m_PuppetMasterUpdater == null)
			{
				throw new ArgumentNullException("m_PuppetMasterUpdater", "m_PuppetMasterUpdater null reference.");
			}
			if (!this.m_PuppetMasterUpdater.isAwaken)
			{
				this.m_PuppetMasterUpdater.ManualAwake();
			}
			if (this.m_PuppetMasterUpdater.puppet == null)
			{
				throw new ArgumentNullException("m_PuppetMasterUpdater.puppet", "m_PuppetMasterUpdater.puppet null reference.");
			}
			PuppetMaster puppet = this.m_PuppetMasterUpdater.puppet;
			puppet.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppet.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.PuppetInitiated));
			if (!this.m_FemaleSkins.hitSkins.useSkins)
			{
				Debug.LogWarning("No se estan usando hit skins, no se van a transferir las collisiones.", base.gameObject);
				return;
			}
			this.m_FemaleSkins.stared += this.M_FemaleSkins_stared;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00007EEC File Offset: 0x000060EC
		private void M_FemaleSkins_stared(object obj)
		{
			this.m_BocaHoleController = this.GetComponentEnRoot(false);
			this.m_AnusHoleController = this.GetComponentEnRoot(false);
			this.m_VagHoleController = this.GetComponentEnRoot(false);
			if (this.m_BocaHoleController == null)
			{
				throw new ArgumentNullException("m_BocaHoleController", "m_BocaHoleController null reference.");
			}
			if (this.m_AnusHoleController == null)
			{
				throw new ArgumentNullException("m_AnusHoleController", "m_AnusHoleController null reference.");
			}
			if (this.m_VagHoleController == null)
			{
				throw new ArgumentNullException("m_VagHoleController", "m_VagHoleController null reference.");
			}
			this.m_vagWallsCollisionable = this.m_FemaleSkins.hitSkins.partes.vagParedes;
			if (this.m_vagWallsCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de vag walls", this);
			}
			this.m_anusWallsCollisionable = this.m_FemaleSkins.hitSkins.partes.anusParedes;
			if (this.m_anusWallsCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de anus walls", this);
			}
			this.m_bocaWallsCollisionable = this.m_FemaleSkins.hitSkins.partes.bocaParedes;
			if (this.m_bocaWallsCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de boca walls", this);
			}
			this.m_vagFondoCollisionable = this.m_FemaleSkins.hitSkins.partes.vagFondo;
			if (this.m_vagFondoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de vag fondo", this);
			}
			this.m_anusFondoCollisionable = this.m_FemaleSkins.hitSkins.partes.anusFondo;
			if (this.m_anusFondoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de anus fondo", this);
			}
			this.m_bocaFondoCollisionable = this.m_FemaleSkins.hitSkins.partes.bocaFondo;
			if (this.m_bocaFondoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de boca fondo", this);
			}
			this.m_vagAnchoCollisionable = this.m_FemaleSkins.hitSkins.partes.vagAncho;
			if (this.m_vagAnchoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de vag Ancho", this);
			}
			this.m_anusAnchoCollisionable = this.m_FemaleSkins.hitSkins.partes.anusAncho;
			if (this.m_anusAnchoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de anus Ancho", this);
			}
			this.m_bocaAnchoCollisionable = this.m_FemaleSkins.hitSkins.partes.bocaAncho;
			if (this.m_bocaAnchoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de boca Ancho", this);
			}
			this.m_vagEntradaCollisionable = this.m_FemaleSkins.hitSkins.partes.vagEntrada;
			if (this.m_vagEntradaCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de vag entrada", this);
			}
			this.m_anusEntradaCollisionable = this.m_FemaleSkins.hitSkins.partes.anusEntrada;
			if (this.m_anusEntradaCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de anus entrada", this);
			}
			this.m_bocaEntradaCollisionable = this.m_FemaleSkins.hitSkins.partes.bocaEntrada;
			if (this.m_bocaEntradaCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de boca entrada", this);
			}
			this.m_torzoCollisionable = this.m_FemaleSkins.hitSkins.partes.torzo;
			if (this.m_torzoCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de torzo", this);
			}
			this.m_headCollisionable = this.m_FemaleSkins.hitSkins.partes.cabeza;
			if (this.m_headCollisionable == null)
			{
				Debug.LogError("No se pudo obtener collisionable de head", this);
			}
			this.m_piena_L = this.m_FemaleSkins.hitSkins.partes.piernas.l;
			this.m_piena_R = this.m_FemaleSkins.hitSkins.partes.piernas.r;
			if (this.m_piena_L == null || this.m_piena_R == null)
			{
				Debug.LogError("No se pudo obtener collisionable de pienas", this);
			}
			this.m_brazo_L = this.m_FemaleSkins.hitSkins.partes.brazos.l;
			this.m_brazo_R = this.m_FemaleSkins.hitSkins.partes.brazos.r;
			if (this.m_brazo_L == null || this.m_brazo_R == null)
			{
				Debug.LogError("No se pudo obtener collisionable de brazos", this);
			}
			this.m_canilla_L = this.m_FemaleSkins.hitSkins.partes.canillas.l;
			this.m_canilla_R = this.m_FemaleSkins.hitSkins.partes.canillas.r;
			if (this.m_canilla_L == null || this.m_canilla_R == null)
			{
				Debug.LogError("No se pudo obtener collisionable de canillas", this);
			}
			this.m_antebrazo_L = this.m_FemaleSkins.hitSkins.partes.anteBrazos.l;
			this.m_antebrazo_R = this.m_FemaleSkins.hitSkins.partes.anteBrazos.r;
			if (this.m_antebrazo_L == null || this.m_antebrazo_R == null)
			{
				Debug.LogError("No se pudo obtener collisionable de antebrazos", this);
			}
			this.m_pie_L = this.m_FemaleSkins.hitSkins.partes.pies.l;
			this.m_pie_R = this.m_FemaleSkins.hitSkins.partes.pies.r;
			if (this.m_pie_L == null || this.m_pie_R == null)
			{
				Debug.LogError("No se pudo obtener collisionable de pies", this);
			}
			this.m_mano_L = this.m_FemaleSkins.hitSkins.partes.manos.l;
			this.m_mano_R = this.m_FemaleSkins.hitSkins.partes.manos.r;
			if (this.m_mano_L == null || this.m_mano_R == null)
			{
				Debug.LogError("No se pudo obtener collisionable de manos", this);
			}
			this.nalga_R = this.m_FemaleSkins.hitSkins.partes.nalgas.r;
			this.nalga_L = this.m_FemaleSkins.hitSkins.partes.nalgas.l;
			this.Seno_000_R = this.m_FemaleSkins.hitSkins.partes.senos000.r;
			this.Seno_000_L = this.m_FemaleSkins.hitSkins.partes.senos000.l;
			this.Seno_001_R = this.m_FemaleSkins.hitSkins.partes.senos001.r;
			this.Seno_001_L = this.m_FemaleSkins.hitSkins.partes.senos001.l;
			this.Seno_002_R = this.m_FemaleSkins.hitSkins.partes.senos002.r;
			this.Seno_002_L = this.m_FemaleSkins.hitSkins.partes.senos002.l;
			if (this.nalga_R == null)
			{
				throw new ArgumentNullException("nalga_R", "nalga_R null reference.");
			}
			if (this.nalga_L == null)
			{
				throw new ArgumentNullException("nalga_L", "nalga_L null reference.");
			}
			if (this.Seno_002_R == null)
			{
				throw new ArgumentNullException("Seno_002_R", "Seno_002_R null reference.");
			}
			if (this.Seno_002_L == null)
			{
				throw new ArgumentNullException("Seno_002_L", "Seno_002_L null reference.");
			}
			if (this.Seno_001_R == null)
			{
				throw new ArgumentNullException("Seno_001_R", "Seno_001_R null reference.");
			}
			if (this.Seno_001_L == null)
			{
				throw new ArgumentNullException("Seno_001_L", "Seno_001_L null reference.");
			}
			if (this.Seno_000_R == null)
			{
				throw new ArgumentNullException("Seno_000_R", "Seno_000_R null reference.");
			}
			if (this.Seno_000_L == null)
			{
				throw new ArgumentNullException("Seno_000_L", "Seno_000_L null reference.");
			}
			this.m_selfToConvexColliders = this.GetComponentEnRoot(false);
			if (this.m_selfToConvexColliders == null)
			{
				throw new ArgumentNullException("m_toConvexColliders", "m_toConvexColliders null reference.");
			}
			if (base.isActiveAndEnabled)
			{
				this.Subscribe();
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000861C File Offset: 0x0000681C
		private void PuppetInitiated()
		{
			PuppetMaster puppet = this.m_PuppetMasterUpdater.puppet;
			puppet.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppet.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.PuppetInitiated));
			Muscle[] muscles = this.m_PuppetMasterUpdater.puppet.muscles;
			int i = 0;
			while (i < muscles.Length)
			{
				Muscle muscle = muscles[i];
				switch (muscle.grupo)
				{
				case Muscle.GroupCompleto.Hips:
					this.m_HipMuscle = muscle;
					break;
				case Muscle.GroupCompleto.Spine:
					this.m_SpineMuscle = muscle;
					break;
				case Muscle.GroupCompleto.Head:
					this.m_headMuscle = muscle;
					break;
				case Muscle.GroupCompleto.Arm:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_armLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_armRMuscle = muscle;
					}
					break;
				case Muscle.GroupCompleto.Hand:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_handLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_handRMuscle = muscle;
					}
					break;
				case Muscle.GroupCompleto.Leg:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_thingsLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_thingsRMuscle = muscle;
					}
					break;
				case Muscle.GroupCompleto.Foot:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_feetLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_feetRMuscle = muscle;
					}
					break;
				case Muscle.GroupCompleto.Tail:
				case Muscle.GroupCompleto.Prop:
					break;
				case (Muscle.GroupCompleto)9:
				case (Muscle.GroupCompleto)10:
				case (Muscle.GroupCompleto)11:
				case (Muscle.GroupCompleto)12:
				case (Muscle.GroupCompleto)13:
				case (Muscle.GroupCompleto)14:
				case (Muscle.GroupCompleto)15:
				case (Muscle.GroupCompleto)16:
				case (Muscle.GroupCompleto)17:
				case (Muscle.GroupCompleto)18:
					goto IL_02B8;
				case Muscle.GroupCompleto.Neck:
					this.m_neckMuscle = muscle;
					break;
				case Muscle.GroupCompleto.Chest:
					this.m_ChestMuscle = muscle;
					break;
				case Muscle.GroupCompleto.ForeArm:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_forearmLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_forearmRMuscle = muscle;
					}
					break;
				case Muscle.GroupCompleto.Calf:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_calfLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_calfRMuscle = muscle;
					}
					break;
				case Muscle.GroupCompleto.Shoulder:
					if (muscle.name.EndsWith(".L"))
					{
						this.m_shoulderLMuscle = muscle;
					}
					else
					{
						if (!muscle.name.EndsWith(".R"))
						{
							throw new NotSupportedException();
						}
						this.m_shoulderRMuscle = muscle;
					}
					break;
				default:
					goto IL_02B8;
				}
				i++;
				continue;
				IL_02B8:
				throw new ArgumentOutOfRangeException(muscle.grupo.ToString());
			}
			this.m_headBuffer.Init(this.m_headMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.1f
			}, this.m_headMuscle);
			this.m_neckBuffer.Init(this.m_neckMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.1f
			}, this.m_neckMuscle);
			this.m_spine2Buffer.Init(this.m_ChestMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.075f
			}, this.m_ChestMuscle);
			this.m_spine1Buffer.Init(this.m_SpineMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.075f
			}, this.m_SpineMuscle);
			this.m_HipsBuffer.Init(this.m_HipMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.125f
			}, this.m_HipMuscle);
			this.m_shouldersLBuffer.Init(this.m_shoulderLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_shoulderLMuscle);
			this.m_shouldersRBuffer.Init(this.m_shoulderRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_shoulderRMuscle);
			this.m_thingsLBuffer.Init(this.m_thingsLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.125f
			}, this.m_thingsLMuscle);
			this.m_thingsRBuffer.Init(this.m_thingsRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.125f
			}, this.m_thingsRMuscle);
			this.m_armsLBuffer.Init(this.m_armLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_armLMuscle);
			this.m_armsRBuffer.Init(this.m_armRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_armRMuscle);
			this.m_calfLBuffer.Init(this.m_calfLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_calfLMuscle);
			this.m_calfRBuffer.Init(this.m_calfRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_calfRMuscle);
			this.m_forearmsLBuffer.Init(this.m_forearmLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_forearmLMuscle);
			this.m_forearmsRBuffer.Init(this.m_forearmRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_forearmRMuscle);
			this.m_feetLBuffer.Init(this.m_feetLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_feetLMuscle);
			this.m_feetRBuffer.Init(this.m_feetRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_feetRMuscle);
			this.m_handsLBuffer.Init(this.m_handLMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_handLMuscle);
			this.m_handsRBuffer.Init(this.m_handRMuscle.rigidbody, new BufferDeFuerzasConfig
			{
				time = 0.05f
			}, this.m_handRMuscle);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00008C49 File Offset: 0x00006E49
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_FemaleSkins.isStared && this.m_FemaleSkins.hitSkins.useSkins)
			{
				this.Subscribe();
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00008C76 File Offset: 0x00006E76
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00008C88 File Offset: 0x00006E88
		private void Subscribe()
		{
			this.m_vagWallsCollisionable.collisionEnterBase += this.M_vagWallsCollisionable_collision;
			this.m_vagWallsCollisionable.collisionStayBase += this.M_vagWallsCollisionable_collision;
			this.m_anusWallsCollisionable.collisionEnterBase += this.M_anusWallsCollisionable_collision;
			this.m_anusWallsCollisionable.collisionStayBase += this.M_anusWallsCollisionable_collision;
			this.m_bocaWallsCollisionable.collisionEnterBase += this.M_bocaWallsCollisionable_collision;
			this.m_bocaWallsCollisionable.collisionStayBase += this.M_bocaWallsCollisionable_collision;
			this.m_vagFondoCollisionable.collisionEnterBase += this.M_vagFondoAnchoCollisionable_collision;
			this.m_vagFondoCollisionable.collisionStayBase += this.M_vagFondoAnchoCollisionable_collision;
			this.m_anusFondoCollisionable.collisionEnterBase += this.M_anusFondoAnchoCollisionable_collision;
			this.m_anusFondoCollisionable.collisionStayBase += this.M_anusFondoAnchoCollisionable_collision;
			this.m_bocaFondoCollisionable.collisionEnterBase += this.M_bocaFondoAnchoCollisionable_collision;
			this.m_bocaFondoCollisionable.collisionStayBase += this.M_bocaFondoAnchoCollisionable_collision;
			this.m_vagAnchoCollisionable.collisionEnterBase += this.M_vagFondoAnchoCollisionable_collision;
			this.m_vagAnchoCollisionable.collisionStayBase += this.M_vagFondoAnchoCollisionable_collision;
			this.m_anusAnchoCollisionable.collisionEnterBase += this.M_anusFondoAnchoCollisionable_collision;
			this.m_anusAnchoCollisionable.collisionStayBase += this.M_anusFondoAnchoCollisionable_collision;
			this.m_bocaAnchoCollisionable.collisionEnterBase += this.M_bocaFondoAnchoCollisionable_collision;
			this.m_bocaAnchoCollisionable.collisionStayBase += this.M_bocaFondoAnchoCollisionable_collision;
			this.m_vagEntradaCollisionable.collisionEnterBase += this.M_vagEntradaCollisionable_collision;
			this.m_vagEntradaCollisionable.collisionStayBase += this.M_vagEntradaCollisionable_collision;
			this.m_anusEntradaCollisionable.collisionEnterBase += this.M_anusEntradaCollisionable_collision;
			this.m_anusEntradaCollisionable.collisionStayBase += this.M_anusEntradaCollisionable_collision;
			this.m_bocaEntradaCollisionable.collisionEnterBase += this.M_bocaEntradaCollisionable_collision;
			this.m_bocaEntradaCollisionable.collisionStayBase += this.M_bocaEntradaCollisionable_collision;
			this.m_headCollisionable.collisionEnterBase += this.M_headCollisionable_collision;
			this.m_headCollisionable.collisionStayBase += this.M_headCollisionable_collision;
			this.m_torzoCollisionable.collisionEnterBase += this.M_torzoCollisionable_collision;
			this.m_torzoCollisionable.collisionStayBase += this.M_torzoCollisionable_collision;
			this.m_brazo_R.collisionEnterBase += this.M_brazo_R_collision;
			this.m_brazo_R.collisionStayBase += this.M_brazo_R_collision;
			this.m_antebrazo_R.collisionEnterBase += this.M_antebrazo_R_collision;
			this.m_antebrazo_R.collisionStayBase += this.M_antebrazo_R_collision;
			this.m_mano_R.collisionEnterBase += this.M_mano_R_collision;
			this.m_mano_R.collisionStayBase += this.M_mano_R_collision;
			this.m_brazo_L.collisionEnterBase += this.M_brazo_L_collision;
			this.m_brazo_L.collisionStayBase += this.M_brazo_L_collision;
			this.m_antebrazo_L.collisionEnterBase += this.M_antebrazo_L_collision;
			this.m_antebrazo_L.collisionStayBase += this.M_antebrazo_L_collision;
			this.m_mano_L.collisionEnterBase += this.M_mano_L_collision;
			this.m_mano_L.collisionStayBase += this.M_mano_L_collision;
			this.m_piena_R.collisionEnterBase += this.M_piena_R_collision;
			this.m_piena_R.collisionStayBase += this.M_piena_R_collision;
			this.m_canilla_R.collisionEnterBase += this.M_canilla_R_collision;
			this.m_canilla_R.collisionStayBase += this.M_canilla_R_collision;
			this.m_pie_R.collisionEnterBase += this.M_pie_R_collision;
			this.m_pie_R.collisionStayBase += this.M_pie_R_collision;
			this.m_piena_L.collisionEnterBase += this.M_piena_L_collision;
			this.m_piena_L.collisionStayBase += this.M_piena_L_collision;
			this.m_canilla_L.collisionEnterBase += this.M_canilla_L_collision;
			this.m_canilla_L.collisionStayBase += this.M_canilla_L_collision;
			this.m_pie_L.collisionEnterBase += this.M_pie_L_collision;
			this.m_pie_L.collisionStayBase += this.M_pie_L_collision;
			this.nalga_R.collisionEnterBase += this.Nalga_R_collision;
			this.nalga_R.collisionStayBase += this.Nalga_R_collision;
			this.nalga_L.collisionEnterBase += this.Nalga_L_collision;
			this.nalga_L.collisionStayBase += this.Nalga_L_collision;
			this.Seno_000_R.collisionEnterBase += this.Seno_R_collision;
			this.Seno_000_R.collisionStayBase += this.Seno_R_collision;
			this.Seno_001_R.collisionEnterBase += this.Seno_R_collision;
			this.Seno_001_R.collisionStayBase += this.Seno_R_collision;
			this.Seno_002_R.collisionEnterBase += this.Seno_R_collision;
			this.Seno_002_R.collisionStayBase += this.Seno_R_collision;
			this.Seno_000_L.collisionEnterBase += this.Seno_L_collision;
			this.Seno_000_L.collisionStayBase += this.Seno_L_collision;
			this.Seno_001_L.collisionEnterBase += this.Seno_L_collision;
			this.Seno_001_L.collisionStayBase += this.Seno_L_collision;
			this.Seno_002_L.collisionEnterBase += this.Seno_L_collision;
			this.Seno_002_L.collisionStayBase += this.Seno_L_collision;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000092B4 File Offset: 0x000074B4
		private void Unsubscribe()
		{
			if (this.Seno_000_R != null)
			{
				this.Seno_000_R.collisionEnterBase -= this.Seno_R_collision;
				this.Seno_000_R.collisionStayBase -= this.Seno_R_collision;
			}
			if (this.Seno_001_R != null)
			{
				this.Seno_001_R.collisionEnterBase -= this.Seno_R_collision;
				this.Seno_001_R.collisionStayBase -= this.Seno_R_collision;
			}
			if (this.Seno_002_R != null)
			{
				this.Seno_002_R.collisionEnterBase -= this.Seno_R_collision;
				this.Seno_002_R.collisionStayBase -= this.Seno_R_collision;
			}
			if (this.Seno_000_L != null)
			{
				this.Seno_000_L.collisionEnterBase -= this.Seno_L_collision;
				this.Seno_000_L.collisionStayBase -= this.Seno_L_collision;
			}
			if (this.Seno_001_L != null)
			{
				this.Seno_001_L.collisionEnterBase -= this.Seno_L_collision;
				this.Seno_001_L.collisionStayBase -= this.Seno_L_collision;
			}
			if (this.Seno_002_L != null)
			{
				this.Seno_002_L.collisionEnterBase -= this.Seno_L_collision;
				this.Seno_002_L.collisionStayBase -= this.Seno_L_collision;
			}
			if (this.nalga_R != null)
			{
				this.nalga_R.collisionEnterBase -= this.Nalga_R_collision;
				this.nalga_R.collisionStayBase -= this.Nalga_R_collision;
			}
			if (this.nalga_L != null)
			{
				this.nalga_L.collisionEnterBase -= this.Nalga_L_collision;
				this.nalga_L.collisionStayBase -= this.Nalga_L_collision;
			}
			if (this.m_torzoCollisionable != null)
			{
				this.m_torzoCollisionable.collisionEnterBase -= this.M_torzoCollisionable_collision;
				this.m_torzoCollisionable.collisionStayBase -= this.M_torzoCollisionable_collision;
			}
			if (this.m_headCollisionable != null)
			{
				this.m_headCollisionable.collisionEnterBase -= this.M_headCollisionable_collision;
				this.m_headCollisionable.collisionStayBase -= this.M_headCollisionable_collision;
			}
			if (this.m_brazo_R != null)
			{
				this.m_brazo_R.collisionEnterBase -= this.M_brazo_R_collision;
				this.m_brazo_R.collisionStayBase -= this.M_brazo_R_collision;
			}
			if (this.m_antebrazo_R != null)
			{
				this.m_antebrazo_R.collisionEnterBase -= this.M_antebrazo_R_collision;
				this.m_antebrazo_R.collisionStayBase -= this.M_antebrazo_R_collision;
			}
			if (this.m_mano_R != null)
			{
				this.m_mano_R.collisionEnterBase -= this.M_mano_R_collision;
				this.m_mano_R.collisionStayBase -= this.M_mano_R_collision;
			}
			if (this.m_brazo_L != null)
			{
				this.m_brazo_L.collisionEnterBase -= this.M_brazo_L_collision;
				this.m_brazo_L.collisionStayBase -= this.M_brazo_L_collision;
			}
			if (this.m_antebrazo_L != null)
			{
				this.m_antebrazo_L.collisionEnterBase -= this.M_antebrazo_L_collision;
				this.m_antebrazo_L.collisionStayBase -= this.M_antebrazo_L_collision;
			}
			if (this.m_mano_L != null)
			{
				this.m_mano_L.collisionEnterBase -= this.M_mano_L_collision;
				this.m_mano_L.collisionStayBase -= this.M_mano_L_collision;
			}
			if (this.m_piena_R != null)
			{
				this.m_piena_R.collisionEnterBase -= this.M_piena_R_collision;
				this.m_piena_R.collisionStayBase -= this.M_piena_R_collision;
			}
			if (this.m_canilla_R != null)
			{
				this.m_canilla_R.collisionEnterBase -= this.M_canilla_R_collision;
				this.m_canilla_R.collisionStayBase -= this.M_canilla_R_collision;
			}
			if (this.m_pie_R != null)
			{
				this.m_pie_R.collisionEnterBase -= this.M_pie_R_collision;
				this.m_pie_R.collisionStayBase -= this.M_pie_R_collision;
			}
			if (this.m_piena_L != null)
			{
				this.m_piena_L.collisionEnterBase -= this.M_piena_L_collision;
				this.m_piena_L.collisionStayBase -= this.M_piena_L_collision;
			}
			if (this.m_canilla_L != null)
			{
				this.m_canilla_L.collisionEnterBase -= this.M_canilla_L_collision;
				this.m_canilla_L.collisionStayBase -= this.M_canilla_L_collision;
			}
			if (this.m_pie_L != null)
			{
				this.m_pie_L.collisionEnterBase -= this.M_pie_L_collision;
				this.m_pie_L.collisionStayBase -= this.M_pie_L_collision;
			}
			if (this.m_vagFondoCollisionable != null)
			{
				this.m_vagFondoCollisionable.collisionEnterBase -= this.M_vagFondoAnchoCollisionable_collision;
				this.m_vagFondoCollisionable.collisionStayBase -= this.M_vagFondoAnchoCollisionable_collision;
			}
			if (this.m_anusFondoCollisionable != null)
			{
				this.m_anusFondoCollisionable.collisionEnterBase -= this.M_anusFondoAnchoCollisionable_collision;
				this.m_anusFondoCollisionable.collisionStayBase -= this.M_anusFondoAnchoCollisionable_collision;
			}
			if (this.m_bocaFondoCollisionable != null)
			{
				this.m_bocaFondoCollisionable.collisionEnterBase -= this.M_bocaFondoAnchoCollisionable_collision;
				this.m_bocaFondoCollisionable.collisionStayBase -= this.M_bocaFondoAnchoCollisionable_collision;
			}
			if (this.m_vagAnchoCollisionable != null)
			{
				this.m_vagAnchoCollisionable.collisionEnterBase -= this.M_vagFondoAnchoCollisionable_collision;
				this.m_vagAnchoCollisionable.collisionStayBase -= this.M_vagFondoAnchoCollisionable_collision;
			}
			if (this.m_anusAnchoCollisionable != null)
			{
				this.m_anusAnchoCollisionable.collisionEnterBase -= this.M_anusFondoAnchoCollisionable_collision;
				this.m_anusAnchoCollisionable.collisionStayBase -= this.M_anusFondoAnchoCollisionable_collision;
			}
			if (this.m_bocaAnchoCollisionable != null)
			{
				this.m_bocaAnchoCollisionable.collisionEnterBase -= this.M_bocaFondoAnchoCollisionable_collision;
				this.m_bocaAnchoCollisionable.collisionStayBase -= this.M_bocaFondoAnchoCollisionable_collision;
			}
			if (this.m_vagEntradaCollisionable != null)
			{
				this.m_vagEntradaCollisionable.collisionEnterBase -= this.M_vagEntradaCollisionable_collision;
				this.m_vagEntradaCollisionable.collisionStayBase -= this.M_vagEntradaCollisionable_collision;
			}
			if (this.m_anusEntradaCollisionable != null)
			{
				this.m_anusEntradaCollisionable.collisionEnterBase -= this.M_anusEntradaCollisionable_collision;
				this.m_anusEntradaCollisionable.collisionStayBase -= this.M_anusEntradaCollisionable_collision;
			}
			if (this.m_bocaEntradaCollisionable != null)
			{
				this.m_bocaEntradaCollisionable.collisionEnterBase -= this.M_bocaEntradaCollisionable_collision;
				this.m_bocaEntradaCollisionable.collisionStayBase -= this.M_bocaEntradaCollisionable_collision;
			}
			if (this.m_vagWallsCollisionable != null)
			{
				this.m_vagWallsCollisionable.collisionEnterBase -= this.M_vagWallsCollisionable_collision;
				this.m_vagWallsCollisionable.collisionStayBase -= this.M_vagWallsCollisionable_collision;
			}
			if (this.m_anusWallsCollisionable != null)
			{
				this.m_anusWallsCollisionable.collisionEnterBase -= this.M_anusWallsCollisionable_collision;
				this.m_anusWallsCollisionable.collisionStayBase -= this.M_anusWallsCollisionable_collision;
			}
			if (this.m_bocaWallsCollisionable != null)
			{
				this.m_bocaWallsCollisionable.collisionEnterBase -= this.M_bocaWallsCollisionable_collision;
				this.m_bocaWallsCollisionable.collisionStayBase -= this.M_bocaWallsCollisionable_collision;
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000099ED File Offset: 0x00007BED
		private void M_vagWallsCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_VagWalls(obj, 1f);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000099FB File Offset: 0x00007BFB
		private void M_anusWallsCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_AnusWalls(obj, 1f);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00009A09 File Offset: 0x00007C09
		private void M_bocaWallsCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_BocaWalls(obj, 1f);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00009A17 File Offset: 0x00007C17
		private void M_vagFondoAnchoCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_VagFondoAncho(obj, 1f);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00009A25 File Offset: 0x00007C25
		private void M_anusFondoAnchoCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_AnusFondoAncho(obj, 1f);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00009A33 File Offset: 0x00007C33
		private void M_bocaFondoAnchoCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_BocaFondoAncho(obj, 1f);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00009A41 File Offset: 0x00007C41
		private void M_vagEntradaCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_VagEntrada(obj, 1f);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00009A4F File Offset: 0x00007C4F
		private void M_anusEntradaCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_AnusEntrada(obj, 1f);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00009A5D File Offset: 0x00007C5D
		private void M_bocaEntradaCollisionable_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_BocaEntrada(obj, 1f);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00009A6B File Offset: 0x00007C6B
		private void M_torzoCollisionable_collision(ColisionBasicaV2 obj)
		{
			if (obj is IColisionContraBodyPartes)
			{
				this.ResolveCollision_ConPartes(obj);
				return;
			}
			this.ResolveCollision_Pecho(obj, 1f);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00009A89 File Offset: 0x00007C89
		private void M_headCollisionable_collision(ColisionBasicaV2 obj)
		{
			if (obj is IColisionContraBodyPartes)
			{
				this.ResolveCollision_ConPartes(obj);
				return;
			}
			this.ResolveCollision_Head(obj, 1f);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00009AA7 File Offset: 0x00007CA7
		private void M_pie_L_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Pie_L(obj, 1f);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00009AB5 File Offset: 0x00007CB5
		private void M_canilla_L_collision(ColisionBasicaV2 obj)
		{
			if (obj is IColisionContraBodyPartes)
			{
				this.ResolveCollision_ConPartes(obj);
				return;
			}
			this.ResolveCollision_Canilla_L(obj, 1f);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00009AD3 File Offset: 0x00007CD3
		private void M_piena_L_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Muslo_L(obj, 1f);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00009AE1 File Offset: 0x00007CE1
		private void M_pie_R_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Pie_R(obj, 1f);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00009AEF File Offset: 0x00007CEF
		private void M_canilla_R_collision(ColisionBasicaV2 obj)
		{
			if (obj is IColisionContraBodyPartes)
			{
				this.ResolveCollision_ConPartes(obj);
				return;
			}
			this.ResolveCollision_Canilla_R(obj, 1f);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00009B0D File Offset: 0x00007D0D
		private void M_piena_R_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Muslo_R(obj, 1f);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00009B1B File Offset: 0x00007D1B
		private void M_mano_L_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Hand_L(obj, 1f);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00009B29 File Offset: 0x00007D29
		private void M_antebrazo_L_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Forearms_L(obj, 1f);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00009B37 File Offset: 0x00007D37
		private void M_brazo_L_collision(ColisionBasicaV2 obj)
		{
			if (obj is IColisionContraBodyPartes)
			{
				this.ResolveCollision_ConPartes(obj);
				return;
			}
			this.ResolveCollision_Arms_L(obj, 1f);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00009B55 File Offset: 0x00007D55
		private void M_mano_R_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Hand_R(obj, 1f);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00009B63 File Offset: 0x00007D63
		private void M_antebrazo_R_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Forearms_R(obj, 1f);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00009B71 File Offset: 0x00007D71
		private void M_brazo_R_collision(ColisionBasicaV2 obj)
		{
			if (obj is IColisionContraBodyPartes)
			{
				this.ResolveCollision_ConPartes(obj);
				return;
			}
			this.ResolveCollision_Arms_R(obj, 1f);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00009B8F File Offset: 0x00007D8F
		private void Seno_R_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Seno_R(obj, 1f);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00009B9D File Offset: 0x00007D9D
		private void Seno_L_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Seno_L(obj, 1f);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00009BAB File Offset: 0x00007DAB
		private void Nalga_R_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Nalga_R(obj, 1f);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00009BB9 File Offset: 0x00007DB9
		private void Nalga_L_collision(ColisionBasicaV2 obj)
		{
			this.ResolveCollision_Nalga_L(obj, 1f);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00009BC8 File Offset: 0x00007DC8
		private void ResolveCollision_ConPartes(ColisionBasicaV2 obj)
		{
			IColisionContraBodyPartes colisionContraBodyPartes = (IColisionContraBodyPartes)obj;
			if (colisionContraBodyPartes.partesImpactadas.Count == 0)
			{
				Debug.LogError("Collison en " + obj.nosotrosVelocitySaver.name + ", no tiene ninguna parte registrada", this);
				return;
			}
			float num = 1f / (float)colisionContraBodyPartes.partesImpactadas.Count;
			for (int i = 0; i < colisionContraBodyPartes.partesImpactadas.Count; i++)
			{
				BodyPartEnum bodyPartEnum = colisionContraBodyPartes.partesImpactadas[i];
				switch (bodyPartEnum)
				{
				case BodyPartEnum.cabeza:
				case BodyPartEnum.mandibula:
				case BodyPartEnum.boca:
				case BodyPartEnum.nariz:
				case BodyPartEnum.mejilla_L:
				case BodyPartEnum.mejilla_R:
				case BodyPartEnum.ojo_L:
				case BodyPartEnum.ojo_R:
				case BodyPartEnum.ojoInterno_L:
				case BodyPartEnum.ojoInterno_R:
				case BodyPartEnum.ceja_L:
				case BodyPartEnum.ceja_R:
				case BodyPartEnum.ciene_L:
				case BodyPartEnum.ciene_R:
				case BodyPartEnum.frente:
				case BodyPartEnum.lengua:
					this.ResolveCollision_Head(obj, num);
					break;
				case BodyPartEnum.cuello:
					this.ResolveCollision_Neck(obj, num);
					break;
				case BodyPartEnum.bocaInterno:
					this.ResolveCollision_Boca(obj, num);
					break;
				case BodyPartEnum.pecho:
				case BodyPartEnum.espalda:
					this.ResolveCollision_Pecho(obj, num);
					break;
				case BodyPartEnum.hombro_L:
				case BodyPartEnum.axila_L:
					this.ResolveCollision_Shoulder_L(obj, num);
					break;
				case BodyPartEnum.hombro_R:
				case BodyPartEnum.axila_R:
					this.ResolveCollision_Shoulder_R(obj, num);
					break;
				case BodyPartEnum.brazo_L:
					this.ResolveCollision_Arms_L(obj, num);
					break;
				case BodyPartEnum.brazo_R:
					this.ResolveCollision_Arms_R(obj, num);
					break;
				case BodyPartEnum.anteBrazo_L:
					this.ResolveCollision_Forearms_L(obj, num);
					break;
				case BodyPartEnum.anteBrazo_R:
					this.ResolveCollision_Forearms_R(obj, num);
					break;
				case BodyPartEnum.mano_L:
					this.ResolveCollision_Hand_L(obj, num);
					break;
				case BodyPartEnum.mano_R:
					this.ResolveCollision_Hand_R(obj, num);
					break;
				case BodyPartEnum.seno_L:
				case BodyPartEnum.pezon_L:
					this.ResolveCollision_Seno_L(obj, num);
					break;
				case BodyPartEnum.seno_R:
				case BodyPartEnum.pezon_R:
					this.ResolveCollision_Seno_R(obj, num);
					break;
				case BodyPartEnum.abdomen:
				case BodyPartEnum.cintura:
				case BodyPartEnum.hombligo:
					this.ResolveCollision_Cintura(obj, num);
					break;
				case BodyPartEnum.cadera_L:
				case BodyPartEnum.nalga_L:
					this.ResolveCollision_Nalga_L(obj, num);
					break;
				case BodyPartEnum.cadera_R:
				case BodyPartEnum.nalga_R:
					this.ResolveCollision_Nalga_R(obj, num);
					break;
				case BodyPartEnum.coxis:
				case BodyPartEnum.vientre:
				case BodyPartEnum.vagina:
				case BodyPartEnum.perineo:
				case BodyPartEnum.clitoris:
				case BodyPartEnum.labiosVaginales:
					this.ResolveCollision_Cadera(obj, num);
					break;
				case BodyPartEnum.anoHole:
					this.ResolveCollision_Anus(obj, num);
					break;
				case BodyPartEnum.vagHole:
					this.ResolveCollision_Vag(obj, num);
					break;
				case BodyPartEnum.pierna_L:
					this.ResolveCollision_Muslo_L(obj, num);
					break;
				case BodyPartEnum.pierna_R:
					this.ResolveCollision_Muslo_R(obj, num);
					break;
				case BodyPartEnum.rodilla_L:
					this.ResolveCollision_Rodilla_L(obj, num);
					break;
				case BodyPartEnum.rodilla_R:
					this.ResolveCollision_Rodilla_R(obj, num);
					break;
				case BodyPartEnum.canilla_L:
					this.ResolveCollision_Canilla_L(obj, num);
					break;
				case BodyPartEnum.canilla_R:
					this.ResolveCollision_Canilla_R(obj, num);
					break;
				case BodyPartEnum.pie_L:
					this.ResolveCollision_Pie_L(obj, num);
					break;
				case BodyPartEnum.pie_R:
					this.ResolveCollision_Pie_R(obj, num);
					break;
				case BodyPartEnum.fondoVag:
				case BodyPartEnum.anchoVag:
					this.ResolveCollision_VagFondoAncho(obj, num);
					break;
				case BodyPartEnum.fondoAnus:
				case BodyPartEnum.anchoAnus:
					this.ResolveCollision_AnusFondoAncho(obj, num);
					break;
				case BodyPartEnum.fondoBoca:
				case BodyPartEnum.anchoBoca:
					this.ResolveCollision_BocaFondoAncho(obj, num);
					break;
				case BodyPartEnum.entradaVag:
					this.ResolveCollision_VagEntrada(obj, num);
					break;
				case BodyPartEnum.entradaAnus:
					this.ResolveCollision_AnusEntrada(obj, num);
					break;
				case BodyPartEnum.entradaBoca:
					this.ResolveCollision_BocaEntrada(obj, num);
					break;
				default:
					throw new ArgumentOutOfRangeException(bodyPartEnum.ToString());
				}
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00009F08 File Offset: 0x00008108
		private bool EsAgainsConvexCollider(ColisionBasicaV2 obj)
		{
			Collider colliderChocandonos = obj.colliderChocandonos;
			return this.m_selfToConvexColliders.toConvexCollidersSet.Contains(colliderChocandonos);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00009F2D File Offset: 0x0000812D
		private void ResolveCollision_VagWalls(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.vagwallsInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00009F69 File Offset: 0x00008169
		private void ResolveCollision_AnusWalls(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.anuswallsInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00009FA8 File Offset: 0x000081A8
		private void ResolveCollision_BocaWalls(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.bocawallsInForceMod * inForceMod * 0.6667f, obj, this.m_headBuffer, this.debugDraw, this.debugLog, 0f, 1f);
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.bocawallsInForceMod * inForceMod * 0.3334f, obj, this.m_neckBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000A02C File Offset: 0x0000822C
		private void ResolveCollision_VagFondoAncho(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.vagFondoAnchoInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000A074 File Offset: 0x00008274
		private void ResolveCollision_AnusFondoAncho(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.anusFondoAnchoInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000A0BC File Offset: 0x000082BC
		private void ResolveCollision_BocaFondoAncho(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.bocaFondoAnchoInForceMod * inForceMod * 0.6667f, obj, this.m_headBuffer, this.debugDraw, this.debugLog, 0f, 1f);
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.bocaFondoAnchoInForceMod * inForceMod * 0.3334f, obj, this.m_neckBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000A144 File Offset: 0x00008344
		private void ResolveCollision_VagEntrada(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.vagEntradaInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000A18C File Offset: 0x0000838C
		private void ResolveCollision_AnusEntrada(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.anusEntradaInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000A1D4 File Offset: 0x000083D4
		private void ResolveCollision_BocaEntrada(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.bocaEntradaInForceMod * inForceMod * 0.6667f, obj, this.m_headBuffer, this.debugDraw, this.debugLog, 0f, 1f);
			this.ResolveCollisionPorPenetracion(this.m_modsDeLayer, this.bocaEntradaInForceMod * inForceMod * 0.3334f, obj, this.m_neckBuffer, this.debugDraw, this.debugLog, 0f, 1f);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000A259 File Offset: 0x00008459
		private void ResolveCollision_Head(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.headInForceMod * inForceMod, obj, this.m_headBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000A295 File Offset: 0x00008495
		private void ResolveCollision_Neck(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.cuelloInForceMod * inForceMod, obj, this.m_neckBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000A2D1 File Offset: 0x000084D1
		private void ResolveCollision_Pecho(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.pechoInForceMod * inForceMod, obj, this.m_spine2Buffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000A30D File Offset: 0x0000850D
		private void ResolveCollision_Cintura(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.cinturaInForceMod * inForceMod, obj, this.m_spine1Buffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000A349 File Offset: 0x00008549
		private void ResolveCollision_Cadera(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.hipsInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000A388 File Offset: 0x00008588
		private void ResolveCollision_Seno_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			Collider colliderChocandonos = obj.colliderChocandonos;
			if (this.Seno_000_L.ContieneCollider(colliderChocandonos) || this.Seno_001_L.ContieneCollider(colliderChocandonos) || this.Seno_002_L.ContieneCollider(colliderChocandonos))
			{
				return;
			}
			if (this.m_FemaleSkins.hitSkins.partes.senos000VsConvex.l.ownCollider == colliderChocandonos)
			{
				return;
			}
			if (this.m_FemaleSkins.hitSkins.partes.senos001VsConvex.l.ownCollider == colliderChocandonos)
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.senosInForceMod * inForceMod, obj, this.m_spine2Buffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000A454 File Offset: 0x00008654
		private void ResolveCollision_Seno_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			Collider colliderChocandonos = obj.colliderChocandonos;
			if (this.Seno_000_R.ContieneCollider(colliderChocandonos) || this.Seno_001_R.ContieneCollider(colliderChocandonos) || this.Seno_002_R.ContieneCollider(colliderChocandonos))
			{
				return;
			}
			if (this.m_FemaleSkins.hitSkins.partes.senos000VsConvex.r.ownCollider == colliderChocandonos)
			{
				return;
			}
			if (this.m_FemaleSkins.hitSkins.partes.senos001VsConvex.r.ownCollider == colliderChocandonos)
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.senosInForceMod * inForceMod, obj, this.m_spine2Buffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000A520 File Offset: 0x00008720
		private void ResolveCollision_Nalga_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.nalgaInForceMod * 0.5f * inForceMod, obj, this.m_thingsRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.nalgaInForceMod * 0.5f * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000A5A4 File Offset: 0x000087A4
		private void ResolveCollision_Nalga_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.nalgaInForceMod * 0.5f * inForceMod, obj, this.m_thingsLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.nalgaInForceMod * 0.5f * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000A627 File Offset: 0x00008827
		private void ResolveCollision_Shoulder_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_shouldersRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000A663 File Offset: 0x00008863
		private void ResolveCollision_Shoulder_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_shouldersLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000A69F File Offset: 0x0000889F
		private void ResolveCollision_Arms_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_armsRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000A6DB File Offset: 0x000088DB
		private void ResolveCollision_Arms_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_armsLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000A717 File Offset: 0x00008917
		private void ResolveCollision_Forearms_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_forearmsRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000A753 File Offset: 0x00008953
		private void ResolveCollision_Forearms_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_forearmsLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000A78F File Offset: 0x0000898F
		private void ResolveCollision_Hand_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_handsRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000A7CB File Offset: 0x000089CB
		private void ResolveCollision_Hand_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.armsInForceMod * inForceMod, obj, this.m_handsLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000A807 File Offset: 0x00008A07
		private void ResolveCollision_Muslo_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod, obj, this.m_thingsRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000A843 File Offset: 0x00008A43
		private void ResolveCollision_Muslo_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod, obj, this.m_thingsLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000A880 File Offset: 0x00008A80
		private void ResolveCollision_Rodilla_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod * 0.5f, obj, this.m_thingsRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod * 0.5f, obj, this.m_calfRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000A904 File Offset: 0x00008B04
		private void ResolveCollision_Rodilla_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod * 0.5f, obj, this.m_thingsLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod * 0.5f, obj, this.m_calfLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000A987 File Offset: 0x00008B87
		private void ResolveCollision_Canilla_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod, obj, this.m_calfRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000A9C3 File Offset: 0x00008BC3
		private void ResolveCollision_Canilla_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod, obj, this.m_calfLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000A9FF File Offset: 0x00008BFF
		private void ResolveCollision_Pie_R(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod, obj, this.m_feetRBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000AA3B File Offset: 0x00008C3B
		private void ResolveCollision_Pie_L(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.thingsInForceMod * inForceMod, obj, this.m_feetLBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000AA78 File Offset: 0x00008C78
		private void ResolveCollision_Boca(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.bocaInForceMod * inForceMod * 0.666f, obj, this.m_headBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.bocaInForceMod * inForceMod * 0.333f, obj, this.m_neckBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000AAFB File Offset: 0x00008CFB
		private void ResolveCollision_Vag(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.vagInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000AB37 File Offset: 0x00008D37
		private void ResolveCollision_Anus(ColisionBasicaV2 obj, float inForceMod = 1f)
		{
			if (this.EsAgainsConvexCollider(obj))
			{
				return;
			}
			SkinCollisionForceTransfer.ResolveCollision(this.m_modsDeLayer, this.anusInForceMod * inForceMod, obj, this.m_HipsBuffer, this.debugDraw, this.debugLog, 0.2f, 0.8f);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000AB74 File Offset: 0x00008D74
		private void ResolveCollisionPorPenetracion(IDictionary<DiccLayer, float> modDeForcePorColliderLayer, float inForceMod, ColisionBasicaV2 collision, BufferDeFuerzas buffer, bool debugDraw, bool debugLog, float emulatedMod = 0.2f, float physcisMod = 0.8f)
		{
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			if (SkinCollisionForceTransfer.ResolveCollision(out vector, out vector2, out vector3, modDeForcePorColliderLayer, inForceMod, collision, buffer, debugDraw, debugLog, emulatedMod, physcisMod))
			{
				SkinCollisionForceTransfer.OnFuerzasPorPenetracionHandler onFuerzasPorPenetracionHandler = this.onFuerzasPorPenetracion;
				if (onFuerzasPorPenetracionHandler == null)
				{
					return;
				}
				onFuerzasPorPenetracionHandler(vector, vector2, vector3, collision, this);
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000ABB0 File Offset: 0x00008DB0
		private static void ResolveCollision(IDictionary<DiccLayer, float> modDeForcePorColliderLayer, float inForceMod, ColisionBasicaV2 collision, BufferDeFuerzas buffer, bool debugDraw, bool debugLog, float emulatedMod = 0.2f, float physcisMod = 0.8f)
		{
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			SkinCollisionForceTransfer.ResolveCollision(out vector, out vector2, out vector3, modDeForcePorColliderLayer, inForceMod, collision, buffer, debugDraw, debugLog, emulatedMod, physcisMod);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000ABD8 File Offset: 0x00008DD8
		private static bool ResolveCollision(out Vector3 point, out Vector3 realForce, out Vector3 usedForce, IDictionary<DiccLayer, float> modDeForcePorColliderLayer, float inForceMod, ColisionBasicaV2 collision, BufferDeFuerzas buffer, bool debugDraw, bool debugLog, float emulatedMod = 0.2f, float physcisMod = 0.8f)
		{
			point = Vector3.zero;
			realForce = Vector3.zero;
			usedForce = Vector3.zero;
			float num;
			if (!modDeForcePorColliderLayer.TryGetValue(new DiccLayer
			{
				layer = collision.colliderChocandonos.gameObject.layer
			}, out num))
			{
				num = modDeForcePorColliderLayer[new DiccLayer
				{
					layer = 0
				}];
			}
			inForceMod *= num;
			float num2 = 0f;
			if (collision.chocandonosTieneRigidbody)
			{
				num2 = collision.rigidbodyChocandonos.mass;
			}
			float currentMassMod = collision.otherVelocitySaver.massModifier.currentMassMod;
			Vector3 vector;
			if (collision.usaPhyscisVelocidadRelativa)
			{
				vector = collision.velocidadEmuladaRelativa * emulatedMod + collision.physcisVelocidadRelativa * physcisMod;
			}
			else
			{
				vector = collision.velocidadEmuladaRelativa;
			}
			usedForce = vector * ((num2 <= 0f) ? currentMassMod : (num2 * currentMassMod)) * inForceMod;
			realForce = vector * num2;
			if (realForce.sqrMagnitude <= 0f && usedForce.sqrMagnitude <= 0f)
			{
				return false;
			}
			point = collision.point.ObtenerVectorGlobal();
			buffer.AddForce(point, usedForce);
			if (debugLog)
			{
				string[] array = new string[16];
				array[0] = "buffer: ";
				array[1] = buffer.target.name;
				array[2] = " By: ";
				array[3] = collision.otherVelocitySaver.name;
				array[4] = " On: ";
				array[5] = collision.nosotrosVelocitySaver.name;
				array[6] = " forceMag: ";
				array[7] = usedForce.magnitude.ToString();
				array[8] = " velMag: ";
				array[9] = vector.magnitude.ToString();
				array[10] = " mass: ";
				array[11] = num2.ToString();
				array[12] = " depenVel: ";
				int num3 = 13;
				Rigidbody rigidbodyChocandonos = collision.rigidbodyChocandonos;
				array[num3] = ((rigidbodyChocandonos != null) ? new float?(rigidbodyChocandonos.maxDepenetrationVelocity) : null).GetValueOrDefault().ToString();
				array[14] = " ownDepenVel: ";
				int num4 = 15;
				Rigidbody rigid = collision.nosotrosVelocitySaver.rigid;
				array[num4] = ((rigid != null) ? new float?(rigid.maxDepenetrationVelocity) : null).GetValueOrDefault().ToString();
				Debug.Log(string.Concat(array));
			}
			if (debugDraw)
			{
				bool usaPhyscisVelocidadRelativa = collision.usaPhyscisVelocidadRelativa;
			}
			return true;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000AE68 File Offset: 0x00009068
		public override void OnUpdateEvent1()
		{
			this.m_HipsBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_spine2Buffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_spine1Buffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_thingsLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_thingsRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_neckBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_headBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_shouldersLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_shouldersRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_armsLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_armsRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_calfLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_calfRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_forearmsLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_forearmsRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_feetLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_feetRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_handsLBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
			this.m_handsRBuffer.DoFixedUpdate(this.m_ToBehaviourForceSender);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000AFB8 File Offset: 0x000091B8
		public void OnFuerzaAplicadaHandler(Vector3 force, Vector3 position, BufferDeFuerzas sender)
		{
			PuppetMasterUpdater puppetMasterUpdater = this.m_PuppetMasterUpdater;
			if (((puppetMasterUpdater != null) ? puppetMasterUpdater.puppet : null) == null)
			{
				return;
			}
			Muscle muscle = sender.targetObj as Muscle;
			if (muscle == null)
			{
				return;
			}
			MuscleCollisionBroadcaster muscleCollisionBroadcaster;
			if (!this.m_lazyLoadedBroadcasterDeMuscle.TryGetValue(muscle, out muscleCollisionBroadcaster))
			{
				Rigidbody rigidbody = muscle.rigidbody;
				if (!((rigidbody != null) ? new bool?(rigidbody.TryGetComponent<MuscleCollisionBroadcaster>(out muscleCollisionBroadcaster)) : null).GetValueOrDefault())
				{
					return;
				}
				this.m_lazyLoadedBroadcasterDeMuscle.Add(muscle, muscleCollisionBroadcaster);
			}
			for (int i = 0; i < this.m_PuppetMasterUpdater.puppet.behaviours.Length; i++)
			{
				BehaviourBase behaviourBase = this.m_PuppetMasterUpdater.puppet.behaviours[i];
				MuscleHit muscleHit = new MuscleHit(muscleCollisionBroadcaster.muscleIndex, (force * Time.fixedDeltaTime).magnitude, Vector3.zero, position);
				behaviourBase.OnMuscleHit(muscleHit);
			}
		}

		// Token: 0x040000FA RID: 250
		public bool debugDraw;

		// Token: 0x040000FB RID: 251
		public bool debugLog;

		// Token: 0x040000FC RID: 252
		[SerializeField]
		private LayerKeyFloatValueDictionary m_modsDeLayer = new LayerKeyFloatValueDictionary();

		// Token: 0x040000FD RID: 253
		[SerializeField]
		private float m_defaultLayerMod = 0.1f;

		// Token: 0x040000FE RID: 254
		private FemaleSkins m_FemaleSkins;

		// Token: 0x040000FF RID: 255
		private PuppetMasterUpdater m_PuppetMasterUpdater;

		// Token: 0x04000100 RID: 256
		private IColisionableContraColliders m_vagWallsCollisionable;

		// Token: 0x04000101 RID: 257
		private IColisionableContraColliders m_anusWallsCollisionable;

		// Token: 0x04000102 RID: 258
		private IColisionableContraColliders m_bocaWallsCollisionable;

		// Token: 0x04000103 RID: 259
		private IColisionableContraColliders m_vagFondoCollisionable;

		// Token: 0x04000104 RID: 260
		private IColisionableContraColliders m_anusFondoCollisionable;

		// Token: 0x04000105 RID: 261
		private IColisionableContraColliders m_bocaFondoCollisionable;

		// Token: 0x04000106 RID: 262
		private IColisionableContraColliders m_vagAnchoCollisionable;

		// Token: 0x04000107 RID: 263
		private IColisionableContraColliders m_anusAnchoCollisionable;

		// Token: 0x04000108 RID: 264
		private IColisionableContraColliders m_bocaAnchoCollisionable;

		// Token: 0x04000109 RID: 265
		private IColisionableContraColliders m_vagEntradaCollisionable;

		// Token: 0x0400010A RID: 266
		private IColisionableContraColliders m_anusEntradaCollisionable;

		// Token: 0x0400010B RID: 267
		private IColisionableContraColliders m_bocaEntradaCollisionable;

		// Token: 0x0400010C RID: 268
		private IColisionableContraColliders m_headCollisionable;

		// Token: 0x0400010D RID: 269
		private IColisionableContraColliders m_torzoCollisionable;

		// Token: 0x0400010E RID: 270
		private IColisionableContraColliders m_brazo_R;

		// Token: 0x0400010F RID: 271
		private IColisionableContraColliders m_antebrazo_R;

		// Token: 0x04000110 RID: 272
		private IColisionableContraColliders m_mano_R;

		// Token: 0x04000111 RID: 273
		private IColisionableContraColliders m_brazo_L;

		// Token: 0x04000112 RID: 274
		private IColisionableContraColliders m_antebrazo_L;

		// Token: 0x04000113 RID: 275
		private IColisionableContraColliders m_mano_L;

		// Token: 0x04000114 RID: 276
		private IColisionableContraColliders m_piena_R;

		// Token: 0x04000115 RID: 277
		private IColisionableContraColliders m_canilla_R;

		// Token: 0x04000116 RID: 278
		private IColisionableContraColliders m_pie_R;

		// Token: 0x04000117 RID: 279
		private IColisionableContraColliders m_piena_L;

		// Token: 0x04000118 RID: 280
		private IColisionableContraColliders m_canilla_L;

		// Token: 0x04000119 RID: 281
		private IColisionableContraColliders m_pie_L;

		// Token: 0x0400011A RID: 282
		private IColisionableContraColliders nalga_R;

		// Token: 0x0400011B RID: 283
		private IColisionableContraColliders nalga_L;

		// Token: 0x0400011C RID: 284
		private IColisionableContraColliders Seno_000_R;

		// Token: 0x0400011D RID: 285
		private IColisionableContraColliders Seno_000_L;

		// Token: 0x0400011E RID: 286
		private IColisionableContraColliders Seno_001_R;

		// Token: 0x0400011F RID: 287
		private IColisionableContraColliders Seno_001_L;

		// Token: 0x04000120 RID: 288
		private IColisionableContraColliders Seno_002_R;

		// Token: 0x04000121 RID: 289
		private IColisionableContraColliders Seno_002_L;

		// Token: 0x04000122 RID: 290
		[NonSerialized]
		private Muscle m_HipMuscle;

		// Token: 0x04000123 RID: 291
		[NonSerialized]
		private Muscle m_neckMuscle;

		// Token: 0x04000124 RID: 292
		[NonSerialized]
		private Muscle m_ChestMuscle;

		// Token: 0x04000125 RID: 293
		[NonSerialized]
		private Muscle m_SpineMuscle;

		// Token: 0x04000126 RID: 294
		[NonSerialized]
		private Muscle m_headMuscle;

		// Token: 0x04000127 RID: 295
		[NonSerialized]
		private Muscle m_shoulderLMuscle;

		// Token: 0x04000128 RID: 296
		[NonSerialized]
		private Muscle m_shoulderRMuscle;

		// Token: 0x04000129 RID: 297
		[NonSerialized]
		private Muscle m_thingsLMuscle;

		// Token: 0x0400012A RID: 298
		[NonSerialized]
		private Muscle m_thingsRMuscle;

		// Token: 0x0400012B RID: 299
		[NonSerialized]
		private Muscle m_armLMuscle;

		// Token: 0x0400012C RID: 300
		[NonSerialized]
		private Muscle m_armRMuscle;

		// Token: 0x0400012D RID: 301
		[NonSerialized]
		private Muscle m_calfLMuscle;

		// Token: 0x0400012E RID: 302
		[NonSerialized]
		private Muscle m_calfRMuscle;

		// Token: 0x0400012F RID: 303
		[NonSerialized]
		private Muscle m_forearmLMuscle;

		// Token: 0x04000130 RID: 304
		[NonSerialized]
		private Muscle m_forearmRMuscle;

		// Token: 0x04000131 RID: 305
		[NonSerialized]
		private Muscle m_feetLMuscle;

		// Token: 0x04000132 RID: 306
		[NonSerialized]
		private Muscle m_feetRMuscle;

		// Token: 0x04000133 RID: 307
		[NonSerialized]
		private Muscle m_handLMuscle;

		// Token: 0x04000134 RID: 308
		[NonSerialized]
		private Muscle m_handRMuscle;

		// Token: 0x04000135 RID: 309
		public float headInForceMod = 1f;

		// Token: 0x04000136 RID: 310
		public float cuelloInForceMod = 1f;

		// Token: 0x04000137 RID: 311
		public float pechoInForceMod = 1.1f;

		// Token: 0x04000138 RID: 312
		public float cinturaInForceMod = 1.1f;

		// Token: 0x04000139 RID: 313
		public float hipsInForceMod = 1.1f;

		// Token: 0x0400013A RID: 314
		public float thingsInForceMod = 1f;

		// Token: 0x0400013B RID: 315
		public float armsInForceMod = 1f;

		// Token: 0x0400013C RID: 316
		public float nalgaInForceMod = 1.25f;

		// Token: 0x0400013D RID: 317
		public float senosInForceMod = 0.66f;

		// Token: 0x0400013E RID: 318
		public float vagInForceMod = 2f;

		// Token: 0x0400013F RID: 319
		public float anusInForceMod = 2f;

		// Token: 0x04000140 RID: 320
		public float bocaInForceMod = 2f;

		// Token: 0x04000141 RID: 321
		public float vagwallsInForceMod = 6.25f;

		// Token: 0x04000142 RID: 322
		public float anuswallsInForceMod = 12.5f;

		// Token: 0x04000143 RID: 323
		public float bocawallsInForceMod = 1.25f;

		// Token: 0x04000144 RID: 324
		public float vagFondoAnchoInForceMod = 10f;

		// Token: 0x04000145 RID: 325
		public float anusFondoAnchoInForceMod = 15f;

		// Token: 0x04000146 RID: 326
		public float bocaFondoAnchoInForceMod = 1f;

		// Token: 0x04000147 RID: 327
		public float vagEntradaInForceMod = 20f;

		// Token: 0x04000148 RID: 328
		public float anusEntradaInForceMod = 30f;

		// Token: 0x04000149 RID: 329
		public float bocaEntradaInForceMod = 1f;

		// Token: 0x0400014A RID: 330
		[SerializeField]
		private BufferDeFuerzas m_headBuffer = new BufferDeFuerzas();

		// Token: 0x0400014B RID: 331
		[SerializeField]
		private BufferDeFuerzas m_neckBuffer = new BufferDeFuerzas();

		// Token: 0x0400014C RID: 332
		[SerializeField]
		private BufferDeFuerzas m_spine2Buffer = new BufferDeFuerzas();

		// Token: 0x0400014D RID: 333
		[SerializeField]
		private BufferDeFuerzas m_spine1Buffer = new BufferDeFuerzas();

		// Token: 0x0400014E RID: 334
		[SerializeField]
		private BufferDeFuerzas m_HipsBuffer = new BufferDeFuerzas();

		// Token: 0x0400014F RID: 335
		[SerializeField]
		private BufferDeFuerzas m_shouldersLBuffer = new BufferDeFuerzas();

		// Token: 0x04000150 RID: 336
		[SerializeField]
		private BufferDeFuerzas m_shouldersRBuffer = new BufferDeFuerzas();

		// Token: 0x04000151 RID: 337
		[SerializeField]
		private BufferDeFuerzas m_thingsLBuffer = new BufferDeFuerzas();

		// Token: 0x04000152 RID: 338
		[SerializeField]
		private BufferDeFuerzas m_thingsRBuffer = new BufferDeFuerzas();

		// Token: 0x04000153 RID: 339
		[SerializeField]
		private BufferDeFuerzas m_armsLBuffer = new BufferDeFuerzas();

		// Token: 0x04000154 RID: 340
		[SerializeField]
		private BufferDeFuerzas m_armsRBuffer = new BufferDeFuerzas();

		// Token: 0x04000155 RID: 341
		[SerializeField]
		private BufferDeFuerzas m_calfLBuffer = new BufferDeFuerzas();

		// Token: 0x04000156 RID: 342
		[SerializeField]
		private BufferDeFuerzas m_calfRBuffer = new BufferDeFuerzas();

		// Token: 0x04000157 RID: 343
		[SerializeField]
		private BufferDeFuerzas m_forearmsLBuffer = new BufferDeFuerzas();

		// Token: 0x04000158 RID: 344
		[SerializeField]
		private BufferDeFuerzas m_forearmsRBuffer = new BufferDeFuerzas();

		// Token: 0x04000159 RID: 345
		[SerializeField]
		private BufferDeFuerzas m_feetLBuffer = new BufferDeFuerzas();

		// Token: 0x0400015A RID: 346
		[SerializeField]
		private BufferDeFuerzas m_feetRBuffer = new BufferDeFuerzas();

		// Token: 0x0400015B RID: 347
		[SerializeField]
		private BufferDeFuerzas m_handsLBuffer = new BufferDeFuerzas();

		// Token: 0x0400015C RID: 348
		[SerializeField]
		private BufferDeFuerzas m_handsRBuffer = new BufferDeFuerzas();

		// Token: 0x0400015D RID: 349
		private BocaHoleController m_BocaHoleController;

		// Token: 0x0400015E RID: 350
		private AnusHoleController m_AnusHoleController;

		// Token: 0x0400015F RID: 351
		private VagHoleController m_VagHoleController;

		// Token: 0x04000160 RID: 352
		private BufferDeFuerzas.FuerzaAplicadaHandler m_ToBehaviourForceSender;

		// Token: 0x04000161 RID: 353
		private PuppetCollidersToConvexAdderV3 m_selfToConvexColliders;

		// Token: 0x04000162 RID: 354
		private Dictionary<Muscle, MuscleCollisionBroadcaster> m_lazyLoadedBroadcasterDeMuscle = new Dictionary<Muscle, MuscleCollisionBroadcaster>();

		// Token: 0x02000042 RID: 66
		// (Invoke) Token: 0x06000187 RID: 391
		public delegate void OnFuerzasPorPenetracionHandler(Vector3 point, Vector3 realForce, Vector3 usedForce, ColisionBasicaV2 collision, SkinCollisionForceTransfer sender);
	}
}
