using System;
using Assets.Base.Tiempo.Runtime;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Semen
{
	// Token: 0x02000028 RID: 40
	[RequireComponent(typeof(EmisorDeSemenChain))]
	public class EmisorDeSemenChainSetContraSkinComponents : CustomMonobehaviour
	{
		// Token: 0x060000BE RID: 190 RVA: 0x000062C8 File Offset: 0x000044C8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emisor = base.GetComponent<EmisorDeSemenChain>();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000062DC File Offset: 0x000044DC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_emisor.onChainCreated += this.M_emisor_onChainCreated;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000062FB File Offset: 0x000044FB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_emisor != null)
			{
				this.m_emisor.onChainCreated -= this.M_emisor_onChainCreated;
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000632C File Offset: 0x0000452C
		private void M_emisor_onChainCreated(SemenChain arg1, EmisorDeSemenChain arg2)
		{
			for (int i = 0; i < arg1.semenPuntos.Count; i++)
			{
				SemenPunto semenPunto = arg1.semenPuntos[i];
				SonidoProductor sonidoProductor = semenPunto.gameObject.AddComponent<SonidoProductor>();
				semenPunto.gameObject.AddComponent<DestroyGameObjectAfterTiempoDeJuego>().duration = 3600f;
				sonidoProductor.textura = TexturaDeObjetoSonoro.liquido;
				sonidoProductor.forma = FormaDeObjetoSonoro.circular;
				semenPunto.gameObject.AddComponent<SemenPuntoCollisionContraSkin>();
				semenPunto.gameObject.AddComponent<SemenMeshToSkinMesh>();
			}
		}

		// Token: 0x040000A1 RID: 161
		private EmisorDeSemenChain m_emisor;
	}
}
