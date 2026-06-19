using System;
using System.Collections.Generic;
using Assets._ReusableScripts;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x0200001E RID: 30
	public class FemaleFullBodyBipedIKs_Simple : AplicableBehaviour, IFemaleFullBodyBipedIKs
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00006AA3 File Offset: 0x00004CA3
		public int cantidadDeIKs
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00006AA6 File Offset: 0x00004CA6
		public int cantidadDeLayers
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00006AA9 File Offset: 0x00004CA9
		public FullBodyBipedIK user
		{
			get
			{
				return this.m_primario;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00006AB4 File Offset: 0x00004CB4
		public List<FullBodyBipedIK> fullBodyBipedIKs
		{
			get
			{
				if (this.m_iks == null)
				{
					this.m_iks = new List<FullBodyBipedIK>();
				}
				if (this.m_iks.Count == 0)
				{
					if (this.m_primario == null)
					{
						throw new ArgumentNullException("m_primario", "m_primario null reference.");
					}
					this.m_iks.Add(this.m_primario);
				}
				return this.m_iks;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00006B16 File Offset: 0x00004D16
		public IReadOnlyList<FullBodyBipedIK> allFullBodyBipedIKs
		{
			get
			{
				return this.fullBodyBipedIKs;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00006B1E File Offset: 0x00004D1E
		public IReadOnlyList<FullBodyBipedIK> primarios
		{
			get
			{
				return this.fullBodyBipedIKs;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00006B26 File Offset: 0x00004D26
		public IReadOnlyList<FullBodyBipedIK> segundarios
		{
			get
			{
				return this.fullBodyBipedIKs;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006B30 File Offset: 0x00004D30
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			List<FullBodyBipedIK> fullBodyBipedIKs = this.fullBodyBipedIKs;
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			foreach (FullBodyBipedIK fullBodyBipedIK in this.m_iks)
			{
				fullBodyBipedIK.SetAnimator(componentInParent.bodyAnimator);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006BC0 File Offset: 0x00004DC0
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006BC8 File Offset: 0x00004DC8
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00006BD4 File Offset: 0x00004DD4
		[Obsolete("", true)]
		public FullBodyBipedIK ObtenerFullBodyBipedIKDePasada(int index)
		{
			FullBodyBipedIK fullBodyBipedIK;
			try
			{
				fullBodyBipedIK = this.fullBodyBipedIKs[index];
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("index " + index.ToString() + ", no existe en iks de " + base.name, ex);
			}
			return fullBodyBipedIK;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00006C28 File Offset: 0x00004E28
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Update IKs Referencias",
				playTimeVisible = false
			};
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006C41 File Offset: 0x00004E41
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.UpdateIKsReferencias();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00006C50 File Offset: 0x00004E50
		public void UpdateIKsReferencias()
		{
			if (Application.isPlaying)
			{
				throw new InvalidOperationException();
			}
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			BipedReferences bipedReferences = null;
			BipedReferences.AutoDetectReferences(ref bipedReferences, componentEnRoot.transform, new BipedReferences.AutoDetectParams(true, false));
			foreach (FullBodyBipedIK fullBodyBipedIK in this.fullBodyBipedIKs)
			{
				fullBodyBipedIK.solver.rootNode = IKSolverFullBodyBiped.DetectRootNodeBone(bipedReferences);
				fullBodyBipedIK.SetReferences(bipedReferences, fullBodyBipedIK.solver.rootNode);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006D04 File Offset: 0x00004F04
		public void SwitchPrimarios()
		{
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00006D06 File Offset: 0x00004F06
		public void SwitchSegundarios()
		{
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00006D08 File Offset: 0x00004F08
		public FullBodyBipedIK ObtenerCurrentFullBodyBipedIKDeLayer(int layer)
		{
			return this.m_primario;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006D10 File Offset: 0x00004F10
		public FullBodyBipedIK ObtenerCurrentFullBodyBipedIKDeID(int id)
		{
			if (id == 0)
			{
				return this.m_primario;
			}
			return null;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006D1D File Offset: 0x00004F1D
		public IReadOnlyList<FullBodyBipedIK> ObtenerFullBodyBipedIKsDeLayer(int layer)
		{
			if (layer == 0)
			{
				return this.fullBodyBipedIKs;
			}
			return null;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00006D2A File Offset: 0x00004F2A
		public int GetId(FullBodyBipedIK IK)
		{
			if (this.m_primario == IK)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00006D3D File Offset: 0x00004F3D
		public int GetLayerDeIK(FullBodyBipedIK IK)
		{
			if (this.m_primario == IK)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006D50 File Offset: 0x00004F50
		public int GetIndexInLayerDeIK(FullBodyBipedIK IK, out bool ultimoDeLayer)
		{
			ultimoDeLayer = true;
			if (this.m_primario == IK)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006D66 File Offset: 0x00004F66
		public int CantidadDePasadasDeIK(FullBodyBipedIK IK)
		{
			return 2;
		}

		// Token: 0x040000A8 RID: 168
		private IIKUpdater m_updater;

		// Token: 0x040000A9 RID: 169
		[SerializeField]
		private FullBodyBipedIK m_primario;

		// Token: 0x040000AA RID: 170
		private List<FullBodyBipedIK> m_iks = new List<FullBodyBipedIK>();
	}
}
