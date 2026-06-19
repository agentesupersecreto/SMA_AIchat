using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime.IK;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D3 RID: 467
	[RequireComponent(typeof(GizmoDeBone))]
	[RequireComponent(typeof(GizmoDeBoneRMInfo))]
	public class BoneGuiable : CustomUpdatedMonobehaviourBase, IMovidoEnBonesEnFrameDataCollector
	{
		// Token: 0x06000AF7 RID: 2807 RVA: 0x00036528 File Offset: 0x00034728
		public static void ActivateSkeletonEditorMode(Character c, bool fastSwitch, bool invisibleMode)
		{
			bool flag;
			GizmosDeSkeleton gizmosDeSkeleton = c.GetComponentInChildren<CustomPosesDeFemaleCharacter>().ObtenerCurrentGizmosDeSkeleton(out flag);
			Singleton<SkeletonEditorMode>.instance.ActivarEnSkeleton(gizmosDeSkeleton, fastSwitch, invisibleMode);
			PoseQueExponePartesVestidas componentInParent = gizmosDeSkeleton.GetComponentInParent<PoseQueExponePartesVestidas>();
			if (componentInParent != null)
			{
				componentInParent.UpdateInitialPartsBeingExposed();
			}
			PrepararCustomPoseOnEditMode componentInParent2 = gizmosDeSkeleton.GetComponentInParent<PrepararCustomPoseOnEditMode>();
			if (componentInParent2 == null)
			{
				return;
			}
			componentInParent2.GetComponentsInChildren<LimbIKDeCustomPose>().ForEach(delegate(LimbIKDeCustomPose ik)
			{
				ik.FollowBones();
			});
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0001F633 File Offset: 0x0001D833
		public override int updateEvent1Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent2Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x00036595 File Offset: 0x00034795
		public GizmoDeBoneRMInfo boneInfo
		{
			get
			{
				return this.m_boneInfo;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000AFB RID: 2811 RVA: 0x0003659D File Offset: 0x0003479D
		public GizmoDeBone gizmoDeBone
		{
			get
			{
				return this.m_gizmoDeBone;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x000365A5 File Offset: 0x000347A5
		public IReadOnlyList<ManipulacionDeBoneData> guiadosEnFrame
		{
			get
			{
				return this.m_guiadosEnFrameV2;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x000365AD File Offset: 0x000347AD
		public IReadOnlyList<ManipulacionDeBoneData> manipuladosEnFrame
		{
			get
			{
				return this.m_manipuladoEnFrameV2;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x000365B5 File Offset: 0x000347B5
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x000365BD File Offset: 0x000347BD
		public SiendoGuiadoEnBonesPorCharacter siendoGuiadoEnBonesPorCharacter
		{
			get
			{
				return this.m_SiendoGuiadoEnBonesPorCharacter;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x000365C5 File Offset: 0x000347C5
		public SiendoManipuladoEnBonesPorCharacter siendoManipuladoEnBonesPorCharacter
		{
			get
			{
				return this.m_SiendoManipuladoEnBonesPorCharacter;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x000365CD File Offset: 0x000347CD
		public PoseQueExponePartesVestidas poseQueExponePartesVestidas
		{
			get
			{
				return this.m_PoseQueExponePartesVestidas;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x000365D5 File Offset: 0x000347D5
		public IStepVelocitySaverEmulated selfSaver
		{
			get
			{
				return this.m_selfSaver;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x000365DD File Offset: 0x000347DD
		public IReadOnlyList<IStepVelocitySaverEmulated> childernSaver
		{
			get
			{
				return this.m_childernSaver;
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000365E8 File Offset: 0x000347E8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_boneInfo = base.GetComponent<GizmoDeBoneRMInfo>();
			this.m_gizmoDeBone = base.GetComponent<GizmoDeBone>();
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_PeticionEstadoDeInteraccionesConAI = this.GetComponentEnRoot(false);
			if (this.m_PeticionEstadoDeInteraccionesConAI == null)
			{
				throw new ArgumentNullException("m_PeticionEstadoDeInteraccionesConAI", "m_PeticionEstadoDeInteraccionesConAI null reference.");
			}
			this.m_CambiarEstadoDeInteraccionesConAI = this.GetComponentEnRoot(false);
			if (this.m_CambiarEstadoDeInteraccionesConAI == null)
			{
				throw new ArgumentNullException("m_CambiarEstadoDeInteraccionesConAI", "m_CambiarEstadoDeInteraccionesConAI null reference.");
			}
			this.m_PoseQueExponePartesVestidas = base.GetComponentInParent<PoseQueExponePartesVestidas>();
			if (this.m_PoseQueExponePartesVestidas == null)
			{
				throw new ArgumentNullException("m_PoseQueExponePartesVestidas", "m_PoseQueExponePartesVestidas null reference.");
			}
			this.m_InteraccionesDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_InteraccionesDeCharacter == null)
			{
				throw new ArgumentNullException("m_InteraccionesDeCharacter", "m_InteraccionesDeCharacter null reference.");
			}
			this.m_SiendoGuiadoEnBonesPorCharacter = new SiendoGuiadoEnBonesPorCharacter(this, this.m_PrioridadesDeObjetoEstimulado);
			this.m_SiendoManipuladoEnBonesPorCharacter = new SiendoManipuladoEnBonesPorCharacter(this, this.m_PrioridadesDeObjetoEstimulado);
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00036784 File Offset: 0x00034984
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			CustomPosesDeFemaleCharacter componentInParent = base.GetComponentInParent<CustomPosesDeFemaleCharacter>();
			this.m_customInter = componentInParent.CustomInteraccionDeSkeleton(this.m_gizmoDeBone.gizmosDeSkeleton);
			this.m_PrepararCustomPoseOnEditMode = componentInParent.ObtenerPrepararCustomPoseOnEditMode(this.m_customInter.GetInteractionID());
			if (!this.m_gizmoDeBone.isStared)
			{
				this.m_gizmoDeBone.ManualStart();
			}
			this.m_selfSaver = this.GetComponentNotNull<IStepVelocitySaverEmulated, EmulatedStepVelocitySaver>();
			this.m_childernSaver = this.m_gizmoDeBone.children.Select((GizmoDeBone c) => c.GetComponentNotNull<IStepVelocitySaverEmulated, EmulatedStepVelocitySaver>()).ToArray<IStepVelocitySaverEmulated>();
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0003682A File Offset: 0x00034A2A
		public override void OnUpdateEvent2()
		{
			if (this.m_gizmoDeBone.boneFueMovido)
			{
				this.m_PoseQueExponePartesVestidas.StartOrStaySession();
				this.RegistrarGuiandoBoneEnAI();
				return;
			}
			this.m_PoseQueExponePartesVestidas.TryEndSession(false);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00036858 File Offset: 0x00034A58
		public float CalculeVelocidadRelativaEmulada()
		{
			Vector3 metrosPorSegundo = this.selfSaver.metrosPorSegundo;
			if (this.childernSaver.Count == 0)
			{
				return metrosPorSegundo.magnitude;
			}
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < this.childernSaver.Count; i++)
			{
				Vector3 metrosPorSegundo2 = this.childernSaver[i].metrosPorSegundo;
				if (metrosPorSegundo2.sqrMagnitude > vector.sqrMagnitude)
				{
					vector = metrosPorSegundo2;
				}
			}
			if (ExtendedMonoBehaviour.AlmostEqual(metrosPorSegundo, vector, 0.001f))
			{
				return metrosPorSegundo.magnitude;
			}
			vector = Vector3.Lerp(metrosPorSegundo, vector, 0.2f);
			return (vector - metrosPorSegundo).magnitude;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x000368FC File Offset: 0x00034AFC
		public void RegistrarManipulandoBoneEnAI()
		{
			if (this.m_customInter == InteraccionPrimariaName.None)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (!this.m_boneInfo.humanBone.TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano))
			{
				throw new InvalidOperationException();
			}
			if (this.m_PoseQueExponePartesVestidas.sessionPartsBeingExposed.Count > 0)
			{
				float num;
				ParteDelCuerpoHumano parteDelCuerpoHumano2;
				float? num2;
				ParteDelCuerpoHumano? parteDelCuerpoHumano3;
				bool flag = this.m_ConsentNecesario.TodosConsentidosConJerarquia(this.m_PoseQueExponePartesVestidas.sessionPartsBeingExposed, TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, out num, out parteDelCuerpoHumano2, out num2, out parteDelCuerpoHumano3, 1f, null, null, null);
				this.m_CambiarEstadoDeInteraccionesConAI.IDFlag = this.m_customInter.GetInteractionID();
				this.m_CambiarEstadoDeInteraccionesConAI.RegistrarToggle(MainChar.current, false, ParteQuePuedeEstimular.manos, flag, false, new float?(this.CalculeVelocidadRelativaEmulada()), false, false);
				return;
			}
			float num3;
			float num4;
			bool flag2 = this.m_ConsentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, out num3, out num4, 1f, null, null, null);
			ManipulacionDeBoneData manipulacionDeBoneData = new ManipulacionDeBoneData(MainChar.current, this.m_boneInfo.characterBone, flag2, true, parteDelCuerpoHumano);
			this.m_manipuladoEnFrameV2.Add(manipulacionDeBoneData);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00036A04 File Offset: 0x00034C04
		private void RegistrarGuiandoBoneEnAI()
		{
			if (this.m_customInter == InteraccionPrimariaName.None)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (!this.m_boneInfo.humanBone.TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano))
			{
				throw new InvalidOperationException();
			}
			Personalidad.Tipo tipo = this.m_ConsentNecesario.personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
			if (this.m_PoseQueExponePartesVestidas.sessionPartsBeingExposed.Count > 0)
			{
				float num;
				ParteDelCuerpoHumano parteDelCuerpoHumano2;
				float? num2;
				ParteDelCuerpoHumano? parteDelCuerpoHumano3;
				bool flag = this.m_ConsentNecesario.TodosConsentidosConJerarquia(this.m_PoseQueExponePartesVestidas.sessionPartsBeingExposed, TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, out num, out parteDelCuerpoHumano2, out num2, out parteDelCuerpoHumano3, 1f, null, null, null);
				bool flag2 = false;
				for (int i = 0; i < this.m_PoseQueExponePartesVestidas.sessionPartsBeingExposed.Count; i++)
				{
					if (this.m_ConsentForzado.EsCorrupted(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, this.m_PoseQueExponePartesVestidas.sessionPartsBeingExposed[i], ParteQuePuedeEstimular.boca, null))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2 && !flag && tipo != Personalidad.Tipo.sumiso)
				{
					this.m_gizmoDeBone.CancelarUltimoMovimiento();
				}
				this.m_PeticionEstadoDeInteraccionesConAI.IDFlag = this.m_customInter.GetInteractionID();
				this.m_PeticionEstadoDeInteraccionesConAI.RegistrarToggle(MainChar.current, false, ParteQuePuedeEstimular.boca, flag, false, new float?(this.CalculeVelocidadRelativaEmulada()), false, false);
				return;
			}
			float num3;
			float num4;
			bool flag3 = this.m_ConsentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, out num3, out num4, 1f, null, null, null);
			if (!this.m_ConsentForzado.EsCorrupted(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, null) && !flag3 && tipo != Personalidad.Tipo.sumiso)
			{
				this.m_gizmoDeBone.CancelarUltimoMovimiento();
			}
			ManipulacionDeBoneData manipulacionDeBoneData = new ManipulacionDeBoneData(MainChar.current, this.m_boneInfo.characterBone, flag3, false, parteDelCuerpoHumano);
			this.m_guiadosEnFrameV2.Add(manipulacionDeBoneData);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00036BBC File Offset: 0x00034DBC
		public override void OnUpdateEvent1()
		{
			bool activada = this.m_PrepararCustomPoseOnEditMode.activada;
			if (this.m_selfSaver.enabled != activada)
			{
				this.m_selfSaver.enabled = activada;
			}
			try
			{
				if (activada)
				{
					this.m_SiendoGuiadoEnBonesPorCharacter.Update_();
					this.m_SiendoManipuladoEnBonesPorCharacter.Update_();
				}
			}
			finally
			{
				this.m_guiadosEnFrameV2.Clear();
				this.m_manipuladoEnFrameV2.Clear();
			}
		}

		// Token: 0x04000846 RID: 2118
		public bool debugLog;

		// Token: 0x04000847 RID: 2119
		private GizmoDeBone m_gizmoDeBone;

		// Token: 0x04000848 RID: 2120
		private GizmoDeBoneRMInfo m_boneInfo;

		// Token: 0x04000849 RID: 2121
		private SiendoGuiadoEnBonesPorCharacter m_SiendoGuiadoEnBonesPorCharacter;

		// Token: 0x0400084A RID: 2122
		private SiendoManipuladoEnBonesPorCharacter m_SiendoManipuladoEnBonesPorCharacter;

		// Token: 0x0400084B RID: 2123
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x0400084C RID: 2124
		private Character m_character;

		// Token: 0x0400084D RID: 2125
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x0400084E RID: 2126
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x0400084F RID: 2127
		private PeticionEstadoDeInteraccionesConAI m_PeticionEstadoDeInteraccionesConAI;

		// Token: 0x04000850 RID: 2128
		private CambiarEstadoDeInteraccionesConAI m_CambiarEstadoDeInteraccionesConAI;

		// Token: 0x04000851 RID: 2129
		private List<ManipulacionDeBoneData> m_guiadosEnFrameV2 = new List<ManipulacionDeBoneData>();

		// Token: 0x04000852 RID: 2130
		private List<ManipulacionDeBoneData> m_manipuladoEnFrameV2 = new List<ManipulacionDeBoneData>();

		// Token: 0x04000853 RID: 2131
		private PoseQueExponePartesVestidas m_PoseQueExponePartesVestidas;

		// Token: 0x04000854 RID: 2132
		private IInteraccionesDeCharacter m_InteraccionesDeCharacter;

		// Token: 0x04000855 RID: 2133
		[SerializeField]
		[ReadOnlyUI]
		private InteraccionPrimariaName m_customInter;

		// Token: 0x04000856 RID: 2134
		private PrepararCustomPoseOnEditMode m_PrepararCustomPoseOnEditMode;

		// Token: 0x04000857 RID: 2135
		private IStepVelocitySaverEmulated m_selfSaver;

		// Token: 0x04000858 RID: 2136
		private IStepVelocitySaverEmulated[] m_childernSaver;
	}
}
