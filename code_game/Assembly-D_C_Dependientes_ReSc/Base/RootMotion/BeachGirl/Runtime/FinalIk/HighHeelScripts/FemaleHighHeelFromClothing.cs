using System;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.HighHeelScripts
{
	// Token: 0x02000021 RID: 33
	[RequireComponent(typeof(FemaleHighHeelSystem))]
	public class FemaleHighHeelFromClothing : CustomMonobehaviour
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00004F8B File Offset: 0x0000318B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleHighHeelSystem = base.GetComponent<FemaleHighHeelSystem>();
			this.m_ArmatureSkins = this.GetComponentEnRoot(false);
			if (this.m_ArmatureSkins == null)
			{
				throw new ArgumentNullException("m_ArmatureSkins", "m_ArmatureSkins null reference.");
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004FCC File Offset: 0x000031CC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ArmatureSkins.skinRemoved += this.M_ArmatureSkins_skinRemoved;
			this.m_ArmatureSkins.skinHidden += this.M_ArmatureSkins_skinHidden;
			this.m_ArmatureSkins.skinAdded += this.M_ArmatureSkins_skinAdded;
			this.m_ArmatureSkins.skinShowed += this.M_ArmatureSkins_skinShowed;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000503C File Offset: 0x0000323C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_ArmatureSkins != null)
			{
				this.m_ArmatureSkins.skinRemoved -= this.M_ArmatureSkins_skinRemoved;
				this.m_ArmatureSkins.skinHidden -= this.M_ArmatureSkins_skinHidden;
				this.m_ArmatureSkins.skinAdded -= this.M_ArmatureSkins_skinAdded;
				this.m_ArmatureSkins.skinShowed -= this.M_ArmatureSkins_skinShowed;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000050BA File Offset: 0x000032BA
		private void M_ArmatureSkins_skinShowed(ArmatureSkins arg1, Skin arg2)
		{
			this.AddHeelState(arg2);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000050BA File Offset: 0x000032BA
		private void M_ArmatureSkins_skinAdded(ArmatureSkins arg1, Skin arg2)
		{
			this.AddHeelState(arg2);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000050C3 File Offset: 0x000032C3
		private void M_ArmatureSkins_skinHidden(ArmatureSkins arg1, Skin arg2)
		{
			this.RemoveHeelState(arg2);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000050C3 File Offset: 0x000032C3
		private void M_ArmatureSkins_skinRemoved(ArmatureSkins arg1, Skin arg2)
		{
			this.RemoveHeelState(arg2);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000050CC File Offset: 0x000032CC
		private void RemoveHeelState(Skin skin)
		{
			PiezaDeRopaBase piezaDeRopaBase = skin as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.RemoveHeelState(piezaDeRopaBase);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000050F4 File Offset: 0x000032F4
		private void AddHeelState(Skin skin)
		{
			PiezaDeRopaBase piezaDeRopaBase = skin as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.AddHeelState(piezaDeRopaBase);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000511C File Offset: 0x0000331C
		private void RemoveHeelState(PiezaDeRopaBase ropa)
		{
			this.m_FemaleHighHeelSystem.heelHeight.RemoverModificador(ropa);
			this.m_FemaleHighHeelSystem.toeHeight.RemoverModificador(ropa);
			this.m_FemaleHighHeelSystem.heelPoseWeight.RemoverModificador(ropa);
			this.m_FemaleHighHeelSystem.toePoseWeight.RemoverModificador(ropa);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005170 File Offset: 0x00003370
		private void AddHeelState(PiezaDeRopaBase ropa)
		{
			ModificadorDeFloatBase modificadorDeFloatBase = this.m_FemaleHighHeelSystem.heelHeight.ObtenerModificadorNotNull(ropa);
			ModificadorDeFloat modificadorDeFloat = this.m_FemaleHighHeelSystem.toeHeight.ObtenerModificadorNotNull(ropa);
			modificadorDeFloatBase.valor.valor = ropa.dataDeRopa.shoesConfig.heelHeigth;
			modificadorDeFloat.valor.valor = ropa.dataDeRopa.shoesConfig.toeHeigth;
			ModificadorDeFloatBase modificadorDeFloatBase2 = this.m_FemaleHighHeelSystem.heelPoseWeight.ObtenerModificadorNotNull(ropa);
			ModificadorDeFloat modificadorDeFloat2 = this.m_FemaleHighHeelSystem.toePoseWeight.ObtenerModificadorNotNull(ropa);
			modificadorDeFloatBase2.valor.valor = ropa.dataDeRopa.shoesConfig.heelPoseWeigth;
			modificadorDeFloat2.valor.valor = ropa.dataDeRopa.shoesConfig.toePoseWeigth;
		}

		// Token: 0x04000081 RID: 129
		private FemaleHighHeelSystem m_FemaleHighHeelSystem;

		// Token: 0x04000082 RID: 130
		private ArmatureSkins m_ArmatureSkins;
	}
}
