using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x020000C8 RID: 200
	[RequireComponent(typeof(InterpretadorDeFemales))]
	public class ProfileLoaderToCharacter : AplicableCustomMonobehaviour
	{
		// Token: 0x060004D4 RID: 1236 RVA: 0x0001867F File Offset: 0x0001687F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interpretador = base.GetComponent<InterpretadorDeFemales>();
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00018693 File Offset: 0x00016893
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Do Load"
			};
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000186AC File Offset: 0x000168AC
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			AutoRatingProfile autoRatingProfile = Singleton<SimplifiedAutoRatings>.instance.autoRatingProfile;
			if (autoRatingProfile == null)
			{
				return;
			}
			this.m_interpretador.interpretacion = autoRatingProfile.completa;
			this.m_interpretador.InverseInterpretar();
		}

		// Token: 0x0400023C RID: 572
		private InterpretadorDeFemales m_interpretador;
	}
}
